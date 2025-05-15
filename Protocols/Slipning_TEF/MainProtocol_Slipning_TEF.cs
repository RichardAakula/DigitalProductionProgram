using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    public partial class MainProtocol_Slipning_TEF : UserControl
    {

        public MainProtocol_Slipning_TEF()
        {
            InitializeComponent();
        }

        public void Load_Data()
        {
            Maskinparametrar.Load_Data();
            Produktion.Load_Data();
            Produktion.Load_Hållfasthet_Enhet();
        }
    }
}
