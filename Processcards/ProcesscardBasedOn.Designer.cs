using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Processcards
{
    partial class ProcesscardBasedOn
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
            label_RevNr = new Label();
            label_EstablishedBy = new Label();
            label_ProcesscardApprovedDate = new Label();
            rb_HistoricalData = new RadioButton();
            rb_Validated = new RadioButton();
            tlp_Main = new TableLayoutPanel();
            btn_ProcesscardBasedOn = new Button();
            label_Empty_0 = new Label();
            lbl_ApprovedDate = new Label();
            tb_Validerade_Loter = new RichTextBox();
            lbl_UpprättatAv_Sign_AnstNr = new Label();
            lbl_RevNr = new Label();
            label_ApprovedBy = new Label();
            rb_FramtagningAvProcessfönster = new RadioButton();
            lbl_QA_Sign = new Label();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // label_RevNr
            // 
            label_RevNr.AutoSize = true;
            label_RevNr.BackColor = Color.White;
            label_RevNr.Dock = DockStyle.Fill;
            label_RevNr.Font = new Font("Arial", 7F);
            label_RevNr.Location = new Point(515, 32);
            label_RevNr.Margin = new Padding(0);
            label_RevNr.Name = "label_RevNr";
            label_RevNr.Size = new Size(142, 18);
            label_RevNr.TabIndex = 873;
            label_RevNr.Text = "RevisionsNr:";
            label_RevNr.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_EstablishedBy
            // 
            label_EstablishedBy.AutoSize = true;
            label_EstablishedBy.BackColor = Color.White;
            label_EstablishedBy.Dock = DockStyle.Fill;
            label_EstablishedBy.Font = new Font("Arial", 7F);
            label_EstablishedBy.Location = new Point(515, 50);
            label_EstablishedBy.Margin = new Padding(0);
            label_EstablishedBy.Name = "label_EstablishedBy";
            label_EstablishedBy.Size = new Size(142, 18);
            label_EstablishedBy.TabIndex = 840;
            label_EstablishedBy.Text = "Upprättat av: Sign./Anst.nr:";
            label_EstablishedBy.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_ProcesscardApprovedDate
            // 
            label_ProcesscardApprovedDate.AutoSize = true;
            label_ProcesscardApprovedDate.BackColor = Color.White;
            label_ProcesscardApprovedDate.Dock = DockStyle.Fill;
            label_ProcesscardApprovedDate.Font = new Font("Arial", 7F);
            label_ProcesscardApprovedDate.ForeColor = Color.Black;
            label_ProcesscardApprovedDate.Location = new Point(201, 32);
            label_ProcesscardApprovedDate.Margin = new Padding(1, 0, 0, 1);
            label_ProcesscardApprovedDate.Name = "label_ProcesscardApprovedDate";
            label_ProcesscardApprovedDate.Size = new Size(178, 17);
            label_ProcesscardApprovedDate.TabIndex = 837;
            label_ProcesscardApprovedDate.Text = "Processkort godkänt den:";
            label_ProcesscardApprovedDate.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rb_HistoricalData
            // 
            rb_HistoricalData.AutoSize = true;
            rb_HistoricalData.BackColor = Color.White;
            rb_HistoricalData.Cursor = Cursors.Hand;
            rb_HistoricalData.Dock = DockStyle.Fill;
            rb_HistoricalData.Enabled = false;
            rb_HistoricalData.Font = new Font("Arial", 7F);
            rb_HistoricalData.ForeColor = Color.Black;
            rb_HistoricalData.Location = new Point(1, 32);
            rb_HistoricalData.Margin = new Padding(1, 0, 0, 0);
            rb_HistoricalData.Name = "rb_HistoricalData";
            rb_HistoricalData.Padding = new Padding(6, 0, 0, 0);
            rb_HistoricalData.Size = new Size(199, 18);
            rb_HistoricalData.TabIndex = 838;
            rb_HistoricalData.Text = "Historiska Data";
            rb_HistoricalData.UseVisualStyleBackColor = false;
            rb_HistoricalData.CheckedChanged += HistoriskaData_CheckedChanged;
            // 
            // rb_Validated
            // 
            rb_Validated.AutoSize = true;
            rb_Validated.BackColor = Color.White;
            rb_Validated.Cursor = Cursors.Hand;
            rb_Validated.Dock = DockStyle.Fill;
            rb_Validated.Enabled = false;
            rb_Validated.Font = new Font("Arial", 7F);
            rb_Validated.ForeColor = Color.Black;
            rb_Validated.Location = new Point(1, 50);
            rb_Validated.Margin = new Padding(1, 0, 0, 0);
            rb_Validated.Name = "rb_Validated";
            rb_Validated.Padding = new Padding(6, 0, 0, 0);
            rb_Validated.Size = new Size(199, 18);
            rb_Validated.TabIndex = 838;
            rb_Validated.Text = "Validerat på dessa loter:";
            rb_Validated.UseVisualStyleBackColor = false;
            rb_Validated.CheckedChanged += Validerat_CheckedChanged;
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 5;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 200F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 136F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 142F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80F));
            tlp_Main.Controls.Add(btn_ProcesscardBasedOn, 0, 0);
            tlp_Main.Controls.Add(label_Empty_0, 1, 3);
            tlp_Main.Controls.Add(lbl_ApprovedDate, 2, 1);
            tlp_Main.Controls.Add(tb_Validerade_Loter, 1, 2);
            tlp_Main.Controls.Add(lbl_UpprättatAv_Sign_AnstNr, 4, 2);
            tlp_Main.Controls.Add(lbl_RevNr, 4, 1);
            tlp_Main.Controls.Add(label_RevNr, 3, 1);
            tlp_Main.Controls.Add(rb_HistoricalData, 0, 1);
            tlp_Main.Controls.Add(label_ApprovedBy, 3, 3);
            tlp_Main.Controls.Add(rb_Validated, 0, 2);
            tlp_Main.Controls.Add(label_EstablishedBy, 3, 2);
            tlp_Main.Controls.Add(rb_FramtagningAvProcessfönster, 0, 3);
            tlp_Main.Controls.Add(label_ProcesscardApprovedDate, 1, 1);
            tlp_Main.Controls.Add(lbl_QA_Sign, 4, 3);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 0);
            tlp_Main.Margin = new Padding(4, 3, 4, 3);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 4;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tlp_Main.Size = new Size(737, 89);
            tlp_Main.TabIndex = 878;
            // 
            // btn_ProcesscardBasedOn
            // 
            btn_ProcesscardBasedOn.BackColor = Color.LightGray;
            tlp_Main.SetColumnSpan(btn_ProcesscardBasedOn, 5);
            btn_ProcesscardBasedOn.Cursor = Cursors.Hand;
            btn_ProcesscardBasedOn.Dock = DockStyle.Fill;
            btn_ProcesscardBasedOn.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 45);
            btn_ProcesscardBasedOn.FlatStyle = FlatStyle.Flat;
            btn_ProcesscardBasedOn.Font = new Font("Palatino Linotype", 10F);
            btn_ProcesscardBasedOn.ForeColor = Color.SaddleBrown;
            btn_ProcesscardBasedOn.Location = new Point(0, 0);
            btn_ProcesscardBasedOn.Margin = new Padding(0);
            btn_ProcesscardBasedOn.Name = "btn_ProcesscardBasedOn";
            btn_ProcesscardBasedOn.Size = new Size(737, 32);
            btn_ProcesscardBasedOn.TabIndex = 915;
            btn_ProcesscardBasedOn.Text = "Processkort är baserat på:";
            btn_ProcesscardBasedOn.TextAlign = ContentAlignment.TopLeft;
            btn_ProcesscardBasedOn.UseVisualStyleBackColor = false;
            // 
            // label_Empty_0
            // 
            label_Empty_0.BackColor = Color.White;
            tlp_Main.SetColumnSpan(label_Empty_0, 2);
            label_Empty_0.Dock = DockStyle.Fill;
            label_Empty_0.Font = new Font("Consolas", 8.25F);
            label_Empty_0.ForeColor = Color.DarkSlateGray;
            label_Empty_0.Location = new Point(200, 68);
            label_Empty_0.Margin = new Padding(0, 0, 0, 1);
            label_Empty_0.Name = "label_Empty_0";
            label_Empty_0.Size = new Size(315, 20);
            label_Empty_0.TabIndex = 914;
            // 
            // lbl_ApprovedDate
            // 
            lbl_ApprovedDate.BackColor = Color.White;
            lbl_ApprovedDate.Dock = DockStyle.Fill;
            lbl_ApprovedDate.Font = new Font("Consolas", 8.25F);
            lbl_ApprovedDate.ForeColor = Color.Gray;
            lbl_ApprovedDate.Location = new Point(380, 32);
            lbl_ApprovedDate.Margin = new Padding(1, 0, 1, 1);
            lbl_ApprovedDate.Name = "lbl_ApprovedDate";
            lbl_ApprovedDate.Size = new Size(134, 17);
            lbl_ApprovedDate.TabIndex = 912;
            lbl_ApprovedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_Validerade_Loter
            // 
            tb_Validerade_Loter.BackColor = Color.White;
            tb_Validerade_Loter.BorderStyle = BorderStyle.None;
            tlp_Main.SetColumnSpan(tb_Validerade_Loter, 2);
            tb_Validerade_Loter.Dock = DockStyle.Fill;
            tb_Validerade_Loter.Font = new Font("Consolas", 8.25F);
            tb_Validerade_Loter.ForeColor = Color.Gray;
            tb_Validerade_Loter.Location = new Point(201, 50);
            tb_Validerade_Loter.Margin = new Padding(1, 0, 1, 1);
            tb_Validerade_Loter.Name = "tb_Validerade_Loter";
            tb_Validerade_Loter.ScrollBars = RichTextBoxScrollBars.Vertical;
            tb_Validerade_Loter.Size = new Size(313, 17);
            tb_Validerade_Loter.TabIndex = 911;
            tb_Validerade_Loter.Text = "";
            // 
            // lbl_UpprättatAv_Sign_AnstNr
            // 
            lbl_UpprättatAv_Sign_AnstNr.BackColor = Color.White;
            lbl_UpprättatAv_Sign_AnstNr.Cursor = Cursors.Hand;
            lbl_UpprättatAv_Sign_AnstNr.Dock = DockStyle.Fill;
            lbl_UpprättatAv_Sign_AnstNr.Font = new Font("Consolas", 8.25F);
            lbl_UpprättatAv_Sign_AnstNr.ForeColor = Color.Gray;
            lbl_UpprättatAv_Sign_AnstNr.Location = new Point(658, 50);
            lbl_UpprättatAv_Sign_AnstNr.Margin = new Padding(1, 0, 1, 1);
            lbl_UpprättatAv_Sign_AnstNr.Name = "lbl_UpprättatAv_Sign_AnstNr";
            lbl_UpprättatAv_Sign_AnstNr.Size = new Size(78, 17);
            lbl_UpprättatAv_Sign_AnstNr.TabIndex = 909;
            lbl_UpprättatAv_Sign_AnstNr.TextAlign = ContentAlignment.MiddleCenter;
            lbl_UpprättatAv_Sign_AnstNr.Click += UpprättatAv_Sign_AnstNr_Click;
            // 
            // lbl_RevNr
            // 
            lbl_RevNr.BackColor = Color.LightSteelBlue;
            lbl_RevNr.Cursor = Cursors.Hand;
            lbl_RevNr.Dock = DockStyle.Fill;
            lbl_RevNr.Font = new Font("Consolas", 8.25F);
            lbl_RevNr.ForeColor = Color.Gray;
            lbl_RevNr.Location = new Point(658, 32);
            lbl_RevNr.Margin = new Padding(1, 0, 1, 1);
            lbl_RevNr.Name = "lbl_RevNr";
            lbl_RevNr.Size = new Size(78, 17);
            lbl_RevNr.TabIndex = 908;
            lbl_RevNr.TextAlign = ContentAlignment.MiddleCenter;
            lbl_RevNr.MouseDown += RevNr_MouseDown;
            // 
            // label_ApprovedBy
            // 
            label_ApprovedBy.AutoSize = true;
            label_ApprovedBy.BackColor = Color.White;
            label_ApprovedBy.Dock = DockStyle.Fill;
            label_ApprovedBy.Font = new Font("Arial", 7F);
            label_ApprovedBy.Location = new Point(515, 68);
            label_ApprovedBy.Margin = new Padding(0, 0, 0, 1);
            label_ApprovedBy.Name = "label_ApprovedBy";
            label_ApprovedBy.Size = new Size(142, 20);
            label_ApprovedBy.TabIndex = 839;
            label_ApprovedBy.Text = "Godkänt av: Sign./Anst nr:";
            label_ApprovedBy.TextAlign = ContentAlignment.MiddleRight;
            // 
            // rb_FramtagningAvProcessfönster
            // 
            rb_FramtagningAvProcessfönster.AutoSize = true;
            rb_FramtagningAvProcessfönster.BackColor = Color.White;
            rb_FramtagningAvProcessfönster.Checked = true;
            rb_FramtagningAvProcessfönster.Cursor = Cursors.Hand;
            rb_FramtagningAvProcessfönster.Dock = DockStyle.Fill;
            rb_FramtagningAvProcessfönster.Enabled = false;
            rb_FramtagningAvProcessfönster.Font = new Font("Arial", 7F);
            rb_FramtagningAvProcessfönster.ForeColor = Color.Black;
            rb_FramtagningAvProcessfönster.Location = new Point(1, 68);
            rb_FramtagningAvProcessfönster.Margin = new Padding(1, 0, 0, 1);
            rb_FramtagningAvProcessfönster.Name = "rb_FramtagningAvProcessfönster";
            rb_FramtagningAvProcessfönster.Padding = new Padding(6, 0, 0, 0);
            rb_FramtagningAvProcessfönster.Size = new Size(199, 20);
            rb_FramtagningAvProcessfönster.TabIndex = 838;
            rb_FramtagningAvProcessfönster.TabStop = true;
            rb_FramtagningAvProcessfönster.Text = "Framtagning av Processfönster:";
            rb_FramtagningAvProcessfönster.UseVisualStyleBackColor = false;
            rb_FramtagningAvProcessfönster.CheckedChanged += FramtagningAvProcessfönster_CheckedChanged;
            // 
            // lbl_QA_Sign
            // 
            lbl_QA_Sign.BackColor = Color.White;
            lbl_QA_Sign.Cursor = Cursors.Hand;
            lbl_QA_Sign.Dock = DockStyle.Fill;
            lbl_QA_Sign.Enabled = false;
            lbl_QA_Sign.Font = new Font("Consolas", 8.25F);
            lbl_QA_Sign.ForeColor = Color.Gray;
            lbl_QA_Sign.Location = new Point(658, 68);
            lbl_QA_Sign.Margin = new Padding(1, 0, 1, 1);
            lbl_QA_Sign.Name = "lbl_QA_Sign";
            lbl_QA_Sign.Size = new Size(78, 20);
            lbl_QA_Sign.TabIndex = 913;
            lbl_QA_Sign.TextAlign = ContentAlignment.MiddleCenter;
            lbl_QA_Sign.Click += QA_Sign_Click;
            // 
            // ProcesscardBasedOn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(tlp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProcesscardBasedOn";
            Size = new Size(737, 89);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private Label label_RevNr;
        private Label label_EstablishedBy;
        private Label label_ProcesscardApprovedDate;
        public RadioButton rb_HistoricalData;
        public RadioButton rb_Validated;
        private TableLayoutPanel tlp_Main;
        public Label lbl_RevNr;
        public RichTextBox tb_Validerade_Loter;
        public Label lbl_UpprättatAv_Sign_AnstNr;
        public Label lbl_ApprovedDate;
        private Button btn_ProcesscardBasedOn;
        private Label label_Empty_0;
        private Label label_ApprovedBy;
        public RadioButton rb_FramtagningAvProcessfönster;
        public Label lbl_QA_Sign;
    }
}
