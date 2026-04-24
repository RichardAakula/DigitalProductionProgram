using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal sealed class CipherWheelVictoryOverlay : Control
    {
        private sealed class FireworkParticle
        {
            public PointF Position;
            public PointF Velocity;
            public float Life;
            public float MaxLife;
            public float Size;
            public Color Color;
        }
        private sealed class EggSprite
        {
            public float X;
            public float BaseY;
            public float VelocityX;
            public float Scale;
            public float Rotation;
            public float RotationVelocity;
            public float BobPhase;
        }
        private readonly List<FireworkParticle> particles = new();
        private readonly List<EggSprite> eggs = new();
        private readonly Random random = new();
        private readonly Timer timer;
        private readonly Image? eggImage;
        private readonly int scoreValue;
        private readonly Font titleFont;
        private readonly Font scoreFont;
        private readonly Font hintFont;
        private readonly StringFormat centeredFormat;
        private Bitmap? staticFrame;
        private int fireworkCooldown;
        private int eggCooldown;
        private bool isFinishing;
        public event EventHandler? CelebrationFinished;
        public CipherWheelVictoryOverlay(int score)
        {
            scoreValue = score;
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.Opaque | ControlStyles.Selectable, true);
            DoubleBuffered = true;
            BackColor = Color.FromArgb(17, 12, 20);
            Dock = DockStyle.Fill;
            Cursor = Cursors.Hand;
            TabStop = true;
            eggImage = LoadEggImage();
            titleFont = new Font("Palatino Linotype", 30f, FontStyle.Bold);
            scoreFont = new Font("Segoe UI", 16f, FontStyle.Bold);
            hintFont = new Font("Segoe UI", 11f, FontStyle.Bold);
            centeredFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            timer = new Timer { Interval = 8 };
            timer.Tick += Timer_Tick;
            MouseClick += (_, _) => Finish();
            fireworkCooldown = 0;
            eggCooldown = 0;
        }
        public void Start()
        {
            CreateOpeningVolley();
            BringToFront();
            Focus();
            timer.Start();
            Invalidate();
        }
        protected override bool IsInputKey(Keys keyData)
        {
            return keyData == Keys.Enter || keyData == Keys.Space || keyData == Keys.Escape || base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode is Keys.Enter or Keys.Space or Keys.Escape)
                Finish();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            EnsureStaticFrame();
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.Bilinear;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            if (staticFrame != null)
                g.DrawImageUnscaled(staticFrame, Point.Empty);
            DrawFireworks(g);
            DrawEggs(g);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (staticFrame != null)
            {
                staticFrame.Dispose();
                staticFrame = null;
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Stop();
                timer.Dispose();
                titleFont.Dispose();
                scoreFont.Dispose();
                hintFont.Dispose();
                centeredFormat.Dispose();
                staticFrame?.Dispose();
                eggImage?.Dispose();
            }
            base.Dispose(disposing);
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            fireworkCooldown -= timer.Interval;
            eggCooldown -= timer.Interval;
            if (fireworkCooldown <= 0)
            {
                SpawnBurst(new PointF(random.Next(140, Math.Max(141, Width - 140)), random.Next(70, Math.Max(71, Height / 2 + 40))));
                fireworkCooldown = random.Next(35, 75);
            }
            if (eggCooldown <= 0)
            {
                SpawnEgg(random.Next(0, 2) == 0);
                if (random.Next(0, 100) > 55)
                    SpawnEgg(random.Next(0, 2) == 0);
                eggCooldown = random.Next(55, 110);
            }
            UpdateParticles();
            UpdateEggs();
            Invalidate();
        }
        private void DrawBackdrop(Graphics g)
        {
            var rect = ClientRectangle;
            using var backgroundBrush = new LinearGradientBrush(rect, Color.FromArgb(235, 17, 12, 20), Color.FromArgb(225, 65, 24, 18), 90f);
            g.FillRectangle(backgroundBrush, rect);
            using var glowBrush = new SolidBrush(Color.FromArgb(40, 255, 225, 140));
            g.FillEllipse(glowBrush, Width / 2 - 280, Height / 2 - 160, 560, 320);
        }
        private void DrawFireworks(Graphics g)
        {
            foreach (var particle in particles)
            {
                var alpha = (int)(255f * (particle.Life / particle.MaxLife));
                if (alpha <= 0)
                    continue;
                using var brush = new SolidBrush(Color.FromArgb(alpha, particle.Color));
                g.FillEllipse(brush, particle.Position.X - particle.Size / 2f, particle.Position.Y - particle.Size / 2f, particle.Size, particle.Size);
            }
        }
        private void DrawEggs(Graphics g)
        {
            foreach (var egg in eggs)
            {
                var y = egg.BaseY + (float)Math.Sin(egg.BobPhase) * 16f;
                var width = 46f * egg.Scale;
                var height = 64f * egg.Scale;
                g.TranslateTransform(egg.X + width / 2f, y + height / 2f);
                g.RotateTransform(egg.Rotation);
                if (eggImage != null)
                    g.DrawImage(eggImage, -width / 2f, -height / 2f, width, height);
                else
                {
                    using var eggBrush = new SolidBrush(Color.FromArgb(240, 247, 231, 180));
                    using var eggPen = new Pen(Color.FromArgb(220, 171, 125, 62), 2f);
                    g.FillEllipse(eggBrush, -width / 2f, -height / 2f, width, height);
                    g.DrawEllipse(eggPen, -width / 2f, -height / 2f, width, height);
                }
                g.ResetTransform();
            }
        }
        private void DrawHeader(Graphics g)
        {
            var titleRect = new Rectangle(80, Height / 2 - 110, Width - 160, 86);
            var scoreRect = new Rectangle(120, Height / 2 - 6, Width - 240, 46);
            var hintRect = new Rectangle(80, Height - 94, Width - 160, 30);
            using var titleShadow = new SolidBrush(Color.FromArgb(120, 0, 0, 0));
            using var titleBrush = new SolidBrush(Color.FromArgb(255, 244, 222, 152));
            using var scoreBrush = new SolidBrush(Color.FromArgb(235, 249, 241, 224));
            using var hintBrush = new SolidBrush(Color.FromArgb(220, 224, 206, 164));
            g.DrawString("Cipher Cracked!", titleFont, titleShadow, new Rectangle(titleRect.X + 4, titleRect.Y + 5, titleRect.Width, titleRect.Height), centeredFormat);
            g.DrawString("Cipher Cracked!", titleFont, titleBrush, titleRect, centeredFormat);
            g.DrawString($"Fireworks. Flying eggs. Final score: {scoreValue}", scoreFont, scoreBrush, scoreRect, centeredFormat);
            g.DrawString("Click anywhere to return to The Cipher Wheel", hintFont, hintBrush, hintRect, centeredFormat);
        }
        private void CreateOpeningVolley()
        {
            SpawnBurst(new PointF(Width * 0.22f, Height * 0.28f));
            SpawnBurst(new PointF(Width * 0.5f, Height * 0.2f));
            SpawnBurst(new PointF(Width * 0.78f, Height * 0.32f));
            for (var i = 0; i < 8; i++)
                SpawnEgg(i % 2 == 0);
        }
        private void SpawnBurst(PointF origin)
        {
            var palette = new[]
            {
                Color.FromArgb(255, 244, 194, 94),
                Color.FromArgb(255, 255, 233, 157),
                Color.FromArgb(255, 255, 124, 95),
                Color.FromArgb(255, 186, 235, 255),
                Color.FromArgb(255, 255, 170, 215)
            };
            var count = random.Next(20, 32);
            for (var i = 0; i < count; i++)
            {
                var angle = (float)(Math.PI * 2 * i / count + random.NextDouble() * 0.22);
                var speed = 9f + (float)random.NextDouble() * 7f;
                particles.Add(new FireworkParticle
                {
                    Position = origin,
                    Velocity = new PointF((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed),
                    Life = 0.92f,
                    MaxLife = 0.92f,
                    Size = 3f + (float)random.NextDouble() * 3f,
                    Color = palette[random.Next(palette.Length)]
                });
            }
        }
        private void SpawnEgg(bool fromLeft)
        {
            eggs.Add(new EggSprite
            {
                X = fromLeft ? -90f : Width + 90f,
                BaseY = random.Next(60, Math.Max(61, Height - 180)),
                VelocityX = fromLeft ? 13f + (float)random.NextDouble() * 8f : -(13f + (float)random.NextDouble() * 8f),
                Scale = 0.8f + (float)random.NextDouble() * 0.85f,
                Rotation = random.Next(-18, 19),
                RotationVelocity = (float)(random.NextDouble() * 7.5 - 3.75),
                BobPhase = (float)(random.NextDouble() * Math.PI * 2)
            });
        }
        private void UpdateParticles()
        {
            for (var i = particles.Count - 1; i >= 0; i--)
            {
                var particle = particles[i];
                particle.Position = new PointF(particle.Position.X + particle.Velocity.X, particle.Position.Y + particle.Velocity.Y);
                particle.Velocity = new PointF(particle.Velocity.X * 0.986f, particle.Velocity.Y + 0.2f);
                particle.Life -= 0.06f;
                if (particle.Life <= 0)
                    particles.RemoveAt(i);
            }
        }
        private void UpdateEggs()
        {
            for (var i = eggs.Count - 1; i >= 0; i--)
            {
                var egg = eggs[i];
                egg.X += egg.VelocityX;
                egg.Rotation += egg.RotationVelocity;
                egg.BobPhase += 0.42f;
                if (egg.X < -140f || egg.X > Width + 140f)
                    eggs.RemoveAt(i);
            }
        }
        private void Finish()
        {
            if (isFinishing || IsDisposed)
                return;
            isFinishing = true;
            timer.Stop();
            CelebrationFinished?.Invoke(this, EventArgs.Empty);
        }
        private void EnsureStaticFrame()
        {
            if (Width <= 0 || Height <= 0 || staticFrame != null)
                return;
            staticFrame = new Bitmap(Width, Height);
            using var g = Graphics.FromImage(staticFrame);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.Clear(BackColor);
            DrawBackdrop(g);
            DrawHeader(g);
        }
        private static Image? LoadEggImage()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "EasterEgg.png");
            if (File.Exists(path) == false)
                return null;
            using var source = Image.FromFile(path);
            return new Bitmap(source);
        }
    }
}
