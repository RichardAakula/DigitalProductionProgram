using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;


namespace DigitalProductionProgram.ControlsManagement
{
    public partial class BetaOverlayForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x00080000; // WS_EX_LAYERED
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT — gör fönstret click-through
                return cp;
            }
        }
        internal static class NativeMethods
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int X;
                public int Y;
                public POINT(int x, int y) { X = x; Y = y; }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct SIZE
            {
                public int cx;
                public int cy;
                public SIZE(int cx, int cy) { this.cx = cx; this.cy = cy; }
            }

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            public struct BLENDFUNCTION
            {
                public byte BlendOp;
                public byte BlendFlags;
                public byte SourceConstantAlpha;
                public byte AlphaFormat;
            }

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst,
                ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern IntPtr GetDC(IntPtr hWnd);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern bool DeleteDC(IntPtr hdc);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

            [DllImport("gdi32.dll", SetLastError = true)]
            public static extern bool DeleteObject(IntPtr hObject);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateLayeredWindowBitmap();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            UpdateLayeredWindowBitmap();
        }
        private readonly Timer _timer;
        private readonly int _speed = 2; // pixlar per tick
        private Bitmap? _bitmap;
        private readonly Form _parentForm;


        public BetaOverlayForm(Form parent)
        {
            InitializeComponent();
            _parentForm = parent;


            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.BackColor = Color.Black; // men du ritar transparenta delar i bitmap
            this.Size = new Size(300, 60);  // exempelstorlek

            this.Left = _parentForm.Left;
            this.Top = _parentForm.Top + 40;

            _timer = new Timer();
            _timer.Interval = 5; // ungefär 60 fps
            _timer.Tick += Timer_Tick;
            _timer.Start();

            UpdateLayeredWindowBitmap();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Left += _speed;

            int rightBoundary = _parentForm.Width;

            if (this.Left > rightBoundary)
            {
                this.Left = _parentForm.Left;
            }

            this.Top = _parentForm.Top + 40;  // Håll höjden konstant om du vill
            UpdateLayeredWindowBitmap();
        }

        private void UpdateLayeredWindowBitmap()
        {
            _bitmap?.Dispose();
            _bitmap = new Bitmap(Width, Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(_bitmap))
            {
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                g.Clear(Color.Transparent);
                // Rita din semi-transparenta bakgrund
                using (var brush = new SolidBrush(Color.FromArgb(120, 0, 0, 0)))
                    g.FillRectangle(brush, ClientRectangle);

                // Rita din text
                string text = "No EasterEgg here! \n" +
                              "I'm just in Beta mode";
                using (var font = new Font("Segoe UI", 16, FontStyle.Bold))
                using (var textBrush = new SolidBrush(PrintingServices.CustomColors.Bad_Back))
                {
                    SizeF textSize = g.MeasureString(text, font);
                    g.DrawString(text, font, textBrush, (Width - textSize.Width) / 2, (Height - textSize.Height) / 2);
                }
            }

            IntPtr screenDc = NativeMethods.GetDC(IntPtr.Zero);
            IntPtr memDc = NativeMethods.CreateCompatibleDC(screenDc);
            IntPtr hBitmap = _bitmap.GetHbitmap(Color.FromArgb(0));
            IntPtr oldBitmap = NativeMethods.SelectObject(memDc, hBitmap);

            NativeMethods.POINT topPos = new NativeMethods.POINT(Left, Top);
            NativeMethods.SIZE size = new NativeMethods.SIZE(Width, Height);
            NativeMethods.POINT pointSource = new NativeMethods.POINT(0, 0);
            NativeMethods.BLENDFUNCTION blend = new NativeMethods.BLENDFUNCTION
            {
                BlendOp = 0x00,
                BlendFlags = 0,
                SourceConstantAlpha = 255,
                AlphaFormat = 0x01 // AC_SRC_ALPHA
            };

            NativeMethods.UpdateLayeredWindow(Handle, screenDc, ref topPos, ref size, memDc, ref pointSource, 0, ref blend, 2);

            NativeMethods.SelectObject(memDc, oldBitmap);
            NativeMethods.DeleteObject(hBitmap);
            NativeMethods.DeleteDC(memDc);
            NativeMethods.ReleaseDC(IntPtr.Zero, screenDc);
        }

    }
}
