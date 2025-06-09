using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.OrderManagement
{
    partial class FinishOrder
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FinishOrder));
            label_FinishOrder_Header = new Label();
            chb_FinishOrder_PrintOrder = new CheckBox();
            label_Info = new Label();
            chb_0 = new CheckBox();
            chb_1 = new CheckBox();
            chb_2 = new CheckBox();
            chb_3 = new CheckBox();
            chb_4 = new CheckBox();
            chb_5 = new CheckBox();
            label_Info_0 = new Label();
            label_Info_1 = new Label();
            label_Info_2 = new Label();
            label_Info_3 = new Label();
            label_Info_4 = new Label();
            label_Info_5 = new Label();
            chb_Rapportera_Jira = new CheckBox();
            panel_Points = new Panel();
            pb_Info_Jira = new PictureBox();
            panel_Info = new Panel();
            tlp_Buttons = new TableLayoutPanel();
            btn_FinishOrder = new Button();
            btn_Abort = new Button();
            panel_Points.SuspendLayout();
            ((ISupportInitialize)pb_Info_Jira).BeginInit();
            panel_Info.SuspendLayout();
            tlp_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // label_FinishOrder_Header
            // 
            label_FinishOrder_Header.BackColor = Color.Transparent;
            label_FinishOrder_Header.Dock = DockStyle.Top;
            label_FinishOrder_Header.Font = new Font("Arial", 16F, FontStyle.Bold);
            label_FinishOrder_Header.ForeColor = Color.FromArgb(171, 150, 85);
            label_FinishOrder_Header.Location = new Point(0, 0);
            label_FinishOrder_Header.Margin = new Padding(4, 0, 4, 0);
            label_FinishOrder_Header.Name = "label_FinishOrder_Header";
            label_FinishOrder_Header.Size = new Size(540, 38);
            label_FinishOrder_Header.TabIndex = 0;
            label_FinishOrder_Header.Text = "Ordern är nu klar";
            label_FinishOrder_Header.TextAlign = ContentAlignment.BottomCenter;
            // 
            // chb_FinishOrder_PrintOrder
            // 
            chb_FinishOrder_PrintOrder.AutoSize = true;
            chb_FinishOrder_PrintOrder.Checked = true;
            chb_FinishOrder_PrintOrder.CheckState = CheckState.Checked;
            chb_FinishOrder_PrintOrder.Font = new Font("Consolas", 10.25F);
            chb_FinishOrder_PrintOrder.ForeColor = Color.FromArgb(239, 228, 177);
            chb_FinishOrder_PrintOrder.Location = new Point(77, 6);
            chb_FinishOrder_PrintOrder.Margin = new Padding(4, 3, 4, 3);
            chb_FinishOrder_PrintOrder.Name = "chb_FinishOrder_PrintOrder";
            chb_FinishOrder_PrintOrder.Size = new Size(227, 21);
            chb_FinishOrder_PrintOrder.TabIndex = 1;
            chb_FinishOrder_PrintOrder.Text = "Vill du skriva ut ordern?";
            chb_FinishOrder_PrintOrder.UseVisualStyleBackColor = true;
            chb_FinishOrder_PrintOrder.Visible = false;
            // 
            // label_Info
            // 
            label_Info.AutoSize = true;
            label_Info.Font = new Font("Arial", 12.25F);
            label_Info.ForeColor = Color.FromArgb(239, 228, 177);
            label_Info.Location = new Point(4, 14);
            label_Info.Margin = new Padding(4, 0, 4, 0);
            label_Info.Name = "label_Info";
            label_Info.Size = new Size(380, 19);
            label_Info.TabIndex = 1;
            label_Info.Text = "Betygsätt ordern baserat på hur materialet har gått.";
            // 
            // chb_0
            // 
            chb_0.AutoSize = true;
            chb_0.Font = new Font("Courier New", 30F);
            chb_0.ForeColor = Color.LemonChiffon;
            chb_0.Location = new Point(8, 54);
            chb_0.Margin = new Padding(4, 3, 4, 3);
            chb_0.Name = "chb_0";
            chb_0.Size = new Size(61, 46);
            chb_0.TabIndex = 3;
            chb_0.Text = "0";
            chb_0.UseVisualStyleBackColor = true;
            chb_0.CheckedChanged += CheckedChanged;
            // 
            // chb_1
            // 
            chb_1.AutoSize = true;
            chb_1.Font = new Font("Courier New", 30F);
            chb_1.ForeColor = Color.FromArgb(239, 228, 177);
            chb_1.Location = new Point(8, 106);
            chb_1.Margin = new Padding(4, 3, 4, 3);
            chb_1.Name = "chb_1";
            chb_1.Size = new Size(61, 46);
            chb_1.TabIndex = 3;
            chb_1.Text = "1";
            chb_1.UseVisualStyleBackColor = true;
            chb_1.CheckedChanged += CheckedChanged;
            // 
            // chb_2
            // 
            chb_2.AutoSize = true;
            chb_2.Font = new Font("Courier New", 30F);
            chb_2.ForeColor = Color.FromArgb(239, 228, 177);
            chb_2.Location = new Point(8, 158);
            chb_2.Margin = new Padding(4, 3, 4, 3);
            chb_2.Name = "chb_2";
            chb_2.Size = new Size(61, 46);
            chb_2.TabIndex = 3;
            chb_2.Text = "2";
            chb_2.UseVisualStyleBackColor = true;
            chb_2.CheckedChanged += CheckedChanged;
            // 
            // chb_3
            // 
            chb_3.AutoSize = true;
            chb_3.Font = new Font("Courier New", 30F);
            chb_3.ForeColor = Color.FromArgb(239, 228, 177);
            chb_3.Location = new Point(8, 210);
            chb_3.Margin = new Padding(4, 3, 4, 3);
            chb_3.Name = "chb_3";
            chb_3.Size = new Size(61, 46);
            chb_3.TabIndex = 3;
            chb_3.Text = "3";
            chb_3.UseVisualStyleBackColor = true;
            chb_3.CheckedChanged += CheckedChanged;
            // 
            // chb_4
            // 
            chb_4.AutoSize = true;
            chb_4.Font = new Font("Courier New", 30F);
            chb_4.ForeColor = Color.FromArgb(239, 228, 177);
            chb_4.Location = new Point(8, 262);
            chb_4.Margin = new Padding(4, 3, 4, 3);
            chb_4.Name = "chb_4";
            chb_4.Size = new Size(61, 46);
            chb_4.TabIndex = 3;
            chb_4.Text = "4";
            chb_4.UseVisualStyleBackColor = true;
            chb_4.CheckedChanged += CheckedChanged;
            // 
            // chb_5
            // 
            chb_5.AutoSize = true;
            chb_5.Font = new Font("Courier New", 30F);
            chb_5.ForeColor = Color.FromArgb(239, 228, 177);
            chb_5.Location = new Point(8, 314);
            chb_5.Margin = new Padding(4, 3, 4, 3);
            chb_5.Name = "chb_5";
            chb_5.Size = new Size(61, 46);
            chb_5.TabIndex = 3;
            chb_5.Text = "5";
            chb_5.UseVisualStyleBackColor = true;
            chb_5.CheckedChanged += CheckedChanged;
            // 
            // label_Info_0
            // 
            label_Info_0.Font = new Font("Consolas", 9F);
            label_Info_0.ForeColor = Color.LemonChiffon;
            label_Info_0.Location = new Point(97, 66);
            label_Info_0.Margin = new Padding(4, 0, 4, 0);
            label_Info_0.Name = "label_Info_0";
            label_Info_0.Size = new Size(397, 40);
            label_Info_0.TabIndex = 1;
            label_Info_0.Text = "Materialet var oanvändbart.";
            // 
            // label_Info_1
            // 
            label_Info_1.Font = new Font("Consolas", 9F);
            label_Info_1.ForeColor = Color.FromArgb(239, 228, 177);
            label_Info_1.Location = new Point(97, 118);
            label_Info_1.Margin = new Padding(4, 0, 4, 0);
            label_Info_1.Name = "label_Info_1";
            label_Info_1.Size = new Size(397, 40);
            label_Info_1.TabIndex = 1;
            label_Info_1.Text = "Materialet var användbart men medförde mycket stora problem.";
            // 
            // label_Info_2
            // 
            label_Info_2.Font = new Font("Consolas", 9F);
            label_Info_2.ForeColor = Color.FromArgb(239, 228, 177);
            label_Info_2.Location = new Point(97, 170);
            label_Info_2.Margin = new Padding(4, 0, 4, 0);
            label_Info_2.Name = "label_Info_2";
            label_Info_2.Size = new Size(397, 40);
            label_Info_2.TabIndex = 1;
            label_Info_2.Text = "Materialet var användbart men medförde mer problem än vanligt.";
            // 
            // label_Info_3
            // 
            label_Info_3.Font = new Font("Consolas", 9F);
            label_Info_3.ForeColor = Color.FromArgb(239, 228, 177);
            label_Info_3.Location = new Point(97, 222);
            label_Info_3.Margin = new Padding(4, 0, 4, 0);
            label_Info_3.Name = "label_Info_3";
            label_Info_3.Size = new Size(397, 40);
            label_Info_3.TabIndex = 1;
            label_Info_3.Text = "Material uppförde sig som vanligt med normala hanterbara variationer från materialet.";
            // 
            // label_Info_4
            // 
            label_Info_4.Font = new Font("Consolas", 9F);
            label_Info_4.ForeColor = Color.FromArgb(239, 228, 177);
            label_Info_4.Location = new Point(97, 273);
            label_Info_4.Margin = new Padding(4, 0, 4, 0);
            label_Info_4.Name = "label_Info_4";
            label_Info_4.Size = new Size(397, 40);
            label_Info_4.TabIndex = 1;
            label_Info_4.Text = "Körningen gick bra med färre än vanligt problem med materialet.";
            // 
            // label_Info_5
            // 
            label_Info_5.Font = new Font("Consolas", 9F);
            label_Info_5.ForeColor = Color.FromArgb(239, 228, 177);
            label_Info_5.Location = new Point(97, 325);
            label_Info_5.Margin = new Padding(4, 0, 4, 0);
            label_Info_5.Name = "label_Info_5";
            label_Info_5.Size = new Size(397, 40);
            label_Info_5.TabIndex = 1;
            label_Info_5.Text = "Körningen gick mycket bra utan problem orsakade av materialet.";
            // 
            // chb_Rapportera_Jira
            // 
            chb_Rapportera_Jira.AutoSize = true;
            chb_Rapportera_Jira.Font = new Font("Consolas", 10.25F);
            chb_Rapportera_Jira.ForeColor = Color.FromArgb(239, 228, 177);
            chb_Rapportera_Jira.Location = new Point(77, 37);
            chb_Rapportera_Jira.Margin = new Padding(4, 3, 4, 3);
            chb_Rapportera_Jira.Name = "chb_Rapportera_Jira";
            chb_Rapportera_Jira.Size = new Size(371, 21);
            chb_Rapportera_Jira.TabIndex = 1;
            chb_Rapportera_Jira.Text = "Rapportera problem till produktionssupport?";
            chb_Rapportera_Jira.UseVisualStyleBackColor = true;
            // 
            // panel_Points
            // 
            panel_Points.BorderStyle = BorderStyle.FixedSingle;
            panel_Points.Controls.Add(label_Info);
            panel_Points.Controls.Add(chb_0);
            panel_Points.Controls.Add(label_Info_0);
            panel_Points.Controls.Add(chb_5);
            panel_Points.Controls.Add(label_Info_5);
            panel_Points.Controls.Add(chb_1);
            panel_Points.Controls.Add(chb_4);
            panel_Points.Controls.Add(label_Info_1);
            panel_Points.Controls.Add(label_Info_4);
            panel_Points.Controls.Add(chb_3);
            panel_Points.Controls.Add(chb_2);
            panel_Points.Controls.Add(label_Info_2);
            panel_Points.Controls.Add(label_Info_3);
            panel_Points.Dock = DockStyle.Fill;
            panel_Points.Location = new Point(0, 112);
            panel_Points.Margin = new Padding(4, 3, 4, 3);
            panel_Points.Name = "panel_Points";
            panel_Points.Size = new Size(540, 371);
            panel_Points.TabIndex = 5;
            // 
            // pb_Info_Jira
            // 
            pb_Info_Jira.BackColor = Color.Transparent;
            pb_Info_Jira.BackgroundImage = (Image)resources.GetObject("pb_Info_Jira.BackgroundImage");
            pb_Info_Jira.BackgroundImageLayout = ImageLayout.Stretch;
            pb_Info_Jira.Cursor = Cursors.Hand;
            pb_Info_Jira.Location = new Point(4, 6);
            pb_Info_Jira.Margin = new Padding(4, 3, 4, 3);
            pb_Info_Jira.Name = "pb_Info_Jira";
            pb_Info_Jira.Size = new Size(40, 33);
            pb_Info_Jira.SizeMode = PictureBoxSizeMode.Zoom;
            pb_Info_Jira.TabIndex = 871;
            pb_Info_Jira.TabStop = false;
            pb_Info_Jira.Click += Info_Jira_Click;
            // 
            // panel_Info
            // 
            panel_Info.Controls.Add(pb_Info_Jira);
            panel_Info.Controls.Add(chb_FinishOrder_PrintOrder);
            panel_Info.Controls.Add(chb_Rapportera_Jira);
            panel_Info.Dock = DockStyle.Top;
            panel_Info.Location = new Point(0, 38);
            panel_Info.Name = "panel_Info";
            panel_Info.Size = new Size(540, 74);
            panel_Info.TabIndex = 872;
            // 
            // tlp_Buttons
            // 
            tlp_Buttons.ColumnCount = 3;
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle());
            tlp_Buttons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlp_Buttons.Controls.Add(btn_FinishOrder, 0, 0);
            tlp_Buttons.Controls.Add(btn_Abort, 2, 0);
            tlp_Buttons.Dock = DockStyle.Bottom;
            tlp_Buttons.Location = new Point(0, 483);
            tlp_Buttons.Name = "tlp_Buttons";
            tlp_Buttons.RowCount = 1;
            tlp_Buttons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlp_Buttons.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlp_Buttons.Size = new Size(540, 38);
            tlp_Buttons.TabIndex = 873;
            // 
            // btn_FinishOrder
            // 
            btn_FinishOrder.Dock = DockStyle.Fill;
            btn_FinishOrder.FlatAppearance.BorderSize = 0;
            btn_FinishOrder.FlatStyle = FlatStyle.Flat;
            btn_FinishOrder.Font = new Font("Segoe UI", 12F);
            btn_FinishOrder.ForeColor = Color.FromArgb(198, 239, 206);
            btn_FinishOrder.Location = new Point(3, 3);
            btn_FinishOrder.Name = "btn_FinishOrder";
            btn_FinishOrder.Size = new Size(264, 32);
            btn_FinishOrder.TabIndex = 1;
            btn_FinishOrder.Text = "Avsluta Order";
            btn_FinishOrder.TextAlign = ContentAlignment.MiddleLeft;
            btn_FinishOrder.UseVisualStyleBackColor = true;
            btn_FinishOrder.Click += Klar_Click;
            // 
            // btn_Abort
            // 
            btn_Abort.Dock = DockStyle.Fill;
            btn_Abort.FlatAppearance.BorderSize = 0;
            btn_Abort.FlatStyle = FlatStyle.Flat;
            btn_Abort.Font = new Font("Segoe UI", 12F);
            btn_Abort.ForeColor = Color.FromArgb(255, 199, 206);
            btn_Abort.Location = new Point(273, 3);
            btn_Abort.Name = "btn_Abort";
            btn_Abort.Size = new Size(264, 32);
            btn_Abort.TabIndex = 0;
            btn_Abort.Text = "Avbryt";
            btn_Abort.TextAlign = ContentAlignment.MiddleRight;
            btn_Abort.UseVisualStyleBackColor = true;
            btn_Abort.Click += Avbryt_Click;
            // 
            // FinishOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(540, 521);
            Controls.Add(panel_Points);
            Controls.Add(tlp_Buttons);
            Controls.Add(panel_Info);
            Controls.Add(label_FinishOrder_Header);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FinishOrder";
            Text = "OrderKlar";
            panel_Points.ResumeLayout(false);
            panel_Points.PerformLayout();
            ((ISupportInitialize)pb_Info_Jira).EndInit();
            panel_Info.ResumeLayout(false);
            panel_Info.PerformLayout();
            tlp_Buttons.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private Label label_FinishOrder_Header;
        private CheckBox chb_FinishOrder_PrintOrder;
        private Label label_Info;
        private CheckBox chb_0;
        private CheckBox chb_1;
        private CheckBox chb_2;
        private CheckBox chb_3;
        private CheckBox chb_4;
        private CheckBox chb_5;
        private Label label_Info_0;
        private Label label_Info_1;
        private Label label_Info_2;
        private Label label_Info_3;
        private Label label_Info_4;
        private Label label_Info_5;
        private CheckBox chb_Rapportera_Jira;
        private Panel panel_Points;
        private PictureBox pb_Info_Jira;
        private Panel panel_Info;
        private TableLayoutPanel tlp_Buttons;
        private Button btn_FinishOrder;
        private Button btn_Abort;
    }
}