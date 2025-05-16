using System;
using System.Collections.Generic;
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


        private int level = 1;
        private int speed;
        private int verticalSpeed;
        private int verticalDirection;
        private int totalScore;

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
            panel.MouseClick += Panel_MouseClick;

            var imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "EasterEgg.png");
            using var original = new Bitmap(imagePath);
            image = new Bitmap(original, new Size(50, 50)); // Skala ner

            StartLevel(level);

            timer = new System.Windows.Forms.Timer { Interval = 40 }; // 60 FPS ~16 ms
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void StartGame()
        {
            this.OnLevelCompleted += (level, points) =>
            {
                // Visa poäng på egen Label, logga eller annat
                MessageBox.Show($"Level {level} klar! Poäng: {points}");
            };
            this.OnGameFinished += TotalScore =>
            {
                if (TotalClicksForLevel > 10)
                    MessageBox.Show("Du missade ägget fler än tio gånger = GAME OVER!!!!");

                MessageBox.Show($"Spelet slut! Total poäng: {TotalScore}");
            };
        }

        private void StartLevel(int lvl)
        {
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
            else if (position.Y > form.ClientSize.Height - image.Height)
            {
                position.Y = form.ClientSize.Height - image.Height;
                verticalDirection = -1;
            }

            if (position.X > form.ClientSize.Width)
            {
                Stop();
                return;
            }

            panel.Invalidate();
        }

        private int TotalClicksForLevel;
        private void Panel_MouseClick(object? sender, MouseEventArgs e)
        {
            // Kolla om klicket är inom äggets rektangel
            var localPoint = e.Location;
            var eggRect = new Rectangle(position, image.Size);
            if (TotalClicksForLevel > 10)
            {
                Stop();
            }
            if (eggRect.Contains(localPoint))
            {
                // Kolla pixelns alfa-värde (transparens)
                var x = localPoint.X - position.X;
                var y = localPoint.Y - position.Y;

                if (x >= 0 && y >= 0 && x < image.Width && y < image.Height)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    if (pixelColor.A > 20) // pixeln är inte genomskinlig (justera tröskel om du vill)
                    {
                        stopwatch.Stop();
                        int reactionTimeMs = (int)stopwatch.ElapsedMilliseconds;

                        // Räkna poäng: snabbare klick = högre poäng
                        int points = Math.Max(10000 - reactionTimeMs, 100);
                        totalScore += points;

                        OnLevelCompleted?.Invoke(level, points);

                        StartLevel(level + 1);
                    }
                    else
                        MissedEgg();
                }
            }
            else
                MissedEgg();
        }

        private void MissedEgg()
        {
            TotalClicksForLevel++;
        }
        private void OverlayPanel_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, position);
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
    }

}
