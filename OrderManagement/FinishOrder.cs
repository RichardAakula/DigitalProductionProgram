using System;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.OrderManagement
{
    public partial class FinishOrder : Form
    {
        public bool utskrift;
        private string poäng
        {
            get
            {
                if (chb_0.Checked)
                    return "0";
                if (chb_1.Checked)
                    return "1";
                if (chb_2.Checked)
                    return "2";
                if (chb_3.Checked)
                    return "3";
                if (chb_4.Checked)
                    return "4";
                if (chb_5.Checked)
                    return "5";
                return string.Empty;
            }
        }
        private bool Is_OkToFinish
        {
            get
            {
                if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.FinishIncompleteOrder, false))
                    return true;
                if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SetPointsForMaterial) && Order.IsPointsSetForOrder == false)
                    return panel_Points.Controls.OfType<CheckBox>().Any(chb => chb.Checked);

                return true;
            }
        }
        private CheckBox? lastChecked;




        public FinishOrder()
        {
            InitializeComponent();

            Initialize_Form();
            TranslateForm();
        }

        private void Initialize_Form()
        {
            if (!string.IsNullOrEmpty(Person.Name))
            {   //Kontrollera om Skriv ut skall synas eller ej
                if (Person.Role == "SuperAdmin")
                    chb_FinishOrder_PrintOrder.Visible = true;

            }
            if (Order.IsOrderDone_Before)
                chb_FinishOrder_PrintOrder.Visible = true;

            if (Monitor.Monitor.factory == Monitor.Monitor.Factory.Thailand)
                chb_Rapportera_Jira.Visible = false;

            chb_Rapportera_Jira.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ReportToProductionSupport, false);

            //Kontrollera om Poängen skall visas eller ej
            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.SetPointsForMaterial) && Order.IsPointsSetForOrder == false)
                panel_Points.Visible = true;
            else
            {
                panel_Points.Visible = false;
                Height = 150;
            }

        }
        private void TranslateForm()
        {
            Control[] controls = { label_FinishOrder_Header, chb_FinishOrder_PrintOrder, btn_FinishOrder, btn_Abort };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }

        private void Klar_Click(object sender, EventArgs e)
        {
            if (Is_OkToFinish)
            {
                if (!string.IsNullOrEmpty(poäng))
                    SaveData.INSERT_Order_Rating(poäng);

                if (chb_Rapportera_Jira.Checked)
                {
                    var jira = new Jira();
                    var black = new BlackBackground("", 85);
                    black.Show();
                    jira.ShowDialog();
                    black.Close();
                    return;
                }

                Order.IsOrderDone = true;
                utskrift = chb_FinishOrder_PrintOrder.Checked;
                Close();
            }
            else
                InfoText.Show("Du måste fylla i vilket poäng du ger för hur bra materialet har gått att köra.", CustomColors.InfoText_Color.Warning, "Warning!", this);
        }
        private void Avbryt_Click(object sender, EventArgs e)
        {
            Order.IsOrderDone = false;
            Close();
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            var active_chb = (CheckBox)sender;
            if (active_chb != lastChecked && lastChecked != null)
                lastChecked.Checked = false;
            lastChecked = active_chb.Checked ? active_chb : null;
        }
        private void Info_Jira_Click(object sender, EventArgs e)
        {
            InfoText.Show("Endast Skiftesledare/ProcessTekniker/Arbetsledare kan rapportera in till Jira.\n" +
                "Ta hjälp av någon av dessa om du behöver rapportera till Jira\n\n" +
                "Endast problem som varit specifikt med körningen skall rapporteras till Jira.", CustomColors.InfoText_Color.Warning, "Warning!", this);

        }

       
    }
}
