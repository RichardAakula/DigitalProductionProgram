using System;
using System.Windows.Forms;

namespace DigitalProductionProgram.ControlsManagement
{
    internal class BufferedListView : ListView
    {
        public BufferedListView()
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw,true);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            DrawingControl.EnableDoubleBuffer(this);
        }
    }
}
