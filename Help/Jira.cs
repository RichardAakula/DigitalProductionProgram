using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Help
{
    public partial class Jira : Form
    {
        private bool is_Text_Changed_Extruder_Temp;
        private bool is_Text_Changed_Extruder_Matning;
        private bool is_Text_Changed_Dragare;
        private bool IsOkSendReport
        {
            get
            {
                if ((chb_Extruder_Temp.Checked && is_Text_Changed_Extruder_Temp == false) || string.IsNullOrEmpty(tb_Extruder_Temp.Text))
                {
                    InfoText.Show("Du har checkat i att det har varit problem med extruderns temperaturer men ej fyllt i någon kommentar.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                    tb_Extruder_Temp.SelectAll();
                    tb_Extruder_Temp.Focus();
                    return false;
                }
                if ((chb_Extruder_Matning.Checked && is_Text_Changed_Extruder_Matning == false) || string.IsNullOrEmpty(tb_Extruder_Matning.Text))
                {
                    InfoText.Show("Du har checkat i att det har varit problem med extruderns matning men ej fyllt i någon kommentar.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                    tb_Extruder_Matning.SelectAll();
                    tb_Extruder_Matning.Focus();
                    return false;
                }
                if ((chb_Dragare.Checked && is_Text_Changed_Dragare == false) || string.IsNullOrEmpty(tb_Dragare.Text))
                {
                    InfoText.Show("Du har checkat i att det har varit problem med dragare/hack men ej fyllt i någon kommentar.", CustomColors.InfoText_Color.Warning, "Warning!", this);
                    tb_Dragare.SelectAll();
                    tb_Dragare.Focus();
                    return false;
                }
                return true;

            }
        }

        private string binary
        {
            get
            {
                int one, two, three;
                if (chb_Extruder_Temp.Checked)
                    one = 1;
                else
                    one = 0;
                if (chb_Extruder_Matning.Checked)
                    two = 1;
                else
                    two = 0;
                if (chb_Dragare.Checked)
                    three = 1;
                else
                    three = 0;

                return $"{one}{two}{three}";
            }
        }
        private string order_Tid
        {
            get
            {
                var tid = Order.Total_RunTime_Order;
                double.TryParse(tid.TotalDays.ToString(), out var days);
                double.TryParse(tid.TotalHours.ToString(), out var hours);
                double.TryParse(tid.TotalMinutes.ToString(), out var mins);
                mins = mins - Math.Floor(hours) * 60;
                hours = hours - Math.Floor(days) * 24;

                return $"{Math.Floor(days)} dagar {Math.Floor(hours)} h {Math.Floor(mins)} min";
            }
        }
        private string mail_Meddelande
        {
            get
            {
                var kontaktPerson = tb_Kontaktperson.Text;
                if (string.IsNullOrEmpty(kontaktPerson))
                    kontaktPerson = Person.Name;

                var meddelande = $"<font color = 'red'><b>ArtikelNr:</b> </font> {Order.PartNumber} <br />" +
                                 $"<font color = 'red'><b>OrderNr:</b> </font> {Order.OrderNumber} <br />" +
                                 "<br />" +
                                 $"<font color = 'red'><b>Kontaktperson:</b> </font> {kontaktPerson}  <b> <font color = 'red'> - Telefonnr:</b> </font>{tb_Telefonnummer.Text} <br />" +
                                 $"<font color = 'red'><b>Tid spenderat på denna order:</b> </font> {tb_Tid.Text} <br /> <br />";

                if (chb_Extruder_Temp.Checked)
                    meddelande += "<font color = 'red'><b>Temperaturproblem:</b></font><br />" +
                                  $"{tb_Extruder_Temp.Text} <br /> <br />";

                if (chb_Extruder_Matning.Checked)
                    meddelande += "<font color = 'red'><b>MatningsProblem:</b></font><br />" +
                                  $"{tb_Extruder_Matning.Text} <br />" +
                                  $"<font color = 'gray'>Skruvvarv:</font> {tb_Skruvvarv.Text} <br />" +
                                  $"<font color = 'gray'>Belastning:</font> {tb_Belastning.Text} <br /> <br />";

                if (chb_Dragare.Checked)
                    meddelande += "<font color = 'red'><b>Problem med Dragare/Hack:</b></font><br />" +
                                  $"{tb_Dragare.Text} <br /><br />";

                meddelande += "<font color = 'red'><b>Uppmätta mått på utrustning:</b></font> <br />" +
                              $"<font color = 'gray'>Munstycke:</font> {tb_Munstycke.Text}<br />" +
                              $"<font color = 'gray'>Kärn: </font> {tb_Kärn.Text}<br />" +
                              $"<font color = 'gray'>Hackrör: </font>{tb_Hackrör.Text}<br />" +
                              $"<font color = 'gray'>Kalibrering: </font>{tb_Kalibrering.Text}<br />" +
                              "<br />";

                if (chb_Material.Checked)
                {
                    meddelande += "<font color = 'red'> <b> Kommentarer angående materialproblem: </font> </b> <br/>" +
                                  $"{tb_Kommentarer_Material.Text} <br /> <br />";

                    meddelande += "<font color = 'red'><b>Dessa ordrar är tidigare körda med samma lotnr: </b></font><br />" +
                                  "(OrderNr - Halvfabrikat Benämning - LotNr) <br />" +
                                  "<br />";

                    foreach (CheckBox chb in flp_Material.Controls)
                    {
                        if (chb.Checked)
                        {
                            using (var con = new SqlConnection(Database.cs_Protocol))
                            {
                                var query = $@"SELECT Halvfabrikat_OrderNr FROM [Order].PreFab {Queries.WHERE_OrderID}
                                               AND Halvfabrikat_Benämning = @lotNr";
                                con.Open();
                                var cmd = new SqlCommand(query, con);
                                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                                cmd.Parameters.AddWithValue("@lotNr", chb.Text);
                                var orderNr = cmd.ExecuteScalar().ToString();
                                for (var i = 0; i < list_Ordrar_Med_Samma_LotNr(orderNr).Count; i++)
                                {
                                    meddelande += $"{list_Ordrar_Med_Samma_LotNr(orderNr)[i]} - {chb.Text} - {orderNr}<br />";
                                }
                            }
                        }
                    }
                }
                meddelande += "<br /><font color = 'red'><b>Övriga kommentarer om körningen:</b></font> <br />" +
                              $"{tb_Kommentarer.Text}";



                return meddelande;
            }


        }
        private List<string> list_Ordrar_Med_Samma_LotNr(string lotNr)
        {
            var list = new List<string>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = "SELECT DISTINCT OrderNr FROM [Order].PreFab WHERE Halvfabrikat_OrderNr = @lotNr";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@lotNr", lotNr);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(reader[0].ToString());
                }
            }
            return list;
        }




        public Jira()
        {
            InitializeComponent();
            
            tb_Tid.Text = order_Tid;

            Person.Fill_ContextMenu_Name(cm_Namn);

            tb_Munstycke.Text = Inventera_Verktyg.Verktyg_Dim_OrderNr("Munstycke");
            tb_Kärn.Text = Inventera_Verktyg.Verktyg_Dim_OrderNr("Kärn");

            Load_Materials();
        }




        private void Load_Materials()
        {
            for (var i = 0; i < PreFab.DataTable_PreFab(Order.OrderID, true).Rows.Count; i++)
            {
                var chb = new CheckBox
                {
                    Text = PreFab.DataTable_PreFab(Order.OrderID, true).Rows[i]["Benämning:"].ToString(),
                    Font = new Font("Cambria", 9),
                    ForeColor = Color.White,
                    Width = flp_Material.Width
                };

                flp_Material.Controls.Add(chb);
            }
        }
        private void Send_Mail()
        {
            if (IsOkSendReport)
            {
                Mail.Body = mail_Meddelande;
                Mail.Send("Problemkörning:", 9);
            }
        }
        private void Set_tlp_TextBoxes_Height()
        {
            tlp_TextBoxes.Visible = true;
            switch (binary)
            {
                case "000":
                    tlp_TextBoxes.RowStyles[0].Height = 0;
                    tlp_TextBoxes.RowStyles[1].Height = 0;
                    tlp_TextBoxes.RowStyles[2].Height = 0;
                    tlp_TextBoxes.Visible = false;
                    break;
                case "100":
                    tlp_TextBoxes.RowStyles[0].Height = 100;
                    tlp_TextBoxes.RowStyles[1].Height = 0;
                    tlp_TextBoxes.RowStyles[2].Height = 0;
                    break;
                case "110":
                    tlp_TextBoxes.RowStyles[0].Height = 50;
                    tlp_TextBoxes.RowStyles[1].Height = 50;
                    tlp_TextBoxes.RowStyles[2].Height = 0;
                    break;
                case "111":
                    tlp_TextBoxes.RowStyles[0].Height = 33;
                    tlp_TextBoxes.RowStyles[1].Height = 33;
                    tlp_TextBoxes.RowStyles[2].Height = 33;
                    break;
                case "010":
                    tlp_TextBoxes.RowStyles[0].Height = 0;
                    tlp_TextBoxes.RowStyles[1].Height = 100;
                    tlp_TextBoxes.RowStyles[2].Height = 0;
                    break;
                case "011":
                    tlp_TextBoxes.RowStyles[0].Height = 0;
                    tlp_TextBoxes.RowStyles[1].Height = 50;
                    tlp_TextBoxes.RowStyles[2].Height = 50;
                    break;
                case "001":
                    tlp_TextBoxes.RowStyles[0].Height = 0;
                    tlp_TextBoxes.RowStyles[1].Height = 0;
                    tlp_TextBoxes.RowStyles[2].Height = 100;
                    break;
                case "101":
                    tlp_TextBoxes.RowStyles[0].Height = 50;
                    tlp_TextBoxes.RowStyles[1].Height = 0;
                    tlp_TextBoxes.RowStyles[2].Height = 50;
                    break;

            }
        }





        private void pb_Info_Tid_Click(object sender, EventArgs e)
        {
            InfoText.Show("Programmet räknar själv ut en tid som du vid behov kan ändra.", CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void pb_Info_Kontaktperson_Click(object sender, EventArgs e)
        {
            InfoText.Show("Om namnet saknas i listan går det bra att skriva i manuellt.", CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void pb_Info_Verktyg_Click(object sender, EventArgs e)
        {
            InfoText.Show("Om du/ni inventerat verktygen tidigare fylls Munstycke/Kärna automatiskt i. \n" +
                "Om inte dimensionen på hackrör/kalibrering är relevant så kan du lämna dem tomma.", CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void pb_Info_Material_Click(object sender, EventArgs e)
        {
            InfoText.Show("Klicka i enbart det materialet du haft problem med. \n" +
                "Om du är osäker på problemet så klickar du inte i något material.", CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void tb_Extruder_Temp_KeyDown(object sender, KeyEventArgs e)
        {
            is_Text_Changed_Extruder_Temp = true;
        }
        private void tb_Extruder_Matning_KeyDown(object sender, KeyEventArgs e)
        {
            is_Text_Changed_Extruder_Matning = true;
        }
        private void tb_Dragare_KeyDown(object sender, KeyEventArgs e)
        {
            is_Text_Changed_Dragare = true;
        }

        private void chb_Extruder_Temp_CheckedChanged(object sender, EventArgs e)
        {
            Set_tlp_TextBoxes_Height();
            if (chb_Extruder_Temp.Checked)
            {
                if (string.IsNullOrEmpty(tb_Extruder_Temp.Text))
                    tb_Extruder_Temp.Text = "Skriv här vilken zon som har problem samt hur mycket den ändrar i temperatur.";

                tb_Extruder_Temp.SelectAll();
                tb_Extruder_Temp.Focus();
            }
        }
        private void chb_Extryder_Matning_CheckedChanged(object sender, EventArgs e)
        {
            Set_tlp_TextBoxes_Height();
            if (chb_Extruder_Matning.Checked)
            {
                if (string.IsNullOrEmpty(tb_Extruder_Matning.Text))
                    tb_Extruder_Matning.Text = "Skriv här hur det har varit problem med extruderns matning. Samt fyll i variationen till höger.";

                tb_Extruder_Matning.SelectAll();
                tb_Extruder_Matning.Focus();
            }
        }
        private void chb_Dragare_CheckedChanged(object sender, EventArgs e)
        {
            Set_tlp_TextBoxes_Height();
            if (chb_Dragare.Checked)
            {
                if (string.IsNullOrEmpty(tb_Dragare.Text))
                    tb_Dragare.Text = "Skriv här vad som har varit problem med dragaren eller hacken.";

                tb_Dragare.SelectAll();
                tb_Dragare.Focus();
            }
        }
        private void chb_Material_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_Material.Checked)
                tlp_Material.Visible = true;
            else
                tlp_Material.Visible = false;
        }





        private void Namn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            tb_Kontaktperson.Text = e.ClickedItem.Text;
        }
        private void Namn_Enter(object sender, EventArgs e)
        {
            cm_Namn.Show(Cursor.Position.X + 40, Cursor.Position.Y + 30);
        }

        private void Skicka_Click(object sender, EventArgs e)
        {
            Send_Mail();
            Close();
        }
        private void Avbryt_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
