using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.IO.Ports;
using System.Net.Mail;
using System.Text;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.eMail;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Exception = System.Exception;
using DigitalProductionProgram.Zumbach;
using System.Text.Json;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.MainWindow;

namespace DigitalProductionProgram.Settings
{
    public partial class Settings : Form
    {
        public static string? Tema { get; set; }
        public static bool MeasuringComputerOnly { get; set; }

        public static string? ProdLine_LoadingPLan { get; set; }
        private Zumbach? zumbach;
        private SerialPort serialPort1;
        private bool IsOkAddPoints;
        

        public Settings()
        {
            InitializeComponent();
            serialPort1 = new SerialPort
            {
                PortName = "COM1",
                ReadTimeout = 5000,
                WriteTimeout = 5000,
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = Parity.None,
                Handshake = Handshake.None
            };
            serialPort1.Encoding = Encoding.GetEncoding(
                "us-ascii",
                new EncoderReplacementFallback("?"),
                new DecoderReplacementFallback("?")
            );
            Translate_Form();

            Lock_Controls();

            IsOkAddPoints = false;
            timer_AddPoints.Start();
            _ = new General(this);
        }

        private void Inställningar_Load(object sender, EventArgs e)
        {
            // LoadData.Load_Settings();
        }
        private void Translate_Form()
        {
            page_General.Text = LanguageManager.GetString("settings_Page_General");
            page_SpecialParts.Text = LanguageManager.GetString("settings_Page_Parts");

            page_Measureinstruments.Text = LanguageManager.GetString("settings_Page_Measureinstruments");

            Control[] controls =
            {
                chb_OnlyForMeasurements, label_Language, label_Settings_InfoZumbachCtr, label_Settings_InfoBaudRate, label_Settings_Add_Parts_Info, btn_AddPartNr, btn_DeletePartNr,
                label_Settings_Info_Measureinstruments, label_Settings_InfoMeasureinstrument_Add, label_Settings_InfoMeasureinstrument_Remove
            };
            LanguageManager.TranslationHelper.TranslateControls(controls);
        }
        private void Lock_Controls()
        {
            chb_OnlyForMeasurements.Enabled = CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeComputerForMeasurementOnly, false);

        }
        private void Page_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var selectedTab = tc_Main.SelectedTab;
            switch (tc_Main.SelectedTab?.Name)
            {
                case "page_General":
                    _ = new General(this);
                    break;
                case "page_Zumbach":
                    if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeSettingsZumbach) == false)
                        if (selectedTab != null)
                            selectedTab.Enabled = false;
                    zumbach = new Zumbach(this);
                    break;
                case "page_SpecialParts":
                    if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangePartLists) == false)
                        if (selectedTab != null)
                            selectedTab.Enabled = false;
                    _ = new SpecialPartNumbers(this);
                    break;
                case "page_Measureinstruments":
                    if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ManageMeasurementInstrumentTemplates) == false)
                        if (selectedTab != null)
                            selectedTab.Enabled = false;
                    _ = new MeasureInstruments(this);
                    break;
                case "page_Notifications":
                    _ = new Notifications(this);
                    break;
            }
        }
        private void Timer_AddPoints_Tick(object sender, EventArgs e)
        {
            IsOkAddPoints = true;
        }
        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsOkAddPoints)
                Points.Add_Points(3, "Varit in i Inställningar");

            zumbach?.SaveSettings();
            serialPort1.Close();
        }





        public class General
        {
            private readonly Settings settings;

            public General(Settings Settings)
            {
                settings = Settings;
                settings.cb_Language.SelectedIndexChanged += Language_SelectedIndexChanged;
                settings.chb_OnlyForMeasurements.CheckedChanged += MeasurementComputer_CheckedChanged;
                settings.cb_Language.Text = LoadData.Setting("CultureInfo");
                LoadSettings();
            }

            private void LoadSettings()
            {
                if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.ChangeComputerForMeasurementOnly, false))
                    settings.chb_OnlyForMeasurements.Enabled = true;

                settings.chb_OnlyForMeasurements.Checked = MeasuringComputerOnly;


            }

            private void MeasurementComputer_CheckedChanged(object? sender, EventArgs e)
            {
                if (settings.chb_OnlyForMeasurements.Checked)
                {
                    SaveData.IsComputerOnlyForMeasure(true);
                    MeasuringComputerOnly = true;
                }
                else
                {
                    SaveData.IsComputerOnlyForMeasure(false);
                    MeasuringComputerOnly = false;
                }
            }
            private void Language_SelectedIndexChanged(object? sender, EventArgs e)
            {
                switch (settings.cb_Language.SelectedIndex)
                {
                    case 0:
                        SaveData.UPDATE_Setting("CultureInfo", null, "sv-SE");
                        LanguageManager.selectedCulture = new CultureInfo("sv-SE");
                        break;
                    case 1:
                        SaveData.UPDATE_Setting("CultureInfo", null, "en-US");
                        LanguageManager.selectedCulture = new CultureInfo("en-US");
                        break;
                    case 2:
                        SaveData.UPDATE_Setting("CultureInfo", null, "th-TH");
                        LanguageManager.selectedCulture = new CultureInfo("th-TH");
                        break;
                }

                InfoText.Show(LanguageManager.GetString("stringRestartComputer"), CustomColors.InfoText_Color.Warning, "Warning!", settings);
            }
        }
        public class Zumbach
        {
            private readonly Settings settingsForm;
            private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
            public class ZumbachSettingsWrapper
            {
                public ZumbachSettings ZumbachSettings { get; set; } = new();
            }

            public Zumbach(Settings Settings)
            {
                settingsForm = Settings;
                SetZumbachSettings();

            }

            public void SetZumbachSettings()
            {
                if (!File.Exists(_filePath))
                    return;

                var json = File.ReadAllText(_filePath);
                var wrapper = JsonSerializer.Deserialize<ZumbachSettingsWrapper>(json);

                var zumbachSettings = wrapper?.ZumbachSettings;
                if (zumbachSettings is null)
                    return;

                settingsForm.cb_com_PortName.Text = zumbachSettings.Portname ?? "COM1";
                settingsForm.cb_com_BaudRate.Text = zumbachSettings.Baudrate.ToString();
                settingsForm.cb_com_DataBits.Text = zumbachSettings.DataBits.ToString();
                settingsForm.cb_com_StopBits.Text = zumbachSettings.Stopbits.ToString();
                settingsForm.cb_com_Parity.Text = Parity.Even.ToString();
                settingsForm.cb_com_HandShake.Text = zumbachSettings.Handshake.ToString();
                settingsForm.tb_com_ZumbachMessage.Text = zumbachSettings.Message ?? "g210";
                settingsForm.num_CtrDeleteZumbachMeasurepoints.Value = zumbachSettings.DeleteMeasurements ?? 5;
            }
            public void SaveSettings()
            {
                var zumbachSettings = new ZumbachSettings
                {
                    Portname = settingsForm.cb_com_PortName.Text,
                    Baudrate = int.TryParse(settingsForm.cb_com_BaudRate.Text, out var baud) ? baud : 9600,
                    DataBits = int.TryParse(settingsForm.cb_com_DataBits.Text, out var bits) ? bits : 8,
                    Stopbits = Enum.TryParse(settingsForm.cb_com_StopBits.Text, out StopBits stop) ? stop : StopBits.One,
                    Handshake = Enum.TryParse(settingsForm.cb_com_HandShake.Text, out Handshake hs) ? hs : Handshake.None,
                    Message = settingsForm.tb_com_ZumbachMessage.Text,
                    DeleteMeasurements = (int)settingsForm.num_CtrDeleteZumbachMeasurepoints.Value
                };

                var wrapper = new ZumbachSettingsWrapper
                {
                    ZumbachSettings = zumbachSettings
                };

                var json = JsonSerializer.Serialize(wrapper, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
        }
        public class SpecialPartNumbers
        {
            public static string Parts_ExtraDescription(string description)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT ExtraDescription FROM Parts.PartNrDescription WHERE description = @description";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@description", description);
                    return cmd.ExecuteScalar().ToString();
                }
            }
            public static DataTable DataTable_SpecialPartNr(string description)
            {
                var dt = new DataTable();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"SELECT PartNr FROM Parts.PartNrSpecial WHERE PartNrDescriptionID = (SELECT id FROM Parts.PartNrDescription WHERE Description = @description)";

                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@description", description);
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
            public static DataTable DataTable_PartNrDescription
            {
                get
                {
                    var dt = new DataTable();
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        const string query = @"SELECT Description FROM Parts.PartNrDescription WHERE id <> 3";

                        con.Open();
                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        dt.Load(cmd.ExecuteReader());
                        return dt;
                    }
                }
            }
            private readonly Settings settings;

            public SpecialPartNumbers(Settings Settings)
            {
                this.settings = Settings;
                settings.btn_AddPartNr.Click += Add_Click;
                settings.btn_DeletePartNr.Click += Delete_Click;
                settings.dgv_Parts_Description.RowEnter += PartsDescription_RowEnter;
                settings.pb_Info_Artiklar.Click += Info_PartNumber_Click;
                Load_Descriptions();

            }

            private void PartsDescription_RowEnter(object sender, DataGridViewCellEventArgs e)
            {
                var description = settings.dgv_Parts_Description.Rows[e.RowIndex].Cells[0].Value.ToString();
                settings.dgv_Parts.DataSource = DataTable_SpecialPartNr(description);
                settings.label_Settings_Part_Description_Info.Text = Parts_ExtraDescription(description);
            }
            private void Add_Click(object sender, EventArgs e)
            {
                var ActiveRow = settings.dgv_Parts_Description.CurrentCell.RowIndex;
                if (settings.dgv_Parts_Description.SelectedRows.Count == 0)
                {
                    InfoText.Show("Välj först en av listorna som du vill lägga till artikelnr.", CustomColors.InfoText_Color.Warning, "Varning");
                    return;
                }

                if (!string.IsNullOrEmpty(settings.tb_PartNr.Text))
                {
                    var description = settings.dgv_Parts_Description.Rows[settings.dgv_Parts_Description.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query = @"
                            IF NOT EXISTS (SELECT * FROM Parts.PartNrSpecial WHERE PartNr = @partnr AND PartNrDescriptionID = (SELECT id FROM Parts.PartNrDescription WHERE Description = @description))
                                BEGIN
                                    INSERT INTO Parts.PartNrSpecial 
                                    VALUES (@partnr, (SELECT ID FROM Parts.PartNrDescription WHERE Description = @description))
                                END";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@partnr", settings.tb_PartNr.Text);
                    cmd.Parameters.AddWithValue("@description", description);
                    con.Open();
                    cmd.ExecuteScalar();
                }
                else
                    InfoText.Show("Fyll i ett artikelnr före du försöker lägga till det.", CustomColors.InfoText_Color.Warning, "Warning!", settings);

                Load_Descriptions();

                settings.dgv_Parts_Description.Rows[ActiveRow].Cells[0].Selected = true;
                settings.tb_PartNr.Text = string.Empty;
                settings.tb_PartNr.Focus();
            }
            private void Delete_Click(object sender, EventArgs e)
            {
                if (settings.dgv_Parts_Description.SelectedRows.Count == 0)
                {
                    InfoText.Show("Välj först en av listorna som du vill lägga till artikelnr.", CustomColors.InfoText_Color.Warning, "Warning!", settings);
                    return;
                }

                if (settings.dgv_Parts.SelectedRows.Count == 0)
                {
                    var PartNr = settings.dgv_Parts.Rows[settings.dgv_Parts.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    var description = settings.dgv_Parts_Description.Rows[settings.dgv_Parts_Description.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    InfoText.Question($"Är du säker på att du vill radera ArtikelNr: {PartNr} från listan med Artiklar: ({settings.dgv_Parts_Description.Rows[settings.dgv_Parts_Description.CurrentCell.RowIndex].Cells[0].Value})?", CustomColors.InfoText_Color.Warning, "Warning!", settings);
                    if (InfoText.answer == InfoText.Answer.Yes)
                    {
                        using (var con = new SqlConnection(Database.cs_Protocol))
                        {
                            const string query = "DELETE FROM Parts.PartNrSpecial WHERE PartNr = @partnr AND PartNrDescriptionID = (SELECT id FROM Parts.PartNrDescription WHERE Description = @description)";
                            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                            cmd.Parameters.AddWithValue("@partnr", PartNr);
                            cmd.Parameters.AddWithValue("@description", description);
                            con.Open();
                            cmd.ExecuteScalar();
                        }
                    }
                }
                else
                    InfoText.Show("Välj ett artikelnr före du försöker radera det.", CustomColors.InfoText_Color.Warning, "Warning!", settings);

                Load_Descriptions();
            }
            private void Info_PartNumber_Click(object sender, EventArgs e)
            {
                InfoText.Show("Välj först vilken av listorna du vill lägga till eller radera ett artikelnr.\n " +
                              "Fyll sedan i artikelnumret och klicka på Lägg till Artikelnr, eller välj artikelnr från listan och klicka på Radera ArtikelNr", CustomColors.InfoText_Color.Info, "Info", settings);
            }

            private void Load_Descriptions()
            {
                settings.dgv_Parts_Description.DataSource = DataTable_PartNrDescription;
                settings.dgv_Parts_Description.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public class MeasureInstruments
        {
            private readonly Settings settings;

            public static string Template_ID(string Mätdon)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                            SELECT ID FROM MeasureInstruments.Templates WHERE MätdonsNr = @mätdon";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@mätdon", Mätdon);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        return value.ToString();
                }

                return null;
            }


            public MeasureInstruments(Settings Settings)
            {
                settings = Settings;
                settings.cb_Workoperations_Measureinstruments.SelectedIndexChanged += Workoperation_SelectedIndexChanged;
                Load_MeasureInstruments();
                Manage_WorkOperation.Fill_cb_Workoperation(settings.cb_Workoperations_Measureinstruments);
            }

            private void Load_MeasureInstruments()
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    const string query = @"
                    SELECT MätdonsNr
                    FROM MeasureInstruments.Templates";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        Add_Control_flp(reader.GetString(0), settings.flp_Measureinstruments);
                }
            }
            private void Load_UsedMeasureInstruments()
            {
                settings.flp_Used_Measureinstruments.Controls.Clear();

                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    con.Open();
                    var query = @"
                    SELECT MätdonsNr
                    FROM MeasureInstruments.WorkOperationTemplate as template
                        INNER JOIN MeasureInstruments.Templates as mätdon
	                        ON template.Template_ID = mätdon.ID
                    WHERE WorkOperation = @workoperation
                    ORDER BY MätdonsNr";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@workoperation", settings.cb_Workoperations_Measureinstruments.Text);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        Add_Control_flp(reader.GetString(0), settings.flp_Used_Measureinstruments);
                }
            }

            private void Add_Control_flp(string text, FlowLayoutPanel flp_Target)
            {
                var lbl = new Label
                {
                    ForeColor = Color.FromArgb(239, 228, 177),
                    Text = text,
                    Font = new Font("Consolas", 11f),
                    AutoSize = true,
                    Cursor = Cursors.Hand
                };
                lbl.Click += MeasureInstrument_Click;
                flp_Target.Controls.Add(lbl);
            }
            private void MeasureInstrument_Click(object sender, EventArgs e)
            {
                var ctrl = (Control)sender;

                if (ctrl.Parent == settings.flp_Measureinstruments)
                    Add_Control_flp(ctrl.Text, settings.flp_Used_Measureinstruments);
                else
                    ctrl.Dispose();
                Save(settings.cb_Workoperations_Measureinstruments.Text, settings.flp_Used_Measureinstruments);
            }
            private void Workoperation_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (settings.cb_Workoperations_Measureinstruments.SelectedIndex > -1)
                {
                    settings.flp_Measureinstruments.Enabled = true;
                    Load_UsedMeasureInstruments();
                }
            }

            public static void Delete(string workoperation)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = @"
                    DELETE FROM MeasureInstruments.WorkOperationTemplate
                    WHERE WorkOperation = @workoperation";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@workoperation", workoperation);
                    cmd.ExecuteNonQuery();
                }
            }
            public static void Save(string workoperation, FlowLayoutPanel flp)
            {
                Delete(workoperation);

                foreach (Label lbl in flp.Controls)
                {
                    using (var con = new SqlConnection(Database.cs_Protocol))
                    {
                        var query = @"
                            INSERT INTO MeasureInstruments.WorkOperationTemplate 
                            VALUES (@workoperation, @templateId)";
                        con.Open();
                        var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                        cmd.Parameters.AddWithValue("@workoperation", workoperation);
                        cmd.Parameters.AddWithValue("@templateId", Template_ID(lbl.Text));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
        public class Notifications
        {
            private readonly Settings settings;

            public Notifications(Settings Settings)
            {
                settings = Settings;
                LoadNotifications();
                settings.dgv_Notifications.SelectionChanged += Notifications_SelectionChanged;
                settings.dgv_NotificationItems.SelectionChanged += NotificationItems_SelectionChanged;
                settings.tb_Email.Click += Email_Click;
                settings.tb_Email.TextChanged += SaveEmail;
                settings.btn_RemoveSubscription.Click += RemoveSubscription_Click;
            }

            private void Notifications_SelectionChanged(object sender, EventArgs e)
            {
                var row = settings.dgv_Notifications.CurrentCell.RowIndex;
                if (row < 0 || settings.dgv_Notifications.Rows.Count == 0)
                    return;

                if (settings.dgv_Notifications.CurrentCell == null)
                    return;

                var selectedRow = settings.dgv_Notifications.Rows[row];

                // Check if the cell contains data before accessing it
                if (selectedRow.Cells[0].Value == null || string.IsNullOrWhiteSpace(selectedRow.Cells[0].Value.ToString()))
                    return;

                // Try parsing the notification ID safely
                if (!int.TryParse(selectedRow.Cells[0].Value.ToString(), out var notificationID))
                    return;

                switch (notificationID)
                {
                    case 1:
                        Fill_NotificationItems_Workoperations(settings.dgv_NotificationItems);
                        settings.label_NotificationItemsInfo.Text = "Välj här vilken arbetsoperation du vill ha en notis för";
                        break;
                }

                //settings.dgv_NotificationItems.DataSource = dt;
            }
            private void NotificationItems_SelectionChanged(object sender, EventArgs e)
            {
                LoadNotificationSubscriptions();
            }

            private void Email_Click(object sender, EventArgs e)
            {
                List<string?> emailList = Person.List_MailAddress.Select(mail => mail.Address).ToList();
                using var choose_Email = new Choose_Item(emailList, new Control[] { settings.tb_Email }, false, true);
                choose_Email.ShowDialog();
                settings.tb_Email.Text = string.Empty;
            }
            private void RemoveSubscription_Click(object sender, EventArgs e)
            {
                int.TryParse(settings.dgv_NotificationSubscriptions.Rows[settings.dgv_NotificationSubscriptions.CurrentCell.RowIndex].Cells["ID"].Value.ToString(), out var id);
                DeleteEmail(id);
            }

            private void SaveEmail(object sender, EventArgs e)
            {
                if (Mail.IsValidEmail(settings.tb_Email.Text) == false)
                    return;
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    INSERT INTO [Settings].NotificationSubscriptions (NotificationID, NotificationItem, UserEmail)
                    VALUES (@notificationid, @notificationitem, @email)";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    SQL_Parameter.Int(cmd.Parameters, "@notificationid", settings.dgv_Notifications.Rows[settings.dgv_Notifications.CurrentCell.RowIndex].Cells["ID"].Value.ToString());
                    cmd.Parameters.AddWithValue("@notificationitem", settings.dgv_NotificationItems.Rows[settings.dgv_NotificationItems.CurrentCell.RowIndex].Cells["Name"].Value.ToString());
                    cmd.Parameters.AddWithValue("@email", settings.tb_Email.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadNotificationSubscriptions();
            }
            private void DeleteEmail(int id)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    DELETE FROM [Settings].NotificationSubscriptions
                    WHERE ID = @id";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadNotificationSubscriptions();
            }
            public void LoadNotifications()
            {
                var dt = new DataTable();
                const string query = "SELECT ID, Notification FROM [Settings].Notifications";

                using (var con = new SqlConnection(Database.cs_Protocol))
                using (var cmd = new SqlCommand(query, con))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    con.Open();
                    adapter.Fill(dt);
                }

                settings.dgv_Notifications.DataSource = dt;
                settings.dgv_Notifications.Columns[0].Visible = false;
            }
            public void LoadNotificationSubscriptions()
            {
                var dt = new DataTable();
                var name = "";
                if (settings.dgv_NotificationItems.CurrentCell != null && settings.dgv_NotificationItems.CurrentCell.RowIndex >= 0 && settings.dgv_NotificationItems.Rows.Count > settings.dgv_NotificationItems.CurrentCell.RowIndex)
                {
                    var cell = settings.dgv_NotificationItems.Rows[settings.dgv_NotificationItems.CurrentCell.RowIndex].Cells["Name"];

                    if (cell?.Value != null) // Check if cell exists and has a value
                        name = cell.Value.ToString();
                }

                const string query = @"
                    SELECT ID, UserEmail 
                    FROM [Settings].NotificationSubscriptions 
                    WHERE NotificationID = @notificationid
                        AND NotificationItem = @notificationitem";

                using (var con = new SqlConnection(Database.cs_Protocol))
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@notificationid", settings.dgv_Notifications.Rows[settings.dgv_Notifications.CurrentCell.RowIndex].Cells["ID"].Value.ToString());
                    cmd.Parameters.AddWithValue("@notificationitem", name);
                    using (var adapter = new SqlDataAdapter(cmd))
                        adapter.Fill(dt);
                }

                settings.dgv_NotificationSubscriptions.DataSource = dt;
                settings.dgv_NotificationSubscriptions.Columns["ID"].Visible = false;
            }

            private static void Fill_NotificationItems_Workoperations(DataGridView dgv)
            {
                var dt = new DataTable();
                const string query = "SELECT Name, Description FROM [Workoperation].Names";

                using (var con = new SqlConnection(Database.cs_Protocol))
                using (var cmd = new SqlCommand(query, con))
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    con.Open();
                    adapter.Fill(dt);
                }

                dgv.DataSource = dt;
                dgv.Columns[0].Visible = false;
            }

            public static class Subscription
            {
                public static void NotifyFirstRun()
                {
                    if (Part.TotalOrdersRun > 1)
                        return;

                    var mailMessage = new MailMessage();
                    using var con = new SqlConnection(Database.cs_Protocol);
                    var query = $@"
                            SELECT * 
                            FROM [Settings].NotificationSubscriptions
                            WHERE NotificationID = 1
                                AND NotificationItem = @notificationitem";
                    con.Open();
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@notificationitem", Order.WorkOperation.ToString());
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var mail = reader["UserEmail"].ToString();
                        mailMessage.To.Add(mail);
                    }

                    if (mailMessage.To.Count > 0)
                        Mail.Send($"Artikelnummer {Order.PartNumber} startades just för första gången och du har valt att få en notis för detta.", 0, mailMessage);
                }
            }
        }






        public class SaveData
        {
            public static void Quickstart_WorkOperation(string workoperation)
            {
                if (string.IsNullOrEmpty(workoperation))
                    return;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                    IF NOT EXISTS (SELECT * FROM Workoperation.QuickStartList WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname) AND WorkoperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation)) 
                        BEGIN
                        INSERT INTO Workoperation.QuickStartList (HostID, WorkoperationID)
                        VALUES 
                            (
                                (SELECT HostID FROM Settings.General WHERE HostName = @hostname),
                                (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation)
                            )
                        END
                        ELSE
                        DELETE FROM Workoperation.QuickStartList WHERE HostID = (SELECT HostID FROM Settings.General WHERE HostName = @hostname) AND WorkoperationID = (SELECT ID FROM Workoperation.Names WHERE Name = @workoperation)";


                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                cmd.Parameters.AddWithValue("@workoperation", workoperation);

                cmd.ExecuteScalar();
            }
            public static void IsComputerOnlyForMeasure(bool value)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = @"
                    IF EXISTS (SELECT * FROM [Settings].General WHERE HostName = @hostname) 
                    BEGIN 
                        UPDATE [Settings].General SET MeasureOnly = @value WHERE HostName = @hostname 
                    END 
                        ELSE INSERT INTO [Settings].General (HostName, MeasureOnly) VALUES (@hostname, @value)";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                cmd.Parameters.AddWithValue("@value", value);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            public static void UPDATE_Setting(string kolumn, Control? ctrl = null, string? text = null)
            {
                var flag = false || ctrl is RadioButton { Checked: true } || ctrl is CheckBox { Checked: true };

                if (string.IsNullOrEmpty(text))
                    text = ctrl?.Text;
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $"UPDATE [Settings].General SET {kolumn} = @value WHERE HostName = @hostname ";


                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                if (ctrl is RadioButton || ctrl is CheckBox)
                    cmd.Parameters.AddWithValue("@value", flag);
                else
                    cmd.Parameters.AddWithValue("@value", text);
                con.Open();

                cmd.ExecuteScalar();
            }
            public static void SaveNewProfile()
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                string query;

                switch (Monitor.Monitor.factory)
                {
                    case Monitor.Monitor.Factory.Godby:
                    case Monitor.Monitor.Factory.Holding:
                        query = Queries.UPDATE_Settings_General_OGO;
                        break;
                    case Monitor.Monitor.Factory.Thailand:
                    case Monitor.Monitor.Factory.ValleyForge:
                        query = Queries.UPDATE_Settings_General_OTH_OVF;
                        break;
                    default:
                        InfoText.Show("Company is missing in DPP, please contact admin.", CustomColors.InfoText_Color.Bad, null);
                        return;
                }

                if (string.IsNullOrEmpty(query))
                    InfoText.Show("Can not save new Profile, please contact Admin.", CustomColors.InfoText_Color.Bad, null);

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                con.Open();
                cmd.ExecuteScalar();
            }
        }

        public class LoadData
        {
            public static string Setting(string column)
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                var query = $@"
                    SELECT {column} 
                    FROM Settings.General 
                    WHERE HostName = @hostname";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);
                var value = cmd.ExecuteScalar();
                return value?.ToString();
            }

            public static void Load_Settings()
            {
                try
                {
                    using var con = new SqlConnection(Database.cs_Protocol);
                    const string query = @"
                        SELECT * FROM [Settings].General
                        WHERE general.HostName = @hostname";

                    using var cmd = new SqlCommand(query, con)
                    {
                        CommandTimeout = 5
                    };

                    ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@hostname", Environment.MachineName);

                    con.Open(); // ⏱️ max 5 sek väntan
                    using var reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        SaveData.SaveNewProfile();
                        _ = Activity.Stop($"Sparar ny profil för dator - {Environment.MachineName}");
                    }

                    while (reader.Read())
                    {
                        MeasuringComputerOnly = bool.Parse(reader["MeasureOnly"].ToString());
                        ProdLine_LoadingPLan = reader["ProdLine_LoadingPLan"].ToString();
                        Tema = reader["Theme"].ToString();
                        LanguageManager.selectedCulture = new CultureInfo($"{reader["CultureInfo"]}");
                    }
                }
                catch (Exception)
                {
                    InfoText.Show(LanguageManager.GetString("errorConnectingDatabase"),
                        CustomColors.InfoText_Color.Bad, "Error!");

                    Application.Exit(); // stäng programmet direkt
                }

                Activity.Stop(Database.cs_Protocol);
            }
        }

       
    }

}