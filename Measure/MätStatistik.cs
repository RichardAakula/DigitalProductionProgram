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
        private readonly StripLine slMax = new ();
        private readonly StripLine slMin = new ();
        private double? USL
        {
            get
            {
                clr_slMax = Color.Red;
                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                    case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                        return USL_Extrudering;

                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        return USL_Krympslang;
                }
                return 0;
            }
        }
        private double? USL_Extrudering
        {
            get
            {
                switch (cb_Mått.Text)
                {
                    case "ID":
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "USL");
                        clr_slMax = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "NOM") + 0.03;
                    case "OD":
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "USL");
                        clr_slMax = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") + 0.03;
                    case "Wall":
                    {
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "USL") > 0)
                                return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "USL");
                        clr_slMax = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "NOM") + 0.02;
                    }
                    case "Oval":
                        {
                            switch (Order.WorkOperation)
                            {
                                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                                    return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Ovality, "USL");
                                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                                case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                                    return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Ovality, "USL");
                            }
                            break;
                        }
                    case "RunOut":
                        {
                            switch (Order.WorkOperation)
                            {
                                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                                    return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Runout, "USL");
                                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                                case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                                    return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Runout, "USL");
                            }
                            break;
                        }
                    case "L":
                    case "Length":
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "LSL");
                }
                return 0;
            }
        }
        private double? USL_Krympslang
        {
            get
            {
                switch (cb_Mått.SelectedIndex)
                {
                    case 0:  //Blåst ID
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpID, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpID, "USL");
                        clr_slMax = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpID, "LSL") + 0.1;
                    case 1: //Blåst OD
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "USL");
                        clr_slMax = Color.Orange; 
                        return AVG(cb_Mått.Text) + 0.1;
                    case 2:  //Blåst W
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "USL");
                        clr_slMax = Color.Orange;
                        return AVG(cb_Mått.Text) + 0.03;
                    case 3:  //Krympt ID
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "USL");
                    case 4:  
                        clr_slMax = Color.Orange;
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "USL") + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "USL") + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "LSL");
                        break;
                    case 5:  //Krympt W
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "USL");
                        clr_slMax = Color.Orange;
                        return AVG(cb_Mått.Text) + 0.02;
                    case 6:  //Längd
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "USL");
                }
                return 0;
            }
        }
        private double? LSL
        {
            get
            {
                clr_slMin = Color.Red;
                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                    case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                        return LSL_Extrudering;

                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        return LSL_Krympslang;
                }
                return 0;
            }
        }
        private double? LSL_Extrudering
        {
            get
            {
                switch (cb_Mått.Text)
                {
                    case "ID":
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "LSL");
                        clr_slMin = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "NOM") - 0.03;
                    case "OD":
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "LSL");
                        clr_slMin = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM") - 0.03;
                    case "Wall":
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "LSL");
                        clr_slMin = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "NOM") - 0.02;
                    case "Oval":
                    case "RunOut":
                        return 0;
                    case "L":
                    case "Length":
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "LSL");
                }
                return 0;
            }
        }
        private double? LSL_Krympslang
        {
            get
            {
                switch (cb_Mått.SelectedIndex)
                {
                    case 0: 
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpID, "LSL");
                    case 1: //Blåst OD
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpOD, "LSL");
                        clr_slMin = Color.Orange;
                        return AVG(cb_Mått.Text) - 0.1;
                    case 2:  //Blåst W
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "LSL");
                        clr_slMin = Color.Orange;
                        return (AVG(cb_Mått.Text) - 0.03);
                    case 3:  //Krympt ID
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "LSL");
                        clr_slMin = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "USL") - 0.3;
                    case 4:  //Krympt OD
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "LSL") > 0)
                        {
                            clr_slMin = Color.Orange;
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "LSL") - (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "LSL") + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "USL"));
                        }

                        clr_slMin = Color.Orange;
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecID, "USL") + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "LSL") + MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "USL") - 0.3;
                    case 5:  //Krympt W
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.RecWall, "LSL");
                        break;
                    case 6:  //Längd
                        return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "LSL");
                    }
                    return 0;

            }
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
        private double? GetValueByCodeName(DataTable table, string codeName)
        {
            if (table == null || table.Rows.Count == 0 || string.IsNullOrWhiteSpace(codeName))
                return null;

            // Hitta första raden där CodeName matchar
            var row = table.AsEnumerable()
                .FirstOrDefault(r => string.Equals(
                    r.Field<string>("CodeName"),
                    codeName,
                    StringComparison.OrdinalIgnoreCase));

            if (row == null)
                return null;

            var obj = row["Value"];

            if (obj == null || obj == DBNull.Value)
                return null;

            // Konvertera alla rimliga typer
            if (obj is double d) return d;
            if (obj is float f) return f;
            if (obj is int i) return i;
            if (obj is long l) return l;
            if (obj is decimal dec) return (double)dec;

            if (double.TryParse(obj.ToString(), out var parsed))
                return parsed;

            return null;
        }


        private DataTable LoadMätData()
        {
            dt_MeasureData.Clear();
            var query = """
                        SELECT CodeName, Value, TextValue, BoolValue, DateValue, Date, Discarded, ErrorCode, AnstNr, Sign, ColumnIndex, Decimals, data.RowIndex, DataType
                        FROM MeasureProtocol.Data as data
                        JOIN MeasureProtocol.Description as description
                            ON data.DescriptionId = description.ID
                        JOIN MeasureProtocol.Template as template
                            ON data.DescriptionId = template.DescriptionID
                        JOIN MeasureProtocol.MainData as main
                            ON data.RowIndex = main.RowIndex AND data.OrderID = main.OrderID 
                        """;
            if (cB_visaAllaOrdrar.Checked)
                query += """
                         WHERE EXISTS 
                         (
                            SELECT * FROM [Order].MainData 
                            WHERE korprotokoll.PartID = @partid
                                AND data.OrderID = korprotokoll.OrderID AND Discarded = 'False'
                         ) 
                         ORDER BY data.OrderID, Påse_Spole
                         """;
            else
                query += """
                         WHERE data.OrderID = @orderid AND FormTemplateID = @formtemplateid
                            AND (Discarded = 'False' OR Discarded IS NULL)
                         ORDER BY RowIndex, ColumnIndex
                         """;

            return Database.ExecuteSafe(con =>
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);

                dt_MeasureData.Load(cmd.ExecuteReader());
                return dt_MeasureData;
            });
        }


        //---------------Start------------
        public MätStatistik()
        {
            InitializeComponent();
            
            DoubleBuffered = true;
            slMax.BorderWidth = 2;
            slMin.BorderWidth = 2;
            slMax.Interval = 0;
            slMin.Interval = 0;
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
            cb_Mått.Visible = true;
            chartData.Visible = true;
            cB_visaAllaOrdrar.Visible = true;
            dgv_OrderList.Visible = true;
        
        }
        public void Fill_ComboBox_Mått()
        {
            switch(Order.WorkOperation)
            {
                
                case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                case Manage_WorkOperation.WorkOperations.Extrudering_PTFE:
                case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                    cb_Mått.Items.Add("ID");
                    cb_Mått.Items.Add("OD");
                    cb_Mått.Items.Add("Wall");
                    cb_Mått.Items.Add("Oval");
                    cb_Mått.Items.Add("RunOut");
                    cb_Mått.Items.Add("Length");
                    break;
                case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                    cb_Mått.Items.Add("Exp_ID");
                    cb_Mått.Items.Add("Exp_OD");
                    cb_Mått.Items.Add("Exp_Wall");
                    cb_Mått.Items.Add("Rec_ID");
                    cb_Mått.Items.Add("Rec_OD");
                    cb_Mått.Items.Add("Rec_Wall");
                    cb_Mått.Items.Add("Length");
                    break;
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    cb_Mått.Items.Add("ID");
                    cb_Mått.Items.Add("OD");
                    cb_Mått.Items.Add("Wall");
                    cb_Mått.Items.Add("Oval");
                    cb_Mått.Items.Add("RunOut");
                    break;
                case Manage_WorkOperation.WorkOperations.Synergy_PTFE_K18:
                    cb_Mått.Items.Add("MainBody_ID");
                    cb_Mått.Items.Add("Tapered_ID");
                    cb_Mått.Items.Add("Tapered_Length");
                    cb_Mått.Items.Add("Gap_Overtube");
                    cb_Mått.Items.Add("Tapered_Flared_OD");
                    cb_Mått.Items.Add("Length_Overtube");
                    cb_Mått.Items.Add("MainBody_Flared_OD");
                    cb_Mått.Items.Add("Tapered_OD");
                    cb_Mått.Items.Add("MainBody_OD");
                    cb_Mått.Items.Add("Oval");
                    cb_Mått.Items.Add("Ovality_Zumbach");
                    break;
            }
            cb_Mått.SelectedIndex = 0;

        }

        

        private void Set_Color_Chart_Series(string ordernrAktiv, string orderNrFöregående)
        {
            if (ordernrAktiv != orderNrFöregående)
                if (clr == Color.Green)
                    clr = Color.RoyalBlue;
                else
                    clr = Color.Green;
            else
                if (clr == Color.Green)
                    clr = Color.Green;
                else
                    clr = Color.RoyalBlue;
        }
        private void Load_Values()
        {
            dt_MeasureData = LoadMätData();
            if (dt_MeasureData.Rows.Count < 1)
                return;

            Initialize_SPC_Data();
            chartData.Series[0].Points.Clear();
            Initialize_Chart();
            Initialize_Striplines();

            if (string.IsNullOrEmpty(cb_Mått.Text))
                return;
            for (int i = 0; i < dt_MeasureData.Rows.Count; i++)
            {
                    var value = GetValueByCodeName(dt_MeasureData, cb_Mått.Text);
                    chartData.Series[0].Points.Add((double)value);
            }

            FärgläggPunkterIdiagram();
           
        }
        private void Initialize_SPC_Data()
        {
            lbl_USL.Text = @$"{USL:0.000}";
            lbl_Max.Text = @$"{MAX(cb_Mått.Text):0.000}";
            lbl_Avg.Text = @$"{AVG(cb_Mått.Text):0.000}";
            lbl_Min.Text = @$"{MIN(cb_Mått.Text):0.000}";
            lbl_LSL.Text = @$"{LSL:0.000}";
            try
            {
                lbl_HiLo.Text = $@"{MAX(cb_Mått.Text) - MIN(cb_Mått.Text):0.000}";
            }
            catch { lbl_HiLo.Text = "N/A"; }

            var list_double = new List<double?>();
            for (int i = 0; i < dt_MeasureData.Rows.Count; i++)
            {
                var value = GetValueByCodeName(dt_MeasureData, cb_Mått.Text);
                list_double.Add(value);
            }
            lbl_Cp.Text = $@"{Calculate.Cp(list_double, USL, LSL)}";
            lbl_Cpk.Text = $@"{Calculate.Cpk(list_double, USL, LSL)}";
        }
        private void Initialize_Striplines()
        {
            slMax.BorderColor = slMax.ForeColor = clr_slMax;
            slMin.BorderColor = slMin.ForeColor = clr_slMin;
            slMax.IntervalOffset = (double)USL;
            slMin.IntervalOffset = (double)LSL;
            if (slMax.BorderColor == Color.Orange)
                slMax.Text = "Uppskattad USL";
            else
                slMax.Text = "USL";

            if (slMin.BorderColor == Color.Orange)
                slMin.Text = "Uppskattad LSL";
            else
                slMin.Text = "LSL";
        }
        private void Initialize_Chart()
        {
            double max = (double)USL + 0.02;
            double min = (double)LSL - 0.02;
            if (min < 0)
                min = 0;
            chartData.ChartAreas[0].AxisY.Maximum = Math.Ceiling(max * 100) / 100;
            chartData.ChartAreas[0].AxisY.Minimum = Math.Floor(min * 100) / 100;

            chartData.Titles[0].Text = cb_Mått.Text;

            chartData.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.00}";

        }
       
        private void FärgläggPunkterIdiagram()
        {
            for (int i = 0; i < dt_MeasureData.Rows.Count; i++)
            {
                if (i <= 0) 
                    continue;
                Set_Color_Chart_Series(dt_MeasureData.Rows[i][0].ToString(), dt_MeasureData.Rows[i - 1][0].ToString());
                chartData.Series[0].Points[i].Color = clr;
            }
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

        private void Mått_SelectedIndexChanged(object sender, EventArgs e)
        {

            Load_Values();
            Fill_dgv();

            if (slMax.IntervalOffset > 0)
                chartData.ChartAreas[0].AxisY.StripLines.Add(slMax);
            if (slMin.IntervalOffset > 0)
                chartData.ChartAreas[0].AxisY.StripLines.Add(slMin);
        }
        private void Chart_Data_MouseMove(object sender, MouseEventArgs e)
        {
            //För med musen på diagrammet så visas vilken order samt vilket värde punkten har
           // try
            {
                HitTestResult pos = chartData.HitTest(e.X, e.Y);
                if (pos.ChartElementType == ChartElementType.DataPoint)
                    tooltip.SetToolTip(chartData, chartData.Series[0].Points[pos.PointIndex].YValues[0] + " | " + dt_MeasureData.Rows[pos.PointIndex]["OrderNr"]);
            }
            //catch {Exception exc }
            
        }
        private void DataGridView_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FärgläggPunkterIdiagram();
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
            Close();
        }
    }
}
