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
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView.WinForms;
using Microsoft.Data.SqlClient;
using SkiaSharp;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.ObjectModel;

namespace DigitalProductionProgram.Measure
{
    public partial class MainMeasureStatistics : UserControl
    {
       
        private static MeasurementChart? measurementChart;
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

        public async Task Add_MeasureInformation_MainForm(MeasurementChart _measurementChart, TableLayoutPanel tlp_MainWindow)
        {
            measurementChart = _measurementChart;
            if (Order.OrderID is null || Templates_MeasureProtocol.MainTemplate.ID == 0 || Templates_MeasureProtocol.MainTemplate.ID is null)
                return;

            Invoke(new Action(() => DrawingControl.SuspendDrawing(this)));

            foreach (var flp in tlp_Main.Controls.OfType<FlowLayoutPanel>())
                flp.Invoke(new Action(() => flp.Controls.Clear()));

            MeasureStatsHeight = label_MeasureInformation.Height + (int)tlp_Main.RowStyles[0].Height + 2;

            var measureDataList = new List<(string Parameter_UserText, string Parameter_Monitor, int Decimals, decimal Average, decimal Min, decimal Max)>();

            await using (var con = new SqlConnection(Database.cs_Protocol))
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

                await using (var cmd = new SqlCommand(query, con))
                {
                    ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);

                    await con.OpenAsync();

                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var parameterUserText = reader["Parameter_UserText"].ToString() ?? string.Empty;
                            var parameterMonitor = reader["Parameter_Monitor"].ToString() ?? string.Empty;
                            var decimals = int.TryParse(reader["Decimals"].ToString(), out var d) ? d : 0;
                            var avg = reader["Average"] != DBNull.Value ? Convert.ToDecimal(reader["Average"]) : 0m;
                            var min = reader["Min"] != DBNull.Value ? Convert.ToDecimal(reader["Min"]) : 0m;
                            var max = reader["Max"] != DBNull.Value ? Convert.ToDecimal(reader["Max"]) : 0m;

                            measureDataList.Add((parameterUserText, parameterMonitor, decimals, avg, min, max));
                        }
                    }
                }
            }

            Invoke(() =>
            {
                foreach (var item in measureDataList)
                {
                    var parameterText = item.Parameter_UserText;
                    var textwidth = TextRenderer.MeasureText(parameterText, new Font("Segoe UI", 9, FontStyle.Bold)).Width;
                    var labelHeight = textwidth > flp_Codenames.Width - 10 ? 40 : 20;

                    if (string.IsNullOrEmpty(ChartCodename))
                    {
                        ChartCodename = item.Parameter_Monitor;
                        ChartCodeText = parameterText;
                    }

                    Add_Label(flp_Codenames, $"{parameterText}:", item.Parameter_Monitor, labelHeight, FontStyle.Bold, ContentAlignment.MiddleRight);
                    MeasureStatsHeight += labelHeight + 2;

                    var avg = AggregateValue(item.Average, item.Decimals);
                    var min = AggregateValue(item.Min, item.Decimals);
                    var max = AggregateValue(item.Max, item.Decimals);

                    Add_Label(flp_Average, FormatDisplayValue(avg), null, labelHeight);
                    Add_Label(flp_Min, FormatDisplayValue(min), null, labelHeight);
                    Add_Label(flp_Max, FormatDisplayValue(max), null, labelHeight);
                }
            });

            if (!string.IsNullOrEmpty(ChartCodename))
            {
                await Task.Run(() => measurementChart.Add_Data_Chart_MainForm(ChartCodename, ChartCodeText));
            }
            else
            {
                await measurementChart.RemoveChart();
                if (ChartCodeText != null)
                    _ = Activity.Stop($"Felsökning rött kryss över chart: ChartCodeText={ChartCodeText}\n" +
                                  $"OrderID = {Order.OrderID} Measureprotocol.MainTemplateID = {Templates_MeasureProtocol.MainTemplate.ID}");
            }

            tlp_MainWindow.Invoke(new Action<TableLayoutPanel>(SetHeight), tlp_MainWindow);
            Invoke(() => DrawingControl.ResumeDrawing(this));
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
        public static async void Mätdata_Row_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var mått = label.Name;
            if (string.IsNullOrEmpty(mått))
                Load_MätStatistik();
            
            active_MeasureCode = mått;

            await measurementChart?.Add_Data_Chart_MainForm(mått, label.Text);
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
