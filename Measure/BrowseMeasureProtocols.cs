using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
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
using DigitalProductionProgram.Övrigt;

namespace DigitalProductionProgram.Measure
{
    public partial class BrowseMeasureProtocols : Form
    {
        private CartesianChart? cartesianChart;

        private double LSL;
        private double LCL;
        private double USL;
        private double UCL;

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
                    if (row.IsNewRow) continue;
                    var discardedCell = row.Cells["Discarded"];
                    var valueCell = row.Cells[Column_Name];

                    if (discardedCell?.Value == null || valueCell?.Value == null)
                        continue;

                    if (discardedCell.Value != null && bool.TryParse(discardedCell.Value.ToString(), out var isDiscarded) && isDiscarded)
                        continue;

                    if (double.TryParse(valueCell.Value.ToString(), out var value))
                        values.Add(value);
                }

                if (values.Count == 0)
                    return 0;

                // Snitt
                var avg = values.Average();

                // Rimlighetsfilter, t.ex. ta bort allt som är mer än 10x snittet
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
                    if (row.IsNewRow) continue;

                    var cell = row.Cells[Column_Name];
                    var discardedCell = row.Cells["Discarded"];

                    if (cell?.Value == null || discardedCell?.Value == null)
                        continue;

                    if (discardedCell.Value != null && bool.TryParse(discardedCell.Value.ToString(), out var isDiscarded) && isDiscarded)
                        continue; // hoppa över om den verkligen är markerad som skrotad

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
            // cb_Workoperations.SelectedIndexChanged -= WorkOperation_SelectedIndexChanged;

            Fill_WorkOperation();

            //  cb_Workoperations.SelectedIndexChanged += WorkOperation_SelectedIndexChanged;
            IsOkAddPoints = false;
            //  timer_AddPoints.Start();

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
        private void FillComboBox(ComboBox cb, string text)
        {
            cb?.Items.Clear();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT DISTINCT {text} 
                    FROM Measureprotocol.MainData as mp
                        JOIN [Order].MainData as korprotokoll
                            ON mp.OrderID = korprotokoll.OrderID
                    WHERE EXISTS (SELECT * FROM [Order].MainData 
                        WHERE korprotokoll.OrderID = mp.OrderID)
                    AND WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@workoperation", cb_Workoperations.Text);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    cb?.Items.Add(reader[0].ToString());
            }
            if (cb != null)
                cb.SelectedIndex = -1;
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
        private void MeasureTemplateRevision_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Load_Data();
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

