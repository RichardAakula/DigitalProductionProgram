using System;
using System.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Measure
{
    public partial class MainMeasureStatistics : UserControl
    {
        public static Dictionary<string, double> dict_AverageValuesForLastOrder = new();
        public static Dictionary<string, double> dict_AverageValuesForPart = new();
        public static void LoadAvgValuesForLastOrder()
        {
            dict_AverageValuesForLastOrder.Clear();

            if (Order.PartNumber is null)
                return;

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
            SELECT d.CodeName, AVG(data.Value) AS AvgValue
            FROM Measureprotocol.Data AS data
            INNER JOIN MeasureProtocol.MainData AS maindata
                ON data.OrderID = maindata.OrderID
                AND data.RowIndex = maindata.RowIndex
            INNER JOIN MeasureProtocol.Description AS d
                ON data.DescriptionId = d.Id
            WHERE data.OrderID = 
            (SELECT OrderID FROM (
                SELECT TOP(2) OrderID, ROW_NUMBER() OVER (ORDER BY Date_Start DESC) AS RowNum
                FROM [Order].MainData 
                WHERE PartNr = @partnumber
            ) AS tables
            WHERE RowNum = 2)
                AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
            GROUP BY d.CodeName";

            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string code = reader.GetString(0);
                double val = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                dict_AverageValuesForLastOrder[code] = val;
            }
        }
        public static void LoadAvgValuesForPart()
        {
            dict_AverageValuesForPart.Clear();

            if (Order.PartID == null || Order.PartID == 0)
                return;

            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
        SELECT d.CodeName, AVG(data.Value) AS AvgValue
        FROM Measureprotocol.Data AS data 
        INNER JOIN MeasureProtocol.MainData AS maindata
            ON data.OrderID = maindata.OrderID
            AND data.RowIndex = maindata.RowIndex
        INNER JOIN MeasureProtocol.Description AS d
            ON data.DescriptionId = d.Id
        WHERE EXISTS (
            SELECT * FROM [Order].MainData AS om 
            WHERE om.OrderID = data.OrderID AND om.PartID = @partid
        )
        AND (maindata.Discarded = 'False' OR maindata.Discarded IS NULL)
        GROUP BY d.CodeName";

            using var cmd = new SqlCommand(query, con);
            ServerStatus.Add_Sql_Counter();
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);

            con.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string code = reader.GetString(0);
                double val = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);
                dict_AverageValuesForPart[code] = val;
            }
        }

        //private static double AvgValue_Measurement_Part(string? codename)
        //{
        //    using var con = new SqlConnection(Database.cs_Protocol);
        //    var query = @"
        //            SELECT AVG(Value) 
        //            FROM Measureprotocol.Data AS data 
        //            INNER JOIN MeasureProtocol.MainData AS maindata
        //                ON data.OrderID = maindata.OrderID
        //                AND data.RowIndex = maindata.RowIndex
        //            WHERE EXISTS (SELECT * FROM [Order].MainData WHERE data.OrderID = [Order].MainData.OrderID AND PartID = @partid)
        //                AND (Discarded = 'False' OR Discarded IS NULL)
        //                AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)";
        //    con.Open();
        //    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
        //    SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
        //    cmd.Parameters.AddWithValue("@codename", codename);
        //    var value = cmd.ExecuteScalar();
        //    if (value != null && value.GetType() != typeof(DBNull))
        //        if (double.TryParse(value.ToString(), out var result))
        //            return result;
        //    return 0;
        //}

        public static double GetMeasurementValue(string statisticType, string? parameterCode)
        {
            if (Order.OrderID is null)
                return 0;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = $@"
                    SELECT {statisticType}(Value) FROM MeasureProtocol.Data AS data
                    INNER JOIN MeasureProtocol.MainData AS maindata
	                    ON data.OrderID = maindata.OrderID
		                    AND data.RowIndex = maindata.RowIndex
                    WHERE data.OrderID = @orderid
                    AND (Discarded = 'False' OR Discarded IS NULL)
                        AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            con.Open();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@codename", parameterCode);
            var value = cmd.ExecuteScalar();
            if (value == null) 
                return 0;
            if (double.TryParse(value.ToString(), out var result))
                return result;

            return 0;
        }

       
        private static double? chart_Maximum_Yvalue(string codename, double sl_max)
        {
            var value = GetMeasurementValue("MAX", codename);
            if (dict_AverageValuesForLastOrder.TryGetValue(codename, out var val) == false)
                return Math.Max(GetMeasurementValue("MAX", codename), sl_max);
            var max = Math.Max(val, value);
            return Math.Max(max, sl_max);
        }
        private static double chart_Minimum_Yvalue(string codename, double sl_min)
        {
            var value = GetMeasurementValue("MIN", codename);
            if (dict_AverageValuesForLastOrder.TryGetValue(codename, out var val) == false)
                return Math.Min(value, sl_min);

            var min = Math.Min(value, val);
            return Math.Max(min, sl_min);

            //var min = Math.Min(value, Math.Max(val, value));
            //return Math.Min(Math.Max(min, sl_min), min);
        }
        //public static int Max_Bag => (int)GetMeasurementValue("MAX", "Bag");
        public static string? active_MeasureCode;
        public static int MeasureStatsHeight;
        public static string? ChartCodename = string.Empty;
        public static string? ChartCodeText = string.Empty;




        public MainMeasureStatistics()
        {
            InitializeComponent();
        }
        public static void Close_All_MeasureProtocols()
        {
            Form?[] forms = { Application.OpenForms["Measurement_Protocol"] };
            foreach (var form in forms)
                form?.Close();
        }


        public void Translate_Form()
        {
            label_MeasureInformation.Text = LanguageManager.GetString(label_MeasureInformation.Name);
        }
        public void Change_Theme()
        {
            BackColor = Teman.backColor_MeasureStats;
            Teman.IterateThroughControls(tlp_Main, Teman.foreColor_MeasureStats);
        }

        public void ClearData()
        {
            foreach(var lbl2 in flp_Codenames.Controls.OfType<Label>()
                        .Concat(flp_Average.Controls.OfType<Label>())
                        .Concat(flp_Max.Controls.OfType<Label>())
                        .Concat(flp_Min.Controls.OfType<Label>()))
                lbl2.Text = string.Empty;
        }
        public void Add_MeasureInformation_MainForm(Panel? panel, TableLayoutPanel tlp_MainWindow)
        {
            if (Order.OrderID is null || Templates_MeasureProtocol.MainTemplate.ID == 0 || Templates_MeasureProtocol.MainTemplate.ID is null)
                return;
            Invoke(new Action(() => DrawingControl.SuspendDrawing(this)));

            foreach (var flp in tlp_Main.Controls.OfType<FlowLayoutPanel>())
                flp.Invoke(new Action(() => flp.Controls.Clear()));
            Charts.panel_Chart = panel;
            MeasureStatsHeight = label_MeasureInformation.Height + (int)tlp_Main.RowStyles[0].Height + 2;
            
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT 
                        Parameter_UserText, 
                        Parameter_Monitor, 
                        Decimals, 
                        AVG(Value) AS Average, 
                        MIN(Value) AS Min, 
                        MAX(Value) AS Max
                    FROM MeasureProtocol.Template AS main
                    JOIN MeasureProtocol.Description AS description
                        ON main.DescriptionID = description.Id
                    JOIN MeasureProtocol.Data as data
                        ON main.DescriptionID = data.DescriptionId
                    JOIN MeasureProtocol.MainData as maindata
                        ON data.OrderID = maindata.OrderID 
                            AND data.RowIndex = maindata.RowIndex
    
                    WHERE main.MeasureProtocolMainTemplateID = @maintemplateid
                        AND description.IsMeasureValue = 'True'
                        AND data.OrderID = @orderid
                        AND (Discarded = 'False' OR Discarded IS NULL)
                    GROUP BY Parameter_UserText,Parameter_Monitor, CodeName, Decimals, ColumnIndex
                    ORDER BY ColumnIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var parameterText = reader["Parameter_UserText"].ToString();
                    var textwidth = TextRenderer.MeasureText(parameterText, new Font("Segoe UI", 9, FontStyle.Bold)).Width;
                    var labelHeight = textwidth > flp_Codenames.Width - 10 ? 40 : 20;
                    if (string.IsNullOrEmpty(ChartCodename))
                    {
                        ChartCodename = reader["Parameter_Monitor"].ToString();
                        ChartCodeText = parameterText;
                    }

                    if (!string.IsNullOrEmpty(ChartCodename) && !string.IsNullOrEmpty(ChartCodeText))
                    {
                        Add_Label(flp_Codenames, $"{parameterText}:", reader["Parameter_Monitor"].ToString(), labelHeight, FontStyle.Bold, ContentAlignment.MiddleRight);
                        MeasureStatsHeight += labelHeight + 2;

                        int.TryParse(reader["Decimals"].ToString(), out var decimals);
                        var avg = AggregateValue(reader["Average"], decimals);
                        var min = AggregateValue(reader["Min"], decimals);
                        var max = AggregateValue(reader["Max"], decimals);
                        Add_Label(flp_Average, FormatDisplayValue(avg), null, labelHeight);
                        Add_Label(flp_Min, FormatDisplayValue(min), null, labelHeight);
                        Add_Label(flp_Max, FormatDisplayValue(max), null, labelHeight);

                    }
                }
            }
            

            if (!string.IsNullOrEmpty(ChartCodename))
                Charts.Add_Data_Chart_MainForm(panel, ChartCodename, ChartCodeText);
            else
            {
                _ = Activity.Stop($"Felsökning rött kryss över chart: ChartCodeText={ChartCodeText}\n" +
                                      $"OrderID = {Order.OrderID} Measureprotocol.MainTemplateID = {Templates_MeasureProtocol.MainTemplate.ID}");

            }
            tlp_MainWindow.Invoke(new Action<TableLayoutPanel>(SetHeight), tlp_MainWindow);
            Invoke( () => DrawingControl.ResumeDrawing(this));
        }
        private double AggregateValue(object value, int decimals)
        {
            if (double.TryParse(value?.ToString(), out var result))
                return Math.Round(result, decimals);
            return double.NaN;
        }
        private string FormatDisplayValue(double value)
        {
            return double.IsNaN(value) ? "N/A" : value.ToString();
        }
        private void SetHeight(TableLayoutPanel tlp)
        {
            tlp.RowStyles[3].Height = Math.Max(MeasurePoints.MeasurePointsHeight, MeasureStatsHeight);
        }
        public static void Add_Label(FlowLayoutPanel flp, string text, string? parameterName, int height, FontStyle fontStyle = FontStyle.Regular, ContentAlignment content = ContentAlignment.MiddleCenter)
        {
            var foreColor = Teman.foreColor_MeasureStats;
            var font = new Font("Segoe UI", 9, fontStyle);
            double.TryParse(text, out var value);
           
            if (double.IsNaN(value) || text == "N/A")
                foreColor = Color.Red;
            
            var lbl = new Label
            {
                BackColor = Color.Transparent,
                ForeColor = foreColor,
                Text = text,
                Name = parameterName,
                Width = flp.Width - 2,
                Height = height,
                AutoSize = false,
                Font = font,
                Margin = new Padding(0, 0, 0, 0),
                TextAlign = content,
                Cursor = Cursors.Hand,
            };
            if (lbl.Width > flp.Width)
                flp.Invoke(new Action(() => flp.Width = lbl.Width + 5));
            if (!string.IsNullOrEmpty(parameterName))
                lbl.Click += Mätdata_Row_Click;
            flp.Invoke(new Action(() => flp.Controls.Add(lbl)));

        }
        public static void Mätdata_Row_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var mått = label.Name;
            if (string.IsNullOrEmpty(mått))
                Load_MätStatistik();
            
            active_MeasureCode = mått;
            Charts.Add_Data_Chart_MainForm(Charts.panel_Chart, mått, label.Text);
        }

        private void ShowStats_Click(object sender, EventArgs e)
        {
            Load_MätStatistik();
        }

        private static void Load_MätStatistik()
        {
            Activity.Start();

            Points.Add_Points(3, "Kollar mätstatistik");
            var stats = new MätStatistik();
            stats.Show();
            stats.InitializeForm();
            stats.Fill_ComboBox_Mått();

            _ = Activity.Stop($"Mätstatistik för order: {Order.OrderNumber}");
        }

        public static class Charts
        {
            public static Panel? panel_Chart;
            public static Chart chart;
            private static double? Y_Axis_MaxValue(string? codename, double sl_max)
            {
                var usl = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL") * 1.005;
                var max_chart = chart_Maximum_Yvalue(codename, sl_max) * 1.005;
                if (MeasurePoints.Tolerances.ActiveTolerance(codename, "USL") != null)
                    if (max_chart != null)
                        if (usl != null)
                            return Math.Ceiling(Math.Max(usl.Value, max_chart.Value) * 100) / 100;
                if (max_chart != null) 
                    return Math.Ceiling(max_chart.Value * 100) / 100;
                return null;
            }
            private static double? Y_Axis_MinValue(string? codename, double sl_min)
            {
                var lsl = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL") * 0.995;
                double? min_chart = chart_Minimum_Yvalue(codename, sl_min) * 0.995;

                if (MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL") == null) 
                    return Math.Floor(min_chart.Value * 100) / 100;
                if (lsl == null) 
                    return Math.Floor(min_chart.Value * 100) / 100;
                var min = Math.Floor(Math.Min(lsl.Value, min_chart.Value) * 100) / 100;
                return min;
            }

            [SuppressMessage("ReSharper.DPA", "DPA0005: Database issues")]
            private static void Initialize_Chart_MainForm(Chart chart, string? codename, string codetext)
            {
                chart.Titles.Clear();
                chart.Series.Clear();
                chart.ChartAreas.Clear();
                chart.Legends.Clear();


                var slMax = new StripLine();
                var slMin = new StripLine();

                chart.Dock = DockStyle.Fill;

                chart.Titles.Add(codetext);
                if (chart.Series.Any(s => s.Name == codename))
                    return;
                chart.Series.Add(codename);
                var serie1 = LanguageManager.GetString("chartSerieMeasurepoints1");
                var serie2 = LanguageManager.GetString("chartSerieMeasurepoints2");
                chart.Series.Add(serie1);
                chart.Series.Add(serie2);

                foreach (var serie in chart.Series)
                    serie.ChartType = SeriesChartType.Line;

                chart.Series[0].Color = Color.Yellow;
                chart.Series[1].Color = Color.Green;
                chart.Series[2].Color = Color.DeepSkyBlue;
                chart.Series[0].LegendText = $"{codetext}";
                chart.Series[1].LegendText = serie1;
                chart.Series[2].LegendText = serie2;
                chart.Titles[0].ForeColor = Color.Goldenrod;
                chart.Titles[0].Font = new Font("Lucida Sans", 11f, FontStyle.Regular);
                chart.ChartAreas.Add("chart_Area");
                chart.ChartAreas[0].AxisY.StripLines.Add(slMax);
                chart.ChartAreas[0].AxisY.StripLines.Add(slMin);
                chart.ChartAreas[0].BackColor = Color.Transparent;
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Transparent;
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Transparent;
                chart.ChartAreas[0].AxisX.LineColor = Color.Transparent;
                chart.ChartAreas[0].AxisY.LineColor = Color.Transparent;
                chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

                chart.Legends.Add("legend");
                chart.Legends[0].ForeColor = Color.White;
                chart.Legends[0].BackColor = Color.Transparent;


                slMax.BorderColor = Color.Red;
                slMin.BorderColor = Color.Red;
                slMin.BorderWidth = 1;
                slMax.BorderWidth = 1;

                chart.ChartAreas[0].AxisY.Maximum = (double)Y_Axis_MaxValue(codename, slMax.IntervalOffset);
                chart.ChartAreas[0].AxisY.Minimum = (double)Y_Axis_MinValue(codename, slMin.IntervalOffset);

                if (Y_Axis_MaxValue(codename, slMax.IntervalOffset) < Y_Axis_MinValue(codename, slMin.IntervalOffset))
                    chart.ChartAreas[0].AxisY.Maximum = (double)Y_Axis_MinValue(codename, slMin.IntervalOffset) + 1;

                chart.ChartAreas[0].AxisX.Minimum = 1;
               
                var USL = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL");
                var LSL = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL");
                                   
                if (USL != null)
                    slMax.IntervalOffset = MeasurePoints.Tolerances.ActiveTolerance(codename, "USL").Value;
                
                if (LSL != null)
                    slMin.IntervalOffset = MeasurePoints.Tolerances.ActiveTolerance(codename, "LSL").Value;
            }
            public static void Add_Data_Chart_MainForm(Panel? panel, string? codename, string? codetext)
            {
                chart = new Chart
                {
                    BackColor = Color.Transparent
                };
                panel?.Invoke(() => panel.Controls.Clear());

                Initialize_Chart_MainForm(chart, codename, codetext);
                    
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                            SELECT Value
                            FROM Measureprotocol.Data AS data
                            INNER JOIN Measureprotocol.MainData as maindata
                                ON data.OrderID = maindata.OrderID
                                    AND data.RowIndex = maindata.RowIndex
                            WHERE data.OrderID = @orderid
                            AND (Discarded = 'False' OR Discarded IS NULL)
                            AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)";

                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    con.Open();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@codename", codename);
                    var reader = cmd.ExecuteReader();
                    var ctr = 0;
                    while (reader.Read())
                    {
                        if (!double.TryParse(reader["Value"].ToString(), out var result)) 
                            continue;
                        chart.Series[0].Points.AddXY(ctr, result);
                        if (dict_AverageValuesForLastOrder.TryGetValue(codename, out var averageValueLastOrder))
                            chart.Series[1].Points.AddXY(ctr, averageValueLastOrder);
                        if (dict_AverageValuesForPart.TryGetValue(codename, out var averageValuePart))
                            chart.Series[2].Points.AddXY(ctr, averageValuePart);
                        ctr++;
                    }
                }
                panel?.Invoke(() => panel.Controls.Add(chart));
                }

            
        }
        public class ValidateMeasurements
        {
            public static void AverageValues()
            {
                var dt = Monitor.Monitor.DataTable_Measurepoints;
                if (string.IsNullOrEmpty(Order.OrderNumber) || dt is null)
                    return;

                for (var i = 0; i < dt.Rows.Count - 1; i++)
                {
                    var CodeName = dt.Rows[i][0].ToString();
                    double.TryParse(dt.Rows[i][2].ToString(), out var ucl);
                    double.TryParse(dt.Rows[i][4].ToString(), out var lcl);
                    double.TryParse(dt.Rows[i][1].ToString(), out var usl);
                    double.TryParse(dt.Rows[i][5].ToString(), out var lsl);
                    double value = GetMeasurementValue("AVG", CodeName);

                    if (value < lcl)
                        if (CodeName != null && lcl > 0 && value > 0)
                            InfoText.Show($"Enligt mätningarna så ligger Medel-{CodeName} under den lägre styrgränsen, kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Warning, $"Varning - {CodeName}");
                    if (value > ucl)
                        if (CodeName != null && ucl > 0 && value > 0)
                            InfoText.Show($"Enligt mätningarna så ligger Medel-{CodeName} över den övre styrgränsen, kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Warning, $"Varning - {CodeName}");

                    if (value < lsl)
                        if (CodeName != null && lsl > 0 && value > 0)
                            InfoText.Show($"Enligt mätningarna så ligger Medel-{CodeName} under den lägre gränsen, kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Bad, $"Varning - {CodeName}");
                    if (value > usl)
                        if (CodeName != null && usl > 0 && value > 0) 
                            InfoText.Show($"Enligt mätningarna så ligger Medel-{CodeName} över den övre styrgränsen, kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Bad, $"Varning - {CodeName}");
                }
            }
        }
    }
}
