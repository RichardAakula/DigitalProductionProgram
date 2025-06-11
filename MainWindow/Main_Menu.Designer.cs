
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class Main_Menu
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Menu_Arkiv = new ToolStripMenuItem();
            Menu_Arkiv_NewOrder = new ToolStripMenuItem();
            Menu_Arkiv_Open = new ToolStripMenuItem();
            Menu_Arkiv_Preview = new ToolStripMenuItem();
            Menu_Arkiv_Print = new ToolStripMenuItem();
            Menu_Arkiv_ManageDatabase = new ToolStripMenuItem();
            Menu_Arkiv_Exit = new ToolStripMenuItem();
            Menu_Order = new ToolStripMenuItem();
            Menu_Order_OrderDone = new ToolStripMenuItem();
            Menu_Order_EditOrder = new ToolStripMenuItem();
            Menu_Order_DeleteOrder = new ToolStripMenuItem();
            Menu_Order_ReportProblemProductionSupport = new ToolStripMenuItem();
            Menu_Order_CreateTestOrder = new ToolStripMenuItem();
            Menu_Order_OpenRandomOrder = new ToolStripMenuItem();
            Menu_Order_QC_Feedback = new ToolStripMenuItem();
            Menu_Order_LinkOrder = new ToolStripMenuItem();
            Menu_Order_ReLink_Processcard = new ToolStripMenuItem();
            Menu_Order_ReLink_Protocol = new ToolStripMenuItem();
            Menu_Order_ReLink_MeasureProtocol = new ToolStripMenuItem();
            Menu_Protocol = new ToolStripMenuItem();
            Menu_Protocol_ManageProcesscards = new ToolStripMenuItem();
            Menu_Protocol_Unlock_ValidatedProcesscard = new ToolStripMenuItem();
            Menu_Protocol_ManageTemplates = new ToolStripMenuItem();
            Menu_Protocol_ManageTemplates_Protocols = new ToolStripMenuItem();
            Menu_Protocol_ManageTemplates_LineClearance = new ToolStripMenuItem();
            Menu_Protocol_ManageTemplates_MeasureProtocol = new ToolStripMenuItem();
            Menu_User = new ToolStripMenuItem();
            Menu_User_LogIn = new ToolStripMenuItem();
            Menu_User_LogOut = new ToolStripMenuItem();
            Menu_User_WhoIsLoggedIn = new ToolStripMenuItem();
            Menu_User_LogOutUser = new ToolStripMenuItem();
            Menu_User_CheckMyAnalysis = new ToolStripMenuItem();
            Menu_User_Authorities = new ToolStripMenuItem();
            Menu_User_Authorities_Roles = new ToolStripMenuItem();
            Menu_User_Authorities_CustomMailAddresses = new ToolStripMenuItem();
            Menu_User_Authorities_CustomWorkoperations = new ToolStripMenuItem();
            Menu_User_Authorities_CustomFactories = new ToolStripMenuItem();
            Menu_User_EditUser = new ToolStripMenuItem();
            Menu_Settings = new ToolStripMenuItem();
            Menu_Settings_Settings = new ToolStripMenuItem();
            Menu_Settings_CalculateMaterial = new ToolStripMenuItem();
            Menu_Settings_ChangeColorHS_Machine = new ToolStripMenuItem();
            Menu_Settings_ToolsCalculator = new ToolStripMenuItem();
            Menu_Themes = new ToolStripMenuItem();
            Menu_Theme_Beach = new ToolStripMenuItem();
            Menu_Theme_Forest = new ToolStripMenuItem();
            Menu_Theme_Sky = new ToolStripMenuItem();
            Menu_Theme_Sun = new ToolStripMenuItem();
            Menu_Theme_Water = new ToolStripMenuItem();
            Menu_Theme_Black = new ToolStripMenuItem();
            Menu_Theme_Winter = new ToolStripMenuItem();
            Menu_Theme_Light = new ToolStripMenuItem();
            Menu_Theme_Pink = new ToolStripMenuItem();
            Menu_Theme_Cars = new ToolStripMenuItem();
            Menu_Theme_Animals = new ToolStripMenuItem();
            Menu_Theme_Music = new ToolStripMenuItem();
            Menu_Theme_Houses = new ToolStripMenuItem();
            Menu_Theme_Nature = new ToolStripMenuItem();
            Menu_Theme_Dark = new ToolStripMenuItem();
            Menu_Theme_Discography = new ToolStripMenuItem();
            Menu_Theme_Optinova = new ToolStripMenuItem();
            Menu_Help = new ToolStripMenuItem();
            Menu_Help_ChangeLog = new ToolStripMenuItem();
            Menu_Help_ReportBug = new ToolStripMenuItem();
            Menu_Help_InstructionVideos = new ToolStripMenuItem();
            Menu_Help_InstructionVideos_SignIn = new ToolStripMenuItem();
            Menu_Help_InstructionVideos_AddUser = new ToolStripMenuItem();
            Menu_Help_InstructionVideos_RecentlyOpenedOrders = new ToolStripMenuItem();
            Menu_Help_InstructionVideos_ManageAuthorities = new ToolStripMenuItem();
            Menu_Help_InstructionVideos_SaveProcessCard = new ToolStripMenuItem();
            Menu_Developer = new ToolStripMenuItem();
            Menu_Developer_GetOrderInfo = new ToolStripMenuItem();
            Menu_Developer_SendMailToAllUsers = new ToolStripMenuItem();
            Menu_Developer_AddGallup = new ToolStripMenuItem();
            Menu_Developer_CheckGallup = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder_1 = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder_ = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder_3 = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder_4 = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder_5 = new ToolStripMenuItem();
            Menu_Developer_OpenRandomOrder_6 = new ToolStripMenuItem();
            Menu_Developer_InsertHalvfabrikat = new ToolStripMenuItem();
            Menu_Developer_NewProtocol_Extrudering_TEF = new ToolStripMenuItem();
            Menu_Developer_Test_RGB = new ToolStripMenuItem();
            Menu_Developer_NewMeasureProtocol = new ToolStripMenuItem();
            Menu_Developer_MoveDataKorprotokollValues = new ToolStripMenuItem();
            Menu_Utvecklare_MoveDataFEP = new ToolStripMenuItem();
            Menu_Developer_Timer_test = new ToolStripMenuItem();
            moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem = new ToolStripMenuItem();
            raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem = new ToolStripMenuItem();
            Menu_Developer_ExportHS_Data = new ToolStripMenuItem();
            kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem = new ToolStripMenuItem();
            Menu_Developer_GetDataForQuoting = new ToolStripMenuItem();
            Menu_Developer_INSERT_Rengjort = new ToolStripMenuItem();
            Menu_Developer_INSERT_Verktyg_Typ = new ToolStripMenuItem();
            testaNAntalKörningarPåArtikelNrToolStripMenuItem = new ToolStripMenuItem();
            Menu_Developer_AddThemePicture = new ToolStripMenuItem();
            Menu_Developer_TestNewProtocol = new ToolStripMenuItem();
            testCalendarToolStripMenuItem = new ToolStripMenuItem();
            Developer_AddLineClearance_Table = new ToolStripMenuItem();
            påskäggToolStripMenuItem = new ToolStripMenuItem();
            menuStrip = new MenuStrip();
            Menu_Equipment = new ToolStripMenuItem();
            Menu_Equipment_UseFilter = new ToolStripMenuItem();
            Menu_Equipment_UseSilpaket = new ToolStripMenuItem();
            testarEnNyBranchToolStripMenuItem = new ToolStripMenuItem();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // Menu_Arkiv
            // 
            Menu_Arkiv.DropDownItems.AddRange(new ToolStripItem[] { Menu_Arkiv_NewOrder, Menu_Arkiv_Open, Menu_Arkiv_Preview, Menu_Arkiv_Print, Menu_Arkiv_ManageDatabase, Menu_Arkiv_Exit });
            Menu_Arkiv.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Arkiv.ForeColor = Color.DeepSkyBlue;
            Menu_Arkiv.Name = "Menu_Arkiv";
            Menu_Arkiv.Size = new Size(52, 32);
            Menu_Arkiv.Text = "Arkiv";
            Menu_Arkiv.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_Arkiv_NewOrder
            // 
            Menu_Arkiv_NewOrder.Name = "Menu_Arkiv_NewOrder";
            Menu_Arkiv_NewOrder.Size = new Size(281, 22);
            Menu_Arkiv_NewOrder.Text = "Ny Order";
            Menu_Arkiv_NewOrder.Click += Menu_Arkiv_NyOrder_Click;
            // 
            // Menu_Arkiv_Open
            // 
            Menu_Arkiv_Open.Name = "Menu_Arkiv_Open";
            Menu_Arkiv_Open.ShortcutKeys = Keys.Control | Keys.O;
            Menu_Arkiv_Open.Size = new Size(281, 22);
            Menu_Arkiv_Open.Text = "Öppna...";
            Menu_Arkiv_Open.Click += Menu_Arkiv_Öppna_Click;
            // 
            // Menu_Arkiv_Preview
            // 
            Menu_Arkiv_Preview.Name = "Menu_Arkiv_Preview";
            Menu_Arkiv_Preview.ShortcutKeys = Keys.Control | Keys.F;
            Menu_Arkiv_Preview.Size = new Size(281, 22);
            Menu_Arkiv_Preview.Text = "Förhandsgranska...";
            Menu_Arkiv_Preview.Click += Menu_Arkiv_Förhandsgranska_Click;
            // 
            // Menu_Arkiv_Print
            // 
            Menu_Arkiv_Print.Name = "Menu_Arkiv_Print";
            Menu_Arkiv_Print.Size = new Size(281, 22);
            Menu_Arkiv_Print.Text = "Skriv ut...(Endast kopia)";
            Menu_Arkiv_Print.Click += Menu_Arkiv_SkrivUt_Click;
            // 
            // Menu_Arkiv_ManageDatabase
            // 
            Menu_Arkiv_ManageDatabase.Name = "Menu_Arkiv_ManageDatabase";
            Menu_Arkiv_ManageDatabase.Size = new Size(281, 22);
            Menu_Arkiv_ManageDatabase.Text = "Hantera Anslutningsinställningar";
            Menu_Arkiv_ManageDatabase.Click += Menu_Arkiv_ManageDatabase_Click;
            // 
            // Menu_Arkiv_Exit
            // 
            Menu_Arkiv_Exit.Name = "Menu_Arkiv_Exit";
            Menu_Arkiv_Exit.ShortcutKeys = Keys.Control | Keys.A;
            Menu_Arkiv_Exit.Size = new Size(281, 22);
            Menu_Arkiv_Exit.Text = "Avsluta";
            Menu_Arkiv_Exit.Click += Menu_Arkiv_Avsluta_Click;
            // 
            // Menu_Order
            // 
            Menu_Order.DropDownItems.AddRange(new ToolStripItem[] { Menu_Order_OrderDone, Menu_Order_EditOrder, Menu_Order_DeleteOrder, Menu_Order_ReportProblemProductionSupport, Menu_Order_CreateTestOrder, Menu_Order_OpenRandomOrder, Menu_Order_QC_Feedback, Menu_Order_LinkOrder });
            Menu_Order.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Order.ForeColor = Color.DeepSkyBlue;
            Menu_Order.Name = "Menu_Order";
            Menu_Order.Size = new Size(55, 32);
            Menu_Order.Text = "Order";
            Menu_Order.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_Order_OrderDone
            // 
            Menu_Order_OrderDone.AccessibleRole = AccessibleRole.MenuBar;
            Menu_Order_OrderDone.Enabled = false;
            Menu_Order_OrderDone.Name = "Menu_Order_OrderDone";
            Menu_Order_OrderDone.Size = new Size(348, 22);
            Menu_Order_OrderDone.Text = "Order Klar";
            Menu_Order_OrderDone.Click += Menu_Order_OrderKlar_Click;
            // 
            // Menu_Order_EditOrder
            // 
            Menu_Order_EditOrder.Enabled = false;
            Menu_Order_EditOrder.Name = "Menu_Order_EditOrder";
            Menu_Order_EditOrder.Size = new Size(348, 22);
            Menu_Order_EditOrder.Text = "Redigera en färdig Order";
            Menu_Order_EditOrder.Click += Menu_Order_RedigeraOrder_Click;
            // 
            // Menu_Order_DeleteOrder
            // 
            Menu_Order_DeleteOrder.Enabled = false;
            Menu_Order_DeleteOrder.Name = "Menu_Order_DeleteOrder";
            Menu_Order_DeleteOrder.Size = new Size(348, 22);
            Menu_Order_DeleteOrder.Text = "Radera Order";
            Menu_Order_DeleteOrder.Click += Menu_Order_RaderaOrder_ClickAsync;
            // 
            // Menu_Order_ReportProblemProductionSupport
            // 
            Menu_Order_ReportProblemProductionSupport.Enabled = false;
            Menu_Order_ReportProblemProductionSupport.Name = "Menu_Order_ReportProblemProductionSupport";
            Menu_Order_ReportProblemProductionSupport.Size = new Size(348, 22);
            Menu_Order_ReportProblemProductionSupport.Text = "Rapportera problem till produktionssupport";
            Menu_Order_ReportProblemProductionSupport.Click += Menu_Order_Rapport_Jira_Click;
            // 
            // Menu_Order_CreateTestOrder
            // 
            Menu_Order_CreateTestOrder.Enabled = false;
            Menu_Order_CreateTestOrder.Name = "Menu_Order_CreateTestOrder";
            Menu_Order_CreateTestOrder.Size = new Size(348, 22);
            Menu_Order_CreateTestOrder.Text = "Skapa Testorder";
            Menu_Order_CreateTestOrder.Click += Menu_Order_SkapaTestOrder_Click;
            // 
            // Menu_Order_OpenRandomOrder
            // 
            Menu_Order_OpenRandomOrder.MergeAction = MergeAction.Insert;
            Menu_Order_OpenRandomOrder.Name = "Menu_Order_OpenRandomOrder";
            Menu_Order_OpenRandomOrder.ShortcutKeys = Keys.Control | Keys.R;
            Menu_Order_OpenRandomOrder.Size = new Size(348, 22);
            Menu_Order_OpenRandomOrder.Text = "Öppna Random Order";
            Menu_Order_OpenRandomOrder.Click += Menu_Order_OpenRandomOrder_Click;
            // 
            // Menu_Order_QC_Feedback
            // 
            Menu_Order_QC_Feedback.Name = "Menu_Order_QC_Feedback";
            Menu_Order_QC_Feedback.Size = new Size(348, 22);
            Menu_Order_QC_Feedback.Text = "Lämna feedback för denna körning";
            Menu_Order_QC_Feedback.Click += Menu_Order_QC_Feedback_Click;
            // 
            // Menu_Order_LinkOrder
            // 
            Menu_Order_LinkOrder.DropDownItems.AddRange(new ToolStripItem[] { Menu_Order_ReLink_Processcard, Menu_Order_ReLink_Protocol, Menu_Order_ReLink_MeasureProtocol });
            Menu_Order_LinkOrder.Name = "Menu_Order_LinkOrder";
            Menu_Order_LinkOrder.Size = new Size(348, 22);
            Menu_Order_LinkOrder.Text = "Länka Order";
            // 
            // Menu_Order_ReLink_Processcard
            // 
            Menu_Order_ReLink_Processcard.Name = "Menu_Order_ReLink_Processcard";
            Menu_Order_ReLink_Processcard.Size = new Size(253, 22);
            Menu_Order_ReLink_Processcard.Text = "Till nytt Processkort";
            Menu_Order_ReLink_Processcard.Click += Menu_Order_Relink_Processcard_Click;
            // 
            // Menu_Order_ReLink_Protocol
            // 
            Menu_Order_ReLink_Protocol.Name = "Menu_Order_ReLink_Protocol";
            Menu_Order_ReLink_Protocol.Size = new Size(253, 22);
            Menu_Order_ReLink_Protocol.Text = "Till ny Mall för Protokoll";
            Menu_Order_ReLink_Protocol.Click += Menu_Order_Relink_Protocol_Click;
            // 
            // Menu_Order_ReLink_MeasureProtocol
            // 
            Menu_Order_ReLink_MeasureProtocol.Name = "Menu_Order_ReLink_MeasureProtocol";
            Menu_Order_ReLink_MeasureProtocol.Size = new Size(253, 22);
            Menu_Order_ReLink_MeasureProtocol.Text = "Till ny Mall för Mätprotokoll";
            Menu_Order_ReLink_MeasureProtocol.Click += Menu_Order_Relink_MeasureProtocol_Click;
            // 
            // Menu_Protocol
            // 
            Menu_Protocol.DropDownItems.AddRange(new ToolStripItem[] { Menu_Protocol_ManageProcesscards, Menu_Protocol_Unlock_ValidatedProcesscard, Menu_Protocol_ManageTemplates });
            Menu_Protocol.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Protocol.ForeColor = Color.DeepSkyBlue;
            Menu_Protocol.Name = "Menu_Protocol";
            Menu_Protocol.Size = new Size(77, 32);
            Menu_Protocol.Text = "Protokoll";
            // 
            // Menu_Protocol_ManageProcesscards
            // 
            Menu_Protocol_ManageProcesscards.Name = "Menu_Protocol_ManageProcesscards";
            Menu_Protocol_ManageProcesscards.ShortcutKeys = Keys.Control | Keys.P;
            Menu_Protocol_ManageProcesscards.Size = new Size(259, 22);
            Menu_Protocol_ManageProcesscards.Text = "Hantera Processkort";
            Menu_Protocol_ManageProcesscards.Click += Menu_Processkort_HanteraProcesskort_Click;
            // 
            // Menu_Protocol_Unlock_ValidatedProcesscard
            // 
            Menu_Protocol_Unlock_ValidatedProcesscard.Enabled = false;
            Menu_Protocol_Unlock_ValidatedProcesscard.Name = "Menu_Protocol_Unlock_ValidatedProcesscard";
            Menu_Protocol_Unlock_ValidatedProcesscard.Size = new Size(259, 22);
            Menu_Protocol_Unlock_ValidatedProcesscard.Text = "Lås Upp Validerat Processkort";
            Menu_Protocol_Unlock_ValidatedProcesscard.Visible = false;
            // 
            // Menu_Protocol_ManageTemplates
            // 
            Menu_Protocol_ManageTemplates.DropDownItems.AddRange(new ToolStripItem[] { Menu_Protocol_ManageTemplates_Protocols, Menu_Protocol_ManageTemplates_LineClearance, Menu_Protocol_ManageTemplates_MeasureProtocol });
            Menu_Protocol_ManageTemplates.Name = "Menu_Protocol_ManageTemplates";
            Menu_Protocol_ManageTemplates.Size = new Size(259, 22);
            Menu_Protocol_ManageTemplates.Text = "Hantera Mallar...";
            Menu_Protocol_ManageTemplates.Visible = false;
            // 
            // Menu_Protocol_ManageTemplates_Protocols
            // 
            Menu_Protocol_ManageTemplates_Protocols.Name = "Menu_Protocol_ManageTemplates_Protocols";
            Menu_Protocol_ManageTemplates_Protocols.Size = new Size(166, 22);
            Menu_Protocol_ManageTemplates_Protocols.Text = "Protokoll";
            Menu_Protocol_ManageTemplates_Protocols.Click += Menu_Protocol_ManageTemplates_Protocols_Click;
            // 
            // Menu_Protocol_ManageTemplates_LineClearance
            // 
            Menu_Protocol_ManageTemplates_LineClearance.Name = "Menu_Protocol_ManageTemplates_LineClearance";
            Menu_Protocol_ManageTemplates_LineClearance.Size = new Size(166, 22);
            Menu_Protocol_ManageTemplates_LineClearance.Text = "Line-Clearance";
            Menu_Protocol_ManageTemplates_LineClearance.Click += Menu_Protocol_ManageTemplates_LineClearance_Click;
            // 
            // Menu_Protocol_ManageTemplates_MeasureProtocol
            // 
            Menu_Protocol_ManageTemplates_MeasureProtocol.Name = "Menu_Protocol_ManageTemplates_MeasureProtocol";
            Menu_Protocol_ManageTemplates_MeasureProtocol.Size = new Size(166, 22);
            Menu_Protocol_ManageTemplates_MeasureProtocol.Text = "Mätprotokoll";
            Menu_Protocol_ManageTemplates_MeasureProtocol.Click += Menu_Protocol_ManageTemplates_MeasureProtocol_Click;
            // 
            // Menu_User
            // 
            Menu_User.DropDownItems.AddRange(new ToolStripItem[] { Menu_User_LogIn, Menu_User_LogOut, Menu_User_WhoIsLoggedIn, Menu_User_LogOutUser, Menu_User_CheckMyAnalysis, Menu_User_Authorities, Menu_User_EditUser });
            Menu_User.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_User.ForeColor = Color.DeepSkyBlue;
            Menu_User.Name = "Menu_User";
            Menu_User.Size = new Size(86, 32);
            Menu_User.Text = "Användare";
            Menu_User.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_User_LogIn
            // 
            Menu_User_LogIn.Name = "Menu_User_LogIn";
            Menu_User_LogIn.Size = new Size(411, 22);
            Menu_User_LogIn.Text = "Logga in...";
            Menu_User_LogIn.Click += Menu_User_SignIn_Click;
            // 
            // Menu_User_LogOut
            // 
            Menu_User_LogOut.Name = "Menu_User_LogOut";
            Menu_User_LogOut.Size = new Size(411, 22);
            Menu_User_LogOut.Text = "Logga ut...";
            Menu_User_LogOut.Click += Menu_User_SignOut_Click;
            // 
            // Menu_User_WhoIsLoggedIn
            // 
            Menu_User_WhoIsLoggedIn.Name = "Menu_User_WhoIsLoggedIn";
            Menu_User_WhoIsLoggedIn.Size = new Size(411, 22);
            Menu_User_WhoIsLoggedIn.Text = "Vem är Inloggad?";
            Menu_User_WhoIsLoggedIn.Click += Menu_User_Inloggad_Click;
            // 
            // Menu_User_LogOutUser
            // 
            Menu_User_LogOutUser.Name = "Menu_User_LogOutUser";
            Menu_User_LogOutUser.Size = new Size(411, 22);
            Menu_User_LogOutUser.Text = "Logga ut användare från Processkortet/Körprotokollet";
            Menu_User_LogOutUser.Click += Menu_User_Logga_ut_användare_Click;
            // 
            // Menu_User_CheckMyAnalysis
            // 
            Menu_User_CheckMyAnalysis.Name = "Menu_User_CheckMyAnalysis";
            Menu_User_CheckMyAnalysis.Size = new Size(411, 22);
            Menu_User_CheckMyAnalysis.Text = "Kolla My Analysis";
            Menu_User_CheckMyAnalysis.Visible = false;
            Menu_User_CheckMyAnalysis.Click += Menu_User_CheckMyAnalysis_Click;
            // 
            // Menu_User_Authorities
            // 
            Menu_User_Authorities.DropDownItems.AddRange(new ToolStripItem[] { Menu_User_Authorities_Roles, Menu_User_Authorities_CustomMailAddresses, Menu_User_Authorities_CustomWorkoperations, Menu_User_Authorities_CustomFactories });
            Menu_User_Authorities.Name = "Menu_User_Authorities";
            Menu_User_Authorities.Size = new Size(411, 22);
            Menu_User_Authorities.Text = "Behörigheter";
            // 
            // Menu_User_Authorities_Roles
            // 
            Menu_User_Authorities_Roles.Name = "Menu_User_Authorities_Roles";
            Menu_User_Authorities_Roles.Size = new Size(258, 22);
            Menu_User_Authorities_Roles.Text = "Behörigheter Roller";
            Menu_User_Authorities_Roles.Click += Menu_User_Authorities_Roles_Click;
            // 
            // Menu_User_Authorities_CustomMailAddresses
            // 
            Menu_User_Authorities_CustomMailAddresses.Name = "Menu_User_Authorities_CustomMailAddresses";
            Menu_User_Authorities_CustomMailAddresses.Size = new Size(258, 22);
            Menu_User_Authorities_CustomMailAddresses.Text = "Anpassade Mailadresser";
            Menu_User_Authorities_CustomMailAddresses.Click += Menu_User_Authorities_CustomMailAddresses_Click;
            // 
            // Menu_User_Authorities_CustomWorkoperations
            // 
            Menu_User_Authorities_CustomWorkoperations.Name = "Menu_User_Authorities_CustomWorkoperations";
            Menu_User_Authorities_CustomWorkoperations.Size = new Size(258, 22);
            Menu_User_Authorities_CustomWorkoperations.Text = "Anpassade Arbetsoperationer";
            Menu_User_Authorities_CustomWorkoperations.Click += Menu_User_Authorities_CustomWorkoperations_Click;
            // 
            // Menu_User_Authorities_CustomFactories
            // 
            Menu_User_Authorities_CustomFactories.Name = "Menu_User_Authorities_CustomFactories";
            Menu_User_Authorities_CustomFactories.Size = new Size(258, 22);
            Menu_User_Authorities_CustomFactories.Text = "Anpassade Fabriker";
            Menu_User_Authorities_CustomFactories.Click += Menu_User_Authorities_CustomFactories_Click;
            // 
            // Menu_User_EditUser
            // 
            Menu_User_EditUser.Name = "Menu_User_EditUser";
            Menu_User_EditUser.Size = new Size(411, 22);
            Menu_User_EditUser.Text = "Redigera Användare";
            Menu_User_EditUser.Click += Menu_User_EditUser_Click;
            // 
            // Menu_Settings
            // 
            Menu_Settings.DropDownItems.AddRange(new ToolStripItem[] { Menu_Settings_Settings, Menu_Settings_CalculateMaterial, Menu_Settings_ChangeColorHS_Machine, Menu_Settings_ToolsCalculator });
            Menu_Settings.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Settings.ForeColor = Color.DeepSkyBlue;
            Menu_Settings.Name = "Menu_Settings";
            Menu_Settings.Size = new Size(67, 32);
            Menu_Settings.Text = "Verktyg";
            Menu_Settings.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_Settings_Settings
            // 
            Menu_Settings_Settings.Name = "Menu_Settings_Settings";
            Menu_Settings_Settings.Size = new Size(212, 22);
            Menu_Settings_Settings.Text = "Inställningar";
            Menu_Settings_Settings.Click += Menu_Verktyg_Inställningar_Click;
            // 
            // Menu_Settings_CalculateMaterial
            // 
            Menu_Settings_CalculateMaterial.Name = "Menu_Settings_CalculateMaterial";
            Menu_Settings_CalculateMaterial.Size = new Size(212, 22);
            Menu_Settings_CalculateMaterial.Text = "Beräkna Material";
            Menu_Settings_CalculateMaterial.Visible = false;
            Menu_Settings_CalculateMaterial.Click += Menu_Verktyg_Beräkna_Material_Click;
            // 
            // Menu_Settings_ChangeColorHS_Machine
            // 
            Menu_Settings_ChangeColorHS_Machine.Name = "Menu_Settings_ChangeColorHS_Machine";
            Menu_Settings_ChangeColorHS_Machine.Size = new Size(212, 22);
            Menu_Settings_ChangeColorHS_Machine.Text = "Ändra färg HS-Maskin";
            Menu_Settings_ChangeColorHS_Machine.Click += Menu_Settings_ChangeColorHS_Machine_Click;
            // 
            // Menu_Settings_ToolsCalculator
            // 
            Menu_Settings_ToolsCalculator.Name = "Menu_Settings_ToolsCalculator";
            Menu_Settings_ToolsCalculator.Size = new Size(212, 22);
            Menu_Settings_ToolsCalculator.Text = "Verktygsberäkning";
            Menu_Settings_ToolsCalculator.Click += Menu_Settings_ToolsCalculator_Click;
            // 
            // Menu_Themes
            // 
            Menu_Themes.DropDownItems.AddRange(new ToolStripItem[] { Menu_Theme_Beach, Menu_Theme_Forest, Menu_Theme_Sky, Menu_Theme_Sun, Menu_Theme_Water, Menu_Theme_Black, Menu_Theme_Winter, Menu_Theme_Light, Menu_Theme_Pink, Menu_Theme_Cars, Menu_Theme_Animals, Menu_Theme_Music, Menu_Theme_Houses, Menu_Theme_Nature, Menu_Theme_Dark, Menu_Theme_Discography, Menu_Theme_Optinova });
            Menu_Themes.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Themes.ForeColor = Color.DeepSkyBlue;
            Menu_Themes.Name = "Menu_Themes";
            Menu_Themes.Size = new Size(61, 32);
            Menu_Themes.Text = "Teman";
            Menu_Themes.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_Theme_Beach
            // 
            Menu_Theme_Beach.BackColor = Color.Wheat;
            Menu_Theme_Beach.Name = "Menu_Theme_Beach";
            Menu_Theme_Beach.Size = new Size(153, 22);
            Menu_Theme_Beach.Text = "Beach";
            Menu_Theme_Beach.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Forest
            // 
            Menu_Theme_Forest.BackColor = Color.SeaGreen;
            Menu_Theme_Forest.Name = "Menu_Theme_Forest";
            Menu_Theme_Forest.Size = new Size(153, 22);
            Menu_Theme_Forest.Text = "Forest";
            Menu_Theme_Forest.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Sky
            // 
            Menu_Theme_Sky.BackColor = Color.LightSteelBlue;
            Menu_Theme_Sky.Name = "Menu_Theme_Sky";
            Menu_Theme_Sky.Size = new Size(153, 22);
            Menu_Theme_Sky.Text = "Sky";
            Menu_Theme_Sky.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Sun
            // 
            Menu_Theme_Sun.BackColor = Color.Yellow;
            Menu_Theme_Sun.Name = "Menu_Theme_Sun";
            Menu_Theme_Sun.Size = new Size(153, 22);
            Menu_Theme_Sun.Text = "Sun";
            Menu_Theme_Sun.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Water
            // 
            Menu_Theme_Water.BackColor = Color.MediumTurquoise;
            Menu_Theme_Water.Name = "Menu_Theme_Water";
            Menu_Theme_Water.Size = new Size(153, 22);
            Menu_Theme_Water.Text = "Water";
            Menu_Theme_Water.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Black
            // 
            Menu_Theme_Black.BackColor = Color.Black;
            Menu_Theme_Black.ForeColor = SystemColors.ControlDarkDark;
            Menu_Theme_Black.Name = "Menu_Theme_Black";
            Menu_Theme_Black.Size = new Size(153, 22);
            Menu_Theme_Black.Text = "Black";
            Menu_Theme_Black.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Winter
            // 
            Menu_Theme_Winter.BackColor = Color.White;
            Menu_Theme_Winter.Name = "Menu_Theme_Winter";
            Menu_Theme_Winter.Size = new Size(153, 22);
            Menu_Theme_Winter.Text = "Winter";
            Menu_Theme_Winter.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Light
            // 
            Menu_Theme_Light.BackColor = Color.SeaShell;
            Menu_Theme_Light.Name = "Menu_Theme_Light";
            Menu_Theme_Light.Size = new Size(153, 22);
            Menu_Theme_Light.Text = "Light";
            Menu_Theme_Light.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Pink
            // 
            Menu_Theme_Pink.BackColor = Color.Violet;
            Menu_Theme_Pink.Name = "Menu_Theme_Pink";
            Menu_Theme_Pink.Size = new Size(153, 22);
            Menu_Theme_Pink.Text = "Pink";
            Menu_Theme_Pink.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Cars
            // 
            Menu_Theme_Cars.Name = "Menu_Theme_Cars";
            Menu_Theme_Cars.Size = new Size(153, 22);
            Menu_Theme_Cars.Text = "Cars";
            Menu_Theme_Cars.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Animals
            // 
            Menu_Theme_Animals.Name = "Menu_Theme_Animals";
            Menu_Theme_Animals.Size = new Size(153, 22);
            Menu_Theme_Animals.Text = "Animals";
            Menu_Theme_Animals.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Music
            // 
            Menu_Theme_Music.Name = "Menu_Theme_Music";
            Menu_Theme_Music.Size = new Size(153, 22);
            Menu_Theme_Music.Text = "Music";
            Menu_Theme_Music.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Houses
            // 
            Menu_Theme_Houses.Name = "Menu_Theme_Houses";
            Menu_Theme_Houses.Size = new Size(153, 22);
            Menu_Theme_Houses.Text = "Houses";
            Menu_Theme_Houses.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Nature
            // 
            Menu_Theme_Nature.BackColor = Color.ForestGreen;
            Menu_Theme_Nature.ForeColor = Color.LightCoral;
            Menu_Theme_Nature.Name = "Menu_Theme_Nature";
            Menu_Theme_Nature.Size = new Size(153, 22);
            Menu_Theme_Nature.Text = "Nature";
            Menu_Theme_Nature.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Dark
            // 
            Menu_Theme_Dark.BackColor = Color.FromArgb(25, 25, 25);
            Menu_Theme_Dark.ForeColor = Color.DarkGray;
            Menu_Theme_Dark.Name = "Menu_Theme_Dark";
            Menu_Theme_Dark.Size = new Size(153, 22);
            Menu_Theme_Dark.Text = "Dark";
            Menu_Theme_Dark.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Discography
            // 
            Menu_Theme_Discography.BackColor = Color.IndianRed;
            Menu_Theme_Discography.Name = "Menu_Theme_Discography";
            Menu_Theme_Discography.Size = new Size(153, 22);
            Menu_Theme_Discography.Text = "Discography";
            Menu_Theme_Discography.Click += Menu_Tema_Click;
            // 
            // Menu_Theme_Optinova
            // 
            Menu_Theme_Optinova.Name = "Menu_Theme_Optinova";
            Menu_Theme_Optinova.Size = new Size(153, 22);
            Menu_Theme_Optinova.Text = "Optinova";
            Menu_Theme_Optinova.Click += Menu_Tema_Click;
            // 
            // Menu_Help
            // 
            Menu_Help.DropDownItems.AddRange(new ToolStripItem[] { Menu_Help_ChangeLog, Menu_Help_ReportBug, Menu_Help_InstructionVideos });
            Menu_Help.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Help.ForeColor = Color.DeepSkyBlue;
            Menu_Help.Name = "Menu_Help";
            Menu_Help.Size = new Size(53, 32);
            Menu_Help.Text = "Hjälp";
            Menu_Help.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Menu_Help_ChangeLog
            // 
            Menu_Help_ChangeLog.Name = "Menu_Help_ChangeLog";
            Menu_Help_ChangeLog.Size = new Size(201, 22);
            Menu_Help_ChangeLog.Text = "Versionshistorik";
            Menu_Help_ChangeLog.Click += Menu_Help_Versionshistorik_Click;
            // 
            // Menu_Help_ReportBug
            // 
            Menu_Help_ReportBug.Name = "Menu_Help_ReportBug";
            Menu_Help_ReportBug.Size = new Size(201, 22);
            Menu_Help_ReportBug.Text = "Rapportera in ett fel";
            Menu_Help_ReportBug.Click += Menu_Help_RapporteraFel_Click;
            // 
            // Menu_Help_InstructionVideos
            // 
            Menu_Help_InstructionVideos.DropDownItems.AddRange(new ToolStripItem[] { Menu_Help_InstructionVideos_SignIn, Menu_Help_InstructionVideos_AddUser, Menu_Help_InstructionVideos_RecentlyOpenedOrders, Menu_Help_InstructionVideos_ManageAuthorities, Menu_Help_InstructionVideos_SaveProcessCard });
            Menu_Help_InstructionVideos.Name = "Menu_Help_InstructionVideos";
            Menu_Help_InstructionVideos.Size = new Size(201, 22);
            Menu_Help_InstructionVideos.Text = "Instruktionsfilmer";
            // 
            // Menu_Help_InstructionVideos_SignIn
            // 
            Menu_Help_InstructionVideos_SignIn.Name = "Menu_Help_InstructionVideos_SignIn";
            Menu_Help_InstructionVideos_SignIn.Size = new Size(216, 22);
            Menu_Help_InstructionVideos_SignIn.Text = "Logga in";
            Menu_Help_InstructionVideos_SignIn.Click += Menu_Help_InstructionVideos_OpenVideo_Click;
            // 
            // Menu_Help_InstructionVideos_AddUser
            // 
            Menu_Help_InstructionVideos_AddUser.Name = "Menu_Help_InstructionVideos_AddUser";
            Menu_Help_InstructionVideos_AddUser.Size = new Size(216, 22);
            Menu_Help_InstructionVideos_AddUser.Text = "Lägg till Användare";
            Menu_Help_InstructionVideos_AddUser.Click += Menu_Help_InstructionVideos_OpenVideo_Click;
            // 
            // Menu_Help_InstructionVideos_RecentlyOpenedOrders
            // 
            Menu_Help_InstructionVideos_RecentlyOpenedOrders.Name = "Menu_Help_InstructionVideos_RecentlyOpenedOrders";
            Menu_Help_InstructionVideos_RecentlyOpenedOrders.Size = new Size(216, 22);
            Menu_Help_InstructionVideos_RecentlyOpenedOrders.Text = "Senast Öppnade Order";
            Menu_Help_InstructionVideos_RecentlyOpenedOrders.Click += Menu_Help_InstructionVideos_OpenVideo_Click;
            // 
            // Menu_Help_InstructionVideos_ManageAuthorities
            // 
            Menu_Help_InstructionVideos_ManageAuthorities.Name = "Menu_Help_InstructionVideos_ManageAuthorities";
            Menu_Help_InstructionVideos_ManageAuthorities.Size = new Size(216, 22);
            Menu_Help_InstructionVideos_ManageAuthorities.Text = "Hantera Rättigheter";
            Menu_Help_InstructionVideos_ManageAuthorities.Click += Menu_Help_InstructionVideos_OpenVideo_Click;
            // 
            // Menu_Help_InstructionVideos_SaveProcessCard
            // 
            Menu_Help_InstructionVideos_SaveProcessCard.Name = "Menu_Help_InstructionVideos_SaveProcessCard";
            Menu_Help_InstructionVideos_SaveProcessCard.Size = new Size(216, 22);
            Menu_Help_InstructionVideos_SaveProcessCard.Text = "Spara Nytt Processkort";
            Menu_Help_InstructionVideos_SaveProcessCard.Click += Menu_Help_InstructionVideos_OpenVideo_Click;
            // 
            // Menu_Developer
            // 
            Menu_Developer.DropDownItems.AddRange(new ToolStripItem[] { Menu_Developer_GetOrderInfo, Menu_Developer_SendMailToAllUsers, Menu_Developer_AddGallup, Menu_Developer_CheckGallup, Menu_Developer_OpenRandomOrder, Menu_Developer_InsertHalvfabrikat, Menu_Developer_NewProtocol_Extrudering_TEF, Menu_Developer_Test_RGB, Menu_Developer_NewMeasureProtocol, Menu_Developer_MoveDataKorprotokollValues, Menu_Utvecklare_MoveDataFEP, Menu_Developer_Timer_test, moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem, raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem, Menu_Developer_ExportHS_Data, kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem, Menu_Developer_GetDataForQuoting, Menu_Developer_INSERT_Rengjort, Menu_Developer_INSERT_Verktyg_Typ, testaNAntalKörningarPåArtikelNrToolStripMenuItem, Menu_Developer_AddThemePicture, Menu_Developer_TestNewProtocol, testCalendarToolStripMenuItem, Developer_AddLineClearance_Table, påskäggToolStripMenuItem, testarEnNyBranchToolStripMenuItem });
            Menu_Developer.ForeColor = Color.DeepSkyBlue;
            Menu_Developer.Name = "Menu_Developer";
            Menu_Developer.Size = new Size(81, 32);
            Menu_Developer.Text = "Utvecklare";
            Menu_Developer.TextAlign = ContentAlignment.MiddleLeft;
            Menu_Developer.Visible = false;
            // 
            // Menu_Developer_GetOrderInfo
            // 
            Menu_Developer_GetOrderInfo.Name = "Menu_Developer_GetOrderInfo";
            Menu_Developer_GetOrderInfo.Size = new Size(401, 22);
            Menu_Developer_GetOrderInfo.Text = "Get Order Info";
            Menu_Developer_GetOrderInfo.Click += Menu_Utvecklare_GetOrderInfo;
            // 
            // Menu_Developer_SendMailToAllUsers
            // 
            Menu_Developer_SendMailToAllUsers.Name = "Menu_Developer_SendMailToAllUsers";
            Menu_Developer_SendMailToAllUsers.Size = new Size(401, 22);
            Menu_Developer_SendMailToAllUsers.Text = "Skicka mail till alla användare";
            Menu_Developer_SendMailToAllUsers.Click += testaMailToolStripMenuItem_Click;
            // 
            // Menu_Developer_AddGallup
            // 
            Menu_Developer_AddGallup.Name = "Menu_Developer_AddGallup";
            Menu_Developer_AddGallup.Size = new Size(401, 22);
            Menu_Developer_AddGallup.Text = "Lägg till Gallup";
            Menu_Developer_AddGallup.Click += Menu_Utvecklare_Add_Gallup_Click;
            // 
            // Menu_Developer_CheckGallup
            // 
            Menu_Developer_CheckGallup.Name = "Menu_Developer_CheckGallup";
            Menu_Developer_CheckGallup.Size = new Size(401, 22);
            Menu_Developer_CheckGallup.Text = "Kolla Gallup";
            Menu_Developer_CheckGallup.Click += Menu_Utvecklare_Kolla_Gallup_Click;
            // 
            // Menu_Developer_OpenRandomOrder
            // 
            Menu_Developer_OpenRandomOrder.DropDownItems.AddRange(new ToolStripItem[] { Menu_Developer_OpenRandomOrder_1, Menu_Developer_OpenRandomOrder_, Menu_Developer_OpenRandomOrder_3, Menu_Developer_OpenRandomOrder_4, Menu_Developer_OpenRandomOrder_5, Menu_Developer_OpenRandomOrder_6 });
            Menu_Developer_OpenRandomOrder.Name = "Menu_Developer_OpenRandomOrder";
            Menu_Developer_OpenRandomOrder.Size = new Size(401, 22);
            Menu_Developer_OpenRandomOrder.Text = "Öppna Random Order";
            // 
            // Menu_Developer_OpenRandomOrder_1
            // 
            Menu_Developer_OpenRandomOrder_1.Name = "Menu_Developer_OpenRandomOrder_1";
            Menu_Developer_OpenRandomOrder_1.Size = new Size(320, 22);
            Menu_Developer_OpenRandomOrder_1.Text = "1 Maskin - 1 Processkort";
            // 
            // Menu_Developer_OpenRandomOrder_
            // 
            Menu_Developer_OpenRandomOrder_.Name = "Menu_Developer_OpenRandomOrder_";
            Menu_Developer_OpenRandomOrder_.Size = new Size(320, 22);
            Menu_Developer_OpenRandomOrder_.Text = "2 Maskiner - 1 Processkort";
            // 
            // Menu_Developer_OpenRandomOrder_3
            // 
            Menu_Developer_OpenRandomOrder_3.Name = "Menu_Developer_OpenRandomOrder_3";
            Menu_Developer_OpenRandomOrder_3.Size = new Size(320, 22);
            Menu_Developer_OpenRandomOrder_3.Text = "1 Maskin - Multipla Linjer";
            // 
            // Menu_Developer_OpenRandomOrder_4
            // 
            Menu_Developer_OpenRandomOrder_4.Name = "Menu_Developer_OpenRandomOrder_4";
            Menu_Developer_OpenRandomOrder_4.Size = new Size(320, 22);
            Menu_Developer_OpenRandomOrder_4.Text = "1 Maskin - Multipla Linjer + Multipla ProdTyp";
            // 
            // Menu_Developer_OpenRandomOrder_5
            // 
            Menu_Developer_OpenRandomOrder_5.Name = "Menu_Developer_OpenRandomOrder_5";
            Menu_Developer_OpenRandomOrder_5.Size = new Size(320, 22);
            Menu_Developer_OpenRandomOrder_5.Text = "Utan Processkort";
            // 
            // Menu_Developer_OpenRandomOrder_6
            // 
            Menu_Developer_OpenRandomOrder_6.Name = "Menu_Developer_OpenRandomOrder_6";
            Menu_Developer_OpenRandomOrder_6.Size = new Size(320, 22);
            Menu_Developer_OpenRandomOrder_6.Text = "Aktiv Order";
            // 
            // Menu_Developer_InsertHalvfabrikat
            // 
            Menu_Developer_InsertHalvfabrikat.Name = "Menu_Developer_InsertHalvfabrikat";
            Menu_Developer_InsertHalvfabrikat.Size = new Size(401, 22);
            Menu_Developer_InsertHalvfabrikat.Text = "INSERT Halvfabrikat";
            // 
            // Menu_Developer_NewProtocol_Extrudering_TEF
            // 
            Menu_Developer_NewProtocol_Extrudering_TEF.Name = "Menu_Developer_NewProtocol_Extrudering_TEF";
            Menu_Developer_NewProtocol_Extrudering_TEF.Size = new Size(401, 22);
            Menu_Developer_NewProtocol_Extrudering_TEF.Text = "Nytt Körprotokoll Ext TEF";
            // 
            // Menu_Developer_Test_RGB
            // 
            Menu_Developer_Test_RGB.Name = "Menu_Developer_Test_RGB";
            Menu_Developer_Test_RGB.Size = new Size(401, 22);
            Menu_Developer_Test_RGB.Text = "Test RGB";
            // 
            // Menu_Developer_NewMeasureProtocol
            // 
            Menu_Developer_NewMeasureProtocol.Name = "Menu_Developer_NewMeasureProtocol";
            Menu_Developer_NewMeasureProtocol.Size = new Size(401, 22);
            Menu_Developer_NewMeasureProtocol.Text = "Nytt Mätprotokoll";
            Menu_Developer_NewMeasureProtocol.Click += Menu_Developer_New_MeasureProtocol_Click;
            // 
            // Menu_Developer_MoveDataKorprotokollValues
            // 
            Menu_Developer_MoveDataKorprotokollValues.Name = "Menu_Developer_MoveDataKorprotokollValues";
            Menu_Developer_MoveDataKorprotokollValues.Size = new Size(401, 22);
            Menu_Developer_MoveDataKorprotokollValues.Text = "INSERT Values To Empty Uppstart TorkModul";
            Menu_Developer_MoveDataKorprotokollValues.Click += Menu_Utvecklare_MoveDataFromKorprotokollToKorprotokoll_Values;
            // 
            // Menu_Utvecklare_MoveDataFEP
            // 
            Menu_Utvecklare_MoveDataFEP.Name = "Menu_Utvecklare_MoveDataFEP";
            Menu_Utvecklare_MoveDataFEP.Size = new Size(401, 22);
            Menu_Utvecklare_MoveDataFEP.Text = "MoveExtrudering_FEPToKorprotokollValues";
            // 
            // Menu_Developer_Timer_test
            // 
            Menu_Developer_Timer_test.Name = "Menu_Developer_Timer_test";
            Menu_Developer_Timer_test.Size = new Size(401, 22);
            Menu_Developer_Timer_test.Text = "Timer test";
            Menu_Developer_Timer_test.Click += Menu_Developer_Timer_test_Click;
            // 
            // moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem
            // 
            moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem.Name = "moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem";
            moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem.Size = new Size(401, 22);
            moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem.Text = "Move Korprotokoll.Skärmning_Parametrar till [Order].Data";
            // 
            // raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem
            // 
            raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem.Name = "raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem";
            raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem.Size = new Size(401, 22);
            raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem.Text = "Radera Extrudering TEF Från Processcard.Data";
            // 
            // Menu_Developer_ExportHS_Data
            // 
            Menu_Developer_ExportHS_Data.Name = "Menu_Developer_ExportHS_Data";
            Menu_Developer_ExportHS_Data.Size = new Size(401, 22);
            Menu_Developer_ExportHS_Data.Text = "Export HS-Data to Excel";
            Menu_Developer_ExportHS_Data.Click += Menu_Developer_ExportHS_Data_Click;
            // 
            // kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem
            // 
            kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem.Name = "kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem";
            kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem.Size = new Size(401, 22);
            kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem.Text = "Kontrollera FEP data som är fel på Extruder";
            // 
            // Menu_Developer_GetDataForQuoting
            // 
            Menu_Developer_GetDataForQuoting.Name = "Menu_Developer_GetDataForQuoting";
            Menu_Developer_GetDataForQuoting.Size = new Size(401, 22);
            Menu_Developer_GetDataForQuoting.Text = "Hämta ut data för Quoting";
            Menu_Developer_GetDataForQuoting.Click += Menu_Developer_GetDataForQuoting_Click;
            // 
            // Menu_Developer_INSERT_Rengjort
            // 
            Menu_Developer_INSERT_Rengjort.Name = "Menu_Developer_INSERT_Rengjort";
            Menu_Developer_INSERT_Rengjort.Size = new Size(401, 22);
            Menu_Developer_INSERT_Rengjort.Text = "INSERT Rengjort Extruder";
            Menu_Developer_INSERT_Rengjort.Click += Menu_Developer_INSERT_Rengjort_Click;
            // 
            // Menu_Developer_INSERT_Verktyg_Typ
            // 
            Menu_Developer_INSERT_Verktyg_Typ.Name = "Menu_Developer_INSERT_Verktyg_Typ";
            Menu_Developer_INSERT_Verktyg_Typ.Size = new Size(401, 22);
            Menu_Developer_INSERT_Verktyg_Typ.Text = "INSERT Verktyg Typ";
            Menu_Developer_INSERT_Verktyg_Typ.Click += Menu_Developer_INSERT_Verktyg_Typ_Click;
            // 
            // testaNAntalKörningarPåArtikelNrToolStripMenuItem
            // 
            testaNAntalKörningarPåArtikelNrToolStripMenuItem.Name = "testaNAntalKörningarPåArtikelNrToolStripMenuItem";
            testaNAntalKörningarPåArtikelNrToolStripMenuItem.Size = new Size(401, 22);
            testaNAntalKörningarPåArtikelNrToolStripMenuItem.Text = "Testa n antal körningar på ArtikelNr";
            testaNAntalKörningarPåArtikelNrToolStripMenuItem.Click += testaNAntalKörningarPåArtikelNrToolStripMenuItem_Click;
            // 
            // Menu_Developer_AddThemePicture
            // 
            Menu_Developer_AddThemePicture.Name = "Menu_Developer_AddThemePicture";
            Menu_Developer_AddThemePicture.Size = new Size(401, 22);
            Menu_Developer_AddThemePicture.Text = "Lägg till Temabild";
            Menu_Developer_AddThemePicture.Click += Menu_Developer_AddThemePicture_Click;
            // 
            // Menu_Developer_TestNewProtocol
            // 
            Menu_Developer_TestNewProtocol.Name = "Menu_Developer_TestNewProtocol";
            Menu_Developer_TestNewProtocol.Size = new Size(401, 22);
            Menu_Developer_TestNewProtocol.Text = "Testa OrderRäknare";
            Menu_Developer_TestNewProtocol.Click += Menu_Developer_TestNewProtocol_Click;
            // 
            // testCalendarToolStripMenuItem
            // 
            testCalendarToolStripMenuItem.Name = "testCalendarToolStripMenuItem";
            testCalendarToolStripMenuItem.Size = new Size(401, 22);
            testCalendarToolStripMenuItem.Text = "Test Calendar";
            testCalendarToolStripMenuItem.Click += Menu_Developer_WhosIsLoggedIn_Click;
            // 
            // Developer_AddLineClearance_Table
            // 
            Developer_AddLineClearance_Table.Name = "Developer_AddLineClearance_Table";
            Developer_AddLineClearance_Table.Size = new Size(401, 22);
            Developer_AddLineClearance_Table.Text = "Add LineClearance Table";
            // 
            // påskäggToolStripMenuItem
            // 
            påskäggToolStripMenuItem.Name = "påskäggToolStripMenuItem";
            påskäggToolStripMenuItem.Size = new Size(401, 22);
            påskäggToolStripMenuItem.Text = "Påskägg";
            påskäggToolStripMenuItem.Click += påskäggToolStripMenuItem_Click;
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.Transparent;
            menuStrip.Dock = DockStyle.Fill;
            menuStrip.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            menuStrip.ImageScalingSize = new Size(28, 28);
            menuStrip.Items.AddRange(new ToolStripItem[] { Menu_Arkiv, Menu_Order, Menu_Protocol, Menu_Equipment, Menu_User, Menu_Help, Menu_Themes, Menu_Settings, Menu_Developer });
            menuStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new Padding(6, 0, 0, 12);
            menuStrip.RightToLeft = RightToLeft.No;
            menuStrip.Size = new Size(1211, 44);
            menuStrip.TabIndex = 894;
            menuStrip.Text = "menuStrip";
            // 
            // Menu_Equipment
            // 
            Menu_Equipment.Checked = true;
            Menu_Equipment.CheckState = CheckState.Checked;
            Menu_Equipment.DropDownItems.AddRange(new ToolStripItem[] { Menu_Equipment_UseFilter, Menu_Equipment_UseSilpaket });
            Menu_Equipment.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            Menu_Equipment.ForeColor = Color.DeepSkyBlue;
            Menu_Equipment.Name = "Menu_Equipment";
            Menu_Equipment.Size = new Size(86, 32);
            Menu_Equipment.Text = "Utrustning";
            Menu_Equipment.Visible = false;
            // 
            // Menu_Equipment_UseFilter
            // 
            Menu_Equipment_UseFilter.CheckOnClick = true;
            Menu_Equipment_UseFilter.Enabled = false;
            Menu_Equipment_UseFilter.ImageScaling = ToolStripItemImageScaling.None;
            Menu_Equipment_UseFilter.Name = "Menu_Equipment_UseFilter";
            Menu_Equipment_UseFilter.Size = new Size(181, 22);
            Menu_Equipment_UseFilter.Text = "Använd Filterhus";
            Menu_Equipment_UseFilter.Click += Menu_Protocol_UseFilter_Click;
            // 
            // Menu_Equipment_UseSilpaket
            // 
            Menu_Equipment_UseSilpaket.Checked = true;
            Menu_Equipment_UseSilpaket.CheckOnClick = true;
            Menu_Equipment_UseSilpaket.CheckState = CheckState.Checked;
            Menu_Equipment_UseSilpaket.Enabled = false;
            Menu_Equipment_UseSilpaket.ImageScaling = ToolStripItemImageScaling.None;
            Menu_Equipment_UseSilpaket.Name = "Menu_Equipment_UseSilpaket";
            Menu_Equipment_UseSilpaket.Size = new Size(181, 22);
            Menu_Equipment_UseSilpaket.Text = "Använd Silpaket";
            Menu_Equipment_UseSilpaket.Click += Menu_Protocol_UseSilpaket_Click;
            // 
            // testarEnNyBranchToolStripMenuItem
            // 
            testarEnNyBranchToolStripMenuItem.Name = "testarEnNyBranchToolStripMenuItem";
            testarEnNyBranchToolStripMenuItem.Size = new Size(401, 22);
            testarEnNyBranchToolStripMenuItem.Text = "Testar en ny Branch";
            // 
            // Main_Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(menuStrip);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main_Menu";
            Size = new Size(1211, 44);
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        public ToolStripMenuItem Menu_Arkiv;
        public ToolStripMenuItem Menu_Arkiv_NewOrder;
        public ToolStripMenuItem Menu_Arkiv_Open;
        public ToolStripMenuItem Menu_Arkiv_Preview;
        public ToolStripMenuItem Menu_Arkiv_Print;
        public ToolStripMenuItem Menu_Arkiv_Exit;
        public ToolStripMenuItem Menu_Order;
        public ToolStripMenuItem Menu_Order_OrderDone;
        public ToolStripMenuItem Menu_Order_EditOrder;
        public ToolStripMenuItem Menu_Order_DeleteOrder;
        public ToolStripMenuItem Menu_Order_ReportProblemProductionSupport;
        public ToolStripMenuItem Menu_Order_CreateTestOrder;
        public ToolStripMenuItem Menu_Protocol;
        public ToolStripMenuItem Menu_Protocol_ManageProcesscards;
        public ToolStripMenuItem Menu_Protocol_Unlock_ValidatedProcesscard;
        public ToolStripMenuItem Menu_User;
        public ToolStripMenuItem Menu_User_LogIn;
        public ToolStripMenuItem Menu_User_LogOut;
        public ToolStripMenuItem Menu_User_WhoIsLoggedIn;
        public ToolStripMenuItem Menu_User_LogOutUser;
        public ToolStripMenuItem Menu_User_CheckMyAnalysis;
        private ToolStripMenuItem Menu_User_Authorities;
        public ToolStripMenuItem Menu_Settings;
        public ToolStripMenuItem Menu_Settings_Settings;
        private ToolStripMenuItem Menu_Settings_CalculateMaterial;
        public ToolStripMenuItem Menu_Themes;
        private ToolStripMenuItem Menu_Theme_Beach;
        private ToolStripMenuItem Menu_Theme_Forest;
        private ToolStripMenuItem Menu_Theme_Sky;
        private ToolStripMenuItem Menu_Theme_Sun;
        private ToolStripMenuItem Menu_Theme_Water;
        private ToolStripMenuItem Menu_Theme_Winter;
        private ToolStripMenuItem Menu_Theme_Black;
        private ToolStripMenuItem Menu_Theme_Light;
        private ToolStripMenuItem Menu_Theme_Pink;
        private ToolStripMenuItem Menu_Theme_Cars;
        private ToolStripMenuItem Menu_Theme_Animals;
        private ToolStripMenuItem Menu_Theme_Music;
        private ToolStripMenuItem Menu_Theme_Houses;
        private ToolStripMenuItem Menu_Theme_Nature;
        private ToolStripMenuItem Menu_Theme_Dark;
        public ToolStripMenuItem Menu_Help;
        public ToolStripMenuItem Menu_Help_ChangeLog;
        public ToolStripMenuItem Menu_Developer;
        private ToolStripMenuItem Menu_Developer_GetOrderInfo;
        private ToolStripMenuItem Menu_Developer_AddGallup;
        private ToolStripMenuItem Menu_Developer_CheckGallup;
        private ToolStripMenuItem Menu_Developer_OpenRandomOrder;
        public ToolStripMenuItem Menu_Developer_OpenRandomOrder_1;
        private ToolStripMenuItem Menu_Developer_OpenRandomOrder_;
        private ToolStripMenuItem Menu_Developer_OpenRandomOrder_3;
        private ToolStripMenuItem Menu_Developer_OpenRandomOrder_4;
        private ToolStripMenuItem Menu_Developer_OpenRandomOrder_5;
        public ToolStripMenuItem Menu_Developer_OpenRandomOrder_6;
        private ToolStripMenuItem Menu_Developer_InsertHalvfabrikat;
        private ToolStripMenuItem Menu_Developer_NewProtocol_Extrudering_TEF;
        private ToolStripMenuItem Menu_Developer_Test_RGB;
        private ToolStripMenuItem Menu_Developer_NewMeasureProtocol;
        public MenuStrip menuStrip;
        private ToolStripMenuItem Menu_Developer_MoveDataKorprotokollValues;
        private ToolStripMenuItem Menu_Utvecklare_MoveDataFEP;
        private ToolStripMenuItem Menu_Equipment;
        private ToolStripMenuItem Menu_Equipment_UseFilter;
        private ToolStripMenuItem Menu_Equipment_UseSilpaket;
        private ToolStripMenuItem Menu_Developer_ChangeLog;
        private ToolStripMenuItem Menu_Help_ReportBug;
        private ToolStripMenuItem Menu_Order_OpenRandomOrder;
        private ToolStripMenuItem Menu_Developer_Timer_test;
        private ToolStripMenuItem Menu_Theme_Discography;
        private ToolStripMenuItem moveProcesskortExtruderingTEFTillProcesscardDataToolStripMenuItem;
        private ToolStripMenuItem raderaExtruderingTEFFrånProcesscardDataToolStripMenuItem;
        private ToolStripMenuItem Menu_Developer_ExportHS_Data;
        private ToolStripMenuItem kontrolleraFEPDataSomÄrFelPåExtruderToolStripMenuItem;
        private ToolStripMenuItem Menu_Developer_GetDataForQuoting;
        private ToolStripMenuItem Menu_Developer_INSERT_Rengjort;
        private ToolStripMenuItem Menu_Developer_INSERT_Verktyg_Typ;
        private ToolStripMenuItem testaNAntalKörningarPåArtikelNrToolStripMenuItem;
        private ToolStripMenuItem Menu_User_EditUser;
        private ToolStripMenuItem Menu_Developer_AddThemePicture;
        private ToolStripMenuItem Menu_Help_InstructionVideos;
        private ToolStripMenuItem Menu_Help_InstructionVideos_AddUser;
        private ToolStripMenuItem Menu_Help_InstructionVideos_SignIn;
        private ToolStripMenuItem Menu_Help_InstructionVideos_RecentlyOpenedOrders;
        private ToolStripMenuItem Menu_Developer_SendMailToAllUsers;
        private ToolStripMenuItem Menu_Help_InstructionVideos_ManageAuthorities;
        private ToolStripMenuItem Menu_Help_InstructionVideos_SaveProcessCard;
        private ToolStripMenuItem Menu_Settings_ChangeColorHS_Machine;
        private ToolStripMenuItem Menu_Theme_Optinova;
        private ToolStripMenuItem Menu_Order_QC_Feedback;
        private ToolStripMenuItem Menu_Arkiv_ManageDatabase;
        private ToolStripMenuItem Menu_User_Authorities_Roles;
        private ToolStripMenuItem Menu_User_Authorities_CustomMailAddresses;
        private ToolStripMenuItem Menu_User_Authorities_CustomWorkoperations;
        private ToolStripMenuItem Menu_User_Authorities_CustomFactories;
        private ToolStripMenuItem Menu_Protocol_ManageTemplates;
        private ToolStripMenuItem Menu_Developer_TestNewProtocol;
        private ToolStripMenuItem testCalendarToolStripMenuItem;
        private ToolStripMenuItem Developer_AddLineClearance_Table;
        private ToolStripMenuItem musTestToolStripMenuItem;
        private ToolStripMenuItem Menu_Order_LinkOrder;
        private ToolStripMenuItem Menu_Order_ReLink_Processcard;
        private ToolStripMenuItem Menu_Order_ReLink_Protocol;
        private ToolStripMenuItem Menu_Order_ReLink_MeasureProtocol;
        private ToolStripMenuItem Menu_Protocol_ManageTemplates_Protocols;
        private ToolStripMenuItem Menu_Protocol_ManageTemplates_LineClearance;
        private ToolStripMenuItem Menu_Protocol_ManageTemplates_MeasureProtocol;
        private ToolStripMenuItem Menu_Settings_ToolsCalculator;
        private ToolStripMenuItem påskäggToolStripMenuItem;
        private ToolStripMenuItem testarEnNyBranchToolStripMenuItem;
    }
}
