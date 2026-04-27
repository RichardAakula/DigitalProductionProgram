using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DigitalProductionProgram.ControlsManagement
{
    internal class DrawingControl
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 11;
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
        private const int LVS_EX_DOUBLEBUFFER = 0x00010000;
        public static void SuspendDrawing(Control parent)
        {
            if (parent is null || parent.IsDisposed || parent.IsHandleCreated == false)
                return;
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }
        public static void ResumeDrawing(Control parent)
        {
            if (parent is null || parent.IsDisposed || parent.IsHandleCreated == false)
                return;
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
        public static void EnableDoubleBuffer(Control control)
        {
            if (control is null)
                return;
            typeof(Control)
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                ?.SetValue(control, true, null);
        }
        public static void EnableDoubleBuffer(ListView listView)
        {
            if (listView is null)
                return;
            EnableDoubleBuffer((Control)listView);
            if (!SystemInformation.TerminalServerSession && listView.IsHandleCreated)
                SendMessage(listView.Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, (IntPtr)LVS_EX_DOUBLEBUFFER, (IntPtr)LVS_EX_DOUBLEBUFFER);
        }
    }
}
