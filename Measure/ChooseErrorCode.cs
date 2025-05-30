using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Measure
{
    public partial class ChooseErrorCode : Form
    {
        private string errorCode { get; set; }
        private string comment { get; set; }
        public string ErrorCode
        {
            get => errorCode;
            set => errorCode = value;
        }
        public string Comment
        {
            get => comment;
            set => comment = value;
        }
        

        public ChooseErrorCode()
        {
            InitializeComponent();
            Translate_Form();

            Fill_ErrorCodes();

            
        }


        private void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{ label_ErrorCodeHeader_1, label_ErrorCodeHeader_2, label_ErrorDiscard, label_ErrorExit });
        }
        private void Fill_ErrorCodes()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = "SELECT Felkod, Beskrivning FROM MeasureProtocol.ErrorCodes WHERE Grupp = @grupp ORDER BY Felkod";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@grupp", Order.WorkOperation.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                    cb_ErrorCode.Items.Add($"{reader[0]} - {reader[1]}");
            }
        }
        private void ErrorCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_ErrorDiscard.Text = LanguageManager.GetString(label_ErrorDiscard.Name);
            ErrorCode = cb_ErrorCode.Text;
            tb_Comments.MaxLength = 63 - $"{LanguageManager.GetString("discardedMeasurement_Info_1")}".Length;
        }

        private void Discard_Click(object sender, EventArgs e)
        {
            Comment = tb_Comments.Text;
            if (string.IsNullOrEmpty(Comment))
            {
                InfoText.Show(LanguageManager.GetString("measureprotocol_Info_11"), CustomColors.InfoText_Color.Warning, null);
                return;
            }

            if (cb_ErrorCode.SelectedIndex > -1)
                Close();
            else
                InfoText.Show(LanguageManager.GetString("measureprotocol_Info_4"), CustomColors.InfoText_Color.Warning, null);
        }

        private void Abort_Click(object sender, EventArgs e)
        {
            errorCode = null;
            comment = null;
            Close();
        }
    }
}
