using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Measure
{
    public partial class BrowseMeasureProtocols : Form
    {
        public BrowseMeasureProtocols()
        {
            InitializeComponent();
            InfoText.Show("Blädda gamla Mätprotokoll fungerar inte för tillfället, kommer tillbaks så fort tid finnes.", CustomColors.InfoText_Color.Bad, "Warning");
        }
    }
}
