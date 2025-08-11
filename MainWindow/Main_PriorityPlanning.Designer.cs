
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class Main_Priorityplanning
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label_ProductionSchedule = new Label();
            label_ProdGroup = new Label();
            tlp_InfoLabels = new TableLayoutPanel();
            label_Brown = new Label();
            label_Red = new Label();
            label_Blue = new Label();
            label_White = new Label();
            label_Yellow = new Label();
            label_Green = new Label();
            tlp_Main = new TableLayoutPanel();
            btn_RefreshPriorityPlan = new Button();
            tb_ProdGrupp = new TextBox();
            tb_ProdBenämning = new TextBox();
            dgv_PriorityPlanning = new DataGridView();
            tlp_InfoLabels.SuspendLayout();
            tlp_Main.SuspendLayout();
            ((ISupportInitialize)dgv_PriorityPlanning).BeginInit();
            SuspendLayout();
            // 
            // label_ProductionSchedule
            // 
            label_ProductionSchedule.BackColor = Color.Transparent;
            label_ProductionSchedule.Dock = DockStyle.Fill;
            label_ProductionSchedule.Font = new Font("Palatino Linotype", 15F, FontStyle.Bold);
            label_ProductionSchedule.ForeColor = SystemColors.Info;
            label_ProductionSchedule.Location = new Point(4, 0);
            label_ProductionSchedule.Margin = new Padding(4, 0, 4, 0);
            label_ProductionSchedule.Name = "label_ProductionSchedule";
            label_ProductionSchedule.Size = new Size(201, 27);
            label_ProductionSchedule.TabIndex = 5;
            label_ProductionSchedule.Text = "Körplanering";
            // 
            // label_ProdGroup
            // 
            label_ProdGroup.BackColor = Color.Transparent;
            tlp_Main.SetColumnSpan(label_ProdGroup, 2);
            label_ProdGroup.Dock = DockStyle.Left;
            label_ProdGroup.Font = new Font("Microsoft Sans Serif", 10.25F);
            label_ProdGroup.ForeColor = Color.White;
            label_ProdGroup.Location = new Point(213, 5);
            label_ProdGroup.Margin = new Padding(4, 5, 4, 0);
            label_ProdGroup.Name = "label_ProdGroup";
            label_ProdGroup.Size = new Size(342, 22);
            label_ProdGroup.TabIndex = 6;
            label_ProdGroup.Text = "Välj Produktionsgrupp";
            // 
            // tlp_InfoLabels
            // 
            tlp_InfoLabels.BackColor = Color.FromArgb(60, 60, 60);
            tlp_InfoLabels.ColumnCount = 1;
            tlp_InfoLabels.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_InfoLabels.Controls.Add(label_Brown, 0, 4);
            tlp_InfoLabels.Controls.Add(label_Red, 0, 5);
            tlp_InfoLabels.Controls.Add(label_Blue, 0, 3);
            tlp_InfoLabels.Controls.Add(label_White, 0, 2);
            tlp_InfoLabels.Controls.Add(label_Yellow, 0, 1);
            tlp_InfoLabels.Controls.Add(label_Green, 0, 0);
            tlp_InfoLabels.Dock = DockStyle.Right;
            tlp_InfoLabels.Location = new Point(902, 57);
            tlp_InfoLabels.Margin = new Padding(0);
            tlp_InfoLabels.Name = "tlp_InfoLabels";
            tlp_InfoLabels.RowCount = 7;
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
            tlp_InfoLabels.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_InfoLabels.Size = new Size(461, 361);
            tlp_InfoLabels.TabIndex = 7;
            // 
            // label_Brown
            // 
            label_Brown.BackColor = Color.Brown;
            label_Brown.Dock = DockStyle.Fill;
            label_Brown.Font = new Font("Lucida Sans", 9.75F);
            label_Brown.ForeColor = Color.DarkOrange;
            label_Brown.Location = new Point(4, 88);
            label_Brown.Margin = new Padding(4, 0, 4, 0);
            label_Brown.Name = "label_Brown";
            label_Brown.Size = new Size(453, 22);
            label_Brown.TabIndex = 16;
            label_Brown.Text = "Processkort under framarbetning, och processkort behöver fastslås.\r\n\r\n";
            // 
            // label_Red
            // 
            label_Red.BackColor = Color.FromArgb(255, 199, 206);
            label_Red.Dock = DockStyle.Fill;
            label_Red.Font = new Font("Lucida Sans", 9.75F);
            label_Red.ForeColor = Color.FromArgb(156, 0, 6);
            label_Red.Location = new Point(4, 110);
            label_Red.Margin = new Padding(4, 0, 4, 0);
            label_Red.Name = "label_Red";
            label_Red.Size = new Size(453, 22);
            label_Red.TabIndex = 15;
            label_Red.Text = "Processkort ej godkänt av QA";
            // 
            // label_Blue
            // 
            label_Blue.BackColor = Color.FromArgb(180, 198, 231);
            label_Blue.Dock = DockStyle.Fill;
            label_Blue.Font = new Font("Lucida Sans", 9.75F);
            label_Blue.ForeColor = Color.DarkSlateGray;
            label_Blue.Location = new Point(4, 66);
            label_Blue.Margin = new Padding(4, 0, 4, 0);
            label_Blue.Name = "label_Blue";
            label_Blue.Size = new Size(453, 22);
            label_Blue.TabIndex = 12;
            label_Blue.Text = "Multipla processkort finns ";
            // 
            // label_White
            // 
            label_White.BackColor = Color.FromArgb(250, 250, 250);
            label_White.Dock = DockStyle.Fill;
            label_White.Font = new Font("Lucida Sans", 9.75F);
            label_White.ForeColor = Color.Red;
            label_White.Location = new Point(4, 44);
            label_White.Margin = new Padding(4, 0, 4, 0);
            label_White.Name = "label_White";
            label_White.Size = new Size(453, 22);
            label_White.TabIndex = 13;
            label_White.Text = "Processkort saknas";
            // 
            // label_Yellow
            // 
            label_Yellow.BackColor = Color.FromArgb(255, 235, 156);
            label_Yellow.Dock = DockStyle.Fill;
            label_Yellow.Font = new Font("Lucida Sans", 9.75F);
            label_Yellow.ForeColor = Color.FromArgb(156, 101, 0);
            label_Yellow.Location = new Point(4, 22);
            label_Yellow.Margin = new Padding(4, 0, 4, 0);
            label_Yellow.Name = "label_Yellow";
            label_Yellow.Size = new Size(453, 22);
            label_Yellow.TabIndex = 4;
            label_Yellow.Text = "Order startad";
            // 
            // label_Green
            // 
            label_Green.BackColor = Color.FromArgb(198, 239, 206);
            label_Green.Dock = DockStyle.Fill;
            label_Green.Font = new Font("Lucida Sans", 9.75F);
            label_Green.ForeColor = Color.FromArgb(0, 97, 0);
            label_Green.Location = new Point(4, 0);
            label_Green.Margin = new Padding(4, 0, 4, 0);
            label_Green.Name = "label_Green";
            label_Green.Size = new Size(453, 22);
            label_Green.TabIndex = 3;
            label_Green.Text = "Order Ok att starta";
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.FromArgb(60, 60, 60);
            tlp_Main.ColumnCount = 3;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 209F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 71F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            tlp_Main.Controls.Add(label_ProductionSchedule, 0, 0);
            tlp_Main.Controls.Add(label_ProdGroup, 1, 0);
            tlp_Main.Controls.Add(btn_RefreshPriorityPlan, 0, 1);
            tlp_Main.Controls.Add(tb_ProdGrupp, 1, 1);
            tlp_Main.Controls.Add(tb_ProdBenämning, 2, 1);
            tlp_Main.Dock = DockStyle.Top;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Main.Size = new Size(1363, 57);
            tlp_Main.TabIndex = 10;
            // 
            // btn_RefreshPriorityPlan
            // 
            btn_RefreshPriorityPlan.BackColor = Color.FromArgb(198, 239, 206);
            btn_RefreshPriorityPlan.Cursor = Cursors.Hand;
            btn_RefreshPriorityPlan.Dock = DockStyle.Fill;
            btn_RefreshPriorityPlan.FlatAppearance.MouseDownBackColor = Color.FromArgb(178, 219, 186);
            btn_RefreshPriorityPlan.FlatStyle = FlatStyle.Flat;
            btn_RefreshPriorityPlan.Font = new Font("Lucida Sans", 10.25F);
            btn_RefreshPriorityPlan.ForeColor = Color.FromArgb(0, 97, 0);
            btn_RefreshPriorityPlan.Location = new Point(2, 27);
            btn_RefreshPriorityPlan.Margin = new Padding(2, 0, 0, 4);
            btn_RefreshPriorityPlan.Name = "btn_RefreshPriorityPlan";
            btn_RefreshPriorityPlan.Size = new Size(207, 26);
            btn_RefreshPriorityPlan.TabIndex = 10;
            btn_RefreshPriorityPlan.Text = "Uppdatera Körplanering";
            btn_RefreshPriorityPlan.UseVisualStyleBackColor = false;
            btn_RefreshPriorityPlan.Click += RefreshPriorityPlan_Click;
            // 
            // tb_ProdGrupp
            // 
            tb_ProdGrupp.Dock = DockStyle.Fill;
            tb_ProdGrupp.Location = new Point(209, 29);
            tb_ProdGrupp.Margin = new Padding(0, 2, 0, 0);
            tb_ProdGrupp.Name = "tb_ProdGrupp";
            tb_ProdGrupp.ReadOnly = true;
            tb_ProdGrupp.Size = new Size(71, 23);
            tb_ProdGrupp.TabIndex = 9;
            tb_ProdGrupp.TextChanged += ProdGrupp_TextChanged;
            tb_ProdGrupp.MouseDown += ProdGrupp_MouseDown;
            // 
            // tb_ProdBenämning
            // 
            tb_ProdBenämning.Dock = DockStyle.Left;
            tb_ProdBenämning.Location = new Point(280, 29);
            tb_ProdBenämning.Margin = new Padding(0, 2, 0, 0);
            tb_ProdBenämning.Name = "tb_ProdBenämning";
            tb_ProdBenämning.ReadOnly = true;
            tb_ProdBenämning.Size = new Size(280, 23);
            tb_ProdBenämning.TabIndex = 9;
            tb_ProdBenämning.MouseDown += ProdGrupp_MouseDown;
            // 
            // dgv_PriorityPlanning
            // 
            dgv_PriorityPlanning.AllowUserToAddRows = false;
            dgv_PriorityPlanning.AllowUserToDeleteRows = false;
            dgv_PriorityPlanning.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_PriorityPlanning.BackgroundColor = Color.FromArgb(60, 60, 60);
            dgv_PriorityPlanning.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_PriorityPlanning.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_PriorityPlanning.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv_PriorityPlanning.DefaultCellStyle = dataGridViewCellStyle2;
            dgv_PriorityPlanning.Dock = DockStyle.Fill;
            dgv_PriorityPlanning.Location = new Point(0, 57);
            dgv_PriorityPlanning.Margin = new Padding(6, 0, 4, 12);
            dgv_PriorityPlanning.Name = "dgv_PriorityPlanning";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_PriorityPlanning.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv_PriorityPlanning.RowHeadersVisible = false;
            dgv_PriorityPlanning.ScrollBars = ScrollBars.Vertical;
            dgv_PriorityPlanning.Size = new Size(902, 361);
            dgv_PriorityPlanning.TabIndex = 8;
            dgv_PriorityPlanning.CellMouseDown += Copy_Text_MouseDown;
            // 
            // Main_Priorityplanning
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 60, 60);
            Controls.Add(dgv_PriorityPlanning);
            Controls.Add(tlp_InfoLabels);
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Main_Priorityplanning";
            Size = new Size(1363, 418);
            tlp_InfoLabels.ResumeLayout(false);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ((ISupportInitialize)dgv_PriorityPlanning).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Label label_ProductionSchedule;
        private Label label_ProdGroup;
        private TableLayoutPanel tlp_InfoLabels;
        private Label label_Green;
        private Label label_Yellow;
        private Label label_Blue;
        private Label label_White;
        private Label label_Brown;
        private TableLayoutPanel tlp_Main;
        public DataGridView dgv_PriorityPlanning;
        private Label label_Red;
        private Button btn_RefreshPriorityPlan;
        public TextBox tb_ProdGrupp;
        public TextBox tb_ProdBenämning;
    }
}
