using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalProductionProgram.ControlsManagement
{
    internal class BufferedListBox : ListBox
    {
        public BufferedListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw,true);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DrawingControl.EnableDoubleBuffer(this);
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= Items.Count)
            {
                e.DrawBackground();
                return;
            }
            bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color backColor = isSelected ? SystemColors.Highlight : BackColor;
            Color foreColor = isSelected ? SystemColors.HighlightText : ForeColor;
            using var backgroundBrush = new SolidBrush(backColor);
            e.Graphics.FillRectangle(backgroundBrush,e.Bounds);
            Rectangle textBounds = new Rectangle(e.Bounds.X + 4,e.Bounds.Y,Math.Max(0,e.Bounds.Width - 8),e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics,GetItemText(Items[e.Index]),Font,textBounds,Enabled ? foreColor : SystemColors.GrayText,TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix);
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus)
                e.DrawFocusRectangle();
        }
    }
}
