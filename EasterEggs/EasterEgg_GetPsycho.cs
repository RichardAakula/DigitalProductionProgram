

using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.EasterEggs
{
    public partial class EasterEgg_GetPsycho : Form
    {
        private readonly Timer _timer;

        // ==== Hastighets- och beteende-parametrar ====
        private const int HueStep = 2;               // hur många Hue-steg per tick (snabbare tonbyte)
        private const int SaturationStep = 2;        // hur mycket S minskar per Hue-varv
        private const int VStepPerHueCycle = 1;      // hur mycket V ökar vid varje Hue-varv
        private const int ExtraVStepEveryMs = 50;    // extra V++ var X ms (snabbar ljushet oberoende av H/S)
        private const int StartV = 10;               // startljus
        private const int MaxV = 255;                // max ljushet

        // Textfade (långsam – justera)
        private const int AlphaStepInterval = 500;    // öka alfa 1 steg var 50:e tick (långsam fade)

        // ==== Tillstånd ====
        private int _h = 0;               // 0..359
        private int _s = 255;             // 255..0
        private int _v = StartV;          // 64..255
        private bool _paused = false;

        private int _alphaTickCounter = 0;
        private int _elapsedTickCounter = 0;  // för extra V++ var X ms

        private int _textAlpha = 0;           // 0..255

        private string _centerText = "Click Space when you see this!";
        private Font _centerFont;

        public EasterEgg_GetPsycho()
        {
            this.Text = "Full RGB – snabbare loop + långsam textfade";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);

            _centerFont = new Font("Segoe UI", 64, FontStyle.Bold, GraphicsUnit.Point);

            _timer = new Timer { Interval = 1 }; // försöker 1 ms; målas ~60–100 Hz i praktiken
            _timer.Tick += Timer_Tick;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (_paused) return;

            // ==== Hue-stegring (snabbare tonbyte) ====
            _h += HueStep;
            if (_h >= 360)
            {
                // hur många varv passerade (om steg är stort kan det bli >1)
                int varv = _h / 360;
                _h = _h % 360;

                // Minska mättnad per varv
                _s -= SaturationStep * varv;
                if (_s < 0) _s = 0;

                // Öka ljushet vid varje Hue-varv
                _v += VStepPerHueCycle * varv;

                // När mättnaden nått 0, börja om och öka V (primär V-ökning vid S-cykel)
                if (_s == 0)
                {
                    _s = 255;
                    _v++;
                }
            }

            // ==== Extra V++ var X ms för ännu snabbare ljushet ====
            _elapsedTickCounter++;
            if (_elapsedTickCounter >= ExtraVStepEveryMs)
            {
                _elapsedTickCounter = 0;
                _v++;
            }

            // Clamp V
            if (_v > MaxV)
            {
                _v = MaxV;
                _timer.Stop();
                this.Text = "Klar: V=255, loop slutförd i snabb-läge.";
            }

            // ==== Långsam textfade ====
            _alphaTickCounter++;
            if (_alphaTickCounter >= AlphaStepInterval)
            {
                _alphaTickCounter = 0;
                if (_textAlpha < 255) _textAlpha++; // öka långsamt
            }

            // ==== Sätt bakgrundsfärgen ====
            var color = HsvToRgb(_h, _s, _v);
            this.BackColor = color;

            this.Invalidate();
            this.Text = $"H:{_h} S:{_s} V:{_v} | RGB({color.R},{color.G},{color.B}) | alpha:{_textAlpha}";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            using var fmt = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Dynamisk textfärg för läsbarhet
            double luminance = 0.2126 * BackColor.R + 0.7152 * BackColor.G + 0.0722 * BackColor.B;
            bool useBlack = luminance > 180;

            var baseTextColor = useBlack ? Color.Black : Color.White;
            var textColor = Color.FromArgb(_textAlpha, baseTextColor);
            using var brush = new SolidBrush(textColor);

            // Skugga bakom texten
            var shadowColor = Color.FromArgb(_textAlpha, 0, 0, 0);
            using var shadowBrush = new SolidBrush(shadowColor);

            var rect = this.ClientRectangle;
            int shadowOffset = 3;

            g.DrawString(_centerText, _centerFont, shadowBrush,
                new RectangleF(rect.X + shadowOffset, rect.Y + shadowOffset, rect.Width, rect.Height), fmt);

            g.DrawString(_centerText, _centerFont, brush,
                new RectangleF(rect.X, rect.Y, rect.Width, rect.Height), fmt);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            var minDim = Math.Min(this.ClientSize.Width, this.ClientSize.Height);
            var targetSize = Math.Max(24, minDim / 10);
            _centerFont?.Dispose();
            _centerFont = new Font("Segoe UI", targetSize, FontStyle.Bold, GraphicsUnit.Point);
            this.Invalidate();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timer.Stop();
            _centerFont?.Dispose();
            base.OnFormClosed(e);
        }

        // Snabbkommandon:
        // ESC: stoppa
        // SPACE: pausa/fortsätt
        // Ctrl+Shift+T: toggla TopMost
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                _timer.Stop();
                this.Text = "Avbrutet (ESC)";
                return true;
            }
            if (keyData == Keys.Space)
            {
                _paused = !_paused;
                this.Text = _paused ? "Paus" : "Fortsätter";
                return true;
            }
            if (keyData == (Keys.Control | Keys.Shift | Keys.T))
            {
                this.TopMost = !this.TopMost;
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// HSV -> RGB. Hue: 0..359, Saturation: 0..255, Value: 0..255.
        /// </summary>
        private static Color HsvToRgb(int hue, int sat, int val)
        {
            if (sat <= 0)
                return Color.FromArgb(val, val, val); // gråskala

            double h = (hue % 360) / 60.0; // 0..6
            double s = sat / 255.0;
            double v = val / 255.0;

            int i = (int)Math.Floor(h);
            double f = h - i;
            double p = v * (1 - s);
            double q = v * (1 - s * f);
            double t = v * (1 - s * (1 - f));

            double r = 0, g = 0, b = 0;
            switch (i)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                case 5: r = v; g = p; b = q; break;
            }

            int R = Clamp255((int)Math.Round(r * 255));
            int G = Clamp255((int)Math.Round(g * 255));
            int B = Clamp255((int)Math.Round(b * 255));
            return Color.FromArgb(R, G, B);
        }

        private static int Clamp255(int x) => x < 0 ? 0 : (x > 255 ? 255 : x);
    }
}
