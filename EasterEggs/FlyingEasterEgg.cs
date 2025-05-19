using DigitalProductionProgram.MainWindow;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.EasterEggs
{
    public class FlyingEasterEgg
    {
        private readonly Form form;
        private readonly DoubleBufferedPanel panel;
        private readonly System.Windows.Forms.Timer timer;
        private readonly Bitmap image;
        private Point position;
        private readonly Random rand = new();
        private readonly Stopwatch stopwatch = new Stopwatch();
        private bool isZoomed = false;

        private int level = 1;
        private int speed;
        private int verticalSpeed;
        private int verticalDirection;
        private int totalScore;
        private readonly List<MissedClick> missedClicks = new();

        public event Action<int, int>? OnLevelCompleted; // (level, poäng för nivån)
        public event Action<int>? OnGameFinished;        // (total poäng)

        public class DoubleBufferedPanel : Panel
        {
            public DoubleBufferedPanel()
            {
                this.DoubleBuffered = true;
                this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                this.UpdateStyles();
                this.BackColor = Color.Transparent;
                this.Dock = DockStyle.Fill;
            }
            protected override void OnPaintBackground(PaintEventArgs e)
            {
                // Rensa bakgrund med formens bakgrundsfärg, så att transparent funkar som förväntat
                e.Graphics.Clear(this.Parent?.BackColor ?? Color.White);
            }
        }

        public FlyingEasterEgg(Form targetForm)
        {
            form = targetForm;

            panel = new DoubleBufferedPanel();
            form.Controls.Add(panel);
            panel.BringToFront();
            panel.Paint += OverlayPanel_Paint;
            panel.MouseClick += Egg_MouseClick;

            //var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "NewIcon.png");
            //using var original = new Bitmap(imagePath);
            //image = new Bitmap(original, new Size(40, 70)); // Skala ner
            image = new Bitmap(Properties.Resources.NewIcon, new Size(40, 70)); // Skala ner

            //StartLevel(level);
            timer = new System.Windows.Forms.Timer { Interval = 40 }; // 60 FPS ~16 ms
            timer.Tick += Timer_Tick;
            //timer.Start();
            StartLevel(level);
        }

        public void StartGame()
        {
            this.OnLevelCompleted += (Level, points) =>
            {
                // Visa poäng på egen Label, logga eller annat
                if (isZoomed)
                {
                    MessageBox.Show(@"Holy EggLord, thats a BullsEye! 5000 extra points");
                    isZoomed = false; // Återställ zoom
                }
                MessageBox.Show($@"Level {level} done! Points: {points}");
            };
            this.OnGameFinished += TotalScore =>
            {
                //if (TotalClicksForLevel > 5)
                  //  MessageBox.Show(@"Whoop whoop, easy with the clicks! The egg is destroyed!");

                EasterEgg_HighScore.Save_Score(level, TotalScore, "Flying Easter Egg");
                var dgv = ShowHighScore();
                MessageBox.Show($@"Game Over! Total points: {TotalScore}");
                form.Controls.Remove(dgv);
                dgv.Dispose();

            };
        }

        private void StartLevel(int lvl)
        {
            timer.Start();
            level = lvl;
            speed = 3 + level; // öka horisontell hastighet med level
            verticalSpeed = 1 + level; // öka vertikal rörelse
            verticalDirection = rand.Next(0, 2) == 0 ? -1 : 1;

            position = new Point(-image.Width, rand.Next(0, Math.Max(1, form.ClientSize.Height - image.Height)));
            TotalClicksForLevel = 0;
            stopwatch.Restart();
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            // Ändra horisontell hastighet lite slumpmässigt, men håll inom rimligt spann
            speed += rand.Next(-1, 2);
            speed = Math.Clamp(speed, 3 + level, 7 + level);

            // Uppdatera position X
            position.X += speed;

            // Vertikal "acceleration" för mjukare rörelse
            if (rand.Next(0, 10) > 7)
            {
                // Slumpmässig acceleration
                verticalDirection = rand.Next(0, 2) == 0 ? -1 : 1;
                verticalSpeed = rand.Next(1, 3 + level);
            }

            position.Y += verticalDirection * verticalSpeed;
            // Begränsa position inom fönstret och vänd riktning om vi går för långt
            if (position.Y < 0)
            {
                position.Y = 0;
                verticalDirection = 1;
            }
            

            else if (position.Y > panel.ClientSize.Height - image.Height)
            {
                position.Y = panel.ClientSize.Height - image.Height;
                verticalDirection = -1;
            }

            if (position.X > panel.ClientSize.Width)
            {
                Stop();
                return;
            }

            panel.Invalidate();
            missedClicks.RemoveAll(m => (DateTime.Now - m.Timestamp).TotalMilliseconds > 2000);
        }

        private int TotalClicksForLevel;
        private async void Egg_MouseClick(object? sender, MouseEventArgs e)
        {
            if (TotalClicksForLevel > 4)
            {
                MessageBox.Show(@"Whoop whoop, easy with the clicks! The egg is destroyed!");
                Stop();
                return;
            }

            // Kolla om klicket är inom äggets rektangel
            var localPoint = e.Location;
            var eggRect = new Rectangle(position, image.Size);
            //Console.WriteLine($"Click at: {localPoint}, Egg pos: {position}, Egg rect: {eggRect}");
            
            if (eggRect.Contains(localPoint))
            {
                // Kolla pixelns alfa-värde (transparens)
                var x = localPoint.X - position.X;
                var y = localPoint.Y - position.Y;

                if (x >= 0 && y >= 0 && x < image.Width && y < image.Height)
                {
                    var pixelColor = image.GetPixel(x, y);
                    //Console.WriteLine($"Pixel Alpha: {pixelColor.A} at ({x},{y})");
                    if (pixelColor.A > 5) // pixeln är inte genomskinlig (justera tröskel om du vill)
                    {
                        stopwatch.Stop();
                        var reactionTimeMs = (int)stopwatch.ElapsedMilliseconds;
                        var points = Math.Max(5000 - reactionTimeMs, 100);
                        var eggCenter = new Point(image.Width / 2, image.Height / 2);
                        double distance = Math.Sqrt(Math.Pow(x - eggCenter.X, 2) + Math.Pow(y - eggCenter.Y, 2));

                        if (distance <= 10) // Bullseye-radie i pixlar
                        {
                            points += 5000;
                            isZoomed = true;
                            panel.Invalidate(); // Återrita för att visa zoomad bild
                            await Task.Delay(10); // Vänta en stund för att visa effekten
                        }

                        totalScore += points;
                        timer.Stop();
                        OnLevelCompleted?.Invoke(level, points);

                        StartLevel(level + 1);
                        return;
                    }
                   
                }
            }
            
            MissedEgg();
        }

        private void MissedEgg()
        {
            TotalClicksForLevel++;

            if (panel.PointToClient(Cursor.Position) is Point missPos)
            {
                missedClicks.Add(new MissedClick(missPos));
                panel.Invalidate(new Rectangle(missPos.X - 6, missPos.Y - 6, 12, 12)); // extra yta för säkerhets skull
            }
        }
        private void OverlayPanel_Paint(object? sender, PaintEventArgs e)
        {
            if (isZoomed)
            {
                int zoomFactor = 4;
                var zoomedSize = new Size(image.Width * zoomFactor, image.Height * zoomFactor);
                var zoomedPos = new Point(position.X - (zoomedSize.Width - image.Width) / 2,
                    position.Y - (zoomedSize.Height - image.Height) / 2);
                e.Graphics.DrawImage(image, new Rectangle(zoomedPos, zoomedSize));
            }
            else
                e.Graphics.DrawImage(image, position);


            foreach (var miss in missedClicks)
            {
                int alpha = miss.Alpha;
                if (alpha > 0)
                {
                    using var brush = new SolidBrush(Color.FromArgb(alpha, Color.Red));
                    e.Graphics.FillEllipse(brush, miss.Position.X - 5, miss.Position.Y - 5, 10, 10);
                }
            }
        }

        public void Stop()
        {
            timer.Stop();
            timer.Tick -= Timer_Tick;
            panel.Paint -= OverlayPanel_Paint;
            form.Controls.Remove(panel);
            panel.Dispose();
            image.Dispose();
            OnGameFinished?.Invoke(totalScore);
        }

        private DataGridView ShowHighScore()
        {
            var dgv = new DataGridView
            {
                Name = "dgv_Highscore",
                Width = 400,
                Height = 250,
                Location = new Point(300, 300), // Justera position
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                BackgroundColor = Color.Black,
                RowHeadersVisible = false,
                ForeColor = Color.Gray,
                ColumnHeadersDefaultCellStyle = { BackColor = Color.DarkBlue, ForeColor = Color.White },
                EnableHeadersVisualStyles = false
            };

            // Ladda poängen
            var table = EasterEgg_HighScore.LoadHighscores("Flying Easter Egg");
            dgv.DataSource = table;

            // Lägg till i formuläret (Main_Form)
            form.Controls.Add(dgv);
            dgv.BringToFront();
            return dgv;
        }

        
        private class MissedClick
        {
            public Point Position { get; }
            public DateTime Timestamp { get; }

            public MissedClick(Point position)
            {
                Position = position;
                Timestamp = DateTime.Now;
            }

            private int AgeMs => (int)(DateTime.Now - Timestamp).TotalMilliseconds;
            public int Alpha => Math.Max(0, 255 - (AgeMs * 255 / 1000)); // Fade ut på 1000 ms
        }
    }

}
