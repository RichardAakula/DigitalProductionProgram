using System;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Processcards
{
    public partial class ProcesscardBasedOn : UserControl
    {
       
        public static bool IsHistoricalData;
        public static bool IsValidated;
        public static bool IsUnderDevelopment;
        
        
        public ProcesscardBasedOn()
        {
            InitializeComponent();
            Clear_Data();
        }
       
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{btn_ProcesscardBasedOn, label_ProcesscardApprovedDate, label_RevNr, label_EstablishedBy, label_ApprovedBy, rb_HistoricalData, rb_Validated, rb_FramtagningAvProcessfönster});
        }


        public void Clear_Data()
        {
            lbl_UpprättatAv_Sign_AnstNr.Text = string.Empty;
            lbl_ApprovedDate.Text = string.Empty;
            lbl_QA_Sign.Text = string.Empty;
            tb_Validerade_Loter.Text = string.Empty;
            lbl_RevNr.Text = string.Empty;
            rb_HistoricalData.Checked = false;
            rb_Validated.Checked = false;
            rb_FramtagningAvProcessfönster.Checked = true;
        }
        public static void ApproveProcesscard(string qa_sign, DateTime date, int? partID, bool IsOkShowMessage)
        {
            Activity.Start();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    UPDATE Processcard.MainData SET GodkäntDatum = @datum, QA_sign = @qaSign 
                    WHERE PartID = @partid";
                con.Open();

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@datum", date);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", partID);
                cmd.Parameters.AddWithValue("@qaSign", qa_sign);
                var ok = cmd.ExecuteNonQuery();

                con.Close();
                if (IsOkShowMessage)
                {
                    if (ok > 0)
                        InfoText.Show(LanguageManager.GetString("approve_Processcard_Ok"), CustomColors.InfoText_Color.Ok, null);
                    else
                        InfoText.Show(LanguageManager.GetString("approve_Processcard_Error"), CustomColors.InfoText_Color.Bad, "Warning");
                }
            }

            _ = Activity.Stop($"QA Godkänt Processkort - {Order.PartNumber} - ProdLinje: {Order.ProdLine} - ProduktTyp: {Order.ProdType}");
        }
        public void Load_Data()
        {
            Translate_Form();
            Clear_Data();
            const string query = @"
                    SELECT Historiska_Data, Validerat, Framtagning_Processfönster, GodkäntDatum, Validerade_Loter, RevNr, UpprättatAv_Sign_AnstNr, QA_sign
                    FROM Processcard.MainData WHERE PartID = @partid";


            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var cmd = new SqlCommand(query, con);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bool.TryParse(reader["Historiska_Data"].ToString(), out IsHistoricalData);
                    rb_HistoricalData.Checked = IsHistoricalData;
                    bool.TryParse(reader["Validerat"].ToString(), out IsValidated);
                    rb_Validated.Checked = IsValidated;
                    bool.TryParse(reader["Framtagning_Processfönster"].ToString(), out IsUnderDevelopment);
                    rb_FramtagningAvProcessfönster.Checked = IsUnderDevelopment;



                    if (DateTime.TryParse(reader["GodkäntDatum"].ToString(), out var date))
                    {
                        var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                        var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
                        lbl_ApprovedDate.Text = formattedDate;
                    }
                    else
                        lbl_ApprovedDate.Text = "N/A";

                    tb_Validerade_Loter.Text = reader["Validerade_Loter"].ToString();
                    lbl_RevNr.Text = reader["RevNr"].ToString();
                    lbl_UpprättatAv_Sign_AnstNr.Text = reader["UpprättatAv_Sign_AnstNr"].ToString();
                    lbl_QA_Sign.Text = reader["QA_sign"].ToString();

                }
                reader.Close();
               
            }
        }

        private void FramtagningAvProcessfönster_CheckedChanged(object sender, EventArgs e)
        {
            if (Manage_Processcards.IsProcesscardUnderManagement == false)
                return;

            tb_Validerade_Loter.Enabled = false;
            if (tb_Validerade_Loter.TextLength == 0)
                tb_Validerade_Loter.Text = "N/A";
            lbl_RevNr.Enabled = true;
            
        }
        private void Validerat_CheckedChanged(object sender, EventArgs e)
        {
            if (Manage_Processcards.IsProcesscardUnderManagement == false)
                return;
            tb_Validerade_Loter.Enabled = true;
            if (tb_Validerade_Loter.Text == "N/A")
                tb_Validerade_Loter.Text = string.Empty;
            
            if (lbl_RevNr.Text.Length == 0)
                lbl_RevNr.Text = string.Empty;
            if (lbl_QA_Sign.Text == "N/A")
                lbl_QA_Sign.Text = string.Empty;
        }
        public void HistoriskaData_CheckedChanged(object sender, EventArgs e)
        {
            if (Manage_Processcards.IsProcesscardUnderManagement == false)
                return;
            tb_Validerade_Loter.Enabled = false;
            tb_Validerade_Loter.Text = "N/A";
            lbl_RevNr.Enabled = true;
            if (lbl_RevNr.Text.Length == 0)
                lbl_RevNr.Text = string.Empty;
            if (lbl_QA_Sign.Text == "N/A")
                lbl_QA_Sign.Text = string.Empty;
        }
        private void QA_Sign_Click(object sender, EventArgs e)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ApproveProcessCard) == false)
               return;
            if (!string.IsNullOrEmpty(lbl_QA_Sign.Text))
            {
                InfoText.Show(LanguageManager.GetString("processcardAlreadySigned"), CustomColors.InfoText_Color.Ok, "Warning!");
                return;
            }

            var black = new BlackBackground(string.Empty, 80);
            var password = new PasswordManager(LanguageManager.GetString("signProcesscardPassword"));
            black.Show();
            password.ShowDialog();
            black.Close();
            if (password.IsOk == false)
                return;

            var qa_sign = Person.Sign + "/" + Person.EmployeeNr;
            lbl_QA_Sign.Text = qa_sign;
            var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
            var formattedDate = DateTime.Now.ToString($"{dateTimeFormat.ShortDatePattern}", CultureInfo.CurrentCulture);
            lbl_ApprovedDate.Text = formattedDate;
            ApproveProcesscard(qa_sign, DateTime.Now, Order.PartID, true);
        }
        private void UpprättatAv_Sign_AnstNr_Click(object sender, EventArgs e)
        {
            if (Manage_Processcards.IsProcesscardUnderManagement == false)
                return;
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageProcesscards) == false)
                return;
            var password = new PasswordManager(LanguageManager.GetString("signProcesscardPassword"));
            password.ShowDialog();
            if (password.IsOk == false)
                return;
            lbl_UpprättatAv_Sign_AnstNr.Text = Person.Sign + "/" + Person.EmployeeNr;
        }

        private void RevNr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Manage_Processcards.IsProcesscardUnderManagement)
                {
                    Manage_Processcards.IsUpdateProcesscard = false;
                    lbl_QA_Sign.Text = string.Empty;
                    lbl_ApprovedDate.Text = string.Empty;
                    lbl_RevNr.Text = ControlValidator.Next_Letter(lbl_RevNr.Text, true);
                }
                else
                {
                    var black = new BlackBackground(string.Empty, 60);
                    var rev = new RevisionInfo();
                    black.Show();
                    rev.ShowDialog();
                    black.Close();
                }
            }
            else
            {
                if (Manage_Processcards.IsProcesscardUnderManagement)
                {
                    Manage_Processcards.IsUpdateProcesscard = false;
                    lbl_UpprättatAv_Sign_AnstNr.Text = string.Empty;
                    lbl_QA_Sign.Text = string.Empty;
                    lbl_ApprovedDate.Text = string.Empty;
                    if (lbl_RevNr.Text != "A")
                        lbl_RevNr.Text = ControlValidator.Next_Letter(lbl_RevNr.Text, false);
                    
                }
            }
        }

        private void ProcesscardBasedOn_MouseClick(object sender, EventArgs e)
        {
            var parentControl = this.Parent;
            while (!(parentControl is MainProtocol) && parentControl != null)
                parentControl = parentControl.Parent;

            if (!(parentControl is MainProtocol form)) 
                return;
            if (form.tlp_Main.ColumnStyles[1].Width > 450)
                form.Hide_ExtraControls();
            else
                form.Show_ProcesscardBasedOn();
        }

        
    }
}

