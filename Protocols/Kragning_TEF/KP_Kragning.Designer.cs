using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Kragning_TEF
{
    partial class KP_Kragning
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Korprotokoll = new System.Windows.Forms.DataGridView();
            this.Tryckluft_Fasthållning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tryckluft_Finmatning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Induktion_Värme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Induktion_Kylning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verktyg_PTFE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verktyg_PTFE_OD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verktyg_Kragningsdon_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Verktyg_Kragningsdon_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Datum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnstNr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Korprotokoll_Inputdata = new System.Windows.Forms.DataGridView();
            this.col_Fasthållning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Finmatning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Värme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Kylning = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PTFEid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_PTFEod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Kragdon_MIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Kragdon_MAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Transfer = new System.Windows.Forms.Button();
            this.btn_Discard = new System.Windows.Forms.Button();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Korprotokoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Korprotokoll_Inputdata)).BeginInit();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.btn_Discard, 0, 1);
            this.tlp_Main.Controls.Add(this.dgv_Korprotokoll, 1, 1);
            this.tlp_Main.Controls.Add(this.dgv_Korprotokoll_Inputdata, 1, 0);
            this.tlp_Main.Controls.Add(this.btn_Transfer, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlp_Main.Size = new System.Drawing.Size(481, 129);
            this.tlp_Main.TabIndex = 0;
            // 
            // dgv_Korprotokoll
            // 
            this.dgv_Korprotokoll.AllowUserToAddRows = false;
            this.dgv_Korprotokoll.AllowUserToDeleteRows = false;
            this.dgv_Korprotokoll.AllowUserToResizeColumns = false;
            this.dgv_Korprotokoll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_Korprotokoll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Korprotokoll.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Korprotokoll.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Korprotokoll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Korprotokoll.ColumnHeadersVisible = false;
            this.dgv_Korprotokoll.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Tryckluft_Fasthållning,
            this.Tryckluft_Finmatning,
            this.Induktion_Värme,
            this.Induktion_Kylning,
            this.Verktyg_PTFE_ID,
            this.Verktyg_PTFE_OD,
            this.Verktyg_Kragningsdon_MIN,
            this.Verktyg_Kragningsdon_MAX,
            this.Datum,
            this.AnstNr,
            this.Sign});
            this.dgv_Korprotokoll.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Korprotokoll.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Korprotokoll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Korprotokoll.Location = new System.Drawing.Point(31, 22);
            this.dgv_Korprotokoll.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.dgv_Korprotokoll.MultiSelect = false;
            this.dgv_Korprotokoll.Name = "dgv_Korprotokoll";
            this.dgv_Korprotokoll.ReadOnly = true;
            this.dgv_Korprotokoll.RowHeadersVisible = false;
            this.dgv_Korprotokoll.RowTemplate.Height = 18;
            this.dgv_Korprotokoll.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Korprotokoll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Korprotokoll.Size = new System.Drawing.Size(450, 107);
            this.dgv_Korprotokoll.TabIndex = 1013;
            this.dgv_Korprotokoll.Leave += new System.EventHandler(this.dgv_Korprotokoll_Leave);
            // 
            // Tryckluft_Fasthållning
            // 
            this.Tryckluft_Fasthållning.HeaderText = "Fasthållning";
            this.Tryckluft_Fasthållning.Name = "Tryckluft_Fasthållning";
            this.Tryckluft_Fasthållning.ReadOnly = true;
            this.Tryckluft_Fasthållning.Width = 52;
            // 
            // Tryckluft_Finmatning
            // 
            this.Tryckluft_Finmatning.HeaderText = "Finmatning";
            this.Tryckluft_Finmatning.Name = "Tryckluft_Finmatning";
            this.Tryckluft_Finmatning.ReadOnly = true;
            this.Tryckluft_Finmatning.Width = 53;
            // 
            // Induktion_Värme
            // 
            this.Induktion_Värme.HeaderText = "Värme";
            this.Induktion_Värme.Name = "Induktion_Värme";
            this.Induktion_Värme.ReadOnly = true;
            this.Induktion_Värme.Width = 53;
            // 
            // Induktion_Kylning
            // 
            this.Induktion_Kylning.HeaderText = "Kylning";
            this.Induktion_Kylning.Name = "Induktion_Kylning";
            this.Induktion_Kylning.ReadOnly = true;
            this.Induktion_Kylning.Width = 53;
            // 
            // Verktyg_PTFE_ID
            // 
            this.Verktyg_PTFE_ID.HeaderText = "PTFE,ID";
            this.Verktyg_PTFE_ID.Name = "Verktyg_PTFE_ID";
            this.Verktyg_PTFE_ID.ReadOnly = true;
            this.Verktyg_PTFE_ID.Width = 55;
            // 
            // Verktyg_PTFE_OD
            // 
            this.Verktyg_PTFE_OD.HeaderText = "PTFE,OD";
            this.Verktyg_PTFE_OD.Name = "Verktyg_PTFE_OD";
            this.Verktyg_PTFE_OD.ReadOnly = true;
            this.Verktyg_PTFE_OD.Width = 57;
            // 
            // Verktyg_Kragningsdon_MIN
            // 
            this.Verktyg_Kragningsdon_MIN.HeaderText = "MIN";
            this.Verktyg_Kragningsdon_MIN.Name = "Verktyg_Kragningsdon_MIN";
            this.Verktyg_Kragningsdon_MIN.ReadOnly = true;
            this.Verktyg_Kragningsdon_MIN.Width = 50;
            // 
            // Verktyg_Kragningsdon_MAX
            // 
            this.Verktyg_Kragningsdon_MAX.HeaderText = "MAX";
            this.Verktyg_Kragningsdon_MAX.Name = "Verktyg_Kragningsdon_MAX";
            this.Verktyg_Kragningsdon_MAX.ReadOnly = true;
            this.Verktyg_Kragningsdon_MAX.Width = 50;
            // 
            // Datum
            // 
            this.Datum.HeaderText = "Datum";
            this.Datum.Name = "Datum";
            this.Datum.ReadOnly = true;
            this.Datum.Width = 140;
            // 
            // AnstNr
            // 
            this.AnstNr.HeaderText = "AnstNr";
            this.AnstNr.Name = "AnstNr";
            this.AnstNr.ReadOnly = true;
            this.AnstNr.Width = 52;
            // 
            // Sign
            // 
            this.Sign.HeaderText = "Sign";
            this.Sign.Name = "Sign";
            this.Sign.ReadOnly = true;
            this.Sign.Width = 52;
            // 
            // dgv_Korprotokoll_Inputdata
            // 
            this.dgv_Korprotokoll_Inputdata.AllowUserToAddRows = false;
            this.dgv_Korprotokoll_Inputdata.AllowUserToDeleteRows = false;
            this.dgv_Korprotokoll_Inputdata.AllowUserToResizeColumns = false;
            this.dgv_Korprotokoll_Inputdata.AllowUserToResizeRows = false;
            this.dgv_Korprotokoll_Inputdata.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.dgv_Korprotokoll_Inputdata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Korprotokoll_Inputdata.ColumnHeadersVisible = false;
            this.dgv_Korprotokoll_Inputdata.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_Fasthållning,
            this.col_Finmatning,
            this.col_Värme,
            this.col_Kylning,
            this.col_PTFEid,
            this.col_PTFEod,
            this.col_Kragdon_MIN,
            this.col_Kragdon_MAX});
            this.dgv_Korprotokoll_Inputdata.Cursor = System.Windows.Forms.Cursors.IBeam;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Courier New", 8.25F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.DarkSlateGray;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Korprotokoll_Inputdata.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Korprotokoll_Inputdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Korprotokoll_Inputdata.Location = new System.Drawing.Point(30, 0);
            this.dgv_Korprotokoll_Inputdata.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Korprotokoll_Inputdata.Name = "dgv_Korprotokoll_Inputdata";
            this.dgv_Korprotokoll_Inputdata.RowHeadersVisible = false;
            this.dgv_Korprotokoll_Inputdata.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_Korprotokoll_Inputdata.Size = new System.Drawing.Size(451, 22);
            this.dgv_Korprotokoll_Inputdata.TabIndex = 1011;
            this.dgv_Korprotokoll_Inputdata.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellLeave_CellValidated);
            this.dgv_Korprotokoll_Inputdata.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.EditingControlShowing);
            // 
            // col_Fasthållning
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Fasthållning.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Fasthållning.HeaderText = "Fasthållning";
            this.col_Fasthållning.Name = "col_Fasthållning";
            this.col_Fasthållning.Width = 52;
            // 
            // col_Finmatning
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Finmatning.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_Finmatning.HeaderText = "Finmatning";
            this.col_Finmatning.Name = "col_Finmatning";
            this.col_Finmatning.Width = 53;
            // 
            // col_Värme
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Värme.DefaultCellStyle = dataGridViewCellStyle5;
            this.col_Värme.HeaderText = "Värme";
            this.col_Värme.Name = "col_Värme";
            this.col_Värme.Width = 53;
            // 
            // col_Kylning
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Kylning.DefaultCellStyle = dataGridViewCellStyle6;
            this.col_Kylning.HeaderText = "Kylning";
            this.col_Kylning.Name = "col_Kylning";
            this.col_Kylning.Width = 53;
            // 
            // col_PTFEid
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_PTFEid.DefaultCellStyle = dataGridViewCellStyle7;
            this.col_PTFEid.HeaderText = "PTFE, ID";
            this.col_PTFEid.Name = "col_PTFEid";
            this.col_PTFEid.Width = 55;
            // 
            // col_PTFEod
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_PTFEod.DefaultCellStyle = dataGridViewCellStyle8;
            this.col_PTFEod.HeaderText = "PTFE, OD";
            this.col_PTFEod.Name = "col_PTFEod";
            this.col_PTFEod.Width = 57;
            // 
            // col_Kragdon_MIN
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Kragdon_MIN.DefaultCellStyle = dataGridViewCellStyle9;
            this.col_Kragdon_MIN.HeaderText = "Kragningsdon MIN";
            this.col_Kragdon_MIN.Name = "col_Kragdon_MIN";
            this.col_Kragdon_MIN.Width = 50;
            // 
            // col_Kragdon_MAX
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Kragdon_MAX.DefaultCellStyle = dataGridViewCellStyle10;
            this.col_Kragdon_MAX.HeaderText = "Kragningsdon MAX";
            this.col_Kragdon_MAX.Name = "col_Kragdon_MAX";
            this.col_Kragdon_MAX.Width = 50;
            // 
            // btn_Transfer
            // 
            this.btn_Transfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_Transfer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Transfer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Transfer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_Transfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Transfer.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.btn_Transfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_Transfer.Location = new System.Drawing.Point(0, 0);
            this.btn_Transfer.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Transfer.Name = "btn_Transfer";
            this.btn_Transfer.Size = new System.Drawing.Size(30, 22);
            this.btn_Transfer.TabIndex = 1015;
            this.btn_Transfer.Text = "→";
            this.btn_Transfer.UseCompatibleTextRendering = true;
            this.btn_Transfer.UseVisualStyleBackColor = false;
            this.btn_Transfer.Click += new System.EventHandler(this.Transfer_Click);
            // 
            // btn_Discard
            // 
            this.btn_Discard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_Discard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Discard.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Discard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btn_Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Discard.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.btn_Discard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Discard.Location = new System.Drawing.Point(0, 22);
            this.btn_Discard.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Discard.Name = "btn_Discard";
            this.btn_Discard.Size = new System.Drawing.Size(30, 28);
            this.btn_Discard.TabIndex = 1016;
            this.btn_Discard.Text = "→";
            this.btn_Discard.UseCompatibleTextRendering = true;
            this.btn_Discard.UseVisualStyleBackColor = false;
            this.btn_Discard.Click += new System.EventHandler(this.Kassera_Rad_Click);
            // 
            // KP_Kragning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "KP_Kragning";
            this.Size = new System.Drawing.Size(481, 129);
            this.tlp_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Korprotokoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Korprotokoll_Inputdata)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private DataGridView dgv_Korprotokoll_Inputdata;
        private DataGridViewTextBoxColumn col_Fasthållning;
        private DataGridViewTextBoxColumn col_Finmatning;
        private DataGridViewTextBoxColumn col_Värme;
        private DataGridViewTextBoxColumn col_Kylning;
        private DataGridViewTextBoxColumn col_PTFEid;
        private DataGridViewTextBoxColumn col_PTFEod;
        private DataGridViewTextBoxColumn col_Kragdon_MIN;
        private DataGridViewTextBoxColumn col_Kragdon_MAX;
        public DataGridView dgv_Korprotokoll;
        private DataGridViewTextBoxColumn Tryckluft_Fasthållning;
        private DataGridViewTextBoxColumn Tryckluft_Finmatning;
        private DataGridViewTextBoxColumn Induktion_Värme;
        private DataGridViewTextBoxColumn Induktion_Kylning;
        private DataGridViewTextBoxColumn Verktyg_PTFE_ID;
        private DataGridViewTextBoxColumn Verktyg_PTFE_OD;
        private DataGridViewTextBoxColumn Verktyg_Kragningsdon_MIN;
        private DataGridViewTextBoxColumn Verktyg_Kragningsdon_MAX;
        private DataGridViewTextBoxColumn Datum;
        private DataGridViewTextBoxColumn AnstNr;
        private DataGridViewTextBoxColumn Sign;
        private Button btn_Discard;
        private Button btn_Transfer;
    }
}
