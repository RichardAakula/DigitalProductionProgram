//Created by: Richard Aakula
//Date      : 14-02-2013
//Projekt   : Digitala mät&kör Protokoll

using System;
using Microsoft.Data.SqlClient;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.EasterEggs;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.Measure;
using DigitalProductionProgram.Monitor;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.PrintingServices.Workoperation_Printouts;
using DigitalProductionProgram.Protocols;
using DigitalProductionProgram.QC;
using DigitalProductionProgram.User;
using Pictures = DigitalProductionProgram.OrderHantering.Pictures;
using ProgressBar = DigitalProductionProgram.ControlsManagement.ProgressBar;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.MainWindow
{

    public partial class Main_Form : Form
    {
       // public static Timer Timer_UpdateChart = new Timer();
       // public static Timer Timer_ChangeGrade = new Timer();
       // public static Timer Timer_ReloginMonitor = new Timer();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control ctrl;

            switch (keyData)
            {
                case Keys.F1:
                    Activity.Start();
                    ctrl = Buttons.Measureprotocol;
                    Buttons.F1_MeasureProtocol_Click(ctrl, null);
                    return true; // indicate that you handled this keystroke
                case Keys.F2:
                    Log.Activity.Start();
                    ctrl = Buttons.Protocol;
                    Buttons.F2_Protocol_Click(ctrl, null);
                    return true;
                case Keys.F3:
                    Activity.Start();
                    ctrl = Buttons.BrowseOldMeasureprotocol;
                    Buttons.F3_SearchOldMeasureProtocols_Click(ctrl, null);
                    return true;
                case Keys.F4:
                    Activity.Start();
                    ctrl = Buttons.BrowseOldOrders;
                    Buttons.F4_SearchOldProtocols(ctrl, null);
                    return true;
                case Keys.F5:
                    Activity.Start();
                    ctrl = Buttons.Compound;
                    Buttons.F5_Compund_Click(ctrl, null);
                    return true;
                case Keys.F6:
                    Activity.Start();
                    ctrl = Buttons.Zumbach;
                    Buttons.F6_Zumbach_Click(ctrl, null);
                    break;
                case Keys.F7:
                    Activity.Start();
                    ctrl = Buttons.OverviewProdlines;
                    Buttons.F7_OverviewProdLines_Click(ctrl, null);
                    return true;
                case Keys.F8:
                    Activity.Start();
                    ctrl = Buttons.Statistics;
                    Buttons.F8_Statistics_Click(ctrl, null);
                    return true;
                case Keys.F9:
                    Activity.Start();
                    ctrl = Buttons.Frequency_Marking;
                    Buttons.F9_FrequencyMarking_Click(ctrl, null);
                    return true;
            }
            // Call the base class
            return base.ProcessCmdKey(ref msg, keyData);
        }
        protected override CreateParams CreateParams //Tar bort en massa flickering
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public static bool IsZumbachÖppet = false;
        public static bool IsBetaMode;

        //UPPSNABBNING AV PROGRAMMET VID UTVECKLING
        public static bool IsLoadingPriorityPlan;
        public static bool IsLoadingMeasurePoints = true;
        public static bool IsOpenRandomOrder = false;
        public static bool IsAutoOpenOrder = false;
        public static bool IsAutoLoginSuperAdmin = true;

        private const string? develop_OrderNr = "C1335";
        private const string? develop_Operation = "10";
        public static Timer? timer_StatsDPP;



        private int ctr_Info_Planerat_Stopp;
        // Denna rad måste finnas för utskrifterna
        private readonly Manage_PrintOuts print = new Manage_PrintOuts();
        private readonly BlackBackground black;
        private FlyingEasterEgg? flyingEgg;
        public static ProgressBar pBar;
        private Timer? eggTimer;
        private Bitmap? easterEggImage;
        private Point eggPosition;
        private Random rand = new Random();




        //----------- UPPSTART --------------------------------------------------
        public Main_Form(BlackBackground back)
        {
            this.Visible = false;
            black = back;
            Settings.Settings.LoadData.Load_Settings();
            Activity.Start();
            InitializeComponent();

            Translate_MainForm();

            MainMenu.mainForm = this;
            OrderInformation.mainForm = this;

            Initialize_Timers();
            Monitor.Monitor.lbl_Monitorstatus = Serverstatus.lbl_MonitorStatus;
            Monitor.Monitor.panel_Monitorstatus = Serverstatus.panel_MonitorStatus;
            Login_Monitor.Login_API();

            if ((Environment.MachineName == "THAI-DPP-TEST01" || Environment.MachineName == "OH-ID61") && IsAutoLoginSuperAdmin)
                AUTOLOGIN_SUPERADMIN();
            else
            {
                IsLoadingPriorityPlan = true;
                IsLoadingMeasurePoints = true;
            }

            Login_Monitor.GiveUserWarningMonitorOnStageServer();
            Serverstatus.SetMainForm(this);



            //Login_Monitor.Login_API();
            PriorityPlanning.dgv_PriorityPlanning.CellClick += PriorityPlanning_OrderNr_CellClick;
            OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;

            lbl_Company.Text = Monitor.Monitor.factory.ToString();
            if (IsAutoOpenOrder == false)
            {
                Enum.TryParse(Settings.Settings.Tema, out Teman.Theme);

                Teman.Choose_Theme();
                Change_Theme();

                if (!Program.IsComputerOnlyForMeasurements && IsAutoOpenOrder == false)
                    OrderInformation.tb_OrderNr.AutoCompleteCustomSource = Monitor.Monitor.AutoFillOrdernr;

                _ = Main_FilterQuickOpen.Load_ListAsync(dgv_QuickOpen);
                // WindowState = FormWindowState.Normal;
            }
            OrderInformation.tb_OrderNr.Focus();
            dgv_QuickOpen.ClearSelection();

            if (Database.cs_Protocol.Contains("GOD_DPP_DEV"))
                IsBetaMode = true;

            Text = "Digital Production Program - " + ChangeLog.CurrentVersion;
            Refresh();
            if (IsBetaMode)
            {
                Text = "DPP in BETA MODE";
                if (Environment.MachineName != "OH-ID61")
                    InfoText.Show(LanguageManager.GetString("warning_Testdatabase"), CustomColors.InfoText_Color.Bad, "Warning");
                Change_GUI_BetaMode();
            }

            Mail.AutoTestJira();
            CheckForMaintenanceWork();
           
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            if (IsAutoOpenOrder == false)
            {
                Monitor.Monitor.Load_WorkCenters();
                PriorityPlanning.Load_ProdGrupp();

                if (Settings.Settings.MeasuringComputerOnly)
                    Change_GUI_Mätdator();

                await Main_FilterQuickOpen.Load_ListAsync(dgv_QuickOpen);
                await Task.Run(() => RollingInformation.Change_Tips());
            }

            if (black != null)
            {
                if (black.InvokeRequired)
                    black.Invoke(new Action(() => black.Close()));
                else
                    black.Close();
            }
            await Activity.Stop("Uppstart av program");
        }
        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                // Create the handle (window) for the form
                this.CreateHandle();
                value = false; // Set visibility to false
            }
            base.SetVisibleCore(value);
        }



        private void AUTOLOGIN_SUPERADMIN()
        {
            IsLoadingPriorityPlan = true;
            
            
            //if (Database.IsGodby____ + Database.IsGodbyBeta + Database.IsGodbyThai + Database.IsThai_____ > 1)

            Person.Name = "Richard Aakula";
            Person.Sign = "RA";
            Person.UserID = 24;
            Person.EmployeeNr = "347";
            Person.Role = "SuperAdmin";
            pbOperatör.Image = Person.ProfilePicture(Person.Name);
            Person.Mail = "richard.aakula@optinova.com";
            ActiveOrdersUser.Visible = true;
            Statistics_DPP.Visible = true;

            lbl_EmpNr.Text = Person.EmployeeNr;
            lbl_Sign.Text = Person.Sign;
            lbl_Namn.Text = Person.Name;
            lbl_Role.Text = "SuperAdmin";
            panel_Profile.Visible = true;
            Change_GUI_Grade();
            MainMenu.Menu_Developer.Visible = true;
            MainMenu.Menu_Order_DeleteOrder.Enabled = true;
            MainMenu.Unlock_Menu();
            SaveData.UPDATE_User_Online(true, lbl_EmpNr.Text);
            if (IsOpenRandomOrder && Person.Role == "SuperAdmin")
            {
                OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
                Order.Start.OpenRandomOrder((OrderInformation));
                Order.Set_NumberOfLayers();
            }
            if (IsAutoOpenOrder && Person.Role == "SuperAdmin")
            {
                var ordernr = develop_OrderNr;
                var operation = develop_Operation;
                Order.CheckIfOldOrderNotDoneExists(ref ordernr, ref operation);
                if (!string.IsNullOrEmpty(ordernr))
                {
                    Order.OrderNumber = OrderInformation.tb_OrderNr.Text = ordernr;
                    Order.Operation = operation;
                    Order.Load_OrderID(Order.OrderNumber, Order.Operation);
                    Order.Load_ProdLine();
                    Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation();
                    StartOrLoadOrder(true);
                    //Open();
                    Order.Set_NumberOfLayers();
                    //Task.Factory.StartNew(() => measureStats.Add_MeasureInformation_MainForm(panelChart, tlp_MainWindow));
                    Task.Run(Buttons.Change_GUI_Buttons);

                }
            }

            WindowState = FormWindowState.Normal;
            Size = new Size(1920, 1080);
            Statistics_DPP.Visible = true;
            //Calender.Fill_OnlineMonitorUsers();

            Task.Run(() => { ActiveOrdersUser.Load_OrderNr(OrderInformation); });
            _ = EasterEgg_Code.IsGameStarted;


            MainMenu.Visible = true;
            MainMenu.menuStrip.Visible = true;
        }

        private void Initialize_Timers()
        {
           // Timer_UpdateChart.Tick += UpdateChart_Tick;
            //Timer_ChangeGrade.Tick += Change_Grade_Tick;
            //Timer_ReloginMonitor.Tick += ReLogin_Monitor_Tick;

           // Timer_UpdateChart.Interval = 300000;
           // Timer_ChangeGrade.Interval = 600000;
           // Timer_ReloginMonitor.Interval = 60000;

          //  timer_CheckForUpdate.Start();

           // Timer_Update_Körplanering_Start();

           // timer_Planerat_Stopp.Start();


            timer_Master = new Timer();
            timer_Master.Interval = 1000; // 1 sekund
            timer_Master.Tick += MasterTimer_Tick;
            timer_Master.Start();
        }


        //----------- CHANGE GUI-----------------------
        public void Change_GUI_MainForm()
        {
            if (InvokeRequired)
                Invoke(new Action(Change_GUI_MainForm));
            else
            {
                MainMenu.Menu_Order_OrderDone.Enabled = true;
                Task.Run(Buttons.Change_GUI_Buttons);
                Task.Run(Change_GUI_Form);
                OrderInformation.cb_Operation.Enabled = false;
                AQL.Visible = CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.IsUsingAQL_Module);
                TipsAndTrix.Visible = CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.TipsAndTrix);
                Task.Factory.StartNew(RollingInformation.Load_list_Tips);
            }
        }
        public void Change_GUI_Form()
        {
            if (InvokeRequired)
                Invoke(new Action(Change_GUI_Form));
            else
            {
                Control[] controls = { panelChart, measurePoints, measureStats };
                foreach (var ctrl in controls)
                    ctrl.Visible = false;

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT Name
                    FROM Workoperation.ControlVisibiltySettings  as visibility
	                    JOIN Workoperation.ApplicationControls as controls
		                    ON visibility.ControlID = controls.ID
                    WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) 
	                    AND ColumnIndex IS NULL
                    ORDER BY ColumnIndex";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@workoperation", Order.WorkOperation.ToString());
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var name = reader[0].ToString();
                        foreach (var control in controls)
                        {
                            if (control.Name == name)
                                control.Visible = true;
                        }
                    }
                }
            }
        }
        private void Set_GUI_Theme_Krympslang()
        {
            Control[] textLabels = { lbl_Company, label_EmpNr, lbl_EmpNr, label_Sign, lbl_Sign, label_Role, lbl_Role, lbl_Percent, ActiveOrdersUser.label_Header_ActiveOrders };//Weather.lbl_Location, Weather.lbl_Temp, Weather.lbl_Wind,
            if (string.IsNullOrEmpty(Equipment.Equipment.HS_Machine) == false)
            {
                MachineColor.Set_HeatShrink_Color();
                Invoke((MethodInvoker)delegate
                {
                    tlp_Left.BackColor = Buttons.BackColor = MachineColor.Theme_BackColor;
                });
                foreach (var control in textLabels)
                    control.ForeColor = MachineColor.Theme_ForeColor;
            }

        }


        public void Translate_MainForm()
        {
            var controls = new Control[] { TipsAndTrix.label_Tips_Trix, label_EmpNr, label_Sign, label_Role, label_Filter, label_QuickOpenOrder };
            LanguageManager.TranslationHelper.TranslateControls(controls);
            LanguageManager.TranslationHelper.TranslateMainMenu(MainMenu.menuStrip);
            Buttons.Translate_Form();
            OrderInformation.Translate_Form();
            ActiveOrdersUser.Translate_Form();
            PriorityPlanning.Translate_Form();
            measurePoints.Translate_Form();
            measureStats.Translate_Form();

        }
        public void Change_GUI_OrderKlar()
        {
            AQL.Visible = false;
            TipsAndTrix.Visible = false;
            tlp_MainWindow.BackgroundImage = null;

            measurePoints.tlp_Main.BackColor = measureStats.BackColor = panelChart.BackColor = tlp_ExtraInfo.BackColor = panelChart.BackColor = Color.Transparent;

            tlp_Left.BackColor = Color.FromArgb(100, 20, 44, 20);
            BackColor = Color.FromArgb(20, 44, 20);

            tlp_ExtraInfo.Visible = true;
            Change_GUI_ExtraInfo();
            MainMenu.Change_GUI_OrderFinished();
            PriorityPlanning.Visible = false;
            Buttons.Change_GUI_OrderFinished();

            if (!string.IsNullOrEmpty(Order.Rating))
            {
                lbl_Rating.Visible = true;
                lbl_Rating.Text = Order.Rating;
                pb_Info_UserPoints.Visible = true;
            }
            else
            {
                lbl_Rating.Visible = false;
                pb_Info_UserPoints.Visible = true;
            }
        }
        public void Change_GUI_OrderEjKlar()
        {
            BackColor = Color.Black;
            PriorityPlanning.Change_GUI_OrderNotFinished();
            MainMenu.Change_GUI_OrderNotFinished();
            Buttons.Change_GUI_OrderNotFinished();

            label_ExtraInfo.Visible = true;

            Change_GUI_ExtraInfo();
            lbl_Rating.Visible = false;
        }
        private void Change_GUI_Mätdator()
        {
            Buttons.Change_GUI_Mätdator();
            MainMenu.Change_GUI_Mätdator();
            PriorityPlanning.Visible = false;

            Size = new Size(1250, 600);
        }

        private void Change_GUI_ExtraInfo()
        {
            if (!string.IsNullOrEmpty(lbl_ExtraInfo.Text))
            {
                label_ExtraInfo.Visible = true;
                tlp_ExtraInfo.Visible = true;
            }
            else
            {
                label_ExtraInfo.Visible = false;
                tlp_ExtraInfo.Visible = false;
            }
        }
        private void Change_GUI_Grade()
        {
            if (string.IsNullOrEmpty(Person.EmployeeNr))
            {
                panel_Grade_Percent.Visible = false;
                pb_GradBeteckning.Visible = false;
                lbl_Percent.Visible = false;
                return;
            }

            Points.TotalPoints = Person.User_Points;
            if (Points.TotalPoints < 0)
                return;
            pb_GradBeteckning.BackgroundImage = Image.FromStream(Grade.Img_Grade);
            pb_GradBeteckning.Visible = true;
            panel_Grade_Percent.BackColor = Color.FromArgb(60, Color.LightGreen);
            panel_Grade_Percent.Visible = true;
            lbl_Percent.Visible = true;

            panel_Grade_Percent.Height = (int)(pb_GradBeteckning.Height * Grade.percent_Grade(Grade.grade));
            panel_Grade_Percent.Top = pb_GradBeteckning.Bottom - panel_Grade_Percent.Height;

            lbl_Percent.Text = $"{Convert.ToInt32(Grade.percent_Grade(Grade.grade) * 100)} %";
        }

        private void Change_GUI_BetaMode()
        {
            tlp_Left.BackColor = OrderInformation.BackColor = panel_Right.BackColor = Color.Pink;

            var lbl_Beta = new Label
            {
                Text = "BETA Mode",
                BackColor = Color.Pink,
                ForeColor = Color.Brown,
                Dock = DockStyle.Fill,
                Font = new Font("Palatino LinoType", 50),
                TextAlign = ContentAlignment.MiddleCenter
            };
            tlp_MainWindow.Controls.Add(lbl_Beta, 3, 3);
        }

        public void Change_Theme()
        {
            if (Order.IsOrderDone)
                return;

            tlp_MainWindow.BackgroundImage = Teman.rndBackPic;

            tlp_MainWindow.BackColor = Teman.backColor_Main;
            tlp_Top.BackColor = Teman.backColor_Menu;
            tlp_QuickOpen.BackColor = Teman.backColor_Panels;

            if (IsBetaMode == false)
            {
                panel_Right.BackColor = Teman.backColor_RightPanel;
                tlp_Left.BackColor = Teman.backColor_LeftPanel;
                BeginInvoke(new Action(() => OrderInformation.Change_Theme()));
            }

            panelChart.BackColor = Teman.backColor_Chart;
            tlp_ExtraInfo.BackColor = TipsAndTrix.label_Tips_Trix.BackColor = TipsAndTrix.pb_Info_Tips_Trix.BackColor = Teman.backColor_ExtraInfo;
            lbl_ExtraInfo.ForeColor = Teman.foreColor_ExtraInfo;

            BeginInvoke(new Action(() => panel_Bottom.BackColor = Teman.backColor_Panels));

            BeginInvoke(new Action(() => MainMenu.Change_Theme()));
            BeginInvoke(new Action(() => Buttons.Change_Theme()));
            BeginInvoke(new Action(() => measureStats.Change_Theme()));
            BeginInvoke(new Action(() => measurePoints.Change_Theme()));
            BeginInvoke(new Action(() => RollingInformation.Change_Theme()));
            BeginInvoke(new Action(() => PriorityPlanning.Change_Theme()));
            BeginInvoke(new Action(() => AQL.Change_Theme()));
            BeginInvoke(new Action(() => ActiveOrdersUser.Change_Theme()));


            Set_GUI_Theme_Krympslang();
            _ = Activity.Stop(Teman.Theme.ToString());
        }


        //---------------------------------------------STARTA ORDER---------------------------------------------
        public void StartOrLoadOrder(bool IsOperationOk)
        {
            MainMeasureStatistics.ChartCodeText = string.Empty;
            MainMeasureStatistics.ChartCodename = string.Empty;
            Order.Is_PrintOutCopy = true;

            // Stoppa MainTimer eventuellt om det blir problem
            if (IsOperationOk == false) //Om Ordern har blivit öppnad från Öppna-menyn så skippas detta steg
            {
                if (OrderInformation.cb_Operation.Text.Contains("-"))
                    Order.Operation = OrderInformation.cb_Operation.Text.Substring(0, OrderInformation.cb_Operation.Text.IndexOf('-') - 1);
                else
                    Order.Operation = OrderInformation.cb_Operation.Text;
                var start = OrderInformation.cb_Operation.Text.IndexOf('-') + 2;
                var length = OrderInformation.cb_Operation.Text.Length - start;
                Order.ProdLine = OrderInformation.cb_Operation.Text.Substring(start, length);

                Order.ProdGroup = Main_OrderInformation.List_ProdGroup[OrderInformation.cb_Operation.SelectedIndex];
            }

            Order.Load_OrderInformation();
            Monitor.Monitor.Load_OrderInformation();

            var IsOkStartOrder = true;

            if (Order.IsOrder_Exist(Order.OrderNumber, Order.Operation))
                Open();
            else
                Order.Start.New_Order(this, ref IsOkStartOrder); //Hämtar data från Monitor och sparar i Korprotokoll_Databas PartID laddas här
            if (IsOkStartOrder == false)
                return;

            Load_MainForm();
            PriorityPlanning.tb_ProdGrupp.Text = OrderInformation.lbl_ProdGroup.Text;

            if (QC_Feedback.IsOperationHaveQCFeedback)
            {
                FeedBackQC.Visible = true;
                FeedBackQC.LoadData();
            }
            else
                FeedBackQC.Visible = false;
            Close_Open_Forms();

            lbl_ExtraInfo.Text = Part.ExtraInfo_Part;

            if (IsAutoOpenOrder == false)
                Task.Run(Change_Theme);
            Task.Run(Change_GUI_MainForm);

            Change_GUI_ExtraInfo();
            // Stoppa MainTimer eventuellt om det blir problem
            Order.Set_NumberOfLayers();
            Load_MeasurePoints();

            Task.Factory.StartNew(() => measureStats.Add_MeasureInformation_MainForm(panelChart, tlp_MainWindow));

            Tools.Load_HSPipes();

            if (Order.IsOrderDone)
                Change_GUI_OrderKlar();
            else
                Change_GUI_OrderEjKlar();

            MainMenu.Unlock_Korprotokoll_Menu();
        }
        public void Operation_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (OrderInformation.cb_Operation.SelectedIndex > -1 & !string.IsNullOrEmpty(OrderInformation.cb_Operation.Text) & !string.IsNullOrEmpty(OrderInformation.tb_OrderNr.Text))
            {
                OrderInformation.cb_Operation.BackColor = Color.White;
                StartOrLoadOrder(false);
            }
        }


        //---------------------------------------------LADDA SPARA---------------------------------------------
        public void Open()
        {
            Activity.Start();
            Order.Set_IsOrderDone();
            if (Program.IsComputerOnlyForMeasurements)
                Change_GUI_Mätdator();

            Order.Is_PrintOutCopy = true;

            OrderInformation.tb_OrderNr.Enabled = false;
            //Stänger eventuella öppna Körprotokoll
            Close_Open_Forms();


            Buttons.panel_Pictures.Visible = true;

            ProgressBar.close();
            Activate();
            OrderInformation.tb_OrderNr.SelectionLength = 0;
            Cursor = Cursors.Arrow;

            _ = Activity.Stop("Öppnar Order:");
        }
        private void Load_MainForm()
        {
            OrderInformation.Load_Data();
            Equipment.Equipment.HS_Machine = Machines.Active_HS_Machine;

            Order.Load_ProdType();

            lbl_ExtraInfo.Text = Part.ExtraInfo_Part;

            AQL.Clear_ProvInfo();
            TipsAndTrix.LoadData();
            AQL.Initialize_QC_ProvuttagInfo();
        }
        public void Öppna_Gallup()
        {
            var gallup = new UserPoll();
            var bg = new BlackBackground("", 80);
            bg.Show();
            gallup.ShowDialog();
            bg.Close();
        }



        //---------------------------------------------MÄTPUNKTER--------------------------------------------------
        public void Load_MeasurePoints()
        {
            if (IsLoadingMeasurePoints == false)
                return;
            Monitor.Monitor.Load_DataTable_Measurpoints(Order.OrderNumber, Order.Operation, true);
            measurePoints.AddMeasurePointsMainForm();
        }




        //---------------------------------------------CLEAR--------------------------------------------------
        public void Clear_Mainform()
        {
            Cursor = Cursors.Arrow;
            measurePoints.Visible = false;
            measureStats.Visible = false;
            panelChart.Visible = false;
            tlp_ExtraInfo.Visible = false;
            Buttons.Change_GUI_Buttons();
            Order.Clear_Order();
            FeedBackQC.Visible = false;

            OrderInformation.cb_Operation.SelectedIndexChanged -= Operation_SelectedIndexChanged;
            OrderInformation.tb_OrderNr.TextChanged -= Operation_SelectedIndexChanged;
            OrderInformation.Clear();
            OrderInformation.tb_OrderNr.TextChanged += Operation_SelectedIndexChanged;
            OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
        }
        private static void Close_Open_Forms()
        {
            ControlManager.Close_All_Körprotokoll();
            MainMeasureStatistics.Close_All_MeasureProtocols();
        }



        //---------------------------------------------KÖRPLANERING-------------------------------------------
        //private void Timer_Update_Körplanering_Start()
        //{

        //   // timer_Update_Körplanering.Start();
        //}
        public void PriorityPlanning_OrderNr_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (PriorityPlanning.dgv_PriorityPlanning.Columns[0].Name != "OrderNr" || e.RowIndex < 0)
                return;
            if (IsZumbachÖppet)
            {
                InfoText.Show("Du har Zumbachfönstret fortfarande öppet, stäng det före du försöker öppna en ny order",
                    CustomColors.InfoText_Color.Warning, "Varning!");
                return;
            }

            OrderInformation.tb_OrderNr.Enabled = true;
            OrderInformation.tb_OrderNr.Text = PriorityPlanning.dgv_PriorityPlanning.Rows[e.RowIndex].Cells["OrderNr"].Value.ToString();

            OrderInformation.Fill_cb_Operation();

            Order.Operation = PriorityPlanning.dgv_PriorityPlanning.Rows[e.RowIndex].Cells["Operation"].Value.ToString();

            int.TryParse(Order.Operation, out int operation);
            OrderInformation.Set_Operation(operation);

            OrderInformation.tb_OrderNr.Enabled = true;
            OrderInformation.cb_Operation.Enabled = true;
            PriorityPlanning.dgv_PriorityPlanning.ClearSelection();
        }



        //---------------------------------------------SNABBÖPPNA---------------------------------------------
        private void QuickOpen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            Clear_Mainform();
            Order.WorkOperation = Manage_WorkOperation.WorkOperations.Nothing;
            var dgv = (DataGridView)sender;
            OrderInformation.cb_Operation.SelectedIndexChanged -= Operation_SelectedIndexChanged;
            OrderInformation.tb_OrderNr.Validated -= OrderInformation.OrderNr_Validated;

            if (IsZumbachÖppet)
            {
                InfoText.Show(LanguageManager.GetString("quickOpen_Info_2"), CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }

            Order.OrderID = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
            Order.OrderNumber = OrderInformation.tb_OrderNr.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            Order.Load_Operation(Order.OrderID);
            Order.PartNumber = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[2].Value.ToString();
            if (int.TryParse(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[3].Value.ToString(), out var artID))
                Order.PartID = artID;
            else
                Order.PartID = null;

            Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation(false, Order.OrderID, Order.PartID);
            if (string.IsNullOrEmpty(Order.WorkOperation.ToString()) || Order.WorkOperation == Manage_WorkOperation.WorkOperations.Nothing)
                InfoText.Show(LanguageManager.GetString("quickOpen_Info_3"), CustomColors.InfoText_Color.Bad, "Warning", this);
            Points.Add_Points(1, "Snabböppna Order");
            StartOrLoadOrder(true);
            dgv.ClearSelection();


            OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
            OrderInformation.tb_OrderNr.Validated += OrderInformation.OrderNr_Validated;
        }
        private void FilterWorkoperations_Click(object sender, EventArgs e)
        {
            var quickOpen = new Main_FilterQuickOpen(dgv_QuickOpen);
            var black = new BlackBackground(null, 80);

            quickOpen.AddWorkoperationCheckBoxes();

            quickOpen.Left = MousePosition.X - 100;
            quickOpen.Top = MousePosition.Y - quickOpen.Height;
            black.StartPosition = FormStartPosition.Manual;
            black.Location = this.Location;
            black.Show();
            quickOpen.ShowDialog();
            black.Close();
        }




        //---------------------------------------------INLOGGNING---------------------------------------------
        public void SignIn()
        {
            var screen = Screen.FromPoint(Cursor.Position);

            SignOut();

            var frmLogin = new Login();
            var backGround = new BlackBackground(string.Empty, 50)
            {
                Size = new Size(Program.ScreenWidth, Height),
                StartPosition = FormStartPosition.Manual
            };
            frmLogin.StartPosition = FormStartPosition.Manual;
            backGround.Location = screen.Bounds.Location;
            frmLogin.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - frmLogin.Width / 2;
            frmLogin.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - frmLogin.Height / 2;

            backGround.Show();
            frmLogin.ShowDialog();
            backGround.Close();


            lbl_EmpNr.Text = Person.EmployeeNr;
            lbl_Sign.Text = Person.Sign;
            lbl_Role.Text = Person.Role;
            lbl_Namn.Text = Person.Name;

            panel_Profile.Visible = true;
            ActiveOrdersUser.Visible = true;

            Change_GUI_Grade();

            pbOperatör.Image = Person.ProfilePicture(Person.Name);

            #region Om Datorn används som Mätdator

            if (frmLogin.SvarÖppnaOrder)
            {
                OrderInformation.tb_OrderNr.Text = Order.OrderNumber;
                StartOrLoadOrder(true);

                var mp = new Measurement_Protocol
                {
                    Location = new Point(100, 10)
                };
                mp.Show();
            }

            #endregion

            if (!string.IsNullOrEmpty(lbl_Namn.Text))
            {
                Points.Add_Points(1, "Loggar in.");
                SaveData.UPDATE_User_Online(true, lbl_EmpNr.Text);
            }

            if (!UserPoll.IsUserVotedPoll)
                Öppna_Gallup();

            if (CheckAuthority.IsOkReadMyAnalysis)
            {
                var my_Analysis = new My_Analysis();
                my_Analysis.ShowDialog();
            }

            #region Kontrollerar om Användaren har en gammal order öppen som ej blivit avslutad

            var ordernr = string.Empty;
            var operation = string.Empty;
            Order.CheckIfOldOrderNotDoneExists(ref ordernr, ref operation);
            if (!string.IsNullOrEmpty(ordernr))
            {
                Order.OrderNumber = OrderInformation.tb_OrderNr.Text = ordernr;
                Order.Operation = operation;
                Order.Load_OrderID(ordernr, operation);
                Order.Load_ProdLine();
                Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation();
                StartOrLoadOrder(true);
            }

            #endregion


            MainMenu.Unlock_Menu();
            RollingInformation.Load_list_Tips();

            Task.Run(() => { ActiveOrdersUser.Load_OrderNr(OrderInformation); });
            _ = EasterEgg_Code.IsGameStarted;
        }
        public void SignOut()
        {
            SaveData.UPDATE_User_Online(false, lbl_EmpNr.Text);

            lbl_Namn.Text = string.Empty;
            lbl_EmpNr.Text = string.Empty;
            lbl_Sign.Text = string.Empty;
            lbl_Role.Text = string.Empty;
            pbOperatör.Image = null;
            pbOperatör.BackgroundImage = null;
            pb_GradBeteckning.Image = null;
            lbl_Percent.Text = string.Empty;

            panel_Profile.Visible = false;
            ActiveOrdersUser.Visible = false;

            Person.Clear();
            ControlManager.Close_All_Körprotokoll();
            MainMenu.Lock_Menu();
        }
        private void SignIn_Click(object sender, EventArgs e)
        {
            SignIn();
        }


        //---------------------------------------------ORDER KLAR---------------------------------------------
        public static void Preview_PrintOut()
        {

            switch (Order.WorkOperation)
            {
                case Manage_WorkOperation.WorkOperations.Blandning_PTFE:
                    Blandning_PTFE.Print_Preview_Order(false);
                    break;
                case Manage_WorkOperation.WorkOperations.Kragning_TEF:
                    Kragning_TEF.Print_Preview_Order(false);
                    break;
                case Manage_WorkOperation.WorkOperations.Skärmning:
                    Skärmning.Print_Preview_Order(false);
                    break;
                case Manage_WorkOperation.WorkOperations.Slipning:
                    Slipning_TEF.Print_PreviewOrder(false);
                    break;
                case Manage_WorkOperation.WorkOperations.Spolning_PTFE:
                    Spolning_PTFE.PrintPreview_Order(false);
                    break;
                case Manage_WorkOperation.WorkOperations.Svetsning:
                    Svetsning.Print_Preview_Order(false);
                    break;

                case Manage_WorkOperation.WorkOperations.Nothing:
                    var pk = new VäljProcesskort();
                    var bg = new BlackBackground(string.Empty, 70);
                    bg.Show();
                    pk.ShowDialog();
                    bg.Close();
                    Order.WorkOperation = Manage_WorkOperation.WorkOperations.Nothing;
                    break;

                default:
                    _ = Print_Protocol.Print_Preview_Order(false);
                    break;
            }

        }
        public void PrintOut()
        {
            if (!string.IsNullOrEmpty(Order.OrderNumber))
            {
                Manage_PrintOuts.Choose_PrintOut();
                if (!string.IsNullOrEmpty(Order.OrderNumber) && Pictures.Total_Pictures > 0)
                    Manage_PrintOuts.Print_Pictures.Print();
            }
        }



        //---------------------------------------------KNAPPAR------------------------------------------------
        private void Info_Snabböppna_Click(object sender, EventArgs e)
        {
            Points.Add_Points(1, "Klickat på Infoknapp om Snabböppna");
            InfoText.Show(LanguageManager.GetString("quickOpen_Info"), CustomColors.InfoText_Color.Info, "Info", this);
        }
        private void EasterEgg_1_Click(object sender, EventArgs e)
        {
            if (EasterEgg_HighScore.IsOkStartGame("Easter Egg 1", this))
            {
                var game = new EasterEgg_1();
                game.ShowDialog();
            }

        }
        private void EasterEgg_2_Click(object sender, EventArgs e)
        {
            if (EasterEgg_HighScore.IsOkStartGame("Easter Egg 2", this))
            {
                var game = new EasterEgg_2();
                game.ShowDialog();

            }
        }
       
        private void Info_Poäng_Click(object sender, EventArgs e)
        {
            Points.Add_Points(1, "Klickat på Infoknapp om poäng.");
            InfoText.Show("Betygskala för körningen baserat på hur materialet har gått:\n\n" +
                          "0 - Materialet var oanvändbart.\n" +
                          "1 - Materialet var användbart men medförde mycket stora problem.\n" +
                          "2 - Materialet var användbart men medförde mer problem än vanligt.\n" +
                          "3 - Material uppförde sig som vanligt med normala hanterbara variationer från materialet.\n" +
                          "4 - Körningen gick bra med färre än vanligt problem med materialet.\n" +
                          "5 - Körningen gick mycket bra utan problem orsakade av materialet.",
                CustomColors.InfoText_Color.Info, "Info", this);
        }






        //---------------------------------------------TIMERS-------------------------------------------------
        private int counter_ChangeGrade = 0;
        private int counter_CheckForUpdate = 0;
        private int counter_CheckMätpunkter = 0;
        private int counter_PlaneratStopp = 0;
        private int counter_UpdateChart = 0;
        private int counter_ReLoginMonitor = 0;
        private int timer_counterPlaneratStopp = 60;
        public static int timer_ReloginMonitor = 600000;

        private Timer timer_Master;
        private async void MasterTimer_Tick(object? sender, EventArgs e)
        {
            timer_Master.Stop();
            // Varje sekund
            counter_ChangeGrade++;
            counter_PlaneratStopp++;
            counter_CheckForUpdate++;
            counter_CheckMätpunkter++;
            counter_UpdateChart++;
            counter_ReLoginMonitor++;


            // 60 sek: Kontrollera planerat stopp
            if (counter_PlaneratStopp >= timer_counterPlaneratStopp)
            {
                counter_PlaneratStopp = 0;
                CheckForMaintenanceWork();
            }

            // 10 sek: Kontrollera mätpunkter
            if (counter_CheckMätpunkter >= 10)
            {
                counter_CheckMätpunkter = 0;
                MainMeasureStatistics.Kontrollera_Mätningar.Medelvärden();
            }
            // 10 sek: Kolla efter uppdatering
            if (counter_CheckForUpdate >= 10)
            {
                counter_CheckForUpdate = 0;
                CheckForUpdate();
            }
            //60 sek: Hantera inloggning mot Monitor API
            if (counter_ReLoginMonitor >= timer_ReloginMonitor)
                ReLogin_Monitor();

         
            // 5 min: Kolla uppdatering och statistik
            if (counter_UpdateChart >= 300)
            {
                counter_UpdateChart = 0;

                _ = Task.Run(() => measureStats.Add_MeasureInformation_MainForm(panelChart, tlp_MainWindow));

                await Statistics_DPP.Load_StatisticsAsync();
            }

            // 10 min: Ändra GUI-grade
            if (counter_ChangeGrade >= 600)
            {
                counter_ChangeGrade = 0;
                Change_GUI_Grade();
            }

            timer_Master.Start();
        }



        private void CheckForUpdate()
        {
            if (ChangeLog.LatestVersion is null)
                return;

            if (ChangeLog.LatestVersion.CompareTo(ChangeLog.CurrentVersion) <= 0)
                return;

            if (Program.IsUpdateCritical)
            {
                InfoText.Show(LanguageManager.GetString("update_Info_1"),
                    CustomColors.InfoText_Color.Bad,
                    "Warning!", this);

                Maintenance.StartInstallation();
                counter_CheckForUpdate = 1; // 1 minut mellan försöken
                return;
            }

            Activity.Start();

            InfoText.Question(
                $"{LanguageManager.GetString("update_Info_1_1")}\n\n" +
                $"{ChangeLog.News}\n" +
                $"{LanguageManager.GetString("update_Info_1_2")}",
                CustomColors.InfoText_Color.Warning,
                "Warning!", this);

            if (InfoText.answer == InfoText.Answer.No)
            {
                _ = Activity.Stop($"Användare {Person.Name} uppdaterade INTE programmet.");
                counter_CheckForUpdate = 300; // 5 timmar
            }
            else
            {
                _ = Activity.Stop($"Användare {Person.Name} uppdaterade programmet.");
                counter_CheckForUpdate = 5;
                Maintenance.StartInstallation();
            }
        }
        private void ReLogin_Monitor()
        {
            
            if (Monitor.Monitor.status == Monitor.Monitor.Status.Bad)
            {
                Login_Monitor.Login_API();

                timer_ReloginMonitor = Monitor.Monitor.status != Monitor.Monitor.Status.Bad ? 300 : 10; // Om ok, vänta 5min innan nästa inloggning, annars 10 sek
            }
                
        }
        private void CheckForMaintenanceWork()
        {
            if (Person.Role == "SuperAdmin")
                return;

            if (Maintenance.IsMaintenance_Ongoing)
            {
                InfoText.Show($"{LanguageManager.GetString("maintenanceWork_1")} {Maintenance.Time_Ongoing}.",
                    CustomColors.InfoText_Color.Bad, "Info", this);
                Application.Exit();
                return;
            }

            if (!Maintenance.IsMaintenance_Coming)
                return;

            ctr_Info_Planerat_Stopp++;

            var clr = CustomColors.InfoText_Color.Ok;
            //Mellan 8 timmar och 2 dygn kvar till planerat stopp
            if (Maintenance.Time_Left_Stop.TotalHours > 8)
            {
                timer_counterPlaneratStopp = 60; // 1 timme
                clr = CustomColors.InfoText_Color.Warning;
            }

            //Mer än 2 dygn kvar till planerat stopp
            if (Maintenance.Time_Left_Stop.TotalDays > 2)
            {
                timer_counterPlaneratStopp = 420; // 7 timmar
                clr = CustomColors.InfoText_Color.Ok;
            }
                
            //Mindre än 8 timmar kvar till planerat stopp
            if (Maintenance.Time_Left_Stop.TotalHours < 8)
            {
                timer_counterPlaneratStopp = 60; // 30 minuter
                clr = CustomColors.InfoText_Color.Bad;
            }
                

            Activity.Start();
            InfoText.Show($"{LanguageManager.GetString("maintenanceWork_4")} {Maintenance.Time_Left} \n\n" +
                          $"{Maintenance.Date_PlannedStop} {LanguageManager.GetString("maintenanceWork_2")}\n\n" +
                          $"{LanguageManager.GetString("maintenanceWork_3")} {Maintenance.PlannedTime}", clr, "Info", this);
            _ = Activity.Stop($"{Person.Name} har läst om Planerat Stopp");

        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlManager.Close_All_Körprotokoll();

            SaveData.Reset_Processcard_Open(false);
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SignOut();
        }

        
    }
}

