using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    public partial class MainInfo_C : UserControl
    {
        public static bool Is_TempKalibChecked
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    //ProtocolDescriptionID 162 = TempKalibCheck
                    var query = "SELECT boolvalue FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 162";
                    var IsTempChecked = false;
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        bool.TryParse(value.ToString(), out IsTempChecked);

                    return IsTempChecked;
                }
            }
        }



        public MainInfo_C()
        {
            InitializeComponent();
        }
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_Customer, label_Amount, label_PartNumber, label_ProdType, chb_TempKalibCheck });
        }
        public void Load_Data(int? OrderID)
        {
            Translate_Form();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT OrderNr, PartNr, ProdType, Customer, Amount FROM [Order].MainData WHERE OrderID = @orderid";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", OrderID);
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        lbl_OrderNr.Text = reader["OrderNr"].ToString();
                        lbl_ArtikelNr.Text = reader["PartNr"].ToString();
                        lbl_ProdType.Text = reader["ProdType"].ToString();
                        lbl_Customer.Text = reader["Customer"].ToString();
                        lbl_Antal.Text = reader["Amount"].ToString();
                    }
                }
                chb_TempKalibCheck.Checked = Is_TempKalibChecked;
            }
        }
        private void TempKalibCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (Module.IsOkToSave == false)
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    IF NOT EXISTS (SELECT * FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText = 'TempKalibCheck'))
                        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, Ugn, Value, TextValue, BoolValue)
                        VALUES(@orderid, (SELECT ID FROM Protocol.Description WHERE CodeText = 'TempKalibCheck'), @uppstart, @ugn, @value, @textvalue, @boolvalue)
                    ELSE
                        UPDATE [Order].Data
                        SET boolvalue = @boolvalue
                        WHERE OrderID = @orderid AND ProtocolDescriptionID = (SELECT ID FROM Protocol.Description WHERE CodeText = 'TempKalibCheck')";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                cmd.Parameters.AddWithValue("@ugn", DBNull.Value);
                cmd.Parameters.AddWithValue("@value", DBNull.Value);
                cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                cmd.Parameters.AddWithValue("@boolvalue", chb_TempKalibCheck.Checked);
                cmd.ExecuteNonQuery();
            }
        }


    }
}
