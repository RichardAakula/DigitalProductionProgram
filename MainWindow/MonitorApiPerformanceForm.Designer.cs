namespace DigitalProductionProgram.MainWindow
{
    partial class MonitorApiPerformanceForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tlp_Main = new TableLayoutPanel();
            tlp_ControlPanel = new TableLayoutPanel();
            label_Factory = new Label();
            cb_Factory = new ComboBox();
            label_Query = new Label();
            cb_Query = new ComboBox();
            label_Loops = new Label();
            num_Loops = new NumericUpDown();
            btn_Run = new Button();
            btn_Export = new Button();
            label_Summary = new Label();
            pbar_ProgressBar = new ProgressBar();
            lv_Results = new ListView();
            col_Loop = new ColumnHeader();
            col_Time = new ColumnHeader();
            col_Result = new ColumnHeader();
            col_Rows = new ColumnHeader();
            col_Timestamp = new ColumnHeader();
            tlp_Main.SuspendLayout();
            tlp_ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Loops).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.Controls.Add(tlp_ControlPanel, 0, 0);
            tlp_Main.Controls.Add(label_Summary, 0, 1);
            tlp_Main.Controls.Add(pbar_ProgressBar, 0, 2);
            tlp_Main.Controls.Add(lv_Results, 0, 3);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(16, 16);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 74F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(1002, 628);
            tlp_Main.TabIndex = 0;
            // 
            // tlp_ControlPanel
            // 
            tlp_ControlPanel.BackColor = Color.FromArgb(81, 85, 92);
            tlp_ControlPanel.ColumnCount = 8;
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_ControlPanel.Controls.Add(label_Factory, 0, 0);
            tlp_ControlPanel.Controls.Add(cb_Factory, 1, 0);
            tlp_ControlPanel.Controls.Add(label_Query, 2, 0);
            tlp_ControlPanel.Controls.Add(cb_Query, 3, 0);
            tlp_ControlPanel.Controls.Add(label_Loops, 4, 0);
            tlp_ControlPanel.Controls.Add(num_Loops, 5, 0);
            tlp_ControlPanel.Controls.Add(btn_Run, 6, 0);
            tlp_ControlPanel.Controls.Add(btn_Export, 6, 1);
            tlp_ControlPanel.Dock = DockStyle.Fill;
            tlp_ControlPanel.Location = new Point(3, 3);
            tlp_ControlPanel.Name = "tlp_ControlPanel";
            tlp_ControlPanel.Padding = new Padding(12);
            tlp_ControlPanel.RowCount = 2;
            tlp_ControlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_ControlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_ControlPanel.Size = new Size(996, 80);
            tlp_ControlPanel.TabIndex = 0;
            // 
            // label_Factory
            // 
            label_Factory.Dock = DockStyle.Fill;
            label_Factory.ForeColor = Color.FromArgb(239, 228, 177);
            label_Factory.Location = new Point(15, 12);
            label_Factory.Name = "label_Factory";
            label_Factory.Size = new Size(84, 28);
            label_Factory.TabIndex = 0;
            label_Factory.Text = "Factory";
            label_Factory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_Factory
            // 
            cb_Factory.Dock = DockStyle.Fill;
            cb_Factory.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Factory.FormattingEnabled = true;
            cb_Factory.Location = new Point(105, 15);
            cb_Factory.Name = "cb_Factory";
            cb_Factory.Size = new Size(184, 23);
            cb_Factory.TabIndex = 1;
            // 
            // label_Query
            // 
            label_Query.Dock = DockStyle.Fill;
            label_Query.ForeColor = Color.FromArgb(239, 228, 177);
            label_Query.Location = new Point(295, 12);
            label_Query.Name = "label_Query";
            label_Query.Size = new Size(84, 28);
            label_Query.TabIndex = 2;
            label_Query.Text = "API-fråga";
            label_Query.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_Query
            // 
            cb_Query.Dock = DockStyle.Fill;
            cb_Query.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Query.FormattingEnabled = true;
            cb_Query.Location = new Point(385, 15);
            cb_Query.Name = "cb_Query";
            cb_Query.Size = new Size(254, 23);
            cb_Query.TabIndex = 3;
            // 
            // label_Loops
            // 
            label_Loops.Dock = DockStyle.Fill;
            label_Loops.ForeColor = Color.FromArgb(239, 228, 177);
            label_Loops.Location = new Point(645, 12);
            label_Loops.Name = "label_Loops";
            label_Loops.Size = new Size(74, 28);
            label_Loops.TabIndex = 4;
            label_Loops.Text = "Loopar";
            label_Loops.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // num_Loops
            // 
            num_Loops.Dock = DockStyle.Fill;
            num_Loops.Location = new Point(725, 15);
            num_Loops.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            num_Loops.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Loops.Name = "num_Loops";
            num_Loops.Size = new Size(84, 23);
            num_Loops.TabIndex = 5;
            num_Loops.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // btn_Run
            // 
            btn_Run.BackColor = Color.FromArgb(198, 239, 206);
            btn_Run.Dock = DockStyle.Fill;
            btn_Run.FlatStyle = FlatStyle.Flat;
            btn_Run.ForeColor = Color.FromArgb(0, 97, 0);
            btn_Run.Location = new Point(815, 15);
            btn_Run.Name = "btn_Run";
            btn_Run.Size = new Size(114, 22);
            btn_Run.TabIndex = 6;
            btn_Run.Text = "Kör test";
            btn_Run.UseVisualStyleBackColor = false;
            btn_Run.Click += btn_Run_Click;
            // 
            // btn_Export
            // 
            btn_Export.BackColor = Color.FromArgb(184, 220, 231);
            btn_Export.Dock = DockStyle.Fill;
            btn_Export.Enabled = false;
            btn_Export.FlatStyle = FlatStyle.Flat;
            btn_Export.ForeColor = Color.FromArgb(6, 81, 87);
            btn_Export.Location = new Point(815, 43);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(114, 22);
            btn_Export.TabIndex = 7;
            btn_Export.Text = "Exportera CSV";
            btn_Export.UseVisualStyleBackColor = false;
            btn_Export.Click += btn_Export_Click;
            // 
            // label_Summary
            // 
            label_Summary.Dock = DockStyle.Fill;
            label_Summary.ForeColor = Color.FromArgb(147, 146, 153);
            label_Summary.Location = new Point(3, 86);
            label_Summary.Name = "label_Summary";
            label_Summary.Size = new Size(996, 74);
            label_Summary.TabIndex = 1;
            label_Summary.Text = "Ingen körning ännu.";
            label_Summary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbar_ProgressBar
            // 
            pbar_ProgressBar.Dock = DockStyle.Fill;
            pbar_ProgressBar.Location = new Point(3, 163);
            pbar_ProgressBar.Name = "pbar_ProgressBar";
            pbar_ProgressBar.Size = new Size(996, 38);
            pbar_ProgressBar.TabIndex = 2;
            // 
            // lv_Results
            // 
            lv_Results.BackColor = Color.FromArgb(81, 85, 92);
            lv_Results.Columns.AddRange(new ColumnHeader[] { col_Loop, col_Time, col_Result, col_Rows, col_Timestamp });
            lv_Results.Dock = DockStyle.Fill;
            lv_Results.ForeColor = Color.FromArgb(239, 228, 177);
            lv_Results.FullRowSelect = true;
            lv_Results.GridLines = true;
            lv_Results.Location = new Point(3, 207);
            lv_Results.Name = "lv_Results";
            lv_Results.Size = new Size(996, 418);
            lv_Results.TabIndex = 3;
            lv_Results.UseCompatibleStateImageBehavior = false;
            lv_Results.View = View.Details;
            // 
            // col_Loop
            // 
            col_Loop.Text = "Loop";
            col_Loop.Width = 80;
            // 
            // col_Time
            // 
            col_Time.Text = "Tid (ms)";
            col_Time.Width = 120;
            // 
            // col_Result
            // 
            col_Result.Text = "Resultat";
            col_Result.Width = 120;
            // 
            // col_Rows
            // 
            col_Rows.Text = "Rader";
            col_Rows.Width = 100;
            // 
            // col_Timestamp
            // 
            col_Timestamp.Text = "Tidpunkt";
            col_Timestamp.Width = 220;
            // 
            // MonitorApiPerformanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1034, 660);
            Controls.Add(tlp_Main);
            ForeColor = Color.FromArgb(239, 228, 177);
            MinimumSize = new Size(950, 600);
            Name = "MonitorApiPerformanceForm";
            Padding = new Padding(16);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Monitor API Performance Test";
            Load += MonitorApiPerformanceForm_Load;
            tlp_Main.ResumeLayout(false);
            tlp_ControlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)num_Loops).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private TableLayoutPanel tlp_ControlPanel;
        private Label label_Factory;
        private ComboBox cb_Factory;
        private Label label_Query;
        private ComboBox cb_Query;
        private Label label_Loops;
        private NumericUpDown num_Loops;
        private Button btn_Run;
        private Button btn_Export;
        private Label label_Summary;
        private ProgressBar pbar_ProgressBar;
        private ListView lv_Results;
        private ColumnHeader col_Loop;
        private ColumnHeader col_Time;
        private ColumnHeader col_Result;
        private ColumnHeader col_Rows;
        private ColumnHeader col_Timestamp;
    }
}
