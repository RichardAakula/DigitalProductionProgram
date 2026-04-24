using System.Drawing.Drawing2D;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal sealed class CipherWheelActionButton : Button
    {
        private bool isHovered;
        private bool isPressed;
        public CipherWheelActionButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            BackColor = Color.Transparent;
            ForeColor = Color.FromArgb(243, 228, 176);
            Font = new Font("Palatino Linotype", 11.4f, FontStyle.Bold);
            Text = "Test Code";
            UpdateButtonRegion();
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            var drawRect = isPressed ? Rectangle.Inflate(rect, -1, -1) : rect;
            var topColor = isHovered ? Color.FromArgb(224, 66, 47, 30) : Color.FromArgb(214, 52, 38, 24);
            var bottomColor = isHovered ? Color.FromArgb(232, 28, 20, 15) : Color.FromArgb(224, 20, 15, 11);
            var ornamentColor = isHovered ? Color.FromArgb(238, 225, 194, 122) : Color.FromArgb(214, 196, 165, 98);
            var borderColor = isHovered ? Color.FromArgb(235, 226, 193, 128) : Color.FromArgb(198, 176, 145, 92);
            using var shadowPath = CreateTabletPath(new Rectangle(drawRect.X, drawRect.Y + 2, drawRect.Width, Math.Max(1, drawRect.Height - 2)), 10);
            using var shadowBrush = new SolidBrush(Color.FromArgb(70, 0, 0, 0));
            using var path = CreateTabletPath(drawRect, 10);
            using var fillBrush = new LinearGradientBrush(drawRect, topColor, bottomColor, 90f);
            using var borderPen = new Pen(borderColor, 1.6f);
            using var innerPen = new Pen(Color.FromArgb(70, 255, 235, 195), 1f);
            using var runePen = new Pen(ornamentColor, 1.2f);
            using var ornamentBrush = new SolidBrush(ornamentColor);
            using var highlightBrush = new SolidBrush(Color.FromArgb(isHovered ? 40 : 24, 255, 243, 207));
            using var textBrush = new SolidBrush(ForeColor);
            using var textShadowBrush = new SolidBrush(Color.FromArgb(82, 10, 7, 4));
            using var format = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.FillPath(shadowBrush, shadowPath);
            g.FillPath(fillBrush, path);
            g.DrawPath(borderPen, path);
            using var innerPath = CreateTabletPath(Rectangle.Inflate(drawRect, -4, -4), 7);
            g.DrawPath(innerPen, innerPath);
            g.FillRectangle(highlightBrush, new Rectangle(drawRect.X + 8, drawRect.Y + 4, Math.Max(1, drawRect.Width - 16), Math.Max(1, (drawRect.Height / 2) - 5)));
            DrawOrnament(g, new Point(drawRect.X + 18, drawRect.Y + (drawRect.Height / 2)), ornamentBrush, runePen);
            DrawOrnament(g, new Point(drawRect.Right - 18, drawRect.Y + (drawRect.Height / 2)), ornamentBrush, runePen);
            var textRect = Rectangle.Inflate(drawRect, -26, -3);
            var shadowRect = new Rectangle(textRect.X + 1, textRect.Y + 1, textRect.Width, textRect.Height);
            g.DrawString(Text, Font, textShadowBrush, shadowRect, format);
            g.DrawString(Text, Font, textBrush, textRect, format);
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            UpdateButtonRegion();
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            isHovered = true;
            Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isHovered = false;
            isPressed = false;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (mevent.Button != MouseButtons.Left)
                return;
            isPressed = true;
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            isPressed = false;
            Invalidate();
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            Invalidate();
        }
        private void UpdateButtonRegion()
        {
            if (Width <= 0 || Height <= 0)
                return;
            using var path = CreateTabletPath(new Rectangle(0, 0, Width - 1, Height - 1), 10);
            Region?.Dispose();
            Region = new Region(path);
        }
        private static void DrawOrnament(Graphics g, Point center, Brush brush, Pen pen)
        {
            var diamond = new[]
            {
                new Point(center.X, center.Y - 4),
                new Point(center.X + 4, center.Y),
                new Point(center.X, center.Y + 4),
                new Point(center.X - 4, center.Y)
            };
            g.FillPolygon(brush, diamond);
            g.DrawPolygon(pen, diamond);
            g.DrawLine(pen, center.X - 6, center.Y, center.X + 6, center.Y);
        }
        private static GraphicsPath CreateTabletPath(Rectangle rect, int chamfer)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddLine(rect.X + chamfer, rect.Y, rect.Right - chamfer, rect.Y);
            path.AddLine(rect.Right - chamfer, rect.Y, rect.Right, rect.Y + chamfer);
            path.AddLine(rect.Right, rect.Y + chamfer, rect.Right, rect.Bottom - chamfer);
            path.AddLine(rect.Right, rect.Bottom - chamfer, rect.Right - chamfer, rect.Bottom);
            path.AddLine(rect.Right - chamfer, rect.Bottom, rect.X + chamfer, rect.Bottom);
            path.AddLine(rect.X + chamfer, rect.Bottom, rect.X, rect.Bottom - chamfer);
            path.AddLine(rect.X, rect.Bottom - chamfer, rect.X, rect.Y + chamfer);
            path.AddLine(rect.X, rect.Y + chamfer, rect.X + chamfer, rect.Y);
            path.CloseFigure();
            return path;
        }
    }
}
