using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class MeasureInstrument
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MeasureInstrument));
            dgv_Mätdon = new DataGridView();
            col_MätDonNr = new DataGridViewTextBoxColumn();
            col_Row = new DataGridViewTextBoxColumn();
            tlp_Main = new TableLayoutPanel();
            pb_Info = new PictureBox();
            btn_Add_Startup = new Button();
            btn_Discard_Startup = new Button();
            label_MeasureInstrument_Header = new Label();
            ((ISupportInitialize)dgv_Mätdon).BeginInit();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)pb_Info).BeginInit();
            SuspendLayout();
            // 
            // dgv_Mätdon
            // 
            dgv_Mätdon.AllowUserToAddRows = false;
            dgv_Mätdon.AllowUserToDeleteRows = false;
            dgv_Mätdon.AllowUserToResizeColumns = false;
            dgv_Mätdon.AllowUserToResizeRows = false;
            dgv_Mätdon.BackgroundColor = Color.FromArgb(45, 113, 122);
            dgv_Mätdon.BorderStyle = BorderStyle.None;
            dgv_Mätdon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Mätdon.ColumnHeadersVisible = false;
            dgv_Mätdon.Columns.AddRange(new DataGridViewColumn[] { col_MätDonNr, col_Row });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(35, 103, 112);
            dataGridViewCellStyle1.Font = new Font("Consolas", 9F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(187, 215, 228);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv_Mätdon.DefaultCellStyle = dataGridViewCellStyle1;
            dgv_Mätdon.Dock = DockStyle.Fill;
            dgv_Mätdon.Location = new Point(38, 23);
            dgv_Mätdon.Margin = new Padding(0);
            dgv_Mätdon.MultiSelect = false;
            dgv_Mätdon.Name = "dgv_Mätdon";
            dgv_Mätdon.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Info;
            dataGridViewCellStyle2.Font = new Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.Info;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv_Mätdon.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv_Mätdon.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dgv_Mätdon.RowTemplate.Height = 18;
            dgv_Mätdon.ScrollBars = ScrollBars.Vertical;
            dgv_Mätdon.ShowCellErrors = false;
            dgv_Mätdon.ShowCellToolTips = false;
            dgv_Mätdon.ShowEditingIcon = false;
            dgv_Mätdon.ShowRowErrors = false;
            dgv_Mätdon.Size = new Size(326, 129);
            dgv_Mätdon.TabIndex = 960;
            dgv_Mätdon.CellMouseDoubleClick += Mätdon_CellMouseDoubleClick;
            // 
            // col_MätDonNr
            // 
            col_MätDonNr.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            col_MätDonNr.HeaderText = "Nr";
            col_MätDonNr.MinimumWidth = 70;
            col_MätDonNr.Name = "col_MätDonNr";
            col_MätDonNr.Width = 70;
            // 
            // col_Row
            // 
            col_Row.HeaderText = "Row";
            col_Row.Name = "col_Row";
            col_Row.Visible = false;
            col_Row.Width = 5;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 1;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 38F));
            tlp_Main.Controls.Add(pb_Info, 0, 0);
            tlp_Main.Controls.Add(btn_Add_Startup, 0, 1);
            tlp_Main.Controls.Add(btn_Discard_Startup, 0, 2);
            tlp_Main.Dock = DockStyle.Left;
            tlp_Main.Location = new Point(0, 23);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.Size = new Size(38, 129);
            tlp_Main.TabIndex = 961;
            // 
            // pb_Info
            // 
            pb_Info.BackColor = Color.Transparent;
            pb_Info.BackgroundImage = (Image)resources.GetObject("pb_Info.BackgroundImage");
            pb_Info.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info.Cursor = Cursors.Hand;
            pb_Info.Dock = DockStyle.Top;
            pb_Info.Location = new Point(4, 3);
            pb_Info.Margin = new Padding(4, 3, 4, 3);
            pb_Info.Name = "pb_Info";
            pb_Info.Size = new Size(30, 35);
            pb_Info.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info.TabIndex = 1075;
            pb_Info.TabStop = false;
            pb_Info.Click += Info_Click;
            // 
            // btn_Add_Startup
            // 
            btn_Add_Startup.BackColor = Color.FromArgb(198, 239, 206);
            btn_Add_Startup.Cursor = Cursors.Hand;
            btn_Add_Startup.Dock = DockStyle.Fill;
            btn_Add_Startup.FlatAppearance.BorderSize = 0;
            btn_Add_Startup.FlatAppearance.MouseOverBackColor = Color.FromArgb(148, 189, 156);
            btn_Add_Startup.FlatStyle = FlatStyle.Flat;
            btn_Add_Startup.Font = new Font("Segoe UI", 11.75F, FontStyle.Bold);
            btn_Add_Startup.ForeColor = Color.DarkSlateGray;
            btn_Add_Startup.Location = new Point(1, 43);
            btn_Add_Startup.Margin = new Padding(1, 1, 1, 0);
            btn_Add_Startup.Name = "btn_Add_Startup";
            btn_Add_Startup.Size = new Size(36, 34);
            btn_Add_Startup.TabIndex = 1073;
            btn_Add_Startup.Text = "+";
            btn_Add_Startup.TextAlign = ContentAlignment.TopCenter;
            btn_Add_Startup.UseCompatibleTextRendering = true;
            btn_Add_Startup.UseVisualStyleBackColor = false;
            btn_Add_Startup.Click += Add_NewMeasureInstrument_Click;
            // 
            // btn_Discard_Startup
            // 
            btn_Discard_Startup.BackColor = Color.FromArgb(255, 199, 206);
            btn_Discard_Startup.Cursor = Cursors.Hand;
            btn_Discard_Startup.Dock = DockStyle.Fill;
            btn_Discard_Startup.FlatAppearance.BorderSize = 0;
            btn_Discard_Startup.FlatAppearance.MouseOverBackColor = Color.FromArgb(205, 149, 156);
            btn_Discard_Startup.FlatStyle = FlatStyle.Flat;
            btn_Discard_Startup.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Discard_Startup.ForeColor = Color.FromArgb(156, 0, 6);
            btn_Discard_Startup.Location = new Point(1, 78);
            btn_Discard_Startup.Margin = new Padding(1, 1, 1, 0);
            btn_Discard_Startup.Name = "btn_Discard_Startup";
            btn_Discard_Startup.Size = new Size(36, 34);
            btn_Discard_Startup.TabIndex = 1074;
            btn_Discard_Startup.Text = "-";
            btn_Discard_Startup.UseCompatibleTextRendering = true;
            btn_Discard_Startup.UseVisualStyleBackColor = false;
            btn_Discard_Startup.Click += Discard_Startup_Click;
            // 
            // label_MeasureInstrument_Header
            // 
            label_MeasureInstrument_Header.BackColor = Color.Transparent;
            label_MeasureInstrument_Header.Dock = DockStyle.Top;
            label_MeasureInstrument_Header.Font = new Font("Lucida Sans", 12.25F);
            label_MeasureInstrument_Header.ForeColor = SystemColors.Info;
            label_MeasureInstrument_Header.Location = new Point(0, 0);
            label_MeasureInstrument_Header.Margin = new Padding(4, 0, 4, 0);
            label_MeasureInstrument_Header.Name = "label_MeasureInstrument_Header";
            label_MeasureInstrument_Header.Size = new Size(364, 23);
            label_MeasureInstrument_Header.TabIndex = 962;
            label_MeasureInstrument_Header.Text = "Mätdon";
            label_MeasureInstrument_Header.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MeasureInstrument
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(35, 103, 112);
            Controls.Add(dgv_Mätdon);
            Controls.Add(tlp_Main);
            Controls.Add(label_MeasureInstrument_Header);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MeasureInstrument";
            Size = new Size(364, 152);
            ((ISupportInitialize)dgv_Mätdon).EndInit();
            tlp_Main.ResumeLayout(false);
            ((ISupportInitialize)pb_Info).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private TableLayoutPanel tlp_Main;
        private Button btn_Add_Startup;
        private Label label_MeasureInstrument_Header;
        private Button btn_Discard_Startup;
        private PictureBox pb_Info;
        public DataGridView dgv_Mätdon;
        private DataGridViewTextBoxColumn col_MätDonNr;
        private DataGridViewTextBoxColumn col_Row;
    }
}
