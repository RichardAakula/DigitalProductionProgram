using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    partial class PreFab
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(PreFab));
            tlp_Main = new TableLayoutPanel();
            btn_PreFab = new Button();
            btn_RemovePreFab = new Button();
            dgv = new DataGridView();
            pb_Info = new PictureBox();
            btn_AddPreFab = new Button();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv).BeginInit();
            ((ISupportInitialize)pb_Info).BeginInit();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Black;
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 215F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 188F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 88F));
            tlp_Main.Controls.Add(btn_PreFab, 0, 0);
            tlp_Main.Controls.Add(btn_RemovePreFab, 1, 1);
            tlp_Main.Controls.Add(dgv, 0, 2);
            tlp_Main.Controls.Add(pb_Info, 2, 1);
            tlp_Main.Controls.Add(btn_AddPreFab, 0, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 3;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Main.Size = new Size(853, 218);
            tlp_Main.TabIndex = 0;
            // 
            // btn_PreFab
            // 
            btn_PreFab.BackColor = Color.LightGray;
            tlp_Main.SetColumnSpan(btn_PreFab, 5);
            btn_PreFab.Cursor = Cursors.Hand;
            btn_PreFab.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            btn_PreFab.FlatStyle = FlatStyle.Flat;
            btn_PreFab.Font = new Font("Palatino Linotype", 10F);
            btn_PreFab.ForeColor = Color.SaddleBrown;
            btn_PreFab.Location = new Point(0, 0);
            btn_PreFab.Margin = new Padding(0);
            btn_PreFab.Name = "btn_PreFab";
            btn_PreFab.Size = new Size(853, 32);
            btn_PreFab.TabIndex = 974;
            btn_PreFab.Text = "Halvfabrikat";
            btn_PreFab.TextAlign = ContentAlignment.TopLeft;
            btn_PreFab.UseVisualStyleBackColor = false;
            // 
            // btn_RemovePreFab
            // 
            btn_RemovePreFab.BackColor = Color.FromArgb(25, 25, 25);
            btn_RemovePreFab.Cursor = Cursors.Hand;
            btn_RemovePreFab.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_RemovePreFab.FlatStyle = FlatStyle.Flat;
            btn_RemovePreFab.Font = new Font("Consolas", 9F);
            btn_RemovePreFab.ForeColor = Color.FromArgb(255, 199, 206);
            btn_RemovePreFab.Location = new Point(217, 33);
            btn_RemovePreFab.Margin = new Padding(2, 1, 0, 0);
            btn_RemovePreFab.Name = "btn_RemovePreFab";
            btn_RemovePreFab.Size = new Size(186, 27);
            btn_RemovePreFab.TabIndex = 973;
            btn_RemovePreFab.Text = "Radera Halvfabrikat";
            btn_RemovePreFab.TextAlign = ContentAlignment.MiddleLeft;
            btn_RemovePreFab.UseVisualStyleBackColor = false;
            btn_RemovePreFab.Click += Delete_PreFab_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.BackgroundColor = Color.FromArgb(25, 25, 25);
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersHeight = 20;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tlp_Main.SetColumnSpan(dgv, 3);
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Consolas", 8.25F);
            dataGridViewCellStyle1.ForeColor = Color.DarkSlateGray;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle1;
            dgv.Dock = DockStyle.Fill;
            dgv.GridColor = Color.FromArgb(75, 75, 75);
            dgv.Location = new Point(0, 60);
            dgv.Margin = new Padding(0);
            dgv.Name = "dgv";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Arial", 9.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgv.RowHeadersVisible = false;
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgv.ScrollBars = ScrollBars.Vertical;
            dgv.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgv.Size = new Size(853, 158);
            dgv.TabIndex = 908;
            dgv.CellClick += PreFab_CellClick;
            dgv.CellFormatting += CellFormatting;
            dgv.CellValueChanged += Save_CellValueChanged;
            dgv.Leave += dgv_Leave;
            // 
            // pb_Info
            // 
            pb_Info.BackColor = Color.Transparent;
            pb_Info.BackgroundImage = (Image)resources.GetObject("pb_Info.BackgroundImage");
            pb_Info.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info.Cursor = Cursors.Hand;
            pb_Info.Dock = DockStyle.Left;
            pb_Info.Location = new Point(403, 32);
            pb_Info.Margin = new Padding(0);
            pb_Info.Name = "pb_Info";
            pb_Info.Size = new Size(49, 28);
            pb_Info.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info.TabIndex = 971;
            pb_Info.TabStop = false;
            pb_Info.Click += Info_Click;
            // 
            // btn_AddPreFab
            // 
            btn_AddPreFab.BackColor = Color.FromArgb(25, 25, 25);
            btn_AddPreFab.Cursor = Cursors.Hand;
            btn_AddPreFab.Dock = DockStyle.Fill;
            btn_AddPreFab.FlatAppearance.MouseOverBackColor = Color.FromArgb(75, 75, 75);
            btn_AddPreFab.FlatStyle = FlatStyle.Flat;
            btn_AddPreFab.Font = new Font("Consolas", 9F);
            btn_AddPreFab.ForeColor = Color.FromArgb(198, 239, 206);
            btn_AddPreFab.Location = new Point(2, 33);
            btn_AddPreFab.Margin = new Padding(2, 1, 0, 0);
            btn_AddPreFab.Name = "btn_AddPreFab";
            btn_AddPreFab.Size = new Size(213, 27);
            btn_AddPreFab.TabIndex = 972;
            btn_AddPreFab.Text = "Lägg till Halvfabrikat";
            btn_AddPreFab.TextAlign = ContentAlignment.MiddleLeft;
            btn_AddPreFab.UseVisualStyleBackColor = false;
            btn_AddPreFab.Click += Add_PreFab_Click;
            // 
            // PreFab
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "PreFab";
            Size = new Size(853, 218);
            tlp_Main.ResumeLayout(false);
            ((ISupportInitialize)dgv).EndInit();
            ((ISupportInitialize)pb_Info).EndInit();
            ResumeLayout(false);

        }

        #endregion
        public TableLayoutPanel tlp_Main;
        public DataGridView dgv;
        private PictureBox pb_Info;
        public Button btn_AddPreFab;
        public Button btn_RemovePreFab;
        public Button btn_PreFab;
    }
}
