using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.ExtraProtocols;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.Protocol
{
    public partial class MainProtocol : Form
    {
        public static string FormTemplateName(int formTemplateID)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT ModuleName 
                    FROM Protocol.FormTemplate WHERE FormTemplateID = @formtemplateid";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@formtemplateid", formTemplateID);
                var value = cmd.ExecuteScalar();
                if (value != DBNull.Value)
                    return (string)value;
            }

            return null;
        }
        public static bool IsUsingMultipleColumnsStartUp
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT IsMultipleColumnsStartup FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateID";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@maintemplateID", Templates_Protocol.MainTemplate.ID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (bool.TryParse(reader["IsMultipleColumnsStartup"].ToString(), out var isUsingMultipleColumnsStartUp))
                            if (isUsingMultipleColumnsStartUp)
                                return true;
                    }
                }
                return false;
            }
        }
        public static bool IsUsingStartUpDates
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT IsStartUpDates FROM Protocol.FormTemplate WHERE MainTemplateID = @maintemplateID";
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@maintemplateID", Templates_Protocol.MainTemplate.ID);
                    con.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (bool.TryParse(reader["IsStartUpDates"].ToString(), out var isUsingStartUpDates))
                            if (isUsingStartUpDates)
                                return true;
                    }
                }
                return false;
            }
        }
        private bool IsOkAddStartUp
        {
            get
            {
                foreach (var module in tlp_Machines.Controls.OfType<Machine>().SelectMany(machine => machine.tlp_Machine.Controls.OfType<Module>()))
                {
                    if (module.IsAuthenticationNeeded == false)
                    {
                        var startup = module.dgv_Module.Columns.Count - 1;
                        foreach (DataGridViewRow row in module.dgv_Module.Rows)
                        {
                            var cell = row.Cells[startup];
                            if (cell.Value == null || string.IsNullOrEmpty(cell.Value.ToString()))
                            {
                                bool.TryParse(module.dgv_Module.Rows[cell.RowIndex].Cells["col_IsValueCritical"].Value.ToString(), out var isValueCriticial);
                                if (isValueCriticial == false)
                                    break;
                                InfoText.Show($"{LanguageManager.GetString("isOkAddStartUp")} \n\n" +
                                              string.Format(LanguageManager.GetString("isOkAddStartUp_2"), FormTemplateName(module.FormTemplateID)), CustomColors.InfoText_Color.Bad, "Warning!", this);
                                return false;
                            }


                        }
                    }
                }

                return true;
            }
        }
        private Extra_Comments? extraComments;
        public static List<DataGridView>? Module_dataGridViews;



        public MainProtocol()
        {
            InitializeComponent();
            Module_dataGridViews = new List<DataGridView>();
            Line_Clearance.lbl_LC_Name.Click += LC_Name_Click;
            Translate_Form();

            Module.IsOkToSave = false;

            AddMainInfo();
            LoadData();

            AddMachine(1);
            if (Machine.Is_MultipleMachines)
            {
                tlp_Machines.ColumnCount = 2;
                tlp_Machines.ColumnStyles[0] = new ColumnStyle(SizeType.Percent, 60);
                tlp_Machines.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 40);
                AddMachine(2);

                tlp_Main.ColumnStyles[1].Width = 400;
            }

            //LoadData();//Flyttat denna längre upp pga ProcesscardBasedOn behöver laddas före datan annars valideras ej datan rätt

            if (Korprotokoll.IsProtocol_Open_By_AnotherUser(this) || string.IsNullOrEmpty(Person.EmployeeNr) || Order.IsOrderDone || LineClearance.LineClearance.IsLineClearanceDone == false)
                SetProtocolLockState(true);
            else
                Module.IsOkShowList = true;

            if ((Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID ?? 0) != 0)
                if (LineClearance.LineClearance.IsLineClearanceApproved == false)
                    SetProtocolLockState(true);
                else
                    Module.IsOkShowList = true;


            if (Order.IsOrderDone)
                return;
            var isOkToCloseForm = false;
            CheckIfEquipmentIsConfirmed(false, ref isOkToCloseForm);
            // SetSize_MainForm();

        }
        private void MainProtocol_Load(object sender, EventArgs e)
        {
            Module.IsOkToSave = true;
        }
        public void Translate_Form()
        {
            LanguageManager.TranslationHelper.TranslateControls(new Control[] { btn_AddStartUp, btn_RemoveStartUp, btn_Confirm_Equipment, btn_Edit_Equipment });
            btn_ExtraComments.Text = LanguageManager.GetString("extraComments");
        }

        private void LoadData()
        {
            ProcesscardBasedOn?.Load_Data();
            Comments.Load_Data();
            Line_Clearance.Load_Data(Order.OrderID);

            if (PreFab.IsUsingPreFab)
                PreFab.Load_Data();
        }
        private void SetProtocolLockState(bool IsLock)
        {
            PreFab.btn_AddPreFab.Enabled = PreFab.btn_RemovePreFab.Enabled = PreFab.dgv.Enabled = btn_AddStartUp.Enabled = btn_RemoveStartUp.Enabled = btn_Confirm_Equipment.Enabled = btn_Edit_Equipment.Enabled = btn_Add_Oven.Enabled = btn_RemoveOven.Enabled = !IsLock;

            Module.IsOkShowList = !IsLock;

            foreach (var module in tlp_Machines.Controls.OfType<Machine>().SelectMany(machine => machine.tlp_Machine.Controls.OfType<Module>()))
                module.dgv_Module.ReadOnly = IsLock;


            //foreach (Control machineControl in tlp_Machines.Controls)
            //{
            //    if (machineControl is Machine machine)
            //        foreach (Control moduleControl in machine.tlp_Machine.Controls)
            //            if (moduleControl is Module module)
            //                module.dgv_Module.ReadOnly = IsLock;
            //}


            Line_Clearance.Enabled = IsLock;
            Comments.tb_Comments.ReadOnly = IsLock;
        }
        private void AddMachine(int machineIndex)
        {
            var isUsingEquipment = false;
            var width = 0;
            var machine = new Machine(machineIndex, ref isUsingEquipment, ref width, false)
            {
                Dock = DockStyle.Fill,
                Name = machineIndex.ToString(),
            };
            tlp_Machines.Controls.Add(machine, machineIndex - 1, 0);
            //tlp_Machines.SetCellPosition(machine, new TableLayoutPanelCellPosition(machineIndex - 1, 0));

            _ = Activity.Stop($"IsUsingPreFab = {PreFab.IsUsingPreFab}");
            if (PreFab.IsUsingPreFab == false)
                Hide_PreFab();
            if (isUsingEquipment == false)
                Hide_Equipment();
            if (IsUsingMultipleColumnsStartUp)
                btn_Add_Oven.Visible = btn_RemoveOven.Visible = true;

        }

        private void Hide_PreFab()
        {
            PreFab.Visible = false;
            tlp_Right.RowStyles[1].Height = 0;
        }
        private void Hide_Equipment()
        {
            btn_Confirm_Equipment.Visible = btn_Edit_Equipment.Visible = false;
        }

        private void AddMainInfo()
        {
            string MainInfoTemplate = null;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT MainInfo_Template FROM Protocol.MainTemplate WHERE ID = @maintemplateid";

                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_Protocol.MainTemplate.ID);
                var value = cmd.ExecuteScalar();
                if (value != DBNull.Value)
                    MainInfoTemplate = (string)value;
            }

            switch (MainInfoTemplate)
            {
                case "A":
                    var mainInfo_A = new MainInfo.MainInfo_A
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 1)
                    };
                    panel_MainInfo.Controls.Add(mainInfo_A);
                    mainInfo_A.Load_Data(Order.OrderID);
                    break;
                case "B":
                    var mainInfo_B = new MainInfo.MainInfo_B
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 1)
                    };
                    panel_MainInfo.Controls.Add(mainInfo_B);
                    mainInfo_B.Load_Data(Order.OrderID);
                    break;
                case "C":
                    var mainInfo_C = new MainInfo.MainInfo_C
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(0, 0, 0, 1)
                    };
                    panel_MainInfo.Controls.Add(mainInfo_C);
                    mainInfo_C.Load_Data(Order.OrderID);
                    break;
                default:
                    var lbl_Error = new Label
                    {
                        Text = LanguageManager.GetString("mainInfo_Missing"),
                        ForeColor = CustomColors.Bad_Back,
                        Font = new Font("Arial", 24),
                        Dock = DockStyle.Fill,
                    };
                    panel_MainInfo.Controls.Add(lbl_Error);
                    break;
            }



        }

        private void LC_Name_Click(object? sender, EventArgs e)
        {
            if (Order.IsOrderDone)
                return;

            if (!LineClearance.LineClearance.IsLineClearanceDone)
                return;

            if ((Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID ?? 0) != 0)
                if (LineClearance.LineClearance.IsLineClearanceApproved == false)
                    return;

            SetProtocolLockState(false);
            Module.IsOkToSave = true;
        }


        private void AddStartup_Click(object sender, EventArgs e)
        {
            if (IsOkAddStartUp == false)
                return;
            Module.IsOkToSave = false;
            var NextStartup = Module.TotalStartUps + 1;

            foreach (Machine machine in tlp_Machines.Controls)
                machine.Add_StartUp(NextStartup);

            Module.IsOkToSave = true;
        }
        private void RemoveStartup_Click(object sender, EventArgs e)
        {
            var startup = Module.TotalStartUps;
            if (startup == 1)
            {
                InfoText.Show(LanguageManager.GetString("removeStartup_1"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }
            InfoText.Question($"{LanguageManager.GetString("removeStartup_2_1")} #{startup}?\n" +
                          LanguageManager.GetString("remove_Startup_2_2"), CustomColors.InfoText_Color.Warning, "Warning!", this);
            if (InfoText.answer == InfoText.Answer.No)
                return;

            Module.DatabaseManagement.Delete_StartUp(startup);

            foreach (Machine machine in tlp_Machines.Controls)
                machine.Remove_StartUp();

            _ = Activity.Stop($"Uppstart: {startup} raderades.");
        }
        private void Confirm_Equipment_Click(object sender, EventArgs e)
        {
            if (Module.IsOkToSave == false)
                return;
            var isOKToConfirm = false;
            var list_Module = new List<Module>();

            foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
            {
                int.TryParse(machine.Name, out var machineIndex);
                foreach (var tlp in machine.Controls.OfType<TableLayoutPanel>())
                    foreach (var module in tlp.Controls.OfType<Module>())
                        if (module.IsAuthenticationNeeded)
                            if (module.equipment.IsEquipmentOkToConfirm(module.dgv_Module, machineIndex))
                            {
                                isOKToConfirm = true;
                                list_Module.Add(module);
                            }
                            else
                                return;
            }

            if (!isOKToConfirm)
                return;

            if (Person.IsPasswordOk(LanguageManager.GetString("extrusionTEF_Info_3")) == false)
            {
                _ = Activity.Stop("Operatör har slagit in fel lösenord före överföring av utrustning");
                return;
            }
            foreach (var module in list_Module)
                module.equipment.ConfirmEquipment(module.dgv_Module);
        }
        private void AddOven_Click(object sender, EventArgs e)
        {
            Module.IsOkToSave = false;

            foreach (Machine machine in tlp_Machines.Controls)
            {
                foreach (var tlp in machine.Controls.OfType<TableLayoutPanel>())
                {
                    foreach (var module in tlp.Controls.OfType<Module>())
                    {
                        if (module.IsModuleUsedWithMultipleColumnsStartup)
                        {
                            var startup = Module.StartUp(module.dgv_Module.Columns[^1].HeaderText);
                            var oven = Module.SinteringOven.TotalOvens(Module.StartUp(module.dgv_Module.Columns[^1].HeaderText)) + 1;
                            if (Module.SinteringOven.IsOkAddOven(startup, Module.SinteringOven.Oven(module.dgv_Module.Columns[^1].HeaderText)))
                                module.AddStartup(startup, oven);
                            else
                            {
                                InfoText.Show("Du kan inte lägga till en ny ugn före du fyllt i data i den tidigare ugnen.", CustomColors.InfoText_Color.Bad, "Warning", this);
                                Module.IsOkToSave = true;
                                return;
                            }
                        }

                    }
                }

                machine.Divide_Startups(true);
            }

            Module.IsOkToSave = true;
        }
        private void RemoveOven_Click(object sender, EventArgs e)
        {
            var startup = Module.TotalStartUps;
            var oven = Module.SinteringOven.TotalOvens(startup);
            if (oven == 1)
            {
                InfoText.Show("Du kan inte radera den första Ugnen på en Uppstart.", CustomColors.InfoText_Color.Bad, "Warning", this);
                return;
            }

            Module.DatabaseManagement.Delete_Oven(startup, oven);

            foreach (Machine machine in tlp_Machines.Controls)
            {
                foreach (var tlp in machine.Controls.OfType<TableLayoutPanel>())
                {
                    foreach (var module in tlp.Controls.OfType<Module>())
                    {
                        if (module.IsModuleUsedWithMultipleColumnsStartup)
                            Module.SinteringOven.RemoveOven(module);
                    }
                }

                machine.Divide_Startups(false);
            }
            _ = Activity.Stop($"Ugn: {oven} Uppstart: {startup} raderades.");
        }
        private void Edit_Equipment_Click(object sender, EventArgs e)
        {
            foreach (var machine in tlp_Machines.Controls.OfType<Machine>())
            {
                foreach (var tlp in machine.Controls.OfType<TableLayoutPanel>())
                {
                    foreach (var module in tlp.Controls.OfType<Module>())
                    {
                        if (!module.IsAuthenticationNeeded) continue;

                        var lastRowIndex = module.dgv_Module.Rows.Count - 1;
                        var currentColumnIndex = module.dgv_Module.CurrentCell.ColumnIndex;
                        var cellValue = module.dgv_Module.Rows[lastRowIndex].Cells[currentColumnIndex].Value;
                        var name = cellValue?.ToString() ?? string.Empty;

                        if (name != Person.Name)
                        {
                            InfoText.Show(LanguageManager.GetString("equipment_Error_1"), CustomColors.InfoText_Color.Bad, "Warning", this);
                            return;
                        }

                        module.dgv_Module.Columns[currentColumnIndex].ReadOnly = false;
                    }
                }
            }

        }
        private void ExtraComments_Click(object sender, EventArgs e)
        {
            extraComments = new Extra_Comments();
            extraComments.Show();
        }

        private void CheckIfEquipmentIsConfirmed(bool isOkWarnUser, ref bool isOkToCloseForm)
        {
            isOkToCloseForm = true;
            var isQuestionAnswered = false;
            foreach (Machine machine in tlp_Machines.Controls.OfType<Machine>())
            {
                foreach (var tlp in machine.Controls.OfType<TableLayoutPanel>())
                    foreach (var module in tlp.Controls.OfType<Module>())
                        if (isQuestionAnswered == false)
                            module.equipment.CheckIfEquipmentIsConfirmed(ref isQuestionAnswered, ref isOkToCloseForm, isOkWarnUser);
            }
        }
        private void MainProtocol_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Module.IsOkToSave == false)
                return;
            var isOkToCloseForm = false;

            CheckIfEquipmentIsConfirmed(true, ref isOkToCloseForm);
            if (isOkToCloseForm == false)
                e.Cancel = true;
            SaveData.Reset_Processcard_Open(false);
            if (extraComments != null)
                extraComments.Close();
        }

        public void Show_ProcesscardBasedOn()
        {
            tlp_Right.RowStyles[2].Height = 100;
            tlp_Main.ColumnStyles[1].Width = 650;
        }
        public void Show_PreFab()
        {
            tlp_Right.RowStyles[1].Height = 150;
            tlp_Main.ColumnStyles[1].Width = 600;
        }
        public void Hide_ExtraControls()
        {
            tlp_Right.RowStyles[1].Height = 28;
            tlp_Right.RowStyles[2].Height = 28;
            tlp_Main.ColumnStyles[1].Width = 412;
        }

        
    }
}
