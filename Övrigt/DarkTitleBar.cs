using System;
using System.Runtime.InteropServices;

namespace DigitalProductionProgram.Övrigt
{
    internal class DarkTitleBar
    {
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            //var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
            //attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;

            int useImmersiveDarkMode = enabled ? 1 : 0;
            return DwmSetWindowAttribute(handle, 20, ref useImmersiveDarkMode, sizeof(int)) == 0;

        }

       
    
    }
}
