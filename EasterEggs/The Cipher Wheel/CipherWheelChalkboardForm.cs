using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal sealed class CipherWheelChalkboardForm : Form
    {
        private const int MinimumPointCount = 10;
        private const float MinimumStrokeSize = 40f;
        private readonly List<PointF> strokePoints = new();
        private readonly Timer fadeTimer = new();
        private bool isDrawing;
        private bool isSolved;
        private float strokeOpacity = 1f;
        public event EventHandler? GlyphSolved;
        public CipherWheelChalkboardForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(760, 520);
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            TopMost = true;
            BackColor = Color.FromArgb(16, 10, 6);
            KeyPreview = true;
            fadeTimer.Interval = 34;
            fadeTimer.Tick += FadeTimer_Tick;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Focus();
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.Escape)
                Close();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (isSolved)
            {
                Close();
                return;
            }
            if (e.Button != MouseButtons.Left || GetBoardBounds().Contains(e.Location) == false)
                return;
            fadeTimer.Stop();
            strokePoints.Clear();
            strokeOpacity = 1f;
            strokePoints.Add(ClampToBoard(e.Location));
            isDrawing = true;
            Capture = true;
            Invalidate();
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (isDrawing == false || isSolved)
                return;
            strokePoints.Add(ClampToBoard(e.Location));
            Invalidate();
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (isDrawing == false)
                return;
            isDrawing = false;
            Capture = false;
            if (IsAcceptedStroke(strokePoints))
            {
                isSolved = true;
                strokePoints.Clear();
                Invalidate();
                GlyphSolved?.Invoke(this, EventArgs.Empty);
                return;
            }
            if (strokePoints.Count < 2)
            {
                strokePoints.Clear();
                Invalidate();
                return;
            }
            fadeTimer.Stop();
            fadeTimer.Start();
        }
        private void FadeTimer_Tick(object? sender, EventArgs e)
        {
            strokeOpacity -= 0.12f;
            if (strokeOpacity > 0f)
            {
                Invalidate();
                return;
            }
            fadeTimer.Stop();
            strokeOpacity = 1f;
            strokePoints.Clear();
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.Clear(BackColor);
            using var outerBrush = new SolidBrush(Color.FromArgb(6, 81, 87));
            using var frameBrush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(63, 115, 140), Color.FromArgb(184, 220, 231), 90f);
            using var framePen = new Pen(Color.FromArgb(160, 116, 68, 28), 3f);
            g.FillRectangle(outerBrush, ClientRectangle);
            var frameRect = new Rectangle(32, 28, ClientSize.Width - 64, ClientSize.Height - 56);
            g.FillRectangle(frameBrush, frameRect);
            g.DrawRectangle(framePen, frameRect);
            var boardRect = GetBoardBounds();
            using var boardBrush = new LinearGradientBrush(boardRect, Color.FromArgb(18, 46, 39), Color.FromArgb(11, 29, 24), 90f);
            using var boardPen = new Pen(Color.FromArgb(160, 205, 193, 148), 2f);
            g.FillRectangle(boardBrush, boardRect);
            g.DrawRectangle(boardPen, boardRect);
            DrawChalkDust(g, boardRect);
            using var titleFont = new Font("Palatino Linotype", 20f, FontStyle.Bold);
            using var subtitleFont = new Font("Segoe UI", 10.5f, FontStyle.Italic);
            using var titleBrush = new SolidBrush(Color.FromArgb(230, 227, 212, 179));
            using var subtitleBrush = new SolidBrush(Color.FromArgb(188, 228, 236, 224));
            using var subtitleFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
            g.DrawString("The Silent Slate", titleFont, titleBrush, new RectangleF(52, 34, 400, 34));
            if (isSolved == false)
                g.DrawString("Trace one deliberate glyph upon the slate.\nA true mark shall burn in gold. A false hand fades to dust.", subtitleFont, subtitleBrush, new RectangleF(54, 68, 520, 40), subtitleFormat);
            DrawStroke(g);
            if (isSolved)
                DrawGoldenGlyph(g, boardRect);
        }
        private void DrawChalkDust(Graphics g, Rectangle boardRect)
        {
            using var dustBrush = new SolidBrush(Color.FromArgb(14, 255, 255, 255));
            for (var i = 0; i < 40; i++)
            {
                var x = boardRect.Left + 22 + (i * 31 % Math.Max(80, boardRect.Width - 44));
                var y = boardRect.Top + 18 + (i * 47 % Math.Max(60, boardRect.Height - 36));
                g.FillEllipse(dustBrush, x, y, 3, 3);
            }
        }
        private void DrawStroke(Graphics g)
        {
            if (strokePoints.Count < 2)
                return;
            var alpha = Math.Clamp((int)(strokeOpacity * 255f), 0, 255);
            using var glowPen = new Pen(Color.FromArgb((int)(alpha * 0.22f), 239, 228, 177), 14f);
            glowPen.StartCap = LineCap.Round;
            glowPen.EndCap = LineCap.Round;
            glowPen.LineJoin = LineJoin.Round;
            using var chalkPen = new Pen(Color.FromArgb(alpha, 239, 228, 177), 7.5f)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };
            g.DrawLines(glowPen, strokePoints.ToArray());
            g.DrawLines(chalkPen, strokePoints.ToArray());
        }
        private void DrawGoldenGlyph(Graphics g, Rectangle boardRect)
        {
            using var path = new GraphicsPath();
            using var fontFamily = new FontFamily("Palatino Linotype");
            path.AddString("G", fontFamily, (int)FontStyle.Bold, 170f, new Point(boardRect.Left + 210, boardRect.Top + 70), StringFormat.GenericDefault);
            using var glowPen = new Pen(Color.FromArgb(72, 255, 223, 119), 18f) { LineJoin = LineJoin.Round };
            using var fillBrush = new LinearGradientBrush(boardRect, Color.FromArgb(255, 246, 214, 109), Color.FromArgb(255, 186, 133, 28), 90f);
            using var outlinePen = new Pen(Color.FromArgb(255, 124, 83, 17), 3f) { LineJoin = LineJoin.Round };
            g.DrawPath(glowPen, path);
            g.FillPath(fillBrush, path);
            g.DrawPath(outlinePen, path);
        }
        private Rectangle GetBoardBounds()
        {
            return new Rectangle(56, 110, ClientSize.Width - 112, ClientSize.Height - 154);
        }
        private PointF ClampToBoard(Point point)
        {
            var boardRect = GetBoardBounds();
            var x = Math.Clamp(point.X, boardRect.Left + 6, boardRect.Right - 6);
            var y = Math.Clamp(point.Y, boardRect.Top + 6, boardRect.Bottom - 6);
            return new PointF(x, y);
        }
        private static bool IsAcceptedStroke(IReadOnlyList<PointF> points)
        {
            var filteredPoints = FilterPoints(points);
            if (filteredPoints.Count < MinimumPointCount)
                return false;
            return LooksLikeGStroke(filteredPoints);
        }
        private static bool LooksLikeGStroke(IReadOnlyList<PointF> points)
        {
            var box = BoundingBox(points);
            if (box.Width < MinimumStrokeSize || box.Height < MinimumStrokeSize)
                return false;
            var aspectRatio = box.Width / Math.Max(1f, box.Height);
            if (aspectRatio < 0.45f || aspectRatio > 1.55f)
                return false;
            var hasTopArc = false;
            var hasLeftArc = false;
            var hasBottomArc = false;
            var hasUpperRightArc = false;
            var hasEndpointInBarZone = IsBarZone(NormalizePoint(points[0], box)) || IsBarZone(NormalizePoint(points[^1], box));
            for (var i = 0; i < points.Count; i++)
            {
                var point = NormalizePoint(points[i], box);
                hasTopArc |= point.Y <= 0.22f && point.X >= 0.18f && point.X <= 0.84f;
                hasLeftArc |= point.X <= 0.22f && point.Y >= 0.16f && point.Y <= 0.84f;
                hasBottomArc |= point.Y >= 0.78f && point.X >= 0.18f && point.X <= 0.86f;
                hasUpperRightArc |= point.X >= 0.72f && point.Y <= 0.42f;
            }
            if (hasTopArc == false || hasLeftArc == false || hasBottomArc == false || hasUpperRightArc == false || hasEndpointInBarZone == false)
                return false;
            var hasBar = false;
            for (var i = 3; i < points.Count; i++)
            {
                var start = NormalizePoint(points[i - 3], box);
                var end = NormalizePoint(points[i], box);
                var midX = (start.X + end.X) * 0.5f;
                var midY = (start.Y + end.Y) * 0.5f;
                if (midX < 0.46f || midX > 0.92f || midY < 0.34f || midY > 0.70f)
                    continue;
                if (Math.Abs(end.X - start.X) >= 0.14f && Math.Abs(end.Y - start.Y) <= 0.12f)
                {
                    hasBar = true;
                    break;
                }
            }
            if (hasBar == false)
                return false;
            var rightMidPoints = 0;
            for (var i = 0; i < points.Count; i++)
            {
                var point = NormalizePoint(points[i], box);
                if (point.X >= 0.80f && point.Y >= 0.42f && point.Y <= 0.68f)
                    rightMidPoints++;
            }
            return rightMidPoints <= Math.Max(5, points.Count / 3);
        }
        private static bool IsBarZone(PointF point)
        {
            return point.X >= 0.46f && point.Y >= 0.34f && point.Y <= 0.70f;
        }
        private static PointF NormalizePoint(PointF point, RectangleF box)
        {
            var width = Math.Max(1f, box.Width);
            var height = Math.Max(1f, box.Height);
            return new PointF((point.X - box.Left) / width, (point.Y - box.Top) / height);
        }
        private static List<PointF> FilterPoints(IReadOnlyList<PointF> rawPoints)
        {
            var filtered = new List<PointF>();
            PointF? lastPoint = null;
            for (var i = 0; i < rawPoints.Count; i++)
            {
                var point = rawPoints[i];
                if (lastPoint.HasValue && Distance(lastPoint.Value, point) < 5f)
                    continue;
                filtered.Add(point);
                lastPoint = point;
            }
            return filtered;
        }
        private static RectangleF BoundingBox(IReadOnlyList<PointF> points)
        {
            var minX = float.MaxValue;
            var minY = float.MaxValue;
            var maxX = float.MinValue;
            var maxY = float.MinValue;
            for (var i = 0; i < points.Count; i++)
            {
                minX = Math.Min(minX, points[i].X);
                minY = Math.Min(minY, points[i].Y);
                maxX = Math.Max(maxX, points[i].X);
                maxY = Math.Max(maxY, points[i].Y);
            }
            return RectangleF.FromLTRB(minX, minY, maxX, maxY);
        }
        private static float Distance(PointF pointA, PointF pointB)
        {
            var dx = pointB.X - pointA.X;
            var dy = pointB.Y - pointA.Y;
            return MathF.Sqrt(dx * dx + dy * dy);
        }
    }
}
