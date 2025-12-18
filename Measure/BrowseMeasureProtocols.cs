using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace DigitalProductionProgram.Measure
{
    public partial class BrowseMeasureProtocols : Form
    {
        private CartesianChart? cartesianChart;

        private double LSL;
        private double LCL;
        private double USL;
        private double UCL;
        
        private static readonly Font ItalicFont = new Font("Courier New", 8, FontStyle.Italic);

        private string Query_TopList
        {
            get
            {
                var query = @"SELECT TOP 15 AnstNr, Count(*) AS Count FROM Measureprotocol.MainData WHERE ";
                if (cb_Workoperations.Text == Manage_WorkOperation.WorkOperations.Nothing.ToString())
                    query += "Date BETWEEN @date_from AND @date_to GROUP BY AnstNr ORDER BY Count DESC";
                else
                    query += @"EXISTS (SELECT * FROM [Order].MainData  
                                    WHERE Measureprotocol.MainData.OrderID = [Order].MainData.OrderID
                                        AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL))
                                AND Date BETWEEN @date_from AND @date_to GROUP BY AnstNr ORDER BY Count DESC";
                return query;
            }

        }
        private bool IsOkAddPoints;
        private string Column_Name => dgv_MeasureProtocol.Columns[dgv_MeasureProtocol.CurrentCell.ColumnIndex].Name;

        private double Max_Y_Value
        {
            get
            {
                var values = new List<double>();

                foreach (DataGridViewRow row in dgv_MeasureProtocol.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var discardedCell = row.Cells["Discarded"];
                    var valueCell = row.Cells[Column_Name];

                    if (valueCell?.Value == null)
                        continue;

                    bool isDiscarded = discardedCell.Value switch
                    {
                        bool b => b,
                        int i => i != 0,
                        string s when s.Equals("true", StringComparison.OrdinalIgnoreCase) => true,
                        string s when s.Equals("false", StringComparison.OrdinalIgnoreCase) => false,
                        string s when int.TryParse(s, out var num) => num != 0,
                        _ => false
                    };

                    if (isDiscarded)
                        continue;

                    if (double.TryParse(valueCell.Value.ToString(), out var value))
                        values.Add(value);
                }

                if (values.Count == 0)
                    return 0;

                var avg = values.Average();
                var filtered = values.Where(v => v < avg * 10).ToList();

                return Math.Max(USL, filtered.Count > 0 ? filtered.Max() : 0);
            }
        }
        private double Min_Y_Value
        {
            get
            {
                var values = new List<double>();

                foreach (DataGridViewRow row in dgv_MeasureProtocol.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var cell = row.Cells[Column_Name];
                    var discardedCell = row.Cells["Discarded"];

                    if (cell?.Value == null)
                        continue;

                    // Säkrare tolkning av Discarded
                    bool isDiscarded = discardedCell.Value switch
                    {
                        bool b => b,
                        int i => i != 0,
                        string s when s.Equals("true", StringComparison.OrdinalIgnoreCase) => true,
                        string s when s.Equals("false", StringComparison.OrdinalIgnoreCase) => false,
                        string s when int.TryParse(s, out var num) => num != 0,
                        _ => false
                    };

                    if (isDiscarded)
                        continue;

                    if (double.TryParse(cell.Value.ToString(), out var value))
                        values.Add(value);
                }

                if (values.Count == 0)
                    return 0;

                // Snitt
                var avg = values.Average();

                // Rimlighetsfilter: ignorera orimligt små värden (t.ex. < 1/10 av snittet)
                var filtered = values.Where(v => v > avg / 10).ToList();
                var minVal = filtered.Count > 0 ? filtered.Min() : 0;

                // Om LSL är satt (> 0), ta minsta av LSL och datavärdet
                if (LSL > 0)
                    return Math.Min(LSL, minVal);

                // Annars returnera bara det minsta datavärdet
                return minVal;
            }
        }

        private (string CountQuery, string SelectQuery, List<SqlParameter> Params) BuildMeasureQueries(List<string> orders)
        {
            string baseCondition = @"
        orders.PartNr = @partnr
        AND orders.MeasureProtocolMainTemplateID = (
            SELECT MeasureProtocolMainTemplateID
            FROM MeasureProtocol.MainTemplate
            WHERE Name = @name AND Revision = @revision
        )";

            var parameters = new List<SqlParameter>
    {
        new("@partnr", tb_PartNr.Text),
        new("@name", cb_MeasureprotocolTemplateName.Text),
        new("@revision", cb_MeasureTemplateRevision.Text)
    };

            string orderFilter = "";
            if (orders.Count > 0)
            {
                var inParams = string.Join(",", orders.Select((_, i) => $"@order{i}"));
                orderFilter = $" AND orders.OrderNr IN ({inParams})";
                for (int i = 0; i < orders.Count; i++)
                    parameters.Add(new SqlParameter($"@order{i}", orders[i]));
            }

            string countQuery = $@"
        SELECT COUNT(*) 
        FROM MeasureProtocol.Data AS data
        JOIN [Order].MainData AS orders ON data.OrderID = orders.OrderID
        WHERE {baseCondition}{orderFilter};";

            string selectQuery = $@"
        SELECT 
            Parameter_UserText, orders.OrderNr, orders.Operation, Value, TextValue,
            BoolValue, Date, Discarded, ErrorCode, AnstNr, Sign, Decimals, DataType,
            main.RowIndex, template.ColumnIndex, maintemplate.Revision
        FROM MeasureProtocol.Data AS data
        JOIN [Order].MainData AS orders ON data.OrderID = orders.OrderID
        JOIN MeasureProtocol.Template AS template
            ON template.MeasureProtocolMainTemplateID = orders.MeasureProtocolMainTemplateID
            AND template.DescriptionID = data.DescriptionId
        JOIN MeasureProtocol.MainTemplate AS maintemplate
            ON template.MeasureProtocolMainTemplateID = maintemplate.MeasureProtocolMainTemplateID
        JOIN MeasureProtocol.MainData AS main
            ON data.RowIndex = main.RowIndex AND data.OrderID = main.OrderID
        WHERE {baseCondition}{orderFilter}
        ORDER BY data.OrderID, main.RowIndex, ColumnIndex;";

            return (countQuery, selectQuery, parameters);
        }


        private double Y_Interval
        {
            get
            {
                switch (Column_Name)
                {
                    case "ID":
                    case "OD":
                    case "Wall":
                        return 0.04;
                    case "Oval":
                    case "RunOut":
                        return 0.5;
                }
                return 0;
            }
        }
        private bool isTemplateHaveMultipleRevisions { get; set; }
        private bool IsTemplateHaveMultipleRevisions
        {
            get
            {
                if (string.IsNullOrEmpty(tb_PartNr.Text))
                    return false;
                IsLoading = true;

                cb_MeasureprotocolTemplateName.Items.Clear();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT DISTINCT MeasureprotocolTemplateRevision 
                        FROM [Order].MainData 
                        WHERE PartNr = @partnr";

                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partnr", tb_PartNr.Text);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var revision = reader[0].ToString();
                        // cb_MeasureMainTemplateID.Items.Add(revision);
                    }

                }

                if (cb_MeasureprotocolTemplateName.Items.Count > 1)
                {
                    //label_MeasureTemplateRevision.Visible = true;
                    cb_MeasureprotocolTemplateName.Visible = true;
                    // InfoText.Show(LanguageManager.GetString("multipleRevisionsMeasureTemnplate"), CustomColors.InfoText_Color.Info, "Warning!", this);
                    isTemplateHaveMultipleRevisions = true;
                    cb_MeasureprotocolTemplateName.Select();
                    IsLoading = false;
                    cb_MeasureprotocolTemplateName.SelectedIndex = 0;
                    return true;
                }

                // cb_MeasureMainTemplateID.SelectedIndex = 0;

                // label_MeasureTemplateRevision.Visible = false;
                // cb_MeasureMainTemplateID.Visible = false;
                isTemplateHaveMultipleRevisions = false;
                IsLoading = false;
                return false;
            }
        }

        private bool IsLoading;


        public BrowseMeasureProtocols()
        {
            Order.Save_TempOrderInfo();

            Log.Activity.Start();
            InitializeComponent();

            Fill_WorkOperation();

            IsOkAddPoints = false;

            if (Order.WorkOperation != Manage_WorkOperation.WorkOperations.Nothing)
                cb_Workoperations.Text = Order.WorkOperation.ToString();

            _ = Log.Activity.Stop("Sökning Mätprotokoll");
        }
        private void BrowseMeasureProtocols_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order.PartNumber) == false)
            {
                tb_PartNr.Text = Order.PartNumber;
                Load_Data();
            }
            Fill_Toplist();
        }


        public void Fill_Toplist()
        {
            dgv_TopList.DataSource = null;
            var dt = new DataTable();
            dt.Columns.Add("Namn", typeof(string));

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                var cmd = new SqlCommand(Query_TopList, con);
                cmd.Parameters.AddWithValue("@date_from", date_From.Value);
                cmd.Parameters.AddWithValue("@date_to", DateTime.Now);
                cmd.Parameters.AddWithValue("@workoperation", cb_Workoperations.Text);
                dt.Load(cmd.ExecuteReader());
            }

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["Namn"] = Person.Get_NameWithAnstNr(dt.Rows[i]["AnstNr"].ToString());
                if (string.IsNullOrEmpty(dt.Rows[i]["Namn"].ToString()))
                    dt.Rows[i]["Namn"] = "# Namn saknas " + dt.Rows[i]["AnstNr"];

            }
            dt.Columns.Remove("AnstNr");

            dgv_TopList.DataSource = dt;
            dgv_TopList.Columns[0].Width = 160;
            dgv_TopList.Columns[1].Width = 50;

        }
        private void Fill_WorkOperation()
        {
            Manage_WorkOperation.Fill_cb_Workoperation(cb_Workoperations);
        }
        private void MeasureTemplateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_MeasureTemplateRevision.Items.Clear();

            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            var query = $@"
                  SELECT DISTINCT Revision
                    FROM MeasureProtocol.MainTemplate
                    WHERE Name = @name";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", cb_MeasureprotocolTemplateName.Text);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cb_MeasureTemplateRevision.Items.Add(reader["Revision"].ToString());
            }
            cb_MeasureTemplateRevision.SelectedIndex = cb_MeasureTemplateRevision.Items.Count - 1;
        }
        private void Workoperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Toplist();
        }
        private void PartNr_MouseClick(object sender, MouseEventArgs e)
        {
            List<string> partnumbers = new List<string>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT DISTINCT PartNr  
                    FROM [Order].MainData
                    WHERE WorkoperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@workoperation", cb_Workoperations.Text);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    partnumbers?.Add(reader[0].ToString());
            }

            var partnr = new Choose_Item(partnumbers, new Control[] { tb_PartNr }, false);
            partnr.ShowDialog();
            Load_Data();
        }

        private void chkList_ListOrders_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                // Förhindra rekursion
                chkList_ListOrders.ItemCheck -= chkList_ListOrders_ItemCheck;

                bool checkAll = e.NewValue == CheckState.Checked;

                for (int i = 1; i < chkList_ListOrders.Items.Count; i++)
                {
                    chkList_ListOrders.SetItemChecked(i, checkAll);
                }

                chkList_ListOrders.ItemCheck += chkList_ListOrders_ItemCheck;
            }
        }
        private void chkList_ListOrders_MouseDown(object sender, MouseEventArgs e)
        {
            var index = chkList_ListOrders.IndexFromPoint(e.Location);

            if (index != ListBox.NoMatches)
            {
                bool current = chkList_ListOrders.GetItemChecked(index);
                chkList_ListOrders.SetItemChecked(index, !current);
            }
        }
        private void PartNr_TextChanged(object sender, EventArgs e)
        {
            using var con = new SqlConnection(Database.cs_Protocol);

            var query = @"
                SELECT DISTINCT maintemplate.MeasureProtocolMainTemplateID AS ID, Name 
                FROM [Order].MainData as orders
                    JOIN MeasureProtocol.MainTemplate as maintemplate
                        ON orders.MeasureProtocolMainTemplateID = maintemplate.MeasureProtocolMainTemplateID
                WHERE PartNr = @partnr 
                    AND orders.WorkOperationID = 
                    (
                        SELECT ID 
                        FROM WorkOperation.Names 
                        WHERE Name = @workoperation
                    )";

            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@partnr", tb_PartNr.Text);
            cmd.Parameters.AddWithValue("@workoperation", cb_Workoperations.Text);

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);

            cb_MeasureprotocolTemplateName.DataSource = dt;
            cb_MeasureprotocolTemplateName.DisplayMember = "Name";
            cb_MeasureprotocolTemplateName.ValueMember = "ID";
        }
        private void LoadOrder_Click(object sender, EventArgs e)
        {
            Load_Data();
        }
        private void ExportDataToExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv_MeasureProtocol.Columns)
            {
                dt.Columns.Add(column.HeaderText);
            }
            foreach (DataGridViewRow row in dgv_MeasureProtocol.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int i = 0; i < dgv_MeasureProtocol.Columns.Count; i++)
                {
                    dr[i] = row.Cells[i].Value;
                }
                dt.Rows.Add(dr);
            }
            Get_Protocol_Data.TransferDataToExcel.MeasurementData(dt, tb_PartNr.Text);

        }



        private void Load_Data()
        {
            if (string.IsNullOrEmpty(cb_Workoperations.Text))
                return;
            if (string.IsNullOrEmpty(tb_PartNr.Text))
                return;
            Load_MeasureData();

        }
        private async void Load_MeasureData()
        {
            if (IsLoading) return;
            var pbar = new CustomProgressBar(1);
            pbar.Show(this);

            try
            {
                dgv_MeasureProtocol.Rows.Clear();
                if (string.IsNullOrEmpty(tb_PartNr.Text)) return;

                await using var con = new SqlConnection(Database.cs_Protocol);
                await con.OpenAsync();

                var checkedOrders = chkList_ListOrders.CheckedItems.Cast<string>().ToList();
                var (countQuery, selectQuery, parameters) = BuildMeasureQueries(checkedOrders);

                // COUNT
                int totalRows;
                await using (var countCmd = new SqlCommand(countQuery, con))
                {
                    countCmd.Parameters.AddRange(parameters.ToArray());
                    totalRows = (int)await countCmd.ExecuteScalarAsync();
                }
                // DATA
                var rows = await LoadMeasureRowsAsync(con, selectQuery, parameters);

                // Fyll UI
                chkList_ListOrders.Items.Clear();
                chkList_ListOrders.Items.Add("Markera alla");
                Load_InputControls();

                int row = -1, lastRow = -1;
                int processed = 0;

                foreach (var item in rows)
                {
                    if (!chkList_ListOrders.Items.Contains(item.OrderNr))
                        chkList_ListOrders.Items.Add(item.OrderNr, true);

                    processed++;
                    double percent = processed * 100.0 / totalRows;
                    bool refresh = processed % 50 == 0;
                    pbar.Set_ValueProgressBar(percent, $"Laddar data: OrderNr {item.OrderNr}", 1, refresh);

                    if (item.RowIndex != lastRow)
                    {
                        lastRow = item.RowIndex;
                        dgv_MeasureProtocol.Rows.Add();
                        row++;
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["OrderNr"], item.OrderNr, item.Discarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Operation"], item.Operation, item.Discarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Date"], item.Date, item.Discarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["ErrorCode"], item.ErrorCode, item.Discarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["AnstNr"], item.AnstNr, item.Discarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Sign"], item.Sign, item.Discarded);
                    }

                    string text = item.DataType switch
                    {
                        "0" => item.Value.HasValue ? Measurement_Protocol.SetDecimals_Value(item.Value.Value, item.Decimals) : "N/A",
                        "1" => item.TextValue ?? "N/A",
                        "2" => item.BoolValue == true ? "\u2714" : "N/A",
                        _ => "N/A"
                    };

                    Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells[item.ColumnIndex + 2], text, item.Discarded, item.ParameterText);
                }

                lbl_TotalOrders.Text = $"Totalt {chkList_ListOrders.Items.Count} ordrar:";
            }
            finally
            {
                pbar.Close();
            }
        }

        private async Task<List<MeasureRow>> LoadMeasureRowsAsync(SqlConnection con, string query, IEnumerable<SqlParameter> parameters)
        {
            var list = new List<MeasureRow>();
            await using var cmd = new SqlCommand(query, con);

            // Lägg till NYA instanser av varje parameter
            foreach (var p in parameters)
                cmd.Parameters.AddWithValue(p.ParameterName, p.Value);

            await using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var row = new MeasureRow
                {
                    OrderNr = reader["OrderNr"]?.ToString(),
                    Revision = reader["Revision"]?.ToString(),
                    RowIndex = reader.IsDBNull(reader.GetOrdinal("RowIndex")) ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("RowIndex"))),
                    ColumnIndex = reader.IsDBNull(reader.GetOrdinal("ColumnIndex")) ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ColumnIndex"))),
                    ParameterText = reader["Parameter_UserText"]?.ToString(),
                    Operation = reader["Operation"]?.ToString(),
                    DataType = reader["DataType"]?.ToString(),
                    ErrorCode = reader["ErrorCode"]?.ToString(),
                    AnstNr = reader["AnstNr"]?.ToString(),
                    Sign = reader["Sign"]?.ToString(),
                    Discarded = !reader.IsDBNull(reader.GetOrdinal("Discarded")) && reader.GetBoolean(reader.GetOrdinal("Discarded")),
                    Value = reader.IsDBNull(reader.GetOrdinal("Value")) ? null : reader.GetDouble(reader.GetOrdinal("Value")),
                    TextValue = reader["TextValue"]?.ToString(),
                    BoolValue = reader.IsDBNull(reader.GetOrdinal("BoolValue")) ? null : reader.GetBoolean(reader.GetOrdinal("BoolValue")),
                    Decimals = reader.IsDBNull(reader.GetOrdinal("Decimals")) ? 0 : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("Decimals"))),
                    Date = reader["Date"]?.ToString()
                };
                list.Add(row);
            }

            return list;
        }


        private void Load_MeasurePoints()
        {
            int rowIndex = dgv_MeasureProtocol.CurrentCell.RowIndex;
            string activeOrderNr = null;
            do
            {
                if (rowIndex == dgv_MeasureProtocol.Rows.Count)
                    break;
                var ordernr = dgv_MeasureProtocol.Rows[rowIndex].Cells["OrderNr"].Value.ToString();
                var operation = dgv_MeasureProtocol.Rows[rowIndex].Cells["Operation"].Value?.ToString() ?? string.Empty;
                if (ordernr == activeOrderNr && rowIndex != 0)
                {
                    rowIndex++;
                    continue;
                }

                Monitor.Monitor.Load_DataTable_Measurpoints(ordernr, operation, false);
                //Set_MeasurePoints();
                //if (IsMeasurePointSet)
                //    measurePoints.AddMeasurePointsMainForm();
                rowIndex++;
                activeOrderNr = ordernr;
            } while (IsMeasurePointSet == false);

        }

        private bool IsMeasurePointSet;
        private void Set_MeasurePoints()
        {
            LSL = 0;
            LCL = 0;
            UCL = 0;
            USL = 0;
            IsMeasurePointSet = false;
            if (Monitor.Monitor.DataTable_Measurepoints != null)
                foreach (DataRow row in Monitor.Monitor.DataTable_Measurepoints.Rows)
                {
                    var codename = row[0].ToString();
                    if (codename == Column_Name)
                    {
                        double.TryParse(row[5].ToString(), out LSL);
                        double.TryParse(row[4].ToString(), out LCL);
                        double.TryParse(row[2].ToString(), out UCL);
                        double.TryParse(row[1].ToString(), out USL);
                        if (codename.Contains("Concentricity"))
                        {
                            LSL *= 100;
                            LCL *= 100;
                            USL *= 100;
                            UCL *= 100;
                        }
                        IsMeasurePointSet = true;
                    }
                }
        }
        public void Load_InputControls()
        {
            dgv_MeasureProtocol.Columns.Clear();
            Add_Column_DatagridView(dgv_MeasureProtocol, "OrderNr", "OrderNr", 80);
            Add_Column_DatagridView(dgv_MeasureProtocol, "Operation", "Op.", 0);
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT Parameter_UserText, CodeName, ColumnWidth, MaxChars
                    FROM MeasureProtocol.Template as template
                        JOIN MeasureProtocol.Description as description
                            ON template.DescriptionID = description.Id 
                    WHERE MeasureProtocolMainTemplateID = (SELECT MeasureProtocolMainTemplateID FROM MeasureProtocol.MainTemplate WHERE Name = @name AND Revision = @revision)
                    ORDER BY ColumnIndex";

            var cmd = new SqlCommand(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@name", cb_MeasureprotocolTemplateName.Text);
            cmd.Parameters.AddWithValue("@revision", cb_MeasureTemplateRevision.Text);

            var reader = cmd.ExecuteReader();
            if (reader.HasRows == false)
            {
                InfoText.Show("Denna order saknar av någon anledning en mätprotokollsrevision. \nKontakta Admin för hjälp.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            while (reader.Read())
            {
                int.TryParse(reader["ColumnWidth"].ToString(), out var width);
                var name = reader["CodeName"].ToString();
                Add_Column_DatagridView(dgv_MeasureProtocol, name, reader["Parameter_UserText"].ToString(), width);
            }

            Add_Column_DatagridView(dgv_MeasureProtocol, "Date", "Datum-Tid", 140);
            Add_Column_DatagridView(dgv_MeasureProtocol, "ErrorCode", "Felkod", 40);
            Add_Column_DatagridView(dgv_MeasureProtocol, "AnstNr", "AnstNr", 50);
            Add_Column_DatagridView(dgv_MeasureProtocol, "Sign", "Sign", 50);
            Add_Column_DatagridView(dgv_MeasureProtocol, "Discarded", "Discarded", 0);
        }
        private static void Add_Column_DatagridView(DataGridView dgv, string name, string headerText, int width)
        {
            dgv.Columns.Add(name, headerText);
            dgv.Columns[name].Width = width;
            dgv.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
            if (width == 0)
                dgv.Columns[name].Visible = false;
        }

        private void Add_Text_DatagridCell(int row, DataGridViewCell cell, string text, bool IsDiscarded, string CodeText = null)
        {
            if (IsDiscarded)
            {
                cell.Style = new DataGridViewCellStyle
                {
                    BackColor = CustomColors.Discarded_Back,
                    ForeColor = CustomColors.Discarded_Front,
                    Font = CustomFonts.DiscardedFont
                };
            }
            else if (string.IsNullOrEmpty(text) || ControlValidator.IsStringNA(text))
            {
                cell.Style = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.Red,
                    //Font = ItalicFont
                };
                text = "N/A";
            }
            else
            {
                MeasurementValidator.DataVerification_Value_dgv(dgv_MeasureProtocol, text, CodeText, row, cell.ColumnIndex);
            }

            cell.Value = text;
        }









        private List<RectangularSection> sections
        {
            get
            {
                var sections = new List<RectangularSection>();
                if (USL > 0)
                    sections.Add(new RectangularSection
                    {
                        Yi = USL,
                        Yj = Max_Y_Value * (1 + marginPercent / 100),
                        Fill = new SolidColorPaint(new SKColor(156, 0, 6, 230))
                    }
                    );
                if (LSL > 0)
                    sections.Add(new RectangularSection
                    {
                        Yi = Min_Y_Value * (1 - marginPercent / 100),
                        Yj = LSL,
                        Fill = new SolidColorPaint(new SKColor(156, 0, 6, 230))
                    }
                    );
                if (UCL > 0)
                    sections.Add(new RectangularSection
                    {
                        Yi = UCL,
                        Yj = USL,
                        Fill = new SolidColorPaint(new SKColor(156, 101, 0, 230))
                    }
                    );
                if (LCL > 0)
                    sections.Add(new RectangularSection
                    {
                        Yi = LCL,
                        Yj = LSL,
                        Fill = new SolidColorPaint(new SKColor(156, 101, 6, 230))
                    });
                return sections;
            }

        }
        private CartesianChart chart(string codeText)
        {
            var chart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                XAxes = new[]
                {
                    new Axis
                    {
                        Name = "OrderNr",
                        TextSize = 12,
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                        SeparatorsPaint = new SolidColorPaint(SKColors.Black),
                        Labels = listOrderNr,
                        LabelsRotation = 45,
                        ShowSeparatorLines = false,
                        MinLimit = 10,
                        MinStep = 10
                    }
                },
                YAxes = new[]
                {
                    new Axis
                    {
                        Name = codeText,
                        TextSize = 12,
                        Labeler = value => $"{value:F3} mm",
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                        SeparatorsPaint = new SolidColorPaint(SKColors.Black),
                        MinLimit = Min_Y_Value * (1 - marginPercent / 100),
                        MaxLimit = Max_Y_Value * (1 + marginPercent / 100),
                        MinStep = 0.002, // Stegstorlek för y-axeln
                    }
                },
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Right,
                LegendTextPaint = new SolidColorPaint
                {
                    Color = SKColors.White,
                    SKTypeface = SKTypeface.Default,
                },
                LegendTextSize = 12,
                ZoomMode = LiveChartsCore.Measure.ZoomAndPanMode.X, // Aktivera zoomning och panorering på både X- och Y-axlar
            };
            return chart;
        }

        readonly List<string> listOrderNr = new();
        private string activeOrderNr;
        private void MätProtokoll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tb_PartNr.Text == string.Empty)
                return;

            if (dgv_MeasureProtocol.CurrentCell == null)
                return;

            var col = dgv_MeasureProtocol.CurrentCell.ColumnIndex;

            if (col < 0 || col >= dgv_MeasureProtocol.Columns.Count)
                return;

            var codeName = dgv_MeasureProtocol.Columns[col].Name;
            var codeText = dgv_MeasureProtocol.Columns[col].HeaderText;

            if (activeOrderNr != dgv_MeasureProtocol.Rows[e.RowIndex].Cells["OrderNr"].Value?.ToString() || string.IsNullOrEmpty(activeOrderNr))
            {
                activeOrderNr = dgv_MeasureProtocol.Rows[e.RowIndex].Cells["OrderNr"].Value?.ToString() ?? string.Empty;
                Load_MeasurePoints();
            }
            Set_MeasurePoints();
            if (IsMeasurePointSet)
                measurePoints.AddMeasurePointsMainForm();
            Initialize_Chart_MainForm(codeName, codeText);

            var ctr = dgv_MeasureProtocol.Rows.Count - 1;
            var measurementValues = new ObservableCollection<ObservablePoint>();

            // Skriver ut värden till diagrammet
            for (var i = 0; i < ctr; i++)
            {
                if (dgv_MeasureProtocol.Rows[i].Cells.Count <= col)
                    continue;

                var cell = dgv_MeasureProtocol.Rows[i].Cells[col].Value;
                var discardedCell = dgv_MeasureProtocol.Rows[i].Cells["Discarded"];
                var dateCell = dgv_MeasureProtocol.Rows[i].Cells["Date"];
                var ordernr = dgv_MeasureProtocol.Rows[i].Cells["OrderNr"].Value?.ToString();

                bool IsDiscarded = false;
                if (discardedCell?.Value != null)
                    bool.TryParse(discardedCell.Value.ToString(), out IsDiscarded);

                if (cell == null || IsDiscarded)
                    continue;

                if (double.TryParse(cell.ToString(), out var value))
                {
                    measurementValues.Add(new ObservablePoint(i, value));
                    listOrderNr.Add(ordernr ?? "");
                }
            }

            var seriesList = cartesianChart.Series.ToList();

            seriesList.Add(
                new LineSeries<ObservablePoint>
                {
                    Values = measurementValues,
                    Name = codeText,
                    IsVisibleAtLegend = true,
                    Stroke = new SolidColorPaint(SKColors.Green, 2),
                    Fill = null,
                    GeometrySize = 4,
                    GeometryFill = new SolidColorPaint(SKColors.Green),
                    GeometryStroke = new SolidColorPaint(SKColors.Green),
                    YToolTipLabelFormatter = value => $"# {value.Coordinate.SecondaryValue} / {value.Coordinate.PrimaryValue:F3}",

                    AnimationsSpeed = TimeSpan.FromMilliseconds(100)
                }
            );
            cartesianChart.Series = seriesList;

        }

        private const double marginPercent = 0.5;
        private void Initialize_Chart_MainForm(string? codename, string codetext)
        {
            for (int i = tlp_Bottom.Controls.Count - 1; i >= 0; i--)
            {
                var c = tlp_Bottom.Controls[i];
                if (tlp_Bottom.GetColumn(c) == 1) // kolumnindex = 1
                {
                    tlp_Bottom.Controls.RemoveAt(i);
                    c.Dispose(); // valfritt om du vill frigöra
                }
            }

            // Set_MeasurePoints();
            cartesianChart = chart(codetext);

            cartesianChart.Sections = sections;


            cartesianChart.Series = new ISeries[] { };

            this.Invoke(() => tlp_Bottom.Controls.Add(cartesianChart, 1, 0));
        }


        private void SökMätprotokoll_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsOkAddPoints)
                Points.Add_Points(2, "Sökning gamla Mätprotokoll");
            Order.Restore_TempOrderInfo();
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Fill_Toplist();
        }



        public class MeasureRow
        {
            public string OrderNr { get; set; } = "";
            public string Revision { get; set; } = "";
            public int RowIndex { get; set; }
            public int ColumnIndex { get; set; }
            public string ParameterText { get; set; } = "";
            public string Operation { get; set; } = "";
            public string DataType { get; set; } = "";
            public string ErrorCode { get; set; } = "";
            public string AnstNr { get; set; } = "";
            public string Sign { get; set; } = "";
            public bool Discarded { get; set; }
            public double? Value { get; set; }
            public string? TextValue { get; set; }
            public bool? BoolValue { get; set; }
            public int Decimals { get; set; }
            public string Date { get; set; }
        }

       
    }
}