using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.EasterEggs
{
    public partial class EasterEgg_Code : Form
    {
        private const string GameName = "Easter Egg Code";

        readonly List<CodeWheel> wheels = new();
        public EasterEgg_Code()
        {
            InitializeComponent();
            for (int i = 0; i < 8; i++)
            {
                var wheel = new CodeWheel { Left = 100 + i * 200, Top = 100 };
                this.Controls.Add(wheel);
                wheels.Add(wheel);
            }

            if (EasterEgg_HighScore.TotalGames(GameName) == 0)
            {
                EasterEgg_HighScore.Save_Score(0,0, GameName);
                InfoText.Show("Grattis. Du har hittat ett påskägg!\n" +
                              "", CustomColors.InfoText_Color.Info, "The Cipher Wheel");
            }
        }

        private void btn_TestCode_Click(object sender, EventArgs e)
        {
            string password = string.Empty;
            foreach (var CodeWheel in wheels)
            {
                password += CodeWheel.SelectedChar;
            }


            MessageBox.Show(password);
        }
    }
}
