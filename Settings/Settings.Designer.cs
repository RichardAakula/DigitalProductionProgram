using System.ComponentModel;
using System.IO.Ports;
using System.Windows.Forms;

namespace DigitalProductionProgram.Settings
{
    partial class Settings
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            System.Text.ASCIIEncoding asciiEncodingSealed1 = new System.Text.ASCIIEncoding();
            System.Text.DecoderReplacementFallback decoderReplacementFallback1 = new System.Text.DecoderReplacementFallback();
            System.Text.EncoderReplacementFallback encoderReplacementFallback1 = new System.Text.EncoderReplacementFallback();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Settings));
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            folder_Sökväg = new FolderBrowserDialog();
            serialPort1 = new SerialPort(components);
            timer_AddPoints = new System.Windows.Forms.Timer(components);
            page_Measureinstruments = new TabPage();
            tlp_Main = new TableLayoutPanel();
            label_Settings_Info_Measureinstruments = new Label();
            cb_Workoperations_Measureinstruments = new ComboBox();
            panel_Mätdon = new Panel();
            label_Settings_InfoMeasureinstrument_Add = new Label();
            flp_Measureinstruments = new FlowLayoutPanel();
            panel_Used_Mätdon = new Panel();
            label_Settings_InfoMeasureinstrument_Remove = new Label();
            flp_Used_Measureinstruments = new FlowLayoutPanel();
            page_SpecialParts = new TabPage();
            tlp_SpecialParts = new TableLayoutPanel();
            dgv_Parts = new DataGridView();
            label_Settings_Add_Parts_Info = new Label();
            pb_Info_Artiklar = new PictureBox();
            label_Settings_Part_Description_Info = new Label();
            tb_PartNr = new TextBox();
            btn_AddPartNr = new Button();
            btn_DeletePartNr = new Button();
            dgv_Parts_Description = new DataGridView();
            page_Zumbach = new TabPage();
            num_CtrDeleteZumbachMeasurepoints = new NumericUpDown();
            tb_com_ZumbachMessage = new TextBox();
            label_Zumbach_CtrDeleteMeasurepoints = new Label();
            label_Zumbach_Message = new Label();
            lbl_OD = new Label();
            btn_TestZumbach = new Button();
            label_Settings_InfoZumbachMessage = new Label();
            label_Settings_InfoZumbachCtr = new Label();
            label_Settings_InfoBaudRate = new Label();
            cb_com_HandShake = new ComboBox();
            cb_com_Parity = new ComboBox();
            cb_com_StopBits = new ComboBox();
            cb_com_DataBits = new ComboBox();
            cb_com_BaudRate = new ComboBox();
            cb_com_PortName = new ComboBox();
            label_Zumbach_Handshake = new Label();
            label_Zumbach_Parity = new Label();
            label_Zumbach_Stopbits = new Label();
            label_Zumbach_Databits = new Label();
            label_Zumbach_BaudRate = new Label();
            label_Zumbach_PortName = new Label();
            page_General = new TabPage();
            panel_Allmänt = new Panel();
            cb_Language = new ComboBox();
            label_Language = new Label();
            chb_OnlyForMeasurements = new CheckBox();
            tc_Main = new TabControl();
            page_Notifications = new TabPage();
            tlp_Notifications = new TableLayoutPanel();
            label_NotificationItemsInfo = new Label();
            label_NotificationInfo = new Label();
            dgv_Notifications = new DataGridView();
            dgv_NotificationItems = new DataGridView();
            dgv_NotificationSubscriptions = new DataGridView();
            btn_RemoveSubscription = new Button();
            tb_Email = new TextBox();
            label_NotificationSubscriptionsInfo = new Label();
            page_Measureinstruments.SuspendLayout();
            tlp_Main.SuspendLayout();
            panel_Mätdon.SuspendLayout();
            panel_Used_Mätdon.SuspendLayout();
            page_SpecialParts.SuspendLayout();
            tlp_SpecialParts.SuspendLayout();
            ((ISupportInitialize)dgv_Parts).BeginInit();
            ((ISupportInitialize)pb_Info_Artiklar).BeginInit();
            ((ISupportInitialize)dgv_Parts_Description).BeginInit();
            page_Zumbach.SuspendLayout();
            ((ISupportInitialize)num_CtrDeleteZumbachMeasurepoints).BeginInit();
            page_General.SuspendLayout();
            panel_Allmänt.SuspendLayout();
            tc_Main.SuspendLayout();
            page_Notifications.SuspendLayout();
            tlp_Notifications.SuspendLayout();
            ((ISupportInitialize)dgv_Notifications).BeginInit();
            ((ISupportInitialize)dgv_NotificationItems).BeginInit();
            ((ISupportInitialize)dgv_NotificationSubscriptions).BeginInit();
            SuspendLayout();
            // 
            // folder_Sökväg
            // 
            folder_Sökväg.SelectedPath = "K:\\";
            // 
            // serialPort1
            // 
            serialPort1.BaudRate = 9600;
            serialPort1.DataBits = 8;
            serialPort1.DiscardNull = false;
            serialPort1.DtrEnable = false;
           // asciiEncodingSealed1.DecoderFallback = decoderReplacementFallback1;
           // asciiEncodingSealed1.EncoderFallback = encoderReplacementFallback1;
            serialPort1.Encoding = asciiEncodingSealed1;
            serialPort1.Handshake = Handshake.XOnXOff;
            serialPort1.NewLine = "\n";
            serialPort1.Parity = Parity.Even;
            serialPort1.ParityReplace = 63;
            serialPort1.PortName = "COM1";
            serialPort1.ReadBufferSize = 4096;
            serialPort1.ReadTimeout = -1;
            serialPort1.ReceivedBytesThreshold = 1;
            serialPort1.RtsEnable = false;
            serialPort1.StopBits = StopBits.One;
            serialPort1.WriteBufferSize = 2048;
            serialPort1.WriteTimeout = -1;
            // 
            // timer_AddPoints
            // 
            timer_AddPoints.Interval = 10000;
            timer_AddPoints.Tick += Timer_AddPoints_Tick;
            // 
            // page_Measureinstruments
            // 
            page_Measureinstruments.Controls.Add(tlp_Main);
            page_Measureinstruments.Location = new Point(4, 29);
            page_Measureinstruments.Margin = new Padding(4, 3, 4, 3);
            page_Measureinstruments.Name = "page_Measureinstruments";
            page_Measureinstruments.Padding = new Padding(4, 3, 4, 3);
            page_Measureinstruments.Size = new Size(1282, 635);
            page_Measureinstruments.TabIndex = 9;
            page_Measureinstruments.Text = "Mätdon";
            page_Measureinstruments.UseVisualStyleBackColor = true;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(6, 81, 87);
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.53627F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.46373F));
            tlp_Main.Controls.Add(label_Settings_Info_Measureinstruments, 0, 0);
            tlp_Main.Controls.Add(cb_Workoperations_Measureinstruments, 1, 0);
            tlp_Main.Controls.Add(panel_Mätdon, 1, 1);
            tlp_Main.Controls.Add(panel_Used_Mätdon, 2, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(4, 3);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 9.523809F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 90.47619F));
            tlp_Main.Size = new Size(1274, 629);
            tlp_Main.TabIndex = 0;
            // 
            // label_Settings_Info_Measureinstruments
            // 
            label_Settings_Info_Measureinstruments.AutoSize = true;
            label_Settings_Info_Measureinstruments.BackColor = Color.FromArgb(112, 198, 176);
            label_Settings_Info_Measureinstruments.Dock = DockStyle.Top;
            label_Settings_Info_Measureinstruments.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label_Settings_Info_Measureinstruments.ForeColor = Color.FromArgb(81, 85, 91);
            label_Settings_Info_Measureinstruments.Location = new Point(0, 0);
            label_Settings_Info_Measureinstruments.Margin = new Padding(0);
            label_Settings_Info_Measureinstruments.Name = "label_Settings_Info_Measureinstruments";
            tlp_Main.SetRowSpan(label_Settings_Info_Measureinstruments, 2);
            label_Settings_Info_Measureinstruments.Size = new Size(150, 60);
            label_Settings_Info_Measureinstruments.TabIndex = 1;
            label_Settings_Info_Measureinstruments.Text = "Välj först Arbetsoperation och välj sedan vilka Mätdon som tillhör Arbetsoperationen.";
            // 
            // cb_Workoperations_Measureinstruments
            // 
            cb_Workoperations_Measureinstruments.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_Workoperations_Measureinstruments.ForeColor = SystemColors.HotTrack;
            cb_Workoperations_Measureinstruments.FormattingEnabled = true;
            cb_Workoperations_Measureinstruments.Location = new Point(154, 3);
            cb_Workoperations_Measureinstruments.Margin = new Padding(4, 3, 4, 3);
            cb_Workoperations_Measureinstruments.Name = "cb_Workoperations_Measureinstruments";
            cb_Workoperations_Measureinstruments.Size = new Size(308, 23);
            cb_Workoperations_Measureinstruments.TabIndex = 871;
            // 
            // panel_Mätdon
            // 
            panel_Mätdon.BackColor = Color.FromArgb(112, 198, 176);
            panel_Mätdon.Controls.Add(label_Settings_InfoMeasureinstrument_Add);
            panel_Mätdon.Controls.Add(flp_Measureinstruments);
            panel_Mätdon.Dock = DockStyle.Fill;
            panel_Mätdon.Location = new Point(154, 62);
            panel_Mätdon.Margin = new Padding(4, 3, 4, 3);
            panel_Mätdon.Name = "panel_Mätdon";
            panel_Mätdon.Size = new Size(458, 564);
            panel_Mätdon.TabIndex = 874;
            // 
            // label_Settings_InfoMeasureinstrument_Add
            // 
            label_Settings_InfoMeasureinstrument_Add.BackColor = Color.FromArgb(112, 198, 176);
            label_Settings_InfoMeasureinstrument_Add.Dock = DockStyle.Fill;
            label_Settings_InfoMeasureinstrument_Add.Font = new Font("Lucida Sans", 11F, FontStyle.Bold);
            label_Settings_InfoMeasureinstrument_Add.ForeColor = Color.FromArgb(81, 85, 91);
            label_Settings_InfoMeasureinstrument_Add.Location = new Point(0, 0);
            label_Settings_InfoMeasureinstrument_Add.Margin = new Padding(4, 0, 4, 0);
            label_Settings_InfoMeasureinstrument_Add.Name = "label_Settings_InfoMeasureinstrument_Add";
            label_Settings_InfoMeasureinstrument_Add.Padding = new Padding(2, 2, 0, 0);
            label_Settings_InfoMeasureinstrument_Add.Size = new Size(458, 71);
            label_Settings_InfoMeasureinstrument_Add.TabIndex = 1;
            label_Settings_InfoMeasureinstrument_Add.Text = "Klicka på ett Mätdon för att lägga till det till aktiv Arbetsoperation.";
            // 
            // flp_Measureinstruments
            // 
            flp_Measureinstruments.BackColor = Color.FromArgb(63, 115, 140);
            flp_Measureinstruments.Dock = DockStyle.Bottom;
            flp_Measureinstruments.Enabled = false;
            flp_Measureinstruments.FlowDirection = FlowDirection.TopDown;
            flp_Measureinstruments.Location = new Point(0, 71);
            flp_Measureinstruments.Margin = new Padding(4, 3, 4, 3);
            flp_Measureinstruments.Name = "flp_Measureinstruments";
            flp_Measureinstruments.Padding = new Padding(6, 12, 0, 0);
            flp_Measureinstruments.Size = new Size(458, 493);
            flp_Measureinstruments.TabIndex = 872;
            // 
            // panel_Used_Mätdon
            // 
            panel_Used_Mätdon.BackColor = Color.FromArgb(112, 198, 176);
            panel_Used_Mätdon.Controls.Add(label_Settings_InfoMeasureinstrument_Remove);
            panel_Used_Mätdon.Controls.Add(flp_Used_Measureinstruments);
            panel_Used_Mätdon.Dock = DockStyle.Fill;
            panel_Used_Mätdon.Location = new Point(620, 62);
            panel_Used_Mätdon.Margin = new Padding(4, 3, 4, 3);
            panel_Used_Mätdon.Name = "panel_Used_Mätdon";
            panel_Used_Mätdon.Size = new Size(650, 564);
            panel_Used_Mätdon.TabIndex = 875;
            // 
            // label_Settings_InfoMeasureinstrument_Remove
            // 
            label_Settings_InfoMeasureinstrument_Remove.BackColor = Color.FromArgb(112, 198, 176);
            label_Settings_InfoMeasureinstrument_Remove.Dock = DockStyle.Fill;
            label_Settings_InfoMeasureinstrument_Remove.Font = new Font("Lucida Sans", 11F, FontStyle.Bold);
            label_Settings_InfoMeasureinstrument_Remove.ForeColor = Color.FromArgb(81, 85, 91);
            label_Settings_InfoMeasureinstrument_Remove.Location = new Point(0, 0);
            label_Settings_InfoMeasureinstrument_Remove.Margin = new Padding(4, 0, 4, 0);
            label_Settings_InfoMeasureinstrument_Remove.Name = "label_Settings_InfoMeasureinstrument_Remove";
            label_Settings_InfoMeasureinstrument_Remove.Padding = new Padding(2, 2, 0, 0);
            label_Settings_InfoMeasureinstrument_Remove.Size = new Size(650, 71);
            label_Settings_InfoMeasureinstrument_Remove.TabIndex = 2;
            label_Settings_InfoMeasureinstrument_Remove.Text = "Klicka på ett Mätdon för att radera det från aktiv Arbetsoperation.\r\n";
            // 
            // flp_Used_Measureinstruments
            // 
            flp_Used_Measureinstruments.BackColor = Color.FromArgb(63, 115, 140);
            flp_Used_Measureinstruments.Dock = DockStyle.Bottom;
            flp_Used_Measureinstruments.FlowDirection = FlowDirection.TopDown;
            flp_Used_Measureinstruments.Location = new Point(0, 71);
            flp_Used_Measureinstruments.Margin = new Padding(4, 3, 4, 3);
            flp_Used_Measureinstruments.Name = "flp_Used_Measureinstruments";
            flp_Used_Measureinstruments.Size = new Size(650, 493);
            flp_Used_Measureinstruments.TabIndex = 873;
            // 
            // page_SpecialParts
            // 
            page_SpecialParts.Controls.Add(tlp_SpecialParts);
            page_SpecialParts.Location = new Point(4, 29);
            page_SpecialParts.Margin = new Padding(4, 3, 4, 3);
            page_SpecialParts.Name = "page_SpecialParts";
            page_SpecialParts.Padding = new Padding(4, 3, 4, 3);
            page_SpecialParts.Size = new Size(1282, 635);
            page_SpecialParts.TabIndex = 7;
            page_SpecialParts.Text = "Special Artiklar";
            page_SpecialParts.UseVisualStyleBackColor = true;
            // 
            // tlp_SpecialParts
            // 
            tlp_SpecialParts.BackColor = Color.FromArgb(6, 81, 87);
            tlp_SpecialParts.ColumnCount = 4;
            tlp_SpecialParts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.34132F));
            tlp_SpecialParts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42.96407F));
            tlp_SpecialParts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.694611F));
            tlp_SpecialParts.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));
            tlp_SpecialParts.Controls.Add(dgv_Parts, 1, 1);
            tlp_SpecialParts.Controls.Add(label_Settings_Add_Parts_Info, 3, 0);
            tlp_SpecialParts.Controls.Add(pb_Info_Artiklar, 3, 4);
            tlp_SpecialParts.Controls.Add(label_Settings_Part_Description_Info, 0, 0);
            tlp_SpecialParts.Controls.Add(tb_PartNr, 3, 2);
            tlp_SpecialParts.Controls.Add(btn_AddPartNr, 3, 1);
            tlp_SpecialParts.Controls.Add(btn_DeletePartNr, 3, 3);
            tlp_SpecialParts.Controls.Add(dgv_Parts_Description, 0, 1);
            tlp_SpecialParts.Dock = DockStyle.Fill;
            tlp_SpecialParts.Location = new Point(4, 3);
            tlp_SpecialParts.Margin = new Padding(4, 3, 4, 3);
            tlp_SpecialParts.Name = "tlp_SpecialParts";
            tlp_SpecialParts.RowCount = 6;
            tlp_SpecialParts.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlp_SpecialParts.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_SpecialParts.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_SpecialParts.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_SpecialParts.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_SpecialParts.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tlp_SpecialParts.Size = new Size(1274, 629);
            tlp_SpecialParts.TabIndex = 0;
            // 
            // dgv_Parts
            // 
            dgv_Parts.AllowUserToAddRows = false;
            dgv_Parts.AllowUserToDeleteRows = false;
            dgv_Parts.AllowUserToResizeColumns = false;
            dgv_Parts.AllowUserToResizeRows = false;
            dgv_Parts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Parts.BackgroundColor = Color.FromArgb(63, 115, 140);
            dgv_Parts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(183, 220, 233);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(147, 146, 153);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Parts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Parts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_Parts.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_Parts.Dock = DockStyle.Fill;
            dgv_Parts.EnableHeadersVisualStyles = false;
            dgv_Parts.Location = new Point(420, 92);
            dgv_Parts.Margin = new Padding(0);
            dgv_Parts.Name = "dgv_Parts";
            dgv_Parts.RowHeadersVisible = false;
            tlp_SpecialParts.SetRowSpan(dgv_Parts, 5);
            dgv_Parts.Size = new Size(332, 537);
            dgv_Parts.TabIndex = 875;
            // 
            // label_Settings_Add_Parts_Info
            // 
            label_Settings_Add_Parts_Info.BackColor = Color.FromArgb(112, 198, 176);
            label_Settings_Add_Parts_Info.Dock = DockStyle.Fill;
            label_Settings_Add_Parts_Info.Font = new Font("Lucida Sans", 11F, FontStyle.Bold);
            label_Settings_Add_Parts_Info.ForeColor = Color.FromArgb(81, 85, 91);
            label_Settings_Add_Parts_Info.Location = new Point(772, 0);
            label_Settings_Add_Parts_Info.Margin = new Padding(0);
            label_Settings_Add_Parts_Info.Name = "label_Settings_Add_Parts_Info";
            label_Settings_Add_Parts_Info.Size = new Size(502, 92);
            label_Settings_Add_Parts_Info.TabIndex = 871;
            label_Settings_Add_Parts_Info.Text = "Välj först i den högra kolumnen vilken typ av artikelnummer du vill lägga till eller radera.\r\n";
            // 
            // pb_Info_Artiklar
            // 
            pb_Info_Artiklar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pb_Info_Artiklar.BackColor = Color.Transparent;
            pb_Info_Artiklar.BackgroundImage = (Image)resources.GetObject("pb_Info_Artiklar.BackgroundImage");
            pb_Info_Artiklar.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info_Artiklar.Cursor = Cursors.Hand;
            pb_Info_Artiklar.Location = new Point(1229, 201);
            pb_Info_Artiklar.Margin = new Padding(4, 3, 4, 3);
            pb_Info_Artiklar.Name = "pb_Info_Artiklar";
            pb_Info_Artiklar.Size = new Size(41, 28);
            pb_Info_Artiklar.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info_Artiklar.TabIndex = 869;
            pb_Info_Artiklar.TabStop = false;
            // 
            // label_Settings_Part_Description_Info
            // 
            label_Settings_Part_Description_Info.BackColor = Color.FromArgb(112, 198, 176);
            tlp_SpecialParts.SetColumnSpan(label_Settings_Part_Description_Info, 2);
            label_Settings_Part_Description_Info.Dock = DockStyle.Fill;
            label_Settings_Part_Description_Info.Font = new Font("Lucida Sans", 11F, FontStyle.Bold);
            label_Settings_Part_Description_Info.ForeColor = Color.FromArgb(81, 85, 91);
            label_Settings_Part_Description_Info.Location = new Point(0, 0);
            label_Settings_Part_Description_Info.Margin = new Padding(0);
            label_Settings_Part_Description_Info.Name = "label_Settings_Part_Description_Info";
            label_Settings_Part_Description_Info.Size = new Size(752, 92);
            label_Settings_Part_Description_Info.TabIndex = 0;
            label_Settings_Part_Description_Info.Text = "Description";
            // 
            // tb_PartNr
            // 
            tb_PartNr.BackColor = Color.White;
            tb_PartNr.Dock = DockStyle.Left;
            tb_PartNr.Font = new Font("Consolas", 10F);
            tb_PartNr.ForeColor = Color.Black;
            tb_PartNr.Location = new Point(776, 130);
            tb_PartNr.Margin = new Padding(4, 3, 4, 3);
            tb_PartNr.Name = "tb_PartNr";
            tb_PartNr.Size = new Size(198, 23);
            tb_PartNr.TabIndex = 8;
            // 
            // btn_AddPartNr
            // 
            btn_AddPartNr.BackColor = Color.FromArgb(198, 239, 206);
            btn_AddPartNr.Cursor = Cursors.Hand;
            btn_AddPartNr.Dock = DockStyle.Left;
            btn_AddPartNr.FlatAppearance.MouseDownBackColor = Color.FromArgb(118, 169, 126);
            btn_AddPartNr.FlatStyle = FlatStyle.Flat;
            btn_AddPartNr.Font = new Font("Segoe UI", 10F);
            btn_AddPartNr.ForeColor = Color.FromArgb(0, 97, 0);
            btn_AddPartNr.Location = new Point(772, 92);
            btn_AddPartNr.Margin = new Padding(0);
            btn_AddPartNr.Name = "btn_AddPartNr";
            btn_AddPartNr.Size = new Size(202, 35);
            btn_AddPartNr.TabIndex = 872;
            btn_AddPartNr.Text = "Lägg till ArtikelNr";
            btn_AddPartNr.TextAlign = ContentAlignment.TopCenter;
            btn_AddPartNr.UseVisualStyleBackColor = false;
            // 
            // btn_DeletePartNr
            // 
            btn_DeletePartNr.BackColor = Color.FromArgb(255, 199, 206);
            btn_DeletePartNr.Cursor = Cursors.Hand;
            btn_DeletePartNr.Dock = DockStyle.Left;
            btn_DeletePartNr.FlatAppearance.MouseDownBackColor = Color.FromArgb(205, 149, 156);
            btn_DeletePartNr.FlatStyle = FlatStyle.Flat;
            btn_DeletePartNr.Font = new Font("Segoe UI", 10F);
            btn_DeletePartNr.ForeColor = Color.FromArgb(156, 0, 6);
            btn_DeletePartNr.Location = new Point(772, 162);
            btn_DeletePartNr.Margin = new Padding(0);
            btn_DeletePartNr.Name = "btn_DeletePartNr";
            btn_DeletePartNr.Size = new Size(202, 35);
            btn_DeletePartNr.TabIndex = 873;
            btn_DeletePartNr.Text = "Radera ArtikelNr";
            btn_DeletePartNr.TextAlign = ContentAlignment.TopCenter;
            btn_DeletePartNr.UseVisualStyleBackColor = false;
            // 
            // dgv_Parts_Description
            // 
            dgv_Parts_Description.AllowUserToAddRows = false;
            dgv_Parts_Description.AllowUserToDeleteRows = false;
            dgv_Parts_Description.AllowUserToResizeColumns = false;
            dgv_Parts_Description.AllowUserToResizeRows = false;
            dgv_Parts_Description.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Parts_Description.BackgroundColor = Color.FromArgb(63, 115, 140);
            dgv_Parts_Description.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(183, 220, 233);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(147, 146, 153);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_Parts_Description.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_Parts_Description.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgv_Parts_Description.DefaultCellStyle = dataGridViewCellStyle4;
            dgv_Parts_Description.Dock = DockStyle.Fill;
            dgv_Parts_Description.EnableHeadersVisualStyles = false;
            dgv_Parts_Description.Location = new Point(0, 92);
            dgv_Parts_Description.Margin = new Padding(0);
            dgv_Parts_Description.Name = "dgv_Parts_Description";
            dgv_Parts_Description.RowHeadersVisible = false;
            tlp_SpecialParts.SetRowSpan(dgv_Parts_Description, 5);
            dgv_Parts_Description.RowTemplate.Height = 24;
            dgv_Parts_Description.Size = new Size(420, 537);
            dgv_Parts_Description.TabIndex = 874;
            // 
            // page_Zumbach
            // 
            page_Zumbach.BackColor = Color.FromArgb(6, 81, 87);
            page_Zumbach.Controls.Add(num_CtrDeleteZumbachMeasurepoints);
            page_Zumbach.Controls.Add(tb_com_ZumbachMessage);
            page_Zumbach.Controls.Add(label_Zumbach_CtrDeleteMeasurepoints);
            page_Zumbach.Controls.Add(label_Zumbach_Message);
            page_Zumbach.Controls.Add(lbl_OD);
            page_Zumbach.Controls.Add(btn_TestZumbach);
            page_Zumbach.Controls.Add(label_Settings_InfoZumbachMessage);
            page_Zumbach.Controls.Add(label_Settings_InfoZumbachCtr);
            page_Zumbach.Controls.Add(label_Settings_InfoBaudRate);
            page_Zumbach.Controls.Add(cb_com_HandShake);
            page_Zumbach.Controls.Add(cb_com_Parity);
            page_Zumbach.Controls.Add(cb_com_StopBits);
            page_Zumbach.Controls.Add(cb_com_DataBits);
            page_Zumbach.Controls.Add(cb_com_BaudRate);
            page_Zumbach.Controls.Add(cb_com_PortName);
            page_Zumbach.Controls.Add(label_Zumbach_Handshake);
            page_Zumbach.Controls.Add(label_Zumbach_Parity);
            page_Zumbach.Controls.Add(label_Zumbach_Stopbits);
            page_Zumbach.Controls.Add(label_Zumbach_Databits);
            page_Zumbach.Controls.Add(label_Zumbach_BaudRate);
            page_Zumbach.Controls.Add(label_Zumbach_PortName);
            page_Zumbach.Location = new Point(4, 29);
            page_Zumbach.Margin = new Padding(4, 3, 4, 3);
            page_Zumbach.Name = "page_Zumbach";
            page_Zumbach.Padding = new Padding(4, 3, 4, 3);
            page_Zumbach.Size = new Size(1282, 635);
            page_Zumbach.TabIndex = 6;
            page_Zumbach.Text = "Zumbach";
            // 
            // num_CtrDeleteZumbachMeasurepoints
            // 
            num_CtrDeleteZumbachMeasurepoints.Font = new Font("Segoe UI", 11F);
            num_CtrDeleteZumbachMeasurepoints.ForeColor = SystemColors.HotTrack;
            num_CtrDeleteZumbachMeasurepoints.Location = new Point(195, 307);
            num_CtrDeleteZumbachMeasurepoints.Margin = new Padding(4, 3, 4, 3);
            num_CtrDeleteZumbachMeasurepoints.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            num_CtrDeleteZumbachMeasurepoints.Name = "num_CtrDeleteZumbachMeasurepoints";
            num_CtrDeleteZumbachMeasurepoints.Size = new Size(83, 27);
            num_CtrDeleteZumbachMeasurepoints.TabIndex = 871;
            // 
            // tb_com_ZumbachMessage
            // 
            tb_com_ZumbachMessage.Font = new Font("Segoe UI", 9F);
            tb_com_ZumbachMessage.ForeColor = SystemColors.HotTrack;
            tb_com_ZumbachMessage.Location = new Point(174, 212);
            tb_com_ZumbachMessage.Margin = new Padding(4, 3, 4, 3);
            tb_com_ZumbachMessage.Name = "tb_com_ZumbachMessage";
            tb_com_ZumbachMessage.Size = new Size(140, 23);
            tb_com_ZumbachMessage.TabIndex = 18;
            // 
            // label_Zumbach_CtrDeleteMeasurepoints
            // 
            label_Zumbach_CtrDeleteMeasurepoints.AutoSize = true;
            label_Zumbach_CtrDeleteMeasurepoints.Font = new Font("Segoe UI", 10F);
            label_Zumbach_CtrDeleteMeasurepoints.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_CtrDeleteMeasurepoints.Location = new Point(19, 312);
            label_Zumbach_CtrDeleteMeasurepoints.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_CtrDeleteMeasurepoints.Name = "label_Zumbach_CtrDeleteMeasurepoints";
            label_Zumbach_CtrDeleteMeasurepoints.Size = new Size(143, 19);
            label_Zumbach_CtrDeleteMeasurepoints.TabIndex = 17;
            label_Zumbach_CtrDeleteMeasurepoints.Text = "Delete Measurepoints";
            // 
            // label_Zumbach_Message
            // 
            label_Zumbach_Message.AutoSize = true;
            label_Zumbach_Message.Font = new Font("Segoe UI", 10F);
            label_Zumbach_Message.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_Message.Location = new Point(19, 210);
            label_Zumbach_Message.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_Message.Name = "label_Zumbach_Message";
            label_Zumbach_Message.Size = new Size(63, 19);
            label_Zumbach_Message.TabIndex = 17;
            label_Zumbach_Message.Text = "Message";
            // 
            // lbl_OD
            // 
            lbl_OD.BorderStyle = BorderStyle.FixedSingle;
            lbl_OD.Location = new Point(488, 179);
            lbl_OD.Margin = new Padding(4, 0, 4, 0);
            lbl_OD.Name = "lbl_OD";
            lbl_OD.Size = new Size(70, 25);
            lbl_OD.TabIndex = 16;
            lbl_OD.Text = "0,000";
            // 
            // btn_TestZumbach
            // 
            btn_TestZumbach.Font = new Font("Microsoft Sans Serif", 8F);
            btn_TestZumbach.Location = new Point(341, 178);
            btn_TestZumbach.Margin = new Padding(4, 3, 4, 3);
            btn_TestZumbach.Name = "btn_TestZumbach";
            btn_TestZumbach.Size = new Size(120, 27);
            btn_TestZumbach.TabIndex = 15;
            btn_TestZumbach.Text = "Testa Zumbach";
            btn_TestZumbach.UseVisualStyleBackColor = true;
            // 
            // label_Settings_InfoZumbachMessage
            // 
            label_Settings_InfoZumbachMessage.AutoSize = true;
            label_Settings_InfoZumbachMessage.Font = new Font("Segoe UI", 8F);
            label_Settings_InfoZumbachMessage.ForeColor = Color.FromArgb(187, 215, 228);
            label_Settings_InfoZumbachMessage.Location = new Point(336, 219);
            label_Settings_InfoZumbachMessage.Margin = new Padding(4, 0, 4, 0);
            label_Settings_InfoZumbachMessage.Name = "label_Settings_InfoZumbachMessage";
            label_Settings_InfoZumbachMessage.Size = new Size(204, 13);
            label_Settings_InfoZumbachMessage.TabIndex = 14;
            label_Settings_InfoZumbachMessage.Text = "(Standard 'd2000' - För USYS 20 'g210')";
            // 
            // label_Settings_InfoZumbachCtr
            // 
            label_Settings_InfoZumbachCtr.Font = new Font("Segoe UI", 8F);
            label_Settings_InfoZumbachCtr.ForeColor = Color.FromArgb(187, 215, 228);
            label_Settings_InfoZumbachCtr.Location = new Point(313, 306);
            label_Settings_InfoZumbachCtr.Margin = new Padding(4, 0, 4, 0);
            label_Settings_InfoZumbachCtr.Name = "label_Settings_InfoZumbachCtr";
            label_Settings_InfoZumbachCtr.Size = new Size(520, 36);
            label_Settings_InfoZumbachCtr.TabIndex = 14;
            label_Settings_InfoZumbachCtr.Text = "(Anger hur många mätpunkter programmet skall radera efter mätning för att ta bort eventuella felmätningar)";
            // 
            // label_Settings_InfoBaudRate
            // 
            label_Settings_InfoBaudRate.AutoSize = true;
            label_Settings_InfoBaudRate.Font = new Font("Segoe UI", 8F);
            label_Settings_InfoBaudRate.ForeColor = Color.FromArgb(187, 215, 228);
            label_Settings_InfoBaudRate.Location = new Point(336, 53);
            label_Settings_InfoBaudRate.Margin = new Padding(4, 0, 4, 0);
            label_Settings_InfoBaudRate.MaximumSize = new Size(525, 0);
            label_Settings_InfoBaudRate.Name = "label_Settings_InfoBaudRate";
            label_Settings_InfoBaudRate.Size = new Size(446, 13);
            label_Settings_InfoBaudRate.TabIndex = 14;
            label_Settings_InfoBaudRate.Text = "(Om BaudRaten ändras måste oxå draghastigheten ändras. Vid 9600 gäller ca 2m/min)";
            // 
            // cb_com_HandShake
            // 
            cb_com_HandShake.BackColor = SystemColors.ControlLightLight;
            cb_com_HandShake.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_com_HandShake.ForeColor = SystemColors.HotTrack;
            cb_com_HandShake.FormattingEnabled = true;
            cb_com_HandShake.Items.AddRange(new object[] { "None", "XOnXOff", "RequestToSend", "RequestToSendXOnXOff" });
            cb_com_HandShake.Location = new Point(174, 178);
            cb_com_HandShake.Margin = new Padding(4, 3, 4, 3);
            cb_com_HandShake.Name = "cb_com_HandShake";
            cb_com_HandShake.Size = new Size(140, 23);
            cb_com_HandShake.TabIndex = 13;
            // 
            // cb_com_Parity
            // 
            cb_com_Parity.BackColor = SystemColors.ControlLightLight;
            cb_com_Parity.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_com_Parity.ForeColor = SystemColors.HotTrack;
            cb_com_Parity.FormattingEnabled = true;
            cb_com_Parity.Items.AddRange(new object[] { "None", "Even", "Odd", "Mark", "Space" });
            cb_com_Parity.Location = new Point(174, 145);
            cb_com_Parity.Margin = new Padding(4, 3, 4, 3);
            cb_com_Parity.Name = "cb_com_Parity";
            cb_com_Parity.Size = new Size(140, 23);
            cb_com_Parity.TabIndex = 12;
            // 
            // cb_com_StopBits
            // 
            cb_com_StopBits.BackColor = SystemColors.ControlLightLight;
            cb_com_StopBits.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_com_StopBits.ForeColor = SystemColors.HotTrack;
            cb_com_StopBits.FormattingEnabled = true;
            cb_com_StopBits.Items.AddRange(new object[] { "None", "One", "Two", "OnePointFive" });
            cb_com_StopBits.Location = new Point(174, 113);
            cb_com_StopBits.Margin = new Padding(4, 3, 4, 3);
            cb_com_StopBits.Name = "cb_com_StopBits";
            cb_com_StopBits.Size = new Size(140, 23);
            cb_com_StopBits.TabIndex = 11;
            // 
            // cb_com_DataBits
            // 
            cb_com_DataBits.BackColor = SystemColors.ControlLightLight;
            cb_com_DataBits.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_com_DataBits.ForeColor = SystemColors.HotTrack;
            cb_com_DataBits.FormattingEnabled = true;
            cb_com_DataBits.Items.AddRange(new object[] { "7", "8" });
            cb_com_DataBits.Location = new Point(174, 81);
            cb_com_DataBits.Margin = new Padding(4, 3, 4, 3);
            cb_com_DataBits.Name = "cb_com_DataBits";
            cb_com_DataBits.Size = new Size(140, 23);
            cb_com_DataBits.TabIndex = 10;
            // 
            // cb_com_BaudRate
            // 
            cb_com_BaudRate.BackColor = SystemColors.ControlLightLight;
            cb_com_BaudRate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_com_BaudRate.ForeColor = SystemColors.HotTrack;
            cb_com_BaudRate.FormattingEnabled = true;
            cb_com_BaudRate.Items.AddRange(new object[] { "150", "300", "600", "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" });
            cb_com_BaudRate.Location = new Point(174, 48);
            cb_com_BaudRate.Margin = new Padding(4, 3, 4, 3);
            cb_com_BaudRate.Name = "cb_com_BaudRate";
            cb_com_BaudRate.Size = new Size(140, 23);
            cb_com_BaudRate.TabIndex = 9;
            // 
            // cb_com_PortName
            // 
            cb_com_PortName.BackColor = SystemColors.ControlLightLight;
            cb_com_PortName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_com_PortName.ForeColor = SystemColors.HotTrack;
            cb_com_PortName.FormattingEnabled = true;
            cb_com_PortName.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9" });
            cb_com_PortName.Location = new Point(174, 16);
            cb_com_PortName.Margin = new Padding(4, 3, 4, 3);
            cb_com_PortName.Name = "cb_com_PortName";
            cb_com_PortName.Size = new Size(140, 23);
            cb_com_PortName.TabIndex = 8;
            // 
            // label_Zumbach_Handshake
            // 
            label_Zumbach_Handshake.AutoSize = true;
            label_Zumbach_Handshake.Font = new Font("Segoe UI", 10F);
            label_Zumbach_Handshake.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_Handshake.Location = new Point(19, 178);
            label_Zumbach_Handshake.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_Handshake.Name = "label_Zumbach_Handshake";
            label_Zumbach_Handshake.Size = new Size(77, 19);
            label_Zumbach_Handshake.TabIndex = 7;
            label_Zumbach_Handshake.Text = "Handshake";
            // 
            // label_Zumbach_Parity
            // 
            label_Zumbach_Parity.AutoSize = true;
            label_Zumbach_Parity.Font = new Font("Segoe UI", 10F);
            label_Zumbach_Parity.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_Parity.Location = new Point(19, 145);
            label_Zumbach_Parity.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_Parity.Name = "label_Zumbach_Parity";
            label_Zumbach_Parity.Size = new Size(44, 19);
            label_Zumbach_Parity.TabIndex = 6;
            label_Zumbach_Parity.Text = "Parity";
            // 
            // label_Zumbach_Stopbits
            // 
            label_Zumbach_Stopbits.AutoSize = true;
            label_Zumbach_Stopbits.Font = new Font("Segoe UI", 10F);
            label_Zumbach_Stopbits.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_Stopbits.Location = new Point(19, 113);
            label_Zumbach_Stopbits.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_Stopbits.Name = "label_Zumbach_Stopbits";
            label_Zumbach_Stopbits.Size = new Size(59, 19);
            label_Zumbach_Stopbits.TabIndex = 5;
            label_Zumbach_Stopbits.Text = "Stopbits";
            // 
            // label_Zumbach_Databits
            // 
            label_Zumbach_Databits.AutoSize = true;
            label_Zumbach_Databits.Font = new Font("Segoe UI", 10F);
            label_Zumbach_Databits.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_Databits.Location = new Point(19, 81);
            label_Zumbach_Databits.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_Databits.Name = "label_Zumbach_Databits";
            label_Zumbach_Databits.Size = new Size(60, 19);
            label_Zumbach_Databits.TabIndex = 4;
            label_Zumbach_Databits.Text = "Databits";
            // 
            // label_Zumbach_BaudRate
            // 
            label_Zumbach_BaudRate.AutoSize = true;
            label_Zumbach_BaudRate.Font = new Font("Segoe UI", 10F);
            label_Zumbach_BaudRate.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_BaudRate.Location = new Point(19, 48);
            label_Zumbach_BaudRate.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_BaudRate.Name = "label_Zumbach_BaudRate";
            label_Zumbach_BaudRate.Size = new Size(67, 19);
            label_Zumbach_BaudRate.TabIndex = 3;
            label_Zumbach_BaudRate.Text = "BaudRate";
            // 
            // label_Zumbach_PortName
            // 
            label_Zumbach_PortName.AutoSize = true;
            label_Zumbach_PortName.Font = new Font("Segoe UI", 10F);
            label_Zumbach_PortName.ForeColor = Color.FromArgb(187, 215, 228);
            label_Zumbach_PortName.Location = new Point(19, 16);
            label_Zumbach_PortName.Margin = new Padding(4, 0, 4, 0);
            label_Zumbach_PortName.Name = "label_Zumbach_PortName";
            label_Zumbach_PortName.Size = new Size(70, 19);
            label_Zumbach_PortName.TabIndex = 2;
            label_Zumbach_PortName.Text = "PortName";
            // 
            // page_General
            // 
            page_General.BackColor = Color.FromArgb(6, 81, 87);
            page_General.Controls.Add(panel_Allmänt);
            page_General.Location = new Point(4, 29);
            page_General.Margin = new Padding(4, 3, 4, 3);
            page_General.Name = "page_General";
            page_General.Padding = new Padding(4, 3, 4, 3);
            page_General.Size = new Size(1282, 635);
            page_General.TabIndex = 4;
            page_General.Text = "Allmänt";
            // 
            // panel_Allmänt
            // 
            panel_Allmänt.BackColor = Color.FromArgb(63, 115, 140);
            panel_Allmänt.BorderStyle = BorderStyle.Fixed3D;
            panel_Allmänt.Controls.Add(cb_Language);
            panel_Allmänt.Controls.Add(label_Language);
            panel_Allmänt.Controls.Add(chb_OnlyForMeasurements);
            panel_Allmänt.Location = new Point(7, 8);
            panel_Allmänt.Margin = new Padding(4, 3, 4, 3);
            panel_Allmänt.Name = "panel_Allmänt";
            panel_Allmänt.Size = new Size(321, 125);
            panel_Allmänt.TabIndex = 13;
            // 
            // cb_Language
            // 
            cb_Language.BackColor = SystemColors.ControlLightLight;
            cb_Language.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cb_Language.ForeColor = SystemColors.HotTrack;
            cb_Language.FormattingEnabled = true;
            cb_Language.Items.AddRange(new object[] { "Svenska", "English", "ไทย" });
            cb_Language.Location = new Point(8, 69);
            cb_Language.Margin = new Padding(4, 3, 4, 3);
            cb_Language.Name = "cb_Language";
            cb_Language.Size = new Size(222, 23);
            cb_Language.TabIndex = 9;
            // 
            // label_Language
            // 
            label_Language.AutoSize = true;
            label_Language.Font = new Font("Segoe UI", 10F);
            label_Language.ForeColor = Color.FromArgb(239, 228, 177);
            label_Language.Location = new Point(4, 44);
            label_Language.Margin = new Padding(4, 0, 4, 0);
            label_Language.Name = "label_Language";
            label_Language.Size = new Size(43, 19);
            label_Language.TabIndex = 3;
            label_Language.Text = "Språk";
            // 
            // chb_OnlyForMeasurements
            // 
            chb_OnlyForMeasurements.AutoSize = true;
            chb_OnlyForMeasurements.Enabled = false;
            chb_OnlyForMeasurements.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chb_OnlyForMeasurements.ForeColor = Color.FromArgb(239, 228, 177);
            chb_OnlyForMeasurements.Location = new Point(6, 9);
            chb_OnlyForMeasurements.Margin = new Padding(4, 3, 4, 3);
            chb_OnlyForMeasurements.Name = "chb_OnlyForMeasurements";
            chb_OnlyForMeasurements.Size = new Size(236, 19);
            chb_OnlyForMeasurements.TabIndex = 0;
            chb_OnlyForMeasurements.Text = "Använd denna dator endast till mätning";
            chb_OnlyForMeasurements.UseVisualStyleBackColor = true;
            chb_OnlyForMeasurements.Visible = false;
            // 
            // tc_Main
            // 
            tc_Main.Controls.Add(page_General);
            tc_Main.Controls.Add(page_Zumbach);
            tc_Main.Controls.Add(page_SpecialParts);
            tc_Main.Controls.Add(page_Measureinstruments);
            tc_Main.Controls.Add(page_Notifications);
            tc_Main.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tc_Main.Location = new Point(14, 14);
            tc_Main.Margin = new Padding(4, 3, 4, 3);
            tc_Main.Name = "tc_Main";
            tc_Main.SelectedIndex = 0;
            tc_Main.Size = new Size(1290, 668);
            tc_Main.TabIndex = 14;
            tc_Main.Selecting += Page_Selecting;
            // 
            // page_Notifications
            // 
            page_Notifications.BackColor = Color.FromArgb(6, 81, 87);
            page_Notifications.Controls.Add(tlp_Notifications);
            page_Notifications.Location = new Point(4, 29);
            page_Notifications.Margin = new Padding(4, 3, 4, 3);
            page_Notifications.Name = "page_Notifications";
            page_Notifications.Padding = new Padding(4, 3, 4, 3);
            page_Notifications.Size = new Size(1282, 635);
            page_Notifications.TabIndex = 10;
            page_Notifications.Text = "Notisinställningar";
            // 
            // tlp_Notifications
            // 
            tlp_Notifications.ColumnCount = 3;
            tlp_Notifications.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 491F));
            tlp_Notifications.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.34633F));
            tlp_Notifications.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41.65367F));
            tlp_Notifications.Controls.Add(label_NotificationItemsInfo, 1, 2);
            tlp_Notifications.Controls.Add(label_NotificationInfo, 0, 2);
            tlp_Notifications.Controls.Add(dgv_Notifications, 0, 3);
            tlp_Notifications.Controls.Add(dgv_NotificationItems, 1, 3);
            tlp_Notifications.Controls.Add(dgv_NotificationSubscriptions, 2, 3);
            tlp_Notifications.Controls.Add(btn_RemoveSubscription, 2, 0);
            tlp_Notifications.Controls.Add(tb_Email, 2, 1);
            tlp_Notifications.Controls.Add(label_NotificationSubscriptionsInfo, 2, 2);
            tlp_Notifications.Dock = DockStyle.Fill;
            tlp_Notifications.Location = new Point(4, 3);
            tlp_Notifications.Margin = new Padding(4, 3, 4, 3);
            tlp_Notifications.Name = "tlp_Notifications";
            tlp_Notifications.RowCount = 4;
            tlp_Notifications.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tlp_Notifications.RowStyles.Add(new RowStyle(SizeType.Absolute, 31F));
            tlp_Notifications.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
            tlp_Notifications.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Notifications.Size = new Size(1274, 629);
            tlp_Notifications.TabIndex = 876;
            // 
            // label_NotificationItemsInfo
            // 
            label_NotificationItemsInfo.BackColor = Color.FromArgb(112, 198, 176);
            label_NotificationItemsInfo.Dock = DockStyle.Fill;
            label_NotificationItemsInfo.Font = new Font("Lucida Sans", 12F, FontStyle.Bold);
            label_NotificationItemsInfo.ForeColor = Color.FromArgb(81, 85, 91);
            label_NotificationItemsInfo.Location = new Point(492, 70);
            label_NotificationItemsInfo.Margin = new Padding(1, 0, 1, 0);
            label_NotificationItemsInfo.Name = "label_NotificationItemsInfo";
            label_NotificationItemsInfo.Size = new Size(454, 78);
            label_NotificationItemsInfo.TabIndex = 879;
            label_NotificationItemsInfo.Text = "Info";
            label_NotificationItemsInfo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // label_NotificationInfo
            // 
            label_NotificationInfo.BackColor = Color.FromArgb(112, 198, 176);
            label_NotificationInfo.Dock = DockStyle.Fill;
            label_NotificationInfo.Font = new Font("Lucida Sans", 12F, FontStyle.Bold);
            label_NotificationInfo.ForeColor = Color.FromArgb(81, 85, 91);
            label_NotificationInfo.Location = new Point(0, 70);
            label_NotificationInfo.Margin = new Padding(0, 0, 1, 0);
            label_NotificationInfo.Name = "label_NotificationInfo";
            label_NotificationInfo.Size = new Size(490, 78);
            label_NotificationInfo.TabIndex = 878;
            label_NotificationInfo.Text = "Välj typ av Notifiering.";
            label_NotificationInfo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // dgv_Notifications
            // 
            dgv_Notifications.AllowUserToAddRows = false;
            dgv_Notifications.AllowUserToDeleteRows = false;
            dgv_Notifications.AllowUserToResizeColumns = false;
            dgv_Notifications.AllowUserToResizeRows = false;
            dgv_Notifications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_Notifications.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_Notifications.BackgroundColor = Color.FromArgb(63, 115, 140);
            dgv_Notifications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(183, 220, 233);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(147, 146, 153);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            dgv_Notifications.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            dgv_Notifications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgv_Notifications.DefaultCellStyle = dataGridViewCellStyle6;
            dgv_Notifications.Dock = DockStyle.Fill;
            dgv_Notifications.EnableHeadersVisualStyles = false;
            dgv_Notifications.Location = new Point(0, 148);
            dgv_Notifications.Margin = new Padding(0);
            dgv_Notifications.Name = "dgv_Notifications";
            dgv_Notifications.RowHeadersVisible = false;
            dgv_Notifications.RowTemplate.Height = 24;
            dgv_Notifications.Size = new Size(491, 481);
            dgv_Notifications.TabIndex = 875;
            // 
            // dgv_NotificationItems
            // 
            dgv_NotificationItems.AllowUserToAddRows = false;
            dgv_NotificationItems.AllowUserToDeleteRows = false;
            dgv_NotificationItems.AllowUserToResizeColumns = false;
            dgv_NotificationItems.AllowUserToResizeRows = false;
            dgv_NotificationItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_NotificationItems.BackgroundColor = Color.FromArgb(63, 115, 140);
            dgv_NotificationItems.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(183, 220, 233);
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle7.SelectionForeColor = Color.FromArgb(147, 146, 153);
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgv_NotificationItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgv_NotificationItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle8.SelectionForeColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgv_NotificationItems.DefaultCellStyle = dataGridViewCellStyle8;
            dgv_NotificationItems.Dock = DockStyle.Fill;
            dgv_NotificationItems.EnableHeadersVisualStyles = false;
            dgv_NotificationItems.Location = new Point(491, 148);
            dgv_NotificationItems.Margin = new Padding(0);
            dgv_NotificationItems.Name = "dgv_NotificationItems";
            dgv_NotificationItems.RowHeadersVisible = false;
            dgv_NotificationItems.RowTemplate.Height = 24;
            dgv_NotificationItems.Size = new Size(456, 481);
            dgv_NotificationItems.TabIndex = 875;
            // 
            // dgv_NotificationSubscriptions
            // 
            dgv_NotificationSubscriptions.AllowUserToAddRows = false;
            dgv_NotificationSubscriptions.AllowUserToDeleteRows = false;
            dgv_NotificationSubscriptions.AllowUserToResizeColumns = false;
            dgv_NotificationSubscriptions.AllowUserToResizeRows = false;
            dgv_NotificationSubscriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_NotificationSubscriptions.BackgroundColor = Color.FromArgb(63, 115, 140);
            dgv_NotificationSubscriptions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(183, 220, 233);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(81, 85, 92);
            dataGridViewCellStyle9.SelectionForeColor = Color.FromArgb(147, 146, 153);
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgv_NotificationSubscriptions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgv_NotificationSubscriptions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle10.SelectionBackColor = Color.FromArgb(239, 228, 177);
            dataGridViewCellStyle10.SelectionForeColor = Color.FromArgb(63, 115, 140);
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dgv_NotificationSubscriptions.DefaultCellStyle = dataGridViewCellStyle10;
            dgv_NotificationSubscriptions.Dock = DockStyle.Fill;
            dgv_NotificationSubscriptions.EnableHeadersVisualStyles = false;
            dgv_NotificationSubscriptions.Location = new Point(947, 148);
            dgv_NotificationSubscriptions.Margin = new Padding(0);
            dgv_NotificationSubscriptions.Name = "dgv_NotificationSubscriptions";
            dgv_NotificationSubscriptions.RowHeadersVisible = false;
            dgv_NotificationSubscriptions.RowTemplate.Height = 24;
            dgv_NotificationSubscriptions.Size = new Size(327, 481);
            dgv_NotificationSubscriptions.TabIndex = 875;
            // 
            // btn_RemoveSubscription
            // 
            btn_RemoveSubscription.BackColor = Color.FromArgb(255, 199, 206);
            btn_RemoveSubscription.Cursor = Cursors.Hand;
            btn_RemoveSubscription.Dock = DockStyle.Left;
            btn_RemoveSubscription.FlatAppearance.MouseDownBackColor = Color.FromArgb(205, 149, 156);
            btn_RemoveSubscription.FlatStyle = FlatStyle.Flat;
            btn_RemoveSubscription.Font = new Font("Segoe UI", 11F);
            btn_RemoveSubscription.ForeColor = Color.FromArgb(156, 0, 6);
            btn_RemoveSubscription.Location = new Point(947, 0);
            btn_RemoveSubscription.Margin = new Padding(0);
            btn_RemoveSubscription.Name = "btn_RemoveSubscription";
            btn_RemoveSubscription.Size = new Size(140, 39);
            btn_RemoveSubscription.TabIndex = 877;
            btn_RemoveSubscription.Text = "Radera Mail";
            btn_RemoveSubscription.TextAlign = ContentAlignment.TopCenter;
            btn_RemoveSubscription.UseVisualStyleBackColor = false;
            // 
            // tb_Email
            // 
            tb_Email.Location = new Point(947, 39);
            tb_Email.Margin = new Padding(0);
            tb_Email.Name = "tb_Email";
            tb_Email.ReadOnly = true;
            tb_Email.Size = new Size(268, 26);
            tb_Email.TabIndex = 876;
            // 
            // label_NotificationSubscriptionsInfo
            // 
            label_NotificationSubscriptionsInfo.BackColor = Color.FromArgb(112, 198, 176);
            label_NotificationSubscriptionsInfo.Dock = DockStyle.Fill;
            label_NotificationSubscriptionsInfo.Font = new Font("Lucida Sans", 12F, FontStyle.Bold);
            label_NotificationSubscriptionsInfo.ForeColor = Color.FromArgb(81, 85, 91);
            label_NotificationSubscriptionsInfo.Location = new Point(948, 70);
            label_NotificationSubscriptionsInfo.Margin = new Padding(1, 0, 0, 0);
            label_NotificationSubscriptionsInfo.Name = "label_NotificationSubscriptionsInfo";
            label_NotificationSubscriptionsInfo.Size = new Size(326, 78);
            label_NotificationSubscriptionsInfo.TabIndex = 879;
            label_NotificationSubscriptionsInfo.Text = "Lägg till eller ta bort mailadresser för vald notis.";
            label_NotificationSubscriptionsInfo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1345, 750);
            Controls.Add(tc_Main);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MaximumSize = new Size(9330, 5186);
            MinimizeBox = false;
            MinimumSize = new Size(930, 340);
            Name = "Settings";
            Text = "-";
            FormClosed += Settings_FormClosed;
            Load += Inställningar_Load;
            page_Measureinstruments.ResumeLayout(false);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            panel_Mätdon.ResumeLayout(false);
            panel_Used_Mätdon.ResumeLayout(false);
            page_SpecialParts.ResumeLayout(false);
            tlp_SpecialParts.ResumeLayout(false);
            tlp_SpecialParts.PerformLayout();
            ((ISupportInitialize)dgv_Parts).EndInit();
            ((ISupportInitialize)pb_Info_Artiklar).EndInit();
            ((ISupportInitialize)dgv_Parts_Description).EndInit();
            page_Zumbach.ResumeLayout(false);
            page_Zumbach.PerformLayout();
            ((ISupportInitialize)num_CtrDeleteZumbachMeasurepoints).EndInit();
            page_General.ResumeLayout(false);
            panel_Allmänt.ResumeLayout(false);
            panel_Allmänt.PerformLayout();
            tc_Main.ResumeLayout(false);
            page_Notifications.ResumeLayout(false);
            tlp_Notifications.ResumeLayout(false);
            tlp_Notifications.PerformLayout();
            ((ISupportInitialize)dgv_Notifications).EndInit();
            ((ISupportInitialize)dgv_NotificationItems).EndInit();
            ((ISupportInitialize)dgv_NotificationSubscriptions).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private FolderBrowserDialog folder_Sökväg;
        private SerialPort serialPort1;
        private System.Windows.Forms.Timer timer_AddPoints;
        private TabPage page_Measureinstruments;
        private TableLayoutPanel tlp_Main;
        private Label label_Settings_Info_Measureinstruments;
        private ComboBox cb_Workoperations_Measureinstruments;
        private Panel panel_Mätdon;
        private Label label_Settings_InfoMeasureinstrument_Add;
        private FlowLayoutPanel flp_Measureinstruments;
        private Panel panel_Used_Mätdon;
        private Label label_Settings_InfoMeasureinstrument_Remove;
        private FlowLayoutPanel flp_Used_Measureinstruments;
        private TabPage page_SpecialParts;
        private TableLayoutPanel tlp_SpecialParts;
        private DataGridView dgv_Parts;
        private Label label_Settings_Add_Parts_Info;
        private PictureBox pb_Info_Artiklar;
        private Label label_Settings_Part_Description_Info;
        private TextBox tb_PartNr;
        private Button btn_AddPartNr;
        private Button btn_DeletePartNr;
        private DataGridView dgv_Parts_Description;
        private TabPage page_Zumbach;
        private NumericUpDown num_CtrDeleteZumbachMeasurepoints;
        private TextBox tb_com_ZumbachMessage;
        private Label label_Zumbach_CtrDeleteMeasurepoints;
        private Label label_Zumbach_Message;
        private Label lbl_OD;
        private Button btn_TestZumbach;
        private Label label_Settings_InfoZumbachMessage;
        private Label label_Settings_InfoZumbachCtr;
        private Label label_Settings_InfoBaudRate;
        private ComboBox cb_com_HandShake;
        private ComboBox cb_com_Parity;
        private ComboBox cb_com_StopBits;
        private ComboBox cb_com_DataBits;
        private ComboBox cb_com_BaudRate;
        private ComboBox cb_com_PortName;
        private Label label_Zumbach_Handshake;
        private Label label_Zumbach_Parity;
        private Label label_Zumbach_Stopbits;
        private Label label_Zumbach_Databits;
        private Label label_Zumbach_BaudRate;
        private Label label_Zumbach_PortName;
        private TabPage page_General;
        private Panel panel_Allmänt;
        private ComboBox cb_Language;
        private Label label_Language;
        private CheckBox chb_OnlyForMeasurements;
        private TabControl tc_Main;
        private TabPage page_Notifications;
        private TableLayoutPanel tlp_Notifications;
        public DataGridView dgv_Notifications;
        public DataGridView dgv_NotificationItems;
        public DataGridView dgv_NotificationSubscriptions;
        public TextBox tb_Email;
        private Label label_NotificationInfo;
        private Button btn_RemoveSubscription;
        private Label label_NotificationItemsInfo;
        private Label label_NotificationSubscriptionsInfo;
    }
}