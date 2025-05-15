using System.Globalization;
using System.Resources;

namespace DigitalProductionProgram
{
    internal class LanguageManager
    {
        private static readonly ResourceManager resource = new(typeof(Properties.Resources));
        public static CultureInfo selectedCulture { get; set; } = new("sv-SE");


        public static string? GetString(string key)
        {
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
                    if (menu.Name != null) 
                        menu.Text = GetString(menu.Name);
                    TranslateSubMenu(menu);
                    //foreach (ToolStripMenuItem submenu in menu.DropDownItems)
                    //    submenu.Text = GetString(submenu.Name);
                }
            }
            private static void TranslateSubMenu(ToolStripDropDownItem parentMenu)
            {
                foreach (ToolStripItem submenu in parentMenu.DropDownItems)
                {
                    if (submenu is ToolStripMenuItem subMenuItem)
                    {
                        // Translate the sub-menu item
                        if (subMenuItem.Name != null) subMenuItem.Text = GetString(subMenuItem.Name);

                        // Recursively translate sub-menu items
                        TranslateSubMenu(subMenuItem);
                    }
                }
            }

            //private static IEnumerable<Control> GetAllControls(UserControl form)
            //{
            //    var controls = form.Controls.Cast<UserControl>();
            //    var userControls = controls as UserControl[] ?? controls.ToArray();
            //    return userControls.SelectMany(GetAllControls).Concat(userControls);
            //}
        }
    }
}
