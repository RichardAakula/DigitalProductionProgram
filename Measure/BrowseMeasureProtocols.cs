using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using OfficeOpenXml.Utils;

namespace DigitalProductionProgram.Measure
{
    public partial class BrowseMeasureProtocols : Form
    {
        private CartesianChart? cartesianChart;

        private double LSL;
        private double LCL;
        private double USL;
        private double UCL;
        private const double marginPercent = 0.5;
        private bool IsLoading;
        private readonly bool IsOkAddPoints;
        private string? activeOrderNr;
        private string Column_Name => dgv_MeasureProtocol.Columns[activeCell.ColumnIndex].Name;
        private DataGridViewCell? activeCell;
        readonly List<string> listOrderNr = new();

        //private static readonly Font ItalicFont = new Font("Courier New", 8, FontStyle.Italic);
        
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
        private static bool IsOutlier(double value, List<double> values, double pct)
        {
            // pct = hur aggressivt du filtrerar. Ex: pct = 3.5 är standard.
            // pct  = "Robust Z-score threshold"

            if (values == null || values.Count < 5)
                return false; // För lite data för att bedöma

            // 1) Median
            var sorted = values.OrderBy(v => v).ToList();
            double median = sorted[sorted.Count / 2];

            // 2) MAD = median(|x - median|)
            var absDev = sorted.Select(v => Math.Abs(v - median)).OrderBy(v => v).ToList();
            double mad = absDev[absDev.Count / 2];

            if (mad == 0)
                return false; // alla är typ lika – inget är outlier

            // 3) Robust Z-score
            double robustZ = Math.Abs(value - median) / (1.4826 * mad);

            // 4) Threshold styrs av pct
            return robustZ > pct;
        }
        private double Max_Y_Value
        {
            get
            {
                var values = new List<double>();

                foreach (DataGridViewRow row in dgv_MeasureProtocol.Rows)
                {
                    if (row.IsNewRow)
                        continue;

                    var mr = ListMeasureRows[row.Index];
                    if ((mr.IsDiscarded && chk_FilterDiscarded.Checked) || (mr.IsOutlied && chk_FilterBad.Checked))
                        continue;

                    //var discardedCell = row.Cells["Discarded"];
                    var valueCell = row.Cells[Column_Name];

                    if (valueCell?.Value == null)
                        continue;

                    //bool isDiscarded = discardedCell.Value switch
                    //{
                    //    bool b => b,
                    //    int i => i != 0,
                    //    string s when s.Equals("true", StringComparison.OrdinalIgnoreCase) => true,
                    //    string s when s.Equals("false", StringComparison.OrdinalIgnoreCase) => false,
                    //    string s when int.TryParse(s, out var num) => num != 0,
                    //    _ => false
                    //};

                    //if (isDiscarded)
                    //    continue;

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

                    var mr = ListMeasureRows[row.Index];
                    if ((mr.IsDiscarded && chk_FilterDiscarded.Checked) || (mr.IsOutlied && chk_FilterBad.Checked))
                        continue;

                    var cell = row.Cells[Column_Name];
                    //var discardedCell = row.Cells["Discarded"];

                    if (cell?.Value == null)
                        continue;

                    // Säkrare tolkning av Discarded
                    //bool isDiscarded = discardedCell.Value switch
                    //{
                    //    bool b => b,
                    //    int i => i != 0,
                    //    string s when s.Equals("true", StringComparison.OrdinalIgnoreCase) => true,
                    //    string s when s.Equals("false", StringComparison.OrdinalIgnoreCase) => false,
                    //    string s when int.TryParse(s, out var num) => num != 0,
                    //    _ => false
                    //};

                    //if (isDiscarded)
                    //    continue;

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
                XAxes =
                [
                    new Axis
                    {
                        Name = "OrderNr",
                        TextSize = 12,
                        LabelsPaint = new SolidColorPaint(SKColors.White),
                        SeparatorsPaint = new SolidColorPaint(SKColors.Black),
                        Labels = listOrderNr,
                        LabelsRotation = 45,
                        ShowSeparatorLines = false,
                        MinLimit = null,
                        MinStep = 1
                    }
                ],
                YAxes =
                [
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
                ],
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

        private (string CountQuery, string SelectQuery, List<SqlParameter> Params) BuildMeasureQueries(List<string> orders)
        {
            string baseCondition = """
                                        orders.PartNr = @partnr
                                        AND orders.MeasureProtocolMainTemplateID = (
                                        SELECT MeasureProtocolMainTemplateID
                                        FROM MeasureProtocol.MainTemplate
                                        WHERE Name = @name AND Revision = @revision
                                    )
                                   """;

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

            string countQuery = $"""
                                 SELECT COUNT(*) 
                                 FROM MeasureProtocol.Data AS data
                                 JOIN [Order].MainData AS orders ON data.OrderID = orders.OrderID
                                 WHERE {baseCondition}{orderFilter};
                                 """;

            string selectQuery = $"""
                                  SELECT
                                      template.Parameter_UserText,
                                      template.Parameter_Monitor,
                                      orders.OrderNr,
                                      orders.Operation,
                                      data.Value,
                                      data.TextValue,
                                      data.BoolValue,
                                      main.Date,
                                      main.Discarded,
                                      main.ErrorCode,
                                      main.AnstNr,
                                      main.Sign,
                                      template.Decimals,
                                      template.DataType,
                                      main.RowIndex,
                                      template.ColumnIndex,
                                      maintemplate.Revision,
                                      description.IsMeasureValue
                                  FROM MeasureProtocol.Data AS data
                                  JOIN [Order].MainData AS orders
                                      ON data.OrderID = orders.OrderID
                                  JOIN MeasureProtocol.MainTemplate AS maintemplate
                                      ON maintemplate.MeasureProtocolMainTemplateID = orders.MeasureProtocolMainTemplateID
                                      AND maintemplate.Name = @name
                                      AND maintemplate.Revision = @revision
                                  JOIN MeasureProtocol.Template AS template
                                      ON template.MeasureProtocolMainTemplateID = orders.MeasureProtocolMainTemplateID
                                     AND template.DescriptionID = data.DescriptionId
                                  JOIN MeasureProtocol.MainData AS main
                                      ON main.OrderID = data.OrderID
                                     AND main.RowIndex = data.RowIndex
                                  JOIN MeasureProtocol.Description AS description
                                      ON description.Id = template.DescriptionID
                                  WHERE {baseCondition}{orderFilter}
                                          ORDER BY data.OrderID, main.RowIndex, ColumnIndex;
                                  """;

            return (countQuery, selectQuery, parameters);
        }


       




        public BrowseMeasureProtocols()
        {
            Order.Save_TempOrderInfo();

            Log.Activity.Start();
            InitializeComponent();

            Fill_WorkOperation();

            IsOkAddPoints = false;
            chkList_ListOrders.Items.Add("Markera alla");

            if (Order.WorkOperation != Manage_WorkOperation.WorkOperations.Nothing)
                cb_Workoperations.Text = Order.WorkOperation.ToString();

            _ = Log.Activity.Stop("Search Measurement Protocol");
        }
        private async void BrowseMeasureProtocols_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order.PartNumber) == false)
            {
                tb_PartNr.Text = Order.PartNumber;
                await Load_MeasureData();
                for (int col = 0; col < dgv_MeasureProtocol.Columns.Count; col++)
                {

                    var tag = dgv_MeasureProtocol.Columns[col].HeaderCell.Tag;
                    if (tag is bool b && b)
                    {
                        activeCell = dgv_MeasureProtocol.Rows[0].Cells[col];
                        dgv_MeasureProtocol.CurrentCell = dgv_MeasureProtocol.Rows[0].Cells[col];
                        break;
                    }

                }
                AddDataToChart(0);
            }
            Fill_Toplist();
        }


