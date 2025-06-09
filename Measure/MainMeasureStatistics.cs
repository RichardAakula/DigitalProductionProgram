using System;
using System.Configuration;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
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
        private static double AvgValue_Measurement_LastOrder(string? codename)
        {
            if (Order.PartNumber is null)
                return 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT AVG(Value) 
                    FROM Measureprotocol.Data AS data
                    INNER JOIN MeasureProtocol.MainData AS maindata
                        ON data.OrderID = maindata.OrderID
                        AND data.RowIndex = maindata.RowIndex
                    WHERE data.OrderID = 
                        (SELECT OrderID FROM (SELECT TOP(2)OrderID, ROW_NUMBER()
                            OVER (ORDER BY Date_Start DESC) AS RowNum
                            FROM [Order].MainData 
                            WHERE PartNr = @partnumber) AS tables
                            WHERE RowNum = 2)
                    AND (Discarded = 'False' OR Discarded IS NULL)
                    AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
                cmd.Parameters.AddWithValue("@codename", codename);
                var value = cmd.ExecuteScalar();
                if (value != null && value.GetType() != typeof(DBNull))
                    return double.Parse(value.ToString());
                return 0;
            }
        }
        private static double AvgValue_Measurement_Part(string? codename)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                    SELECT AVG(Value) 
                    FROM Measureprotocol.Data AS data 
                    INNER JOIN MeasureProtocol.MainData AS maindata
                        ON data.OrderID = maindata.OrderID
                        AND data.RowIndex = maindata.RowIndex
                    WHERE EXISTS (SELECT * FROM [Order].MainData WHERE data.OrderID = [Order].MainData.OrderID AND PartID = @partid)
                        AND (Discarded = 'False' OR Discarded IS NULL)
                        AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)";
            con.Open();
            var cmd = new SqlCommand(query, con);
            SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
            cmd.Parameters.AddWithValue("@codename", codename);
            var value = cmd.ExecuteScalar();
            if (value != null && value.GetType() != typeof(DBNull))
                if (double.TryParse(value.ToString(), out var result))
                    return result;
            return 0;
        }
        public static double MaxOrMinMeasureValue(string Min_Max, string? codename)
        {
            if (Order.OrderID is null)
                return 0;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"
                    SELECT {Min_Max}(Value) FROM MeasureProtocol.Data AS data
                    INNER JOIN MeasureProtocol.MainData AS maindata
	                    ON data.OrderID = maindata.OrderID
		                    AND data.RowIndex = maindata.RowIndex
                    WHERE data.OrderID = @orderid
                    AND (Discarded = 'False' OR Discarded IS NULL)
                        AND DescriptionId = (SELECT Id FROM MeasureProtocol.Description WHERE CodeName = @codename)";

                var cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@codename", codename);
               var value = cmd.ExecuteScalar();
               if (value == null) 
                   return 0;
               if (double.TryParse(value.ToString(), out var result))
                   return result;
            }

            return 0;
        }

       
        private static double? Max_Value_MätData(string? codename, double sl_max)
        {
            var max = Math.Max(AvgValue_Measurement_LastOrder(codename), MaxOrMinMeasureValue("MAX", codename));
            return Math.Max(max, sl_max);
        }
        private static double Min_Value_MätData(string? codename, double sl_min)
        {
            var min = Math.Min(MaxOrMinMeasureValue("MIN", codename), Math.Max(AvgValue_Measurement_LastOrder(codename), MaxOrMinMeasureValue("MIN", codename)));
            return Math.Min(Math.Max(min, sl_min), min);
        }
        public static int Max_Bag => (int)MaxOrMinMeasureValue("MAX", "Bag");
        public static string? active_MeasureCode;
        public static int MeasureStatsHeight;
        public static string? ChartCodename = string.Empty;
        public static string ChartCodeText = string.Empty;




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
            if (Order.OrderID is null)
                return;
            Invoke(new Action(() => DrawingControl.SuspendDrawing(this)));

            foreach (var flp in tlp_Main.Controls.OfType<FlowLayoutPanel>())
                flp.Invoke(new Action(() => flp.Controls.Clear()));
            Charts.panel_Chart = panel;
            MeasureStatsHeight = label_MeasureInformation.Height + (int)tlp_Main.RowStyles[0].Height + 2;
            
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
               // if (Order.OrderID is null)
                //    Order.Load_OrderID(Order.OrderNumber, Order.Operation);
                var query = @"
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
                var cmd = new SqlCommand(query, con);
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

                    Add_Label(flp_Codenames, $"{parameterText}:",reader["Parameter_Monitor"].ToString(), labelHeight, FontStyle.Bold, ContentAlignment.MiddleRight);
                    MeasureStatsHeight += labelHeight + 2;

                    int.TryParse(reader["Decimals"].ToString(), out var decimals);
                    if (double.TryParse(reader["Average"].ToString(), out var average))
                        Add_Label(flp_Average, $"{Math.Round(average, decimals)}", null, labelHeight);
                    if (double.TryParse(reader["Min"].ToString(), out var min))
                        Add_Label(flp_Min, $"{Math.Round(min, decimals)}", null, labelHeight);
                    if (double.TryParse(reader["Max"].ToString(), out var max))
                        Add_Label(flp_Max, $"{Math.Round(max, decimals)}", null, labelHeight);
                }
            }


            if (!string.IsNullOrEmpty(ChartCodename))
            {
                Charts.Add_Mätdata_Chart_MainForm(panel, ChartCodename, ChartCodeText);
            }
            else
            {
                _ = Log.Activity.Stop($"Felsökning rött kryss över chart: ChartCodeName={ChartCodename}");
                _ = Log.Activity.Stop($"Felsökning rött kryss över chart: ChartCodeName={ChartCodeText}");

            }
            tlp_MainWindow.Invoke(new Action<TableLayoutPanel>(SetHeight), tlp_MainWindow);
            
            // Invoke(new Action(() => Height = MeasureStatsHeight));
            Invoke( new Action(() => DrawingControl.ResumeDrawing(this)));
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
           
            if (double.IsNaN(value))
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
            Charts.Add_Mätdata_Chart_MainForm(Charts.panel_Chart, mått, label.Text);
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
                var max_chart = Max_Value_MätData(codename, sl_max) * 1.005;
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
                double? min_chart = Min_Value_MätData(codename, sl_min) * 0.995;

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
                var slMax = new StripLine();
                var slMin = new StripLine();

                chart.Dock = DockStyle.Fill;

                chart.Titles.Add(codetext);
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
            public static void Add_Mätdata_Chart_MainForm(Panel? panel, string? codename, string codetext)
            {
                chart = new Chart
                {
                    BackColor = Color.Transparent
                };
              //  try
                {
                    panel.Invoke(new Action(() => panel.Controls.Clear()));

                    Initialize_Chart_MainForm(chart, codename, codetext);
                    var AvgValueLastOrder = AvgValue_Measurement_LastOrder(codename);
                    var AvgValuePartNumber = AvgValue_Measurement_Part(codename);
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

                        var cmd = new SqlCommand(query, con);
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
                            chart.Series[1].Points.AddXY(ctr, AvgValueLastOrder);
                            chart.Series[2].Points.AddXY(ctr, AvgValuePartNumber);
                            ctr++;
                        }

                    }
                    panel.Invoke(new Action(() => panel.Controls.Add(chart)));
                }

                // catch (Exception exc)
                {
                    //LoggaLaddtid.Start();
                    //LoggaLaddtid.Stop($"Error - Chart: Fel =({exc}) ----- AxisX-min = {chart.ChartAreas[0].AxisX.Minimum} ---AxisX-max = {chart.ChartAreas[0].AxisX.Maximum} ---AxisY-min = {chart.ChartAreas[0].AxisY.Minimum} --- AxisY-max = {chart.ChartAreas[0].AxisY.Maximum}");
                    //if (Person.Role == Roles.SuperUser)
                    //{
                    //    MessageBox.Show(exc.Message);
                    //    MessageBox.Show(exc.InnerException.Message);
                    //}
                }
            }
        }
        public class Kontrollera_Mätningar
        {
            public static void Medelvärden()
            {
                var dt = Monitor.Monitor.DataTable_Measurepoints;
                if (string.IsNullOrEmpty(Order.OrderNumber))
                    return;

                for (var i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (MaxOrMinMeasureValue("AVG", dt.Rows[i][0].ToString()) < double.Parse(dt.Rows[i][4].ToString()))
                        InfoText.Show($"Enligt mätningarna så ligger Medel-{dt.Rows[i][0].ToString()[i]} under den lägre styrgränsen, vänligen kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Warning, $"Varning - Medel {dt.Rows[i][0]}");
                    if (MaxOrMinMeasureValue("AVG",dt.Rows[i][0].ToString()) > double.Parse(dt.Rows[i][2].ToString()))
                        InfoText.Show($"Enligt mätningarna så ligger Medel-{dt.Rows[i][0].ToString()[i]} över den övre styrgränsen, vänligen kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Warning, $"Varning - Medel ID{dt.Rows[i][0]}");

                    if (MaxOrMinMeasureValue("AVG",dt.Rows[i][0].ToString()) < double.Parse(dt.Rows[i][5].ToString()))
                        InfoText.Show($"Enligt mätningarna så ligger Medel-{dt.Rows[i][0].ToString()[i]} under den lägre gränsen, kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Bad, $"Varning - Medel {dt.Rows[i][0]}");
                    if (MaxOrMinMeasureValue("AVG", dt.Rows[i][0].ToString()) > double.Parse(dt.Rows[i][1].ToString()))
                        InfoText.Show($"Enligt mätningarna så ligger Medel-{dt.Rows[i][0].ToString()[i]} över den övre styrgränsen, kontrollera att mätningarna är ok.", CustomColors.InfoText_Color.Bad, $"Varning - Medel {dt.Rows[i][0]}");
                }
            }
        }
    }
}
