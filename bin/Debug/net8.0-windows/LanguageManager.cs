using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace DigitalProductionProgram
{
    internal class LanguageManager
    {
        private static readonly ResourceManager resource = new ResourceManager(typeof(Properties.Resources));
        public static CultureInfo selectedCulture { get; set; } = new CultureInfo("sv-SE");


        public static string? GetString(string key)
        {
            if (selectedCulture == null)
                selectedCulture = new CultureInfo("sv-SE");
            var value = resource.GetString(key, selectedCulture);
            return !string.IsNullOrEmpty(value) ? value : "Error: Missing text, please contact Admin.";
        }

        public static class TranslationHelper
        {
            public static void TranslateControls(Control[] controls)
            {
                foreach (var control in controls)
                    control.Text = GetString(control.Name);
            }
            public static void TranslateControls(Control control)
            {
                control.Text = GetString(control.Name);
            }
            public static void TranslateMainMenu(MenuStrip menuStrip)
            {
                foreach (ToolStripMenuItem menu in menuStrip.Items)
                {
                    if (menu.Name == "Menu_Developer")
                        return;
                    menu.Text = GetString(menu.Name);
                    TranslateSubMenu(menu);
                    //foreach (ToolStripMenuItem submenu in menu.DropDownItems)
                    //    submenu.Text = GetString(submenu.Name);
                }
            }
            private static void TranslateSubMenu(ToolStripMenuItem parentMenu)
            {
                foreach (ToolStripItem submenu in parentMenu.DropDownItems)
                {
                    if (submenu is ToolStripMenuItem subMenuItem)
                    {
                        // Translate the sub-menu item
                        subMenuItem.Text = GetString(subMenuItem.Name);

                        // Recursively translate sub-menu items
                        TranslateSubMenu(subMenuItem);
                    }
                }
            }

            private static IEnumerable<Control> GetAllControls(UserControl form)
            {
                var controls = form.Controls.Cast<UserControl>();
                return controls.SelectMany(GetAllControls).Concat(controls);
            }
        }
    }
}
