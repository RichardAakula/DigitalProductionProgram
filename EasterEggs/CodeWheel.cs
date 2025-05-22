using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.EasterEggs
{
    public partial class CodeWheel : UserControl
    {
        private readonly char[] _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
        private int _index = 0;

        public char SelectedChar => _characters[_index];

        public CodeWheel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Width = 200;
            this.Height = 200;
            this.BackColor = Color.Transparent;
            this.Font = new Font("Consolas", 24, FontStyle.Bold);
            this.Cursor = Cursors.Hand;

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("DigitalProductionProgram.Resources.CodeWheel.png");
            if (stream != null)
            {
                this.BackgroundImage = Image.FromStream(stream);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        public void SetHighlight(Color color)
        {
            this.BackColor = color;
        }
        public void ResetHighlight()
        {
            this.BackColor = Color.Transparent;
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (Parent is { } parentControl)
            {
                foreach (Control c in parentControl.Controls)
                {
                    if (c is CodeWheel wheel)
                        wheel.ResetHighlight();
                }
            }
            if (e.Button == MouseButtons.Left)
                _index = (_index + 1) % _characters.Length;
            else if (e.Button == MouseButtons.Right)
                _index = (_index - 1) % _characters.Length;
            
            this.Invalidate(); // Tvinga omritning
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (Parent is { } parentControl)
            {
                foreach (Control c in parentControl.Controls)
                {
                    if (c is CodeWheel wheel)
                        wheel.ResetHighlight();
                }
            }
            if (e.Delta > 0)
                // Scroll uppåt – framåt i listan
                _index = (_index + 1) % _characters.Length;
            else if (e.Delta < 0)
                // Scroll nedåt – bakåt i listan
                _index = (_index - 1 + _characters.Length) % _characters.Length;

            this.Invalidate(); // Rita om
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            using var brush = new SolidBrush(Color.FromArgb(20,30,40));
            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            g.DrawString(_characters[_index].ToString(), new Font("Segoe UI", 28f, FontStyle.Bold), brush, this.ClientRectangle, sf);
        }
    }
}