        private void Fill_Toplist()
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

            var query = """
                        SELECT 
                            mt.Revision,
                            mt.MeasureProtocolMainTemplateID,
                            CASE WHEN mt.MeasureProtocolMainTemplateID = 
                            (
                                SELECT TOP 1 MeasureProtocolMainTemplateID
                                FROM [Order].MainData
                                WHERE PartNr = @partNr
                                    AND MeasureProtocolMainTemplateID = mt.MeasureProtocolMainTemplateID
                            )
                        THEN 1 ELSE 0 END AS IsCorrect
                        FROM MeasureProtocol.MainTemplate mt
                        WHERE mt.Name = @name
                        ORDER BY mt.Revision;
                        """;

            using var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", cb_MeasureprotocolTemplateName.Text);
            cmd.Parameters.AddWithValue("@partNr", tb_PartNr.Text);

            var correctIndex = -1;
            var index = 0;

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string rev = reader["Revision"].ToString();
                cb_MeasureTemplateRevision.Items.Add(rev);

                if (reader["IsCorrect"].ToString() == "1")
                    correctIndex = index;

                index++;
            }

            // välj rätt revision om den finns, annars senaste
            if (cb_MeasureTemplateRevision.Items.Count > 0)
            {
                cb_MeasureTemplateRevision.SelectedIndex =
                    correctIndex >= 0 
                        ? correctIndex 
                        : cb_MeasureTemplateRevision.Items.Count - 1;
            }
            else
            {
                cb_MeasureTemplateRevision.SelectedIndex = -1;
            }
        }
        private void Workoperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Fill_Toplist();
        }
        private void PartNr_MouseClick(object sender, MouseEventArgs e)
        {
            List<string> partnumbers = new List<string>();
            Database.ExecuteSafe(con =>
            {
                const string query = $"""

                                                          SELECT
                                          m.PartNr,
                                          MAX(m.Date_Start) AS LatestDateStart
                                      FROM [Order].MainData AS m
                                      WHERE m.WorkoperationID = (
                                          SELECT ID FROM Workoperation.Names WHERE Name = @workoperation
                                      )
                                      GROUP BY m.PartNr
                                      ORDER BY LatestDateStart DESC
                                      """;

                using var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@workoperation", cb_Workoperations.Text);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    partnumbers?.Add($"{reader[0]}:{reader[1]}");
            });

            var partnr = new Choose_Item(partnumbers, [tb_PartNr], isMultipleColumns:true,headers:["PartNumber", "Date"] );
            partnr.ShowDialog();
            Load_Data();
        }
        private void cb_MeasureTemplateRevision_SelectionChangeCommitted(object sender, EventArgs e)
        {
            chkList_ListOrders.Items.Clear();
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
            _ = Load_MeasureData();
        }

        private readonly List<MeasureRow> ListMeasureRows = [];
        private async Task Load_MeasureData()
        {
            if (IsLoading)
                return;
            ListMeasureRows.Clear();
            var pbar = new CustomProgressBar(1);
            pbar.Show(this);

            try
            {
                dgv_MeasureProtocol.Rows.Clear();
                if (string.IsNullOrEmpty(tb_PartNr.Text))
                    return;

                await using var con = new SqlConnection(Database.cs_Protocol);
                await con.OpenAsync();

                var checkedOrders = chkList_ListOrders.CheckedItems.Cast<string>().ToList();
                var (_, selectQuery, parameters) = BuildMeasureQueries(checkedOrders);

                // Hämta rader
                var rows = await LoadMeasureRowsAsync(con, selectQuery, parameters);

                Load_InputControls();

                // Grupp per rad (för discarded)
                var rowGroups = rows.GroupBy(r => new { r.OrderNr, r.RowIndex }).ToList();

                var discardedRowKeys = new HashSet<(string OrderNr, int RowIndex)>();
                var outlierRowKeys = new HashSet<(string OrderNr, int RowIndex)>();

                // === Steg 1: Discarded per rad ===
                foreach (var g in rowGroups)
                {
                    if (g.Any(x => x.IsDiscarded))
                        discardedRowKeys.Add((g.Key.OrderNr, g.Key.RowIndex));
                }

                // === Steg 2: Outliers per kolumn ===

                var measureGroups = rows
                    .Where(r => r.IsMeasureValue && r.Value.HasValue)
                    .GroupBy(r => new { r.OrderNr, r.ColumnIndex, r.MonitorText }) // ParameterText = kodnamn
                    .ToList();

                double pct = (double)num_OutlierPercent.Value;

                foreach (var colGroup in measureGroups)
                {
                    var values = colGroup.Select(x => x.Value.Value).ToList();

                    foreach (var cell in colGroup)
                    {
                        double val = cell.Value.Value;

                        if (IsOutlier(val, values, pct))
                            outlierRowKeys.Add((cell.OrderNr, cell.RowIndex));
                    }

                }

                // === Steg 3: Kombinerat filter ===
                var skipKeys = new HashSet<(string OrderNr, int RowIndex)>();

                if (chk_FilterDiscarded.Checked)
                    foreach (var x in discardedRowKeys)
                        skipKeys.Add(x);

                //if (chk_FilterBad.Checked)
                //    foreach (var x in outlierRowKeys)
                //        skipKeys.Add(x);

                // === Steg 4: Rendering ===
                var row = -1;
                var processed = 0;
                string lastOrderNr = null;
                var lastRowIndex = -99999;

                var total = rowGroups.Count - skipKeys.Count;
                if (total < 1) total = 1;

                foreach (var item in rows)
                {
                    var key = (item.OrderNr, item.RowIndex);
                    if (chk_FilterBad.Checked)
                    {
                        var isBad = outlierRowKeys.Contains(key);
                        if (isBad)
                            item.IsOutlied = true;
                    }

                    if (item.IsMeasureValue)
                    {
                        var colIndex = item.ColumnIndex + 2;
                        var headerCell = dgv_MeasureProtocol.Columns[colIndex].HeaderCell;
                        headerCell.Tag = true;
                    }
                    if (!chkList_ListOrders.Items.Contains(item.OrderNr))
                        chkList_ListOrders.Items.Add(item.OrderNr, true);

                    var newRow = lastOrderNr != item.OrderNr || lastRowIndex != item.RowIndex;

                    if (newRow)
                    {
                        processed++;
                        double percent = Math.Min(100.0, processed * 100.0 / total);
                        var refresh = processed % 10 == 0;

                        pbar.Set_ValueProgressBar(percent, "Laddar data: OrderNr " + item.OrderNr, 1, refresh);

                        dgv_MeasureProtocol.Rows.Add();
                        row++;
                        ListMeasureRows.Add(item);
                        lastOrderNr = item.OrderNr;
                        lastRowIndex = item.RowIndex;
                        dgv_MeasureProtocol.Rows[row].Cells["IsOutlied"].Value = item.IsOutlied;
                        dgv_MeasureProtocol.Rows[row].Cells["IsDiscarded"].Value = item.IsDiscarded;

                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["OrderNr"], item.OrderNr, item);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Operation"], item.Operation, item);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Date"], item.Date, item);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["ErrorCode"], item.ErrorCode, item);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["AnstNr"], item.AnstNr, item);
                        Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells["Sign"], item.Sign, item);
                    }

                    string text = item.DataType switch
                    {
                        "0" => item.Value.HasValue ? Measurement_Protocol.SetDecimals_Value(item.Value.Value, item.Decimals) : "N/A",
                        "1" => item.TextValue ?? "N/A",
                        "2" => item.BoolValue == true ? "✔" : "N/A",
                        _ => "N/A"
                    };

                    Add_Text_DatagridCell(row, dgv_MeasureProtocol.Rows[row].Cells[item.ColumnIndex + 2], text, item, item.ParameterText);
                }

                lbl_TotalOrders.Text = $"Totalt {chkList_ListOrders.Items.Count} ordrar:";

                if (chk_FilterBad.Checked || chk_FilterDiscarded.Checked)
                {
                    
                    int totalFiltered = 0;

                    if (chk_FilterDiscarded.Checked)
                        totalFiltered += discardedRowKeys.Count;

                    if (chk_FilterBad.Checked)
                        totalFiltered += outlierRowKeys.Count;

                    
                    label_FilterInfo.Text =
                        $"""
                         Filtrerar bort {totalFiltered} rader:
                         {(chk_FilterDiscarded.Checked ? $"Kasserade: {discardedRowKeys.Count}" : "")}
                         {(chk_FilterBad.Checked ? $"Orimliga: {outlierRowKeys.Count}" : "")}
                         """;


                }
                else
                {
                    label_FilterInfo.Text = "";
                }

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
                    MonitorText = reader["Parameter_Monitor"]?.ToString(),
                    Operation = reader["Operation"]?.ToString(),
                    DataType = reader["DataType"]?.ToString(),
                    ErrorCode = reader["ErrorCode"]?.ToString(),
                    AnstNr = reader["AnstNr"]?.ToString(),
                    Sign = reader["Sign"]?.ToString(),
                    IsMeasureValue = !reader.IsDBNull(reader.GetOrdinal("IsMeasureValue")) && reader.GetBoolean(reader.GetOrdinal("IsMeasureValue")),
                    IsDiscarded = !reader.IsDBNull(reader.GetOrdinal("Discarded")) && reader.GetBoolean(reader.GetOrdinal("Discarded")),
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




        private bool IsMeasurePointSet;
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
                Set_MeasurePoints();
                rowIndex++;
                activeOrderNr = ordernr;
            } while (IsMeasurePointSet == false);
        }
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
        private void Load_InputControls()
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
            Add_Column_DatagridView(dgv_MeasureProtocol, "IsDiscarded", "Discarded", 0);
            Add_Column_DatagridView(dgv_MeasureProtocol, "IsOutlied", "Outlied", 0);
        }
        private static void Add_Column_DatagridView(DataGridView dgv, string name, string headerText, int width)
        {
            dgv.Columns.Add(name, headerText);
            dgv.Columns[name].Width = width;
            dgv.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
            if (width == 0)
                dgv.Columns[name].Visible = false;
        }
        private void Add_Text_DatagridCell(int row, DataGridViewCell cell, string text, MeasureRow item, string CodeText = null)
        {
            if (item.IsOutlied)
            {
                cell.Style = new DataGridViewCellStyle
                {
                    BackColor = CustomColors.Bad_Back,
                    ForeColor = CustomColors.Bad_Front,
                };

                cell.Value = text;
                return;

            }
            if (item.IsDiscarded)
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



        private void MätProtokoll_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            activeCell = dgv_MeasureProtocol.Rows[e.RowIndex].Cells[e.ColumnIndex];
            AddDataToChart(e.RowIndex);
        }
        private async void chk_FilterBad_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                await Load_MeasureData();
                AddDataToChart(null);
            }
            catch
            {

            }
        }
        private async void LoadOrder_Click(object sender, EventArgs e)
        {
            try
            {
                await Load_MeasureData();
                AddDataToChart(null);
            }
            catch
            {

            }
        }

        private void AddDataToChart(int? row)
        {
            if (tb_PartNr.Text == string.Empty)
                return;

            if (activeCell == null)
                return;

            var col = activeCell.ColumnIndex;

            if (col < 0 || col >= dgv_MeasureProtocol.Columns.Count)
                return;

            var codeName = dgv_MeasureProtocol.Columns[col].Name;
            var codeText = dgv_MeasureProtocol.Columns[col].HeaderText;


            if (row != null)
            {
                if (activeOrderNr != dgv_MeasureProtocol.Rows[(int)row].Cells["OrderNr"].Value?.ToString() || string.IsNullOrEmpty(activeOrderNr))
                {
                    activeOrderNr = dgv_MeasureProtocol.Rows[(int)row].Cells["OrderNr"].Value?.ToString() ?? string.Empty;
                    Load_MeasurePoints();
                }
            }

            Set_MeasurePoints();
            if (IsMeasurePointSet)
                cf_MeasurePoints.AddMeasurePointsMainForm();
            Initialize_Chart_MainForm(codeName, codeText);

            var ctr = dgv_MeasureProtocol.Rows.Count - 1;
            var measurementValues = new ObservableCollection<ObservablePointEx>();
            listOrderNr.Clear();
            int x = 0;
            // Print out värden till diagrammet
            for (var i = 0; i < ctr + 1; i++)
            {
                var r = dgv_MeasureProtocol.Rows[i];
                if (r.IsNewRow) continue;

                var orderNr = r.Cells["OrderNr"].Value?.ToString() ?? "";

                bool discarded = (r.Cells["IsDiscarded"].Value?.ToString() == "1" ||
                                  r.Cells["IsDiscarded"].Value?.ToString()?.ToLower() == "true");
                if (discarded && chk_FilterDiscarded.Checked)
                    continue;

                // Filtrera på Outlier
                bool isOut = (r.Cells["IsOutlied"].Value?.ToString()?.ToLower() == "true");
                if (isOut && chk_FilterBad.Checked)
                    continue;

                // Hämta mätvärdet i kolumnen
                if (r.Cells.Count <= col)
                    continue;


                var cellText = r.Cells[col].Value?.ToString();
                if (double.TryParse(cellText, out double value))
                {

                    var bag = r.Cells["Bag"].Value?.ToString() ?? "";
                    var point = new ObservablePointEx(x, value, bag);

                    measurementValues.Add(point);
                    listOrderNr.Add(orderNr);
                    x++;
                }

            }
            var valueList = measurementValues.Select(x => x.Y).ToList();
            var spc = SpcResult.Calculate(valueList, codeName, null, LSL, USL);
            Update_SPC_UI(spc);

            var seriesList = cartesianChart.Series.ToList();

            seriesList.Add(
                new LineSeries<ObservablePointEx>
                {
                    Values = measurementValues,
                    Name = codeText,
                    IsVisibleAtLegend = true,
                    Stroke = new SolidColorPaint(SKColors.Green, 2),
                    Fill = null,
                    GeometrySize = 4,
                    GeometryFill = new SolidColorPaint(SKColors.Green),
                    GeometryStroke = new SolidColorPaint(SKColors.Green),
                    YToolTipLabelFormatter = cp =>
                    {
                        var model = (ObservablePointEx)cp.Model;
                        return $"Bag {model.Bag} / {cp.Coordinate.PrimaryValue:F3}";
                    },


                    AnimationsSpeed = TimeSpan.FromMilliseconds(100)
                }
            );
            cartesianChart.Series = seriesList;
        }
        public class ObservablePointEx(double x, double y, string bag) : ObservablePoint(x, y)
        {
            public string Bag { get; set; } = bag;
        }

        private void Initialize_Chart_MainForm(string? codename, string codetext)
        {
            for (int i = tlp_Bottom.Controls.Count - 1; i >= 0; i--)
            {
                var c = tlp_Bottom.Controls[i];
                if (tlp_Bottom.GetColumn(c) == 2) // kolumnindex = 1
                {
                    tlp_Bottom.Controls.RemoveAt(i);
                    c.Dispose(); // valfritt om du vill frigöra
                }
            }

            cartesianChart = chart(codetext);
            cartesianChart.Sections = sections;
            cartesianChart.Series = [];

            this.Invoke(() => tlp_Bottom.Controls.Add(cartesianChart, 2, 0));
        }
        private void Update_SPC_UI(SpcResult spc)
        {
            if (spc == null)
            {
                label_SPC_Title.Text = "SPC";
                lbl_TotalMeasurements.Text = "0";
                //lbl_SPC_Std.Text = "—";
                lbl_Median.Text = "—";

                lbl_Pp.Text = "—";
                //lbl_SPC_Ppk.Text = "—";
                //lbl_SPC_Pp.Text = "—";
                //lbl_SPC_Ppk.Text = "—";
                return;
            }

            label_SPC_Title.Text = string.IsNullOrWhiteSpace(spc.CodeName) ? "SPC" : "SPC – " + spc.CodeName;

            lbl_TotalMeasurements.Text = spc.Count.ToString() ?? "N/A";
            lbl_Mean.Text = spc.Mean?.ToString("F3") ?? "N/A";
            lbl_Median.Text = spc.Median.ToString();
            lbl_Min.Text = spc.Min?.ToString("F3") ?? "N/A";
            lbl_Max.Text = spc.Max?.ToString("F3") ?? "N/A";
            lbl_Range.Text = spc.Range?.ToString("F3") ?? "N/A";
            lbl_StandardDeviation.Text = spc.StandardDeviation?.ToString("F4") ?? "N/A";
            lbl_Skewness.Text = spc.Skewness?.ToString("F3") ?? "-";
            lbl_Kurtosis.Text = spc.Kurtosis?.ToString("F3") ?? "-";
            lbl_Pp.Text = spc.Pp.HasValue ? spc.Pp.Value.ToString("F3") : "N/A";
            lbl_Ppk.Text = spc.Ppk.HasValue ? spc.Ppk.Value.ToString("F3") : "M/A";

            // Skewness: nära 0 är bra → invert: true, använd |skew|
            if (spc.Skewness != null)
            {
                double absSkew = Math.Abs((double)spc.Skewness);
                const double badSkew = 2.0; // t.ex. 2.0 som rött tak
                MiniBarRenderer.DrawMiniBar(lbl_Bar_Skewness, absSkew, 0.0, badSkew, invert: true);
            }

            if (spc.Kurtosis != null)
            {
                double absK = Math.Abs((double)spc.Kurtosis);
                // Sätt ett “rött tak” (alla > 3 mappas i princip till rött)
                const double badAbs = 3.0;
                // 0 = perfekt (grön), 3 = dåligt (rött). invert:true ger rätt färglogik.
                MiniBarRenderer.DrawMiniBar(lbl_Bar_Kurtosis, absK, 0.0, badAbs, invert: true);
            }

            // Pp: högre = bättre → inte invert och INGEN Abs
            if (spc.Pp != null)
                MiniBarRenderer.DrawMiniBar(lbl_Bar_Pp, (double)spc.Pp, 0.0, 2.0);
            // Ppk: högre = bättre → inte invert och INGEN Abs
            if (spc.Ppk != null)
                MiniBarRenderer.DrawMiniBar(lbl_Bar_Ppk, (double)spc.Ppk, 0.0, 2.0);
            // Standard Deviation: lägre = bättre → invert: true
            if (spc.StandardDeviation != null)
                MiniBarRenderer.DrawMiniBar(lbl_Bar_StandardDeviation, (double)spc.StandardDeviation, 0.0, 0.03, invert: true);

        }



        private void SPC_MouseHover(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                toolTip1.SetToolTip(lbl, GetSpcTooltip(lbl.Name));
            }
        }

        private string? GetSpcTooltip(string labelName)
        {
            return labelName switch
            {
                "label_TotalMeasurements" => LanguageManager.GetString("spc_Totalmeasurements"),
                "label_Mean" => LanguageManager.GetString("spc_Mean"),
                "label_Median" => LanguageManager.GetString("spc_Median"),
                "label_Min" => LanguageManager.GetString("spc_Min"),
                "label_Max" => LanguageManager.GetString("spc_Max"),
                "label_Range" => LanguageManager.GetString("spc_Range"),
                "label_StandardDeviation" => LanguageManager.GetString("spc_StandardDeviation"),
                "label_Skewness" => LanguageManager.GetString("spc_Skewness"),
                "label_Kurtosis" => LanguageManager.GetString("spc_Kurtosis"),
                "label_Pp" => LanguageManager.GetString("spc_Pp"),
                "label_Ppk" => LanguageManager.GetString("spc_Ppk"),
                _ => ""
            };
        }


        private void SökMätprotokoll_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsOkAddPoints)
                Points.Add_Points(2, "Sökning gamla Mätprotokoll");
            Order.Restore_TempOrderInfo();
        }


        public static class MiniBarRenderer
        {
            public static void DrawMiniBar(Label target, double? value, double? min, double? max, bool invert = false, Color? colBad = null, Color? colMid = null, Color? colGood = null)
            {
                // Färgpalett (kan överstyras via parametrar)
                Color cBad = colBad ?? CustomColors.Bad_Front;
                Color cMid = colMid ?? CustomColors.Warning_Back;
                Color cGood = colGood ?? CustomColors.Ok_Front;

                // Sane guards
                if (target == null || !value.HasValue || !min.HasValue || !max.HasValue)
                {
                    target.Image?.Dispose();
                    target.Image = null;
                    return;
                }

                double v = value.Value;
                double vmin = min.Value;
                double vmax = max.Value;

                // Skydda mot min=max
                if (Math.Abs(vmax - vmin) < double.Epsilon)
                {
                    // Om allt är samma: visa full bar (bra) om invert, annars 0
                    double normalizedFlat = invert ? 1.0 : 0.0;
                    RenderMiniBar(target, normalizedFlat, cBad, cMid, cGood);
                    return;
                }

                // Clamp & normalisera
                double normalized = (v - vmin) / (vmax - vmin);
                normalized = Math.Max(0.0, Math.Min(1.0, normalized));

                if (invert) normalized = 1.0 - normalized;

                RenderMiniBar(target, normalized, cBad, cMid, cGood);
            }
            private static void RenderMiniBar(Label target, double normalized, Color cBad, Color cMid, Color cGood)
            {
                int steps = 100;
                int filled = (int)Math.Round(normalized * steps);

                using var bmp = new Bitmap(target.Width, target.Height);
                using Graphics g = Graphics.FromImage(bmp);
                g.Clear(target.BackColor);

                int barWidth = Math.Max(1, target.Width / steps);
                int barHeight = Math.Max(1, target.Height - 4);

                for (int i = 0; i < steps; i++)
                {
                    var rect = new Rectangle(i * barWidth, 0, Math.Max(1, barWidth - 0), barHeight);

                    Color color;
                    if (i < filled)
                    {
                        // t = progress längs hela baren [0..1]
                        double t = steps == 1 ? 1.0 : (double)i / (steps - 1);

                        // Två-delad lerp: [0..0.5] röd->orange, [0.5..1] orange->grön
                        if (t <= 0.5)
                        {
                            double lt = t / 0.5; // [0..1]
                            color = LerpColor(cBad, cMid, lt);
                        }
                        else
                        {
                            double lt = (t - 0.5) / 0.5; // [0..1]
                            color = LerpColor(cMid, cGood, lt);
                        }
                    }
                    else
                    {
                        color = Color.FromArgb(40, 255, 255, 255); // “tom” steg
                    }

                    using (Brush b = new SolidBrush(color))
                        g.FillRectangle(b, rect);
                }

                // Byt ut ev. gammal bild
                target.Image?.Dispose();
                // klona så vi släpper using(bmp)
                target.Image = (Bitmap)bmp.Clone();
            }
            private static Color LerpColor(Color c1, Color c2, double t)
            {
                t = Math.Max(0.0, Math.Min(1.0, t));
                int r = (int)Math.Round(c1.R + (c2.R - c1.R) * t);
                int g = (int)Math.Round(c1.G + (c2.G - c1.G) * t);
                int b = (int)Math.Round(c1.B + (c2.B - c1.B) * t);
                return Color.FromArgb(r, g, b);
            }
        }



        public class MeasureRow
        {
            public string OrderNr { get; init; } = "";
            public string Revision { get; set; } = "";
            public int RowIndex { get; init; }
            public int ColumnIndex { get; init; }
            public string ParameterText { get; init; } = "";
            public string MonitorText { get; set; }
            public string Operation { get; set; } = "";
            public string DataType { get; set; } = "";
            public string ErrorCode { get; set; } = "";
            public string AnstNr { get; set; } = "";
            public string Sign { get; set; } = "";
            public bool IsMeasureValue { get; set; }
            public bool IsDiscarded { get; set; }
            public bool IsOutlied { get; set; }
            public double? Value { get; set; }
            public string? TextValue { get; set; }
            public bool? BoolValue { get; set; }
            public int Decimals { get; set; }
            public string Date { get; set; }
        }


        private sealed class Spec
        {
            public double? Min { get; set; }
            public double? Max { get; set; }
            public double? Nom { get; set; }
            public double? Tol { get; set; } // Absolut tolerans ±
        }







        public sealed class SpcResult
        {
            private const double EPS = 1e-12;
            public string CodeName { get; set; }

            // Grundstatistik
            public int Count { get; set; }
            public double? Mean { get; set; }
            public double? Min { get; set; }
            public double? Max { get; set; }
            public double? Median { get; set; }
            public double? Range { get; set; }
            public double? StandardDeviation { get; set; }
            public double? Skewness { get; set; }
            public double? Kurtosis { get; set; }


            // Specgränser (design/specification limits)
            private double? LSL { get; set; }
            private double? USL { get; set; }
            private double? Nom { get; set; }

            // Kapabilitet
            public double? Pp { get; set; }
            public double? Ppk { get; set; }

            // Performance-index (mot hela samplet, inte subgrupper) – valfritt
            //public double? Pp { get; set; }
            //public double? Ppk { get; set; }

            public static SpcResult Calculate(IList<double?> values, string codeName, string specText = null, double? lsl = null, double? usl = null, double? target = null, double sigmaFactor = 3.0, bool useSampleSigma = false)
            {
                var res = new SpcResult
                {
                    CodeName = codeName ?? string.Empty
                };

                if (values == null || values.Count == 0)
                    return res;

                // Grundstatistik
                res.Count = values.Count;
                res.Min = values.Min();
                res.Max = values.Max();
                res.Median = Övrigt.Calculate.Median(values);
                res.Mean = values.Average();
                res.Range = values.Max() - values.Min();
                res.StandardDeviation = Övrigt.Calculate.StandardDeviation(values.Select(v => v).ToList());
                res.Skewness = Övrigt.Calculate.Skewness(values.Select(v => v).ToList());
                res.Kurtosis = Övrigt.Calculate.Kurtosis(values.Select(v => v).ToList());

                // Hämta specgränser (LSL/USL/Target)
                // 1) overrides vinner
                if (lsl.HasValue) res.LSL = lsl.Value;
                if (usl.HasValue) res.USL = usl.Value;
                if (target.HasValue) res.Nom = target.Value;

                // 2) annars försök tolka från specText via TryParseSpec (finns i din klass)
                if ((res.LSL == null || res.USL == null || res.Nom == null) && !string.IsNullOrWhiteSpace(specText))
                {
                    if (TryParseSpecSafe(specText, out var parsed))
                    {
                        if (res.LSL == null && parsed.Min.HasValue) res.LSL = parsed.Min.Value;
                        if (res.USL == null && parsed.Max.HasValue) res.USL = parsed.Max.Value;
                        if (res.Nom == null && parsed.Nom.HasValue) res.Nom = parsed.Nom.Value;

                        if (res.LSL == null && res.USL == null && parsed.Nom.HasValue && parsed.Tol.HasValue)
                        {
                            res.LSL = parsed.Nom.Value - parsed.Tol.Value;
                            res.USL = parsed.Nom.Value + parsed.Tol.Value;
                            if (res.Nom == null)
                                res.Nom = parsed.Nom.Value;
                        }
                    }
                }

                // Kapabilitet (Pp/Ppk kräver LSL & USL & std > 0)
                if (res is { USL: not null, LSL: not null })
                {
                    res.Pp = Övrigt.Calculate.Pp(values.Select(v => (double?)v).ToList(), res.USL, res.LSL);
                    res.Ppk = Övrigt.Calculate.Ppk(values.Select(v => (double?)v).ToList(), res.USL, res.LSL);


                    // double width = res.USL.Value - res.LSL.Value;


                    // Pp/Ppk: använder sample standard deviation över hela datat (”global performance”)
                    // Här kan du välja att använda samma std som ovan, eller specifik "overall std".
                    // Vi använder samma std för enkelhet, men vill du ha en "overall" kan du skicka useSampleSigma=true här.
                    //var overallStd = res.StdDev;
                    //if (overallStd > EPS && width > EPS)
                    //{
                    //    res.Pp = width / (2.0 * sigmaFactor * overallStd);
                    //    double ppu = (res.USL.Value - res.Mean) / (sigmaFactor * overallStd);
                    //    double ppl = (res.Mean - res.LSL.Value) / (sigmaFactor * overallStd);
                    //    res.Ppk = Math.Min(ppu, ppl);
                    //}
                }

                return res;
            }

        }


        private static bool TryParseSpecSafe(string parameterText, out Spec spec)
        {
            try
            {
                return TryParseSpec(parameterText, out spec);
            }
            catch
            {
                spec = new Spec();
                return false;
            }
        }
        private static bool TryParseSpec(string parameterText, out Spec spec)
        {
            // Placeholder: denna kommer länkas mot din riktiga metod via den partial/klass du redan har.
            // Om du får "ambiguous reference" – ta bort denna stubbe och använd din originalmetod.
            spec = new Spec();
            return false;
        }

        
    }

}