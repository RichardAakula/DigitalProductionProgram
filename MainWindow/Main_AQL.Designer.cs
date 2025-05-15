
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class Main_AQL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_AQL));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_ProvInfo = new System.Windows.Forms.TableLayoutPanel();
            this.label_Provuttag_StartPåse = new System.Windows.Forms.Label();
            this.label_Provuttag_SlutPåse = new System.Windows.Forms.Label();
            this.label_Provuttag_AntalProver = new System.Windows.Forms.Label();
            this.pb_Info_Provuttagsinfo = new System.Windows.Forms.PictureBox();
            this.label_Provuttag_AntalPåsar = new System.Windows.Forms.Label();
            this.label_ProvuttagsInfo_PåsarMellanProv = new System.Windows.Forms.Label();
            this.tb_StartPåse = new System.Windows.Forms.TextBox();
            this.tb_SlutPåse = new System.Windows.Forms.TextBox();
            this.tb_AntalProver = new System.Windows.Forms.TextBox();
            this.label_ProvInfo_Rubrik = new System.Windows.Forms.Label();
            this.dgv_ProvInfo_Påsar = new System.Windows.Forms.DataGridView();
            this.lbl_AntalPåsar = new System.Windows.Forms.Label();
            this.lbl_PåsarMellanProv = new System.Windows.Forms.Label();
            this.timer_Update_ProvuttagInfo = new System.Windows.Forms.Timer(this.components);
            this.tlp_ProvInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Provuttagsinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProvInfo_Påsar)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_ProvInfo
            // 
            this.tlp_ProvInfo.BackColor = System.Drawing.Color.Transparent;
            this.tlp_ProvInfo.ColumnCount = 3;
            this.tlp_ProvInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlp_ProvInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tlp_ProvInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlp_ProvInfo.Controls.Add(this.label_Provuttag_StartPåse, 0, 1);
            this.tlp_ProvInfo.Controls.Add(this.label_Provuttag_SlutPåse, 0, 2);
            this.tlp_ProvInfo.Controls.Add(this.label_Provuttag_AntalProver, 0, 3);
            this.tlp_ProvInfo.Controls.Add(this.pb_Info_Provuttagsinfo, 1, 0);
            this.tlp_ProvInfo.Controls.Add(this.label_Provuttag_AntalPåsar, 0, 4);
            this.tlp_ProvInfo.Controls.Add(this.label_ProvuttagsInfo_PåsarMellanProv, 0, 5);
            this.tlp_ProvInfo.Controls.Add(this.tb_StartPåse, 1, 1);
            this.tlp_ProvInfo.Controls.Add(this.tb_SlutPåse, 1, 2);
            this.tlp_ProvInfo.Controls.Add(this.tb_AntalProver, 1, 3);
            this.tlp_ProvInfo.Controls.Add(this.label_ProvInfo_Rubrik, 0, 0);
            this.tlp_ProvInfo.Controls.Add(this.dgv_ProvInfo_Påsar, 2, 1);
            this.tlp_ProvInfo.Controls.Add(this.lbl_AntalPåsar, 1, 4);
            this.tlp_ProvInfo.Controls.Add(this.lbl_PåsarMellanProv, 1, 5);
            this.tlp_ProvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_ProvInfo.Location = new System.Drawing.Point(0, 0);
            this.tlp_ProvInfo.Name = "tlp_ProvInfo";
            this.tlp_ProvInfo.RowCount = 6;
            this.tlp_ProvInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlp_ProvInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_ProvInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_ProvInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_ProvInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_ProvInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlp_ProvInfo.Size = new System.Drawing.Size(243, 168);
            this.tlp_ProvInfo.TabIndex = 910;
            // 
            // label_Provuttag_StartPåse
            // 
            this.label_Provuttag_StartPåse.AutoSize = true;
            this.label_Provuttag_StartPåse.BackColor = System.Drawing.Color.Transparent;
            this.label_Provuttag_StartPåse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Provuttag_StartPåse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Provuttag_StartPåse.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_Provuttag_StartPåse.Location = new System.Drawing.Point(3, 35);
            this.label_Provuttag_StartPåse.Name = "label_Provuttag_StartPåse";
            this.label_Provuttag_StartPåse.Size = new System.Drawing.Size(144, 23);
            this.label_Provuttag_StartPåse.TabIndex = 0;
            this.label_Provuttag_StartPåse.Text = "StartPåse:";
            this.label_Provuttag_StartPåse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Provuttag_SlutPåse
            // 
            this.label_Provuttag_SlutPåse.AutoSize = true;
            this.label_Provuttag_SlutPåse.BackColor = System.Drawing.Color.Transparent;
            this.label_Provuttag_SlutPåse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Provuttag_SlutPåse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Provuttag_SlutPåse.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_Provuttag_SlutPåse.Location = new System.Drawing.Point(3, 58);
            this.label_Provuttag_SlutPåse.Name = "label_Provuttag_SlutPåse";
            this.label_Provuttag_SlutPåse.Size = new System.Drawing.Size(144, 23);
            this.label_Provuttag_SlutPåse.TabIndex = 0;
            this.label_Provuttag_SlutPåse.Text = "SlutPåse:";
            this.label_Provuttag_SlutPåse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Provuttag_AntalProver
            // 
            this.label_Provuttag_AntalProver.AutoSize = true;
            this.label_Provuttag_AntalProver.BackColor = System.Drawing.Color.Transparent;
            this.label_Provuttag_AntalProver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Provuttag_AntalProver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Provuttag_AntalProver.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_Provuttag_AntalProver.Location = new System.Drawing.Point(3, 81);
            this.label_Provuttag_AntalProver.Name = "label_Provuttag_AntalProver";
            this.label_Provuttag_AntalProver.Size = new System.Drawing.Size(144, 23);
            this.label_Provuttag_AntalProver.TabIndex = 0;
            this.label_Provuttag_AntalProver.Text = "Antal Prover:";
            this.label_Provuttag_AntalProver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pb_Info_Provuttagsinfo
            // 
            this.pb_Info_Provuttagsinfo.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info_Provuttagsinfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info_Provuttagsinfo.BackgroundImage")));
            this.pb_Info_Provuttagsinfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_Provuttagsinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_Provuttagsinfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Info_Provuttagsinfo.Location = new System.Drawing.Point(186, 3);
            this.pb_Info_Provuttagsinfo.Name = "pb_Info_Provuttagsinfo";
            this.pb_Info_Provuttagsinfo.Size = new System.Drawing.Size(34, 29);
            this.pb_Info_Provuttagsinfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info_Provuttagsinfo.TabIndex = 870;
            this.pb_Info_Provuttagsinfo.TabStop = false;
            this.pb_Info_Provuttagsinfo.Click += new System.EventHandler(this.Info_Provuttagsinfo_Click);
            // 
            // label_Provuttag_AntalPåsar
            // 
            this.label_Provuttag_AntalPåsar.AutoSize = true;
            this.label_Provuttag_AntalPåsar.BackColor = System.Drawing.Color.Transparent;
            this.label_Provuttag_AntalPåsar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Provuttag_AntalPåsar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_Provuttag_AntalPåsar.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_Provuttag_AntalPåsar.Location = new System.Drawing.Point(3, 104);
            this.label_Provuttag_AntalPåsar.Name = "label_Provuttag_AntalPåsar";
            this.label_Provuttag_AntalPåsar.Size = new System.Drawing.Size(144, 23);
            this.label_Provuttag_AntalPåsar.TabIndex = 0;
            this.label_Provuttag_AntalPåsar.Text = "Antal Påsar:";
            this.label_Provuttag_AntalPåsar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_ProvuttagsInfo_PåsarMellanProv
            // 
            this.label_ProvuttagsInfo_PåsarMellanProv.AutoSize = true;
            this.label_ProvuttagsInfo_PåsarMellanProv.BackColor = System.Drawing.Color.Transparent;
            this.label_ProvuttagsInfo_PåsarMellanProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProvuttagsInfo_PåsarMellanProv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_ProvuttagsInfo_PåsarMellanProv.ForeColor = System.Drawing.Color.FloralWhite;
            this.label_ProvuttagsInfo_PåsarMellanProv.Location = new System.Drawing.Point(3, 127);
            this.label_ProvuttagsInfo_PåsarMellanProv.Name = "label_ProvuttagsInfo_PåsarMellanProv";
            this.label_ProvuttagsInfo_PåsarMellanProv.Size = new System.Drawing.Size(144, 41);
            this.label_ProvuttagsInfo_PåsarMellanProv.TabIndex = 0;
            this.label_ProvuttagsInfo_PåsarMellanProv.Text = "Påsar mellan varje prov:";
            this.label_ProvuttagsInfo_PåsarMellanProv.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_StartPåse
            // 
            this.tb_StartPåse.BackColor = System.Drawing.Color.Khaki;
            this.tb_StartPåse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_StartPåse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_StartPåse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tb_StartPåse.ForeColor = System.Drawing.Color.Gray;
            this.tb_StartPåse.Location = new System.Drawing.Point(150, 35);
            this.tb_StartPåse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_StartPåse.MaxLength = 4;
            this.tb_StartPåse.Multiline = true;
            this.tb_StartPåse.Name = "tb_StartPåse";
            this.tb_StartPåse.Size = new System.Drawing.Size(33, 22);
            this.tb_StartPåse.TabIndex = 1;
            this.tb_StartPåse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_StartPåse.Enter += new System.EventHandler(this.ProvInfo_Enter);
            this.tb_StartPåse.Leave += new System.EventHandler(this.ProvInfo_Leave);
            // 
            // tb_SlutPåse
            // 
            this.tb_SlutPåse.BackColor = System.Drawing.Color.Khaki;
            this.tb_SlutPåse.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_SlutPåse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_SlutPåse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tb_SlutPåse.ForeColor = System.Drawing.Color.Gray;
            this.tb_SlutPåse.Location = new System.Drawing.Point(150, 58);
            this.tb_SlutPåse.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_SlutPåse.MaxLength = 5;
            this.tb_SlutPåse.Multiline = true;
            this.tb_SlutPåse.Name = "tb_SlutPåse";
            this.tb_SlutPåse.Size = new System.Drawing.Size(33, 22);
            this.tb_SlutPåse.TabIndex = 1;
            this.tb_SlutPåse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_SlutPåse.Enter += new System.EventHandler(this.ProvInfo_Enter);
            this.tb_SlutPåse.Leave += new System.EventHandler(this.ProvInfo_Leave);
            // 
            // tb_AntalProver
            // 
            this.tb_AntalProver.BackColor = System.Drawing.Color.Khaki;
            this.tb_AntalProver.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_AntalProver.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_AntalProver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.tb_AntalProver.ForeColor = System.Drawing.Color.Gray;
            this.tb_AntalProver.Location = new System.Drawing.Point(150, 81);
            this.tb_AntalProver.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tb_AntalProver.MaxLength = 3;
            this.tb_AntalProver.Multiline = true;
            this.tb_AntalProver.Name = "tb_AntalProver";
            this.tb_AntalProver.Size = new System.Drawing.Size(33, 22);
            this.tb_AntalProver.TabIndex = 1;
            this.tb_AntalProver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_AntalProver.Enter += new System.EventHandler(this.ProvInfo_Enter);
            this.tb_AntalProver.Leave += new System.EventHandler(this.ProvInfo_Leave);
            // 
            // label_ProvInfo_Rubrik
            // 
            this.label_ProvInfo_Rubrik.AutoSize = true;
            this.label_ProvInfo_Rubrik.BackColor = System.Drawing.Color.Transparent;
            this.tlp_ProvInfo.SetColumnSpan(this.label_ProvInfo_Rubrik, 2);
            this.label_ProvInfo_Rubrik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProvInfo_Rubrik.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.label_ProvInfo_Rubrik.ForeColor = System.Drawing.Color.Moccasin;
            this.label_ProvInfo_Rubrik.Location = new System.Drawing.Point(0, 0);
            this.label_ProvInfo_Rubrik.Margin = new System.Windows.Forms.Padding(0);
            this.label_ProvInfo_Rubrik.Name = "label_ProvInfo_Rubrik";
            this.label_ProvInfo_Rubrik.Size = new System.Drawing.Size(183, 35);
            this.label_ProvInfo_Rubrik.TabIndex = 3;
            this.label_ProvInfo_Rubrik.Text = "ProvuttagsInfo";
            this.label_ProvInfo_Rubrik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_ProvInfo_Påsar
            // 
            this.dgv_ProvInfo_Påsar.AllowUserToDeleteRows = false;
            this.dgv_ProvInfo_Påsar.AllowUserToResizeColumns = false;
            this.dgv_ProvInfo_Påsar.AllowUserToResizeRows = false;
            this.dgv_ProvInfo_Påsar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.dgv_ProvInfo_Påsar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_ProvInfo_Påsar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ProvInfo_Påsar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ProvInfo_Påsar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProvInfo_Påsar.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FloralWhite;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ProvInfo_Påsar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ProvInfo_Påsar.Location = new System.Drawing.Point(188, 35);
            this.dgv_ProvInfo_Påsar.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.dgv_ProvInfo_Påsar.MultiSelect = false;
            this.dgv_ProvInfo_Påsar.Name = "dgv_ProvInfo_Påsar";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ProvInfo_Påsar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_ProvInfo_Påsar.RowHeadersVisible = false;
            this.tlp_ProvInfo.SetRowSpan(this.dgv_ProvInfo_Påsar, 5);
            this.dgv_ProvInfo_Påsar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_ProvInfo_Påsar.Size = new System.Drawing.Size(50, 113);
            this.dgv_ProvInfo_Påsar.TabIndex = 4;
            // 
            // lbl_AntalPåsar
            // 
            this.lbl_AntalPåsar.AutoSize = true;
            this.lbl_AntalPåsar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_AntalPåsar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_AntalPåsar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_AntalPåsar.Location = new System.Drawing.Point(150, 104);
            this.lbl_AntalPåsar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_AntalPåsar.Name = "lbl_AntalPåsar";
            this.lbl_AntalPåsar.Size = new System.Drawing.Size(33, 22);
            this.lbl_AntalPåsar.TabIndex = 5;
            this.lbl_AntalPåsar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_PåsarMellanProv
            // 
            this.lbl_PåsarMellanProv.AutoSize = true;
            this.lbl_PåsarMellanProv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_PåsarMellanProv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_PåsarMellanProv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_PåsarMellanProv.Location = new System.Drawing.Point(150, 127);
            this.lbl_PåsarMellanProv.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.lbl_PåsarMellanProv.Name = "lbl_PåsarMellanProv";
            this.lbl_PåsarMellanProv.Size = new System.Drawing.Size(33, 40);
            this.lbl_PåsarMellanProv.TabIndex = 6;
            this.lbl_PåsarMellanProv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer_Update_ProvuttagInfo
            // 
            this.timer_Update_ProvuttagInfo.Enabled = true;
            this.timer_Update_ProvuttagInfo.Interval = 600000;
            this.timer_Update_ProvuttagInfo.Tick += new System.EventHandler(this.timer_Update_ProvuttagInfo_Tick);
            // 
            // Main_ProvUttag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.tlp_ProvInfo);
            this.Name = "Main_ProvUttag";
            this.Size = new System.Drawing.Size(243, 168);
            this.tlp_ProvInfo.ResumeLayout(false);
            this.tlp_ProvInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Provuttagsinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProvInfo_Påsar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public TableLayoutPanel tlp_ProvInfo;
        private Label label_Provuttag_StartPåse;
        private Label label_Provuttag_SlutPåse;
        private Label label_Provuttag_AntalProver;
        private PictureBox pb_Info_Provuttagsinfo;
        private Label label_Provuttag_AntalPåsar;
        private Label label_ProvuttagsInfo_PåsarMellanProv;
        private TextBox tb_StartPåse;
        private TextBox tb_SlutPåse;
        private TextBox tb_AntalProver;
        private Label label_ProvInfo_Rubrik;
        private DataGridView dgv_ProvInfo_Påsar;
        private Label lbl_AntalPåsar;
        private Label lbl_PåsarMellanProv;
        private System.Windows.Forms.Timer timer_Update_ProvuttagInfo;
    }
}
