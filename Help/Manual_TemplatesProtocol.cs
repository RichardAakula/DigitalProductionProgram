using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.Help
{
    public partial class Manual_TemplatesProtocol : Form
    {
        public Manual_TemplatesProtocol()
        {
            InitializeComponent();
            Load_PDF();
        }
        private void Load_PDF()
        {
            var filePath = Path.Combine(Path.GetTempPath(), "Guide - Templates.pdf");
            File.WriteAllBytes(filePath, Properties.Resources.GuideTemplates);
            web_PDF_Viewer.Navigate(filePath); // Load the PDF into the WebBrowser control
        }
    }
}
