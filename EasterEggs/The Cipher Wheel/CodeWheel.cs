using System.Drawing.Drawing2D;
using System.Reflection;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    public partial class CodeWheel : UserControl
    {
        private readonly char[] _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private static Image? _wheelImage;
        private int _index = 0;
        private Color _highlightColor = Color.Empty;
        private Color _sealColor = Color.Empty;
        private bool _sealVisible;
        public char SelectedChar => _characters[_index];
        public CodeWheel()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            DoubleBuffered = true;
            Width = 200;
            Height = 200;
            BackColor = Color.Transparent;
            Font = new Font("Segoe UI", 28f, FontStyle.Bold);
            Cursor = Cursors.Hand;
            if (_wheelImage == null)
            {
                var assembly = Assembly.GetExecutingAssembly();
                using var stream = assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.CodeWheel.png");
                if (stream != null)
                    _wheelImage = Image.FromStream(stream);
            }
            BackgroundImage = _wheelImage;
            BackgroundImageLayout = ImageLayout.Stretch;
        }
        public void SetHighlight(Color color)
        {
            _highlightColor = Color.FromArgb(230, color.R, color.G, color.B);
            Invalidate();
        }
        public void SetSealRing(Color color)
        {
            _sealVisible = true;
            _sealColor = Color.FromArgb(230, color.R, color.G, color.B);
            Invalidate();
        }
        public void ClearSealRing()
        {
            if (_sealVisible == false && _sealColor == Color.Empty)
                return;
            _sealVisible = false;
            _sealColor = Color.Empty;
            Invalidate();
        }
        public void ResetHighlight()
        {
            if (_highlightColor == Color.Empty)
                return;
            _highlightColor = Color.Empty;
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
                return;
            Focus();
            ClearSiblingHighlights();
            StepSelection(e.Button == MouseButtons.Left ? 1 : -1);
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (e.Delta == 0)
                return;
            ClearSiblingHighlights();
            StepSelection(e.Delta > 0 ? 1 : -1);
        }
        private void ClearSiblingHighlights()
        {
            if (Parent is not { } parentControl)
                return;
            foreach (Control c in parentControl.Controls)
            {
                if (c is CodeWheel wheel)
                    wheel.ResetHighlight();
            }
        }
        private void StepSelection(int direction)
        {
            _index = (_index + direction + _characters.Length) % _characters.Length;
            Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(Color.FromArgb(20,30,40));
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(_characters[_index].ToString(), Font, brush, ClientRectangle, sf);
            if (_sealVisible && _sealColor != Color.Empty)
                DrawSealRing(g);
            if (_highlightColor != Color.Empty)
                DrawHighlightRing(g);
        }
        private void DrawSealRing(Graphics g)
        {
            var glowRect = new Rectangle(4, 4, Width - 9, Height - 9);
            using var glowPen = new Pen(Color.FromArgb(72, _sealColor.R, _sealColor.G, _sealColor.B), 16f);
            using var ringPen = new Pen(_sealColor, 7f);
            g.DrawEllipse(glowPen, glowRect);
            var ringRect = Rectangle.Inflate(glowRect, -5, -5);
            g.DrawEllipse(ringPen, ringRect);
        }
        private void DrawHighlightRing(Graphics g)
        {
            var glowRect = new Rectangle(10, 10, Width - 21, Height - 21);
            using var glowPen = new Pen(Color.FromArgb(85, _highlightColor.R, _highlightColor.G, _highlightColor.B), 12f);
            using var ringPen = new Pen(_highlightColor, 6f);
            g.DrawEllipse(glowPen, glowRect);
            var ringRect = Rectangle.Inflate(glowRect, -4, -4);
            g.DrawEllipse(ringPen, ringRect);
        }
    }
}
