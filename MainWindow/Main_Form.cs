//Created by: Richard Aakula
//Date      : 14-02-2013
//Projekt   : Digitala mät&kör Protokoll

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
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
using Activity = DigitalProductionProgram.Log.Activity;
using Pictures = DigitalProductionProgram.OrderHantering.Pictures;
using CustomProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.MainWindow
{

    public partial class Main_Form : Form
    {
        private static readonly Timer Timer_UpdateSQL_Counter = new Timer();
        public ApplicationScheduler _scheduler;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Control ctrl;

            switch (keyData)
            {
                case Keys.F1:
                    Activity.Start();
                    ctrl = cf_Buttons.Measureprotocol;
                    cf_Buttons.F1_MeasureProtocol_Click(ctrl, null);
                    return true; // indicate that you handled this keystroke
                case Keys.F2:
                    Log.Activity.Start();
                    ctrl = cf_Buttons.Protocol;
                    cf_Buttons.F2_Protocol_Click(ctrl, null);
                    return true;
                case Keys.F3:
                    Activity.Start();
                    ctrl = cf_Buttons.BrowseOldMeasureprotocol;
                    cf_Buttons.F3_SearchOldMeasureProtocols_Click(ctrl, null);
                    return true;
                case Keys.F4:
                    Activity.Start();
                    ctrl = cf_Buttons.BrowseOldOrders;
                    cf_Buttons.F4_SearchOldProtocols(ctrl, null);
                    return true;
                case Keys.F5:
                    Activity.Start();
                    ctrl = cf_Buttons.Compound;
                    cf_Buttons.F5_Compund_Click(ctrl, null);
                    return true;
                case Keys.F6:
                    Activity.Start();
                    ctrl = cf_Buttons.Zumbach;
                    cf_Buttons.F6_Zumbach_Click(ctrl, null);
                    break;
                case Keys.F7:
                    Activity.Start();
                    ctrl = cf_Buttons.OverviewProdlines;
                    cf_Buttons.F7_OverviewProdLines_Click(ctrl, null);
                    return true;
                case Keys.F8:
                    Activity.Start();
                    ctrl = cf_Buttons.Statistics;
                    cf_Buttons.F8_Statistics_Click(ctrl, null);
                    return true;
                case Keys.F9:
                    Activity.Start();
                    ctrl = cf_Buttons.Frequency_Marking;
                    cf_Buttons.F9_FrequencyMarking_Click(ctrl, null);
                    return true;
                case Keys.F12:
                    //black.Close();
                    break;
                        
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

        //UPPSNABBNING AV PROGRAMMET VID UTVECKLING
        public static bool IsZumbachÖppet = false;
        private static bool IsBetaMode = false;
        public static bool IsLoadingPriorityPlan = true;
        private static bool IsLoadingMeasurePoints = true;
        private const bool IsOpenRandomOrder = false;
        private const bool IsAutoOpenOrder = false;
        public const bool IsAutoLoginSuperAdmin = true;
        public const string adminHostName = "OH-ID61";

        private DateTime startTime;
        private const string? develop_OrderNr = "H67876";
        private const string? develop_Operation = "10";
        


        // Denna rad måste finnas för utskrifterna
        private readonly Manage_PrintOuts? print;
        public Main_Form()
        {
            startTime = DateTime.Now;
            this.Visible = false;
            Activity.Start();
            InitializeComponent();

            if (Database.cs_Protocol.Contains("GOD_DPP_DEV"))
                IsBetaMode = true;
            cf_MainMenu.mainForm = this;
            cf_OrderInformation.mainForm = this;
            cf_Serverstatus.SetMainForm(this);
            cf_PriorityPlanning.dgv_PriorityPlanning.CellClick += PriorityPlanning_OrderNr_CellClick;
            cf_OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
            lbl_Company.Text = Monitor.Monitor.factory.ToString();
            cf_OrderInformation.tb_OrderNr.Focus();

            print = new Manage_PrintOuts();
           
        }
        protected override async void OnShown(EventArgs e)
        {
            base.OnShown(e);

            await Task.Delay(500); // ger UI-tråden tid att börja rendera splash

            await Task.Run(() =>
            {
                Settings.Settings.LoadData.Load_Settings();
                Activity.Start();
                Login_Monitor.Login_API();
                Mail.AutoTestJira();
                Login_Monitor.GiveUserWarningMonitorOnStageServer();
               
                if (!IsAutoOpenOrder)
                {
                    Enum.TryParse(Settings.Settings.Tema, out Teman.Theme);
                    // UI → tillbaka till huvudtråden
                    this.Invoke(() =>
                    {
                        Teman.Choose_Theme();

                        if (!Program.IsComputerOnlyForMeasurements)
                            cf_OrderInformation.tb_OrderNr.AutoCompleteCustomSource = Monitor.Monitor.AutoFillOrdernr;
                        _ = Main_FilterQuickOpen.Load_ListAsync(dgv_QuickOpen);
                    });
                }

            });
            
            Translate_MainForm();
            await InitializeUIAsync();

            CloseSplash();
        }
        private async Task InitializeUIAsync()
        {
            //-- Här görst tyngre initialiseringar som inte behöver göras på UI-tråden --
            Change_GUI_StandardColor();

            RollingInformation.LoadStats();
            if (IsAutoOpenOrder == false)
            {
                Monitor.Monitor.Load_WorkCenters();
                cf_PriorityPlanning.Load_ProdGrupp();
                if (Settings.Settings.MeasuringComputerOnly)
                    Change_GUI_Mätdator();
                await Task.Run(() => cf_RollingInformation.Change_Tips());
                //RollingInformation.Change_Tips();
            }

            if ((Environment.MachineName == "THAI-DPP-TEST01" || Environment.MachineName == "OH-ID61") && IsAutoLoginSuperAdmin)
            {
                AUTOLOGIN_SUPERADMIN();
            }
            else
            {
                IsLoadingPriorityPlan = true;
                IsLoadingMeasurePoints = true;
            }
           
            var processes = Process.GetProcessesByName("DigitalProductionProgram");
            await Activity.Stop($"Application startup # {processes.Length}");
            _scheduler = new ApplicationScheduler(UpdateMeasureInformationAsync, UpdateGuiGrade, cf_Statistics_DPP, cf_Serverstatus);
            _scheduler.Start();
            _scheduler.CheckForUpdate();
            Text = "Digital Production Program - " + ChangeLog.CurrentVersion;
        }
        private void CloseSplash()
        {
            
            if (Program.splashScreen.InvokeRequired)
                Program.splashScreen.Invoke((Action)(() =>
                {
                    Program.splashScreen.ClearAllText();
                    Program.splashScreen.StartFadeOut();
                }));
            else
            {
                Program.splashScreen.ClearAllText();
                Program.splashScreen.StartFadeOut();
            }
                
            Thread.Sleep(500);
            this.Invoke(this.Show);
            Program.splashScreen.FadeCompleted += () =>
            {
                // ✨ Detta körs när splash är HELT faded out ✨
                this.Invoke(() =>
                {
                    this.BringToFront();
                    this.Activate();
                });
            };


        }



        protected override void SetVisibleCore(bool value)
        {
            // Om vi är på fel tråd – flytta arbetet till UI-tråden och avsluta direkt
            if (this.InvokeRequired)
            {
                // BeginInvoke för att undvika deadlocks
                this.BeginInvoke(new Action<bool>(v => SetVisibleCore(v)), value);
                return;
            }

            // Nu är vi på UI-tråden
            if (!this.IsHandleCreated)
            {
                // Skapa handtaget på UI-tråden
                this.CreateHandle();
                // Behåll osynligt initialt om det är det du vill
                value = false;
            }

            base.SetVisibleCore(value);
        }
        private void AUTOLOGIN_SUPERADMIN()
        {
            IsLoadingPriorityPlan = true;
            Timer_UpdateSQL_Counter.Start();
            Timer_UpdateSQL_Counter.Interval = 1000; // 1 sekund
            Timer_UpdateSQL_Counter.Tick += (s, e) => cf_Serverstatus.Set_Sql_Counter();
           

            cf_Serverstatus.lbl_SQL_Queries.Visible = true;
            cf_Serverstatus.lbl_Memory.Visible = true;
            cf_Serverstatus.label_Queries.Visible = true;
            cf_Serverstatus.label_Memory.Visible = true;

            Person.Name = "Richard Aakula";
            Person.Sign = "RA";
            Person.UserID = 24;
            Person.EmployeeNr = "347";
            Person.Role = "SuperAdmin";
            pbOperatör.Image = Person.ProfilePicture(Person.Name);
            Person.Mail = "richard.aakula@optinova.com";
            cf_ActiveOrdersUser.Visible = true;

            lbl_EmpNr.Text = Person.EmployeeNr;
            lbl_Sign.Text = Person.Sign;
            lbl_Namn.Text = Person.Name;
            lbl_Role.Text = "SuperAdmin";
            panel_Profile.Visible = true;
            Change_GUI_Grade();
            cf_MainMenu.Menu_Developer.Visible = true;
            cf_MainMenu.Menu_Order_DeleteOrder.Enabled = true;
            cf_MainMenu.Unlock_Menu();
            SaveData.UPDATE_User_Online(true, lbl_EmpNr.Text);
            if (IsOpenRandomOrder && Person.Role == "SuperAdmin")
            {
                cf_OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
                Order.Start.OpenRandomOrder((cf_OrderInformation));
                Order.Set_NumberOfLayers();
            }
            if (IsAutoOpenOrder && Person.Role == "SuperAdmin")
            {
                var ordernr = develop_OrderNr;
                var operation = develop_Operation;
                Order.CheckIfOldOrderNotDoneExists(ref ordernr, ref operation);
                if (!string.IsNullOrEmpty(ordernr))
                {
                    Order.OrderNumber = cf_OrderInformation.tb_OrderNr.Text = ordernr;
                    Order.Operation = operation;
                    Order.Load_OrderID(Order.OrderNumber, Order.Operation);
                    Order.Load_ProdLine();
                    Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation();
                    _ = StartOrLoadOrder(true);
                    //Open();
                    Order.Set_NumberOfLayers();
                    //Task.Factory.StartNew(() => cf_MeasureStats.Add_MeasureInformation_MainForm(panelChart, tlp_MainWindow));
                    Task.Run(cf_Buttons.Change_GUI_Buttons);

                }
            }

            WindowState = FormWindowState.Normal;
            Size = new Size(1920, 1080);
            cf_Statistics_DPP.Visible = true;
            //Calender.Fill_OnlineMonitorUsers();

            Task.Run(() => { cf_ActiveOrdersUser.Load_OrderNr(cf_OrderInformation); });
            _ = EasterEgg_Code.IsGameStarted;


            cf_MainMenu.Visible = true;
            cf_MainMenu.menuStrip.Visible = true;
        }

        

        //----------- CHANGE GUI-----------------------
        public void Change_GUI_MainForm()
        {
            if (InvokeRequired)
                Invoke(new Action(Change_GUI_MainForm));
            else
            {
                cf_MainMenu.Menu_Order_OrderDone.Enabled = true;
                Task.Run(cf_Buttons.Change_GUI_Buttons);
                Task.Run(Change_GUI_Form);
                cf_OrderInformation.cb_Operation.Enabled = false;
                cf_AQL.Visible = CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.IsUsingAQL_Module);
                cf_TipsAndTrix.Visible = CheckAuthority.IsWorkoperationAuthorized(CheckAuthority.TemplateWorkoperation.TipsAndTrix);
                Task.Factory.StartNew(cf_RollingInformation.Load_list_Tips);
            }
        }
        private void Change_GUI_Form()
        {
            if (InvokeRequired)
                Invoke(Change_GUI_Form);
            else
            {
                Control[] controls = { cf_MeasurePoints, cf_MeasureStats };
                foreach (var ctrl in controls)
                    ctrl.Visible = false;

                Database.ExecuteSafe(con =>
                {
                    const string query = @"
                    SELECT Name
                    FROM Workoperation.ControlVisibiltySettings  as visibility
	                    JOIN Workoperation.ApplicationControls as controls
		                    ON visibility.ControlID = controls.ID
                    WHERE WorkOperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation AND ID IS NOT NULL) 
	                    AND ColumnIndex IS NULL
                    ORDER BY ColumnIndex";
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
                });
            }
        }
        private void Set_GUI_Theme_Krympslang()
        {
            Control[] textLabels = { lbl_Company, label_EmpNr, lbl_EmpNr, label_Sign, lbl_Sign, label_Role, lbl_Role, lbl_Percent, cf_ActiveOrdersUser.label_Header_ActiveOrders };//Weather.lbl_Location, Weather.lbl_Temp, Weather.lbl_Wind,
            if (string.IsNullOrEmpty(Equipment.Equipment.HS_Machine) == false)
            {
                MachineColor.Set_HeatShrink_Color();
                Invoke((MethodInvoker)delegate
                {
                    tlp_Left.BackColor = cf_Buttons.BackColor = MachineColor.Theme_BackColor;
                });
                foreach (var control in textLabels)
                    control.ForeColor = MachineColor.Theme_ForeColor;
            }

        }

        private void Translate_MainForm()
        {
            if (InvokeRequired)
            {
                Invoke(Translate_MainForm);
                return;
            }

            var controls = new Control[]
            {
                cf_TipsAndTrix.label_Tips_Trix,
                label_EmpNr,
                label_Sign,
                label_Role,
                label_Filter,
                label_QuickOpenOrder
            };

            LanguageManager.TranslationHelper.TranslateControls(controls);
            LanguageManager.TranslationHelper.TranslateMainMenu(cf_MainMenu.menuStrip);

            cf_Buttons.Translate_Form();
            cf_OrderInformation.Translate_Form();
            cf_ActiveOrdersUser.Translate_Form();
            cf_PriorityPlanning.Translate_Form();
            cf_MeasurePoints.Translate_Form();
            cf_MeasureStats.Translate_Form();
        }


        public void Change_GUI_OrderKlar()
        {
            cf_AQL.Visible = false;
            cf_TipsAndTrix.Visible = false;
            tlp_MainWindow.BackgroundImage = null;

            //cf_MeasurePoints.tlp_Main.BackColor = cf_MeasureStats.BackColor = tlp_ExtraInfo.BackColor = Color.Transparent;

            tlp_Left.BackColor = Color.FromArgb(100, 20, 44, 20);
            BackColor = Color.FromArgb(20, 44, 20);

            tlp_ExtraInfo.Visible = true;
            Change_GUI_ExtraInfo();
           // MainMenu.Change_GUI_OrderFinished();
            cf_PriorityPlanning.Visible = false;
            //cf_Buttons.Change_GUI_OrderFinished();

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
        public void Change_GUI_StandardColor()
        {
            cf_PriorityPlanning.Change_GUI_OrderNotFinished();
            cf_MainMenu.Change_GUI_OrderNotFinished();
            cf_Buttons.Change_GUI_OrderNotFinished();

            label_ExtraInfo.Visible = true;
            lbl_Rating.Visible = false;

            Change_GUI_ExtraInfo();
            if (IsBetaMode)
                ChangeToBetaMode();
            Change_Theme();
        }
        private void Change_GUI_Mätdator()
        {
            cf_Buttons.Change_GUI_Mätdator();
            cf_MainMenu.Change_GUI_Mätdator();
            cf_PriorityPlanning.Visible = false;

            Size = new Size(1250, 600);
        }
        private void Change_GUI_ExtraInfo()
        {
            if (InvokeRequired)
            {
                Invoke(Change_GUI_ExtraInfo);
                return;
            }

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
        private void UpdateGuiGrade()
        {
            Change_GUI_Grade();
        }
        private void Change_GUI_Grade()
        {
            if (string.IsNullOrEmpty(Person.EmployeeNr))
            {
                panel_Grade_Percent.Visible = false;
                pb_Grade.Visible = false;
                lbl_Percent.Visible = false;
                return;
            }

            Points.TotalPoints = Person.User_Points;
            if (Points.TotalPoints < 0)
                return;
            if (Grade.Img_Grade != null)
            {
                var _ = pb_Grade.BackgroundImage = Image.FromStream(Grade.Img_Grade);
            }

            pb_Grade.Visible = true;
            panel_Grade_Percent.BackColor = Color.FromArgb(60, Color.LightGreen);
            panel_Grade_Percent.Visible = true;
            lbl_Percent.Visible = true;

            panel_Grade_Percent.Height = (int)(pb_Grade.Height * Grade.percent_Grade(Grade.grade));
            panel_Grade_Percent.Top = pb_Grade.Bottom - panel_Grade_Percent.Height;

            lbl_Percent.Text = $"{Convert.ToInt32(Grade.percent_Grade(Grade.grade) * 100)} %";
        }
        private void ChangeToBetaMode()
        {
            if (Environment.MachineName != "OH-ID61")
                InfoText.Show(LanguageManager.GetString("warning_Testdatabase"), CustomColors.InfoText_Color.Bad, "Warning");
            tlp_Left.BackColor =  panel_Right.BackColor = Color.Pink;//cf_OrderInformation.BackColor =
            if (Environment.MachineName == "THAI-DPP-TEST01" || Environment.MachineName == "OH-ID61")
                return;
            var betaOverlay = new BetaOverlayForm(this);
            betaOverlay.Show();
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
                BeginInvoke(() => cf_OrderInformation.Change_Theme());
            }

            cf_MeasurementChart.BackColor = Teman.backColor_Chart;
            tlp_ExtraInfo.BackColor = cf_TipsAndTrix.label_Tips_Trix.BackColor = cf_TipsAndTrix.pb_Info_Tips_Trix.BackColor = Teman.backColor_ExtraInfo;
            lbl_ExtraInfo.ForeColor = Teman.foreColor_ExtraInfo;

            BeginInvoke(() => panel_Bottom.BackColor = Teman.backColor_Panels);

            BeginInvoke(() => cf_MainMenu.Change_Theme());
            BeginInvoke(() => cf_Buttons.Change_Theme());
            BeginInvoke(() => cf_MeasureStats.Change_Theme());
            BeginInvoke(() => cf_MeasurePoints.Change_Theme());
            BeginInvoke(() => cf_RollingInformation.Change_Theme());
            BeginInvoke(() => cf_PriorityPlanning.Change_Theme());
            BeginInvoke(() => cf_AQL.Change_Theme());
            BeginInvoke(() => cf_ActiveOrdersUser.Change_Theme());


            Set_GUI_Theme_Krympslang();
            _ = Activity.Stop($"Choosing Theme {Teman.Theme.ToString()}");
        }
        private async Task UpdateMeasureInformationAsync()
        {
            if (string.IsNullOrEmpty(Order.OrderNumber))
                return;

            await cf_MeasureStats.Add_MeasureInformation_MainForm(cf_MeasurementChart, tlp_MainWindow);
        }

        //---------------------------------------------STARTA ORDER---------------------------------------------
        public async Task StartOrLoadOrder(bool IsOperationOk)
        {
            MainMeasureStatistics.ChartCodeText = string.Empty;
            MainMeasureStatistics.ChartCodename = string.Empty;
            MeasurementChart.ActiveCodeName = string.Empty;
            MeasurementChart.ActiveCodeText = string.Empty;

            Order.Is_PrintOutCopy = true;

            // Stoppa MainTimer eventuellt om det blir problem
            if (IsOperationOk == false) //Om Ordern har blivit öppnad från Öppna-menyn så skippas detta steg
            {
                if (cf_OrderInformation.cb_Operation.Text.Contains("-"))
                    Order.Operation = cf_OrderInformation.cb_Operation.Text.Substring(0, cf_OrderInformation.cb_Operation.Text.IndexOf('-') - 1);
                else
                    Order.Operation = cf_OrderInformation.cb_Operation.Text;
                var start = cf_OrderInformation.cb_Operation.Text.IndexOf('-') + 2;
                var length = cf_OrderInformation.cb_Operation.Text.Length - start;
                Order.ProdLine = cf_OrderInformation.cb_Operation.Text.Substring(start, length);

                Order.ProdGroup = Main_OrderInformation.List_ProdGroup[cf_OrderInformation.cb_Operation.SelectedIndex];
            }

            Order.Load_OrderInformation();
            Monitor.Monitor.Current.Load_OrderInformation();

            var IsOkStartOrder = true;

            if (Order.IsOrderExist(Order.OrderNumber, Order.Operation))
                Open();
            else
                Order.Start.New_Order(this, ref IsOkStartOrder); //Hämtar data från Monitor och sparar i Korprotokoll_Databas PartID laddas här
            if (IsOkStartOrder == false)
                return;

            Part.SetPartNrSpecial("BioBurden Samples");
            Order.IsUsingBioBurdenSamples = Part.IsPartNrSpecial;

            Load_MainForm();
            cf_PriorityPlanning.tb_ProdGrupp.Text = cf_OrderInformation.lbl_ProdGroup.Text;

            if (QC_Feedback.IsOperationHaveQCFeedback)
            {
                cf_FeedBackQC.Visible = true;
                cf_FeedBackQC.LoadData();
            }
            else
                cf_FeedBackQC.Visible = false;
            Close_Open_Forms();

            lbl_ExtraInfo.Text = Part.ExtraInfo_Part;

            //if (IsAutoOpenOrder == false)
            //    Task.Run(Change_Theme);
            Task.Run(Change_GUI_MainForm);

            Change_GUI_ExtraInfo();
            Order.Set_NumberOfLayers();
            Load_MeasurePoints();
            MeasurementChart.LoadAvgValuesForLastOrder();
            MeasurementChart.LoadAvgValuesForPart();

            await cf_MeasureStats.Add_MeasureInformation_MainForm(cf_MeasurementChart, tlp_MainWindow);

            //Task.Factory.StartNew(() => cf_MeasureStats.Add_MeasureInformation_MainForm(panelChart, tlp_MainWindow));

            Tools.Load_HSPipes();

            if (Order.IsOrderDone)
                Change_GUI_OrderKlar();
            else
                Change_GUI_StandardColor();

            cf_MainMenu.Unlock_Korprotokoll_Menu();
        }
        public async void Operation_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cf_OrderInformation.cb_Operation.SelectedIndex > -1 & !string.IsNullOrEmpty(cf_OrderInformation.cb_Operation.Text) & !string.IsNullOrEmpty(cf_OrderInformation.tb_OrderNr.Text))
            {
                cf_OrderInformation.cb_Operation.BackColor = Color.White;
                await StartOrLoadOrder(false);
                cf_OrderInformation.tb_OrderNr.Enabled = false;
            }
        }


        //---------------------------------------------LADDA SPARA---------------------------------------------
        private void Open()
        {
            Activity.Start();
            Order.Set_IsOrderDone();
            if (Program.IsComputerOnlyForMeasurements)
                Change_GUI_Mätdator();

            Order.Is_PrintOutCopy = true;

            cf_OrderInformation.tb_OrderNr.Enabled = false;
            //Stänger eventuella öppna Körprotokoll
            Close_Open_Forms();


            cf_Buttons.panel_Pictures.Visible = true;

            CustomProgressBar.close();
            Activate();
            //cf_OrderInformation.tb_OrderNr.SelectionLength = 0;
            Cursor = Cursors.Arrow;

            _ = Activity.Stop("Opening Order:");
        }
        private void Load_MainForm()
        {
            cf_OrderInformation.Load_Data();
            Equipment.Equipment.HS_Machine = Machines.Active_HS_Machine;

            Order.Load_ProdType();

            lbl_ExtraInfo.Text = Part.ExtraInfo_Part;

            cf_AQL.ClearData();
            cf_TipsAndTrix.LoadData();
            cf_AQL.Initialize_QC_ProvuttagInfo();
        }

        private void Öppna_Gallup()
        {
            
            var bg = new BlackBackground("", 80);
            bg.Show();
            using var gallup = new UserPoll();
            gallup.ShowDialog();
            bg.Close();
            bg.Dispose();
        }



        //---------------------------------------------MÄTPUNKTER--------------------------------------------------
        public void Load_MeasurePoints()
        {
            if (IsLoadingMeasurePoints == false)
                return;
            Monitor.Monitor.Load_DataTable_Measurpoints(Order.OrderNumber, Order.Operation, true);
            cf_MeasurePoints.AddMeasurePointsMainForm();
        }



        //---------------------------------------------CLEAR--------------------------------------------------
        public void Clear_Mainform()
        {
            Cursor = Cursors.Arrow;
            cf_MeasurePoints.Visible = false;
            cf_MeasureStats.Visible = false;
            
            cf_MeasurementChart.Visible = false;
            tlp_ExtraInfo.Visible = false;
            cf_Buttons.Change_GUI_Buttons();
            Order.Clear_Order();
            cf_TipsAndTrix.ClearData();
            cf_AQL.ClearData();
            cf_FeedBackQC.Visible = false;

            cf_OrderInformation.cb_Operation.SelectedIndexChanged -= Operation_SelectedIndexChanged;
            cf_OrderInformation.tb_OrderNr.TextChanged -= Operation_SelectedIndexChanged;
            cf_OrderInformation.Clear();
            cf_OrderInformation.tb_OrderNr.TextChanged += Operation_SelectedIndexChanged;
            cf_OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
        }
        private static void Close_Open_Forms()
        {
            ControlManager.Close_All_Körprotokoll();
            MainMeasureStatistics.Close_All_MeasureProtocols();
        }



        //---------------------------------------------KÖRPLANERING-------------------------------------------
        private void PriorityPlanning_OrderNr_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (cf_PriorityPlanning.dgv_PriorityPlanning.Columns[0].Name != "OrderNr" || e.RowIndex < 0)
                return;
            if (IsZumbachÖppet)
            {
                InfoText.Show("Du har Zumbachfönstret fortfarande öppet, stäng det före du försöker öppna en ny order",
                    CustomColors.InfoText_Color.Warning, "Varning!");
                return;
            }
            Clear_Mainform();

            cf_OrderInformation.tb_OrderNr.Enabled = true;
            cf_OrderInformation.tb_OrderNr.Text = cf_PriorityPlanning.dgv_PriorityPlanning.Rows[e.RowIndex].Cells["OrderNr"].Value.ToString();
            cf_OrderInformation.cb_Operation.Focus();
            cf_OrderInformation.Fill_cb_Operation();

            Order.Operation = cf_PriorityPlanning.dgv_PriorityPlanning.Rows[e.RowIndex].Cells["Operation"].Value.ToString();

            int.TryParse(Order.Operation, out int operation);
            cf_OrderInformation.Set_Operation(operation);

            cf_OrderInformation.tb_OrderNr.Enabled = false;
            cf_OrderInformation.cb_Operation.Enabled = true;
            cf_PriorityPlanning.dgv_PriorityPlanning.ClearSelection();
        }



        //---------------------------------------------SNABBÖPPNA---------------------------------------------
        private void QuickOpen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            Clear_Mainform();
            Order.WorkOperation = Manage_WorkOperation.WorkOperations.Nothing;
            var dgv = (DataGridView)sender;
            cf_OrderInformation.cb_Operation.SelectedIndexChanged -= Operation_SelectedIndexChanged;
            cf_OrderInformation.tb_OrderNr.Validated -= cf_OrderInformation.OrderNr_Validated;

            if (IsZumbachÖppet)
            {
                InfoText.Show(LanguageManager.GetString("quickOpen_Info_2"), CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }

            Order.OrderID = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
            Order.OrderNumber = cf_OrderInformation.tb_OrderNr.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
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
            _ = StartOrLoadOrder(true);
            dgv.ClearSelection();


            cf_OrderInformation.cb_Operation.SelectedIndexChanged += Operation_SelectedIndexChanged;
            cf_OrderInformation.tb_OrderNr.Validated += cf_OrderInformation.OrderNr_Validated;
        }
        private void FilterWorkoperations_Click(object sender, EventArgs e)
        {
            using var quickOpen = new Main_FilterQuickOpen(dgv_QuickOpen);
            using var blackBackground = new BlackBackground(null, 80);

            quickOpen.AddWorkoperationCheckBoxes();

            quickOpen.Left = MousePosition.X - 100;
            quickOpen.Top = MousePosition.Y - quickOpen.Height;
            blackBackground.StartPosition = FormStartPosition.Manual;
            blackBackground.Location = this.Location;

            blackBackground.Show();
            quickOpen.ShowDialog();
            blackBackground.Close();

        }




        //---------------------------------------------INLOGGNING---------------------------------------------
        public void SignIn()
        {
            var screen = Screen.FromPoint(Cursor.Position);

            SignOut();

            using var frmLogin = new Login();
            using var backGround = new BlackBackground(string.Empty, 50)
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

           // backGround.Dispose();
           // frmLogin.Dispose();


            lbl_EmpNr.Text = Person.EmployeeNr;
            lbl_Sign.Text = Person.Sign;
            lbl_Role.Text = Person.Role;
            lbl_Namn.Text = Person.Name;

            panel_Profile.Visible = true;
            cf_ActiveOrdersUser.Visible = true;

            Change_GUI_Grade();

            pbOperatör.Image = Person.ProfilePicture(Person.Name);


            if (!string.IsNullOrEmpty(lbl_Namn.Text))
            {
                Points.Add_Points(1, "Log in");
                SaveData.UPDATE_User_Online(true, lbl_EmpNr.Text);
            }

            if (!UserPoll.IsUserVotedPoll)
                Öppna_Gallup();

            if (CheckAuthority.IsOkReadMyAnalysis)
            {
                using var my_Analysis = new My_Analysis(); 
                my_Analysis.ShowDialog();
            }

            #region Kontrollerar om Användaren har en gammal order öppen som ej blivit avslutad

            var ordernr = string.Empty;
            var operation = string.Empty;
            Order.CheckIfOldOrderNotDoneExists(ref ordernr, ref operation);
            if (!string.IsNullOrEmpty(ordernr))
            {
                Order.OrderNumber = cf_OrderInformation.tb_OrderNr.Text = ordernr;
                Order.Operation = operation;
                Order.Load_OrderID(ordernr, operation);
                Order.Load_ProdLine();
                Order.WorkOperation = Manage_WorkOperation.Load_WorkOperation();
                _ = StartOrLoadOrder(true);
            }
            #endregion

            if (User.Person.Name == "Richard Aakula" || User.Person.Name == "Kenny Lindqvist")
            {
                var target = new DateTime(2025, 11, 4, 18, 30, 0);
                DateTime now = DateTime.Now;
                TimeSpan difference = target - now;
                int days = difference.Days;
                int hours = difference.Hours;
                int minutes = difference.Minutes;
                if (days >= 0)
                    InfoText.Show($"JAHA!!!! {days} dagar, {hours} timmar och {minutes} minuter tills de bär av till Prag nu!!", CustomColors.InfoText_Color.Info, "Kennyboy", this);
            }


            cf_MainMenu.Unlock_Menu();
            cf_RollingInformation.Load_list_Tips();

            Task.Run(() => { cf_ActiveOrdersUser.Load_OrderNr(cf_OrderInformation); });
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
            pb_Grade.Image = null;
            lbl_Percent.Text = string.Empty;

            panel_Profile.Visible = false;
            cf_ActiveOrdersUser.Visible = false;

            Person.Clear();
            ControlManager.Close_All_Körprotokoll();
            cf_MainMenu.Lock_Menu();
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
                case Manage_WorkOperation.WorkOperations.Nothing:
                    var bg = new BlackBackground(string.Empty, 70);
                    bg.Show();
                    using (var pk = new VäljProcesskort())
                        pk.ShowDialog();
                    bg.Close();
                    bg.Dispose();
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
                using var game = new EasterEgg_1();
                game.ShowDialog();
            }

        }
        private void EasterEgg_2_Click(object sender, EventArgs e)
        {
            if (EasterEgg_HighScore.IsOkStartGame("Easter Egg 2", this))
            {
                using var game = new EasterEgg_2();
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


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControlManager.Close_All_Körprotokoll();
            SaveData.Reset_Processcard_Open(false);

            var topMethod = ServerStatus.dictMethodsSqlCounter
                .OrderByDescending(kv => kv.Value)
                .FirstOrDefault();

            var stopTime = DateTime.Now;
            var time = stopTime - startTime;
            var totalTime = time.ToString(@"hh\:mm\:ss");

            // 👇 BLOCKERA tills async Stop() är helt klar
            Activity.Stop(
                $"Closing DPP: (Total SQL Queries: {Database.SQL_Counter}) " +
                $"(Most Common Method: {topMethod.Key} - Total Queries for most common Method: {topMethod.Value}) " +
                $"- Total Time: {totalTime}"
            ).GetAwaiter().GetResult();
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            SignOut();
        }

        
    }
}

