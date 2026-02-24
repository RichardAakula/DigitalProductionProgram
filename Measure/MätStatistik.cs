using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;

namespace DigitalProductionProgram.Measure
{
    public sealed partial class MätStatistik : Form
    {
        private Color clr;
        private Color clr_slMax;
        private Color clr_slMin;
        private DataTable dt_MeasureData = new();
        private readonly ToolTip tooltip = new ();
        private readonly StripLine sl_USL = new ();
        private readonly StripLine sl_UCL = new ();
        private readonly StripLine sl_LSL = new ();
        private readonly StripLine sl_LCL = new ();
        public enum ToleranceType
        {
            USL,
            UCL,
            NOM,
            LCL,
            LSL
        }
        private double? MeasurePoint(ToleranceType toleranceType)
        {
            var dt = Monitor.Monitor.DataTable_Measurepoints;
            var codeName = cb_CodeName.SelectedValue?.ToString();
            var rows = dt.Select($"Description = '{codeName}'");
            if (rows.Length == 0)
                return null;

            var row = rows[0];

            // Returnera rätt kolumn
            return row[toleranceType.ToString()] as double?;

            
        }
     
        
        private double? MIN(string codeName)
        {
            if (dt_MeasureData == null || dt_MeasureData.Rows.Count == 0 || string.IsNullOrWhiteSpace(codeName))
                return null;

            var values = dt_MeasureData.AsEnumerable()
                .Where(r =>
                    (r.IsNull("Discarded") || !r.Field<bool>("Discarded")) &&
                    string.Equals(r.Field<string>("CodeName"), codeName, StringComparison.OrdinalIgnoreCase))
                .Select(r => r["Value"])
                .Where(v => v != null && v != DBNull.Value)
                .Select(v => Convert.ToDouble(v));

            return values.Any() ? values.Min() : (double?)null;
        }
        private double? MAX(string codeName)
        {
            if (dt_MeasureData == null || dt_MeasureData.Rows.Count == 0 || string.IsNullOrWhiteSpace(codeName))
                return null;

            var values = dt_MeasureData.AsEnumerable()
                .Where(r =>
                    (r.IsNull("Discarded") || !r.Field<bool>("Discarded")) &&
                    string.Equals(r.Field<string>("CodeName"), codeName, StringComparison.OrdinalIgnoreCase))
                .Select(r => r["Value"])
                .Where(v => v != null && v != DBNull.Value)
                .Select(v => Convert.ToDouble(v));

            return values.Any() ? values.Max() : (double?)null;
        }
        private double? AVG(string codeName)
        {
            if (dt_MeasureData == null || dt_MeasureData.Rows.Count == 0 || string.IsNullOrWhiteSpace(codeName))
                return null;

            var values = dt_MeasureData.AsEnumerable()
                .Where(r =>
                    (r.IsNull("Discarded") || !r.Field<bool>("Discarded")) &&
                    string.Equals(r.Field<string>("CodeName"), codeName, StringComparison.OrdinalIgnoreCase))
                .Select(r => r["Value"])
                .Where(v => v != null && v != DBNull.Value)
                .Select(v => Convert.ToDouble(v));

            return values.Any() ? values.Average() : (double?)null;
        }
        
        //private readonly Dictionary<string, Color> _orderColors = new();
        //private readonly Random _rand = new();
        
        //private Color GetColorForOrder(string orderNr)
        //{
        //    if (string.IsNullOrEmpty(orderNr))
        //        return Color.LightGray; // fallback

        //    if (_orderColors.TryGetValue(orderNr, out var c))
        //        return c;

        //    // Skapa en riktigt tydlig ljus färg via HSL
        //    c = GenerateVisibleColor();

        //    _orderColors[orderNr] = c;
        //    return c;
        //}
        //private Color GenerateVisibleColor()
        //{
        //    // Hue 0–360
        //    double h = _rand.NextDouble() * 360.0;

        //    // Saturation & Lightness höga för tydlighet
        //    double s = 0.75; // 75%
        //    double l = 0.70; // 70%

        //    return ColorFromHSL(h, s, l);
        //}
        //private Color ColorFromHSL(double h, double s, double l)
        //{
        //    // HSL → RGB (standardformel)
        //    h /= 360.0;

