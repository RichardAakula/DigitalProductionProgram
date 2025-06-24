using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    partial class Journal_Spolning_PTFE
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
            tlp_Main = new TableLayoutPanel();
            dgv_Journal = new DataGridView();
            dgv_Journal_Input = new DataGridView();
            panel_ExtraInfoLabels = new Panel();
            flp_Buttons = new FlowLayoutPanel();
            btn_SaveRow = new Button();
            btn_EditRow = new Button();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv_Journal).BeginInit();
            ((ISupportInitialize)dgv_Journal_Input).BeginInit();
            flp_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(35, 35, 35);
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(dgv_Journal, 0, 3);
            tlp_Main.Controls.Add(dgv_Journal_Input, 0, 2);
            tlp_Main.Controls.Add(panel_ExtraInfoLabels, 0, 1);
            tlp_Main.Controls.Add(flp_Buttons, 0, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 37F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 92F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1057, 330);
            tlp_Main.TabIndex = 4;
            // 
            // dgv_Journal
            // 
            dgv_Journal.AllowUserToAddRows = false;
            dgv_Journal.AllowUserToDeleteRows = false;
            dgv_Journal.AllowUserToResizeColumns = false;
            dgv_Journal.AllowUserToResizeRows = false;
            dgv_Journal.BackgroundColor = Color.White;
            dgv_Journal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Journal.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Courier New", 8.25F);
            dataGridViewCellStyle1.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Journal.DefaultCellStyle = dataGridViewCellStyle1;
            dgv_Journal.Dock = DockStyle.Fill;
            dgv_Journal.Location = new Point(0, 153);
            dgv_Journal.Margin = new Padding(0);
            dgv_Journal.Name = "dgv_Journal";
            dgv_Journal.ReadOnly = true;
            dgv_Journal.RowHeadersVisible = false;
            dgv_Journal.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_Journal.Size = new Size(1057, 177);
            dgv_Journal.TabIndex = 3;
            dgv_Journal.CellMouseDoubleClick += CopyRow_CellMouseDoubleClick;
            // 
            // dgv_Journal_Input
            // 
            dgv_Journal_Input.AllowUserToAddRows = false;
            dgv_Journal_Input.AllowUserToDeleteRows = false;
            dgv_Journal_Input.AllowUserToResizeColumns = false;
            dgv_Journal_Input.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 7.25F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Journal_Input.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Journal_Input.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Journal_Input.Dock = DockStyle.Fill;
            dgv_Journal_Input.Location = new Point(0, 61);
            dgv_Journal_Input.Margin = new Padding(0);
            dgv_Journal_Input.Name = "dgv_Journal_Input";
            dgv_Journal_Input.RowHeadersVisible = false;
            dgv_Journal_Input.Size = new Size(1057, 92);
            dgv_Journal_Input.TabIndex = 2;
            dgv_Journal_Input.CellClick += Journal_Input_CellClick;
            dgv_Journal_Input.CellEnter += Journal_Input_CellEnter;
            dgv_Journal_Input.CellValueChanged += Journal_Input_CellValueChanged;
            dgv_Journal_Input.ColumnHeaderMouseClick += dgv_Journal_Input_ColumnHeaderMouseClick;
            dgv_Journal_Input.EditingControlShowing += EditingControlShowing;
            // 
            // panel_ExtraInfoLabels
            // 
            panel_ExtraInfoLabels.BackColor = Color.White;
            panel_ExtraInfoLabels.Dock = DockStyle.Fill;
            panel_ExtraInfoLabels.Location = new Point(1, 38);
            panel_ExtraInfoLabels.Margin = new Padding(1, 1, 1, 0);
            panel_ExtraInfoLabels.Name = "panel_ExtraInfoLabels";
            panel_ExtraInfoLabels.Size = new Size(1055, 23);
            panel_ExtraInfoLabels.TabIndex = 50;
            // 
            // flp_Buttons
            // 
            flp_Buttons.Controls.Add(btn_SaveRow);
            flp_Buttons.Controls.Add(btn_EditRow);
            flp_Buttons.Location = new Point(0, 0);
            flp_Buttons.Margin = new Padding(0);
            flp_Buttons.Name = "flp_Buttons";
            flp_Buttons.Size = new Size(986, 36);
            flp_Buttons.TabIndex = 52;
            // 
            // btn_SaveRow
            // 
            btn_SaveRow.BackColor = Color.FromArgb(50, 50, 50);
            btn_SaveRow.FlatAppearance.BorderColor = Color.FromArgb(198, 239, 206);
            btn_SaveRow.FlatAppearance.BorderSize = 3;
            btn_SaveRow.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 97, 0);
            btn_SaveRow.FlatStyle = FlatStyle.Flat;
            btn_SaveRow.Font = new Font("Palatino Linotype", 9F);
            btn_SaveRow.ForeColor = Color.White;
            btn_SaveRow.Location = new Point(6, 1);
            btn_SaveRow.Margin = new Padding(6, 1, 6, 1);
            btn_SaveRow.Name = "btn_SaveRow";
            btn_SaveRow.Size = new Size(135, 33);
            btn_SaveRow.TabIndex = 49;
            btn_SaveRow.Text = "Spara Rad";
            btn_SaveRow.UseVisualStyleBackColor = false;
            btn_SaveRow.Click += SaveRow_Click;
            // 
            // btn_EditRow
            // 
            btn_EditRow.BackColor = Color.FromArgb(50, 50, 50);
            btn_EditRow.FlatAppearance.BorderColor = Color.FromArgb(156, 101, 0);
            btn_EditRow.FlatAppearance.BorderSize = 3;
            btn_EditRow.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 235, 156);
            btn_EditRow.FlatStyle = FlatStyle.Flat;
            btn_EditRow.Font = new Font("Palatino Linotype", 9F);
            btn_EditRow.ForeColor = Color.White;
            btn_EditRow.Location = new Point(176, 1);
            btn_EditRow.Margin = new Padding(29, 1, 6, 1);
            btn_EditRow.Name = "btn_EditRow";
            btn_EditRow.Size = new Size(138, 33);
            btn_EditRow.TabIndex = 51;
            btn_EditRow.Text = "Redigera Rad";
            btn_EditRow.UseVisualStyleBackColor = false;
            btn_EditRow.Click += EditRow_Click;
            // 
            // Journal_Spolning_PTFE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Journal_Spolning_PTFE";
            Size = new Size(1057, 330);
            Load += Journal_Spolning_PTFE_Load;
            tlp_Main.ResumeLayout(false);
            ((ISupportInitialize)dgv_Journal).EndInit();
            ((ISupportInitialize)dgv_Journal_Input).EndInit();
            flp_Buttons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public Button btn_SaveRow;
        private DataGridView dgv_Journal;
        private Panel panel_ExtraInfoLabels;
        public DataGridView dgv_Journal_Input;
        public Button btn_EditRow;
        private FlowLayoutPanel flp_Buttons;
    }
}
