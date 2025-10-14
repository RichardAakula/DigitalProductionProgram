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
        private DataTable MätData = new DataTable();
        private readonly ToolTip tooltip = new ToolTip();
        private readonly StripLine slMax = new StripLine();
        private readonly StripLine slMin = new StripLine();
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
                        return AVG + 0.1;
                    case 2:  //Blåst W
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "USL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "USL");
                        clr_slMax = Color.Orange;
                        return AVG + 0.03;
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
                        return AVG + 0.02;
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
                        return AVG - 0.1;
                    case 2:  //Blåst W
                        if (MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "LSL") > 0)
                            return MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ExpWall, "LSL");
                        clr_slMin = Color.Orange;
                        return (AVG - 0.03);
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
        private double? MIN
        {
            get
            {
                try
                {
                    double? min = (double?)MätData.Compute($"min({cb_Mått.Text})", string.Empty);
                    return min;
                }
                catch { return null; }
            }
        }
        private double? MAX
        {
            get
            {
                try
                {
                    double? max = (double?)MätData.Compute($"max({cb_Mått.Text})", string.Empty);
                    return max;
                }
                catch { return null; }
                
            }
        }
        private double? AVG
        {
            get
            {
                try
                {
                    double? avg = (double?)MätData.Compute($"avg({cb_Mått.Text})", string.Empty);
                    return avg;
                }
                catch
                {
                    return null;
                }
            }
        }
          
        private DataTable LoadMätData()
        {
            MätData.Clear();
            string query = @" SELECT CodeName, Value, TextValue, BoolValue, DateValue, Date, Discarded, ErrorCode, AnstNr, Sign, ColumnIndex, Decimals, data.RowIndex, Type
                    FROM MeasureProtocol.Data as data
	                    JOIN MeasureProtocol.Description as description
		                    ON data.DescriptionId = description.ID
	                    JOIN MeasureProtocol.Template as template
		                    ON data.DescriptionId = template.DescriptionID
	                    JOIN MeasureProtocol.MainData as main
		                    ON data.RowIndex = main.RowIndex AND data.OrderID = main.OrderID";
            if (cB_visaAllaOrdrar.Checked)
                query += @"
                    WHERE EXISTS (SELECT * FROM [Order].MainData 
                        WHERE korprotokoll.PartID = @partid
                            AND data.OrderID = korprotokoll.OrderID AND Discarded = 'False') 
                            ORDER BY data.OrderID, Påse_Spole";
            else
                query += @"
                            WHERE data.OrderID = @orderid AND FormTemplateID = @formtemplateid
                        AND template.Revision = (SELECT MeasureprotocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid)
                        AND Discarded = 'False'
                    ORDER BY RowIndex, ColumnIndex";

            using (SqlConnection con = new SqlConnection(Database.cs_Protocol))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@formtemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);

                MätData.Load(cmd.ExecuteReader());
                return MätData;
            }
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
                Opacity = Opacity + 0.004f;
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
            MätData = LoadMätData();
            if (MätData.Rows.Count < 1)
                return;

            Initialize_SPC_Data();
            chartData.Series[0].Points.Clear();
            Initialize_Chart();
            Initialize_Striplines();

            if (string.IsNullOrEmpty(cb_Mått.Text))
                return;
            for (int i = 0; i < MätData.Rows.Count; i++)
            {
                    string str_value = MätData.Rows[i][cb_Mått.Text].ToString().Replace('.', ',');
                    if (double.TryParse(str_value, out double value))
                        chartData.Series[0].Points.Add(value);
            }

            FärgläggPunkterIdiagram();
           
        }
        private void Initialize_SPC_Data()
        {
            lbl_USL.Text = $"{USL:0.000}";
            lbl_Max.Text = $"{MAX:0.000}";
            lbl_Avg.Text = $"{AVG:0.000}";
            lbl_Min.Text = $"{MIN:0.000}";
            lbl_LSL.Text = $"{LSL:0.000}";
            try
            {
                lbl_HiLo.Text = $"{MAX - MIN:0.000}";
            }
            catch { lbl_HiLo.Text = "N/A"; }

            var list_double = new List<double?>();
            for (int i = 0; i < MätData.Rows.Count; i++)
            {
                double.TryParse(MätData.Rows[i][cb_Mått.Text].ToString(), out var value);
                //double? value = double.Parse(MätData.Rows[i][cb_Mått.Text].ToString());
                list_double.Add(value);
            }
            lbl_Cp.Text = $"{Calculate.Cp(list_double, USL, LSL)}";
            lbl_Cpk.Text = $"{Calculate.Cpk(list_double, USL, LSL)}";
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
            for (int i = 0; i < MätData.Rows.Count; i++)
            {
                if (i <= 0) 
                    continue;
                Set_Color_Chart_Series(MätData.Rows[i][0].ToString(), MätData.Rows[i - 1][0].ToString());
                chartData.Series[0].Points[i].Color = clr;
            }
        }
        private void Fill_dgv()
        {
            List<string> values = new List<string>();
            dgv_OrderList.Rows.Clear();
            for (int i = 0; i < MätData.Rows.Count; i++)
            {
                if (!values.Contains($"{MätData.Rows[i]["OrderNr"]}"))
                    values.Add($"{MätData.Rows[i]["OrderNr"]}");
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
                    tooltip.SetToolTip(chartData, chartData.Series[0].Points[pos.PointIndex].YValues[0] + " | " + MätData.Rows[pos.PointIndex]["OrderNr"]);
            }
            //catch {Exception exc }
            
        }
        private void DataGridView_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FärgläggPunkterIdiagram();
            int i = 0;
            foreach (DataPoint dp in chartData.Series[0].Points)
            {
                if (MätData.Rows[i][1].ToString() + MätData.Rows[i][2] == dgv_OrderList.CurrentCell.Value.ToString())
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
