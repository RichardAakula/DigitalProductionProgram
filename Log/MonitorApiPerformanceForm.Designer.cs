namespace DigitalProductionProgram.Log
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
            label_TimeRemaining = new Label();
            label_Factory = new Label();
            cb_Factory = new ComboBox();
            label_Query = new Label();
            cb_Query = new ComboBox();
            label_Loops = new Label();
            num_Loops = new NumericUpDown();
            radioLoopMode = new RadioButton();
            radioTimeMode = new RadioButton();
            label_TimeMinutes = new Label();
            num_TimeMinutes = new NumericUpDown();
            label_IntervalSeconds = new Label();
            num_IntervalSeconds = new NumericUpDown();
            label_Summary = new Label();
            pbar_ProgressBar = new ProgressBar();
            lv_Results = new ListView();
            col_Loop = new ColumnHeader();
            col_Time = new ColumnHeader();
            col_Result = new ColumnHeader();
            col_Rows = new ColumnHeader();
            col_Timestamp = new ColumnHeader();
            chart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            panel_Buttons = new Panel();
            btn_Stop = new Button();
            btn_Run = new Button();
            btn_Export = new Button();
            tlp_Main.SuspendLayout();
            tlp_ControlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_Loops).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_TimeMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_IntervalSeconds).BeginInit();
            panel_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.ColumnCount = 2;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 159F));
            tlp_Main.Controls.Add(tlp_ControlPanel, 0, 0);
            tlp_Main.Controls.Add(label_Summary, 0, 1);
            tlp_Main.Controls.Add(pbar_ProgressBar, 0, 2);
            tlp_Main.Controls.Add(lv_Results, 0, 4);
            tlp_Main.Controls.Add(chart1, 0, 3);
            tlp_Main.Controls.Add(panel_Buttons, 1, 0);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(16, 16);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 5;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 62.6984138F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 37.3015862F));
            tlp_Main.Size = new Size(1204, 804);
            tlp_Main.TabIndex = 0;
            // 
            // tlp_ControlPanel
            // 
            tlp_ControlPanel.BackColor = Color.FromArgb(81, 85, 92);
            tlp_ControlPanel.ColumnCount = 9;
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 114F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 61F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 113F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 186F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 91F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 162F));
            tlp_ControlPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_ControlPanel.Controls.Add(label_TimeRemaining, 7, 1);
            tlp_ControlPanel.Controls.Add(label_Factory, 1, 0);
            tlp_ControlPanel.Controls.Add(cb_Factory, 2, 0);
            tlp_ControlPanel.Controls.Add(label_Query, 3, 0);
            tlp_ControlPanel.Controls.Add(cb_Query, 4, 0);
            tlp_ControlPanel.Controls.Add(label_Loops, 5, 0);
            tlp_ControlPanel.Controls.Add(num_Loops, 6, 0);
            tlp_ControlPanel.Controls.Add(radioLoopMode, 0, 0);
            tlp_ControlPanel.Controls.Add(radioTimeMode, 0, 1);
            tlp_ControlPanel.Controls.Add(label_TimeMinutes, 3, 1);
            tlp_ControlPanel.Controls.Add(num_TimeMinutes, 4, 1);
            tlp_ControlPanel.Controls.Add(label_IntervalSeconds, 5, 1);
            tlp_ControlPanel.Controls.Add(num_IntervalSeconds, 6, 1);
            tlp_ControlPanel.Dock = DockStyle.Fill;
            tlp_ControlPanel.Location = new Point(3, 3);
            tlp_ControlPanel.Name = "tlp_ControlPanel";
            tlp_ControlPanel.Padding = new Padding(12);
            tlp_ControlPanel.RowCount = 2;
            tlp_ControlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_ControlPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_ControlPanel.Size = new Size(1039, 80);
            tlp_ControlPanel.TabIndex = 0;
            // 
            // label_TimeRemaining
            // 
            label_TimeRemaining.Dock = DockStyle.Fill;
            label_TimeRemaining.ForeColor = Color.FromArgb(239, 228, 177);
            label_TimeRemaining.Location = new Point(853, 40);
            label_TimeRemaining.Name = "label_TimeRemaining";
            label_TimeRemaining.Size = new Size(156, 28);
            label_TimeRemaining.TabIndex = 11;
            label_TimeRemaining.Text = "0";
            label_TimeRemaining.TextAlign = ContentAlignment.MiddleLeft;
            label_TimeRemaining.Visible = false;
            // 
            // label_Factory
            // 
            label_Factory.Dock = DockStyle.Fill;
            label_Factory.ForeColor = Color.FromArgb(239, 228, 177);
            label_Factory.Location = new Point(129, 12);
            label_Factory.Name = "label_Factory";
            label_Factory.Size = new Size(55, 28);
            label_Factory.TabIndex = 0;
            label_Factory.Text = "Factory";
            label_Factory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_Factory
            // 
            cb_Factory.Dock = DockStyle.Fill;
            cb_Factory.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Factory.FormattingEnabled = true;
            cb_Factory.Location = new Point(190, 15);
            cb_Factory.Name = "cb_Factory";
            cb_Factory.Size = new Size(179, 23);
            cb_Factory.TabIndex = 1;
            // 
            // label_Query
            // 
            label_Query.Dock = DockStyle.Fill;
            label_Query.ForeColor = Color.FromArgb(239, 228, 177);
            label_Query.Location = new Point(375, 12);
            label_Query.Name = "label_Query";
            label_Query.Size = new Size(107, 28);
            label_Query.TabIndex = 2;
            label_Query.Text = "API-fråga";
            label_Query.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_Query
            // 
            cb_Query.Dock = DockStyle.Fill;
            cb_Query.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Query.FormattingEnabled = true;
            cb_Query.Location = new Point(488, 15);
            cb_Query.Name = "cb_Query";
            cb_Query.Size = new Size(180, 23);
            cb_Query.TabIndex = 3;
            // 
            // label_Loops
            // 
            label_Loops.Dock = DockStyle.Fill;
            label_Loops.ForeColor = Color.FromArgb(239, 228, 177);
            label_Loops.Location = new Point(674, 12);
            label_Loops.Name = "label_Loops";
            label_Loops.Size = new Size(85, 28);
            label_Loops.TabIndex = 4;
            label_Loops.Text = "Loopar";
            label_Loops.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // num_Loops
            // 
            num_Loops.Dock = DockStyle.Fill;
            num_Loops.Location = new Point(765, 15);
            num_Loops.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            num_Loops.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_Loops.Name = "num_Loops";
            num_Loops.Size = new Size(82, 23);
            num_Loops.TabIndex = 5;
            num_Loops.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // radioLoopMode
            // 
            radioLoopMode.AutoSize = true;
            radioLoopMode.Location = new Point(15, 15);
            radioLoopMode.Name = "radioLoopMode";
            radioLoopMode.Size = new Size(86, 19);
            radioLoopMode.TabIndex = 8;
            radioLoopMode.TabStop = true;
            radioLoopMode.Text = "Loop Mode";
            radioLoopMode.UseVisualStyleBackColor = true;
            // 
            // radioTimeMode
            // 
            radioTimeMode.AutoSize = true;
            radioTimeMode.Location = new Point(15, 43);
            radioTimeMode.Name = "radioTimeMode";
            radioTimeMode.Size = new Size(85, 19);
            radioTimeMode.TabIndex = 8;
            radioTimeMode.TabStop = true;
            radioTimeMode.Text = "Time Mode";
            radioTimeMode.UseVisualStyleBackColor = true;
            // 
            // label_TimeMinutes
            // 
            label_TimeMinutes.Dock = DockStyle.Fill;
            label_TimeMinutes.ForeColor = Color.FromArgb(239, 228, 177);
            label_TimeMinutes.Location = new Point(375, 40);
            label_TimeMinutes.Name = "label_TimeMinutes";
            label_TimeMinutes.Size = new Size(107, 28);
            label_TimeMinutes.TabIndex = 9;
            label_TimeMinutes.Text = "Total tid (minuter):";
            label_TimeMinutes.TextAlign = ContentAlignment.MiddleLeft;
            label_TimeMinutes.Visible = false;
            // 
            // num_TimeMinutes
            // 
            num_TimeMinutes.Location = new Point(488, 43);
            num_TimeMinutes.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_TimeMinutes.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_TimeMinutes.Name = "num_TimeMinutes";
            num_TimeMinutes.Size = new Size(63, 23);
            num_TimeMinutes.TabIndex = 10;
            num_TimeMinutes.Value = new decimal(new int[] { 5, 0, 0, 0 });
            num_TimeMinutes.Visible = false;
            // 
            // label_IntervalSeconds
            // 
            label_IntervalSeconds.Dock = DockStyle.Fill;
            label_IntervalSeconds.ForeColor = Color.FromArgb(239, 228, 177);
            label_IntervalSeconds.Location = new Point(674, 40);
            label_IntervalSeconds.Name = "label_IntervalSeconds";
            label_IntervalSeconds.Size = new Size(85, 28);
            label_IntervalSeconds.TabIndex = 9;
            label_IntervalSeconds.Text = "Intervall (sek):";
            label_IntervalSeconds.TextAlign = ContentAlignment.MiddleLeft;
            label_IntervalSeconds.Visible = false;
            // 
            // num_IntervalSeconds
            // 
            num_IntervalSeconds.Dock = DockStyle.Fill;
            num_IntervalSeconds.Location = new Point(765, 43);
            num_IntervalSeconds.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_IntervalSeconds.Name = "num_IntervalSeconds";
            num_IntervalSeconds.Size = new Size(82, 23);
            num_IntervalSeconds.TabIndex = 10;
            num_IntervalSeconds.Value = new decimal(new int[] { 10, 0, 0, 0 });
            num_IntervalSeconds.Visible = false;
            // 
            // label_Summary
            // 
            label_Summary.Dock = DockStyle.Fill;
            label_Summary.ForeColor = Color.FromArgb(147, 146, 153);
            label_Summary.Location = new Point(3, 86);
            label_Summary.Name = "label_Summary";
            label_Summary.Size = new Size(1039, 52);
            label_Summary.TabIndex = 1;
            label_Summary.Text = "Ingen körning ännu.";
            label_Summary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbar_ProgressBar
            // 
            pbar_ProgressBar.Dock = DockStyle.Fill;
            pbar_ProgressBar.Location = new Point(3, 141);
            pbar_ProgressBar.Name = "pbar_ProgressBar";
            pbar_ProgressBar.Size = new Size(1039, 30);
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
            lv_Results.Location = new Point(3, 572);
            lv_Results.Name = "lv_Results";
            lv_Results.Size = new Size(1039, 229);
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
            // chart1
            // 
            chart1.Dock = DockStyle.Fill;
            chart1.Location = new Point(3, 177);
            chart1.Name = "chart1";
            chart1.Size = new Size(1039, 389);
            chart1.TabIndex = 4;
            chart1.Tag = "";
            // 
            // panel_Buttons
            // 
            panel_Buttons.Controls.Add(btn_Stop);
            panel_Buttons.Controls.Add(btn_Run);
            panel_Buttons.Controls.Add(btn_Export);
            panel_Buttons.Dock = DockStyle.Fill;
            panel_Buttons.Location = new Point(1048, 3);
            panel_Buttons.Name = "panel_Buttons";
            panel_Buttons.Size = new Size(153, 80);
            panel_Buttons.TabIndex = 5;
            // 
            // btn_Stop
            // 
            btn_Stop.BackColor = Color.FromArgb(255, 199, 206);
            btn_Stop.FlatStyle = FlatStyle.Flat;
            btn_Stop.ForeColor = Color.FromArgb(156, 0, 6);
            btn_Stop.Location = new Point(0, 28);
            btn_Stop.Name = "btn_Stop";
            btn_Stop.Size = new Size(153, 24);
            btn_Stop.TabIndex = 8;
            btn_Stop.Text = "Stoppa Test";
            btn_Stop.UseVisualStyleBackColor = false;
            btn_Stop.Click += btn_Stop_Click;
            // 
            // btn_Run
            // 
            btn_Run.BackColor = Color.FromArgb(198, 239, 206);
            btn_Run.Dock = DockStyle.Top;
            btn_Run.FlatStyle = FlatStyle.Flat;
            btn_Run.ForeColor = Color.FromArgb(0, 97, 0);
            btn_Run.Location = new Point(0, 0);
            btn_Run.Name = "btn_Run";
            btn_Run.Size = new Size(153, 24);
            btn_Run.TabIndex = 6;
            btn_Run.Text = "Kör Test";
            btn_Run.UseVisualStyleBackColor = false;
            btn_Run.Click += btn_Run_Click;
            // 
            // btn_Export
            // 
            btn_Export.BackColor = Color.FromArgb(184, 220, 231);
            btn_Export.Dock = DockStyle.Bottom;
            btn_Export.Enabled = false;
            btn_Export.FlatStyle = FlatStyle.Flat;
            btn_Export.ForeColor = Color.FromArgb(6, 81, 87);
            btn_Export.Location = new Point(0, 56);
            btn_Export.Name = "btn_Export";
            btn_Export.Size = new Size(153, 24);
            btn_Export.TabIndex = 7;
            btn_Export.Text = "Exportera CSV";
            btn_Export.UseVisualStyleBackColor = false;
            btn_Export.Click += btn_Export_Click;
            // 
            // MonitorApiPerformanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1236, 836);
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
            tlp_ControlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_Loops).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_TimeMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_IntervalSeconds).EndInit();
            panel_Buttons.ResumeLayout(false);
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
        private RadioButton radioLoopMode;
        private RadioButton radioTimeMode;
        private Label label_TimeMinutes;
        private NumericUpDown num_TimeMinutes;
        private Label label_IntervalSeconds;
        private NumericUpDown num_IntervalSeconds;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chart1;
        private Label label_TimeRemaining;
        private Panel panel_Buttons;
        private Button btn_Stop;
    }
}
