using System.Drawing.Drawing2D;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal sealed class CipherWheelScorePanel : Control
    {
        private int scoreValue;
        private int wrongGuessCount;
        public string TitleText { get; set; } = "Current score";
        public int ScoreValue
        {
            get => scoreValue;
            set
            {
                if (scoreValue == value)
                    return;
                scoreValue = value;
                Invalidate();
            }
        }
        public int WrongGuessCount
        {
            get => wrongGuessCount;
            set
            {
                if (wrongGuessCount == value)
                    return;
                wrongGuessCount = value;
                Invalidate();
            }
        }
        public CipherWheelScorePanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(244, 236, 214);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var panelRect = new Rectangle(0, 0, Width - 1, Height - 1);
            using var panelPath = CreateRoundedRectangle(panelRect, 24);
            using var backgroundBrush = new LinearGradientBrush(panelRect, Color.FromArgb(228, 24, 18, 12), Color.FromArgb(228, 70, 46, 22), 12f);
            using var shadowBrush = new SolidBrush(Color.FromArgb(55, 0, 0, 0));
            using var borderPen = new Pen(Color.FromArgb(210, 191, 162, 94), 2f);
            using var innerBorderPen = new Pen(Color.FromArgb(70, 255, 240, 205), 1f);
            using var titleBrush = new SolidBrush(Color.FromArgb(232, 214, 153));
            using var scoreBrush = new SolidBrush(Color.FromArgb(255, 243, 218, 154));
            using var footerBrush = new SolidBrush(Color.FromArgb(220, 226, 210, 170));
            using var titleFont = new Font("Palatino Linotype", 12f, FontStyle.Bold);
            using var scoreFont = new Font("Palatino Linotype", 25f, FontStyle.Bold);
            using var footerFont = new Font("Segoe UI", 8.6f, FontStyle.Bold);
            using var textFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.FillPath(shadowBrush, panelPath);
            g.FillPath(backgroundBrush, panelPath);
            g.DrawPath(borderPen, panelPath);
            var innerRect = Rectangle.Inflate(panelRect, -7, -7);
            using var innerPath = CreateRoundedRectangle(innerRect, 18);
            g.DrawPath(innerBorderPen, innerPath);
            g.DrawString(TitleText, titleFont, titleBrush, new Rectangle(18, 9, Width - 36, 18), textFormat);
            g.DrawString(ScoreValue.ToString(), scoreFont, scoreBrush, new Rectangle(18, 23, Width - 36, 34), textFormat);
            g.DrawString($"Wrong guesses: {WrongGuessCount}", footerFont, footerBrush, new Rectangle(18, Height - 24, Width - 36, 16), textFormat);
        }
        private static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            var diameter = radius * 2;
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}
