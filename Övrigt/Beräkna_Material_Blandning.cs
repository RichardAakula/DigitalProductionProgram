using System;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.Övrigt
{
    public partial class Beräkna_Material_Blandning : Form
    {
        public Beräkna_Material_Blandning()
        {
            InitializeComponent();
            TextBox[] tb = {tb_Total_Mängd, tb_Pigment, tb_Material_1, tb_Material_2 };
            for (int i = 0; i < tb.Length; i++)
                tb[i].KeyPress += Public_Events.Only_Decimal_KeyPress;

            cb_BlandningsTyp.SelectedIndex = 0;
        }


        private void tb_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(tb_Total_Mängd.Text, out double total);
            double.TryParse(tb_Pigment.Text, out double pigment);
            double.TryParse(tb_Material_1.Text, out double material_1);
            double.TryParse(tb_Material_2.Text, out double material_2);

            if (pigment + material_1 + material_2 != 100)
            {
                lbl_Blandning_Ok.BackColor = CustomColors.Bad_Back;
                lbl_Blandning_Ok.ForeColor = CustomColors.Bad_Front;
                lbl_Blandning_Ok.Text = "Nej, kolla siffrorna.";
            }
            else
            {
                lbl_Blandning_Ok.BackColor = CustomColors.Ok_Back;
                lbl_Blandning_Ok.ForeColor = CustomColors.Ok_Front;
                lbl_Blandning_Ok.Text = "Ok";

                lbl_Resultat_Pigment.Text = $"{total * pigment / 100}";
                lbl_Resultat_Material_1.Text = $"{total * material_1 / 100}";
                lbl_Resultat_Material_2.Text = $"{total * material_2 / 100}";
            }
        }

        private void cb_BlandningsTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Activity.Start();
            switch(cb_BlandningsTyp.SelectedIndex)
            {
                case 0:///Ett material + pigment
                    tlp_Main.RowStyles[2].Height = 20;      ///Pigment
                    tlp_Main.RowStyles[4].Height = 0;       ///Material 2
                    tlp_Main.RowStyles[7].Height = 20;      ///result_Pigment
                    tlp_Main.RowStyles[9].Height = 0;       ///result_Material 2
                    tb_Material_2.Visible = false;
                    label_Material_2_enhet.Visible = false;
                    label_Material_2.Visible = false;
                    Height = 199;
                    break;
                case 1:///Två material + pigment
                    tlp_Main.RowStyles[2].Height = 20;      ///Pigment
                    tlp_Main.RowStyles[4].Height = 20;      ///Material 2
                    tb_Material_2.Visible = true;
                    label_Material_2_enhet.Visible = true;
                    label_Material_2.Visible = true;
                    tlp_Main.RowStyles[7].Height = 20;      ///result_Pigment
                    tlp_Main.RowStyles[9].Height = 20;      ///result_Material 2
                    Height = 241;
                    break;
                case 2:
                    tlp_Main.RowStyles[2].Height = 0;       ///Pigment
                    tlp_Main.RowStyles[4].Height = 20;      ///Material 2
                    tb_Material_2.Visible = true;
                    label_Material_2_enhet.Visible = true;
                    label_Material_2.Visible = true;
                    tlp_Main.RowStyles[7].Height = 0;       ///result_Pigment
                    tlp_Main.RowStyles[9].Height = 20;      ///result_Material 2
                    Height = 202;
                    break;
            }
            tb_Material_1.Text = string.Empty;
            tb_Material_2.Text = string.Empty;
            tb_Pigment.Text = string.Empty;
            tb_Total_Mängd.Text = string.Empty;
            _ = Activity.Stop($"Beräkna Material - {cb_BlandningsTyp.Text}");
        }
    }
}