        //    double r = 0, g = 0, b = 0;

        //    if (s == 0)
        //    {
        //        r = g = b = l;
        //    }
        //    else
        //    {
        //        double q = l < 0.5 ? l * (1 + s) : l + s - (l * s);
        //        double p = 2 * l - q;

        //        r = Hue2RGB(p, q, h + 1.0 / 3.0);
        //        g = Hue2RGB(p, q, h);
        //        b = Hue2RGB(p, q, h - 1.0 / 3.0);
        //    }

        //    return Color.FromArgb(
        //        255,
        //        (int)(r * 255),
        //        (int)(g * 255),
        //        (int)(b * 255));
        //}
        //private double Hue2RGB(double p, double q, double t)
        //{
        //    if (t < 0) t += 1;
        //    if (t > 1) t -= 1;
        //    if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
        //    if (t < 1.0 / 2.0) return q;
        //    if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;

        //    return p;
        //}

       
        
        private (string OrderNr, double? Value, int RowIndex) GetOrderNrAndValue(DataTable table, int tableRowIndex)
        {
            var row = table.Rows[tableRowIndex];

            string orderNr = row["OrderNr"]?.ToString();
            double? value = row["Value"] == DBNull.Value ? null : Convert.ToDouble(row["Value"]);
            int rowIndex = Convert.ToInt32(row["RowIndex"]); // SQL RowIndex

            return (orderNr, value, rowIndex);
        }




        private DataTable LoadMätData()
        {
            dt_MeasureData.Clear();
            var query = """
                        SELECT 
                            maindata.OrderNr,
                            description.CodeName,
                            data.Value,
                            data.TextValue,
                            data.BoolValue,
                            data.DateValue,
                            main.Date,
                            main.Discarded,
                            main.ErrorCode,
                            main.AnstNr,
                            main.Sign,
                            template.ColumnIndex,
                            template.Decimals,
                            main.RowIndex,
                            template.DataType
                        
                        FROM MeasureProtocol.Data as data
                        JOIN MeasureProtocol.Description as description
                            ON data.DescriptionId = description.ID
                        JOIN MeasureProtocol.Template as template
                            ON data.DescriptionId = template.DescriptionID
                        
                        JOIN MeasureProtocol.MainData as main
                            ON data.RowIndex = main.RowIndex AND data.OrderID = main.OrderId
                        JOIN [Order].MainData as maindata
                            ON maindata.OrderID = main.OrderID 
                        """;
            if (cB_visaAllaOrdrar.Checked)
                query += """
                         WHERE maindata.OrderID IN 
                         (
                             SELECT OrderID 
                             FROM [Order].MainData
                             WHERE PartID = @partid
                         ) 
                         """;
            else
                query += """
                         WHERE data.OrderID = @orderid AND template.MeasureProtocolMainTemplateID = @maintemplateid 
                         """;
            query += """
                     AND CodeName = @codename
                     ORDER BY maindata.OrderID, main.RowIndex, template.ColumnIndex
                     """;

            return Database.ExecuteSafe(con =>
            {
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                cmd.Parameters.AddWithValue("@codename", cb_CodeName.SelectedValue.ToString());

                dt_MeasureData.Load(cmd.ExecuteReader());
                return dt_MeasureData;
            });
        }


