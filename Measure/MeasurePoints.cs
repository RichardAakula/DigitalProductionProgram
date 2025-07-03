using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Measure
{
    public partial class MeasurePoints : UserControl
    {
        public static CodeTextMonitor text;
        public enum CodeTextMonitor
        {
            Amount,
            BraidedOD,
            Bubbles,
            BumpID,
            BumpOD,
            Concentricity,
            ConcentricityLayer1,
            ConcentricityLayer2,
            ConcentricityLayer3,
            Curvature,
            DimA_MainBody,
            DimB_FlareOD,
            DimC_MainBody,
            ExpConcentricity,
            ExpID,
            ExpOD,
            ExpWall,
            FlareOD,
            GapOvertube,
            ID,
            Layer1OD,
            Layer2OD,
            Length,
            LengthOverall,
            LengthOvertube,
            LengthTapered,
            LengthToBump,
            MainBodyFlaredOD,
            MainBodyID,
            MainBodyLength,
            MainBodyOD,
            MainBodyOvality,
            OD,
            Ovality,
            RecConcentricity,
            RecID,
            RecID_10min,
            RecID_5min,
            RecID_Final,
            RecID_Initial,
            RecOD,
            RecWall,
            ResidualStress,
            Runout,
            RunoutLayer1,
            RunoutLayer2,
            RunoutLayer3,
            Stripes,
            TaperedFlaredOD,
            TaperedID,
            TaperedLength,
            TaperedOD,
            Wall,
            WallLayer1,
            WallLayer2,
            WallLayer3,

        }

        public static string[] CodeText
        {
            //Om ordningen på dessa ändras måste namnet på måttrutorna i Mätprotokollet ändras oxå.
            //Siffran i måttrutornas namn motsvarar index i denna array och måste vara rätt
            get
            {
                return new[]
                {
                    "Amount (per bag/spool)",   //0
                    "Braided OD",               //1
                    "Bubbles",                  //2
                    "Bump ID",                  //3
                    "Bump OD",                  //4
                    "Concentricity",            //5
                    "ConcentricityLayer1",      //6
                    "ConcentricityLayer2",      //7
                    "ConcentricityLayer3",      //8
                    "Curvature",                //9
                    "Dim A main body",          //10
                    "Dim B flare OD",           //11
                    "Dim C main body",          //12
                    "Exp Concentricity",        //13
                    "Exp ID",                   //14
                    "Exp OD",                   //15
                    "Exp Wall",                 //16
                    "Flare OD",                 //17
                    "Gap Overtube",             //18
                    "ID",                       //19
                    "Layer1OD",                 //20
                    "Layer2OD",                 //21
                    "Length",                   //22
                    "Length overall",           //23
                    "Length overtube",          //24
                    "Length tapered",           //25
                    "Length to bump",           //26
                    "Main Body Flared OD",      //27
                    "Main Body ID",             //28
                    "Main Body Length",         //29
                    "Main Body OD",             //30
                    "Main Body Ovality",        //31
                    "OD",                       //32
                    "Ovality",                  //33
                    "Rec Concentricity",        //34    
                    "Rec ID",                   //35    
                    "Rec ID 10 min",            //36
                    "Rec ID 5 min",             //37
                    "Rec ID Final",             //38
                    "Rec ID Initial",           //39
                    "Rec OD",                   //40
                    "Rec Wall",                 //41
                    "Residual Stress",          //42
                    "Runout",                   //43
                    "RunoutLayer1",             //44
                    "RunoutLayer2",             //45
                    "RunoutLayer3",             //46
                    "Stripes%",                 //47
                    "Tapered Flared OD",        //48
                    "Tapered ID",               //49
                    "Tapered Length",           //50
                    "Tapered OD",               //51
                    "Wall",                     //52
                    "WallLayer1",               //53
                    "WallLayer2",               //54
                    "WallLayer3",               //55
                };
            }
        }
        public static double? Value(CodeTextMonitor CodeName, string Description)
        {
            var col = 0;
            var codeText = CodeText[(int)CodeName];
            switch (Description)
            {
                case "USL":
                    col = 1;
                    break;
                case "UCL":
                    col = 2;
                    break;
                case "NOM":
                    col = 3;
                    break;
                case "LCL":
                    col = 4;
                    break;
                case "LSL":
                    col = 5;
                    break;
            }
            if (Monitor.Monitor.DataTable_Measurepoints is null)
                return null;
            for (var i = 0; i < Monitor.Monitor.DataTable_Measurepoints.Rows.Count; i++)
            {
                var codetextMonitor = Monitor.Monitor.DataTable_Measurepoints.Rows[i][0].ToString();
                if (codeText == Monitor.Monitor.DataTable_Measurepoints.Rows[i][0].ToString())
                {
                    double.TryParse(Monitor.Monitor.DataTable_Measurepoints.Rows[i][col].ToString(), out var value);
                    return value;
                }
            }

            return null;
        }
        public static bool IsStripesPercentOk(TextBox tb_Stripes)
        {
            if (double.TryParse(tb_Stripes.Text, out var percent))
                if (percent > 100 || percent < 0)
                {
                    InfoText.Show("Medeltjockleken för Stripes måste vara mellan 0 och 100%.", CustomColors.InfoText_Color.Bad, null);
                    tb_Stripes.Text = string.Empty;
                    return false;
                }
            return true;
        }

        public static int MeasurePointsHeight;

        public MeasurePoints()
        {
            InitializeComponent();
        }



        public void Translate_Form()
        {
            label_Measurepoints.Text = LanguageManager.GetString(label_Measurepoints.Name);
        }
        public void AddMeasurePointsMainForm()
        {
            ClearMeasurePoints();
            MeasurePointsHeight = 58;
            var dt = Monitor.Monitor.DataTable_Measurepoints;
            if (dt is null)
                return;

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var IsConcentricity = dt.Rows[i][0].ToString().Contains("Concentricity");
                Add_Label(flp_CodeName, $"{dt.Rows[i][0]}:", FontStyle.Bold, ContentAlignment.MiddleRight);
                var lsl = $"{dt.Rows[i][5]:0.000}";
                var lcl = $"{dt.Rows[i][4]:0.000}";
                var nom = $"{dt.Rows[i][3]:0.000}";
                var ucl = $"{dt.Rows[i][2]:0.000}";
                var usl = $"{dt.Rows[i][1]:0.000}";
                if (IsConcentricity && Order.WorkOperation == Manage_WorkOperation.WorkOperations.Krympslangsblåsning)
                {
                    if (double.TryParse(lsl, out var LSL))
                        lsl = $"{LSL * 100:0}";
                    if (double.TryParse(lcl, out var LCL))
                        lcl = $"{LCL * 100:0}";
                    if (double.TryParse(nom, out var NOM))
                        nom = $"{NOM * 100:0}";
                    if (double.TryParse(ucl, out var UCL))
                        ucl = $"{UCL * 100:0}";
                    if (double.TryParse(usl, out var USL))
                        usl = $"{USL * 100:0}";

                    if (LSL > 1 || LCL > 1)
                    {
                        if (Person.Name == "Richard Aakula") continue;
                        Mail.NotifyFannyHanssonWrongMeasurePoints($"ArtikelNr: {Order.PartNumber} har fel på dessa mått:<br />" +
                                                                   $"LSL = {LSL}<br />" +
                                                                   $"LCL = {LCL}<br />" +
                                                                   $"NOM = {NOM}<br />" +
                                                                   $"UCL = {UCL}<br />" +
                                                                   $"USL = {USL}");
                    }
                }
                Add_Label(flp_LSL, $"{lsl}", FontStyle.Regular, ContentAlignment.MiddleCenter);
                Add_Label(flp_LCL, $"{lcl}", FontStyle.Regular, ContentAlignment.MiddleCenter);
                Add_Label(flp_NOM, $"{nom}", FontStyle.Regular, ContentAlignment.MiddleCenter);
                Add_Label(flp_UCL, $"{ucl}", FontStyle.Regular, ContentAlignment.MiddleCenter);
                Add_Label(flp_USL, $"{usl}", FontStyle.Regular, ContentAlignment.MiddleCenter);

                MeasurePointsHeight += 20;
            }
            //MeasurePointsHeight += flp_CodeName.Height;
        }
        public void ClearMeasurePoints()
        {
            foreach (var flp in tlp_Main.Controls.OfType<FlowLayoutPanel>())
                flp.Controls.Clear();
        }
        public void Change_Theme()
        {
            BackColor = Teman.backColor_MeasurePoints;
            Teman.IterateThroughControls(flp_CodeName, Teman.foreColor_MeasurePoints);
        }

        public static void Add_Label(FlowLayoutPanel flp, string text, FontStyle fontStyle, ContentAlignment content)
        {
            var foreColor = Teman.foreColor_MeasurePoints;
            var font = new Font("Segoe UI", 9, fontStyle);
            double.TryParse(text, out var value);

            if (double.IsNaN(value) || string.IsNullOrEmpty(text))
            {
                foreColor = Color.Red;
                text = "N/A";
            }
                
            var lbl = new Label
            {
                BackColor = Color.Transparent,
                ForeColor = foreColor,
                Text = text,
                Width = flp.Width - 2,
                Height = 20,
                AutoSize = false,
                Font = font,
                Margin = new Padding(0, 0, 0, 0),
                TextAlign = content,
            };
            flp.Controls.Add(lbl);
        }
        
        

        public class Tolerances
        {
            //Om Ordern snabbladdas i utvecklarmiljö behöver Mätpunkter laddas från Monitor här
            //CodeName i Measureprotocol.Description Måste vara samma som i Monitor för att få fram rätt värde
            public static double? ActiveTolerance(string? CodeName, string Value)
            {
                if (Monitor.Monitor.DataTable_Measurepoints == null)
                    Monitor.Monitor.Load_DataTable_Measurpoints(Order.OrderNumber, Order.Operation, false);

                var dt = Monitor.Monitor.DataTable_Measurepoints;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    var CodeNameMonitor = dt.Rows[i][0].ToString();
                    if (CodeName != dt.Rows[i][0].ToString())
                        continue;
                    if (double.TryParse(dt.Rows[i][Value].ToString(), out var value) == false)
                        return null;
                    switch (CodeName)
                    {
                        case "Stripes%":
                        case "Exp Concentricity":
                        case "Rec Concentricity":
                            return value * 100;
                        
                        default:
                            return value;
                    }
                }
                return null;
            }
        }
        public class DataVerification
        {
            public static void DataVerification_Value(double value, Control ctrl)
            {
                double? usl = null;
                double? ucl = null;
                double? nom = null;
                double? lsl = null;
                double? lcl = null;

                if (ctrl is Measure_ControlManagement.InputTextBox tb)
                {
                    usl = tb.USL;
                    ucl = tb.UCL;
                    nom = tb.NOM;
                    lsl = tb.LSL;
                    lcl = tb.LCL;
                }

                ctrl.BackColor = CustomColors.Ok_Back; //Grönt = OK
                ctrl.ForeColor = CustomColors.Ok_Front; //Grönt = OK

                if (value > ucl && ucl != 0 || value < lcl)
                {
                    ctrl.BackColor = CustomColors.Warning_Back; //Orange = Varning
                    ctrl.ForeColor = CustomColors.Warning_Front; //Orange = Varning
                }

                if (value > usl && usl != 0 || value < lsl)
                {
                    ctrl.BackColor = CustomColors.Bad_Back; //Rött = Fail
                    ctrl.ForeColor = CustomColors.Bad_Front; //Rött = Fail
                }

                if (usl is null && lsl is null || string.IsNullOrEmpty(ctrl.Text)) //Inget min eller max värde finns
                {
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.Black;
                }

                if (nom > 0 && value > nom * 5) //Värdet är onormalt mkt större än Nomvärde (felskrivning)
                {
                    ctrl.BackColor = CustomColors.Neutral_Back;
                    ctrl.ForeColor = CustomColors.Neutral_Front;
                }
                
            }
            public static void DataVerification_Value_dgv(DataGridView dgv, string? text, string? codename, int row, int col)
            {
                var back = CustomColors.Ok_Back;
                var fore = CustomColors.Ok_Front;

                if (double.TryParse(text, out var value))
                {
                    var USL = Tolerances.ActiveTolerance(codename, "USL");
                    var UCL = Tolerances.ActiveTolerance(codename, "UCL");
                    var LCL = Tolerances.ActiveTolerance(codename, "LCL");
                    var LSL = Tolerances.ActiveTolerance(codename, "LSL");
                    if (value > UCL && UCL != 0 || value < LCL)
                    {
                        back = CustomColors.Warning_Back;
                        fore = CustomColors.Warning_Front;
                    }

                    if (value > USL && USL != 0 || value < LSL)
                    {
                        back = CustomColors.Bad_Back;
                        fore = CustomColors.Bad_Front;
                    }

                    dgv.Rows[row].Cells[col].Style.BackColor = back;
                    dgv.Rows[row].Cells[col].Style.ForeColor = fore;
                }

                if (ControlValidator.IsStringNA(text) == false)
                {
                    dgv.Rows[row].Cells[col].Style.BackColor = back;
                    dgv.Rows[row].Cells[col].Style.ForeColor = fore;
                }
            }
            public static void DataVerification_Walls_dgv(DataGridViewCell cell, string? codename)
            {
                if (cell.Value == null || !double.TryParse(cell.Value.ToString(), out double value))
                    return;

                var fore = Color.White;
                var back = Color.FromArgb(25,25,25);

                var text = cell.Value.ToString();
                
                var USL = Tolerances.ActiveTolerance(codename, "USL");
                var UCL = Tolerances.ActiveTolerance(codename, "UCL");
                var LCL = Tolerances.ActiveTolerance(codename, "LCL");
                var LSL = Tolerances.ActiveTolerance(codename, "LSL");

                if (value < UCL && value > LCL)
                {
                    fore = CustomColors.Ok_Front;
                    back = CustomColors.Ok_Back;
                }
                if (value > UCL && UCL != 0 || value < LCL)
                {
                    fore = CustomColors.Warning_Front;
                    back = CustomColors.Warning_Back;
                }


                if (value > USL && USL != 0 || value < LSL)
                {
                    fore = CustomColors.Bad_Front;
                    back = CustomColors.Bad_Back;
                }

                //if (value <= 0)
                //{
                //    fore = Color.FromArgb(25, 25, 25);
                //    back = Color.FromArgb(25, 25, 25);
                //}
                        

                cell.Style.ForeColor = fore;
                cell.Style.BackColor = back;
                cell.Style.SelectionBackColor = back;
                cell.Style.SelectionForeColor = fore;
            }
               
            
        }

        public static void Mätpunkter_Click(object sender, EventArgs e)
        {
            Main_Buttons.Open_MeasureProtocol();
        }
    }
}
