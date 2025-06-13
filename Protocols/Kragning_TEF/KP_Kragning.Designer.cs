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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            tlp_Main = new TableLayoutPanel();
            btn_Discard = new Button();
            dgv_Korprotokoll = new DataGridView();
            dgv_Korprotokoll_Inputdata = new DataGridView();
            btn_Transfer = new Button();
            Tryckluft_Fasthållning = new DataGridViewTextBoxColumn();
            Tryckluft_Finmatning = new DataGridViewTextBoxColumn();
            Induktion_Värme = new DataGridViewTextBoxColumn();
            Induktion_Kylning = new DataGridViewTextBoxColumn();
            Verktyg_PTFE_ID = new DataGridViewTextBoxColumn();
            Verktyg_PTFE_OD = new DataGridViewTextBoxColumn();
            Verktyg_Kragningsdon_MIN = new DataGridViewTextBoxColumn();
            Verktyg_Kragningsdon_MAX = new DataGridViewTextBoxColumn();
            Datum = new DataGridViewTextBoxColumn();
            AnstNr = new DataGridViewTextBoxColumn();
            Sign = new DataGridViewTextBoxColumn();
            col_Fasthållning = new DataGridViewTextBoxColumn();
            col_Finmatning = new DataGridViewTextBoxColumn();
            col_Värme = new DataGridViewTextBoxColumn();
            col_Kylning = new DataGridViewTextBoxColumn();
            col_PTFEid = new DataGridViewTextBoxColumn();
            col_PTFEod = new DataGridViewTextBoxColumn();
            col_Kragdon_MIN = new DataGridViewTextBoxColumn();
            col_Kragdon_MAX = new DataGridViewTextBoxColumn();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv_Korprotokoll).BeginInit();
            ((ISupportInitialize)dgv_Korprotokoll_Inputdata).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 35F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(btn_Discard, 0, 1);
            tlp_Main.Controls.Add(dgv_Korprotokoll, 1, 1);
            tlp_Main.Controls.Add(dgv_Korprotokoll_Inputdata, 1, 0);
            tlp_Main.Controls.Add(btn_Transfer, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tlp_Main.RowStyles.Add(new RowStyle());
            tlp_Main.Size = new Size(561, 149);
            tlp_Main.TabIndex = 0;
            // 
            // btn_Discard
            // 
            btn_Discard.BackColor = Color.FromArgb(255, 199, 206);
            btn_Discard.Dock = DockStyle.Top;
            btn_Discard.FlatAppearance.BorderColor = Color.FromArgb(156, 0, 6);
            btn_Discard.FlatAppearance.MouseOverBackColor = Color.Black;
            btn_Discard.FlatStyle = FlatStyle.Flat;
            btn_Discard.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btn_Discard.ForeColor = Color.FromArgb(156, 0, 6);
            btn_Discard.Location = new Point(0, 25);
            btn_Discard.Margin = new Padding(0);
            btn_Discard.Name = "btn_Discard";
            btn_Discard.Size = new Size(35, 32);
            btn_Discard.TabIndex = 1016;
            btn_Discard.Text = "→";
            btn_Discard.UseCompatibleTextRendering = true;
            btn_Discard.UseVisualStyleBackColor = false;
            btn_Discard.Click += Kassera_Rad_Click;
            // 
            // dgv_Korprotokoll
            // 
            dgv_Korprotokoll.AllowUserToAddRows = false;
            dgv_Korprotokoll.AllowUserToDeleteRows = false;
            dgv_Korprotokoll.AllowUserToResizeColumns = false;
            dgv_Korprotokoll.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dgv_Korprotokoll.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Korprotokoll.BackgroundColor = Color.White;
            dgv_Korprotokoll.BorderStyle = BorderStyle.None;
            dgv_Korprotokoll.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Korprotokoll.ColumnHeadersVisible = false;
            dgv_Korprotokoll.Columns.AddRange(new DataGridViewColumn[] { Tryckluft_Fasthållning, Tryckluft_Finmatning, Induktion_Värme, Induktion_Kylning, Verktyg_PTFE_ID, Verktyg_PTFE_OD, Verktyg_Kragningsdon_MIN, Verktyg_Kragningsdon_MAX, Datum, AnstNr, Sign });
            dgv_Korprotokoll.Cursor = Cursors.IBeam;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Courier New", 8.5F);
            dataGridViewCellStyle2.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_Korprotokoll.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_Korprotokoll.Dock = DockStyle.Fill;
            dgv_Korprotokoll.Location = new Point(36, 25);
            dgv_Korprotokoll.Margin = new Padding(1, 0, 0, 0);
            dgv_Korprotokoll.MultiSelect = false;
            dgv_Korprotokoll.Name = "dgv_Korprotokoll";
            dgv_Korprotokoll.ReadOnly = true;
            dgv_Korprotokoll.RowHeadersVisible = false;
            dgv_Korprotokoll.RowTemplate.Height = 18;
            dgv_Korprotokoll.ScrollBars = ScrollBars.None;
            dgv_Korprotokoll.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Korprotokoll.Size = new Size(525, 124);
            dgv_Korprotokoll.TabIndex = 1013;
            dgv_Korprotokoll.Leave += dgv_Korprotokoll_Leave;
            // 
            // dgv_Korprotokoll_Inputdata
            // 
            dgv_Korprotokoll_Inputdata.AllowUserToAddRows = false;
            dgv_Korprotokoll_Inputdata.AllowUserToDeleteRows = false;
            dgv_Korprotokoll_Inputdata.AllowUserToResizeColumns = false;
            dgv_Korprotokoll_Inputdata.AllowUserToResizeRows = false;
            dgv_Korprotokoll_Inputdata.BackgroundColor = Color.FromArgb(80, 80, 80);
            dgv_Korprotokoll_Inputdata.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Korprotokoll_Inputdata.ColumnHeadersVisible = false;
            dgv_Korprotokoll_Inputdata.Columns.AddRange(new DataGridViewColumn[] { col_Fasthållning, col_Finmatning, col_Värme, col_Kylning, col_PTFEid, col_PTFEod, col_Kragdon_MIN, col_Kragdon_MAX });
            dgv_Korprotokoll_Inputdata.Cursor = Cursors.IBeam;
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Courier New", 8.25F);
            dataGridViewCellStyle11.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dgv_Korprotokoll_Inputdata.DefaultCellStyle = dataGridViewCellStyle11;
            dgv_Korprotokoll_Inputdata.Dock = DockStyle.Fill;
            dgv_Korprotokoll_Inputdata.Location = new Point(35, 0);
            dgv_Korprotokoll_Inputdata.Margin = new Padding(0);
            dgv_Korprotokoll_Inputdata.Name = "dgv_Korprotokoll_Inputdata";
            dgv_Korprotokoll_Inputdata.RowHeadersVisible = false;
            dgv_Korprotokoll_Inputdata.ScrollBars = ScrollBars.None;
            dgv_Korprotokoll_Inputdata.Size = new Size(526, 25);
            dgv_Korprotokoll_Inputdata.TabIndex = 1011;
            dgv_Korprotokoll_Inputdata.CellValidated += CellLeave_CellValidated;
            dgv_Korprotokoll_Inputdata.EditingControlShowing += EditingControlShowing;
            // 
            // btn_Transfer
            // 
            btn_Transfer.BackColor = Color.FromArgb(198, 239, 206);
            btn_Transfer.Dock = DockStyle.Fill;
            btn_Transfer.FlatAppearance.BorderColor = Color.FromArgb(0, 97, 0);
            btn_Transfer.FlatAppearance.MouseOverBackColor = Color.Black;
            btn_Transfer.FlatStyle = FlatStyle.Flat;
            btn_Transfer.Font = new Font("Times New Roman", 14F, FontStyle.Bold);
            btn_Transfer.ForeColor = Color.FromArgb(0, 97, 0);
            btn_Transfer.Location = new Point(0, 0);
            btn_Transfer.Margin = new Padding(0);
            btn_Transfer.Name = "btn_Transfer";
            btn_Transfer.Size = new Size(35, 25);
            btn_Transfer.TabIndex = 1015;
            btn_Transfer.Text = "→";
            btn_Transfer.UseCompatibleTextRendering = true;
            btn_Transfer.UseVisualStyleBackColor = false;
            btn_Transfer.Click += Transfer_Click;
            // 
            // Tryckluft_Fasthållning
            // 
            Tryckluft_Fasthållning.HeaderText = "Fasthållning";
            Tryckluft_Fasthållning.Name = "Tryckluft_Fasthållning";
            Tryckluft_Fasthållning.ReadOnly = true;
            Tryckluft_Fasthållning.Width = 61;
            // 
            // Tryckluft_Finmatning
            // 
            Tryckluft_Finmatning.HeaderText = "Finmatning";
            Tryckluft_Finmatning.Name = "Tryckluft_Finmatning";
            Tryckluft_Finmatning.ReadOnly = true;
            Tryckluft_Finmatning.Width = 62;
            // 
            // Induktion_Värme
            // 
            Induktion_Värme.HeaderText = "Värme";
            Induktion_Värme.Name = "Induktion_Värme";
            Induktion_Värme.ReadOnly = true;
            Induktion_Värme.Width = 62;
            // 
            // Induktion_Kylning
            // 
            Induktion_Kylning.HeaderText = "Kylning";
            Induktion_Kylning.Name = "Induktion_Kylning";
            Induktion_Kylning.ReadOnly = true;
            Induktion_Kylning.Width = 62;
            // 
            // Verktyg_PTFE_ID
            // 
            Verktyg_PTFE_ID.HeaderText = "PTFE,ID";
            Verktyg_PTFE_ID.Name = "Verktyg_PTFE_ID";
            Verktyg_PTFE_ID.ReadOnly = true;
            Verktyg_PTFE_ID.Width = 63;
            // 
            // Verktyg_PTFE_OD
            // 
            Verktyg_PTFE_OD.HeaderText = "PTFE,OD";
            Verktyg_PTFE_OD.Name = "Verktyg_PTFE_OD";
            Verktyg_PTFE_OD.ReadOnly = true;
            Verktyg_PTFE_OD.Width = 66;
            // 
            // Verktyg_Kragningsdon_MIN
            // 
            Verktyg_Kragningsdon_MIN.HeaderText = "MIN";
            Verktyg_Kragningsdon_MIN.Name = "Verktyg_Kragningsdon_MIN";
            Verktyg_Kragningsdon_MIN.ReadOnly = true;
            Verktyg_Kragningsdon_MIN.Width = 59;
            // 
            // Verktyg_Kragningsdon_MAX
            // 
            Verktyg_Kragningsdon_MAX.HeaderText = "MAX";
            Verktyg_Kragningsdon_MAX.Name = "Verktyg_Kragningsdon_MAX";
            Verktyg_Kragningsdon_MAX.ReadOnly = true;
            Verktyg_Kragningsdon_MAX.Width = 60;
            // 
            // Datum
            // 
            Datum.HeaderText = "Datum";
            Datum.Name = "Datum";
            Datum.ReadOnly = true;
            Datum.Width = 163;
            // 
            // AnstNr
            // 
            AnstNr.HeaderText = "AnstNr";
            AnstNr.Name = "AnstNr";
            AnstNr.ReadOnly = true;
            AnstNr.Width = 57;
            // 
            // Sign
            // 
            Sign.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Sign.HeaderText = "Sign";
            Sign.Name = "Sign";
            Sign.ReadOnly = true;
            // 
            // col_Fasthållning
            // 
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_Fasthållning.DefaultCellStyle = dataGridViewCellStyle3;
            col_Fasthållning.HeaderText = "Fasthållning";
            col_Fasthållning.Name = "col_Fasthållning";
            col_Fasthållning.Width = 61;
            // 
            // col_Finmatning
            // 
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_Finmatning.DefaultCellStyle = dataGridViewCellStyle4;
            col_Finmatning.HeaderText = "Finmatning";
            col_Finmatning.Name = "col_Finmatning";
            col_Finmatning.Width = 62;
            // 
            // col_Värme
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_Värme.DefaultCellStyle = dataGridViewCellStyle5;
            col_Värme.HeaderText = "Värme";
            col_Värme.Name = "col_Värme";
            col_Värme.Width = 62;
            // 
            // col_Kylning
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_Kylning.DefaultCellStyle = dataGridViewCellStyle6;
            col_Kylning.HeaderText = "Kylning";
            col_Kylning.Name = "col_Kylning";
            col_Kylning.Width = 62;
            // 
            // col_PTFEid
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_PTFEid.DefaultCellStyle = dataGridViewCellStyle7;
            col_PTFEid.HeaderText = "PTFE, ID";
            col_PTFEid.Name = "col_PTFEid";
            col_PTFEid.Width = 63;
            // 
            // col_PTFEod
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_PTFEod.DefaultCellStyle = dataGridViewCellStyle8;
            col_PTFEod.HeaderText = "PTFE, OD";
            col_PTFEod.Name = "col_PTFEod";
            col_PTFEod.Width = 66;
            // 
            // col_Kragdon_MIN
            // 
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_Kragdon_MIN.DefaultCellStyle = dataGridViewCellStyle9;
            col_Kragdon_MIN.HeaderText = "Kragningsdon MIN";
            col_Kragdon_MIN.Name = "col_Kragdon_MIN";
            col_Kragdon_MIN.Width = 59;
            // 
            // col_Kragdon_MAX
            // 
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            col_Kragdon_MAX.DefaultCellStyle = dataGridViewCellStyle10;
            col_Kragdon_MAX.HeaderText = "Kragningsdon MAX";
            col_Kragdon_MAX.Name = "col_Kragdon_MAX";
            col_Kragdon_MAX.Width = 60;
            // 
            // KP_Kragning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "KP_Kragning";
            Size = new Size(561, 149);
            tlp_Main.ResumeLayout(false);
            ((ISupportInitialize)dgv_Korprotokoll).EndInit();
            ((ISupportInitialize)dgv_Korprotokoll_Inputdata).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private DataGridView dgv_Korprotokoll_Inputdata;
        public DataGridView dgv_Korprotokoll;
        private Button btn_Discard;
        private Button btn_Transfer;
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
        private DataGridViewTextBoxColumn col_Fasthållning;
        private DataGridViewTextBoxColumn col_Finmatning;
        private DataGridViewTextBoxColumn col_Värme;
        private DataGridViewTextBoxColumn col_Kylning;
        private DataGridViewTextBoxColumn col_PTFEid;
        private DataGridViewTextBoxColumn col_PTFEod;
        private DataGridViewTextBoxColumn col_Kragdon_MIN;
        private DataGridViewTextBoxColumn col_Kragdon_MAX;
    }
}
