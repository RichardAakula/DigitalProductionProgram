using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols
{
    internal class Open_Protocol
    {
        private static void Open(Form form, Form parent)
        {
            var name = form.Name;
            _ = Application.OpenForms[name];
            {
                form.StartPosition = FormStartPosition.Manual;
                form.Location = parent.Location;

                form.Show();
            }
        }
        public static void Choose_Protocol(Form parent)
        {
            if (Order.OrderNumber == null || Order.OrderID == null)
            {
                InfoText.Show(LanguageManager.GetString("error_OrderNotOpen") , CustomColors.InfoText_Color.Bad, "Warning");
                return;
            }
            switch (Order.WorkOperation)
            {
                //Kontrollerar att Processkort ej är öppet sen tidigare och öppnar det aktiva processkortet
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                    if (Application.OpenForms.OfType<Blandning_PTFE.Blandning_PTFE>().Count() == 1)
                        Application.OpenForms.OfType<Blandning_PTFE.Blandning_PTFE>().First().Close();
                    Open(new Blandning_PTFE.Blandning_PTFE(), parent);
                    break;
                    
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    if (Application.OpenForms.OfType<Kragning_TEF.Kragning_TEF>().Count() == 1)
                        Application.OpenForms.OfType<Kragning_TEF.Kragning_TEF>().First().Close();
                    Open(new Kragning_TEF.Kragning_TEF(), parent);
                    break;

                case Manage_WorkOperation.WorkOperations.Skärmning:
                    if (Application.OpenForms.OfType<Skärmning_TEF.Skärmning_TEF>().Count() == 1)
                        Application.OpenForms.OfType<Skärmning_TEF.Skärmning_TEF>().First().Close();
                    Open(new Skärmning_TEF.Skärmning_TEF(), parent);
                    break;

                case Manage_WorkOperation.WorkOperations.Slipning:
                    if (Application.OpenForms.OfType<Slipning_TEF.Slipning_TEF>().Count() == 1)
                        Application.OpenForms.OfType<Slipning_TEF.Slipning_TEF>().First().Close();
                    Open(new Slipning_TEF.Slipning_TEF(), parent);
                    break;

                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    if (Application.OpenForms.OfType<Spolning_PTFE.Spolning_PTFE>().Count() == 1)
                        Application.OpenForms.OfType<Spolning_PTFE.Spolning_PTFE>().First().Close();
                    Open(new Spolning_PTFE.Spolning_PTFE(), parent);
                    break;

                default:
                    if (Application.OpenForms.OfType<MainProtocol>().Count() == 1)
                        Application.OpenForms.OfType<MainProtocol>().First().Close();
                    Open(new MainProtocol(), parent);
                    break;
            }
        }
    }
}
