using System.Drawing.Drawing2D;
using System.Reflection;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.EasterEggs
{
    internal sealed class CipherWheelLevel3Overlay : Form
    {
        private const int FadeInTicks = 10;
        private const int HoldTicks = 84;
        private const int FadeOutTicks = 18;
        private readonly Form ownerForm;
        private readonly Timer timer;
        private readonly string message;
        private Image? backgroundImage;
        private int tick;
        private float imageScale = 1f;
        private int textAlpha;
        public CipherWheelLevel3Overlay(Form owner, string messageText)
        {
            ownerForm = owner;
            message = messageText;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            BackColor = Color.Black;
            Opacity = 0;
            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DigitalProductionProgram.Resources.Code_Background.jpg");
            if (stream != null)
            {
                using var loadedImage = Image.FromStream(stream);
                backgroundImage = new Bitmap(loadedImage);
            }
            timer = new Timer { Interval = 16 };
            timer.Tick += Timer_Tick;
        }
        protected override bool ShowWithoutActivation => true;
        public void RestartAnimation()
        {
            tick = 0;
            imageScale = 1f;
            textAlpha = 0;
            Opacity = 0;
            SyncToOwner();
            if (timer.Enabled == false)
                timer.Start();
            Invalidate();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RestartAnimation();
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            timer.Stop();
            timer.Tick -= Timer_Tick;
            backgroundImage?.Dispose();
            base.OnFormClosed(e);
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (ownerForm.IsDisposed || ownerForm.Visible == false || ownerForm.WindowState == FormWindowState.Minimized)
            {
                Close();
                return;
            }
            tick++;
            SyncToOwner();
            var totalTicks = FadeInTicks + HoldTicks + FadeOutTicks;
            float opacityFactor;
            if (tick <= FadeInTicks)
                opacityFactor = tick / (float)FadeInTicks;
            else if (tick <= FadeInTicks + HoldTicks)
                opacityFactor = 1f;
            else
                opacityFactor = 1f - ((tick - FadeInTicks - HoldTicks) / (float)FadeOutTicks);
            opacityFactor = Math.Clamp(opacityFactor, 0f, 1f);
            Opacity = 0.88d * opacityFactor;
            var zoomProgress = Math.Min(1f, tick / (float)(FadeInTicks + HoldTicks));
            imageScale = 1f + (0.18f * EaseOutCubic(zoomProgress));
            var textFadeProgress = Math.Clamp((tick - 6) / 18f, 0f, 1f);
            textAlpha = (int)(255 * textFadeProgress * opacityFactor);
            Invalidate();
            if (tick >= totalTicks)
                Close();
        }
        private void SyncToOwner()
        {
            Bounds = ownerForm.RectangleToScreen(ownerForm.ClientRectangle);
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Close();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var keyCode = keyData & Keys.KeyCode;
            if (keyCode is Keys.Escape or Keys.Enter or Keys.Space or Keys.P)
            {
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            DrawBackground(g);
            using var tintBrush = new SolidBrush(Color.FromArgb(120, 0, 0, 0));
            g.FillRectangle(tintBrush, ClientRectangle);
            var panelRect = GetPanelRectangle();
            using var path = CreateRoundedRectangle(panelRect, 28);
            using var panelBrush = new SolidBrush(Color.FromArgb(185, 8, 8, 8));
            using var borderPen = new Pen(Color.FromArgb(210, 187, 154, 87), 2f);
            g.FillPath(panelBrush, path);
            g.DrawPath(borderPen, path);
            using var glyphFont = new Font("Palatino Linotype", Math.Max(48, panelRect.Height / 2), FontStyle.Bold);
            using var glyphBrush = new SolidBrush(Color.FromArgb(Math.Min(60, textAlpha / 4), 215, 180, 90));
            using var glyphFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
            var glyphRect = Rectangle.Inflate(panelRect, -26, -18);
            g.DrawString("P", glyphFont, glyphBrush, glyphRect, glyphFormat);
            using var titleFont = new Font("Palatino Linotype", 19f, FontStyle.Bold);
            using var titleBrush = new SolidBrush(Color.FromArgb(textAlpha, 226, 210, 153));
            using var bodyFont = new Font("Palatino Linotype", 17f, FontStyle.Regular);
            using var bodyBrush = new SolidBrush(Color.FromArgb(textAlpha, 244, 236, 214));
            using var shadowBrush = new SolidBrush(Color.FromArgb(Math.Min(150, textAlpha), 0, 0, 0));
            using var titleFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near };
            using var bodyFormat = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near };
            var titleRect = new Rectangle(panelRect.Left + 28, panelRect.Top + 24, panelRect.Width - 56, 36);
            var titleShadowRect = new Rectangle(titleRect.X + 2, titleRect.Y + 2, titleRect.Width, titleRect.Height);
            g.DrawString("The Cipher Wheel", titleFont, shadowBrush, titleShadowRect, titleFormat);
            g.DrawString("The Cipher Wheel", titleFont, titleBrush, titleRect, titleFormat);
            using var dividerPen = new Pen(Color.FromArgb(Math.Min(180, textAlpha), 191, 162, 84), 1f);
            g.DrawLine(dividerPen, panelRect.Left + 38, panelRect.Top + 74, panelRect.Right - 38, panelRect.Top + 74);
            var bodyRect = new Rectangle(panelRect.Left + 34, panelRect.Top + 88, panelRect.Width - 68, panelRect.Height - 118);
            var bodyShadowRect = new Rectangle(bodyRect.X + 2, bodyRect.Y + 2, bodyRect.Width, bodyRect.Height);
            g.DrawString(message, bodyFont, shadowBrush, bodyShadowRect, bodyFormat);
            g.DrawString(message, bodyFont, bodyBrush, bodyRect, bodyFormat);
        }
        private void DrawBackground(Graphics g)
        {
            if (backgroundImage == null)
                return;
            var destRect = GetCoverRectangle(ClientRectangle, backgroundImage.Size, imageScale);
            g.DrawImage(backgroundImage, destRect);
        }
        private Rectangle GetPanelRectangle()
        {
            var width = Math.Min((int)(ClientSize.Width * 0.68f), 880);
            var height = Math.Min((int)(ClientSize.Height * 0.40f), 300);
            width = Math.Max(width, 520);
            height = Math.Max(height, 220);
            return new Rectangle((ClientSize.Width - width) / 2, (ClientSize.Height - height) / 2, width, height);
        }
        private static Rectangle GetCoverRectangle(Rectangle bounds, Size imageSize, float scale)
        {
            var baseScale = Math.Max(bounds.Width / (float)imageSize.Width, bounds.Height / (float)imageSize.Height);
            var finalScale = baseScale * scale;
            var width = (int)(imageSize.Width * finalScale);
            var height = (int)(imageSize.Height * finalScale);
            return new Rectangle(bounds.X + ((bounds.Width - width) / 2), bounds.Y + ((bounds.Height - height) / 2), width, height);
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
        private static float EaseOutCubic(float value)
        {
            var inverted = 1f - value;
            return 1f - (inverted * inverted * inverted);
        }
    }
}
