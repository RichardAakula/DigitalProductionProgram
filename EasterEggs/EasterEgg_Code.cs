using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.EasterEggs
{
    public partial class EasterEgg_Code : Form
    {

        static int clickCount = 0;
        static DateTime firstClickTime;


        private const string GameName = "The Cipher Wheel";
        private readonly List<CodeWheel> wheels = new();
        
           


        private static bool? isGameStarted;
        public static bool IsGameStarted
        {
            get
            {
                if (isGameStarted.HasValue)
                    return isGameStarted.Value;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @name AND Game = @game";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@name", Person.Name);
                cmd.Parameters.AddWithValue("@game", GameName);

                con.Open();
                var count = (int)cmd.ExecuteScalar();
                isGameStarted = count > 0;
                return isGameStarted.Value;
            }
        }
        
        
        public EasterEgg_Code()
        {
            InitializeComponent();

            isGameStarted = true;
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


        public class Level_1
        {
            public static string Riddle_1 =>
                "This riddle holds the key, the first mark you’ll feel,\n" +
                "The opening symbol on The Cipher Wheel.\n\n" +
                "I am the start of hope, and the start of home.\n" +
                "In the alphabet’s heart, I stand first alone. \n" +
                "Without me, questions wander lost and awry—\n" +
                "What letter am I? Come on, give it a try.";
        }

        public class Level_2
        {
            private static int Attempts
            {
                get
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @name AND Game = @game AND Level = 2";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", Person.Name);
                    cmd.Parameters.AddWithValue("@game", GameName);

                    con.Open();
                    var count = (int)cmd.ExecuteScalar();
                    return count;
                }
            }
            public static readonly string[] crypticErrorMessages = new[]
            {
                "The rhythm slipped through the cracks of time — the dance must fall within the fleeting moments.",
                "A shadow of discord lingers — the cadence only reveals itself in perfect timing.",
                "Echoes fall silent when the beat is lost; remember, the secret pulses only in precise intervals.",
                "The sequence falters in the void of haste or delay — align your touch to the narrow window.",
                "A whisper missed the call of time’s delicate balance; the key lies in striking the moment just right.",
                "Between beats, the secret fades — your rhythm must dance within the briefest seconds.",
                "The pulse resists the hands that hurry or linger — only the timed touch unlocks the path.",
                "Remember! Not too fast, Not too slow."
            };

            public static void KnockKnock(Control parent, Point clickLocation)
            {
                if (isGameStarted == false)
                    return;
                if (clickCount == 0)
                {
                    firstClickTime = DateTime.Now;
                    ShowKnockTip(parent);
                }

                clickCount++;
                var elapsed = (DateTime.Now - firstClickTime).TotalSeconds;

                if (elapsed > 6)
                {
                    InfoText.Show(
                        $"You struck {clickCount} times in {elapsed:F2} heartbeats,\n" +
                        "yet the secret rhythm remains elusive.\n" +
                        "Only the one who knocks the right number of times\n" +
                        "between four and six heartbeats shall uncover the second symbol of The Cipher Wheel.",
                        CustomColors.InfoText_Color.Bad, "The Cipher Wheel", parent);

                    EasterEgg_HighScore.Save_Score(2,0, GameName);
                    clickCount = 0;
                    return;
                }

                if (elapsed is >= 4 and <= 6)
                {
                    if (clickCount == 4)
                        InfoText.Show(
                            $"A hidden path reveals itself...\n" +
                            $"You have unlocked the *second* symbol of The Cipher Wheel.\n\n" +
                            $"It took you {Attempts} attempt{(Attempts > 1 ? "s" : "")} to find the right rhythm.\n" +
                            $"But beware — only those who remember the number of knocks shall find their way.",
                            CustomColors.InfoText_Color.Ok,
                            "The Cipher Wheel",
                            parent, true);

                    else
                    {
                        var rnd = new Random();
                        var msg = crypticErrorMessages[rnd.Next(crypticErrorMessages.Length)];
                        var info = $"{clickCount} knocks in {elapsed:F2} heartbeats.";

                        InfoText.Show($"{msg}\n\n{info}\n" +
                                      $"Only the one who knocks the right number of times\n" +
                                      $"between four and six heartbeats shall uncover the second symbol of The Cipher Wheel.",
                            CustomColors.InfoText_Color.Bad, "The Cipher Wheel", parent);
                        clickCount = 0;
                    }
                }
            }

            public static void ShowKnockTip(Control parent)
            {
                // Visa subtil ledtråd
                var cursorPos = Cursor.Position;
                var tipLocation = parent.PointToClient(cursorPos);
                var toolTip = new ToolTip();
                toolTip.OwnerDraw = true; // Gör att du kan rita själv
                toolTip.Draw += (sender, e) =>
                {
                    e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);
                    using var f = new Font("Segoe UI", 10, FontStyle.Bold);
                    e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, e.Bounds);
                };
                toolTip.Popup += (sender, e) =>
                {
                    e.ToolTipSize = TextRenderer.MeasureText(toolTip.GetToolTip(e.AssociatedControl), new Font("Segoe UI", 10, FontStyle.Bold));
                };

                toolTip.Show("Knock knock...", parent, tipLocation, 2000);
            }
        }
        

        private void btn_TestCode_Click(object sender, EventArgs e)
        {
            InfoText.Question(
                "Are you sure you wish to test the code?\n" +
                "Such haste might come at a cost...",
                CustomColors.InfoText_Color.Warning,
                "Proceed with the trial?",
                Form: this);
            if (InfoText.answer == InfoText.Answer.No)
                return;
            var enteredPassword = string.Concat(wheels.Select(w => w.SelectedChar));
            const string Password = "H4PPYE6G";

            for (var i = 0; i < wheels.Count; i++)
            {
                var selected = wheels[i].SelectedChar;
                var correct = Password[i];

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
