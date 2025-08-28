using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.ControlsManagement
{
    internal class ControlValidator
    {
        [DebuggerStepThrough]
        public static bool IsStringNA(string? text)
        {
            switch (text)
            {
                case "n/a":
                case "na":
                case "NA":
                case "na/":
                case "NA/":
                case "/nA":
                case "/NA":
                case "nA":
                case "n/A":
                case "N/a":
                case "N/A":
                case "N A":
                case "n a":
                case "n A":
                case "N a":
                    return true;
                default:
                    return false;
            }
        }
        public static async void SoftBlink(Control? ctrl, Color c1, Color c2, short blink_Frequence = 300, int time = 70)
        {
            var startColor = ctrl.BackColor;
            var sw = new Stopwatch();
            sw.Start();
            var halfCycle = (short)Math.Round(blink_Frequence * 0.5);

            for (var i = 0; i < time; i++)
            {
                await Task.Delay(1);
                var n = sw.ElapsedMilliseconds % blink_Frequence;
                var per = (double)Math.Abs(n - halfCycle) / halfCycle;
                var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
                var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
                var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
                var clr = Color.FromArgb(red, grn, blw);

                ctrl.BackColor = clr;
            }

            ctrl.BackColor = startColor;
            ctrl.Focus();
        }
        public static string Next_Letter(string revNr, bool isAscending)
        {
            var characters = revNr.ToCharArray();
            var incrementValue = isAscending ? 1 : -1;

            for (var i = characters.Length - 1; i >= 0; i--)
            {
                characters[i] += (char)incrementValue;

                if (characters[i] < 'A')
                    characters[i] = 'Z';
                else if (characters[i] > 'Z')
                {
                    characters[i] = 'A';

                    // If the left neighbor doesn't exist, prepend 'A'
                    if (i == 0)
                        return "A" + new string(characters);
                }
                else
                    break;
            }

            return new string(characters);
        }
    }
}
