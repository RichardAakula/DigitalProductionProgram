using System.Windows.Forms;

using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    public partial class MainProtocol_Spolning_PTFE : UserControl
    {
        public MainProtocol_Spolning_PTFE()
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
