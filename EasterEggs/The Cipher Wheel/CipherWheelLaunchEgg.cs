using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal sealed class CipherWheelLaunchEgg : IDisposable
    {
        private const float EggOpacity = 0.44f;
        private const byte AlphaHitThreshold = 18;
        private sealed class LaunchEggOverlayForm : Form
        {
            private const int WsExToolWindow = 0x80;
            private const int WsExNoActivate = 0x08000000;
            public LaunchEggOverlayForm()
            {
                FormBorderStyle = FormBorderStyle.None;
                ShowInTaskbar = false;
                StartPosition = FormStartPosition.Manual;
                TopMost = true;
                BackColor = Color.Magenta;
                TransparencyKey = Color.Magenta;
                BackgroundImageLayout = ImageLayout.Stretch;
            }
            protected override bool ShowWithoutActivation => true;
            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    cp.ExStyle |= WsExToolWindow;
                    cp.ExStyle |= WsExNoActivate;
                    return cp;
                }
            }
        }
        private sealed class ClickBlockerMessageFilter : IMessageFilter
        {
            private readonly Form hostForm;
            private readonly Form eggForm;
            public ClickBlockerMessageFilter(Form hostForm, Form eggForm)
            {
                this.hostForm = hostForm;
                this.eggForm = eggForm;
            }
            public bool PreFilterMessage(ref Message m)
            {
                if (!IsBlockedMouseMessage(m.Msg) || hostForm.IsDisposed || eggForm.IsDisposed)
                    return false;
                var target = Control.FromHandle(m.HWnd);
                if (target is not null && IsControlInside(eggForm, target))
                    return false;
                if (!hostForm.Bounds.Contains(Cursor.Position))
                    return false;
                if (target is null)
                    return true;
                return IsControlInside(hostForm, target);
            }
            private static bool IsBlockedMouseMessage(int message)
            {
                return message is
                    0x0201 or 0x0202 or 0x0203 or
                    0x0204 or 0x0205 or 0x0206 or
                    0x0207 or 0x0208 or 0x0209 or
                    0x020A or 0x020B or 0x020C or
                    0x020E or
                    0x00A1 or 0x00A2 or 0x00A3 or
                    0x00A4 or 0x00A5 or 0x00A6 or
                    0x00A7 or 0x00A8 or 0x00A9;
            }
            private static bool IsControlInside(Control parent, Control control)
            {
                for (var current = control; current is not null; current = current.Parent)
                {
                    if (ReferenceEquals(current, parent))
                        return true;
                }
                return false;
            }
        }
        private readonly Form hostForm;
        private readonly Action onCaught;
        private readonly Action onFinished;
        private readonly LaunchEggOverlayForm overlayForm;
        private readonly Timer animationTimer;
        private readonly ClickBlockerMessageFilter clickBlocker;
        private readonly Bitmap sourceEggImage;
        private readonly Random random = new();
        private Bitmap? renderedEggImage;
        private float eggX;
        private float eggY;
        private float eggBaseY;
        private float eggWidth;
        private float eggHeight;
        private float eggVelocity;
        private float eggWavePhase;
        private bool isDisposed;
        public CipherWheelLaunchEgg(Form hostForm, Action onCaught, Action onFinished)
        {
            this.hostForm = hostForm;
            this.onCaught = onCaught;
            this.onFinished = onFinished;
            sourceEggImage = LoadEggImage();
            overlayForm = new LaunchEggOverlayForm();
            overlayForm.MouseDown += OverlayForm_MouseDown;
            overlayForm.MouseMove += OverlayForm_MouseMove;
            clickBlocker = new ClickBlockerMessageFilter(hostForm, overlayForm);
            animationTimer = new Timer { Interval = 16 };
            animationTimer.Tick += AnimationTimer_Tick;
            hostForm.Resize += HostForm_BoundsChanged;
            hostForm.Move += HostForm_BoundsChanged;
            hostForm.VisibleChanged += HostForm_VisibleChanged;
            Application.AddMessageFilter(clickBlocker);
            StartFlight();
        }
        private static Bitmap LoadEggImage()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var eggPath = Path.Combine(basePath, "Resources", "EasterEgg.png");
            if (!File.Exists(eggPath))
                eggPath = Path.Combine(basePath, "Resources", "NewIcon.png");
            using var original = new Bitmap(eggPath);
            return new Bitmap(original);
        }
        private void StartFlight()
        {
            if (hostForm.ClientSize.Width <= 0 || hostForm.ClientSize.Height <= 0)
            {
                Finish(false);
                return;
            }
            eggHeight = Math.Clamp(hostForm.ClientSize.Height * 0.068f, 38f, 58f);
            eggWidth = eggHeight * (sourceEggImage.Width / (float)Math.Max(1, sourceEggImage.Height));
            eggBaseY = GetEggBaseY();
            eggVelocity = Math.Max(11f, hostForm.ClientSize.Width / 125f);
            eggWavePhase = (float)(random.NextDouble() * Math.PI * 2);
            eggX = -eggWidth - 24f;
            eggY = eggBaseY;
            BuildRenderedEggImage();
            UpdateOverlayPosition();
            overlayForm.Show(hostForm);
            overlayForm.BringToFront();
            animationTimer.Start();
        }
        private float GetEggBaseY()
        {
            var minY = Math.Max(85f, hostForm.ClientSize.Height * 0.15f);
            var maxY = Math.Max(minY + 20f, hostForm.ClientSize.Height * 0.54f);
            return minY + (float)random.NextDouble() * (maxY - minY);
        }
        private void BuildRenderedEggImage()
        {
            var newWidth = Math.Max(1, (int)Math.Ceiling(eggWidth));
            var newHeight = Math.Max(1, (int)Math.Ceiling(eggHeight));
            var bitmap = new Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb);
            using (var graphics = Graphics.FromImage(bitmap))
            using (var imageAttributes = new ImageAttributes())
            {
                graphics.Clear(Color.Transparent);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                var colorMatrix = new ColorMatrix
                {
                    Matrix33 = EggOpacity
                };
                imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                graphics.DrawImage(sourceEggImage, new Rectangle(0, 0, newWidth, newHeight), 0, 0, sourceEggImage.Width, sourceEggImage.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            var previousRenderedImage = renderedEggImage;
            var oldRegion = overlayForm.Region;
            overlayForm.BackgroundImage = bitmap;
            renderedEggImage = bitmap;
            overlayForm.ClientSize = bitmap.Size;
            overlayForm.Region = CreateAlphaRegion(bitmap);
            previousRenderedImage?.Dispose();
            oldRegion?.Dispose();
        }
        private static Region CreateAlphaRegion(Bitmap bitmap)
        {
            using var path = new GraphicsPath();
            for (var y = 0; y < bitmap.Height; y++)
            {
                var startX = -1;
                for (var x = 0; x < bitmap.Width; x++)
                {
                    var isOpaque = bitmap.GetPixel(x, y).A > AlphaHitThreshold;
                    if (isOpaque && startX == -1)
                        startX = x;
                    if (isOpaque || startX == -1)
                        continue;
                    path.AddRectangle(new Rectangle(startX, y, x - startX, 1));
                    startX = -1;
                }
                if (startX != -1)
                    path.AddRectangle(new Rectangle(startX, y, bitmap.Width - startX, 1));
            }
            if (path.PointCount == 0)
                path.AddRectangle(new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            return new Region(path);
        }
        private void HostForm_BoundsChanged(object? sender, EventArgs e)
        {
            if (isDisposed)
                return;
            if (hostForm.ClientSize.Width <= 0 || hostForm.ClientSize.Height <= 0)
            {
                Finish(false);
                return;
            }
            UpdateOverlayPosition();
        }
        private void HostForm_VisibleChanged(object? sender, EventArgs e)
        {
            if (isDisposed)
                return;
            if (!hostForm.Visible)
                Finish(false);
        }
        private void AnimationTimer_Tick(object? sender, EventArgs e)
        {
            if (isDisposed || hostForm.IsDisposed || !hostForm.Visible)
                return;
            eggWavePhase += 0.14f;
            eggX += eggVelocity;
            eggY = eggBaseY + ((float)Math.Sin(eggWavePhase) * 16f);
            UpdateOverlayPosition();
            overlayForm.Cursor = IsEggHit(overlayForm.PointToClient(Cursor.Position)) ? Cursors.Hand : Cursors.Default;
            if (eggX > hostForm.ClientSize.Width + 32f)
                Finish(false);
        }
        private void UpdateOverlayPosition()
        {
            if (isDisposed || renderedEggImage is null)
                return;
            var location = hostForm.PointToScreen(new Point((int)Math.Round(eggX), (int)Math.Round(eggY)));
            overlayForm.Location = location;
        }
        private void OverlayForm_MouseMove(object? sender, MouseEventArgs e)
        {
            overlayForm.Cursor = IsEggHit(e.Location) ? Cursors.Hand : Cursors.Default;
        }
        private void OverlayForm_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || !IsEggHit(e.Location))
                return;
            Finish(true);
        }
        private bool IsEggHit(Point location)
        {
            if (renderedEggImage is null)
                return false;
            if (location.X < 0 || location.Y < 0 || location.X >= renderedEggImage.Width || location.Y >= renderedEggImage.Height)
                return false;
            return renderedEggImage.GetPixel(location.X, location.Y).A > AlphaHitThreshold;
        }
        private void Finish(bool caught)
        {
            if (isDisposed)
                return;
            DisposeInternal();
            onFinished();
            if (caught)
                onCaught();
        }
        private void DisposeInternal()
        {
            if (isDisposed)
                return;
            isDisposed = true;
            animationTimer.Stop();
            animationTimer.Tick -= AnimationTimer_Tick;
            hostForm.Resize -= HostForm_BoundsChanged;
            hostForm.Move -= HostForm_BoundsChanged;
            hostForm.VisibleChanged -= HostForm_VisibleChanged;
            overlayForm.MouseDown -= OverlayForm_MouseDown;
            overlayForm.MouseMove -= OverlayForm_MouseMove;
            if (!overlayForm.IsDisposed)
            {
                overlayForm.BackgroundImage = null;
                overlayForm.Hide();
                overlayForm.Dispose();
            }
            renderedEggImage?.Dispose();
            renderedEggImage = null;
            sourceEggImage.Dispose();
            animationTimer.Dispose();
            Application.RemoveMessageFilter(clickBlocker);
        }
        public void Dispose()
        {
            Finish(false);
        }
    }
}
