using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Övrigt
{
    internal class Public_Events
    {
        public static void Only_Decimal_KeyPress(object? sender, KeyPressEventArgs e)
        {
            var decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != decimalSeparator)
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && (e.KeyChar == decimalSeparator) && ((TextBox)sender).Text.IndexOf(decimalSeparator) > -1)
            {
                e.Handled = true;
            }
        }
        public static void Enter_To_TAB_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                    SendKeys.Send("{TAB}");
            }
        }
        public static void Control_MouseDoubleClick(object? sender, MouseEventArgs e)
        {
            var ctrl = (Control)sender;
            ctrl.Text = "N/A";
            ctrl.ForeColor = Color.Red;
        }

        public static void ctrl_NA_DoubleClick(object sender, EventArgs e)
        {
                var ctrl = (Control)sender;
                ctrl.Text = "N/A";
        }
        public static void pb_Info_LineClearance_Click(object sender, EventArgs e)
        {
            InfoText.Show(LanguageManager.GetString("lineClearance_Info_3"), CustomColors.InfoText_Color.Info, null);
        }
       
    }
}
