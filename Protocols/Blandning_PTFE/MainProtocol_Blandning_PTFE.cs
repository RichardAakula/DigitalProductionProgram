using System.Windows.Forms;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Protocols.Blandning_PTFE
{
    public partial class MainProtocol_Blandning_PTFE : UserControl
    {
        public MainProtocol_Blandning_PTFE()
        {
            InitializeComponent();

        }

        public void Load_Data()
        {
            MainInfo.Load_Data(Order.OrderID);
            Journal.Load_Info();
            Journal.Load_Data();
        }
    }
}
