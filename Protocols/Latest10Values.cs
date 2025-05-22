using System;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.User;

// ReSharper disable All

namespace DigitalProductionProgram.Protocols
{
    public partial class Latest10Values : Form
    {
        private readonly string kolumn;
        private readonly string codetext;
        private int width;
        private int ctr;


        private string query
        {
            get
            {
               return $@"
                            SELECT TOP (10) Date_Start, value, textvalue
                            FROM [Order].MainData AS main
	                            INNER JOIN [Order].Data as valuess
		                            ON main.OrderID = valuess.OrderID
                            WHERE main.PartID = @partid AND EXISTS
	                            (SELECT * FROM [Order].MainData WHERE PartID = @partid
		                            AND main.OrderID = valuess.OrderID) 
	                            AND ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = @codetext)
                            ORDER BY main.Date_Start DESC";
            }
        }


        public Latest10Values(string ctrlName, int Maskin, int Uppstart)
        {
            InitializeComponent();
            LanguageManager.TranslationHelper.TranslateControls(label_Latest10Values_Info);

            kolumn = ctrlName;
            codetext = ctrlName;
            label_Header.Text = this.kolumn;
            Load_Data_From_Databas();
            Initalize_Form();
            _ = Activity.Stop($"{Person.Name} har tittat på 10 senaste körningar på orderNr {Order.OrderNumber}");
        }

        private void Load_Data_From_Databas()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                if (string.IsNullOrEmpty(query))
                {
                    Mail.Inform_SuperAdmin_Error($"Error - Senaste Körningar: query is null or Empty <br /> ArbetsOperation = {Order.WorkOperation}");
                    return;
                }
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", Order.PartNumber);
                cmd.Parameters.AddWithValue("@partID", Order.PartID);
                cmd.Parameters.AddWithValue("@codetext", codetext);
                
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime.TryParse(reader[0].ToString(), out DateTime date);
                    Add_Label(ctr, 36, date.ToString("yyyy-MM-dd"), Color.Teal);
                    string value = reader[1].ToString();
                    if (string.IsNullOrEmpty(value))
                        value = reader[2].ToString();
                    Add_Label(ctr, 66, value, Color.Black);
                    ctr++;
                }
            } 
        }
        private void Initalize_Form()
        {
            this.Width = width + 20;
        }

        private void Add_Label(int left_Point, int top_Point, string value, Color clr)
        {
            Label lbl = new Label
            {
                AutoSize = true,
                ForeColor = clr,
                Top = top_Point,
                Left = 20 + (left_Point * 100),
                Text = value
            };
            width += lbl.Width/2;

            panel_MainForm.Controls.Add(lbl);
        }

        private void panel_MainForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
