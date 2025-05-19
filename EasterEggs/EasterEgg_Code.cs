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
                InfoText.Show("Congratulations. You've discovered a hidden Easter Egg!\n" +
                              "Before you lies a mysterious cipher lock.\n" +
                              "Unlock it, and you shall win the game.\n" +
                              "But beware...\n" +
                              "Each failed attempt chips away at your score.\n" +
                              "Clues are scattered—hidden in the shadows of the program,\n" +
                              "waiting for the observant and the bold.\n" +
                              " -Maximum score: 5000\n" +
                              " -Each incorrect guess costs you 100 points\n\n" +
                              "Can you crack the code before your chances run out?\n" +
                              "Let the cipher challenge begin.", CustomColors.InfoText_Color.Info, "The Cipher Wheel");
            }
        }

        private void btn_TestCode_Click(object sender, EventArgs e)
        {
            string enteredPassword = string.Concat(wheels.Select(w => w.SelectedChar));
            string Password = "BENNY123";

            for (int i = 0; i < wheels.Count; i++)
            {
                char selected = wheels[i].SelectedChar;
                char correct = Password[i];

                if (selected == correct)
                    wheels[i].SetHighlight(Color.FromArgb(50, 198,239,206)); // Rätt plats, rätt bokstav
                else if (Password.Contains(selected))
                    wheels[i].SetHighlight(Color.FromArgb(50, 255,235,156)); // Fel plats, men rätt bokstav
                else
                    wheels[i].SetHighlight(Color.FromArgb(50,255,199,206)); // Fel bokstav helt
            }

            // Om hela lösenordet är rätt:
            if (enteredPassword == Password)
            {
                MessageBox.Show("You cracked the code! 🏆");
                // Här kan du avsluta spelet
            }

            InfoText.Show("Oooops sorry! there goes another 100 points.", CustomColors.InfoText_Color.Bad, "Sorry", this);
            EasterEgg_HighScore.Save_Score(0,0, GameName);


        }
    }
}