        //---------------Start------------
        public MätStatistik()
        {
            InitializeComponent();
            InitializeForm();
            Fill_CodeName();
            Load_Values();
            DoubleBuffered = true;
            sl_USL.BorderWidth = sl_UCL.BorderWidth = sl_LCL.BorderWidth = sl_LSL.BorderWidth = 2;
            sl_USL.Interval = sl_UCL.Interval = sl_LCL.Interval = sl_LSL.Interval = 0;
        }
        public void InitializeForm()
        {
            //Opacity at Start = 20 %
            for (int i = 0; i < 180; i++)
            {
                Opacity += 0.004f;
                Refresh();
            }

            lblOrderNr.Text = Order.OrderNumber;
            lblOrderNr.Visible = true;
            cb_CodeName.Visible = true;
            chartData.Visible = true;
            cB_visaAllaOrdrar.Visible = true;
            dgv_OrderList.Visible = true;
        
        }
        public void Fill_CodeName()
        {
            // Koppla loss ev. tidigare binding för att undvika spökvärden
            cb_CodeName.DataSource = null;
            cb_CodeName.Items.Clear();

            var dt = new DataTable();
            dt.Columns.Add("UserText", typeof(string));
            dt.Columns.Add("Monitor", typeof(string));

            Database.ExecuteSafe(con =>
            {
                const string query = """
                                     SELECT 
                                        template.Parameter_UserText, 
                                        template.Parameter_Monitor
                                     FROM MeasureProtocol.Template AS template
                                     JOIN MeasureProtocol.Description AS description
                                        ON template.DescriptionID = description.ID
                                     WHERE template.MeasureProtocolMainTemplateID = @measureprotocolmaintemplateid
                                        AND description.IsMeasureValue = 'True';
                                     """;

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@measureprotocolmaintemplateid", SqlDbType.Int)
                    .Value = Templates_MeasureProtocol.MainTemplate.ID;

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Skydda mot NULL i databasen
                    var userText = !reader.IsDBNull(0) ? reader.GetString(0) : string.Empty;
                    var monitor  = !reader.IsDBNull(1) ? reader.GetString(1) : string.Empty;

                    dt.Rows.Add(userText, monitor);
                }
            });

            // Binda comboboxen: visa UserText, använd Monitor som värde
            cb_CodeName.DisplayMember = "UserText";
            cb_CodeName.ValueMember   = "Monitor";
            cb_CodeName.DataSource    = dt;

            // Sätt vald post om det finns några
            if (cb_CodeName.Items.Count > 0)
                cb_CodeName.SelectedIndex = 0;
            else
                cb_CodeName.SelectedIndex = -1; // inget att välja
        }


        

        private void Load_Values()
        {
            dt_MeasureData = LoadMätData();
            if (dt_MeasureData.Rows.Count < 1)
                return;

            Initialize_SPC_Data();
            
            var s = chartData.Series[0];
            s.Points.Clear();
           // s.YValuesPerPoint = 1;

            Initialize_Chart();
            Initialize_Striplines();

            if (string.IsNullOrEmpty(cb_CodeName.SelectedValue.ToString()))
                return;
            for (int i = 0; i < dt_MeasureData.Rows.Count; i++)
            {
                var (orderNr, value, realRowIndex) = GetOrderNrAndValue(dt_MeasureData, i);
                if (!value.HasValue)
                    continue;

                var label = $"{i + 1}: {orderNr}";
                var idx = chartData.Series[0].Points.AddXY(i+1, value.Value);
                // Här hämtar vi punkten
                var p = chartData.Series[0].Points[idx];
                // realRowIndex = Convert.ToInt32(dt_MeasureData.Rows[i]["RowIndex"]);
                p.Tag = new
                {
                    Value = value.Value,
                    RowIndex = realRowIndex,
                    OrderNr = orderNr,
                };
                p.AxisLabel = label;
                // Random färg för ordren
                var color = CustomColors.GetColorForOrder(orderNr);

                p.Color = color;
                p.MarkerColor = color;
                p.BorderColor = color;
            }

           
        }
        private void Initialize_SPC_Data()
        {
            var usl = MeasurePoint(ToleranceType.USL);
            var lsl = MeasurePoint(ToleranceType.LSL);
            lbl_USL.Text = @$"{usl:0.000}";
            lbl_Max.Text = @$"{MAX(cb_CodeName.SelectedValue.ToString()):0.000}";
            lbl_Avg.Text = @$"{AVG(cb_CodeName.SelectedValue.ToString()):0.000}";
            lbl_Min.Text = @$"{MIN(cb_CodeName.SelectedValue.ToString()):0.000}";
            lbl_LSL.Text = @$"{lsl:0.000}";
            try
            {
                lbl_HiLo.Text = $@"{MAX(cb_CodeName.SelectedValue.ToString()) - MIN(cb_CodeName.SelectedValue.ToString()):0.000}";
            }
            catch { lbl_HiLo.Text = "N/A"; }

            var list_double = new List<double?>();
            for (var i = 0; i < dt_MeasureData.Rows.Count; i++)
            {
                var (_, value, _) = GetOrderNrAndValue(dt_MeasureData, i);
                if (value.HasValue)
                   list_double.Add(value.Value);
            }
            lbl_Cp.Text = $@"{Calculate.Pp(list_double, usl, lsl)}";
            lbl_Cpk.Text = $@"{Calculate.Ppk(list_double, usl, lsl)}";
        }
        private void Initialize_Striplines()
        {
            var usl = MeasurePoint(ToleranceType.USL);
            var ucl = MeasurePoint(ToleranceType.UCL);
            var lsl = MeasurePoint(ToleranceType.LSL);
            var lcl = MeasurePoint(ToleranceType.LCL);
            if (usl != null)
            {
                sl_USL.BorderColor = Color.Red;
                sl_USL.IntervalOffset = (double)usl;
                sl_USL.Text = "USL";
                chartData.ChartAreas[0].AxisY.StripLines.Add(sl_USL);
            }
            if (ucl != null)
            {
                sl_UCL.BorderColor = Color.DarkOrange;
                sl_UCL.IntervalOffset = (double)ucl;
                sl_UCL.Text = "UCL";
                chartData.ChartAreas[0].AxisY.StripLines.Add(sl_UCL);
            }

            if (lsl != null)
            {
                sl_LSL.BorderColor = Color.Red;
                sl_LSL.IntervalOffset = (double)lsl;
                sl_LSL.Text = "LSL";
                chartData.ChartAreas[0].AxisY.StripLines.Add(sl_LSL);
            }
            if (lcl != null)
            {
                sl_LCL.BorderColor = Color.DarkOrange;
                sl_LCL.IntervalOffset = (double)lcl;
                sl_LCL.Text = "LCL";
                chartData.ChartAreas[0].AxisY.StripLines.Add(sl_LCL);
            }

            
        }
        private void Initialize_Chart()
        {
            double? usl = MeasurePoint(ToleranceType.USL);
            double? lsl = MeasurePoint(ToleranceType.LSL);

            // Om USL saknas → använd maxvärdet i datan
            var actualMax = usl ?? (double)MAX(cb_CodeName.SelectedValue.ToString());

            // Om LSL saknas → använd minvärdet i datan
            var actualMin = lsl ?? (double)MIN(cb_CodeName.SelectedValue.ToString());

            // Lägg på margin
            var max = actualMax + 0.02;
            var min = actualMin - 0.02;

            if (min < 0)
                min = 0;

            chartData.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max * 100) / 100;
            chartData.ChartAreas[0].AxisY.Minimum = Math.Floor(min * 100) / 100;

