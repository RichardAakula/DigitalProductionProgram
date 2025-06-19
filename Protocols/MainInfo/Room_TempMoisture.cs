using DigitalProductionProgram.DatabaseManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    public partial class Room_TempMoisture : UserControl
    {
        public Room_TempMoisture()
        {
            InitializeComponent();
            Add_Events_To_Controls();
        }

        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { label_RoomTempMoist });
        }

        private void Add_Events_To_Controls()
        {
            var control = new Control[] { Rum_Fukt, Rum_Temp };
            foreach (var ctrl in control)
            {
                ctrl.TextChanged += ControlManager.Save.Protocol_Main;
                ctrl.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            }
            var textBox = new[] { Rum_Fukt, Rum_Temp };
            foreach (var tb in textBox)
                tb.KeyPress += Public_Events.Only_Decimal_KeyPress;
        }

        public void Load_Data()
        {

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT Rum_Temp, Rum_Fukt FROM [Order].MainData WHERE OrderID = @id";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        Rum_Temp.Text = reader["Rum_Temp"].ToString();
                        Rum_Fukt.Text = reader["Rum_Fukt"].ToString();
                    }
                }
            }
        }

        private void ValidateData_Leave(object sender, EventArgs e)
        {
            if (Module.IsOkToSave == false)
                return;
            var tb = (TextBox)sender;
            if (LineClearance.LineClearance.IsLineClearanceDone == false)
            {
                InfoText.Show(LanguageManager.GetString("lineClearance_Info_2"), CustomColors.InfoText_Color.Warning, "Warning!", this);
                tb.Clear();
                return;
            }
            double.TryParse(Rum_Fukt.Text, out var fukt);
            double.TryParse(Rum_Temp.Text, out var temp);
            if (double.TryParse(tb.Text, out _))
            {
                string? message;
                double value;
                double valueMax;
                if (tb.Name == "Rum_Temp")
                {
                    message = "Är du säker på att det är över 30° i rummet?";
                    value = temp;
                    valueMax = 30;
                }
                else
                {
                    message = "Är du säker på att det är över 100% luftfuktighet i rummet?";
                    value = fukt;
                    valueMax = 100;
                }

                if (value > valueMax)
                {
                    InfoText.Show(message, CustomColors.InfoText_Color.Info, "Warning!", this);
                    tb.SelectAll();
                }
            }
            else
                tb.Clear();

        }
    }
}
