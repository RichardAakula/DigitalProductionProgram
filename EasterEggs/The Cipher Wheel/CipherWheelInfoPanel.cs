using System.Drawing.Drawing2D;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal sealed class CipherWheelInfoPanel : Control
    {
        private readonly struct LayoutMetrics
        {
            public LayoutMetrics(Rectangle scoreBounds, Rectangle actionBounds, Rectangle highscoreFrameBounds, Rectangle titleBounds, Rectangle bodyBounds, Rectangle badgeBounds, Rectangle sectionBounds, int dividerY)
            {
                ScoreBounds = scoreBounds;
                ActionBounds = actionBounds;
                HighscoreFrameBounds = highscoreFrameBounds;
                TitleBounds = titleBounds;
                BodyBounds = bodyBounds;
                BadgeBounds = badgeBounds;
                SectionBounds = sectionBounds;
                DividerY = dividerY;
            }
            public Rectangle ScoreBounds { get; }
            public Rectangle ActionBounds { get; }
            public Rectangle HighscoreFrameBounds { get; }
            public Rectangle TitleBounds { get; }
            public Rectangle BodyBounds { get; }
            public Rectangle BadgeBounds { get; }
            public Rectangle SectionBounds { get; }
            public int DividerY { get; }
        }
        public string TitleText { get; set; } = string.Empty;
        public string BodyText { get; set; } = string.Empty;
        public string PrimaryBadgeText { get; set; } = string.Empty;
        public string SecondaryBadgeText { get; set; } = string.Empty;
        public string SectionTitleText { get; set; } = string.Empty;
        public Rectangle ScorePanelBounds => GetLayoutMetrics().ScoreBounds;
        public Rectangle ActionButtonBounds => GetLayoutMetrics().ActionBounds;
        public Rectangle HighscoreContentBounds => Rectangle.Inflate(GetLayoutMetrics().HighscoreFrameBounds, -14, -14);
        public CipherWheelInfoPanel()
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
            if (BackgroundImage != null)
                g.DrawImage(BackgroundImage, ClientRectangle);
            var layout = GetLayoutMetrics();
            using var panelPath = CreateRoundedRectangle(panelRect, 28);
            using var backgroundBrush = new LinearGradientBrush(panelRect, Color.FromArgb(188, 18, 14, 10), Color.FromArgb(188, 58, 41, 20), 8f);
            using var shadowBrush = new SolidBrush(Color.FromArgb(55, 0, 0, 0));
            using var borderPen = new Pen(Color.FromArgb(210, 191, 162, 94), 2f);
            using var innerBorderPen = new Pen(Color.FromArgb(70, 255, 240, 205), 1f);
            using var glazeBrush = new LinearGradientBrush(panelRect, Color.FromArgb(36, 232, 214, 153), Color.FromArgb(0, 232, 214, 153), 0f);
            var scoreDockRect = Rectangle.Inflate(layout.ScoreBounds, 9, 9);
            var highscoreFrameRect = layout.HighscoreFrameBounds;
            using var highscoreFramePath = CreateRoundedRectangle(highscoreFrameRect, 20);
            using var highscoreFrameBrush = new LinearGradientBrush(highscoreFrameRect, Color.FromArgb(168, 21, 15, 11), Color.FromArgb(182, 45, 31, 20), 90f);
            using var highscoreFrameBorderPen = new Pen(Color.FromArgb(125, 191, 162, 94), 1.6f);
            using var highscoreInnerBorderPen = new Pen(Color.FromArgb(44, 255, 240, 205), 1f);
            using var scoreDockBrush = new SolidBrush(Color.FromArgb(34, 255, 240, 205));
            using var scoreDockPen = new Pen(Color.FromArgb(60, 191, 162, 94), 1f);
            g.FillPath(shadowBrush, panelPath);
            g.FillPath(backgroundBrush, panelPath);
            g.FillPath(glazeBrush, panelPath);
            g.DrawPath(borderPen, panelPath);
            var innerRect = Rectangle.Inflate(panelRect, -8, -8);
            using var innerPath = CreateRoundedRectangle(innerRect, 22);
            g.DrawPath(innerBorderPen, innerPath);
            using var titleFont = new Font("Palatino Linotype", 19f, FontStyle.Bold);
            using var sectionFont = new Font("Palatino Linotype", 11.8f, FontStyle.Bold);
            using var bodyFont = new Font("Segoe UI", 9.9f, FontStyle.Regular);
            using var footerFont = new Font("Segoe UI", 8.8f, FontStyle.Bold);
            using var titleBrush = new SolidBrush(Color.FromArgb(232, 214, 153));
            using var bodyBrush = new SolidBrush(ForeColor);
            using var mutedBrush = new SolidBrush(Color.FromArgb(210, 226, 210, 170));
            using var dividerPen = new Pen(Color.FromArgb(120, 191, 162, 84), 1f);
            using var sectionBrush = new SolidBrush(Color.FromArgb(235, 226, 196, 130));
            using var titleFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
            using var bodyFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
            g.DrawString(TitleText, titleFont, titleBrush, layout.TitleBounds, titleFormat);
            g.DrawLine(dividerPen, 26, 50, Width - 26, 50);
            g.DrawString(BodyText, bodyFont, bodyBrush, layout.BodyBounds, bodyFormat);
            g.DrawString($"{PrimaryBadgeText}   |   {SecondaryBadgeText}", footerFont, mutedBrush, layout.BadgeBounds, new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
            g.DrawLine(dividerPen, 26, layout.DividerY, Width - 26, layout.DividerY);
            g.FillRectangle(scoreDockBrush, scoreDockRect);
            g.DrawRectangle(scoreDockPen, scoreDockRect);
            g.DrawString(SectionTitleText, sectionFont, sectionBrush, layout.SectionBounds, titleFormat);
            g.FillPath(highscoreFrameBrush, highscoreFramePath);
            g.DrawPath(highscoreFrameBorderPen, highscoreFramePath);
            var highscoreInnerRect = Rectangle.Inflate(highscoreFrameRect, -7, -7);
            using var highscoreInnerPath = CreateRoundedRectangle(highscoreInnerRect, 14);
            g.DrawPath(highscoreInnerBorderPen, highscoreInnerPath);
        }
        private LayoutMetrics GetLayoutMetrics()
        {
            var scoreWidth = Math.Min(308, Math.Max(250, Width / 5));
            var scoreBounds = new Rectangle(Width - scoreWidth - 28, 22, scoreWidth, 84);
            var bodyWidth = Math.Max(340, scoreBounds.Left - 48);
            var titleBounds = new Rectangle(26, 16, bodyWidth, 30);
            var bodyHeight = MeasureBodyHeight(bodyWidth);
            var bodyBounds = new Rectangle(28, 58, bodyWidth, bodyHeight);
            var badgeY = bodyBounds.Bottom + 8;
            var badgeBounds = new Rectangle(28, badgeY, bodyWidth, 18);
            var dividerY = badgeBounds.Bottom + 8;
            var buttonWidth = Math.Min(170, scoreBounds.Width - 30);
            var buttonHeight = 36;
            var actionBounds = new Rectangle(scoreBounds.X + ((scoreBounds.Width - buttonWidth) / 2), scoreBounds.Bottom + 14, buttonWidth, buttonHeight);
            var sectionY = Math.Max(dividerY + 10, actionBounds.Bottom + 12);
            var sectionBounds = new Rectangle(28, sectionY, Width - 56, 24);
            var highscoreFrameY = sectionBounds.Bottom + 8;
            var highscoreFrameBounds = new Rectangle(24, highscoreFrameY, Width - 48, Math.Max(86, Height - highscoreFrameY - 18));
            return new LayoutMetrics(scoreBounds, actionBounds, highscoreFrameBounds, titleBounds, bodyBounds, badgeBounds, sectionBounds, dividerY);
        }
        private int MeasureBodyHeight(int width)
        {
            using var bodyFont = new Font("Segoe UI", 9.9f, FontStyle.Regular);
            var measured = TextRenderer.MeasureText(BodyText, bodyFont, new Size(Math.Max(1, width), int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
            return Math.Max(74, measured.Height + 6);
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