            chartData.Titles[0].Text = cb_CodeName.SelectedValue?.ToString();
            chartData.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.00}";
        }
       
      
        private void Fill_dgv()
        {
            return;
            List<string> values = new List<string>();
            dgv_OrderList.Rows.Clear();
            for (int i = 0; i < dt_MeasureData.Rows.Count; i++)
            {
                if (!values.Contains($"{dt_MeasureData.Rows[i]["OrderNr"]}"))
                    values.Add($"{dt_MeasureData.Rows[i]["OrderNr"]}");
            }
            for (int i = 0; i < values.Count; i++)
            {
                dgv_OrderList.Rows.Add();
                dgv_OrderList.Rows[i].Cells[0].Value = values[i];
            }
        }

        private void CodeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Values();
            Fill_dgv();

        }
        private void chartData_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = chartData.HitTest(e.X, e.Y);

            if (pos.ChartElementType == ChartElementType.DataPoint)
            {
                var p = chartData.Series[0].Points[pos.PointIndex];
                dynamic tag = p.Tag;

                tooltip.SetToolTip(chartData,
                    $"Value: {tag.Value}\n" +
                    $"OrderNr: {tag.OrderNr}\n" +
                    $"RowIndex: {tag.RowIndex}"
                );
            }
            else
            {
                tooltip.SetToolTip(chartData, "");
            }
        }
        private void DataGridView_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = 0;
            foreach (DataPoint dp in chartData.Series[0].Points)
            {
                if (dt_MeasureData.Rows[i][1].ToString() + dt_MeasureData.Rows[i][2] == dgv_OrderList.CurrentCell.Value.ToString())
                {
                    dp.Color = Color.Goldenrod;
                    dp.BorderWidth = 3;
                }
                i++; 
            }
        }
        private void MätStatistik_Deactivate(object sender, EventArgs e)
        {
         //   Close();
        }
    }
}
