using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SkiaSharp.HarfBuzz.SKShaper;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_AQL : UserControl
    {
        public static double Påsar_mellan_prov(string startpåse, string slutpåse, string antal, string antalProver)
        {
            return Antal_Påsar(startpåse, slutpåse, antal) / (Antal_Prover(antalProver) - 1);
        }

        public static int Antal_Mätningar_OrderNr
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT TOP(1) Påse_Spole FROM  WHERE OrderID = @orderid
                        ORDER BY Påse_Spole DESC";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);

                var value = cmd.ExecuteScalar();
                if (value != null)
                    return (int)cmd.ExecuteScalar();
                return 1;
            }
        }
        public static int Antal_Totalt(string antal)
        {
            int.TryParse(antal, out var antal_Totalt);
            return antal_Totalt;
        }
        public static int AQL_Provuttag
        {
            get
            {
                if (string.IsNullOrEmpty(Order.PartNumber))
                    return 0;
                return Order.Amount < 35001 ? 13 : 50;
            }
        }
        public static double Antal_Påsar(string startpåse, string slutpåse, string antal)
        {
            return SlutPåse(slutpåse, antal) - StartPåse(startpåse) + 1;
        }
        public static double StartPåse(string startPåse)
        {
            if (string.IsNullOrEmpty(startPåse))
            {
                return 1;
            }

            return double.Parse(startPåse);
        }
        public static double SlutPåse(string slutpåse, string antal)
        {
            if (string.IsNullOrEmpty(slutpåse))
            {
                if (TotalAmountPerSpoolBag > 0)
                {
                    return Antal_Totalt(antal) / TotalAmountPerSpoolBag;
                }

                return 0;
            }

            double.TryParse(slutpåse, out var slutPåse);
            return slutPåse;
        }
        public static int Antal_Prover(string antalProver)
        {
            return string.IsNullOrEmpty(antalProver) ? AQL_Provuttag : int.Parse(antalProver);
        }
        public static int TotalAmountPerSpoolBag
        {
            get
            {
                if (string.IsNullOrEmpty(Order.OrderNumber) || string.IsNullOrEmpty(Order.PartNumber) || Order.OrderID is null)
                    return 0;

                int antal_per_Påse_Spole = 0;

                switch (Order.WorkOperation)
                {
                    case Manage_WorkOperation.WorkOperations.Extrudering_Termo:
                    case Manage_WorkOperation.WorkOperations.Extrudering_Tryck:
                        antal_per_Påse_Spole = Database.ExecuteSafe(con =>
                        {
                            var query = "SELECT Value FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 238";
                            using var cmd = new SqlCommand(query, con);
                            ServerStatus.Add_Sql_Counter();
                            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                            var value = cmd.ExecuteScalar();
                            if (value != null)
                            {
                                var match = Regex.Match(value.ToString() ?? "", @"\d+").Value;
                                return int.TryParse(match, out var result) ? result : 0;
                            }
                            return 0;
                        });

                        if (antal_per_Påse_Spole == 0)
                        {
                            antal_per_Påse_Spole = Database.ExecuteSafe(con =>
                            {
                                var query = @"
                            SELECT Value
                            FROM Processcard.Data 
                            WHERE PartID = @partid
                                AND TemplateID = (SELECT Id FROM Protocol.Template WHERE FormTemplateID = 34 AND revision = (SELECT ProtocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid) AND ProtocolDescriptionID = 238)";
                                using var cmd = new SqlCommand(query, con);
                                ServerStatus.Add_Sql_Counter();
                                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                                var value = cmd.ExecuteScalar();
                                return value != null && int.TryParse(value.ToString(), out var result) ? result : 0;
                            });
                        }
                        break;

                    case Manage_WorkOperation.WorkOperations.Krympslangsblåsning:
                        antal_per_Påse_Spole = Database.ExecuteSafe(con =>
                        {
                            var query = "SELECT Value FROM [Order].Data WHERE OrderID = @orderid AND ProtocolDescriptionID = 72";
                            using var cmd = new SqlCommand(query, con);
                            ServerStatus.Add_Sql_Counter();
                            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                            var value = cmd.ExecuteScalar();
                            return value != null && int.TryParse(value.ToString(), out var result) ? result : 0;
                        });

                        if (antal_per_Påse_Spole == 0)
                        {
                            antal_per_Påse_Spole = Database.ExecuteSafe(con =>
                            {
                                var query = @"
                            SELECT Value FROM Processcard.Data 
                            WHERE PartID = @partid 
                                AND TemplateID = (SELECT Id FROM Protocol.Template WHERE FormTemplateID = @formtemplateid AND revision = (SELECT ProtocolTemplateRevision FROM [Order].MainData WHERE OrderID = @orderid) AND ProtocolDescriptionID = 72)";
                                using var cmd = new SqlCommand(query, con);
                                ServerStatus.Add_Sql_Counter();
                                SQL_Parameter.NullableINT(cmd.Parameters, "@partid", Order.PartID);
                                cmd.Parameters.AddWithValue("@formtemplateid", 35);
                                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                                var value = cmd.ExecuteScalar();
                                return value != null && int.TryParse(value.ToString(), out var result) ? result : 0;
                            });
                        }
                        break;

                    case Manage_WorkOperation.WorkOperations.Hackning_TEF:
                        antal_per_Påse_Spole = Database.ExecuteSafe(con =>
                        {
                            var query = @"
                        SELECT value FROM [Order].Data 
                        WHERE OrderID = @orderid
                        AND ProtocolDescriptionID = (SELECT id FROM Protocol.Description WHERE CodeText = 'ANTAL/PÅSE')";
                            using var cmd = new SqlCommand(query, con);
                            ServerStatus.Add_Sql_Counter();
                            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                            var value = cmd.ExecuteScalar();
                            return value != null && int.TryParse(value.ToString(), out var result) ? result : 0;
                        });
                        break;
                }

                return antal_per_Påse_Spole;
            }
        }


        public static int Get_Row_dgv_ProvInfo(DataGridView dgv)
        {
            var antal_Mätningar = Antal_Mätningar_OrderNr;
            for (var i = 0; i < dgv.Rows.Count; i++)
            {
                if (antal_Mätningar < int.Parse(dgv.Rows[i].Cells[0].Value.ToString()))
                {
                    if (i == 0)
                        return 0;
                    return i - 1;
                }
            }
            return 0;
        }

        public Main_OrderInformation orderInformation;


        public Main_AQL()
        {
            InitializeComponent();
            dgv_ProvInfo_Påsar.AllowUserToAddRows = true;
            orderInformation = new Main_OrderInformation();
            tb_AntalProver.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            tb_SlutPåse.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
            tb_StartPåse.KeyDown += Public_Events.Enter_To_TAB_KeyDown;
        }

        public void Change_Theme()
        {
            BackColor = Teman.backColor_ExtraInfo;
            Teman.IterateThroughControls(tlp_ProvInfo, Teman.foreColor_ExtraInfo);
        }
        public void ClearData()
        {
            tb_StartPåse.Text = string.Empty;
            tb_SlutPåse.Text = string.Empty;
            tb_AntalProver.Text = string.Empty;
            lbl_AntalPåsar.Text = string.Empty;
            lbl_PåsarMellanProv.Text = string.Empty;
            dgv_ProvInfo_Påsar.DataSource = null;
        }
        public void Initialize_QC_ProvuttagInfo()
        {
            //Visible = CheckAuthority.Is_OkToShowObject;
            timer_Update_ProvuttagInfo.Start();

            int steps;

            tb_StartPåse.Text = $"{StartPåse(tb_StartPåse.Text)}";
            if (TotalAmountPerSpoolBag > 0 && SlutPåse(tb_SlutPåse.Text, tb_AntalProver.Text) > 0)
                tb_SlutPåse.Text = $"{SlutPåse(tb_SlutPåse.Text, tb_AntalProver.Text)}";
            else if (string.IsNullOrEmpty(tb_SlutPåse.Text) || SlutPåse(tb_SlutPåse.Text, tb_AntalProver.Text) == 0)
                tb_SlutPåse.Text = "N/A";

            tb_AntalProver.Text = $"{Antal_Prover(tb_AntalProver.Text)}";
            lbl_AntalPåsar.Text = $"{Antal_Påsar(tb_StartPåse.Text, tb_SlutPåse.Text, orderInformation.lbl_Antal.Text)}";
            
            if (Math.Round(Påsar_mellan_prov(tb_StartPåse.Text, tb_SlutPåse.Text, orderInformation.lbl_Antal.Text, tb_AntalProver.Text), 1) > 1)
            {
                lbl_PåsarMellanProv.Text = $"{Math.Round(Påsar_mellan_prov(tb_StartPåse.Text, tb_SlutPåse.Text, orderInformation.lbl_Antal.Text, tb_AntalProver.Text), 1)}";
                label_ProvuttagsInfo_PåsarMellanProv.Text = "Påsar mellan varje prov:";
            }
            else
            {
                label_ProvuttagsInfo_PåsarMellanProv.Text = "Provuttag / Påse:";
                lbl_PåsarMellanProv.Text = $"{Math.Round(Antal_Prover(tb_AntalProver.Text) / Antal_Påsar(tb_StartPåse.Text, tb_SlutPåse.Text, orderInformation.lbl_Antal.Text), 1)}";
            }

            //Fyller upp listan när prover skall tas ut
            dgv_ProvInfo_Påsar.DataSource = null;

            var dt = new DataTable();
            dt.Columns.Add();

            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink))
                steps = Antal_Prover(tb_AntalProver.Text) / 3;
            else
                steps = Antal_Prover(tb_AntalProver.Text);
           


            if (int.TryParse(tb_SlutPåse.Text, out var value) && value > 0)
            {
                dgv_ProvInfo_Påsar.Visible = true;
                for (var i = 1; i < steps; i++)
                {
                    var bag = StartPåse(tb_StartPåse.Text) + i * Påsar_mellan_prov(tb_StartPåse.Text, tb_SlutPåse.Text, orderInformation.lbl_Antal.Text, tb_AntalProver.Text);
                    bag = Math.Floor(bag - Påsar_mellan_prov(tb_StartPåse.Text, tb_SlutPåse.Text, orderInformation.lbl_Antal.Text, tb_AntalProver.Text));
                    if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.ManufacturesHeatShrink))
                        bag *= 3;

                    if (bag < 1)
                        bag = 1;

                    dt.Rows.Add(bag);
                }

                dt.Rows.Add(SlutPåse(tb_SlutPåse.Text, tb_AntalProver.Text));
                dgv_ProvInfo_Påsar.DataSource = dt;
                dgv_ProvInfo_Påsar.AllowUserToAddRows = false;

                dgv_ProvInfo_Påsar.FirstDisplayedScrollingRowIndex = Get_Row_dgv_ProvInfo(dgv_ProvInfo_Påsar);
                dgv_ProvInfo_Påsar.Rows[0].Selected = false;
                if (Get_Row_dgv_ProvInfo(dgv_ProvInfo_Påsar) + 1 < dgv_ProvInfo_Påsar.Rows.Count && Get_Row_dgv_ProvInfo(dgv_ProvInfo_Påsar) > 0)
                    dgv_ProvInfo_Påsar.Rows[Get_Row_dgv_ProvInfo(dgv_ProvInfo_Påsar) + 1].Selected = true;
                else
                    dgv_ProvInfo_Påsar.Rows[0].Selected = true;
            }
            else
                dgv_ProvInfo_Påsar.Visible = false;
        }

        private void Info_Provuttagsinfo_Click(object sender, EventArgs e)
        {
            Points.Add_Points(1, "Klickat på Infoknapp Provuttagsinfo");
            InfoText.Show("Detta är ett hjälpmedel för att visa när du skall göra ett provuttag.\n" +
                          "Programmet föröker hämtar information automatiskt, vid behov kan du ändra i dom gula rutorna.\n" +
                          "Till höger om rutorn finns en lista på vilken påse/spole du skall ta prov från.\n" +
                          "Programmet väljer automatiskt i listan vilken påse/spole du ska ta QC-prov från.\n" +
                          "Om det står N/A i rutan SlutPåse beror det på att Antal/Spole på processkortet är tomt.",
                CustomColors.InfoText_Color.Info, "Provuttag");
        }

        private void ProvInfo_Leave(object sender, EventArgs e)
        {
            Initialize_QC_ProvuttagInfo();
        }
        private void ProvInfo_Enter(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            tb.SelectAll();
        }
        private void timer_Update_ProvuttagInfo_Tick(object sender, EventArgs e)
        {
            Initialize_QC_ProvuttagInfo();
        }
    }
}
