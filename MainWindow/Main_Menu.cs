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
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using Color = System.Drawing.Color;
using ProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;

namespace DigitalProductionProgram.MainWindow
{
    public partial class Main_Menu : UserControl
    {
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
            Menu_Arkiv_ManageDatabase.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeDatabaseSettings, false);
            Menu_Order_EditOrder.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.EditOrder, false);
            Menu_Order_DeleteOrder.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.DeleteOrder, false);
            Menu_Order_ReportProblemProductionSupport.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ReportToProductionSupport, false);
            Menu_Order_CreateTestOrder.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.CreateTestOrder, false);
            Menu_Developer.Visible = CheckAuthority.IsOkShowDeveloperMenu;
            Menu_User_CheckMyAnalysis.Visible = CheckAuthority.IsFactoryAuthorized(CheckAuthority.TemplateFactory.MyAnalysis);
            Menu_Protocol_ManageTemplates.Visible = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageTemplates, false);

        }


        public void Lock_Menu()
        {
            Menu_Developer.Visible = false;
            Menu_Order_EditOrder.Enabled = false;
            Menu_Order_ReportProblemProductionSupport.Enabled = false;
            Menu_Arkiv_ManageDatabase.Enabled = false;
            Menu_Order_DeleteOrder.Enabled = false;
            Menu_Protocol_Unlock_ValidatedProcesscard.Enabled = false;
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



        //----------ARKIV/FILE----------
        private void Menu_Arkiv_NyOrder_Click(object sender, EventArgs e)
        {
           ResetMainForm();
        }

        private void ResetMainForm()
        {
            Order.Clear_Order();
            mainForm.Clear_Mainform();
            mainForm.OrderInformation.Clear();
            mainForm.OrderInformation.tb_OrderNr.Focus();
            mainForm.measurePoints.ClearMeasurePoints();
            mainForm.measureStats.ClearData();
            mainForm.OrderInformation.tb_OrderNr.Enabled = true;
            mainForm.Change_Theme();
            mainForm.tlp_Left.BackColor = Color.Transparent;
            mainForm.BackColor = Color.Transparent;
            //här
            //foreach (var series in MeasurementChart.chart.Series)
            //    if (series.Values is IList<double> values)
            //        values.Clear();


            mainForm.Change_GUI_StandardColor();
            _ = Log.Activity.Stop("Användare klickar på Ny Order");
        }
        private void Menu_Arkiv_UpdateDPP_Click(object sender, EventArgs e)
        {
            var updaterPath = @"\\optifil\dpp\Update\Update DPP.exe"; // Ändra till rätt filnamn
            if (File.Exists(updaterPath))
            {
                Process.Start(updaterPath);
            }
            else
            {
                MessageBox.Show("Updatern kunde inte hittas.", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit(); // Stänger DPP

        }
        private async void Menu_Arkiv_Öppna_Click(object sender, EventArgs e)
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
                mainForm.OrderInformation.cb_Operation.SelectedIndexChanged -= mainForm.Operation_SelectedIndexChanged;
                mainForm.OrderInformation.tb_OrderNr.Text = Order.OrderNumber;
                mainForm.OrderInformation.cb_Operation.Text = $"{Order.Operation} - {Order.Description}";
                mainForm.OrderInformation.cb_Operation.SelectedIndex = -1; //Detta görs för att inte Order.Operation skall ändras vid metoden StartaOrder()
                mainForm.OrderInformation.cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged;

                Menu_Order_OrderDone.Enabled = true;
                _ = mainForm.StartOrLoadOrder(true);
            }
        }

        private void Menu_Arkiv_Förhandsgranska_Click(object sender, EventArgs e)
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
        private void Menu_Arkiv_SkrivUt_Click(object sender, EventArgs e)
        {
            Order.Is_PrintOutCopy = true;
            mainForm.PrintOut();
        }
        private void Menu_Arkiv_ManageDatabase_Click(object sender, EventArgs e)
        {
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeDatabaseSettings) == false)
                return;
            using var database = new Database();
            database.ShowDialog();
            Application.Restart();
        }

        private void Menu_Arkiv_Avsluta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //----------ORDER----------
        private void Menu_Order_OrderKlar_Click(object sender, EventArgs e)
        {
            Order.Finish.Order(mainForm);

            if (Person.Role == "SuperAdmin")
                ResetMainForm();
        }
        private void Menu_Order_RedigeraOrder_Click(object sender, EventArgs e)
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
                InfoText.Show(LanguageManager.GetString("editOrder"), CustomColors.InfoText_Color.Bad, "Warning", this);
        }
        private void Menu_Order_RaderaOrder_ClickAsync(object sender, EventArgs e)
        {
            InfoText.Question($"{LanguageManager.GetString("delete")} \n\n" +
                          $"OrderNr {Order.OrderNumber}\n" +
                          $"Operation {Order.Operation}?", CustomColors.InfoText_Color.Warning, "Warning!", this);
            if (InfoText.answer != InfoText.Answer.Yes) return;
            if (!string.IsNullOrEmpty(Order.OrderNumber))
            {
                Log.Activity.Start();
                Order.DELETE_Order();
                //Activity.Stop($"{Person.Name} raderade order {Order.OrderNumber} - Operation: {Order.Operation}");
                //var task = Main_FilterQuickOpen.Load_ListAsync(mainForm.dgv_QuickOpen);

                if (QC_Feedback.IsOperationHaveQCFeedback)
                    QC_Feedback.IncreaseRemainingViewsForOperation();

                // Order.Clear_Order();//Detta görs i Clear_Mainform
                mainForm.Clear_Mainform();

            }
            else
                InfoText.Show(LanguageManager.GetString("deleteOrder_Info_1"), CustomColors.InfoText_Color.Bad, "Warning", this);

            _ = Main_FilterQuickOpen.Load_ListAsync(mainForm.dgv_QuickOpen);
            mainForm.PriorityPlanning.Load_PriorityPlanning();

        }
        private void Menu_Order_Rapport_Jira_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(LanguageManager.GetString("reportJira_Info_1"), CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }

            using var jira = new Jira();
            using var black = new BlackBackground("", 85);
            black.Show();
            jira.ShowDialog();
            black.Close();
        }
        private void Menu_Order_SkapaTestOrder_Click(object sender, EventArgs e)
        {
            var org_OrderNr = Order.OrderNumber;
            using var c_to = new CreateTestOrder();
            c_to.ShowDialog();

            if (Order.OrderNumber == org_OrderNr)
                return;

            Log.Activity.Start();

            mainForm.OrderInformation.tb_OrderNr.Text = Order.OrderNumber;
            mainForm.OrderInformation.cb_Operation.Text = Order.Operation;

            //Order.Start.Save_MainInfo();
            _ = mainForm.StartOrLoadOrder(true);
            mainForm.Change_GUI_MainForm();

            _ = Log.Activity.Stop($"{Person.Name} Skapar Testorder");
        }
        private void Menu_Order_OpenRandomOrder_Click(object sender, EventArgs e)
        {
            Order.Start.OpenRandomOrder(mainForm.OrderInformation);
        }
        private void Menu_Order_Relink_Processcard_Click(object sender, EventArgs e)
        {
            if (Order.IsOrderDone)
            {
                InfoText.Show(LanguageManager.GetString("changeProcesscard_Info_4"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(LanguageManager.GetString("changeProcesscard_Info_1"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            if (!Processcard.IsPartNrExist)
            {
                InfoText.Show(LanguageManager.GetString("changeProcesscard_Info_2"), CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }

            using var chooseProcesscard_ChangeProcesscard = new ProcesscardTemplateSelector(true, true, false, false);
            chooseProcesscard_ChangeProcesscard.ShowDialog();

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                        UPDATE [Order].MainData
                            SET PartID = @partID, RevNr = @revNr, ProdLine = @prodline, ProdType = @prodtyp
                        WHERE OrderID = @orderid";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                SQL_Parameter.NullableINT(cmd.Parameters, "@partID", Order.PartID);
                SQL_Parameter.String(cmd.Parameters, "@revNr", Order.RevNr);
                SQL_Parameter.String(cmd.Parameters, "@prodline", Order.ProdLine);
                SQL_Parameter.String(cmd.Parameters, "@prodtyp", Order.ProdType);


                con.Open();
                cmd.ExecuteNonQuery();
            }


            mainForm.OrderInformation.lbl_RevNr.Text = Order.RevNr;
        }
        private void Menu_Order_Relink_Protocol_Click(object sender, EventArgs e)
        {
            if (Order.IsOrderDone)
            {
                InfoText.Show(LanguageManager.GetString("changeProtocol_Info_1"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(LanguageManager.GetString("changeProtocol_Info_2"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            using var changeTemplate = new ProcesscardTemplateSelector(ProcesscardTemplateSelector.TemplateType.TemplateProtocol);
            changeTemplate.ShowDialog();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        UPDATE [Order].MainData
                            SET ProtocolMainTemplateID = @protocolmaintemplateid
                        WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@protocolmaintemplateid", Templates_Protocol.MainTemplate.ID);

            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void Menu_Order_Relink_MeasureProtocol_Click(object sender, EventArgs e)
        {
            if (Order.IsOrderDone)
            {
                InfoText.Show(LanguageManager.GetString("changeMeasureProtocol_Info_1"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            if (string.IsNullOrEmpty(Order.OrderNumber))
            {
                InfoText.Show(LanguageManager.GetString("changeMeasureProtocol_Info_2"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            using var changeTemplate = new ProcesscardTemplateSelector(ProcesscardTemplateSelector.TemplateType.TemplateMeasureProtocol);
            changeTemplate.ShowDialog();
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        UPDATE [Order].MainData
                            SET MeasureProtocolMainTemplateID = @measureprotocolmaintemplateid
                        WHERE OrderID = @orderid";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter(); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
            cmd.Parameters.AddWithValue("@measureprotocolmaintemplateid", Templates_MeasureProtocol.MainTemplate.ID);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        //----------PROTOKOLL/PROTOCOL----------
        private void Menu_Processkort_HanteraProcesskort_Click(object sender, EventArgs e)
        {
            if (Order.OrderID != null && Person.Role != "SuperAdmin")
            {
                InfoText.Show(LanguageManager.GetString("openProcessardManagementWarning"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            // Stoppa MainTimer eventuellt om det blir problem
            using var WorkOperation = new Choose_WorkOperation_BrowseProtocols_ManageProcesscards(true, false, false, LanguageManager.GetString("label_ChoosePC_Header"));
            WorkOperation.ShowDialog();
        }


        private void Menu_Protocol_ManageTemplates_Protocols_Click(object sender, EventArgs e)
        {
            if (Person.IsUserSignedIn(false) == false)
            {
                InfoText.Show(LanguageManager.GetString("manageTemplates"), CustomColors.InfoText_Color.Bad, "Warning", this);
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


        //----------KÖRPROTOKOLL----------
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

            _ = Log.Activity.Stop($"Kollar inställningar.");
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
            ToolCalculator toolCalculator = new ToolCalculator(mainForm.OrderInformation.tb_OrderNr.AutoCompleteCustomSource);
            toolCalculator.Show();

        }

        //----------TEMAN----------
        private void Menu_Tema_Click(object sender, EventArgs e)
        {
            var menu = (ToolStripMenuItem)sender;
            Teman.load_Themes[menu.Text]();
            Settings.Settings.SaveData.UPDATE_Setting("Theme", null, menu.Text);
            Points.Add_Points(1, menu.Text);
            Task.Run(mainForm.Change_Theme);
            //mainForm.Change_Theme();
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
            using var changeLog = new ChangeLog(ChangeLog.LatestVersion);
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
        public void Menu_Utvecklare_GetOrderInfo(object sender, EventArgs e)
        {
            var workcenterDescription = "N/A";
            var workcenterProdGroup = "N/A";
            if (Monitor.Monitor.WorkCenter != null)
            {
                workcenterDescription = Monitor.Monitor.WorkCenter.Description;
                workcenterProdGroup = Monitor.Monitor.WorkCenter.Number;
            }



            InfoText.Show(
                $@"
------ORDERINFO------
OrderNr = {Order.OrderNumber} 
OrderID = {Order.OrderID}
Operation = {Order.Operation}
PartNr = {Order.PartNumber} 
PartID = {Order.PartID}
RevNr = {Order.RevNr}
ProdLinje = {Order.ProdLine}
WorkCenterDescritpion = {workcenterDescription}
ProduktTyp = {Order.ProdType}
ProdGrupp = {Order.ProdGroup} 
WorkCenterProdGroup = {workcenterProdGroup}
Kund = {Order.Customer}
Benämning = {Order.Description}
HS-Machine = {Equipment.Equipment.HS_Machine}

------WORKOPERATION------
WorkOperation = {Order.WorkOperation}
WorkOperationID = {Order.WorkoperationID}

------USER INFO------
Theme = {Teman.Theme}
Name = {Person.Name} - {Person.EmployeeNr}
Befattning = {Person.Role}
MonitorCompany = {Database.MonitorCompany}

------TEMPLATES------
Measureprotocol.MainTemplateID = {Templates_MeasureProtocol.MainTemplate.ID}
Measureprotocol.Name = {Templates_MeasureProtocol.MainTemplate.Name}

LineClearance.MainTemplateID = {Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID}

Protocol.MainTemplate.ID = {Templates_Protocol.MainTemplate.ID}
Protocol.MainTemplate.Name = {Templates_Protocol.MainTemplate.Name}
Protocol.MainTemplate.Revision = {Templates_Protocol.MainTemplate.Revision}"
, CustomColors.InfoText_Color.Info, "Info", this);
        }
        public void Menu_Utvecklare_Add_Gallup_Click(object sender, EventArgs e)
        {
            using var addGallup = new Add_UserPoll();
            addGallup.ShowDialog();
        }
        public void Menu_Utvecklare_Kolla_Gallup_Click(object sender, EventArgs e)
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
        private void Öppna_Random_Order(string? artikelNr)
        {
            mainForm.Clear_Mainform();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query =
                    @"SELECT TOP(1) OrderNr, Operation FROM [Order].MainData WHERE ArtikelNr = @partnr AND RevNr IS NOT NULL ORDER BY NEWID()";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();

                con.Open();
                cmd.Parameters.AddWithValue("@partnr", artikelNr);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order.OrderNumber = reader[0].ToString();
                    Order.Operation = reader[2].ToString();
                    Order.PartNumber = artikelNr;
                }

                Order.WorkOperation = Manage_WorkOperation.WorkOperations.Extrudering_Termo;
            }

            mainForm.OrderInformation.cb_Operation.SelectedIndexChanged -= mainForm.Operation_SelectedIndexChanged;
            mainForm.OrderInformation.tb_OrderNr.Text = Order.OrderNumber;

            mainForm.OrderInformation.cb_Operation.SelectedIndex = -1; //Detta görs för att inte Order.Operation skall ändras vid metoden StartaOrder()
            mainForm.OrderInformation.cb_Operation.SelectedIndexChanged += mainForm.Operation_SelectedIndexChanged;


            _ = mainForm.StartOrLoadOrder(true);
        }
        private void Menu_Developer_WhosIsLoggedIn_Click(object sender, EventArgs e)
        {
            using var calender = new LoggedInUsers();
            calender.ShowDialog();
        }
        private void Developer_CountSql_Queries_Click(object sender, EventArgs e)
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
        private void Developer_Clear_Sql_Queries_Click(object sender, EventArgs e)
        {
            ServerStatus.dictMethodsSqlCounter.Clear();
            Database.SQL_Counter = 0;
        }






        private void INSERT_DATA_Korprotokoll_Value(int orderid, int descrId, string? value, int uppstart, int MachineIndex)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                BEGIN
                        IF NOT EXISTS 
                            (SELECT * FROM [Order].Data
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId AND (COALESCE(Uppstart, 0) = COALESCE(@uppstart, 0)) AND (COALESCE(MachineIndex, 0) = COALESCE(@machineindex, 0)))
                        
                            INSERT INTO [Order].Data (OrderID, ProtocolDescriptionID, Uppstart, MachineIndex, Value)     
                            VALUES (@orderid, @descrId, @uppstart, @machineindex, @value)
                END";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);
                //if (uppstart == 0)
                //    cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                //else
                cmd.Parameters.AddWithValue("@uppstart", uppstart);
                if (MachineIndex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", MachineIndex);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_DATA_Korprotokoll_TextValue(int orderid, int descrId, string? textvalue, int uppstart, int MachineIndex = 0)
        {
            //if (string.IsNullOrEmpty(value))
            //    return;
            using (var con = new SqlConnection(Database.cs_Protocol))
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_DATA_Korprotokoll_BoolValue(int orderid, int descrId, bool boolvalue, int uppstart, int MachineIndex)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
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



                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_DATA_Korprotokoll_DateValue(int orderid, int descrId, DateTime date, int uppstart, int MachineIndex)
        {
            //if (string.IsNullOrEmpty(value))
            //    return;
            using (var con = new SqlConnection(Database.cs_Protocol))
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                if (date < DateTime.Parse("1950-01-01"))
                    cmd.Parameters.AddWithValue("@datevalue", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@datevalue", date);
                //if (uppstart == 0)
                //    cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                //else
                cmd.Parameters.AddWithValue("@uppstart", uppstart);
                if (MachineIndex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", MachineIndex);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_MätMainData(int orderid, bool discarded, DateTime date, string anstnr, string sign, int rowindex)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].[MainData]
                                WHERE OrderID = @orderid AND [Date] = @date)
                        INSERT INTO [MeasureProtocol].[MainData] (OrderID, Discarded, [Date], AnstNr, Sign, RowIndex)     
                            VALUES (@orderid, @discarded, @date, @anstnr, @sign, @row)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@discarded", discarded);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@anstnr", anstnr);
            cmd.Parameters.AddWithValue("@sign", sign);
            cmd.Parameters.AddWithValue("@row", rowindex);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void INSERT_MätDataTextValue(int orderid, int descrid, string? textvalue, int rowindex)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].Data
                                WHERE OrderID = @orderid AND DescriptionID = @descrid AND RowIndex = @rowindex)
                        
                            INSERT INTO [MeasureProtocol].Data (OrderID, DescriptionID, TextValue, RowIndex)     
                            VALUES (@orderid, @descrid, @textvalue, @rowindex)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@descrId", descrid);
            cmd.Parameters.AddWithValue("@textvalue", textvalue);
            cmd.Parameters.AddWithValue("@rowindex", rowindex);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void INSERT_MätDataValue(int orderid, int descrid, string? value, int rowindex)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].Data
                                WHERE OrderID = @orderid AND DescriptionID = @descrid AND RowIndex = @rowindex)
                        
                            INSERT INTO [MeasureProtocol].Data (OrderID, DescriptionID, Value, RowIndex)     
                            VALUES (@orderid, @descrid, @value, @rowindex)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@descrId", descrid);
            SQL_Parameter.Double(cmd.Parameters, "@value", value);
            cmd.Parameters.AddWithValue("@rowindex", rowindex);
            con.Open();
            cmd.ExecuteNonQuery();
        }
        private void INSERT_MätDataBoolValue(int orderid, int descrid, bool boolvalue, int rowindex)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            var query = @"
                        IF NOT EXISTS 
                            (SELECT * FROM [MeasureProtocol].Data
                                WHERE OrderID = @orderid AND DescriptionID = @descrid AND RowIndex = @rowindex)
                        
                            INSERT INTO [MeasureProtocol].Data (OrderID, DescriptionID, BoolValue, RowIndex)     
                            VALUES (@orderid, @descrid, @boolvalue, @rowindex)";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@orderid", orderid);
            cmd.Parameters.AddWithValue("@descrId", descrid);
            SQL_Parameter.Boolean(cmd.Parameters, "@boolvalue", boolvalue);
            cmd.Parameters.AddWithValue("@rowindex", rowindex);
            con.Open();
            cmd.ExecuteNonQuery();
        }


        private void INSERT_DATA_Processcard_Value(int PartID, int templateID, string? value, byte machineindex, int type)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@partid", PartID);
                cmd.Parameters.AddWithValue("@templateid", templateID);
                if (machineindex == 0)
                    cmd.Parameters.AddWithValue("@machineindex", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@machineindex", machineindex);
                cmd.Parameters.AddWithValue("@type", type);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_DATA_Processcard_TextValue(int PartID, int templateID, string textvalue, byte machineindex, int type)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
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

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void INSERT_DATA_WithoutUppstart_Korprotokoll_TextValue(int orderid, int descrId, string? value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
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

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.String(cmd.Parameters, "@textvalue", value);

                cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void INSERT_DATA_WithoutUppstart_Korprotokoll_Value(int orderid, int descrId, string? value)
        {
            if (string.IsNullOrEmpty(value))
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    BEGIN
                        IF NOT EXISTS 
                            (SELECT * FROM Korprotokoll_Values 
                                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId)
                        
                            INSERT INTO Korprotokoll_Values (OrderID, ProtocolDescriptionID, Uppstart, Ugn, value, textvalue)     
                            VALUES (@orderid, @descrId, NULL, NULL, @value, NULL)
                        ELSE
                            UPDATE Korprotokoll_Values
			                SET value = @value
			                WHERE OrderID = @orderid AND ProtocolDescriptionID = @descrId
                    END";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@descrId", descrId);
                SQL_Parameter.Double(cmd.Parameters, "@value", value);
                cmd.Parameters.AddWithValue("@textvalue", DBNull.Value);
                cmd.Parameters.AddWithValue("@boolvalue", DBNull.Value);
                cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                con.Open();
                cmd.ExecuteNonQuery();
            }
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


        private void Menu_Developer_AddThemePicture_Click(object sender, EventArgs e)
        {
            using var addTheme = new AddTheme();
            addTheme.ShowDialog();
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

        private void testaChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainMeasureStatistics.ValidateMeasurements.AverageValues();
        }

        


        private void flyttaDataFrånSvetsnigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
            List<int> listOrderId = new List<int>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                   SELECT OrderID FROM [Order].MainData WHERE WorkoperationID = 14";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[0].ToString(), out var orderid);
                    listOrderId.Add(orderid);
                }
            }

            foreach (var orderid in listOrderId)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                        SELECT 
                            [OrderID]
                            ,[Svets]
                            ,[Tid_Förvärme]
                            ,[Svetsförflyttning]
                            ,[Tid_Bindvärme]
                            ,[Tid_Kylluft]
                            ,[Temperatur]
                            ,[Pinne_OD_Stål]
                            ,[Pinne_OD_PTFE]              
                            ,[Värmebackar_Bredd]
                            ,[Värmebackar_Hål],
                            TRY_CAST(
                                CONVERT(varchar(10), TRY_CAST([Datum] AS date), 120) + ' ' + 
                                CONVERT(varchar(8), TRY_CAST([Tid] AS time), 108)
                                AS datetime
                            ) AS [DatumTid]
                            ,[AnstNr]
                            ,[Sign]
                        FROM Korprotokoll_Svetsning_Maskinparametrar
                        WHERE OrderID = @orderid
                        ORDER BY  [DatumTid]";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@orderid", orderid);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    var uppstart = 1;
                    while (reader.Read())
                    {
                        var svets = reader["Svets"].ToString();
                        var tid_Förvärme = reader["Tid_Förvärme"].ToString();
                        var svetsförflyttning = reader["Svetsförflyttning"].ToString();
                        var tid_Bindvärme = reader["Tid_Bindvärme"].ToString();
                        var tid_Kylluft = reader["Tid_Kylluft"].ToString();
                        var temperatur = reader["Temperatur"].ToString();
                        var pinne_OD_Stål = reader["Pinne_OD_Stål"].ToString();
                        var pinne_OD_PTFE = reader["Pinne_OD_PTFE"].ToString();
                        var värmebackar_Bredd = reader["Värmebackar_Bredd"].ToString();
                        var värmebackar_Hål = reader["Värmebackar_Hål"].ToString();
                        DateTime.TryParse(reader["DatumTid"].ToString(), out var datum);
                        var anstNr = reader["AnstNr"].ToString();
                        var sign = reader["Sign"].ToString();
                        var name = Person.Get_NameWithAnstNr(anstNr);

                        INSERT_DATA_Korprotokoll_TextValue(orderid, 404, svets, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 405, tid_Förvärme, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 406, svetsförflyttning, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 407, tid_Bindvärme, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 408, tid_Kylluft, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 276, temperatur, uppstart, 1);

                        INSERT_DATA_Korprotokoll_Value(orderid, 409, pinne_OD_Stål, uppstart, 1);
                        INSERT_DATA_Korprotokoll_TextValue(orderid, 410, pinne_OD_PTFE, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 411, värmebackar_Bredd, uppstart, 1);
                        INSERT_DATA_Korprotokoll_Value(orderid, 412, värmebackar_Hål, uppstart, 1);
                        INSERT_DATA_Korprotokoll_TextValue(orderid, 158, anstNr, uppstart, 1);
                        INSERT_DATA_Korprotokoll_TextValue(orderid, 157, sign, uppstart, 1);
                        INSERT_DATA_Korprotokoll_DateValue(orderid, 171, datum, uppstart, 1);
                        INSERT_DATA_Korprotokoll_TextValue(orderid, 322, name, uppstart, 1);
                        uppstart++;
                    }
                }
            }
            MessageBox.Show("Klart");

        }
        private void flyttaMätDataFrånSvetsnigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
            List<int> listOrderId = new List<int>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                SELECT DISTINCT m.OrderID
FROM [Order].MainData m
INNER JOIN Korprotokoll_Svetsning_Parametrar k
    ON m.OrderID = k.OrderID
LEFT JOIN MeasureProtocol.Data d
    ON m.OrderID = d.OrderID
WHERE m.WorkoperationID = 14
  AND d.OrderID IS NULL

  ORDER BY OrderID;
";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@uppstart", DBNull.Value);
                cmd.Parameters.AddWithValue("@ugn", DBNull.Value);

                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int.TryParse(reader[0].ToString(), out var orderid);
                    listOrderId.Add(orderid);
                }
            }

            foreach (var orderid in listOrderId)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                        SELECT 
                            [Kasserad]
                            ,[Inledande_OrderNr]
                            ,[Inledande_Påse]
                            ,[Inledande_UppmättPinne]
                            ,[Inledande_ID]
                            ,[Inledande_OD]
                            ,[Inledande_Längd]
                            ,[Inspektion_Utsida]
                            ,[Inspektion_Insida]
                             ,TRY_CAST(
                                CONVERT(varchar(10), TRY_CAST([Datum] AS date), 120) + ' ' + 
                                CONVERT(varchar(8), TRY_CAST([Tid] AS time), 108)
                                AS datetime
                            ) AS [DatumTid]
                            ,[AnstNr]
                            ,[Sign]
                            
                        FROM [Korprotokoll_Svetsning_Parametrar]
                        WHERE OrderID = @orderid
                        ORDER BY  [DatumTid]";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", orderid);
                con.Open();
                var reader = cmd.ExecuteReader();
                var row = 1;
                while (reader.Read())
                {
                    var kasserad = bool.Parse(reader["Kasserad"].ToString());
                    var inledandeOrderNr = reader["Inledande_OrderNr"].ToString();
                    var inledandePåse = reader["Inledande_Påse"].ToString();
                    var inledandePinne = reader["Inledande_UppmättPinne"].ToString();
                    var inledandeID = reader["Inledande_ID"].ToString();
                    var inledandeOD = reader["Inledande_OD"].ToString();
                    var inledandeLängd = reader["Inledande_Längd"].ToString();
                    var inspektion_Ut = bool.Parse(reader["Inspektion_Utsida"].ToString());
                    var inspektion_In = bool.Parse(reader["Inspektion_Insida"].ToString());

                    DateTime.TryParse(reader["DatumTid"].ToString(), out var datum);
                    var anstNr = reader["AnstNr"].ToString();
                    var sign = reader["Sign"].ToString();

                    INSERT_MätMainData(orderid, kasserad, datum, anstNr, sign, row);
                    INSERT_MätDataTextValue(orderid, 68, inledandeOrderNr, row);
                    INSERT_MätDataValue(orderid, 37, inledandePåse, row);
                    INSERT_MätDataValue(orderid, 69, inledandePinne, row);
                    INSERT_MätDataValue(orderid, 1, inledandeID, row);
                    INSERT_MätDataValue(orderid, 11, inledandeOD, row);
                    INSERT_MätDataValue(orderid, 34, inledandeLängd, row);
                    INSERT_MätDataBoolValue(orderid, 40, inspektion_Ut, row);
                    INSERT_MätDataBoolValue(orderid, 70, inspektion_In, row);
                    row++;
                }
            }
            MessageBox.Show("Klart");

        }


        private void menu_MedExpand(object sender, EventArgs e)
        {
            List<string> list = Monitor.Monitor.List_All_WithExpand();
        }

        private void utanExpand(object sender, EventArgs e)
        {
            List<string> list = Monitor.Monitor.List_All_Tools_WithOutExpand();
        }
    }
}
