using System;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using System.Drawing.Drawing2D;
using AxWMPLib;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.Övrigt
{
    public partial class EasterEgg_1 : Form
    {
        private int antal_Spel { get; set; }
        private int level = 1;
        private int timer_Length = 10;
        private int level_Points = 1000;
        private int total_Points;
        private int rnd_X => rnd.Next(10, 50);

        private int rnd_Y => rnd.Next(10, panel_GameArea.Height - 10);
        private readonly Random rnd = new();
        private int GetValidStartX(int minAvailableRight)
        {
            var attempts = 0;
            while (attempts++ < 100) // max 100 försök
            {
                var candidate = rnd.Next(10, panel_GameArea.Width - 10);
                var availableRight = panel_GameArea.Width - candidate - 10;
                if (availableRight >= minAvailableRight)
                    return candidate;
            }

            // Om inget dugligt hittades, tvinga ett säkert start_x
            return Math.Max(panel_GameArea.Width - minAvailableRight - 10, 10);
        }
        private int GetValidStartY(int minAvailableHeight)
        {
            var attempts = 0;
            while (attempts++ < 100) // max 100 försök
            {
                var candidate = rnd.Next(10, panel_GameArea.Height - 10);
                var availableHeight = panel_GameArea.Height - candidate - 10;
                if (availableHeight >= minAvailableHeight)
                    return candidate;
            }

            // Om inget dugligt hittades, tvinga ett säkert start_y
            return Math.Max(panel_GameArea.Height - minAvailableHeight - 10, 10);
        }
        private int start_x;
        private int start_y;
        private int end_x;
        private int end_y;
        private int line_Thickness = 6;
        public static int Antal_Spel
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = "SELECT COUNT(*) FROM Easter_Egg_Points WHERE Namn = @namn AND CAST (Datum AS date) = @date AND Game = 'Easter Egg 1'";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                con.Open();
                var value = cmd.ExecuteScalar();
                if (value is null)
                    return 0;
                return (int)value;
            }
        }
        public static int Antal_Spelare_Som_Spelat
        {
            get
            {
                var ctr = 0;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT DISTINCT Namn FROM Easter_Egg_Points WHERE Namn <> @namn AND Game = 'Easter Egg 1'";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@namn", Person.Name);
                con.Open();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    ctr++;
                return ctr;
            }
        }
        private AxWindowsMediaPlayer mediaPlayer = null!;
        private readonly Timer? startTimer;
        private bool isFirstMove = true;
        private int mouseStartX;
        private int mouseStartY;

        public EasterEgg_1()
        {
            InitializeComponent();
            panel_GameArea.Paint += panel_GameArea_Paint!;
            startTimer = new Timer();
            startTimer.Interval = 500; // 500 ms fördröjning
            startTimer.Tick += StartTimer_Tick!;

            Load_HighScore();
            antal_Spel = Antal_Spel;
        }


        private void StartTimer_Tick(object sender, EventArgs e)
        {
            // När timern tickar, markera att det inte är första rörelsen
            isFirstMove = false;
            startTimer.Stop(); // Stoppa timern
        }

        private void panel_GameArea_Paint(object sender, PaintEventArgs e)
        {
            using var pen = new Pen(Color.Yellow, line_Thickness);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.DrawLine(pen, start_x, start_y, end_x, end_y);

            // Ritar en rektangel runt toleransområdet för debug
            //var rect = GetLineBoundingBox(start_x, start_y, end_x, end_y, line_Thickness);
            //e.Graphics.DrawRectangle(Pens.Red, rect);
        }
        private Rectangle GetLineBoundingBox(int x1, int y1, int x2, int y2, int thickness)
        {
            // Beräkna linjens lutning för att få en korrekt bounding box
            float dx = x2 - x1;
            float dy = y2 - y1;
            float lineLength = (float)Math.Sqrt(dx * dx + dy * dy);

            // Räkna ut rektangeln runt linjen baserat på dess lutning och tjocklek
            float angle = (float)Math.Atan2(dy, dx);

            // Om linjen är vertikal eller horisontell
            if (Math.Abs(dx) < 1e-5) // Vertikal linje
            {
                return new Rectangle(x1 - thickness / 2, Math.Min(y1, y2), thickness, (int)lineLength);
            }
            else if (Math.Abs(dy) < 1e-5) // Horisontell linje
            {
                return new Rectangle(Math.Min(x1, x2), y1 - thickness / 2, (int)lineLength, thickness);
            }
            else
            {
                // Om linjen är diagonal, räkna ut bounding box för den
                float offsetX = (float)(thickness / 2 * Math.Cos(angle));
                float offsetY = (float)(thickness / 2 * Math.Sin(angle));

                return new Rectangle(
                    (int)(Math.Min(x1, x2) - offsetX),
                    (int)(Math.Min(y1, y2) - offsetY),
                    (int)lineLength,
                    thickness
                );
            }
        }


        private void Add_Random_Line(int x1, int y1, int x2, int y2)
        {
            start_x = x1;
            start_y = y1;
            end_x = x2;
            end_y = y2;

            // Logga start- och slutpunkterna
            Console.WriteLine($"Nya linje-koordinater - Start_X: {start_x}, Start_Y: {start_y}, End_X: {end_x}, End_Y: {end_y}");

            panel_GameArea.Invalidate(); // Be panelen måla om (så Paint-eventet triggas)
        }
        private void lbl_Start_Game_Click(object sender, EventArgs e)
        {
           // if (mediaPlayer != null)
           //     mediaPlayer.Ctlcontrols.stop();
            level = 1;
            line_Thickness = 15;
            level_Points = 1000;
            timer_Length = 10;
            if (Person.Name == "Richard Aakula")
                timer_Length = 1000;
            total_Points = 0;

            // Slumpa första linjen
            start_x = rnd_X;
            start_y = rnd_Y;
            end_x = start_x + 200; // alltid till höger i början
            end_y = start_y;
            startTimer.Start();
            Start_Level();
        }
        private void Start_Level()
        {
            Add_Random_Line(start_x, start_y, end_x, end_y); // Använd färdiga värden
            if (level == 1)
            {
                mouseStartX = start_x + (end_x - start_x) / 30; // Lägger musen några pixlar inåt i linjen horisontellt
                mouseStartY = start_y + (end_y - start_y) / 30; // Lägger musen några pixlar inåt i linjen vertikalt
                Cursor.Position = panel_GameArea.PointToScreen(new Point(mouseStartX, mouseStartY));
            }
            

            lbl_Timer.Text = timer_Length.ToString();
            lbl_Points.Text = level_Points.ToString();
            lbl_Level.Text = level.ToString();
            lbl_Total_Poäng.Text = total_Points.ToString();

            timer.Start();
            panel_GameArea.MouseMove += panel_GameArea_MouseMove!;
        }



        private int spelCounter; // Räknar antalet spel

        private void Next_Level()
        {
            // Slumpmässiga startpositioner
            var minLength = 100;
            start_x = GetValidStartX(minLength);  // Hitta en giltig start_x som säkerställer tillräckligt med utrymme åt höger
            start_y = GetValidStartY(minLength);  // Hitta en giltig start_y som säkerställer tillräckligt med utrymme uppåt eller nedåt

            level++;
            isFirstMove = true;
            startTimer?.Start();

            // Beräkna maximal längd beroende på riktning
            var availableRight = panel_GameArea.Width - start_x - 10;
            var availableLeft = start_x - 10;
            var availableTop = start_y - 10;
            var availableBottom = panel_GameArea.Height - start_y - 10;

            var desiredLength = 200 + (level * 50);
            int length;

            // Bestäm slumpmässig riktning baserat på nivån
            var centerX = panel_GameArea.Width / 2;
            var goLeft = start_x > centerX; // Om rnd_X är större än centrumpunkten, gå vänster
            var goUp = level >= 1 && rnd.Next(0, 2) == 0;  // 50% chans att gå upp från level 10
            var goDiagonal = level >= 2 && rnd.Next(0, 2) == 0; // Diagonal från level 15

            if (goDiagonal)
            {
                dgv_Text.Rows.Add($"Diagonal - x:{start_x},{end_x}, y: {start_y}, {end_y}");
                // Beräkna längd på linjen
                length = Math.Clamp(desiredLength, 100, availableRight);
                end_x = start_x + length;

                // Kontrollera om linjen hamnar utanför panelen på Y-axeln
                int maxSlope = 90 + level * 5;
                int verticalMove = rnd.Next(0, 2) == 0 ? rnd.Next(50, maxSlope) : -rnd.Next(50, maxSlope); // Rör sig upp eller ner
                end_y = start_y + verticalMove;

                // Om end_y är utanför panelen, justera så att den stannar inom gränserna
                if (end_y < 0)
                    end_y = 0;
                if (end_y > panel_GameArea.Height)
                    end_y = panel_GameArea.Height - 1;

                // Justera musens startposition (plocka en position på linjen)
                mouseStartX = start_x + (end_x - start_x) / 30;
                mouseStartY = start_y + (end_y - start_y) / 30;
            }
            else if (goUp)
            {
                dgv_Text.Rows.Add($"Up - x:{start_x},{end_x}, y: {start_y}, {end_y}");

                // Vertikal linje – end_x är samma som start_x
                end_x = start_x;

                // Gå upp eller ner beroende på slump
                int verticalMove = rnd.Next(0, 2) == 0 ? -Math.Min(desiredLength, start_y - 10)
                    : Math.Min(desiredLength, panel_GameArea.Height - start_y - 10);
                end_y = start_y + verticalMove;

                // Justera musens startposition någonstans längs linjen
                mouseStartX = start_x;
                mouseStartY = start_y + (end_y - start_y) / 30;
            }
            else if (goLeft)
            {
                dgv_Text.Rows.Add($"Left - x:{start_x},{end_x}, y: {start_y}, {end_y}");
                length = Math.Clamp(desiredLength, minLength, availableLeft);
                end_x = start_x - length;
                end_y = start_y;

                // Justera musens startposition (plocka en position på linjen)
                mouseStartX = start_x - (length / 30);
                mouseStartY = start_y;
            }
            else
            {
                dgv_Text.Rows.Add($"Right - x:{start_x},{end_x}, y: {start_y}, {end_y}");
                length = Math.Clamp(desiredLength, minLength, availableRight);
                end_x = start_x + length;
                end_y = start_y;

                // Justera musens startposition (plocka en position på linjen)
                mouseStartX = start_x + (end_x - start_x) / 30;
                mouseStartY = start_y;
            }

            // Uppdatera musens position till startpositionen
            Cursor.Position = panel_GameArea.PointToScreen(new Point(mouseStartX, mouseStartY));
            dgv_Text.FirstDisplayedScrollingRowIndex = dgv_Text.Rows.Count - 1;

            // Minska linjetjocklek vart tredje spel
            spelCounter++;
            if (spelCounter % 3 == 0 && line_Thickness > 1)
                line_Thickness--;

            // Poäng och tid
            level_Points += 200;
            if (level % 2 == 0 && timer_Length > 5)
                timer_Length--;
            if (timer_Length < 5)
                timer_Length = 5;
            Start_Level();
        }





        private async void Game_Over(string text)
        {
            panel_GameArea.MouseMove -= panel_GameArea_MouseMove!;
            timer.Stop();
            MessageBox.Show(text);

            if (total_Points > 0)
            {
                Save_Score();
                antal_Spel++;
            }
            Load_HighScore();
            MessageBox.Show($@"Du fick {total_Points} poäng.");
            Reset_Values();

            if (antal_Spel == 2)
            {
                InfoText.Show("Du har nu spelat max antal spel/dag.", CustomColors.InfoText_Color.Info, "Warning!", this);
                Close();
            }
            await PlayVideoOnGameOverAsync();

        }
        private Task PlayVideoOnGameOverAsync()
        {
            // Skapa och konfigurera Windows Media Player-kontrollen
            var tcs = new TaskCompletionSource<object>();
            mediaPlayer = new AxWindowsMediaPlayer();
            panel_GameArea.MouseClick += MediaPlayerOnClick;

            mediaPlayer.BeginInit();
            mediaPlayer.Location = new Point(0, 0); // Placera videon på panelen
            mediaPlayer.Size = panel_GameArea.Size;  // Sätt storleken på panelen
            mediaPlayer.Parent = panel_GameArea;     // Lägg till i panelen
            mediaPlayer.EndInit();

            // Ange videofilens sökväg
            var videoPath = Path.Combine(Application.StartupPath, "Resources", "LinusPåLinjen.mp4");

            mediaPlayer.URL = videoPath;
            mediaPlayer.uiMode = "none";  // Dölj kontroller som play, pause, osv.

            // Lyssna efter när videon är klar
            mediaPlayer.PlayStateChange += MediaPlayer_PlayStateChange;
            return tcs.Task;
        }



        private void MediaPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 1)  // 1 betyder att videon har stannat (slut)
            {
                mediaPlayer.close();
                panel_GameArea.Controls.Remove(mediaPlayer); // Ta bort mediaPlayer från panelen
                if (antal_Spel == 2)
                {
                    InfoText.Show("Du har nu spelat max antal spel/dag.", CustomColors.InfoText_Color.Info, "Warning!", this);
                    Close();
                }
            }
        }
        private void MediaPlayerOnClick(object? sender, EventArgs e)
        {
            mediaPlayer.Ctlcontrols.stop();
        }
        private void Goal()
        {
            timer.Stop();
            panel_GameArea.MouseMove -= panel_GameArea_MouseMove!;

            MessageBox.Show("Grattis Du klarade banan");
            int.TryParse(lbl_Points.Text, out var points);
            total_Points += points;
            lbl_Total_Poäng.Text = total_Points.ToString();

            MessageBox.Show("Klicka för nästa bana.");
            Next_Level();
        }

        private void Save_Score()
        {
            if (Person.Name == "Richard Aakula")
                return;
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "INSERT INTO Easter_Egg_Points VALUES(@game, @namn, @datum, @level, @points)";
            var cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@namn", Person.Name);
            cmd.Parameters.AddWithValue("@datum", DateTime.Now);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@points", total_Points);
            cmd.Parameters.AddWithValue("@game", "Easter Egg 1");

            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void Load_HighScore()
        {
            var dt = new DataTable();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = "SELECT TOP(10) Namn, Datum, Level, Points FROM Easter_Egg_Points WHERE Game = 'Easter Egg 1' ORDER BY Points DESC";
            var cmd = new SqlCommand(query, con);
            con.Open();
            dt.Load(cmd.ExecuteReader());

            dgv_HighScore.DataSource = dt;
            dgv_HighScore.Columns["Namn"].Width = 120;
            dgv_HighScore.Columns["Level"].Width = 50;
            dgv_HighScore.Columns["Points"].Width = 50;
        }
        private void Reset_Values()
        {
            level = 1;
            timer_Length = 10;
            level_Points = 1000;
            total_Points = 0;

            lbl_Level.Text = level.ToString();
            lbl_Timer.Text = timer_Length.ToString();
            lbl_Points.Text = level_Points.ToString();
            lbl_Total_Poäng.Text = total_Points.ToString();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer_Length--;
            level_Points -= 100;
            lbl_Timer.Text = $"{timer_Length} s";
            lbl_Points.Text = level_Points.ToString();

            if (timer_Length == 0)
                Game_Over("GAME OVER!\nTiden är slut!.");
        }
        private static bool IsMouseInsideAllowedArea(int mouseX, int mouseY, int x1, int y1, int x2, int y2, int tolerance)
        {
            // Beräkna närmaste avstånd från musens punkt till linjen (Pythagoras via projektion)
            double dx = x2 - x1;
            double dy = y2 - y1;

            if (dx == 0 && dy == 0)
            {
                // Linjen är en punkt
                var dist = Math.Sqrt(Math.Pow(mouseX - x1, 2) + Math.Pow(mouseY - y1, 2));
                return dist <= tolerance;
            }

            // Projektion av musens punkt på linjen (normaliserat t mellan 0 och 1)
            var t = ((mouseX - x1) * dx + (mouseY - y1) * dy) / (dx * dx + dy * dy);
            t = Math.Max(0, Math.Min(1, t));

            // Närmaste punkt på linjen
            var closestX = x1 + t * dx;
            var closestY = y1 + t * dy;

            // Avstånd mellan muspekaren och närmaste punkt
            var distance = Math.Sqrt(Math.Pow(mouseX - closestX, 2) + Math.Pow(mouseY - closestY, 2));

            return distance <= tolerance;
        }

        private void panel_GameArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (isFirstMove)
                return;

            if (!IsMouseInsideAllowedArea(e.X, e.Y, start_x, start_y, end_x, end_y, line_Thickness))
            {
                Game_Over($"GAME OVER!\nDu körde utanför linjen.");
            }
            else
            {
                level_Points++;
                lbl_Points.Text = level_Points.ToString();
            }

            // Kontrollera om målet har nåtts
            int goalTolerance = 15; // Öka toleransen för att målet ska räknas
            if (Math.Abs(e.X - end_x) <= goalTolerance && Math.Abs(e.Y - end_y) <= goalTolerance)
            {
                Goal();
            }
        }

        private void lbl_Avsluta_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
