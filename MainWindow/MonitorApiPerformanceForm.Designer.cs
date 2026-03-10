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
            mainLayout = new TableLayoutPanel();
            controlsPanel = new TableLayoutPanel();
            lblFactory = new Label();
            cbFactory = new ComboBox();
            lblQuery = new Label();
            cbQuery = new ComboBox();
            lblLoops = new Label();
            nudLoops = new NumericUpDown();
            btnRun = new Button();
            btnExport = new Button();
            lblSummary = new Label();
            progressBar = new ProgressBar();
            lvResults = new ListView();
            colLoop = new ColumnHeader();
            colTime = new ColumnHeader();
            colResult = new ColumnHeader();
            colRows = new ColumnHeader();
            colTimestamp = new ColumnHeader();
            mainLayout.SuspendLayout();
            controlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudLoops).BeginInit();
            SuspendLayout();
            // 
            // mainLayout
            // 
            mainLayout.ColumnCount = 1;
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainLayout.Controls.Add(controlsPanel, 0, 0);
            mainLayout.Controls.Add(lblSummary, 0, 1);
            mainLayout.Controls.Add(progressBar, 0, 2);
            mainLayout.Controls.Add(lvResults, 0, 3);
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.Location = new Point(16, 16);
            mainLayout.Name = "mainLayout";
            mainLayout.RowCount = 4;
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 130F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainLayout.Size = new Size(1002, 628);
            mainLayout.TabIndex = 0;
            // 
            // controlsPanel
            // 
            controlsPanel.BackColor = Color.FromArgb(81, 85, 92);
            controlsPanel.ColumnCount = 8;
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 190F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 260F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            controlsPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            controlsPanel.Controls.Add(lblFactory, 0, 0);
            controlsPanel.Controls.Add(cbFactory, 1, 0);
            controlsPanel.Controls.Add(lblQuery, 2, 0);
            controlsPanel.Controls.Add(cbQuery, 3, 0);
            controlsPanel.Controls.Add(lblLoops, 4, 0);
            controlsPanel.Controls.Add(nudLoops, 5, 0);
            controlsPanel.Controls.Add(btnRun, 6, 0);
            controlsPanel.Controls.Add(btnExport, 6, 1);
            controlsPanel.Dock = DockStyle.Fill;
            controlsPanel.Location = new Point(3, 3);
            controlsPanel.Name = "controlsPanel";
            controlsPanel.Padding = new Padding(12);
            controlsPanel.RowCount = 2;
            controlsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlsPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            controlsPanel.Size = new Size(996, 124);
            controlsPanel.TabIndex = 0;
            // 
            // lblFactory
            // 
            lblFactory.Dock = DockStyle.Fill;
            lblFactory.ForeColor = Color.FromArgb(239, 228, 177);
            lblFactory.Location = new Point(15, 12);
            lblFactory.Name = "lblFactory";
            lblFactory.Size = new Size(84, 50);
            lblFactory.TabIndex = 0;
            lblFactory.Text = "Factory";
            lblFactory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbFactory
            // 
            cbFactory.Dock = DockStyle.Fill;
            cbFactory.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFactory.FormattingEnabled = true;
            cbFactory.Location = new Point(105, 15);
            cbFactory.Name = "cbFactory";
            cbFactory.Size = new Size(184, 23);
            cbFactory.TabIndex = 1;
            // 
            // lblQuery
            // 
            lblQuery.Dock = DockStyle.Fill;
            lblQuery.ForeColor = Color.FromArgb(239, 228, 177);
            lblQuery.Location = new Point(295, 12);
            lblQuery.Name = "lblQuery";
            lblQuery.Size = new Size(84, 50);
            lblQuery.TabIndex = 2;
            lblQuery.Text = "API-fråga";
            lblQuery.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cbQuery
            // 
            cbQuery.Dock = DockStyle.Fill;
            cbQuery.DropDownStyle = ComboBoxStyle.DropDownList;
            cbQuery.FormattingEnabled = true;
            cbQuery.Location = new Point(385, 15);
            cbQuery.Name = "cbQuery";
            cbQuery.Size = new Size(254, 23);
            cbQuery.TabIndex = 3;
            // 
            // lblLoops
            // 
            lblLoops.Dock = DockStyle.Fill;
            lblLoops.ForeColor = Color.FromArgb(239, 228, 177);
            lblLoops.Location = new Point(645, 12);
            lblLoops.Name = "lblLoops";
            lblLoops.Size = new Size(74, 50);
            lblLoops.TabIndex = 4;
            lblLoops.Text = "Loopar";
            lblLoops.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // nudLoops
            // 
            nudLoops.Dock = DockStyle.Fill;
            nudLoops.Location = new Point(725, 15);
            nudLoops.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            nudLoops.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudLoops.Name = "nudLoops";
            nudLoops.Size = new Size(84, 23);
            nudLoops.TabIndex = 5;
            nudLoops.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // btnRun
            // 
            btnRun.BackColor = Color.FromArgb(198, 239, 206);
            btnRun.Dock = DockStyle.Fill;
            btnRun.FlatStyle = FlatStyle.Flat;
            btnRun.ForeColor = Color.FromArgb(0, 97, 0);
            btnRun.Location = new Point(815, 15);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(114, 44);
            btnRun.TabIndex = 6;
            btnRun.Text = "Kör test";
            btnRun.UseVisualStyleBackColor = false;
            btnRun.Click += btnRun_Click;
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.FromArgb(184, 220, 231);
            btnExport.Dock = DockStyle.Fill;
            btnExport.Enabled = false;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.FromArgb(6, 81, 87);
            btnExport.Location = new Point(815, 65);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(114, 44);
            btnExport.TabIndex = 7;
            btnExport.Text = "Exportera CSV";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // lblSummary
            // 
            lblSummary.Dock = DockStyle.Fill;
            lblSummary.ForeColor = Color.FromArgb(147, 146, 153);
            lblSummary.Location = new Point(3, 130);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(996, 30);
            lblSummary.TabIndex = 1;
            lblSummary.Text = "Ingen körning ännu.";
            lblSummary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Fill;
            progressBar.Location = new Point(3, 163);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(996, 38);
            progressBar.TabIndex = 2;
            // 
            // lvResults
            // 
            lvResults.BackColor = Color.FromArgb(81, 85, 92);
            lvResults.Columns.AddRange(new ColumnHeader[] { colLoop, colTime, colResult, colRows, colTimestamp });
            lvResults.Dock = DockStyle.Fill;
            lvResults.ForeColor = Color.FromArgb(239, 228, 177);
            lvResults.FullRowSelect = true;
            lvResults.GridLines = true;
            lvResults.Location = new Point(3, 207);
            lvResults.Name = "lvResults";
            lvResults.Size = new Size(996, 418);
            lvResults.TabIndex = 3;
            lvResults.UseCompatibleStateImageBehavior = false;
            lvResults.View = View.Details;
            // 
            // colLoop
            // 
            colLoop.Text = "Loop";
            colLoop.Width = 80;
            // 
            // colTime
            // 
            colTime.Text = "Tid (ms)";
            colTime.Width = 120;
            // 
            // colResult
            // 
            colResult.Text = "Resultat";
            colResult.Width = 120;
            // 
            // colRows
            // 
            colRows.Text = "Rader";
            colRows.Width = 100;
            // 
            // colTimestamp
            // 
            colTimestamp.Text = "Tidpunkt";
            colTimestamp.Width = 220;
            // 
            // MonitorApiPerformanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(1034, 660);
            Controls.Add(mainLayout);
            ForeColor = Color.FromArgb(239, 228, 177);
            MinimumSize = new Size(950, 600);
            Name = "MonitorApiPerformanceForm";
            Padding = new Padding(16);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Monitor API Performance Test";
            mainLayout.ResumeLayout(false);
            controlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudLoops).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel mainLayout;
        private TableLayoutPanel controlsPanel;
        private Label lblFactory;
        private ComboBox cbFactory;
        private Label lblQuery;
        private ComboBox cbQuery;
        private Label lblLoops;
        private NumericUpDown nudLoops;
        private Button btnRun;
        private Button btnExport;
        private Label lblSummary;
        private ProgressBar progressBar;
        private ListView lvResults;
        private ColumnHeader colLoop;
        private ColumnHeader colTime;
        private ColumnHeader colResult;
        private ColumnHeader colRows;
        private ColumnHeader colTimestamp;
    }
}
