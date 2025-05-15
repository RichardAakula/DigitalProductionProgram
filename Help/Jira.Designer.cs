using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DigitalProductionProgram.Övrigt;

namespace DigitalProductionProgram.Help
{
    partial class Jira
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
            this.components = new System.ComponentModel.Container();
            this.label_Info = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Extra_Kommentarer = new System.Windows.Forms.Label();
            this.pb_Info_Material = new System.Windows.Forms.PictureBox();
            this.chb_Material = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Telefonnummer = new System.Windows.Forms.TextBox();
            this.pb_Info_Kontaktperson = new System.Windows.Forms.PictureBox();
            this.label_Kontaktperson = new System.Windows.Forms.Label();
            this.chb_Dragare = new System.Windows.Forms.CheckBox();
            this.label_Tid = new System.Windows.Forms.Label();
            this.pb_Info_Tid = new System.Windows.Forms.PictureBox();
            this.chb_Extruder_Temp = new System.Windows.Forms.CheckBox();
            this.chb_Extruder_Matning = new System.Windows.Forms.CheckBox();
            this.panel_TextBoxes = new System.Windows.Forms.Panel();
            this.label_Info_Kommentarer_Övrigt = new System.Windows.Forms.Label();
            this.tb_Kommentarer = new System.Windows.Forms.TextBox();
            this.tlp_Material = new System.Windows.Forms.TableLayoutPanel();
            this.label_Info_Material_2 = new System.Windows.Forms.Label();
            this.tb_Kommentarer_Material = new System.Windows.Forms.TextBox();
            this.label_Info_Material = new System.Windows.Forms.Label();
            this.flp_Material = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_Verktyg = new System.Windows.Forms.TableLayoutPanel();
            this.label_Info_Kalibrering = new System.Windows.Forms.Label();
            this.label_Info_Hackrör = new System.Windows.Forms.Label();
            this.label_Info_Munstycke = new System.Windows.Forms.Label();
            this.tb_Munstycke = new System.Windows.Forms.TextBox();
            this.tb_Kärn = new System.Windows.Forms.TextBox();
            this.label_Info_Kärn = new System.Windows.Forms.Label();
            this.tb_Hackrör = new System.Windows.Forms.TextBox();
            this.tb_Kalibrering = new System.Windows.Forms.TextBox();
            this.tlp_TextBoxes = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Extruder_Matning_2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Info_1 = new System.Windows.Forms.Label();
            this.label_Info_2 = new System.Windows.Forms.Label();
            this.tb_Belastning = new System.Windows.Forms.TextBox();
            this.tb_Skruvvarv = new System.Windows.Forms.TextBox();
            this.tlp_Extruder_Temp = new System.Windows.Forms.TableLayoutPanel();
            this.tb_Extruder_Temp = new System.Windows.Forms.TextBox();
            this.label_Info_Extruder_Temp = new System.Windows.Forms.Label();
            this.tlp_Extruder_Matning_1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Info_ExtruderMatning = new System.Windows.Forms.Label();
            this.tb_Extruder_Matning = new System.Windows.Forms.TextBox();
            this.tlp_Dragare = new System.Windows.Forms.TableLayoutPanel();
            this.label_Info_Dragare_Hack = new System.Windows.Forms.Label();
            this.tb_Dragare = new System.Windows.Forms.TextBox();
            this.tb_Tid = new System.Windows.Forms.TextBox();
            this.tlp_Kontaktperson = new System.Windows.Forms.TableLayoutPanel();
            this.label_Kontaktperson_Info = new System.Windows.Forms.Label();
            this.tb_Kontaktperson = new System.Windows.Forms.TextBox();
            this.label_Telefonnummer = new System.Windows.Forms.Label();
            this.pb_Info_Verktyg = new System.Windows.Forms.PictureBox();
            this.label_Skicka = new System.Windows.Forms.Label();
            this.label_Avbryt = new System.Windows.Forms.Label();
            this.cm_Namn = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Material)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Kontaktperson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Tid)).BeginInit();
            this.panel_TextBoxes.SuspendLayout();
            this.tlp_Material.SuspendLayout();
            this.tlp_Verktyg.SuspendLayout();
            this.tlp_TextBoxes.SuspendLayout();
            this.tlp_Extruder_Matning_2.SuspendLayout();
            this.tlp_Extruder_Temp.SuspendLayout();
            this.tlp_Extruder_Matning_1.SuspendLayout();
            this.tlp_Dragare.SuspendLayout();
            this.tlp_Kontaktperson.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Verktyg)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.tlp_Main.SetColumnSpan(this.label_Info, 4);
            this.label_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info.Font = new System.Drawing.Font("Cambria", 10F);
            this.label_Info.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info.Location = new System.Drawing.Point(3, 0);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(744, 72);
            this.label_Info.TabIndex = 0;
            this.label_Info.Text = "Hej, \r\nfyll i alla fält som du kan och förklara så noggrant som möjligt vad probl" +
    "emet har varit med denna order.\r\n";
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 4;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 184F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 383F));
            this.tlp_Main.Controls.Add(this.label_Extra_Kommentarer, 0, 9);
            this.tlp_Main.Controls.Add(this.pb_Info_Material, 2, 8);
            this.tlp_Main.Controls.Add(this.chb_Material, 0, 8);
            this.tlp_Main.Controls.Add(this.label1, 0, 7);
            this.tlp_Main.Controls.Add(this.tb_Telefonnummer, 1, 6);
            this.tlp_Main.Controls.Add(this.pb_Info_Kontaktperson, 2, 5);
            this.tlp_Main.Controls.Add(this.label_Kontaktperson, 0, 5);
            this.tlp_Main.Controls.Add(this.chb_Dragare, 0, 4);
            this.tlp_Main.Controls.Add(this.label_Info, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Tid, 0, 1);
            this.tlp_Main.Controls.Add(this.pb_Info_Tid, 2, 1);
            this.tlp_Main.Controls.Add(this.chb_Extruder_Temp, 0, 2);
            this.tlp_Main.Controls.Add(this.chb_Extruder_Matning, 0, 3);
            this.tlp_Main.Controls.Add(this.panel_TextBoxes, 3, 1);
            this.tlp_Main.Controls.Add(this.tlp_Kontaktperson, 1, 5);
            this.tlp_Main.Controls.Add(this.label_Telefonnummer, 0, 6);
            this.tlp_Main.Controls.Add(this.pb_Info_Verktyg, 2, 7);
            this.tlp_Main.Controls.Add(this.label_Skicka, 0, 10);
            this.tlp_Main.Controls.Add(this.label_Avbryt, 1, 10);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.ForeColor = System.Drawing.Color.OliveDrab;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 11;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 187F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlp_Main.Size = new System.Drawing.Size(750, 684);
            this.tlp_Main.TabIndex = 1;
            // 
            // label_Extra_Kommentarer
            // 
            this.label_Extra_Kommentarer.AutoSize = true;
            this.tlp_Main.SetColumnSpan(this.label_Extra_Kommentarer, 2);
            this.label_Extra_Kommentarer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Extra_Kommentarer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Extra_Kommentarer.Location = new System.Drawing.Point(3, 594);
            this.label_Extra_Kommentarer.Name = "label_Extra_Kommentarer";
            this.label_Extra_Kommentarer.Size = new System.Drawing.Size(338, 56);
            this.label_Extra_Kommentarer.TabIndex = 18;
            this.label_Extra_Kommentarer.Text = "Övriga kommentarer";
            this.label_Extra_Kommentarer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pb_Info_Material
            // 
            //this.pb_Info_Material.BackgroundImage = global::DigitalProductionProgram.Properties.Resources.Info;
            this.pb_Info_Material.BackgroundImage = Image.FromStream(Pictures.Icons.Info);
            this.pb_Info_Material.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_Material.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_Material.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_Info_Material.Location = new System.Drawing.Point(344, 407);
            this.pb_Info_Material.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Info_Material.Name = "pb_Info_Material";
            this.pb_Info_Material.Size = new System.Drawing.Size(23, 23);
            this.pb_Info_Material.TabIndex = 17;
            this.pb_Info_Material.TabStop = false;
            this.pb_Info_Material.Click += new System.EventHandler(this.pb_Info_Material_Click);
            // 
            // chb_Material
            // 
            this.chb_Material.AutoSize = true;
            this.tlp_Main.SetColumnSpan(this.chb_Material, 2);
            this.chb_Material.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_Material.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chb_Material.Location = new System.Drawing.Point(3, 410);
            this.chb_Material.Name = "chb_Material";
            this.chb_Material.Size = new System.Drawing.Size(338, 20);
            this.chb_Material.TabIndex = 14;
            this.chb_Material.Text = "Har det varit problem pga materialet?";
            this.chb_Material.UseVisualStyleBackColor = true;
            this.chb_Material.CheckedChanged += new System.EventHandler(this.chb_Material_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tlp_Main.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label1.Location = new System.Drawing.Point(3, 316);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 91);
            this.label1.TabIndex = 13;
            this.label1.Text = "Uppmätta mått på verktyg/utrustning?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Telefonnummer
            // 
            this.tb_Telefonnummer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Telefonnummer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tb_Telefonnummer.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Telefonnummer.Location = new System.Drawing.Point(187, 297);
            this.tb_Telefonnummer.Name = "tb_Telefonnummer";
            this.tb_Telefonnummer.Size = new System.Drawing.Size(154, 16);
            this.tb_Telefonnummer.TabIndex = 2;
            // 
            // pb_Info_Kontaktperson
            // 
            this.pb_Info_Kontaktperson.BackgroundImage = Image.FromStream(Pictures.Icons.Info);
            this.pb_Info_Kontaktperson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_Kontaktperson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_Kontaktperson.Location = new System.Drawing.Point(344, 214);
            this.pb_Info_Kontaktperson.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Info_Kontaktperson.Name = "pb_Info_Kontaktperson";
            this.pb_Info_Kontaktperson.Size = new System.Drawing.Size(19, 18);
            this.pb_Info_Kontaktperson.TabIndex = 11;
            this.pb_Info_Kontaktperson.TabStop = false;
            this.pb_Info_Kontaktperson.Click += new System.EventHandler(this.pb_Info_Kontaktperson_Click);
            // 
            // label_Kontaktperson
            // 
            this.label_Kontaktperson.AutoSize = true;
            this.label_Kontaktperson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kontaktperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Kontaktperson.Location = new System.Drawing.Point(3, 214);
            this.label_Kontaktperson.Name = "label_Kontaktperson";
            this.label_Kontaktperson.Size = new System.Drawing.Size(178, 59);
            this.label_Kontaktperson.TabIndex = 9;
            this.label_Kontaktperson.Text = "Vem är kontaktperson för denna rapport?";
            this.label_Kontaktperson.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // chb_Dragare
            // 
            this.chb_Dragare.AutoSize = true;
            this.chb_Dragare.Checked = true;
            this.chb_Dragare.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlp_Main.SetColumnSpan(this.chb_Dragare, 2);
            this.chb_Dragare.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_Dragare.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chb_Dragare.Location = new System.Drawing.Point(3, 167);
            this.chb_Dragare.Name = "chb_Dragare";
            this.chb_Dragare.Size = new System.Drawing.Size(338, 20);
            this.chb_Dragare.TabIndex = 6;
            this.chb_Dragare.Text = "Har det varit problem med dragaren/hacken?";
            this.chb_Dragare.UseVisualStyleBackColor = true;
            this.chb_Dragare.CheckedChanged += new System.EventHandler(this.chb_Dragare_CheckedChanged);
            // 
            // label_Tid
            // 
            this.label_Tid.AutoSize = true;
            this.tlp_Main.SetColumnSpan(this.label_Tid, 2);
            this.label_Tid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Tid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Tid.Location = new System.Drawing.Point(3, 72);
            this.label_Tid.Name = "label_Tid";
            this.label_Tid.Size = new System.Drawing.Size(338, 22);
            this.label_Tid.TabIndex = 1;
            this.label_Tid.Text = "Hur mycket tid har du/ni satt på denna order?";
            this.label_Tid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pb_Info_Tid
            // 
            this.pb_Info_Tid.BackgroundImage = Image.FromStream(Pictures.Icons.Info);
            this.pb_Info_Tid.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_Tid.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_Tid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Info_Tid.Location = new System.Drawing.Point(344, 72);
            this.pb_Info_Tid.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Info_Tid.Name = "pb_Info_Tid";
            this.pb_Info_Tid.Size = new System.Drawing.Size(23, 22);
            this.pb_Info_Tid.TabIndex = 3;
            this.pb_Info_Tid.TabStop = false;
            this.pb_Info_Tid.Click += new System.EventHandler(this.pb_Info_Tid_Click);
            // 
            // chb_Extruder_Temp
            // 
            this.chb_Extruder_Temp.AutoSize = true;
            this.chb_Extruder_Temp.Checked = true;
            this.chb_Extruder_Temp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlp_Main.SetColumnSpan(this.chb_Extruder_Temp, 2);
            this.chb_Extruder_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Extruder_Temp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chb_Extruder_Temp.Location = new System.Drawing.Point(3, 97);
            this.chb_Extruder_Temp.Name = "chb_Extruder_Temp";
            this.chb_Extruder_Temp.Size = new System.Drawing.Size(338, 29);
            this.chb_Extruder_Temp.TabIndex = 4;
            this.chb_Extruder_Temp.Text = "Har det varit problem med extruderns temperaturer?";
            this.chb_Extruder_Temp.UseVisualStyleBackColor = true;
            this.chb_Extruder_Temp.CheckedChanged += new System.EventHandler(this.chb_Extruder_Temp_CheckedChanged);
            // 
            // chb_Extruder_Matning
            // 
            this.chb_Extruder_Matning.AutoSize = true;
            this.chb_Extruder_Matning.Checked = true;
            this.chb_Extruder_Matning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tlp_Main.SetColumnSpan(this.chb_Extruder_Matning, 2);
            this.chb_Extruder_Matning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Extruder_Matning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.chb_Extruder_Matning.Location = new System.Drawing.Point(3, 132);
            this.chb_Extruder_Matning.Name = "chb_Extruder_Matning";
            this.chb_Extruder_Matning.Size = new System.Drawing.Size(338, 29);
            this.chb_Extruder_Matning.TabIndex = 4;
            this.chb_Extruder_Matning.Text = "Har det varit problem med extruderns matning?";
            this.chb_Extruder_Matning.UseVisualStyleBackColor = true;
            this.chb_Extruder_Matning.CheckedChanged += new System.EventHandler(this.chb_Extryder_Matning_CheckedChanged);
            // 
            // panel_TextBoxes
            // 
            this.panel_TextBoxes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel_TextBoxes.Controls.Add(this.label_Info_Kommentarer_Övrigt);
            this.panel_TextBoxes.Controls.Add(this.tb_Kommentarer);
            this.panel_TextBoxes.Controls.Add(this.tlp_Material);
            this.panel_TextBoxes.Controls.Add(this.tlp_Verktyg);
            this.panel_TextBoxes.Controls.Add(this.tlp_TextBoxes);
            this.panel_TextBoxes.Controls.Add(this.tb_Tid);
            this.panel_TextBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TextBoxes.Location = new System.Drawing.Point(370, 75);
            this.panel_TextBoxes.Name = "panel_TextBoxes";
            this.tlp_Main.SetRowSpan(this.panel_TextBoxes, 10);
            this.panel_TextBoxes.Size = new System.Drawing.Size(377, 606);
            this.panel_TextBoxes.TabIndex = 8;
            // 
            // label_Info_Kommentarer_Övrigt
            // 
            this.label_Info_Kommentarer_Övrigt.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Kommentarer_Övrigt.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Kommentarer_Övrigt.Location = new System.Drawing.Point(3, 507);
            this.label_Info_Kommentarer_Övrigt.Name = "label_Info_Kommentarer_Övrigt";
            this.label_Info_Kommentarer_Övrigt.Size = new System.Drawing.Size(371, 31);
            this.label_Info_Kommentarer_Övrigt.TabIndex = 4;
            this.label_Info_Kommentarer_Övrigt.Text = "Fyll i övrig information om inget av ovanstående passar in på problemet med körni" +
    "ngen.\r\n";
            // 
            // tb_Kommentarer
            // 
            this.tb_Kommentarer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Kommentarer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Kommentarer.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Kommentarer.ForeColor = System.Drawing.Color.White;
            this.tb_Kommentarer.Location = new System.Drawing.Point(3, 540);
            this.tb_Kommentarer.Multiline = true;
            this.tb_Kommentarer.Name = "tb_Kommentarer";
            this.tb_Kommentarer.Size = new System.Drawing.Size(363, 62);
            this.tb_Kommentarer.TabIndex = 11;
            // 
            // tlp_Material
            // 
            this.tlp_Material.ColumnCount = 1;
            this.tlp_Material.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Material.Controls.Add(this.label_Info_Material_2, 0, 2);
            this.tlp_Material.Controls.Add(this.tb_Kommentarer_Material, 0, 3);
            this.tlp_Material.Controls.Add(this.label_Info_Material, 0, 0);
            this.tlp_Material.Controls.Add(this.flp_Material, 0, 1);
            this.tlp_Material.Location = new System.Drawing.Point(0, 339);
            this.tlp_Material.Name = "tlp_Material";
            this.tlp_Material.RowCount = 4;
            this.tlp_Material.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Material.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Material.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Material.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Material.Size = new System.Drawing.Size(369, 165);
            this.tlp_Material.TabIndex = 10;
            this.tlp_Material.Visible = false;
            // 
            // label_Info_Material_2
            // 
            this.label_Info_Material_2.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Material_2.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Material_2.Location = new System.Drawing.Point(3, 82);
            this.label_Info_Material_2.Name = "label_Info_Material_2";
            this.label_Info_Material_2.Size = new System.Drawing.Size(363, 19);
            this.label_Info_Material_2.TabIndex = 4;
            this.label_Info_Material_2.Text = "Fyll i en kommentar om vad som varit problemet med materialet.";
            // 
            // tb_Kommentarer_Material
            // 
            this.tb_Kommentarer_Material.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Kommentarer_Material.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Kommentarer_Material.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Kommentarer_Material.ForeColor = System.Drawing.Color.White;
            this.tb_Kommentarer_Material.Location = new System.Drawing.Point(3, 105);
            this.tb_Kommentarer_Material.Multiline = true;
            this.tb_Kommentarer_Material.Name = "tb_Kommentarer_Material";
            this.tb_Kommentarer_Material.Size = new System.Drawing.Size(363, 57);
            this.tb_Kommentarer_Material.TabIndex = 11;
            // 
            // label_Info_Material
            // 
            this.label_Info_Material.AutoSize = true;
            this.label_Info_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Material.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Material.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Material.Location = new System.Drawing.Point(3, 0);
            this.label_Info_Material.Name = "label_Info_Material";
            this.label_Info_Material.Size = new System.Drawing.Size(363, 20);
            this.label_Info_Material.TabIndex = 2;
            this.label_Info_Material.Text = "Kryssa i materialen du haft problem med";
            this.label_Info_Material.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flp_Material
            // 
            this.flp_Material.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Material.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Material.Location = new System.Drawing.Point(3, 23);
            this.flp_Material.Name = "flp_Material";
            this.flp_Material.Size = new System.Drawing.Size(363, 56);
            this.flp_Material.TabIndex = 3;
            // 
            // tlp_Verktyg
            // 
            this.tlp_Verktyg.ColumnCount = 2;
            this.tlp_Verktyg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Verktyg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Verktyg.Controls.Add(this.label_Info_Kalibrering, 1, 2);
            this.tlp_Verktyg.Controls.Add(this.label_Info_Hackrör, 0, 2);
            this.tlp_Verktyg.Controls.Add(this.label_Info_Munstycke, 0, 0);
            this.tlp_Verktyg.Controls.Add(this.tb_Munstycke, 0, 1);
            this.tlp_Verktyg.Controls.Add(this.tb_Kärn, 1, 1);
            this.tlp_Verktyg.Controls.Add(this.label_Info_Kärn, 1, 0);
            this.tlp_Verktyg.Controls.Add(this.tb_Hackrör, 0, 3);
            this.tlp_Verktyg.Controls.Add(this.tb_Kalibrering, 1, 3);
            this.tlp_Verktyg.Location = new System.Drawing.Point(0, 243);
            this.tlp_Verktyg.Name = "tlp_Verktyg";
            this.tlp_Verktyg.RowCount = 4;
            this.tlp_Verktyg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Verktyg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Verktyg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tlp_Verktyg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Verktyg.Size = new System.Drawing.Size(153, 90);
            this.tlp_Verktyg.TabIndex = 9;
            // 
            // label_Info_Kalibrering
            // 
            this.label_Info_Kalibrering.AutoSize = true;
            this.label_Info_Kalibrering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Kalibrering.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Kalibrering.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Kalibrering.Location = new System.Drawing.Point(79, 48);
            this.label_Info_Kalibrering.Name = "label_Info_Kalibrering";
            this.label_Info_Kalibrering.Size = new System.Drawing.Size(71, 13);
            this.label_Info_Kalibrering.TabIndex = 10;
            this.label_Info_Kalibrering.Text = "Kalibrering";
            this.label_Info_Kalibrering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Info_Hackrör
            // 
            this.label_Info_Hackrör.AutoSize = true;
            this.label_Info_Hackrör.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Hackrör.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Hackrör.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Hackrör.Location = new System.Drawing.Point(3, 48);
            this.label_Info_Hackrör.Name = "label_Info_Hackrör";
            this.label_Info_Hackrör.Size = new System.Drawing.Size(70, 13);
            this.label_Info_Hackrör.TabIndex = 9;
            this.label_Info_Hackrör.Text = "Hackrör";
            this.label_Info_Hackrör.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Info_Munstycke
            // 
            this.label_Info_Munstycke.AutoSize = true;
            this.label_Info_Munstycke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Munstycke.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Munstycke.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Munstycke.Location = new System.Drawing.Point(3, 0);
            this.label_Info_Munstycke.Name = "label_Info_Munstycke";
            this.label_Info_Munstycke.Size = new System.Drawing.Size(70, 20);
            this.label_Info_Munstycke.TabIndex = 1;
            this.label_Info_Munstycke.Text = "Munstycke";
            this.label_Info_Munstycke.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Munstycke
            // 
            this.tb_Munstycke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Munstycke.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Munstycke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Munstycke.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Munstycke.ForeColor = System.Drawing.Color.White;
            this.tb_Munstycke.Location = new System.Drawing.Point(3, 23);
            this.tb_Munstycke.Name = "tb_Munstycke";
            this.tb_Munstycke.Size = new System.Drawing.Size(70, 23);
            this.tb_Munstycke.TabIndex = 8;
            this.tb_Munstycke.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Kärn
            // 
            this.tb_Kärn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Kärn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Kärn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Kärn.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Kärn.ForeColor = System.Drawing.Color.White;
            this.tb_Kärn.Location = new System.Drawing.Point(79, 23);
            this.tb_Kärn.Name = "tb_Kärn";
            this.tb_Kärn.Size = new System.Drawing.Size(71, 23);
            this.tb_Kärn.TabIndex = 8;
            this.tb_Kärn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Info_Kärn
            // 
            this.label_Info_Kärn.AutoSize = true;
            this.label_Info_Kärn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Kärn.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Kärn.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Kärn.Location = new System.Drawing.Point(79, 0);
            this.label_Info_Kärn.Name = "label_Info_Kärn";
            this.label_Info_Kärn.Size = new System.Drawing.Size(71, 20);
            this.label_Info_Kärn.TabIndex = 1;
            this.label_Info_Kärn.Text = "Kärn";
            this.label_Info_Kärn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_Hackrör
            // 
            this.tb_Hackrör.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Hackrör.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Hackrör.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Hackrör.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Hackrör.ForeColor = System.Drawing.Color.White;
            this.tb_Hackrör.Location = new System.Drawing.Point(3, 64);
            this.tb_Hackrör.Name = "tb_Hackrör";
            this.tb_Hackrör.Size = new System.Drawing.Size(70, 23);
            this.tb_Hackrör.TabIndex = 8;
            this.tb_Hackrör.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Kalibrering
            // 
            this.tb_Kalibrering.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Kalibrering.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Kalibrering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Kalibrering.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Kalibrering.ForeColor = System.Drawing.Color.White;
            this.tb_Kalibrering.Location = new System.Drawing.Point(79, 64);
            this.tb_Kalibrering.Name = "tb_Kalibrering";
            this.tb_Kalibrering.Size = new System.Drawing.Size(71, 23);
            this.tb_Kalibrering.TabIndex = 8;
            this.tb_Kalibrering.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlp_TextBoxes
            // 
            this.tlp_TextBoxes.ColumnCount = 2;
            this.tlp_TextBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.21762F));
            this.tlp_TextBoxes.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.78238F));
            this.tlp_TextBoxes.Controls.Add(this.tlp_Extruder_Matning_2, 1, 1);
            this.tlp_TextBoxes.Controls.Add(this.tlp_Extruder_Temp, 0, 0);
            this.tlp_TextBoxes.Controls.Add(this.tlp_Extruder_Matning_1, 0, 1);
            this.tlp_TextBoxes.Controls.Add(this.tlp_Dragare, 0, 2);
            this.tlp_TextBoxes.Location = new System.Drawing.Point(0, 19);
            this.tlp_TextBoxes.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_TextBoxes.Name = "tlp_TextBoxes";
            this.tlp_TextBoxes.RowCount = 3;
            this.tlp_TextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_TextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_TextBoxes.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_TextBoxes.Size = new System.Drawing.Size(369, 221);
            this.tlp_TextBoxes.TabIndex = 7;
            // 
            // tlp_Extruder_Matning_2
            // 
            this.tlp_Extruder_Matning_2.ColumnCount = 2;
            this.tlp_Extruder_Matning_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Extruder_Matning_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Extruder_Matning_2.Controls.Add(this.label_Info_1, 0, 0);
            this.tlp_Extruder_Matning_2.Controls.Add(this.label_Info_2, 1, 0);
            this.tlp_Extruder_Matning_2.Controls.Add(this.tb_Belastning, 0, 1);
            this.tlp_Extruder_Matning_2.Controls.Add(this.tb_Skruvvarv, 1, 1);
            this.tlp_Extruder_Matning_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Extruder_Matning_2.Location = new System.Drawing.Point(207, 73);
            this.tlp_Extruder_Matning_2.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Extruder_Matning_2.Name = "tlp_Extruder_Matning_2";
            this.tlp_Extruder_Matning_2.RowCount = 2;
            this.tlp_Extruder_Matning_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlp_Extruder_Matning_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp_Extruder_Matning_2.Size = new System.Drawing.Size(162, 73);
            this.tlp_Extruder_Matning_2.TabIndex = 3;
            // 
            // label_Info_1
            // 
            this.label_Info_1.AutoSize = true;
            this.label_Info_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_1.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_1.Location = new System.Drawing.Point(3, 0);
            this.label_Info_1.Name = "label_Info_1";
            this.label_Info_1.Size = new System.Drawing.Size(75, 16);
            this.label_Info_1.TabIndex = 0;
            this.label_Info_1.Text = "Belastning";
            // 
            // label_Info_2
            // 
            this.label_Info_2.AutoSize = true;
            this.label_Info_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_2.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_2.Location = new System.Drawing.Point(84, 0);
            this.label_Info_2.Name = "label_Info_2";
            this.label_Info_2.Size = new System.Drawing.Size(75, 16);
            this.label_Info_2.TabIndex = 0;
            this.label_Info_2.Text = "Skruvvarv";
            // 
            // tb_Belastning
            // 
            this.tb_Belastning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Belastning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Belastning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Belastning.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Belastning.ForeColor = System.Drawing.Color.White;
            this.tb_Belastning.Location = new System.Drawing.Point(3, 19);
            this.tb_Belastning.Name = "tb_Belastning";
            this.tb_Belastning.Size = new System.Drawing.Size(75, 23);
            this.tb_Belastning.TabIndex = 1;
            this.tb_Belastning.Text = "xx - xx";
            this.tb_Belastning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Skruvvarv
            // 
            this.tb_Skruvvarv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Skruvvarv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Skruvvarv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Skruvvarv.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Skruvvarv.ForeColor = System.Drawing.Color.White;
            this.tb_Skruvvarv.Location = new System.Drawing.Point(84, 19);
            this.tb_Skruvvarv.Name = "tb_Skruvvarv";
            this.tb_Skruvvarv.Size = new System.Drawing.Size(75, 23);
            this.tb_Skruvvarv.TabIndex = 2;
            this.tb_Skruvvarv.Text = "xx - xx";
            this.tb_Skruvvarv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tlp_Extruder_Temp
            // 
            this.tlp_Extruder_Temp.ColumnCount = 1;
            this.tlp_Extruder_Temp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Extruder_Temp.Controls.Add(this.tb_Extruder_Temp, 0, 1);
            this.tlp_Extruder_Temp.Controls.Add(this.label_Info_Extruder_Temp, 0, 0);
            this.tlp_Extruder_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Extruder_Temp.Location = new System.Drawing.Point(0, 0);
            this.tlp_Extruder_Temp.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Extruder_Temp.Name = "tlp_Extruder_Temp";
            this.tlp_Extruder_Temp.RowCount = 2;
            this.tlp_Extruder_Temp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Extruder_Temp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Extruder_Temp.Size = new System.Drawing.Size(207, 73);
            this.tlp_Extruder_Temp.TabIndex = 4;
            // 
            // tb_Extruder_Temp
            // 
            this.tb_Extruder_Temp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Extruder_Temp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Extruder_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Extruder_Temp.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Extruder_Temp.ForeColor = System.Drawing.Color.White;
            this.tb_Extruder_Temp.Location = new System.Drawing.Point(0, 20);
            this.tb_Extruder_Temp.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Extruder_Temp.Multiline = true;
            this.tb_Extruder_Temp.Name = "tb_Extruder_Temp";
            this.tb_Extruder_Temp.Size = new System.Drawing.Size(207, 53);
            this.tb_Extruder_Temp.TabIndex = 0;
            this.tb_Extruder_Temp.Text = "Skriv här vilken zon som har problem samt hur mycket den ändrar i temperatur.";
            this.tb_Extruder_Temp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Extruder_Temp_KeyDown);
            // 
            // label_Info_Extruder_Temp
            // 
            this.label_Info_Extruder_Temp.AutoSize = true;
            this.label_Info_Extruder_Temp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Extruder_Temp.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Extruder_Temp.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Extruder_Temp.Location = new System.Drawing.Point(3, 0);
            this.label_Info_Extruder_Temp.Name = "label_Info_Extruder_Temp";
            this.label_Info_Extruder_Temp.Size = new System.Drawing.Size(201, 20);
            this.label_Info_Extruder_Temp.TabIndex = 1;
            this.label_Info_Extruder_Temp.Text = "Extruder temperaturer";
            // 
            // tlp_Extruder_Matning_1
            // 
            this.tlp_Extruder_Matning_1.ColumnCount = 1;
            this.tlp_Extruder_Matning_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Extruder_Matning_1.Controls.Add(this.label_Info_ExtruderMatning, 0, 0);
            this.tlp_Extruder_Matning_1.Controls.Add(this.tb_Extruder_Matning, 0, 1);
            this.tlp_Extruder_Matning_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Extruder_Matning_1.Location = new System.Drawing.Point(0, 73);
            this.tlp_Extruder_Matning_1.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Extruder_Matning_1.Name = "tlp_Extruder_Matning_1";
            this.tlp_Extruder_Matning_1.RowCount = 2;
            this.tlp_Extruder_Matning_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Extruder_Matning_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Extruder_Matning_1.Size = new System.Drawing.Size(207, 73);
            this.tlp_Extruder_Matning_1.TabIndex = 5;
            // 
            // label_Info_ExtruderMatning
            // 
            this.label_Info_ExtruderMatning.AutoSize = true;
            this.label_Info_ExtruderMatning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_ExtruderMatning.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_ExtruderMatning.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_ExtruderMatning.Location = new System.Drawing.Point(3, 0);
            this.label_Info_ExtruderMatning.Name = "label_Info_ExtruderMatning";
            this.label_Info_ExtruderMatning.Size = new System.Drawing.Size(201, 20);
            this.label_Info_ExtruderMatning.TabIndex = 1;
            this.label_Info_ExtruderMatning.Text = "Extruder matning";
            // 
            // tb_Extruder_Matning
            // 
            this.tb_Extruder_Matning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Extruder_Matning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Extruder_Matning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Extruder_Matning.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Extruder_Matning.ForeColor = System.Drawing.Color.White;
            this.tb_Extruder_Matning.Location = new System.Drawing.Point(0, 20);
            this.tb_Extruder_Matning.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Extruder_Matning.Multiline = true;
            this.tb_Extruder_Matning.Name = "tb_Extruder_Matning";
            this.tb_Extruder_Matning.Size = new System.Drawing.Size(207, 53);
            this.tb_Extruder_Matning.TabIndex = 1;
            this.tb_Extruder_Matning.Text = "Skriv här hur det har varit problem med extruderns matning. Samt fyll i variation" +
    "en till höger.";
            this.tb_Extruder_Matning.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Extruder_Matning_KeyDown);
            // 
            // tlp_Dragare
            // 
            this.tlp_Dragare.ColumnCount = 1;
            this.tlp_Dragare.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Dragare.Controls.Add(this.label_Info_Dragare_Hack, 0, 0);
            this.tlp_Dragare.Controls.Add(this.tb_Dragare, 0, 1);
            this.tlp_Dragare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Dragare.Location = new System.Drawing.Point(0, 146);
            this.tlp_Dragare.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Dragare.Name = "tlp_Dragare";
            this.tlp_Dragare.RowCount = 2;
            this.tlp_Dragare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Dragare.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Dragare.Size = new System.Drawing.Size(207, 75);
            this.tlp_Dragare.TabIndex = 6;
            // 
            // label_Info_Dragare_Hack
            // 
            this.label_Info_Dragare_Hack.AutoSize = true;
            this.label_Info_Dragare_Hack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_Dragare_Hack.Font = new System.Drawing.Font("Cambria", 9F);
            this.label_Info_Dragare_Hack.ForeColor = System.Drawing.Color.Gray;
            this.label_Info_Dragare_Hack.Location = new System.Drawing.Point(3, 0);
            this.label_Info_Dragare_Hack.Name = "label_Info_Dragare_Hack";
            this.label_Info_Dragare_Hack.Size = new System.Drawing.Size(201, 20);
            this.label_Info_Dragare_Hack.TabIndex = 1;
            this.label_Info_Dragare_Hack.Text = "Dragare / Hack";
            // 
            // tb_Dragare
            // 
            this.tb_Dragare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Dragare.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_Dragare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Dragare.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Dragare.ForeColor = System.Drawing.Color.White;
            this.tb_Dragare.Location = new System.Drawing.Point(0, 20);
            this.tb_Dragare.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Dragare.Multiline = true;
            this.tb_Dragare.Name = "tb_Dragare";
            this.tb_Dragare.Size = new System.Drawing.Size(207, 55);
            this.tb_Dragare.TabIndex = 2;
            this.tb_Dragare.Text = "Skriv här vad som har varit problem med dragaren eller hacken.";
            this.tb_Dragare.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_Dragare_KeyDown);
            // 
            // tb_Tid
            // 
            this.tb_Tid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tb_Tid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Tid.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_Tid.Font = new System.Drawing.Font("Courier New", 9.25F);
            this.tb_Tid.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_Tid.Location = new System.Drawing.Point(0, 0);
            this.tb_Tid.Margin = new System.Windows.Forms.Padding(30, 5, 0, 0);
            this.tb_Tid.Name = "tb_Tid";
            this.tb_Tid.Size = new System.Drawing.Size(377, 14);
            this.tb_Tid.TabIndex = 2;
            // 
            // tlp_Kontaktperson
            // 
            this.tlp_Kontaktperson.ColumnCount = 1;
            this.tlp_Kontaktperson.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Kontaktperson.Controls.Add(this.label_Kontaktperson_Info, 0, 0);
            this.tlp_Kontaktperson.Controls.Add(this.tb_Kontaktperson, 0, 1);
            this.tlp_Kontaktperson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Kontaktperson.Location = new System.Drawing.Point(184, 214);
            this.tlp_Kontaktperson.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Kontaktperson.Name = "tlp_Kontaktperson";
            this.tlp_Kontaktperson.RowCount = 3;
            this.tlp_Kontaktperson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78.94736F));
            this.tlp_Kontaktperson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.05263F));
            this.tlp_Kontaktperson.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Kontaktperson.Size = new System.Drawing.Size(160, 59);
            this.tlp_Kontaktperson.TabIndex = 10;
            // 
            // label_Kontaktperson_Info
            // 
            this.label_Kontaktperson_Info.AutoSize = true;
            this.label_Kontaktperson_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Kontaktperson_Info.ForeColor = System.Drawing.Color.Gray;
            this.label_Kontaktperson_Info.Location = new System.Drawing.Point(3, 0);
            this.label_Kontaktperson_Info.Name = "label_Kontaktperson_Info";
            this.label_Kontaktperson_Info.Size = new System.Drawing.Size(154, 30);
            this.label_Kontaktperson_Info.TabIndex = 0;
            this.label_Kontaktperson_Info.Text = "Lämna denna tom om du själv är kontaktpersonen.";
            // 
            // tb_Kontaktperson
            // 
            this.tb_Kontaktperson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Kontaktperson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Kontaktperson.Font = new System.Drawing.Font("Courier New", 10F);
            this.tb_Kontaktperson.Location = new System.Drawing.Point(3, 35);
            this.tb_Kontaktperson.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.tb_Kontaktperson.Name = "tb_Kontaktperson";
            this.tb_Kontaktperson.Size = new System.Drawing.Size(154, 16);
            this.tb_Kontaktperson.TabIndex = 1;
            this.tb_Kontaktperson.Enter += new System.EventHandler(this.Namn_Enter);
            // 
            // label_Telefonnummer
            // 
            this.label_Telefonnummer.AutoSize = true;
            this.label_Telefonnummer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Telefonnummer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Telefonnummer.Location = new System.Drawing.Point(3, 273);
            this.label_Telefonnummer.Name = "label_Telefonnummer";
            this.label_Telefonnummer.Size = new System.Drawing.Size(178, 43);
            this.label_Telefonnummer.TabIndex = 12;
            this.label_Telefonnummer.Text = "Telefonnummer till kontaktpersonen.";
            this.label_Telefonnummer.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // pb_Info_Verktyg
            // 
            this.pb_Info_Verktyg.BackgroundImage = Image.FromStream(Pictures.Icons.Info);
            this.pb_Info_Verktyg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_Verktyg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_Verktyg.Dock = System.Windows.Forms.DockStyle.Top;
            this.pb_Info_Verktyg.Location = new System.Drawing.Point(344, 316);
            this.pb_Info_Verktyg.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Info_Verktyg.Name = "pb_Info_Verktyg";
            this.pb_Info_Verktyg.Size = new System.Drawing.Size(23, 18);
            this.pb_Info_Verktyg.TabIndex = 11;
            this.pb_Info_Verktyg.TabStop = false;
            this.pb_Info_Verktyg.Click += new System.EventHandler(this.pb_Info_Verktyg_Click);
            // 
            // label_Skicka
            // 
            this.label_Skicka.AutoSize = true;
            this.label_Skicka.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.label_Skicka.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Skicka.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Skicka.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label_Skicka.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.label_Skicka.Location = new System.Drawing.Point(3, 660);
            this.label_Skicka.Name = "label_Skicka";
            this.label_Skicka.Size = new System.Drawing.Size(178, 24);
            this.label_Skicka.TabIndex = 15;
            this.label_Skicka.Text = "Skicka Rapport";
            this.label_Skicka.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label_Skicka.Click += new System.EventHandler(this.Skicka_Click);
            // 
            // label_Avbryt
            // 
            this.label_Avbryt.AutoSize = true;
            this.label_Avbryt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.label_Avbryt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Avbryt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_Avbryt.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label_Avbryt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_Avbryt.Location = new System.Drawing.Point(187, 660);
            this.label_Avbryt.Name = "label_Avbryt";
            this.label_Avbryt.Size = new System.Drawing.Size(154, 24);
            this.label_Avbryt.TabIndex = 16;
            this.label_Avbryt.Text = "Avbryt";
            this.label_Avbryt.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label_Avbryt.Click += new System.EventHandler(this.Avbryt_Click);
            // 
            // cm_Namn
            // 
            this.cm_Namn.Font = new System.Drawing.Font("Courier New", 8F);
            this.cm_Namn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cm_Namn.Name = "cm_Munstycke";
            this.cm_Namn.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cm_Namn.Size = new System.Drawing.Size(61, 4);
            this.cm_Namn.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Namn_ItemClicked);
            // 
            // Jira
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(750, 684);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Jira";
            this.Text = "Jira";
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Material)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Kontaktperson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Tid)).EndInit();
            this.panel_TextBoxes.ResumeLayout(false);
            this.panel_TextBoxes.PerformLayout();
            this.tlp_Material.ResumeLayout(false);
            this.tlp_Material.PerformLayout();
            this.tlp_Verktyg.ResumeLayout(false);
            this.tlp_Verktyg.PerformLayout();
            this.tlp_TextBoxes.ResumeLayout(false);
            this.tlp_Extruder_Matning_2.ResumeLayout(false);
            this.tlp_Extruder_Matning_2.PerformLayout();
            this.tlp_Extruder_Temp.ResumeLayout(false);
            this.tlp_Extruder_Temp.PerformLayout();
            this.tlp_Extruder_Matning_1.ResumeLayout(false);
            this.tlp_Extruder_Matning_1.PerformLayout();
            this.tlp_Dragare.ResumeLayout(false);
            this.tlp_Dragare.PerformLayout();
            this.tlp_Kontaktperson.ResumeLayout(false);
            this.tlp_Kontaktperson.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Verktyg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_Info;
        private TableLayoutPanel tlp_Main;
        private Label label_Tid;
        private TextBox tb_Tid;
        private PictureBox pb_Info_Tid;
        private CheckBox chb_Dragare;
        private CheckBox chb_Extruder_Temp;
        private TextBox tb_Extruder_Temp;
        private TextBox tb_Extruder_Matning;
        private TextBox tb_Dragare;
        private CheckBox chb_Extruder_Matning;
        private TableLayoutPanel tlp_TextBoxes;
        private TableLayoutPanel tlp_Extruder_Matning_2;
        private Label label_Info_1;
        private Label label_Info_2;
        private TextBox tb_Belastning;
        private TextBox tb_Skruvvarv;
        private TableLayoutPanel tlp_Extruder_Temp;
        private Label label_Info_Extruder_Temp;
        private TableLayoutPanel tlp_Extruder_Matning_1;
        private Label label_Info_ExtruderMatning;
        private TableLayoutPanel tlp_Dragare;
        private Label label_Info_Dragare_Hack;
        private Panel panel_TextBoxes;
        private Label label_Kontaktperson;
        private TableLayoutPanel tlp_Kontaktperson;
        private PictureBox pb_Info_Kontaktperson;
        private Label label_Kontaktperson_Info;
        private TextBox tb_Kontaktperson;
        private ContextMenuStrip cm_Namn;
        private TextBox tb_Telefonnummer;
        private Label label_Telefonnummer;
        private Label label1;
        private TableLayoutPanel tlp_Verktyg;
        private Label label_Info_Kalibrering;
        private Label label_Info_Hackrör;
        private Label label_Info_Munstycke;
        private TextBox tb_Munstycke;
        private TextBox tb_Kärn;
        private Label label_Info_Kärn;
        private TextBox tb_Hackrör;
        private TextBox tb_Kalibrering;
        private PictureBox pb_Info_Verktyg;
        private CheckBox chb_Material;
        private TableLayoutPanel tlp_Material;
        private Label label_Info_Material;
        private FlowLayoutPanel flp_Material;
        private ToolTip toolTip1;
        private Label label_Skicka;
        private Label label_Avbryt;
        private PictureBox pb_Info_Material;
        private Label label_Extra_Kommentarer;
        private Label label_Info_Kommentarer_Övrigt;
        private TextBox tb_Kommentarer;
        private Label label_Info_Material_2;
        private TextBox tb_Kommentarer_Material;
    }
}