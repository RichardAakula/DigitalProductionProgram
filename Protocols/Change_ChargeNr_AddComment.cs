using System;
using System.Windows.Forms;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Protocols
{
    public partial class Change_ChargeNr_AddComment : Form
    {
        private string kommentar { get; set; }
        public string Kommentar
        {
            get => kommentar;
            set => kommentar = value;
        }



        public Change_ChargeNr_AddComment()
        {
            InitializeComponent();
            Translate_Form();
        }

        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_ChangeChargeNr_Header, label_ChangeChargeNr_Info_1, lbl_ChangeChargeNr_Info_Change, lbl_ChangeChargeNr_Info_Exit});
        }
        private void ChangeChargeNr_Click(object sender, EventArgs e)
        {
            Kommentar = tb_Kommentar.Text;
            if (Kommentar.Length > 5)
                Close();
            else
                InfoText.Show(LanguageManager.GetString("changeBatchNr_Info_3"), CustomColors.InfoText_Color.Bad, "Warning!", this);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            kommentar = null;
            Close();
        }
    }
}
