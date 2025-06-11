using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.LineClearance;
using DigitalProductionProgram.Protocols.Protocol;

namespace DigitalProductionProgram.Protocols.MainInfo
{
    public partial class MainInfo_B : UserControl
    {
        public static List<string?> List_ProdType(string tabell)
        {
            var list = new List<string?>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"SELECT DISTINCT ProdType FROM {tabell} WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL)";

                var cmd = new SqlCommand(query, con);
                SQL_Parameter.String(cmd.Parameters, "@workoperation", Order.WorkOperation.ToString());
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!Equipment.Equipment.Blacklist_Utrustning.Contains(reader["ProdType"].ToString()))
                        list.Add(reader[0].ToString());
                }
            }
            return list;

        }

        public MainInfo_B()
        {
            InitializeComponent();
            Add_Events_To_Controls();
        }


        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[]{label_Customer, label_ProdType, label_PartNumber, label_OrderNr, label_Length });
        }
        public void Hide_Measurepoints()
        {
            label_ID.Visible = ID.Visible = label_OD.Visible = OD.Visible = label_Length.Visible = LENGTH.Visible = label_W.Visible = WALL.Visible = label_ProdType.Visible = ProdType.Visible = false;
        }
        public void Load_Data(int? OrderID)
        {
            Room_TempMoisture.Load_Data();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT OrderNr, PartNr, ProdType, Customer, Rum_Temp, Rum_Fukt FROM [Order].MainData WHERE OrderID = @id";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", OrderID);
                var reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {
                        lbl_OrderNr.Text = reader["OrderNr"].ToString();
                        lbl_ArtikelNr.Text = reader["PartNr"].ToString();
                        ProdType.Text = reader["ProdType"].ToString();
                        lbl_Customer.Text = reader["Customer"].ToString();
                    }
                }
            }

            string[] codetext = {"ID", "OD", "WALL", "LENGTH"};
            TextBox[] tboxes = {ID, OD, WALL, LENGTH};
            var ctr = 0;
            foreach (var text in codetext)
            {
                
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT value                         
                        FROM [Order].Data
                        WHERE OrderID = @id
                        AND ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE codetext = @codetext) ";

                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", OrderID);
                    cmd.Parameters.AddWithValue("@codetext", text);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                    {
                        if (double.TryParse(value.ToString(), out var dblValue))
                            tboxes[ctr].Text = dblValue.ToString();
                    }
                    else
                        tboxes[ctr].Text = string.Empty;
                }

                ctr++;
            }

            if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols)
                return;
            if (string.IsNullOrEmpty(ProdType.Text) || ProdType.Text == "N/A")
                ProdType.Enabled = true;
            else
                ProdType.Enabled = false;
        }
      
        public static void INSERT_Measurepoints_Korprotokoll()
        {
            //Om mätpunkter finns så hämtas det här från Monitor och lägger till det i Körprotokollet automatiskt
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                                INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, value, textvalue)
                                VALUES 
                                (@orderID, (SELECT id FROM Protocol.Description WHERE CodeText = 'ID'), @id, NULL),
                                (@orderID, (SELECT id FROM Protocol.Description WHERE CodeText = 'OD'), @od, NULL),
                                (@orderID, (SELECT id FROM Protocol.Description WHERE CodeText = 'WALL'), @wall, NULL),
                                (@orderID, (SELECT id FROM Protocol.Description WHERE CodeText = 'LENGTH'), @length, NULL)";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderID", Order.OrderID);

                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_FEP:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                    case Manage_WorkOperation.WorkOperations.Extrusion_HS:
                    case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                    case Manage_WorkOperation.WorkOperations.Hackning_PTFE:
                    case Manage_WorkOperation.WorkOperations.Hackning_PUR_IV:
                        SQL_Parameter.Double(cmd.Parameters, "@id", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.ID, "NOM").ToString());
                        SQL_Parameter.Double(cmd.Parameters, "@od", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.OD, "NOM").ToString());
                        SQL_Parameter.Double(cmd.Parameters, "@wall", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "NOM").ToString());
                        SQL_Parameter.Double(cmd.Parameters, "@length", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Length, "NOM").ToString());
                        break;

                    case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
                    case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
                    case Manage_WorkOperation.WorkOperations.Synergy_PTFE:
                        SQL_Parameter.Double(cmd.Parameters, "@id", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.MainBodyID, "NOM").ToString());
                        SQL_Parameter.Double(cmd.Parameters, "@od", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.MainBodyOD, "NOM").ToString());
                        SQL_Parameter.Double(cmd.Parameters, "@wall", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.Wall, "NOM").ToString());
                        SQL_Parameter.Double(cmd.Parameters, "@length", MeasurePoints.Value(MeasurePoints.CodeTextMonitor.MainBodyLength, "NOM").ToString());
                        break;
                }
                
                cmd.ExecuteNonQuery();
            }
        }
        public static void UPDATE_Value_Korprotokoll(string codetext, string? value)
        {
            if (Module.IsOkToSave == false)
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                                UPDATE [Order].Data SET Value = @value
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = (SELECT ID from Protocol.Description WHERE CodeText = @codetext)";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@codetext", codetext);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);
                cmd.ExecuteNonQuery();
            }
        }
        public static void UPDATE_TextValue_Korprotokoll(string codetext, string? textvalue)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                                UPDATE [Order].Data SET TextValue = @textvalue
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = (SELECT ID from Protocol.Description WHERE CodeText = @codetext)";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@codetext", codetext);
                SQL_Parameter.Double(cmd.Parameters, "@value", textvalue);
                cmd.ExecuteNonQuery();
            }
        }

        private void Add_Events_To_Controls()
        {
            Control[] control = { ID, OD, WALL, LENGTH };
            foreach (var ctrl in control)
            {
                ctrl.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
                ctrl.DoubleClick += Public_Events.ctrl_NA_DoubleClick;
            }
            control = new Control[] { ProdType };
            foreach (var ctrl in control)
            {
                ctrl.TextChanged += ControlManager.Save.Protocol_Main;
                ctrl.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
                ctrl.DoubleClick += Public_Events.ctrl_NA_DoubleClick;
            }

            TextBox[] textBox = { ID, OD, WALL, LENGTH };
            foreach (var tb in textBox)
                tb.KeyPress += Public_Events.Only_Decimal_KeyPress;

           
        }
        
        private void ID_OD_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(ID.Text, out var id) && double.TryParse(OD.Text, out var od))
            {
                if (id > od)
                    MessageBox.Show("Kontrollera att du skrivit rätt, ID är nu större än OD.", "Varning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void ProdType_Click(object sender, EventArgs e)
        {
            if (Browse_Protocols.Browse_Protocols.Is_BrowsingProtocols)
                return;
            var choose = new Choose_Item(List_ProdType("[Order].MainData"), new Control[] { ProdType }, false, true);
            choose.ShowDialog();
        }

        private void Value_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            UPDATE_Value_Korprotokoll(tb.Name, tb.Text);
        }
      
    }
}
