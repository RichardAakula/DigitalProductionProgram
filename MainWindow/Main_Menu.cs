using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Processcards;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.QC;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.ToolManagement;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using DigitalProductionProgram.Statistics;
using Activity = DigitalProductionProgram.Log.Activity;
using Color = System.Drawing.Color;
using ProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_Menu : UserControl
    {

        private const string RtfColor_Date = @"\red255\green255\blue255;";   // Vit
        private const string RtfColor_Header = @"\red100\green200\blue255;";   // Ljusblå
        private const string RtfColor_Name = @"\red150\green255\blue150;";   // Ljusgrön
        private const string RtfColor_Message = @"\red200\green200\blue200;";  // Grå


        public Main_Form mainForm;

        public Main_Menu()
        {
            InitializeComponent();
        }

        public void Change_Theme()
        {
            Menu_Arkiv.ForeColor = Menu_Order.ForeColor = Menu_Protocol.ForeColor = Menu_Equipment.ForeColor = Menu_User.ForeColor = Menu_Settings.ForeColor = Menu_Themes.ForeColor = Menu_Help.ForeColor = Menu_Developer.ForeColor = Teman.foreColor_Menu;
        }
        public void Unlock_Menu()
        {
            Menu_Order_EditOrder.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.EditOrder, false);
            Menu_Order_DeleteOrder.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.DeleteOrder, false);
            Menu_Order_ReportProblemProductionSupport.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ReportToProductionSupport, false);
            Menu_Order_CreateTestOrder.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.CreateTestOrder, false);
            Menu_Developer.Visible = CheckAuthority.IsOkShowDeveloperMenu;
            Menu_User_CheckMyAnalysis.Visible = CheckAuthority.IsFactoryAuthorized(CheckAuthority.TemplateFactory.MyAnalysis);
            Menu_Protocol_ManageTemplates.Visible = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageTemplates, false);
            Menu_Arkiv_ManageDatabase.Visible = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeDatabaseSettings, false);
        }
        public void Lock_Menu()
        {
            Menu_Developer.Visible = false;
            Menu_Order_EditOrder.Enabled = false;
            Menu_Order_ReportProblemProductionSupport.Enabled = false;
            // Menu_Arkiv_ManageDatabase.Enabled = false;
            Menu_Order_DeleteOrder.Enabled = false;
            Menu_Protocol_Unlock_ValidatedProcesscard.Enabled = false;
        }
        public void Unlock_Korprotokoll_Menu()
        {
            if (CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.UsingCandleFilter_Screenpackage))
            {
                Menu_Equipment.Visible = false;
                Menu_Settings_CalculateMaterial.Visible = false;
            }

            Menu_Equipment.Visible = true;
            Menu_Settings_CalculateMaterial.Visible = true;
            Menu_Equipment_UseFilter.Enabled = true;
            Menu_Equipment_UseSilpaket.Enabled = true;

            if (Equipment.Equipment.Is_Filterhus_Used_No_Processcard)
            {
                Menu_Equipment_UseFilter.Checked = true;
                Menu_Equipment_UseSilpaket.Checked = false;
            }
            else
            {
                Menu_Equipment_UseFilter.Checked = false;
                Menu_Equipment_UseSilpaket.Checked = true;
            }

            if (!string.IsNullOrEmpty(Order.RevNr))
            {
                Menu_Equipment_UseFilter.Enabled = false;
                Menu_Equipment_UseSilpaket.Enabled = false;
            }
        }
        public void Change_GUI_Mätdator()
        {
            Menu_Order.Enabled = false;

            Menu_Arkiv_NewOrder.Enabled = false;
            Menu_Arkiv_Preview.Enabled = false;
            Menu_Arkiv_Print.Enabled = false;
        }
        public void Change_GUI_OrderNotFinished()
        {
            var menus = new[] { Menu_Order, Menu_Protocol, Menu_User, Menu_Settings, Menu_Themes };
            foreach (var menu in menus)
                menu.Enabled = true;
        }
        public void Change_GUI_OrderFinished()
        {
            menuStrip.ForeColor = Color.Black;
        }





        //----------ARKIV/FILE----------
        private void Menu_Arkiv_NyOrder_Click(object sender, EventArgs e)
        {
            ResetMainForm();
        }
        private void ResetMainForm()
        {
            Order.Clear_Order();
            mainForm.Clear_Mainform();
            mainForm.cf_OrderInformation.Clear();
            mainForm.cf_OrderInformation.tb_OrderNr.Focus();
            mainForm.cf_MeasurePoints.ClearMeasurePoints();
            mainForm.cf_MeasureStats.ClearData();
            mainForm.cf_OrderInformation.tb_OrderNr.Enabled = true;
            // mainForm.Change_Theme();
            mainForm.tlp_Left.BackColor = Color.Transparent;
            mainForm.BackColor = Color.FromArgb(25, 25, 25);

            mainForm.Change_GUI_StandardColor();
            Change_Theme();
            _ = Log.Activity.Stop("User Click New Order");
        }
        private void Menu_File_UpdateDPP_Click(object sender, EventArgs e)
        {
            if (File.Exists(Database.UpdatePath))
            {
                _ = Activity.Stop("User updated DPP via the menu");
                Maintenance.StartInstallation(false);
            }
            else
            {
                MessageBox.Show("Updater could not be found, please contact Admin.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Application.Exit(); // Closing DPP
        }
        private async void Menu_File_Öppna_Click(object sender, EventArgs e)
        {
            if (Main_Form.IsZumbachÖppet)
            {
                InfoText.Show("Du har Zumbachfönstret fortfarande öppet, stäng det före du försöker öppna en ny order.",
                    CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            var screen = Screen.FromPoint(Cursor.Position);

            using var frmÖppna = new Open_Order
            {
                StartPosition = FormStartPosition.Manual,
                Location = screen.Bounds.Location
            };

            frmÖppna.ShowDialog();
            if (Order.OrderNumber != null & frmÖppna.svarÖppna)
            {
                mainForm.cf_OrderInformation.cb_Operation.SelectedIndexChanged -= mainForm.Operation_SelectedIndexChanged;
                mainForm.cf_OrderInformation.tb_OrderNr.Text = Order.OrderNumber;
                mainForm.cf_OrderInformation.cb_Operation.Text = $"{Order.Operation} - {Order.Description}";
                mainForm.cf_OrderInformation.cb_Operation.SelectedIndex = -1; //Detta görs för att inte Order.Operation skall ändras vid metoden StartaOrder()
                mainForm.cf_OrderInformation.cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged;

                Menu_Order_OrderDone.Enabled = true;
                _ = mainForm.StartOrLoadOrder(true);
            }
        }
        private void Menu_File_Preview_Click(object sender, EventArgs e)
        {
            if (Print.IsPrinterInstalled)
            {
                // Stoppa MainTimer eventuellt om det blir problem
                Main_Form.Preview_PrintOut();
            }
            else
            {
                InfoText.Show("No printer installed", CustomColors.InfoText_Color.Bad, "Warning", this);
            }

        }
        private void Menu_File_Printout_Click(object sender, EventArgs e)
        {
            Order.Is_PrintOutCopy = true;
            mainForm.PrintOut();
        }
        private void Menu_File_ManageDatabase_Click(object sender, EventArgs e)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeDatabaseSettings) == false)
                return;
            using var database = new Database();
            database.ShowDialog();
            Application.Restart();
        }
        private void Menu_File_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //----------ORDER----------
        private void Menu_Order_FinishOrder_Click(object sender, EventArgs e)
        {
            Order.Finish.Order(mainForm);

            if (Person.Role == "SuperAdmin")
                ResetMainForm();
        }
        private void Menu_Order_EditOrder_Click(object sender, EventArgs e)
        {
            if (Order.OrderNumber != string.Empty && Order.IsOrderDone)
            {
                SaveData.UPDATE_Unlock_OrderDone();
                mainForm.BackColor = Color.FromArgb(25, 25, 25);
                _ = mainForm.StartOrLoadOrder(true);
                //mainForm.Open();
                Menu_Order_OrderDone.Enabled = true;
            }
            else
                InfoText.Show(Properties.Resources.editOrder, CustomColors.InfoText_Color.Bad, "Warning", this);
        }
        private void Menu_Order_DeleteOrder_ClickAsync(object sender, EventArgs e)
        {
            InfoText.Question($"{Properties.Resources.delete} \n\n" +
                              $"OrderNr {Order.OrderNumber}\n" +
                              $"Operation {Order.Operation}?", CustomColors.InfoText_Color.Warning, "Warning!", this);
            if (InfoText.answer != InfoText.Answer.Yes) return;
            if (!string.IsNullOrEmpty(Order.OrderNumber))
            {
                Activity.Start();
                Order.DELETE_Order();
                _ = Activity.Stop($"{Person.Name} Deleted Order {Order.OrderNumber} - Operation: {Order.Operation}");

                if (QC_Feedback.IsOperationHaveQCFeedback)
                    QC_Feedback.IncreaseRemainingViewsForOperation();

                mainForm.Clear_Mainform();

            }
            else
                InfoText.Show(Properties.Resources.deleteOrder_Info_1, CustomColors.InfoText_Color.Bad, "Warning", this);

            _ = Main_FilterQuickOpen.Load_ListAsync(mainForm.dgv_QuickOpen);
            mainForm.cf_PriorityPlanning.Load_PriorityPlanning();

        }
        private void Menu_Order_ReportToJira_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(Properties.Resources.reportJira_Info_1, CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }

            using var jira = new Jira();
            using var black = new BlackBackground("", 85);
            black.Show();
            jira.ShowDialog();
            black.Close();
        }
        private void Menu_Order_ReadProposedProcesscardChanges_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(Properties.Resources.orderNotOpen, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT Rubrik, Meddelande, Namn, Datum
                    FROM Processcard.ProposedChanges
                    WHERE OrderID = @orderid
                    ORDER BY Datum DESC;";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = Order.OrderID;
                using var reader = cmd.ExecuteReader();

                // Hantera både "<br>" och HTML-escaped "&lt;br&gt;"
                var brRegex = new Regex(@"(<br\s*/?>)|(&lt;br\s*/?&gt;)", RegexOptions.IgnoreCase | RegexOptions.Compiled);

                var rtf = new StringBuilder();

                // ANSI + codepage 1252 så å/ä/ö funkar utan \u-escape
                rtf.Append(@"{\rtf1\ansi\ansicpg1252\deff0");
                rtf.Append(@"{\colortbl ;");
                rtf.Append(RtfColor_Date); // 1 vit (datum)
                rtf.Append(RtfColor_Header); // 2 ljusblå (rubrik)
                rtf.Append(RtfColor_Name); // 3 ljusgrön (namn)
                rtf.Append(RtfColor_Message); // 4 grå  (meddelande)
                rtf.Append(@"}");

                while (reader.Read())
                {
                    var rubrik = reader["Rubrik"]?.ToString() ?? string.Empty;
                    rubrik = brRegex.Replace(rubrik, "\n").Replace("\r\n", "\n").Replace("\r", "");

                    var meddelande = reader["Meddelande"]?.ToString() ?? string.Empty;
                    meddelande = brRegex.Replace(meddelande, "\n").Replace("\r\n", "\n").Replace("\r", "").Trim('\n');

                    var namn = reader["Namn"]?.ToString() ?? string.Empty;
                    var datum = reader["Datum"]?.ToString() ?? string.Empty;

                    // DATUM – vit
                    rtf.Append(@"\cf1\b[");
                    rtf.Append(EscapeRtf(datum));
                    rtf.Append(@"]\b0\line\pard");


                    // RUBRIK – ljusblå (med radbrytningar via \line mellan escapade delar)
                    rtf.Append(@"\pard\cf2");
                    {
                        var parts = rubrik.Split('\n');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            rtf.Append(EscapeRtf(parts[i]));
                            if (i < parts.Length - 1)
                                rtf.Append(@"\line ");
                        }
                    }
                    rtf.Append(@"\b0\line\line");
                    // MEDDELANDE – grå
                    rtf.Append(@"\cf4\tab(");
                    {
                        var parts = meddelande.Split('\n');
                        for (int i = 0; i < parts.Length; i++)
                        {
                            rtf.Append(EscapeRtf(parts[i]));
                            if (i < parts.Length - 1) rtf.Append(@"\line");
                        }
                    }
                    rtf.Append(@")\line");

                    // NAMN – ljusgrön
                    rtf.Append(@"\cf3\b -");
                    rtf.Append(EscapeRtf(namn));
                    rtf.Append(@"\b0\line\line");
                }

                rtf.Append("}");

                _ = Activity.Stop("User checks suggested changes for the Process card");
                InfoText.Show(rtf.ToString(), CustomColors.InfoText_Color.Info, Properties.Resources.processcard_SuggestedChanges, this);
            });
        }

        private void Menu_Order_CreateTestOrder_Click(object sender, EventArgs e)
        {
            var org_OrderNr = Order.OrderNumber;
            using var c_to = new CreateTestOrder();
            c_to.ShowDialog();

            if (Order.OrderNumber == org_OrderNr)
                return;

            Log.Activity.Start();

            mainForm.cf_OrderInformation.tb_OrderNr.Text = Order.OrderNumber;
            mainForm.cf_OrderInformation.cb_Operation.Text = Order.Operation;

            //Order.Start.Save_MainInfo();
            _ = mainForm.StartOrLoadOrder(true);
            mainForm.Change_GUI_MainForm();

            _ = Activity.Stop($"{Person.Name} Creating a TestOrder");
        }
        private void Menu_Order_OpenRandomOrder_Click(object sender, EventArgs e)
        {
            Order.Start.OpenRandomOrder(mainForm.cf_OrderInformation);
        }
        private void Menu_Order_RelinkProcesscard_Click(object sender, EventArgs e)
        {
            if (Order.IsOrderDone)
            {
                InfoText.Show(Properties.Resources.changeProcesscard_Info_4, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(Properties.Resources.changeProcesscard_Info_1, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (!Processcard.IsPartNrExist)
            {
                InfoText.Show(Properties.Resources.changeProcesscard_Info_2, CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }

            using var chooseProcesscard_ChangeProcesscard = new TemplateSelector(true, true, false, false);
            chooseProcesscard_ChangeProcesscard.ShowDialog();

            Database.ExecuteSafe(con =>
            {
                var query = @"
                        UPDATE [Order].MainData
                            SET PartID = @partID, RevNr = @revNr, ProdLine = @prodline, ProdType = @prodtyp
                        WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                SQL_Parameter.String(cmd.Parameters, "@revNr", Order.RevNr);
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);

                cmd.ExecuteNonQuery();
            });
            mainForm.cf_OrderInformation.lbl_RevNr.Text = Order.RevNr;
        }
        private void Menu_Order_RelinkProtocol_Click(object sender, EventArgs e)
        {
            if (Order.IsOrderDone)
            {
                InfoText.Show(Properties.Resources.changeProtocol_Info_1, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(Properties.Resources.changeProtocol_Info_2, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            //Väljer först Workoperation -> ProtocolTemplateID -> LineClearanceMainTemplateID
            using var changeWorkoperation = new TemplateSelector(TemplateSelector.TemplateType.Workoperations);
            changeWorkoperation.ShowDialog();

            using var changeTemplate = new TemplateSelector(TemplateSelector.TemplateType.TemplateProtocol);
            changeTemplate.ShowDialog();
            Templates_LineClearance.MainTemplate.Set_MainTemplateID();
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                        UPDATE [Order].MainData
                            SET 
                                WorkoperationID = @workoperationid,
                                LineClearanceMainTemplateID = @lineclearancemaintemplateid,
                                ProtocolMainTemplateID = @protocolmaintemplateid
                        WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@workoperationid", Order.WorkoperationID);
                cmd.Parameters.AddWithValue("@lineclearancemaintemplateid", Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID);
                cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);
                cmd.ExecuteNonQuery();
            });
        }
        private void Menu_Order_RelinkMeasureProtocol_Click(object sender, EventArgs e)
        {
            if (Order.IsOrderDone)
            {
                InfoText.Show(Properties.Resources.changeMeasureProtocol_Info_1, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(Properties.Resources.changeMeasureProtocol_Info_2, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            if (!string.IsNullOrEmpty(Order.RevNr))
            {
                InfoText.Show(Properties.Resources.changeMeasureProtocol_Info_3, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (MeasureInformation.TotalMeasurmentsByOperators > 0)
            {
                InfoText.Question(Properties.Resources.changeMeasureProtocol_Info_IsMeasurementsDone, CustomColors.InfoText_Color.Warning, "Warning", this);
                if (InfoText.answer == InfoText.Answer.No)
                    return;
            }
            using var changeTemplate = new TemplateSelector(TemplateSelector.TemplateType.TemplateMeasureProtocol, false);
            changeTemplate.ShowDialog();
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        UPDATE [Order].MainData
                            SET MeasureProtocolMainTemplateID = @measureprotocolmaintemplateid
                        WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@measureprotocolmaintemplateid", Templates_MeasureProtocol.MainTemplate.ID);
                cmd.ExecuteNonQuery();
            });
        }
        private void Menu_Order_OrderLog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order.OrderNumber))
                return;

            Activity.Start();

            var rtfContent = Database.ExecuteSafe(con =>
            {
                StringBuilder sb = new StringBuilder();

                // Starta RTF och definiera färger: 1=blå, 2=grå, 3=grön
                sb.Append(@"{\rtf1\ansi\deff0");
                sb.AppendLine(@"{\colortbl ;");
                sb.AppendLine(RtfColor_Date); // ParmesanFont  --Datum
                sb.AppendLine(RtfColor_Name); // Name+HostName
                sb.AppendLine(RtfColor_Message); // LightBlue  --Info
                sb.AppendLine(RtfColor_Header); // Parmesan   --Rubrik
                sb.AppendLine(@"}");

                // Rubrik i grön
                sb.Append(@"\cf4\b\fs32 --- Order Log for OrderNr: " + EscapeRtf(Order.OrderNumber) + @" ---\b0\fs20\line\line");

                const string query = @"
                    SELECT
                        log.Date,
                        log.Info,
                        log.HostID,
                        log.UserID,
                        g.HostName,
                        p.Name AS UserName
                    FROM [Log].ActivityLog AS log
                    LEFT JOIN [Settings].General AS g
                        ON g.HostID = log.HostID
                    LEFT JOIN [User].Person AS p
                        ON p.UserID = log.UserID
                    WHERE log.OrderID = @orderid    
                        AND Program NOT IN 
                        (
                            'AddMachine', 
                            'Add',
                            'Add_Points', 
                            'Http_response', 
                            'CopyRow_CellMouseDoubleClick', 
                            'ResetMainForm', 
                            'Menu_Order_OrderLog_Click', 
                            'CheckIfEquipmentIsConfirmed',
                            'MainForm_FormClosing',
                            'Inledande_LotNr_Enter' ,
                            'SavePrefabFromMonitor',
                            'AutoTestJira',
                            'Looping_ThroughMeasurements',
                            'Mätdata_Row_Click',
                            'Load_dt_Korprotokoll_MainDataAsync',
                            'SaveExtraComment'
                        )
                        AND Info NOT LIKE '%Felsökning%'
                        AND Info NOT LIKE '%Error%'
                    ORDER BY log.Date DESC;";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@orderid", SqlDbType.Int).Value = Order.OrderID;

                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var date = EscapeRtf(reader["Date"].ToString());
                    var user = EscapeRtf(reader["UserName"].ToString());
                    var host = EscapeRtf(reader["HostName"].ToString());
                    var info = EscapeRtf(reader["Info"].ToString());
                    // Datum + användare + HostName
                    sb.Append(
                        @"\cf1\fs20 " + date +
                        @"\cf2\b   " + user + @" @ " + host +
                        @"\line"
                    );

                    // Info
                    sb.Append(@"\cf3\pard\li360\fi-360\bullet\tab ");
                    sb.Append(info);
                    sb.Append(@"\par\line");
                }

                // Sluttext i grön
                sb.Append(@"\cf4\b\fs32 --- End of Order Log for OrderNr: " + EscapeRtf(Order.OrderNumber) + @" ---\line");
                sb.Append("}"); // avsluta RTF
                return sb.ToString();
            });

            if (!string.IsNullOrEmpty(rtfContent))
                InfoText.Show(rtfContent, CustomColors.InfoText_Color.Info, "Order Log", this);

            Activity.Stop("User Checks OrderLog");
        }


        // Hjälpmetod för att escapera RTF-specialtecken
        private string EscapeRtf(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text.Replace(@"\", @"\\").Replace("{", @"\{").Replace("}", @"\}");
        }
        private void Menu_Protocol_ManageProcesscards_Click(object sender, EventArgs e)
        {
            if (Order.OrderID != null && Person.Role != "SuperAdmin")
            {
                InfoText.Show(Properties.Resources.openProcessardManagementWarning, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            // Stoppa MainTimer eventuellt om det blir problem
            using var WorkOperation = new Choose_WorkOperation_BrowseProtocols_ManageProcesscards(true, false, false, Properties.Resources.label_ChoosePC_Header);
            WorkOperation.ShowDialog();
        }
        private void Menu_Protocol_ManageTemplates_Protocols_Click(object sender, EventArgs e)
        {
            if (Person.IsUserSignedIn(false) == false)
            {
                InfoText.Show(Properties.Resources.manageTemplates, CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            //try
            //{
            using var newTemplate = new Templates_Protocol();
            newTemplate.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"An error occurred: {ex.Message}");
            //}
        }
        private void Menu_Protocol_ManageTemplates_LineClearance_Click(object sender, EventArgs e)
        {
            using var manage_LineClearanceTemplates = new Templates_LineClearance();
            manage_LineClearanceTemplates.ShowDialog();
        }
        private void Menu_Protocol_ManageTemplates_MeasureProtocol_Click(object sender, EventArgs e)
        {
            using var manage_MeasureProtocolTemplates = new Templates_MeasureProtocol();
            manage_MeasureProtocolTemplates.ShowDialog();
        }
        private void Menu_Protocol_UseFilter_Click(object sender, EventArgs e)
        {
            if (Order.OrderID is null)
                return;
            if (Menu_Equipment_UseFilter.Checked)
            {
                Menu_Equipment_UseSilpaket.Checked = false;
                Equipment.Equipment.Set_Filterhus_Used_In_Protocol(true);
            }
            else
            {
                Menu_Equipment_UseFilter.Checked = false;
                Equipment.Equipment.Set_Filterhus_Used_In_Protocol(false);
            }
        }
        private void Menu_Protocol_UseSilpaket_Click(object sender, EventArgs e)
        {
            if (Order.OrderID is null)
                return;
            if (Menu_Equipment_UseSilpaket.Checked)
            {
                Menu_Equipment_UseFilter.Checked = false;
                Equipment.Equipment.Set_Filterhus_Used_In_Protocol(false);
            }
            else
            {
                Menu_Equipment_UseSilpaket.Checked = false;
                Equipment.Equipment.Set_Filterhus_Used_In_Protocol(true);
            }
        }


        //----------USER----------
        private void Menu_User_SignIn_Click(object sender, EventArgs e)
        {
            mainForm.SignIn();
        }
        private void Menu_User_SignOut_Click(object sender, EventArgs e)
        {
            mainForm.SignOut();
        }
        private void Menu_User_Inloggad_Click(object sender, EventArgs e)
        {
            Points.Add_Points(1, "Kollar vem som är inloggad.");
            using var inloggad = new WhoIsLoggedIn();
            inloggad.ShowDialog();
        }
        private void Menu_User_Logga_ut_användare_Click(object sender, EventArgs e)
        {
            SaveData.Reset_Processcard_Open(true);
        }
        private void Menu_User_CheckMyAnalysis_Click(object sender, EventArgs e)
        {
            using var my_Analysis = new My_Analysis();
            my_Analysis.ShowDialog();
        }
        private void Menu_User_Authorities_Roles_Click(object sender, EventArgs e)
        {
            using var authorities = new AuthorizationManager(AuthorizationManager.Scenario.Roles);
            authorities.ShowDialog();
        }
        private void Menu_User_Authorities_CustomMailAddresses_Click(object sender, EventArgs e)
        {
            using var authorities = new AuthorizationManager(AuthorizationManager.Scenario.Email);
            authorities.ShowDialog();
        }
        private void Menu_User_Authorities_CustomWorkoperations_Click(object sender, EventArgs e)
        {
            using var authorities = new AuthorizationManager(AuthorizationManager.Scenario.Workoperation);
            authorities.ShowDialog();
        }
        private void Menu_User_Authorities_CustomFactories_Click(object sender, EventArgs e)
        {
            using var authorities = new AuthorizationManager(AuthorizationManager.Scenario.Factory);
            authorities.ShowDialog();
        }


        //----------VERKTYG----------
        private void Menu_Verktyg_Inställningar_Click(object sender, EventArgs e)
        {
            if (!Person.IsUserSignedIn(false))
            {
                InfoText.Show("Logga in för att ändra i inställningarna.", CustomColors.InfoText_Color.Bad, "Varning!");
                return;
            }

            Log.Activity.Start();

            using var inst = new Settings.Settings();
            inst.ShowDialog();
            _ = Main_FilterQuickOpen.Load_ListAsync(mainForm.dgv_QuickOpen);

            _ = Log.Activity.Stop($"Open Settings");
        }
        private void Menu_Verktyg_Beräkna_Material_Click(object sender, EventArgs e)
        {
            var beräkna = new Beräkna_Material_Blandning();
            beräkna.Show();
        }
        private void Menu_Settings_ChangeColorHS_Machine_Click(object sender, EventArgs e)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeColorHS_Machine))
            {
                using var machineColor = new MachineColor();
                machineColor.ShowDialog();
            }

        }
        private void Menu_Settings_ToolsCalculator_Click(object sender, EventArgs e)
        {
            ToolCalculator toolCalculator = new ToolCalculator(mainForm.cf_OrderInformation.tb_OrderNr.AutoCompleteCustomSource);
            toolCalculator.Show();

        }
        private void Menu_Settings_AnalyseParameterData_Click(object sender, EventArgs e)
        {
            using var parameterData = new ParameterDataSearch();
            using var black = new BlackBackground("", 70);
            black.Show();
            parameterData.ShowDialog();
            black.Close();
        }

        //----------TEMAN----------
        private void Menu_Theme_Click(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            Teman.load_Themes[menu.Text]();
            Settings.Settings.SaveData.UPDATE_Setting("Theme", null, menu.Text);
            Points.Add_Points(1, menu.Text);
            Task.Run(mainForm.Change_Theme);
        }


        //----------HJÄLP----------
        private void Menu_Help_RapporteraFel_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://optinova.atlassian.net/servicedesk/customer/portal/22",
                UseShellExecute = true
            });
        }
        private void Menu_Help_Versionshistorik_Click(object sender, EventArgs e)
        {
            using var changeLog = new ChangeLog(ChangeLog.LatestAllowedVersion);
            changeLog.ShowDialog();
        }
        private void Menu_Help_InstructionVideos_OpenVideo_Click(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            if (item is null)
                return;
            string videoUrl = null;
            switch (item.Name)
            {
                case "Menu_Help_InstructionVideos_AddUser":
                    videoUrl = "https://optinovaholding.sharepoint.com/:v:/r/sites/InnovationCenter/Delade%20dokument/W%20-%20Software/DPP/DPP-Instruction%20Movies/Add%20User.mp4?csf=1&web=1&e=JIm7vS";
                    break;
                case "Menu_Help_InstructionVideos_SignIn":
                    videoUrl = "https://optinovaholding.sharepoint.com/:v:/r/sites/InnovationCenter/Delade%20dokument/W%20-%20Software/DPP/DPP-Instruction%20Movies/Sign%20In.mp4?csf=1&web=1&e=iaiki8";
                    break;
                case "Menu_Help_InstructionVideos_RecentlyOpenedOrders":
                    videoUrl = "https://optinovaholding.sharepoint.com/:v:/r/sites/InnovationCenter/Delade%20dokument/W%20-%20Software/DPP/DPP-Instruction%20Movies/How%20to%20use%20Open%20most%20Recently%20Initiated%20Orders.mp4?csf=1&web=1&e=aTXnQb";
                    break;
                case "Menu_Help_InstructionVideos_ManageAuthorities":
                    videoUrl = "https://optinovaholding.sharepoint.com/:v:/r/sites/InnovationCenter/Delade%20dokument/W%20-%20Software/DPP/DPP-Instruction%20Movies/Manage%20Authorities.mp4?csf=1&web=1&e=T1xO0X";
                    break;
                case "Menu_Help_InstructionVideos_SaveProcessCard":
                    videoUrl = "https://optinovaholding.sharepoint.com/:v:/r/sites/InnovationCenter/Delade%20dokument/W%20-%20Software/DPP/DPP-Instruction%20Movies/Save%20a%20Process%20card.mp4?csf=1&web=1&e=fac7c0";
                    break;
            }


            // Use the Process class to start the default program associated with the file type
            if (videoUrl != null)
                Process.Start(new ProcessStartInfo
                {
                    FileName = videoUrl, // or use the local file path if applicable
                    UseShellExecute = true
                });
        }

        //----------UVECKLING----------
        private void Menu_Utvecklare_GetInfo(object sender, EventArgs e)
        {
            var workcenterDescription = "N/A";
            var workcenterProdGroup = "N/A";
            if (Monitor.Monitor.WorkCenter != null)
            {
                workcenterDescription = Monitor.Monitor.WorkCenter.Description;
                workcenterProdGroup = Monitor.Monitor.WorkCenter.Number;
            }


            string message =
@"{\rtf1\ansi
{\fonttbl\f0\fnil\fcharset0 Consolas;}
{\colortbl ;\red239\green228\blue177;\red184\green220\blue231;}

\f0

\cf1\fs24 ==================== ORDERINFO ==================== \line
\cf2\fs18 OrderNr                  = " + Order.OrderNumber + @"\line
OrderID                  = " + Order.OrderID + @"\line
Operation                = " + Order.Operation + @"\line
PartNr                   = " + Order.PartNumber + @"\line
PartID                   = " + Order.PartID + @"\line
RevNr                    = " + Order.RevNr + @"\line
ProdLinje                = " + Order.ProdLine + @"\line
WorkCenterDescription    = " + workcenterDescription + @"\line
ProduktTyp               = " + Order.ProdType + @"\line
ProdGrupp                = " + Order.ProdGroup + @"\line
WorkCenterProdGroup      = " + workcenterProdGroup + @"\line
Kund                     = " + Order.Customer + @"\line
Benämning                = " + Order.Description + @"\line
HS-Machine               = " + Equipment.Equipment.HS_Machine + @"\line
\cf1\fs24=================================================== \line\line

=================== WORKOPERATION ================= \line
\cf2\fs18 WorkOperation            = " + Order.WorkOperation + @"\line
WorkOperationID          = " + Order.WorkoperationID + @"\line
\cf1\fs24=================================================== \line\line

====================== USER INFO ================== \line
\cf2\fs18 Theme                   = " + Teman.Theme + @"\line
Name                    = " + Person.Name + " - " + Person.EmployeeNr + @"\line
Befattning              = " + Person.Role + @"\line
\cf1\fs24=================================================== \line\line

======================= MONITOR =================== \line
\cf2\fs18 MonitorCompany          = " + Database.MonitorCompany + @"\line
MonitorHost             = " + Database.MonitorHost + @"\line
\cf1\fs24=================================================== \line\line

========= MEASUREPROTOCOL TEMPLATE ================ \line
\cf2\fs18 MainTemplateID          = " + Templates_MeasureProtocol.MainTemplate.ID + @"\line
MainTemplateName        = " + Templates_MeasureProtocol.MainTemplate.Name + @"\line
\cf1\fs24=================================================== \line\line

========= LINECLEARANCE TEMPLATE ================== \line
\cf2\fs18 MainTemplateID          = " + Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID + @"\line
\cf1\fs24=================================================== \line\line

\cf1\fs24 ========= MAINPROTOCOL TEMPLATE =================== \line
\cf2\fs18 Protocol.TemplateID     = " + Templates_Protocol.MainTemplate.ID + @"\line
Protocol.Name           = " + Templates_Protocol.MainTemplate.Name + @"\line
Protocol.Revision       = " + Templates_Protocol.MainTemplate.Revision + @"\line
\cf1\fs24=================================================== \line
}";

            InfoText.Show(message, CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void Menu_Developer_Add_Gallup_Click(object sender, EventArgs e)
        {
            using var addGallup = new Add_UserPoll();
            addGallup.ShowDialog();
        }
        private void Menu_Developer_Kolla_Gallup_Click(object sender, EventArgs e)
        {
            using var gallup = new UserPoll();
            gallup.ShowDialog();
        }
        private void Menu_Developer_Timer_test_Click(object sender, EventArgs e)
        {
            using var pbar = new ProgressBar();
            double percent = 0;

            pbar.Show();

            for (var i = 0; i < 100; i++)
            {
                pbar.Set_ValueProgressBar(percent, $"Testar: {i}", percent);
                Thread.Sleep(100);
                percent += 1;
            }
        }
        private void Menu_Developer_GetDataForQuoting_Click(object sender, EventArgs e)
        {
            Get_Protocol_Data.Get_QuoteData.TransferData();
        }
        private void Menu_Developer_TestNewProtocol_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Orders utan processkort = {Part.TotalOrders_WithoutProcesscard}\n" +
                            $"Orders med processkort = {Part.TotalOrders_WithProcesscardBasedOn_DevelopmentOfProcesscard}");
        }
        private void Menu_Developer_OpenRandomOrder_Click(string? artikelNr)
        {
            if (string.IsNullOrEmpty(artikelNr))
                return;

            mainForm.Clear_Mainform();

            // Hämta slumpmässig order via ExecuteSafe
            var result = Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT TOP(1) OrderNr, Operation 
                    FROM [Order].MainData 
                    WHERE ArtikelNr = @partnr AND RevNr IS NOT NULL 
                    ORDER BY NEWID()";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnr", artikelNr);
                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new
                    {
                        OrderNr = reader["OrderNr"].ToString(),
                        Operation = reader["Operation"].ToString()
                    };
                }

                return null;
            });

            if (result == null)
            {
                InfoText.Show($"Ingen order hittades för artikelNr: {artikelNr}", CustomColors.InfoText_Color.Info, "Info");
                return;
            }

            // Sätt order-info
            Order.OrderNumber = result.OrderNr;
            Order.Operation = result.Operation;
            Order.PartNumber = artikelNr;
            Order.WorkOperation = Manage_WorkOperation.WorkOperations.Extrudering_Termo;

            // Uppdatera UI utan att trigga SelectedIndexChanged
            mainForm.cf_OrderInformation.cb_Operation.SelectedIndexChanged -= mainForm.Operation_SelectedIndexChanged;
            mainForm.cf_OrderInformation.tb_OrderNr.Text = Order.OrderNumber;
            mainForm.cf_OrderInformation.cb_Operation.SelectedIndex = -1;
            mainForm.cf_OrderInformation.cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged;

            // Starta eller ladda order
            _ = mainForm.StartOrLoadOrder(true);
        }
        private void Menu_Developer_WhosIsLoggedIn_Click(object sender, EventArgs e)
        {
            using var calender = new LoggedInUsers();
            calender.ShowDialog();
        }
        private void Menu_Developer_BlockClients_Click(object sender, EventArgs e)
        {
            ClientUpdateManager blockClients = new ClientUpdateManager();
            blockClients.Show();
        }
        private void Menu_Developer_CheckForUpdate_Click(object sender, EventArgs e)
        {
            mainForm._scheduler.CheckForUpdate();
        }
        private void Menu_Developer_CountSqlQueries_Click(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Totalt antal SQL-anrop: {Database.SQL_Counter}\n\n");

            foreach (var kvp in ServerStatus.dictMethodsSqlCounter.OrderByDescending(x => x.Value))
            {
                sb.AppendLine($"{kvp.Key}: {kvp.Value} anrop");
            }

            InfoText.Show(sb.ToString(), CustomColors.InfoText_Color.Info, null, mainForm);
            // Kopiera till urklipp
            Clipboard.SetText(sb.ToString());
        }
        private void Menu_Developer_ClearSqlQueries_Click(object sender, EventArgs e)
        {
            ServerStatus.dictMethodsSqlCounter.Clear();
            Database.SQL_Counter = 0;
        }
        private void Menu_Developer_AddThemePicture_Click(object sender, EventArgs e)
        {
            using var addTheme = new AddTheme();
            addTheme.ShowDialog();
        }
        private void Menu_Developer_EasterEggPsycho_Click(object sender, EventArgs e)
        {
            EasterEgg_GetPsycho psycho = new EasterEgg_GetPsycho();
            psycho.Show();
        }
        private void menu_Developer_AutotestJira_Click(object sender, EventArgs e)
        {
            Mail.AutoTestJira();
        }
        private void Menu_Developer_TestMonitorAPI_Click(object sender, EventArgs e)
        {
            using var monitorApiPerformance = new MonitorApiPerformanceForm();
            monitorApiPerformance.ShowDialog(mainForm);
        }




        private static void INSERT_DATA_Korprotokoll_Value(int orderid, int descrId, string? value, int uppstart, int machineIndex)
        {
            Database.ExecuteSafe(con =>
            {
                const string query = @"
        IF NOT EXISTS 
        (
            SELECT 1 
            FROM [Order].Data
            WHERE OrderID = @orderid
                AND ProtocolDescriptionID = @descrId
                AND COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)
                AND COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)
        )
        INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, MachineIndex, Value)     
        VALUES (@orderid, @descrId, @uppstart, @machineindex, @value);";

                using var cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);

                cmd.Parameters.AddWithValue("@uppstart", uppstart);
                cmd.Parameters.AddWithValue("@machineindex", machineIndex == 0 ? DBNull.Value : machineIndex);

                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_DATA_Korprotokoll_TextValue(int orderid, int descrId, string? textvalue, int uppstart, int MachineIndex = 0)
        {
            //if (string.IsNullOrEmpty(value))
            //    return;
            Database.ExecuteSafe(con =>
            {
                var query = @"
                BEGIN
                        IF NOT EXISTS 
                            (SELECT * FROM [Order].Data
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))
                        
                            INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, MachineIndex, TextValue)     
                            VALUES (@orderid, @descrId, @uppstart, @machineindex, @textvalue)
                        ELSE
                            UPDATE [Order].Data
			                SET TextValue = @textvalue
			                WHERE OrderID = @orderid AND uppstart = @uppstart AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)) AND ProtocolDescriptionID = @descrId
                    END";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.String(cmd.Parameters, "@textvalue", textvalue);
                //if (uppstart == 0)
                //    cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                //else
                cmd.Parameters.AddWithValue("@uppstart", uppstart);
                if (MachineIndex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", MachineIndex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_DATA_Korprotokoll_BoolValue(int orderid, int descrId, bool boolvalue, int uppstart, int MachineIndex)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                BEGIN
                        IF NOT EXISTS 
                            (SELECT * FROM [Order].Data
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))
                        
                            INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, MachineIndex, BoolValue)     
                            VALUES (@orderid, @descrId, @uppstart, @machineindex, @boolvalue)
                        ELSE
                            UPDATE [Order].Data
			                SET BoolValue = @boolvalue
			                WHERE OrderID = @orderid AND uppstart = @uppstart AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)) AND ProtocolDescriptionID = @descrId
                    END";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", boolvalue);
                //if (uppstart == 0)
                //    cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                //else
                cmd.Parameters.AddWithValue("@uppstart", uppstart);
                if (MachineIndex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", MachineIndex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_DATA_Korprotokoll_DateValue(int orderid, int descrId, DateTime date, int uppstart, int MachineIndex)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                    BEGIN
                        IF NOT EXISTS 
                            (SELECT * FROM [Order].Data
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))
                        
                            INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, MachineIndex, DateValue)     
                            VALUES (@orderid, @descrId, @uppstart, @machineindex, @datevalue)
                        ELSE
                            UPDATE [Order].Data
			                SET DateValue = @datevalue
			                WHERE OrderID = @orderid AND uppstart = @uppstart AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)) AND ProtocolDescriptionID = @descrId
                    END";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                if (date < DateTime.Parse("1950-01-01"))
                    cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@datevalue", date);
                cmd.Parameters.AddWithValue("@uppstart", uppstart);
                if (MachineIndex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", MachineIndex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_MätMainData(int orderid, bool discarded, DateTime date, string anstnr, string sign, int rowindex)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].[MainData]
                                WHERE OrderID = @orderid AND [Date] = @date)
                        INSERT INTO [MeasureProtocol].[MainData] (OrderID, Discarded, [Date], AnstNr, Sign, RowIndex)     
                            VALUES (@orderid, @discarded, @date, @anstnr, @sign, @row)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@discarded", discarded);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@anstnr", anstnr);
                cmd.Parameters.AddWithValue("@sign", sign);
                cmd.Parameters.AddWithValue("@row", rowindex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_MätDataTextValue(int orderid, int descrid, string? textvalue, int rowindex)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].Data
                                WHERE OrderID = @orderid AND DescriptionID = @descrid AND RowIndex = @rowindex)
                        
                            INSERT INTO [MeasureProtocol].Data (OrderID, DescriptionID, TextValue, RowIndex)     
                            VALUES (@orderid, @descrid, @textvalue, @rowindex)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrid);
                cmd.Parameters.AddWithValue("@textvalue", textvalue);
                cmd.Parameters.AddWithValue("@rowindex", rowindex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_MätDataValue(int orderid, int descrid, string? value, int rowindex)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].Data
                                WHERE OrderID = @orderid AND DescriptionID = @descrid AND RowIndex = @rowindex)
                        
                            INSERT INTO [MeasureProtocol].Data (OrderID, DescriptionID, Value, RowIndex)     
                            VALUES (@orderid, @descrid, @value, @rowindex)";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrid);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);
                cmd.Parameters.AddWithValue("@rowindex", rowindex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_MätDataBoolValue(int orderid, int descrid, bool boolvalue, int rowindex)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].Data
                                WHERE OrderID = @orderid AND DescriptionID = @descrid AND RowIndex = @rowindex)
                        
                            INSERT INTO [MeasureProtocol].Data (OrderID, DescriptionID, BoolValue, RowIndex)     
                            VALUES (@orderid, @descrid, @boolvalue, @rowindex)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrid);
                SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", boolvalue);
                cmd.Parameters.AddWithValue("@rowindex", rowindex);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_DATA_Processcard_Value(int PartID, int templateID, string? value, byte machineindex, int type)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        BEGIN
                            IF NOT EXISTS 
                                (SELECT * FROM Processcard.Data 
                                    WHERE PartID = @partid AND TemplateID = @templateid AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))

                                INSERT INTO Processcard.Data (PartID, TemplateID, MachineIndex, Value, TextValue, Type)     
                                VALUES (@partid, @templateid, @machineindex, @value, NULL, @type)
                            ELSE
                                UPDATE Processcard.Data
                            SET Value = @value
                            WHERE PartID = @PartID AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)) AND TemplateID = @templateid
                        END";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partid", PartID);
                cmd.Parameters.AddWithValue("@templateid", templateID);
                if (machineindex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", machineindex);
                cmd.Parameters.AddWithValue("@type", type);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);

                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_DATA_Processcard_TextValue(int PartID, int templateID, string textvalue, byte machineindex, int type)
        {
            Database.ExecuteSafe(con =>
            {
                var query = @"
                        BEGIN
                            IF NOT EXISTS 
                                (SELECT * FROM Processcard.Data 
                                    WHERE PartID = @partid AND TemplateID = @templateid AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))

                                INSERT INTO Processcard.Data (PartID, TemplateID, MachineIndex, Value, TextValue, Type)     
                                VALUES (@partid, @templateid, @machineindex, NULL, @textvalue, @type)
                            ELSE
                                UPDATE Processcard.Data
                            SET TextValue = @textvalue
                            WHERE PartID = @PartID AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)) AND TemplateID = @templateid
                        END";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partid", PartID);
                cmd.Parameters.AddWithValue("@templateid", templateID);
                if (machineindex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", machineindex);
                cmd.Parameters.AddWithValue("@type", type);
                if (textvalue is null)
                    cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@textvalue", textvalue);
                cmd.ExecuteNonQuery();
            });
        }
        private void INSERT_DATA_WithoutUppstart_Korprotokoll_TextValue(int orderid, int descrId, string? value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            Database.ExecuteSafe(con =>
            {
                var query = @"
                    BEGIN
                        IF NOT EXISTS 
                            (SELECT * FROM [Order].Data 
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId)
                        
                            INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, Ugn, Value, textvalue)     
                            VALUES (@orderid, @descrId, NULL, NULL, NULL, @textvalue)
                        ELSE
                            UPDATE [Order].Data
			                SET textvalue = @textvalue
			                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId
                    END";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.String(cmd.Parameters, "@textvalue", value);

                cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                cmd.ExecuteNonQuery();
            });
        }




        private void Menu_Developer_ExportHS_Data_Click(object sender, EventArgs e)
        {
            Get_Protocol_Data.Get_QuoteData.TransferData();
        }

        private void testaNAntalKörningarPåArtikelNrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Part.TotalOrdersRun = {Part.TotalOrdersRun}");
            MessageBox.Show($"Part.TotalOrders_WithoutProcesscard = {Part.TotalOrders_WithoutProcesscard}");

        }


        private void testaMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoText.Question("Vill du skicka mail till alla användare", CustomColors.InfoText_Color.Info, "Skicka Mail?", this);
            if (InfoText.answer == InfoText.Answer.Yes)
            {
                Mail.NotifyAllUsersSpecificInfo();
            }
        }

        private void Menu_Order_QC_Feedback_Click(object sender, EventArgs e)
        {
            using var qc = new QC_Feedback(true, false, false);
            qc.ShowDialog();
        }

        private void påskäggToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var easterEgg = new EasterEgg_Code();
            easterEgg.ShowDialog();
        }

        private void fixaChangeLogListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-----ChangeLog for DigitalProductionProgram-----");
            sb.AppendLine();
            Database.ExecuteSafe(con =>
            {
                var query = @"
                       SELECT ReleaseDate, Version, Tags, DescriptionHeader, Description, HowToDo, VisibleToUser, IsCritical FROM Log.ChangeLog";
                var cmd = new SqlCommand(query, con);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var releaseDate = reader["ReleaseDate"].ToString() ?? "";
                    var version = reader["Version"].ToString() ?? "";
                    var tags = reader["Tags"].ToString() ?? "";
                    var header = reader["DescriptionHeader"].ToString() ?? "Info";
                    var description = reader["Description"].ToString() ?? "";
                    var howToDo = reader["HowToDo"].ToString() ?? "";
                    bool.TryParse(reader["VisibleToUser"].ToString(), out var isVisibleToUser);
                    bool.TryParse(reader["IsCritical"].ToString(), out var isCritical);
                    {
                        sb.AppendLine($"## Version: {version}");
                        sb.AppendLine($"Release Date: {releaseDate}");
                        switch (tags)
                        {
                            case "Nytt":
                                tags = "New Feature";
                                break;
                            case "Fix":
                                tags = "Small bugfix";
                                break;
                            case "Bugfix":
                                tags = "Bug Fix";
                                break;
                            default:
                                tags = "ℹ Info";
                                break;
                        }

                        sb.AppendLine($"### {tags}");
                        sb.AppendLine($"-Header: {header}");
                        sb.AppendLine($"  {description}");
                        sb.AppendLine($"How To Do: {howToDo}");
                        sb.AppendLine($"Is Critical: {isCritical}");
                        sb.AppendLine($"IsVisibleToUser: {isVisibleToUser}");
                        sb.AppendLine();
                    }
                }
                Clipboard.SetText(sb.ToString());
            });


        }

        private void tvåToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var activitylogViewer = new ActivityLogViewer();
            activitylogViewer.Show();
        }

       
    }
}