        private void chb_SelectAllOrders_CheckedChanged(object sender, EventArgs e)
        {
            Load_Data();
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
            // if (string.IsNullOrEmpty(cb_MeasureprotocolTemplateName.Text))
            //     return;
            // if (string.IsNullOrEmpty(cb_MeasureTemplateRevision.Text))
            //     return;
            if (string.IsNullOrEmpty(tb_PartNr.Text))
                return;
            Load_MeasureData();

        }
        private async void Load_MeasureData()
        {
            if (IsLoading)
                return;

            var list_OrderNr = new List<string>();
            var pbar = new CustomProgressBar(1);
            pbar.Show(this);


            try
            {
                Load_InputControls();
                if (string.IsNullOrEmpty(tb_PartNr.Text))
                    return;

                dgv_MeasureProtocol.Rows.Clear();

                await using var con = new SqlConnection(Database.cs_Protocol);
                await con.OpenAsync();

                // --- Bygg COUNT-query ---
                string countQuery = @"
            SELECT COUNT(*) 
            FROM MeasureProtocol.Data AS data
                JOIN [Order].MainData AS orders 
                    ON data.OrderID = orders.OrderID
            WHERE orders.PartNr = @partnr
                AND orders.MeasureProtocolMainTemplateID = 
                (
                    SELECT MeasureProtocolMainTemplateID 
                    FROM MeasureProtocol.MainTemplate 
                    WHERE Name = @name AND Revision = @revision
                )";

                if (!chb_SelectAllOrders.Checked)
                {
                    countQuery += @"
                AND orders.OrderNr IN 
                (
                    SELECT TOP (@top) OrderNr 
                    FROM [Order].MainData 
                    WHERE PartNr = @partnr 
                    ORDER BY OrderID DESC
                )";
                }

                // --- Bygg SELECT-query ---
                string query;
                if (chb_SelectAllOrders.Checked)
                {
                    query = @"
                SELECT 
                    Parameter_UserText, orders.OrderNr, orders.Operation, Value, TextValue, BoolValue, Date, 
                    Discarded, ErrorCode, AnstNr, Sign, Decimals, DataType, main.RowIndex, template.ColumnIndex
                FROM MeasureProtocol.Data AS data
                    JOIN [Order].MainData AS orders 
                        ON data.OrderID = orders.OrderID
                    JOIN MeasureProtocol.Template AS template 
                        ON template.MeasureProtocolMainTemplateID = orders.MeasureProtocolMainTemplateID
                        AND template.DescriptionID = data.DescriptionId
                    JOIN MeasureProtocol.MainData AS main 
                        ON data.RowIndex = main.RowIndex 
                        AND data.OrderID = main.OrderID
                WHERE orders.PartNr = @partnr
                    AND orders.MeasureProtocolMainTemplateID = 
                    (
                        SELECT MeasureProtocolMainTemplateID 
                        FROM MeasureProtocol.MainTemplate 
                        WHERE Name = @name AND Revision = @revision
                    )
                ORDER BY data.OrderID, main.RowIndex, ColumnIndex;";
                }
                else
                {
                    query = @"
                SELECT 
                    Parameter_UserText, orders.OrderNr, orders.Operation, Value, TextValue, BoolValue, Date, 
                    Discarded, ErrorCode, AnstNr, Sign, Decimals, DataType, main.RowIndex, template.ColumnIndex
                FROM MeasureProtocol.Data AS data
                    JOIN [Order].MainData AS orders 
                        ON data.OrderID = orders.OrderID
                    JOIN MeasureProtocol.Template AS template 
                        ON template.MeasureProtocolMainTemplateID = orders.MeasureProtocolMainTemplateID
                        AND template.DescriptionID = data.DescriptionId
                    JOIN MeasureProtocol.MainData AS main 
                        ON data.RowIndex = main.RowIndex 
                        AND data.OrderID = main.OrderID
                WHERE orders.PartNr = @partnr
                    AND orders.MeasureProtocolMainTemplateID = 
                    (
                        SELECT MeasureProtocolMainTemplateID 
                        FROM MeasureProtocol.MainTemplate 
                        WHERE Name = @name AND Revision = @revision
                    )
                    AND orders.OrderNr IN 
                    (
                        SELECT TOP (@top) OrderNr
                        FROM [Order].MainData
                        WHERE PartNr = @partnr
                        ORDER BY OrderID DESC 
                    )
                ORDER BY data.OrderID, main.RowIndex, ColumnIndex;";
                }

                // --- Hämta total antal rader ---
                int totalRows;
                await using (var countCmd = new SqlCommand(countQuery, con))
                {
                    countCmd.Parameters.AddWithValue("@partnr", tb_PartNr.Text);
                    countCmd.Parameters.AddWithValue("@name", cb_MeasureprotocolTemplateName.Text);
                    countCmd.Parameters.AddWithValue("@revision", cb_MeasureTemplateRevision.Text);
                    if (!chb_SelectAllOrders.Checked)
                        countCmd.Parameters.AddWithValue("@top", (int)num_SelectTotalOrders.Value);

                    totalRows = (int)await countCmd.ExecuteScalarAsync();
                }

                // --- Hämta själva datan ---
                await using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", tb_PartNr.Text);
                cmd.Parameters.AddWithValue("@name", cb_MeasureprotocolTemplateName.Text);
                cmd.Parameters.AddWithValue("@revision", cb_MeasureTemplateRevision.Text);
                if (!chb_SelectAllOrders.Checked)
                    cmd.Parameters.AddWithValue("@top", (int)num_SelectTotalOrders.Value);

                await using var reader = await cmd.ExecuteReaderAsync();

                var lastrow = 0;
                var row = 0;
                int processed = 0;

                while (reader.Read())
                {
                    processed++;
                    double percent = (processed * 100.0) / totalRows;

                    var orderNr = reader["OrderNr"].ToString();
                    var mainrow = int.Parse(reader["RowIndex"].ToString());
                    var codeText = reader["Parameter_UserText"].ToString();
                    var colIndex = int.Parse(reader["ColumnIndex"].ToString());
                    int.TryParse(reader["Decimals"].ToString(), out var decimals);

                    if (!list_OrderNr.Contains(orderNr))
                        list_OrderNr.Add(orderNr);

                    mainrow--;
                    if (lastrow != mainrow)
                    {
                        lastrow = mainrow;
                        row++;
                    }

                    bool.TryParse(reader["Discarded"].ToString(), out var IsDiscarded);

                    string text = reader["DataType"].ToString()
                        switch
                    {
                        "0" => double.TryParse(reader["Value"].ToString(), out var value) ? Measurement_Protocol.SetDecimals_Value(value, decimals) : "N/A",
                        "1" => reader["TextValue"].ToString(),
                        "2" => bool.TryParse(reader["BoolValue"].ToString(), out var boolValue) && boolValue ? "\u2714" : "N/A",
                        _ => "N/A"
                    };

                    // Uppdatera progressbar
                    var IsOkRefresh = mainrow % 50 == 0;
                    pbar.Set_ValueProgressBar(percent > 100 ? 100 : percent, $"Laddar data: OrderNr {orderNr}", 1, IsOkRefresh);

                    if (row + 1 > dgv_MeasureProtocol.Rows.Count)
                    {
                        dgv_MeasureProtocol.Rows.Add();
                        var date = DateTime.Parse(reader["Date"].ToString());
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["OrderNr"], orderNr, IsDiscarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Operation"], reader["Operation"].ToString(), IsDiscarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Date"], date.ToString("yyyy-MM-dd HH:mm"), IsDiscarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["ErrorCode"], reader["ErrorCode"].ToString(), IsDiscarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["AnstNr"], reader["AnstNr"].ToString(), IsDiscarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Sign"], reader["Sign"].ToString(), IsDiscarded);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Discarded"], reader["Discarded"].ToString(), IsDiscarded);
                    }

                    Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells[colIndex + 2], text, IsDiscarded, codeText);
                }

                dgv_MeasureProtocol.ResumeLayout();

                if (dgv_MeasureProtocol.Rows.Count > 0 && dgv_MeasureProtocol.Rows[0].Cells["OrderNr"].Value != null)
                {
                    var ordernr = dgv_MeasureProtocol.Rows[0].Cells["OrderNr"].Value.ToString();
                    var operation = dgv_MeasureProtocol.Rows[0].Cells["Operation"].Value?.ToString() ?? string.Empty;
                    Monitor.Monitor.Load_DataTable_Measurpoints(ordernr, operation, false);
                    measurePoints.AddMeasurePointsMainForm();
                }

                lbl_TotalOrders.Text = list_OrderNr.Count.ToString();
            }
            finally
            {
                pbar.Close();
            }
        }
        private void Set_MeasurePoints()
        {
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
        private static readonly Font StrikeoutFont = new Font("Segoe UI", 9, FontStyle.Strikeout);
        private static readonly Font ItalicFont = new Font("Courier New", 8, FontStyle.Italic);

        private void Add_Text_DatagridCell(int row, DataGridViewCell cell, string text, bool IsDiscarded, string CodeText = null)
        {
            if (IsDiscarded)
            {
                cell.Style = new DataGridViewCellStyle
                {
                    BackColor = CustomColors.Discarded_Back,
                    ForeColor = CustomColors.Discarded_Front,
                    Font = StrikeoutFont
                };
            }
            else if (string.IsNullOrEmpty(text) || ControlValidator.IsStringNA(text))
            {
                cell.Style = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.Red,
                    Font = ItalicFont
                };
                text = "N/A";
            }
            else
            {
                MeasurementValidator.DataVerification_Value_dgv(dgv_MeasureProtocol, text, CodeText, row, cell.ColumnIndex);
            }

            cell.Value = text;
        }






        private void Clear_label_Click(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            switch (lbl.Text)
            {
                case "Välj Artikelnummer...":
                    tb_PartNr.Text = string.Empty;
                    break;
                    //case "Välj OrderNummer...":
                    //    cb_OrderNr.Text = string.Empty;
                    //    break;
                    //case "Välj Sign...":
                    //    cb_Sign.Text = string.Empty;
                    //    break;

            }
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

            Set_MeasurePoints();
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

            Set_MeasurePoints();
            cartesianChart = chart(codetext);

            cartesianChart.Sections = sections;


            cartesianChart.Series = new ISeries[] { };
            // cartesianChart.Series = new ISeries[] { serie_USL(codename), serie_UCL(codename), serie_LCL(codename), serie_LSL(codename) };

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


    }
}