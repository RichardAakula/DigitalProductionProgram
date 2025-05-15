using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class Measurement_Protocol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Measurement_Protocol));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_OrderInfo_TEF = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Benämning_Övrigt = new System.Windows.Forms.Label();
            this.label_Description = new System.Windows.Forms.Label();
            this.lbl_OrderNr_Övrigt = new System.Windows.Forms.Label();
            this.label_OrderNr = new System.Windows.Forms.Label();
            this.label_Customer = new System.Windows.Forms.Label();
            this.label_PartNumber = new System.Windows.Forms.Label();
            this.lbl_ArtikelNr_Övrigt = new System.Windows.Forms.Label();
            this.lbl_Kund_Övrigt = new System.Windows.Forms.Label();
            this.flp_Buttons = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_TransferLengthMeasure = new System.Windows.Forms.Button();
            this.btn_TransferMeasurement = new System.Windows.Forms.Button();
            this.btn_EditBag = new System.Windows.Forms.Button();
            this.btn_EditAmount = new System.Windows.Forms.Button();
            this.btn_Discard = new System.Windows.Forms.Button();
            this.btn_TransferToExcel = new System.Windows.Forms.Button();
            this.tlp_Help_InputData_1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Clear_HelpInput_2 = new System.Windows.Forms.Button();
            this.btn_Clear_HelpInput_1 = new System.Windows.Forms.Button();
            this.dgv_HelpInput_1 = new System.Windows.Forms.DataGridView();
            this.RowHeaders = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Walls = new System.Windows.Forms.DataGridView();
            this.dgv_RecWalls = new System.Windows.Forms.DataGridView();
            this.dgv_HelpInput_2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pb_CrossSectionTube = new System.Windows.Forms.PictureBox();
            this.tlp_Mätdon = new System.Windows.Forms.TableLayoutPanel();
            this.tb_Hack = new System.Windows.Forms.TextBox();
            this.label_HackNr = new System.Windows.Forms.Label();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Measurements = new System.Windows.Forms.DataGridView();
            this.tlp_Info_Colors = new System.Windows.Forms.TableLayoutPanel();
            this.pb_Info = new System.Windows.Forms.PictureBox();
            this.label_Discarded = new System.Windows.Forms.Label();
            this.label_Ok = new System.Windows.Forms.Label();
            this.label_Fail = new System.Windows.Forms.Label();
            this.label_Felskrivning = new System.Windows.Forms.Label();
            this.label_Warning = new System.Windows.Forms.Label();
            this.flp_Headers = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_InputControls = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.tlp_OrderInfo_FEP = new System.Windows.Forms.TableLayoutPanel();
            this.label_OD = new System.Windows.Forms.Label();
            this.lbl_Nom_OD = new System.Windows.Forms.Label();
            this.label_Wall = new System.Windows.Forms.Label();
            this.lbl_Nom_Wall = new System.Windows.Forms.Label();
            this.label_Length = new System.Windows.Forms.Label();
            this.lbl_Nom_Length = new System.Windows.Forms.Label();
            this.lbl_Nom_ID = new System.Windows.Forms.Label();
            this.label_ID = new System.Windows.Forms.Label();
            this.lbl_OrderNr_FEP = new System.Windows.Forms.Label();
            this.label_OrderNr_2 = new System.Windows.Forms.Label();
            this.label_Customer_2 = new System.Windows.Forms.Label();
            this.lbl_Kund_FEP = new System.Windows.Forms.Label();
            this.Co_Extrudering = new System.Windows.Forms.CheckBox();
            this.Röntgen = new System.Windows.Forms.CheckBox();
            this.Clear = new System.Windows.Forms.CheckBox();
            this.label_AntalStripes = new System.Windows.Forms.Label();
            this.Antal_Stripes = new System.Windows.Forms.TextBox();
            this.label_st = new System.Windows.Forms.Label();
            this.Single_Extrudering = new System.Windows.Forms.CheckBox();
            this.menu_Beräkna = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_ID_Blåst = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_OD_Blåst = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_W_Blåst = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_ID_Krympt = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_OD_Krympt = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_W_Krympt = new System.Windows.Forms.ToolStripMenuItem();
            this.measureInstrument = new DigitalProductionProgram.Measure.MeasureInstrument();
            this.tlp_Help_InputData_2 = new System.Windows.Forms.TableLayoutPanel();
            this.col_RecInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_RecWall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Wall = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlp_OrderInfo_TEF.SuspendLayout();
            this.flp_Buttons.SuspendLayout();
            this.tlp_Help_InputData_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HelpInput_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Walls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecWalls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HelpInput_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CrossSectionTube)).BeginInit();
            this.tlp_Mätdon.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Measurements)).BeginInit();
            this.tlp_Info_Colors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.tlp_OrderInfo_FEP.SuspendLayout();
            this.menu_Beräkna.SuspendLayout();
            this.tlp_Help_InputData_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_OrderInfo_TEF
            // 
            this.tlp_OrderInfo_TEF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_OrderInfo_TEF.ColumnCount = 4;
            this.tlp_OrderInfo_TEF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tlp_OrderInfo_TEF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_OrderInfo_TEF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp_OrderInfo_TEF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlp_OrderInfo_TEF.Controls.Add(this.lbl_Benämning_Övrigt, 1, 1);
            this.tlp_OrderInfo_TEF.Controls.Add(this.label_Description, 0, 1);
            this.tlp_OrderInfo_TEF.Controls.Add(this.lbl_OrderNr_Övrigt, 3, 0);
            this.tlp_OrderInfo_TEF.Controls.Add(this.label_OrderNr, 2, 0);
            this.tlp_OrderInfo_TEF.Controls.Add(this.label_Customer, 0, 0);
            this.tlp_OrderInfo_TEF.Controls.Add(this.label_PartNumber, 2, 1);
            this.tlp_OrderInfo_TEF.Controls.Add(this.lbl_ArtikelNr_Övrigt, 3, 1);
            this.tlp_OrderInfo_TEF.Controls.Add(this.lbl_Kund_Övrigt, 1, 0);
            this.tlp_OrderInfo_TEF.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_OrderInfo_TEF.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_OrderInfo_TEF.Location = new System.Drawing.Point(0, 0);
            this.tlp_OrderInfo_TEF.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_OrderInfo_TEF.Name = "tlp_OrderInfo_TEF";
            this.tlp_OrderInfo_TEF.RowCount = 2;
            this.tlp_OrderInfo_TEF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_OrderInfo_TEF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_OrderInfo_TEF.Size = new System.Drawing.Size(1137, 44);
            this.tlp_OrderInfo_TEF.TabIndex = 85;
            // 
            // lbl_Benämning_Övrigt
            // 
            this.lbl_Benämning_Övrigt.AutoSize = true;
            this.lbl_Benämning_Övrigt.BackColor = System.Drawing.Color.White;
            this.lbl_Benämning_Övrigt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Benämning_Övrigt.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_Benämning_Övrigt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Benämning_Övrigt.Location = new System.Drawing.Point(106, 23);
            this.lbl_Benämning_Övrigt.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.lbl_Benämning_Övrigt.Name = "lbl_Benämning_Övrigt";
            this.lbl_Benämning_Övrigt.Size = new System.Drawing.Size(761, 20);
            this.lbl_Benämning_Övrigt.TabIndex = 924;
            this.lbl_Benämning_Övrigt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Description
            // 
            this.label_Description.BackColor = System.Drawing.Color.White;
            this.label_Description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Description.Font = new System.Drawing.Font("Arial", 12F);
            this.label_Description.ForeColor = System.Drawing.Color.Black;
            this.label_Description.Location = new System.Drawing.Point(1, 23);
            this.label_Description.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(104, 20);
            this.label_Description.TabIndex = 921;
            this.label_Description.Text = "Benämning:";
            this.label_Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr_Övrigt
            // 
            this.lbl_OrderNr_Övrigt.BackColor = System.Drawing.Color.White;
            this.lbl_OrderNr_Övrigt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr_Övrigt.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_OrderNr_Övrigt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_OrderNr_Övrigt.Location = new System.Drawing.Point(988, 1);
            this.lbl_OrderNr_Övrigt.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.lbl_OrderNr_Övrigt.Name = "lbl_OrderNr_Övrigt";
            this.lbl_OrderNr_Övrigt.Size = new System.Drawing.Size(148, 21);
            this.lbl_OrderNr_Övrigt.TabIndex = 915;
            this.lbl_OrderNr_Övrigt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr
            // 
            this.label_OrderNr.BackColor = System.Drawing.Color.White;
            this.label_OrderNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr.Font = new System.Drawing.Font("Arial", 12F);
            this.label_OrderNr.ForeColor = System.Drawing.Color.Black;
            this.label_OrderNr.Location = new System.Drawing.Point(868, 1);
            this.label_OrderNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_OrderNr.Name = "label_OrderNr";
            this.label_OrderNr.Size = new System.Drawing.Size(119, 21);
            this.label_OrderNr.TabIndex = 914;
            this.label_OrderNr.Text = "OrderNr: ";
            this.label_OrderNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Customer
            // 
            this.label_Customer.BackColor = System.Drawing.Color.White;
            this.label_Customer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Customer.Font = new System.Drawing.Font("Arial", 12F);
            this.label_Customer.ForeColor = System.Drawing.Color.Black;
            this.label_Customer.Location = new System.Drawing.Point(1, 1);
            this.label_Customer.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Customer.Name = "label_Customer";
            this.label_Customer.Size = new System.Drawing.Size(104, 21);
            this.label_Customer.TabIndex = 898;
            this.label_Customer.Text = "Kund: ";
            this.label_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_PartNumber
            // 
            this.label_PartNumber.BackColor = System.Drawing.Color.White;
            this.label_PartNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_PartNumber.Font = new System.Drawing.Font("Arial", 12F);
            this.label_PartNumber.ForeColor = System.Drawing.Color.Black;
            this.label_PartNumber.Location = new System.Drawing.Point(868, 23);
            this.label_PartNumber.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_PartNumber.Name = "label_PartNumber";
            this.label_PartNumber.Size = new System.Drawing.Size(119, 20);
            this.label_PartNumber.TabIndex = 922;
            this.label_PartNumber.Text = "ArtikelNr:";
            this.label_PartNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ArtikelNr_Övrigt
            // 
            this.lbl_ArtikelNr_Övrigt.BackColor = System.Drawing.Color.White;
            this.lbl_ArtikelNr_Övrigt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ArtikelNr_Övrigt.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_ArtikelNr_Övrigt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_ArtikelNr_Övrigt.Location = new System.Drawing.Point(988, 23);
            this.lbl_ArtikelNr_Övrigt.Margin = new System.Windows.Forms.Padding(1);
            this.lbl_ArtikelNr_Övrigt.Name = "lbl_ArtikelNr_Övrigt";
            this.lbl_ArtikelNr_Övrigt.Size = new System.Drawing.Size(148, 20);
            this.lbl_ArtikelNr_Övrigt.TabIndex = 923;
            this.lbl_ArtikelNr_Övrigt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Kund_Övrigt
            // 
            this.lbl_Kund_Övrigt.AutoSize = true;
            this.lbl_Kund_Övrigt.BackColor = System.Drawing.Color.White;
            this.lbl_Kund_Övrigt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Kund_Övrigt.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_Kund_Övrigt.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Kund_Övrigt.Location = new System.Drawing.Point(106, 1);
            this.lbl_Kund_Övrigt.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_Kund_Övrigt.Name = "lbl_Kund_Övrigt";
            this.lbl_Kund_Övrigt.Size = new System.Drawing.Size(761, 21);
            this.lbl_Kund_Övrigt.TabIndex = 902;
            this.lbl_Kund_Övrigt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flp_Buttons
            // 
            this.flp_Buttons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.flp_Buttons.Controls.Add(this.btn_TransferLengthMeasure);
            this.flp_Buttons.Controls.Add(this.btn_TransferMeasurement);
            this.flp_Buttons.Controls.Add(this.btn_EditBag);
            this.flp_Buttons.Controls.Add(this.btn_EditAmount);
            this.flp_Buttons.Controls.Add(this.btn_Discard);
            this.flp_Buttons.Controls.Add(this.btn_TransferToExcel);
            this.flp_Buttons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flp_Buttons.Location = new System.Drawing.Point(0, 945);
            this.flp_Buttons.Name = "flp_Buttons";
            this.flp_Buttons.Size = new System.Drawing.Size(1137, 60);
            this.flp_Buttons.TabIndex = 986;
            // 
            // btn_TransferLengthMeasure
            // 
            this.btn_TransferLengthMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_TransferLengthMeasure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TransferLengthMeasure.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_TransferLengthMeasure.FlatAppearance.BorderSize = 3;
            this.btn_TransferLengthMeasure.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_TransferLengthMeasure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_TransferLengthMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TransferLengthMeasure.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_TransferLengthMeasure.ForeColor = System.Drawing.Color.White;
            this.btn_TransferLengthMeasure.Location = new System.Drawing.Point(5, 5);
            this.btn_TransferLengthMeasure.Margin = new System.Windows.Forms.Padding(5, 5, 5, 1);
            this.btn_TransferLengthMeasure.Name = "btn_TransferLengthMeasure";
            this.btn_TransferLengthMeasure.Size = new System.Drawing.Size(106, 50);
            this.btn_TransferLengthMeasure.TabIndex = 10;
            this.btn_TransferLengthMeasure.Text = "Överför Längdmätning";
            this.btn_TransferLengthMeasure.UseVisualStyleBackColor = false;
            this.btn_TransferLengthMeasure.Visible = false;
            this.btn_TransferLengthMeasure.Click += new System.EventHandler(this.TransferLengthMeasure_Click);
            // 
            // btn_TransferMeasurement
            // 
            this.btn_TransferMeasurement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_TransferMeasurement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TransferMeasurement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_TransferMeasurement.FlatAppearance.BorderSize = 3;
            this.btn_TransferMeasurement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_TransferMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TransferMeasurement.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_TransferMeasurement.ForeColor = System.Drawing.Color.White;
            this.btn_TransferMeasurement.Location = new System.Drawing.Point(121, 5);
            this.btn_TransferMeasurement.Margin = new System.Windows.Forms.Padding(5, 5, 5, 1);
            this.btn_TransferMeasurement.Name = "btn_TransferMeasurement";
            this.btn_TransferMeasurement.Size = new System.Drawing.Size(106, 50);
            this.btn_TransferMeasurement.TabIndex = 48;
            this.btn_TransferMeasurement.Text = "Överför Mätning";
            this.btn_TransferMeasurement.UseVisualStyleBackColor = false;
            this.btn_TransferMeasurement.Click += new System.EventHandler(this.TransferMeasurement_Click);
            // 
            // btn_EditBag
            // 
            this.btn_EditBag.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_EditBag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EditBag.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.btn_EditBag.FlatAppearance.BorderSize = 3;
            this.btn_EditBag.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.btn_EditBag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditBag.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_EditBag.ForeColor = System.Drawing.Color.White;
            this.btn_EditBag.Location = new System.Drawing.Point(257, 5);
            this.btn_EditBag.Margin = new System.Windows.Forms.Padding(25, 5, 5, 1);
            this.btn_EditBag.Name = "btn_EditBag";
            this.btn_EditBag.Size = new System.Drawing.Size(114, 50);
            this.btn_EditBag.TabIndex = 855;
            this.btn_EditBag.Text = "Redigera PåseNr/SpoleNr";
            this.btn_EditBag.UseVisualStyleBackColor = false;
            this.btn_EditBag.Visible = false;
            this.btn_EditBag.Click += new System.EventHandler(this.EditBag_Click);
            // 
            // btn_EditAmount
            // 
            this.btn_EditAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_EditAmount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_EditAmount.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.btn_EditAmount.FlatAppearance.BorderSize = 3;
            this.btn_EditAmount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.btn_EditAmount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_EditAmount.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_EditAmount.ForeColor = System.Drawing.Color.White;
            this.btn_EditAmount.Location = new System.Drawing.Point(401, 5);
            this.btn_EditAmount.Margin = new System.Windows.Forms.Padding(25, 5, 5, 1);
            this.btn_EditAmount.Name = "btn_EditAmount";
            this.btn_EditAmount.Size = new System.Drawing.Size(87, 50);
            this.btn_EditAmount.TabIndex = 48;
            this.btn_EditAmount.Text = "Redigera Mängd";
            this.btn_EditAmount.UseVisualStyleBackColor = false;
            this.btn_EditAmount.Visible = false;
            this.btn_EditAmount.Click += new System.EventHandler(this.EditTotal_Click);
            // 
            // btn_Discard
            // 
            this.btn_Discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_Discard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Discard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Discard.FlatAppearance.BorderSize = 3;
            this.btn_Discard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Discard.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_Discard.ForeColor = System.Drawing.Color.White;
            this.btn_Discard.Location = new System.Drawing.Point(523, 5);
            this.btn_Discard.Margin = new System.Windows.Forms.Padding(30, 5, 1, 5);
            this.btn_Discard.Name = "btn_Discard";
            this.btn_Discard.Size = new System.Drawing.Size(134, 50);
            this.btn_Discard.TabIndex = 853;
            this.btn_Discard.Text = "Kassera Mätning";
            this.btn_Discard.UseVisualStyleBackColor = false;
            this.btn_Discard.Click += new System.EventHandler(this.DiscardMeasurement_Click);
            // 
            // btn_TransferToExcel
            // 
            this.btn_TransferToExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_TransferToExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TransferToExcel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_TransferToExcel.FlatAppearance.BorderSize = 3;
            this.btn_TransferToExcel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_TransferToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_TransferToExcel.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_TransferToExcel.ForeColor = System.Drawing.Color.White;
            this.btn_TransferToExcel.Location = new System.Drawing.Point(708, 5);
            this.btn_TransferToExcel.Margin = new System.Windows.Forms.Padding(50, 5, 5, 1);
            this.btn_TransferToExcel.Name = "btn_TransferToExcel";
            this.btn_TransferToExcel.Size = new System.Drawing.Size(138, 50);
            this.btn_TransferToExcel.TabIndex = 854;
            this.btn_TransferToExcel.Text = "Överför Mätningar till Excel";
            this.btn_TransferToExcel.UseVisualStyleBackColor = false;
            this.btn_TransferToExcel.Visible = false;
            // 
            // tlp_Help_InputData_1
            // 
            this.tlp_Help_InputData_1.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Help_InputData_1.ColumnCount = 2;
            this.tlp_Help_InputData_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_Help_InputData_1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Help_InputData_1.Controls.Add(this.btn_Clear_HelpInput_1, 0, 0);
            this.tlp_Help_InputData_1.Controls.Add(this.dgv_HelpInput_1, 0, 1);
            this.tlp_Help_InputData_1.Controls.Add(this.dgv_Walls, 1, 1);
            this.tlp_Help_InputData_1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlp_Help_InputData_1.Location = new System.Drawing.Point(0, 0);
            this.tlp_Help_InputData_1.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Help_InputData_1.Name = "tlp_Help_InputData_1";
            this.tlp_Help_InputData_1.RowCount = 2;
            this.tlp_Help_InputData_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Help_InputData_1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Help_InputData_1.Size = new System.Drawing.Size(175, 207);
            this.tlp_Help_InputData_1.TabIndex = 984;
            this.tlp_Help_InputData_1.Visible = false;
            // 
            // btn_Clear_HelpInput_2
            // 
            this.btn_Clear_HelpInput_2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_Clear_HelpInput_2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Clear_HelpInput_2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_Clear_HelpInput_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear_HelpInput_2.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_Clear_HelpInput_2.ForeColor = System.Drawing.Color.White;
            this.btn_Clear_HelpInput_2.Location = new System.Drawing.Point(0, 0);
            this.btn_Clear_HelpInput_2.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Clear_HelpInput_2.Name = "btn_Clear_HelpInput_2";
            this.btn_Clear_HelpInput_2.Size = new System.Drawing.Size(75, 24);
            this.btn_Clear_HelpInput_2.TabIndex = 855;
            this.btn_Clear_HelpInput_2.Text = "Töm";
            this.btn_Clear_HelpInput_2.UseVisualStyleBackColor = false;
            // 
            // btn_Clear_HelpInput_1
            // 
            this.btn_Clear_HelpInput_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btn_Clear_HelpInput_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Clear_HelpInput_1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Clear_HelpInput_1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_Clear_HelpInput_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear_HelpInput_1.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.btn_Clear_HelpInput_1.ForeColor = System.Drawing.Color.White;
            this.btn_Clear_HelpInput_1.Location = new System.Drawing.Point(0, 0);
            this.btn_Clear_HelpInput_1.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Clear_HelpInput_1.Name = "btn_Clear_HelpInput_1";
            this.btn_Clear_HelpInput_1.Size = new System.Drawing.Size(75, 24);
            this.btn_Clear_HelpInput_1.TabIndex = 854;
            this.btn_Clear_HelpInput_1.Text = "Töm";
            this.btn_Clear_HelpInput_1.UseVisualStyleBackColor = false;
            this.btn_Clear_HelpInput_1.Click += new System.EventHandler(this.Clear_HelpInput_1_Click);
            // 
            // dgv_HelpInput_1
            // 
            this.dgv_HelpInput_1.AllowUserToAddRows = false;
            this.dgv_HelpInput_1.AllowUserToDeleteRows = false;
            this.dgv_HelpInput_1.AllowUserToResizeColumns = false;
            this.dgv_HelpInput_1.AllowUserToResizeRows = false;
            this.dgv_HelpInput_1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_HelpInput_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HelpInput_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgv_HelpInput_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HelpInput_1.ColumnHeadersVisible = false;
            this.dgv_HelpInput_1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowHeaders,
            this.Value});
            this.dgv_HelpInput_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Courier New", 8.25F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HelpInput_1.DefaultCellStyle = dataGridViewCellStyle23;
            this.dgv_HelpInput_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_HelpInput_1.Location = new System.Drawing.Point(0, 24);
            this.dgv_HelpInput_1.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_HelpInput_1.Name = "dgv_HelpInput_1";
            this.dgv_HelpInput_1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HelpInput_1.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.dgv_HelpInput_1.RowHeadersVisible = false;
            this.dgv_HelpInput_1.RowHeadersWidth = 30;
            this.dgv_HelpInput_1.RowTemplate.Height = 20;
            this.dgv_HelpInput_1.ShowEditingIcon = false;
            this.dgv_HelpInput_1.ShowRowErrors = false;
            this.dgv_HelpInput_1.Size = new System.Drawing.Size(75, 183);
            this.dgv_HelpInput_1.TabIndex = 0;
            this.dgv_HelpInput_1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.HelpInput_1_EditingControlShowing);
            // 
            // RowHeaders
            // 
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle21.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.Color.White;
            this.RowHeaders.DefaultCellStyle = dataGridViewCellStyle21;
            this.RowHeaders.Frozen = true;
            this.RowHeaders.HeaderText = "Row Headers";
            this.RowHeaders.Name = "RowHeaders";
            this.RowHeaders.ReadOnly = true;
            this.RowHeaders.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RowHeaders.Width = 25;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.Color.White;
            this.Value.DefaultCellStyle = dataGridViewCellStyle22;
            this.Value.Frozen = true;
            this.Value.HeaderText = "Values";
            this.Value.MaxInputLength = 5;
            this.Value.Name = "Value";
            this.Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Value.Width = 74;
            // 
            // dgv_Walls
            // 
            this.dgv_Walls.AllowUserToAddRows = false;
            this.dgv_Walls.AllowUserToDeleteRows = false;
            this.dgv_Walls.AllowUserToResizeColumns = false;
            this.dgv_Walls.AllowUserToResizeRows = false;
            this.dgv_Walls.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Walls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Walls.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Walls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Walls.ColumnHeadersVisible = false;
            this.dgv_Walls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Info,
            this.col_Wall});
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Walls.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgv_Walls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Walls.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_Walls.Location = new System.Drawing.Point(75, 24);
            this.dgv_Walls.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Walls.Name = "dgv_Walls";
            this.dgv_Walls.ReadOnly = true;
            this.dgv_Walls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Walls.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgv_Walls.RowHeadersVisible = false;
            this.dgv_Walls.RowHeadersWidth = 20;
            this.dgv_Walls.RowTemplate.ReadOnly = true;
            this.dgv_Walls.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Walls.Size = new System.Drawing.Size(100, 183);
            this.dgv_Walls.TabIndex = 856;
            this.dgv_Walls.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Walls_PreviewKeyDown);
            // 
            // dgv_RecWalls
            // 
            this.dgv_RecWalls.AllowUserToAddRows = false;
            this.dgv_RecWalls.AllowUserToDeleteRows = false;
            this.dgv_RecWalls.AllowUserToResizeColumns = false;
            this.dgv_RecWalls.AllowUserToResizeRows = false;
            this.dgv_RecWalls.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_RecWalls.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_RecWalls.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_RecWalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_RecWalls.ColumnHeadersVisible = false;
            this.dgv_RecWalls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_RecInfo,
            this.col_RecWall});
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_RecWalls.DefaultCellStyle = dataGridViewCellStyle29;
            this.dgv_RecWalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_RecWalls.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_RecWalls.Location = new System.Drawing.Point(75, 24);
            this.dgv_RecWalls.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_RecWalls.Name = "dgv_RecWalls";
            this.dgv_RecWalls.ReadOnly = true;
            this.dgv_RecWalls.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_RecWalls.RowHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dgv_RecWalls.RowHeadersVisible = false;
            this.dgv_RecWalls.RowHeadersWidth = 20;
            this.dgv_RecWalls.RowTemplate.ReadOnly = true;
            this.dgv_RecWalls.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_RecWalls.Size = new System.Drawing.Size(100, 183);
            this.dgv_RecWalls.TabIndex = 857;
            // 
            // dgv_HelpInput_2
            // 
            this.dgv_HelpInput_2.AllowUserToAddRows = false;
            this.dgv_HelpInput_2.AllowUserToDeleteRows = false;
            this.dgv_HelpInput_2.AllowUserToResizeColumns = false;
            this.dgv_HelpInput_2.AllowUserToResizeRows = false;
            this.dgv_HelpInput_2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_HelpInput_2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HelpInput_2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dgv_HelpInput_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HelpInput_2.ColumnHeadersVisible = false;
            this.dgv_HelpInput_2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgv_HelpInput_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("Courier New", 8.25F);
            dataGridViewCellStyle34.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_HelpInput_2.DefaultCellStyle = dataGridViewCellStyle34;
            this.dgv_HelpInput_2.Location = new System.Drawing.Point(0, 24);
            this.dgv_HelpInput_2.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_HelpInput_2.Name = "dgv_HelpInput_2";
            this.dgv_HelpInput_2.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle35.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_HelpInput_2.RowHeadersDefaultCellStyle = dataGridViewCellStyle35;
            this.dgv_HelpInput_2.RowHeadersVisible = false;
            this.dgv_HelpInput_2.RowHeadersWidth = 30;
            this.dgv_HelpInput_2.RowTemplate.Height = 20;
            this.dgv_HelpInput_2.ShowEditingIcon = false;
            this.dgv_HelpInput_2.ShowRowErrors = false;
            this.dgv_HelpInput_2.Size = new System.Drawing.Size(75, 183);
            this.dgv_HelpInput_2.TabIndex = 2;
            this.dgv_HelpInput_2.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.HelpInput_2_EditingControlShowing);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle32.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "Row Headers";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 2;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Width = 25;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle33.BackColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle33.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridViewTextBoxColumn2.Frozen = true;
            this.dataGridViewTextBoxColumn2.HeaderText = "Values";
            this.dataGridViewTextBoxColumn2.MaxInputLength = 5;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 74;
            // 
            // pb_CrossSectionTube
            // 
            this.pb_CrossSectionTube.BackColor = System.Drawing.Color.Transparent;
            this.pb_CrossSectionTube.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_CrossSectionTube.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_CrossSectionTube.Location = new System.Drawing.Point(350, 0);
            this.pb_CrossSectionTube.Margin = new System.Windows.Forms.Padding(0);
            this.pb_CrossSectionTube.Name = "pb_CrossSectionTube";
            this.pb_CrossSectionTube.Size = new System.Drawing.Size(200, 207);
            this.pb_CrossSectionTube.TabIndex = 985;
            this.pb_CrossSectionTube.TabStop = false;
            // 
            // tlp_Mätdon
            // 
            this.tlp_Mätdon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.tlp_Mätdon.ColumnCount = 2;
            this.tlp_Mätdon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.10506F));
            this.tlp_Mätdon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.89493F));
            this.tlp_Mätdon.Controls.Add(this.tb_Hack, 1, 0);
            this.tlp_Mätdon.Controls.Add(this.label_HackNr, 0, 0);
            this.tlp_Mätdon.Controls.Add(this.measureInstrument, 0, 1);
            this.tlp_Mätdon.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlp_Mätdon.Location = new System.Drawing.Point(746, 0);
            this.tlp_Mätdon.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.tlp_Mätdon.Name = "tlp_Mätdon";
            this.tlp_Mätdon.RowCount = 2;
            this.tlp_Mätdon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Mätdon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 99.99999F));
            this.tlp_Mätdon.Size = new System.Drawing.Size(391, 207);
            this.tlp_Mätdon.TabIndex = 987;
            // 
            // tb_Hack
            // 
            this.tb_Hack.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Hack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Hack.Font = new System.Drawing.Font("Consolas", 10F);
            this.tb_Hack.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.tb_Hack.Location = new System.Drawing.Point(137, 0);
            this.tb_Hack.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_Hack.MaxLength = 20;
            this.tb_Hack.Multiline = true;
            this.tb_Hack.Name = "tb_Hack";
            this.tb_Hack.Size = new System.Drawing.Size(254, 21);
            this.tb_Hack.TabIndex = 960;
            this.tb_Hack.Leave += new System.EventHandler(this.Hack_Leave);
            // 
            // label_HackNr
            // 
            this.label_HackNr.BackColor = System.Drawing.Color.Transparent;
            this.label_HackNr.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_HackNr.Font = new System.Drawing.Font("Arial", 10F);
            this.label_HackNr.ForeColor = System.Drawing.Color.White;
            this.label_HackNr.Location = new System.Drawing.Point(1, 1);
            this.label_HackNr.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_HackNr.Name = "label_HackNr";
            this.label_HackNr.Size = new System.Drawing.Size(136, 20);
            this.label_HackNr.TabIndex = 959;
            this.label_HackNr.Text = "Hack/Upptagare nr:";
            this.label_HackNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 331F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.dgv_Measurements, 0, 0);
            this.tlp_Main.Controls.Add(this.tlp_Info_Colors, 0, 1);
            this.tlp_Main.Controls.Add(this.flp_Headers, 0, 2);
            this.tlp_Main.Controls.Add(this.flp_InputControls, 0, 3);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 103);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_Main.Size = new System.Drawing.Size(1137, 635);
            this.tlp_Main.TabIndex = 988;
            // 
            // dgv_Measurements
            // 
            this.dgv_Measurements.AllowUserToAddRows = false;
            this.dgv_Measurements.AllowUserToDeleteRows = false;
            this.dgv_Measurements.AllowUserToResizeColumns = false;
            this.dgv_Measurements.AllowUserToResizeRows = false;
            this.dgv_Measurements.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Measurements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dgv_Measurements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlp_Main.SetColumnSpan(this.dgv_Measurements, 3);
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle37.Font = new System.Drawing.Font("Courier New", 9.25F);
            dataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Measurements.DefaultCellStyle = dataGridViewCellStyle37;
            this.dgv_Measurements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Measurements.EnableHeadersVisualStyles = false;
            this.dgv_Measurements.Location = new System.Drawing.Point(0, 0);
            this.dgv_Measurements.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Measurements.MultiSelect = false;
            this.dgv_Measurements.Name = "dgv_Measurements";
            this.dgv_Measurements.ReadOnly = true;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Measurements.RowHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.dgv_Measurements.RowHeadersVisible = false;
            this.dgv_Measurements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Measurements.Size = new System.Drawing.Size(1137, 504);
            this.dgv_Measurements.TabIndex = 86;
            this.dgv_Measurements.TabStop = false;
            this.dgv_Measurements.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.CopyRow_Measurements_CellMouseDoubleClick);
            this.dgv_Measurements.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.SortMeasurementSpool);
            // 
            // tlp_Info_Colors
            // 
            this.tlp_Info_Colors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_Info_Colors.ColumnCount = 3;
            this.tlp_Main.SetColumnSpan(this.tlp_Info_Colors, 3);
            this.tlp_Info_Colors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.tlp_Info_Colors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tlp_Info_Colors.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 2282F));
            this.tlp_Info_Colors.Controls.Add(this.pb_Info, 2, 0);
            this.tlp_Info_Colors.Controls.Add(this.label_Discarded, 1, 1);
            this.tlp_Info_Colors.Controls.Add(this.label_Ok, 0, 0);
            this.tlp_Info_Colors.Controls.Add(this.label_Fail, 0, 1);
            this.tlp_Info_Colors.Controls.Add(this.label_Felskrivning, 1, 0);
            this.tlp_Info_Colors.Controls.Add(this.label_Warning, 0, 2);
            this.tlp_Info_Colors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Info_Colors.Location = new System.Drawing.Point(0, 504);
            this.tlp_Info_Colors.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tlp_Info_Colors.Name = "tlp_Info_Colors";
            this.tlp_Info_Colors.RowCount = 3;
            this.tlp_Info_Colors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Info_Colors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Info_Colors.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Info_Colors.Size = new System.Drawing.Size(1137, 63);
            this.tlp_Info_Colors.TabIndex = 977;
            // 
            // pb_Info
            // 
            this.pb_Info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Info.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info.BackgroundImage")));
            this.pb_Info.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info.Location = new System.Drawing.Point(2650, 3);
            this.pb_Info.Name = "pb_Info";
            this.pb_Info.Size = new System.Drawing.Size(40, 14);
            this.pb_Info.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info.TabIndex = 974;
            this.pb_Info.TabStop = false;
            // 
            // label_Discarded
            // 
            this.label_Discarded.BackColor = System.Drawing.Color.DimGray;
            this.label_Discarded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Discarded.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Discarded.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label_Discarded.Location = new System.Drawing.Point(215, 20);
            this.label_Discarded.Margin = new System.Windows.Forms.Padding(0);
            this.label_Discarded.Name = "label_Discarded";
            this.label_Discarded.Size = new System.Drawing.Size(196, 20);
            this.label_Discarded.TabIndex = 973;
            this.label_Discarded.Text = "Kasserad";
            this.label_Discarded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Ok
            // 
            this.label_Ok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.label_Ok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Ok.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label_Ok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.label_Ok.Location = new System.Drawing.Point(0, 0);
            this.label_Ok.Margin = new System.Windows.Forms.Padding(0);
            this.label_Ok.Name = "label_Ok";
            this.label_Ok.Size = new System.Drawing.Size(215, 20);
            this.label_Ok.TabIndex = 954;
            this.label_Ok.Text = "Värde ok";
            this.label_Ok.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Fail
            // 
            this.label_Fail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.label_Fail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Fail.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label_Fail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.label_Fail.Location = new System.Drawing.Point(0, 20);
            this.label_Fail.Margin = new System.Windows.Forms.Padding(0);
            this.label_Fail.Name = "label_Fail";
            this.label_Fail.Size = new System.Drawing.Size(215, 20);
            this.label_Fail.TabIndex = 954;
            this.label_Fail.Text = "Värde utanför Spec.";
            this.label_Fail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Felskrivning
            // 
            this.label_Felskrivning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(198)))), ((int)(((byte)(231)))));
            this.label_Felskrivning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Felskrivning.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label_Felskrivning.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Felskrivning.Location = new System.Drawing.Point(215, 0);
            this.label_Felskrivning.Margin = new System.Windows.Forms.Padding(0);
            this.label_Felskrivning.Name = "label_Felskrivning";
            this.label_Felskrivning.Size = new System.Drawing.Size(196, 20);
            this.label_Felskrivning.TabIndex = 954;
            this.label_Felskrivning.Text = "Felskrivning?";
            this.label_Felskrivning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Warning
            // 
            this.label_Warning.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.label_Warning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Warning.Font = new System.Drawing.Font("Segoe UI", 8.75F);
            this.label_Warning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(101)))), ((int)(((byte)(0)))));
            this.label_Warning.Location = new System.Drawing.Point(0, 40);
            this.label_Warning.Margin = new System.Windows.Forms.Padding(0);
            this.label_Warning.Name = "label_Warning";
            this.label_Warning.Size = new System.Drawing.Size(215, 23);
            this.label_Warning.TabIndex = 954;
            this.label_Warning.Text = "Varning, värde utanför styrgräns";
            this.label_Warning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flp_Headers
            // 
            this.flp_Headers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.tlp_Main.SetColumnSpan(this.flp_Headers, 3);
            this.flp_Headers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Headers.Location = new System.Drawing.Point(0, 568);
            this.flp_Headers.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Headers.Name = "flp_Headers";
            this.flp_Headers.Size = new System.Drawing.Size(1137, 44);
            this.flp_Headers.TabIndex = 978;
            // 
            // flp_InputControls
            // 
            this.flp_InputControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.tlp_Main.SetColumnSpan(this.flp_InputControls, 3);
            this.flp_InputControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_InputControls.Location = new System.Drawing.Point(0, 612);
            this.flp_InputControls.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.flp_InputControls.Name = "flp_InputControls";
            this.flp_InputControls.Size = new System.Drawing.Size(1137, 21);
            this.flp_InputControls.TabIndex = 979;
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.pb_CrossSectionTube);
            this.panel_Bottom.Controls.Add(this.tlp_Help_InputData_2);
            this.panel_Bottom.Controls.Add(this.tlp_Help_InputData_1);
            this.panel_Bottom.Controls.Add(this.tlp_Mätdon);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 738);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(1137, 207);
            this.panel_Bottom.TabIndex = 989;
            // 
            // tlp_OrderInfo_FEP
            // 
            this.tlp_OrderInfo_FEP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.tlp_OrderInfo_FEP.ColumnCount = 14;
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tlp_OrderInfo_FEP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 317F));
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_OD, 6, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.lbl_Nom_OD, 7, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_Wall, 8, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.lbl_Nom_Wall, 9, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_Length, 10, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.lbl_Nom_Length, 11, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.lbl_Nom_ID, 5, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_ID, 4, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.lbl_OrderNr_FEP, 13, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_OrderNr_2, 12, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_Customer_2, 0, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.lbl_Kund_FEP, 1, 0);
            this.tlp_OrderInfo_FEP.Controls.Add(this.Co_Extrudering, 0, 1);
            this.tlp_OrderInfo_FEP.Controls.Add(this.Röntgen, 12, 1);
            this.tlp_OrderInfo_FEP.Controls.Add(this.Clear, 10, 1);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_AntalStripes, 2, 1);
            this.tlp_OrderInfo_FEP.Controls.Add(this.Antal_Stripes, 3, 1);
            this.tlp_OrderInfo_FEP.Controls.Add(this.label_st, 4, 1);
            this.tlp_OrderInfo_FEP.Controls.Add(this.Single_Extrudering, 5, 1);
            this.tlp_OrderInfo_FEP.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlp_OrderInfo_FEP.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_OrderInfo_FEP.Location = new System.Drawing.Point(0, 44);
            this.tlp_OrderInfo_FEP.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_OrderInfo_FEP.Name = "tlp_OrderInfo_FEP";
            this.tlp_OrderInfo_FEP.RowCount = 2;
            this.tlp_OrderInfo_FEP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.10169F));
            this.tlp_OrderInfo_FEP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.8983F));
            this.tlp_OrderInfo_FEP.Size = new System.Drawing.Size(1137, 59);
            this.tlp_OrderInfo_FEP.TabIndex = 990;
            // 
            // label_OD
            // 
            this.label_OD.BackColor = System.Drawing.Color.White;
            this.label_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OD.Font = new System.Drawing.Font("Arial", 10F);
            this.label_OD.ForeColor = System.Drawing.Color.Black;
            this.label_OD.Location = new System.Drawing.Point(352, 1);
            this.label_OD.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_OD.Name = "label_OD";
            this.label_OD.Size = new System.Drawing.Size(33, 38);
            this.label_OD.TabIndex = 939;
            this.label_OD.Text = "OD: ";
            this.label_OD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_OD
            // 
            this.lbl_Nom_OD.AutoSize = true;
            this.lbl_Nom_OD.BackColor = System.Drawing.Color.White;
            this.lbl_Nom_OD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Nom_OD.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Nom_OD.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Nom_OD.Location = new System.Drawing.Point(385, 1);
            this.lbl_Nom_OD.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Nom_OD.Name = "lbl_Nom_OD";
            this.lbl_Nom_OD.Size = new System.Drawing.Size(40, 38);
            this.lbl_Nom_OD.TabIndex = 938;
            this.lbl_Nom_OD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Wall
            // 
            this.label_Wall.BackColor = System.Drawing.Color.White;
            this.label_Wall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Wall.Font = new System.Drawing.Font("Arial", 10F);
            this.label_Wall.ForeColor = System.Drawing.Color.Black;
            this.label_Wall.Location = new System.Drawing.Point(426, 1);
            this.label_Wall.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Wall.Name = "label_Wall";
            this.label_Wall.Size = new System.Drawing.Size(39, 38);
            this.label_Wall.TabIndex = 937;
            this.label_Wall.Text = "Wall:";
            this.label_Wall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_Wall
            // 
            this.lbl_Nom_Wall.AutoSize = true;
            this.lbl_Nom_Wall.BackColor = System.Drawing.Color.White;
            this.lbl_Nom_Wall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Nom_Wall.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Nom_Wall.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Nom_Wall.Location = new System.Drawing.Point(465, 1);
            this.lbl_Nom_Wall.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Nom_Wall.Name = "lbl_Nom_Wall";
            this.lbl_Nom_Wall.Size = new System.Drawing.Size(40, 38);
            this.lbl_Nom_Wall.TabIndex = 936;
            this.lbl_Nom_Wall.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Length
            // 
            this.label_Length.BackColor = System.Drawing.Color.White;
            this.label_Length.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Length.Font = new System.Drawing.Font("Arial", 10F);
            this.label_Length.ForeColor = System.Drawing.Color.Black;
            this.label_Length.Location = new System.Drawing.Point(506, 1);
            this.label_Length.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Length.Name = "label_Length";
            this.label_Length.Size = new System.Drawing.Size(59, 38);
            this.label_Length.TabIndex = 935;
            this.label_Length.Text = "Length:";
            this.label_Length.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_Length
            // 
            this.lbl_Nom_Length.AutoSize = true;
            this.lbl_Nom_Length.BackColor = System.Drawing.Color.White;
            this.lbl_Nom_Length.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Nom_Length.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Nom_Length.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Nom_Length.Location = new System.Drawing.Point(565, 1);
            this.lbl_Nom_Length.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Nom_Length.Name = "lbl_Nom_Length";
            this.lbl_Nom_Length.Size = new System.Drawing.Size(78, 38);
            this.lbl_Nom_Length.TabIndex = 934;
            this.lbl_Nom_Length.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Nom_ID
            // 
            this.lbl_Nom_ID.AutoSize = true;
            this.lbl_Nom_ID.BackColor = System.Drawing.Color.White;
            this.lbl_Nom_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Nom_ID.Font = new System.Drawing.Font("Consolas", 8F);
            this.lbl_Nom_ID.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Nom_ID.Location = new System.Drawing.Point(311, 1);
            this.lbl_Nom_ID.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.lbl_Nom_ID.Name = "lbl_Nom_ID";
            this.lbl_Nom_ID.Size = new System.Drawing.Size(40, 38);
            this.lbl_Nom_ID.TabIndex = 926;
            this.lbl_Nom_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ID
            // 
            this.label_ID.BackColor = System.Drawing.Color.White;
            this.label_ID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ID.Font = new System.Drawing.Font("Arial", 10F);
            this.label_ID.ForeColor = System.Drawing.Color.Black;
            this.label_ID.Location = new System.Drawing.Point(282, 1);
            this.label_ID.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_ID.Name = "label_ID";
            this.label_ID.Size = new System.Drawing.Size(29, 38);
            this.label_ID.TabIndex = 925;
            this.label_ID.Text = "ID: ";
            this.label_ID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderNr_FEP
            // 
            this.lbl_OrderNr_FEP.BackColor = System.Drawing.Color.White;
            this.lbl_OrderNr_FEP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_OrderNr_FEP.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_OrderNr_FEP.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_OrderNr_FEP.Location = new System.Drawing.Point(718, 1);
            this.lbl_OrderNr_FEP.Margin = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.lbl_OrderNr_FEP.Name = "lbl_OrderNr_FEP";
            this.lbl_OrderNr_FEP.Size = new System.Drawing.Size(418, 38);
            this.lbl_OrderNr_FEP.TabIndex = 915;
            this.lbl_OrderNr_FEP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OrderNr_2
            // 
            this.label_OrderNr_2.BackColor = System.Drawing.Color.White;
            this.label_OrderNr_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_OrderNr_2.Font = new System.Drawing.Font("Arial", 12F);
            this.label_OrderNr_2.ForeColor = System.Drawing.Color.Black;
            this.label_OrderNr_2.Location = new System.Drawing.Point(644, 1);
            this.label_OrderNr_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_OrderNr_2.Name = "label_OrderNr_2";
            this.label_OrderNr_2.Size = new System.Drawing.Size(73, 38);
            this.label_OrderNr_2.TabIndex = 914;
            this.label_OrderNr_2.Text = "OrderNr: ";
            this.label_OrderNr_2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Customer_2
            // 
            this.label_Customer_2.BackColor = System.Drawing.Color.White;
            this.label_Customer_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Customer_2.Font = new System.Drawing.Font("Arial", 12F);
            this.label_Customer_2.ForeColor = System.Drawing.Color.Black;
            this.label_Customer_2.Location = new System.Drawing.Point(1, 1);
            this.label_Customer_2.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.label_Customer_2.Name = "label_Customer_2";
            this.label_Customer_2.Size = new System.Drawing.Size(68, 38);
            this.label_Customer_2.TabIndex = 898;
            this.label_Customer_2.Text = "Kund: ";
            this.label_Customer_2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Kund_FEP
            // 
            this.lbl_Kund_FEP.AutoSize = true;
            this.lbl_Kund_FEP.BackColor = System.Drawing.Color.White;
            this.tlp_OrderInfo_FEP.SetColumnSpan(this.lbl_Kund_FEP, 3);
            this.lbl_Kund_FEP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Kund_FEP.Font = new System.Drawing.Font("Consolas", 10F);
            this.lbl_Kund_FEP.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lbl_Kund_FEP.Location = new System.Drawing.Point(70, 1);
            this.lbl_Kund_FEP.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.lbl_Kund_FEP.Name = "lbl_Kund_FEP";
            this.lbl_Kund_FEP.Size = new System.Drawing.Size(211, 38);
            this.lbl_Kund_FEP.TabIndex = 902;
            this.lbl_Kund_FEP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Co_Extrudering
            // 
            this.Co_Extrudering.AutoSize = true;
            this.Co_Extrudering.BackColor = System.Drawing.Color.White;
            this.tlp_OrderInfo_FEP.SetColumnSpan(this.Co_Extrudering, 2);
            this.Co_Extrudering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Co_Extrudering.Font = new System.Drawing.Font("Arial", 9F);
            this.Co_Extrudering.Location = new System.Drawing.Point(1, 40);
            this.Co_Extrudering.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.Co_Extrudering.Name = "Co_Extrudering";
            this.Co_Extrudering.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Co_Extrudering.Size = new System.Drawing.Size(153, 18);
            this.Co_Extrudering.TabIndex = 927;
            this.Co_Extrudering.Text = "Co-Extrudering";
            this.Co_Extrudering.UseVisualStyleBackColor = false;
            this.Co_Extrudering.CheckedChanged += new System.EventHandler(this.Co_Extrudering_CheckedChanged);
            // 
            // Röntgen
            // 
            this.Röntgen.AutoSize = true;
            this.Röntgen.BackColor = System.Drawing.Color.White;
            this.tlp_OrderInfo_FEP.SetColumnSpan(this.Röntgen, 2);
            this.Röntgen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Röntgen.Font = new System.Drawing.Font("Arial", 9F);
            this.Röntgen.Location = new System.Drawing.Point(644, 40);
            this.Röntgen.Margin = new System.Windows.Forms.Padding(1);
            this.Röntgen.Name = "Röntgen";
            this.Röntgen.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Röntgen.Size = new System.Drawing.Size(492, 18);
            this.Röntgen.TabIndex = 933;
            this.Röntgen.Text = "R/O";
            this.Röntgen.UseVisualStyleBackColor = false;
            this.Röntgen.CheckedChanged += new System.EventHandler(this.Röntgen_CheckedChanged);
            // 
            // Clear
            // 
            this.Clear.AutoSize = true;
            this.Clear.BackColor = System.Drawing.Color.White;
            this.tlp_OrderInfo_FEP.SetColumnSpan(this.Clear, 2);
            this.Clear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Clear.Font = new System.Drawing.Font("Arial", 9F);
            this.Clear.Location = new System.Drawing.Point(506, 40);
            this.Clear.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.Clear.Name = "Clear";
            this.Clear.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Clear.Size = new System.Drawing.Size(137, 18);
            this.Clear.TabIndex = 932;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = false;
            this.Clear.CheckedChanged += new System.EventHandler(this.Clear_CheckedChanged);
            // 
            // label_AntalStripes
            // 
            this.label_AntalStripes.BackColor = System.Drawing.Color.White;
            this.label_AntalStripes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_AntalStripes.Font = new System.Drawing.Font("Arial", 9F);
            this.label_AntalStripes.ForeColor = System.Drawing.Color.Black;
            this.label_AntalStripes.Location = new System.Drawing.Point(155, 40);
            this.label_AntalStripes.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_AntalStripes.Name = "label_AntalStripes";
            this.label_AntalStripes.Size = new System.Drawing.Size(81, 18);
            this.label_AntalStripes.TabIndex = 928;
            this.label_AntalStripes.Text = "Antal Stripes:";
            this.label_AntalStripes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Antal_Stripes
            // 
            this.Antal_Stripes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Antal_Stripes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Antal_Stripes.Font = new System.Drawing.Font("Consolas", 10F);
            this.Antal_Stripes.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.Antal_Stripes.Location = new System.Drawing.Point(236, 40);
            this.Antal_Stripes.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.Antal_Stripes.MaxLength = 1;
            this.Antal_Stripes.Multiline = true;
            this.Antal_Stripes.Name = "Antal_Stripes";
            this.Antal_Stripes.Size = new System.Drawing.Size(45, 18);
            this.Antal_Stripes.TabIndex = 929;
            this.Antal_Stripes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Antal_Stripes.Leave += new System.EventHandler(this.Antal_Stripes_Leave);
            // 
            // label_st
            // 
            this.label_st.BackColor = System.Drawing.Color.White;
            this.label_st.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_st.Font = new System.Drawing.Font("Arial", 9F);
            this.label_st.ForeColor = System.Drawing.Color.Black;
            this.label_st.Location = new System.Drawing.Point(281, 40);
            this.label_st.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.label_st.Name = "label_st";
            this.label_st.Size = new System.Drawing.Size(30, 18);
            this.label_st.TabIndex = 930;
            this.label_st.Text = "st";
            this.label_st.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Single_Extrudering
            // 
            this.Single_Extrudering.AutoSize = true;
            this.Single_Extrudering.BackColor = System.Drawing.Color.White;
            this.tlp_OrderInfo_FEP.SetColumnSpan(this.Single_Extrudering, 5);
            this.Single_Extrudering.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Single_Extrudering.Font = new System.Drawing.Font("Arial", 9F);
            this.Single_Extrudering.Location = new System.Drawing.Point(312, 40);
            this.Single_Extrudering.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.Single_Extrudering.Name = "Single_Extrudering";
            this.Single_Extrudering.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Single_Extrudering.Size = new System.Drawing.Size(193, 18);
            this.Single_Extrudering.TabIndex = 931;
            this.Single_Extrudering.Text = "Singel extrudering";
            this.Single_Extrudering.UseVisualStyleBackColor = false;
            this.Single_Extrudering.CheckedChanged += new System.EventHandler(this.Singel_Extrudering_CheckedChanged);
            // 
            // menu_Beräkna
            // 
            this.menu_Beräkna.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu_Beräkna.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_ID_Blåst,
            this.menu_OD_Blåst,
            this.menu_W_Blåst,
            this.menu_ID_Krympt,
            this.menu_OD_Krympt,
            this.menu_W_Krympt});
            this.menu_Beräkna.Name = "menu_ID";
            this.menu_Beräkna.Size = new System.Drawing.Size(258, 136);
            this.menu_Beräkna.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Menu_Beräkna_ItemClicked);
            // 
            // menu_ID_Blåst
            // 
            this.menu_ID_Blåst.Name = "menu_ID_Blåst";
            this.menu_ID_Blåst.Size = new System.Drawing.Size(257, 22);
            this.menu_ID_Blåst.Text = "Calculate Exp. ID with Wall and OD";
            // 
            // menu_OD_Blåst
            // 
            this.menu_OD_Blåst.Name = "menu_OD_Blåst";
            this.menu_OD_Blåst.Size = new System.Drawing.Size(257, 22);
            this.menu_OD_Blåst.Text = "Calculate Exp. OD with Wall and ID";
            // 
            // menu_W_Blåst
            // 
            this.menu_W_Blåst.Name = "menu_W_Blåst";
            this.menu_W_Blåst.Size = new System.Drawing.Size(257, 22);
            this.menu_W_Blåst.Text = "Calculate Exp. Wall with ID and OD";
            // 
            // menu_ID_Krympt
            // 
            this.menu_ID_Krympt.Name = "menu_ID_Krympt";
            this.menu_ID_Krympt.Size = new System.Drawing.Size(257, 22);
            this.menu_ID_Krympt.Text = "Calculate Rec. ID with Wall and OD";
            // 
            // menu_OD_Krympt
            // 
            this.menu_OD_Krympt.Name = "menu_OD_Krympt";
            this.menu_OD_Krympt.Size = new System.Drawing.Size(257, 22);
            this.menu_OD_Krympt.Text = "Calculate Rec. OD with Wall and ID";
            // 
            // menu_W_Krympt
            // 
            this.menu_W_Krympt.Name = "menu_W_Krympt";
            this.menu_W_Krympt.Size = new System.Drawing.Size(257, 22);
            this.menu_W_Krympt.Text = "Calculate Rec. Wall with ID and OD";
            // 
            // measureInstrument
            // 
            this.measureInstrument.AutoSize = true;
            this.measureInstrument.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Mätdon.SetColumnSpan(this.measureInstrument, 2);
            this.measureInstrument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.measureInstrument.Location = new System.Drawing.Point(3, 25);
            this.measureInstrument.Name = "measureInstrument";
            this.measureInstrument.Size = new System.Drawing.Size(385, 179);
            this.measureInstrument.TabIndex = 961;
            this.measureInstrument.TabStop = false;
            // 
            // tlp_Help_InputData_2
            // 
            this.tlp_Help_InputData_2.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Help_InputData_2.ColumnCount = 2;
            this.tlp_Help_InputData_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tlp_Help_InputData_2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlp_Help_InputData_2.Controls.Add(this.btn_Clear_HelpInput_2, 0, 0);
            this.tlp_Help_InputData_2.Controls.Add(this.dgv_HelpInput_2, 0, 1);
            this.tlp_Help_InputData_2.Controls.Add(this.dgv_RecWalls, 1, 1);
            this.tlp_Help_InputData_2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlp_Help_InputData_2.Location = new System.Drawing.Point(175, 0);
            this.tlp_Help_InputData_2.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Help_InputData_2.Name = "tlp_Help_InputData_2";
            this.tlp_Help_InputData_2.RowCount = 2;
            this.tlp_Help_InputData_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Help_InputData_2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Help_InputData_2.Size = new System.Drawing.Size(175, 207);
            this.tlp_Help_InputData_2.TabIndex = 985;
            this.tlp_Help_InputData_2.Visible = false;
            // 
            // col_RecInfo
            // 
            this.col_RecInfo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_RecInfo.HeaderText = "Info";
            this.col_RecInfo.Name = "col_RecInfo";
            this.col_RecInfo.ReadOnly = true;
            this.col_RecInfo.Width = 5;
            // 
            // col_RecWall
            // 
            this.col_RecWall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.White;
            this.col_RecWall.DefaultCellStyle = dataGridViewCellStyle28;
            this.col_RecWall.HeaderText = "Wall";
            this.col_RecWall.Name = "col_RecWall";
            this.col_RecWall.ReadOnly = true;
            // 
            // col_Info
            // 
            this.col_Info.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Info.HeaderText = "Info";
            this.col_Info.Name = "col_Info";
            this.col_Info.ReadOnly = true;
            this.col_Info.Width = 5;
            // 
            // col_Wall
            // 
            this.col_Wall.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.Color.White;
            this.col_Wall.DefaultCellStyle = dataGridViewCellStyle25;
            this.col_Wall.HeaderText = "Wall";
            this.col_Wall.Name = "col_Wall";
            this.col_Wall.ReadOnly = true;
            // 
            // Measurement_Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1137, 1005);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.tlp_OrderInfo_FEP);
            this.Controls.Add(this.tlp_OrderInfo_TEF);
            this.Controls.Add(this.panel_Bottom);
            this.Controls.Add(this.flp_Buttons);
            this.MinimumSize = new System.Drawing.Size(845, 39);
            this.Name = "Measurement_Protocol";
            this.Text = "Mätprotokoll";
            this.tlp_OrderInfo_TEF.ResumeLayout(false);
            this.tlp_OrderInfo_TEF.PerformLayout();
            this.flp_Buttons.ResumeLayout(false);
            this.tlp_Help_InputData_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HelpInput_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Walls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_RecWalls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HelpInput_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_CrossSectionTube)).EndInit();
            this.tlp_Mätdon.ResumeLayout(false);
            this.tlp_Mätdon.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Measurements)).EndInit();
            this.tlp_Info_Colors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.tlp_OrderInfo_FEP.ResumeLayout(false);
            this.tlp_OrderInfo_FEP.PerformLayout();
            this.menu_Beräkna.ResumeLayout(false);
            this.tlp_Help_InputData_2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_OrderInfo_TEF;
        private Label lbl_Benämning_Övrigt;
        private Label label_Description;
        private Label lbl_OrderNr_Övrigt;
        private Label label_OrderNr;
        private Label lbl_Kund_Övrigt;
        private Label label_Customer;
        private Label label_PartNumber;
        private Label lbl_ArtikelNr_Övrigt;
        private FlowLayoutPanel flp_Buttons;
        public Button btn_TransferMeasurement;
        public Button btn_TransferLengthMeasure;
        public Button btn_EditAmount;
        public Button btn_Discard;
        public Button btn_TransferToExcel;
        public Label label_HackNr;
        public TextBox tb_Hack;
        public PictureBox pb_CrossSectionTube;
        public TableLayoutPanel tlp_Mätdon;
        public TableLayoutPanel tlp_Help_InputData_1;
        public DataGridView dgv_HelpInput_1;
        public DataGridView dgv_HelpInput_2;
        public Button btn_Clear_HelpInput_2;
        public Button btn_Clear_HelpInput_1;
        public TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_Info_Colors;
        private PictureBox pb_Info;
        private Label label_Discarded;
        private Label label_Ok;
        private Label label_Fail;
        private Label label_Felskrivning;
        private Label label_Warning;
        public FlowLayoutPanel flp_Headers;
        public FlowLayoutPanel flp_InputControls;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private MeasureInstrument measureInstrument;
        public DataGridView dgv_Walls;
        private DataGridViewTextBoxColumn RowHeaders;
        private DataGridViewTextBoxColumn Value;
        public DataGridView dgv_Measurements;
        public Panel panel_Bottom;
        private TableLayoutPanel tlp_OrderInfo_FEP;
        private Label label_OD;
        private Label lbl_Nom_OD;
        private Label label_Wall;
        private Label lbl_Nom_Wall;
        private Label label_Length;
        private Label lbl_Nom_Length;
        private Label lbl_Nom_ID;
        private Label label_ID;
        private Label lbl_OrderNr_FEP;
        private Label label_OrderNr_2;
        private Label label_Customer_2;
        private Label lbl_Kund_FEP;
        private CheckBox Co_Extrudering;
        private CheckBox Röntgen;
        private CheckBox Clear;
        private Label label_AntalStripes;
        private TextBox Antal_Stripes;
        private Label label_st;
        private CheckBox Single_Extrudering;
        public Button btn_EditBag;
        private ContextMenuStrip menu_Beräkna;
        private ToolStripMenuItem menu_ID_Blåst;
        private ToolStripMenuItem menu_OD_Blåst;
        private ToolStripMenuItem menu_W_Blåst;
        private ToolStripMenuItem menu_ID_Krympt;
        private ToolStripMenuItem menu_OD_Krympt;
        private ToolStripMenuItem menu_W_Krympt;
        public DataGridView dgv_RecWalls;
        public TableLayoutPanel tlp_Help_InputData_2;
        private DataGridViewTextBoxColumn col_Info;
        private DataGridViewTextBoxColumn col_Wall;
        private DataGridViewTextBoxColumn col_RecInfo;
        private DataGridViewTextBoxColumn col_RecWall;
    }
}