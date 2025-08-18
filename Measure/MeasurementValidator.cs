using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.PrintingServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DigitalProductionProgram.Measure.MeasurePoints;

namespace DigitalProductionProgram.Measure
{
    internal class MeasurementValidator
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
                string test;
                if (codename == "Runout" && value == 0.010)
                    test = "Peter";
                if (value >= UCL && UCL != 0 || value <= LCL)
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
            var back = Color.FromArgb(25, 25, 25);

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
}
