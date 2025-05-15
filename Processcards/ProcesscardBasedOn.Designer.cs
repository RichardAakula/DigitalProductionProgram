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
            this.label_RevNr = new System.Windows.Forms.Label();
            this.label_EstablishedBy = new System.Windows.Forms.Label();
            this.label_ProcesscardApprovedDate = new System.Windows.Forms.Label();
            this.rb_HistoricalData = new System.Windows.Forms.RadioButton();
            this.rb_Validated = new System.Windows.Forms.RadioButton();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ProcesscardBasedOn = new System.Windows.Forms.Button();
            this.label_Empty_0 = new System.Windows.Forms.Label();
            this.lbl_ApprovedDate = new System.Windows.Forms.Label();
            this.tb_Validerade_Loter = new System.Windows.Forms.RichTextBox();
            this.lbl_UpprättatAv_Sign_AnstNr = new System.Windows.Forms.Label();
            this.lbl_RevNr = new System.Windows.Forms.Label();
            this.label_ApprovedBy = new System.Windows.Forms.Label();
            this.rb_FramtagningAvProcessfönster = new System.Windows.Forms.RadioButton();
            this.lbl_QA_Sign = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_RevNr
            // 
            this.label_RevNr.AutoSize = true;
            this.label_RevNr.BackColor = System.Drawing.Color.White;
            this.label_RevNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_RevNr.Font = new System.Drawing.Font("Arial", 7F);
            this.label_RevNr.Location = new System.Drawing.Point(566, 28);
            this.label_RevNr.Margin = new System.Windows.Forms.Padding(0);
            this.label_RevNr.Name = "label_RevNr";
            this.label_RevNr.Size = new System.Drawing.Size(135, 16);
            this.label_RevNr.TabIndex = 873;
            this.label_RevNr.Text = "RevisionsNr:";
            this.label_RevNr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_EstablishedBy
            // 
            this.label_EstablishedBy.AutoSize = true;
            this.label_EstablishedBy.BackColor = System.Drawing.Color.White;
            this.label_EstablishedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_EstablishedBy.Font = new System.Drawing.Font("Arial", 7F);
            this.label_EstablishedBy.Location = new System.Drawing.Point(566, 44);
            this.label_EstablishedBy.Margin = new System.Windows.Forms.Padding(0);
            this.label_EstablishedBy.Name = "label_EstablishedBy";
            this.label_EstablishedBy.Size = new System.Drawing.Size(135, 16);
            this.label_EstablishedBy.TabIndex = 840;
            this.label_EstablishedBy.Text = "Upprättat av: Sign./Anst.nr:";
            this.label_EstablishedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_ProcesscardApprovedDate
            // 
            this.label_ProcesscardApprovedDate.AutoSize = true;
            this.label_ProcesscardApprovedDate.BackColor = System.Drawing.Color.White;
            this.label_ProcesscardApprovedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ProcesscardApprovedDate.Font = new System.Drawing.Font("Arial", 7F);
            this.label_ProcesscardApprovedDate.ForeColor = System.Drawing.Color.Black;
            this.label_ProcesscardApprovedDate.Location = new System.Drawing.Point(181, 28);
            this.label_ProcesscardApprovedDate.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.label_ProcesscardApprovedDate.Name = "label_ProcesscardApprovedDate";
            this.label_ProcesscardApprovedDate.Size = new System.Drawing.Size(129, 15);
            this.label_ProcesscardApprovedDate.TabIndex = 837;
            this.label_ProcesscardApprovedDate.Text = "Processkort godkänt den:";
            this.label_ProcesscardApprovedDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rb_HistoricalData
            // 
            this.rb_HistoricalData.AutoSize = true;
            this.rb_HistoricalData.BackColor = System.Drawing.Color.White;
            this.rb_HistoricalData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_HistoricalData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb_HistoricalData.Enabled = false;
            this.rb_HistoricalData.Font = new System.Drawing.Font("Arial", 7F);
            this.rb_HistoricalData.ForeColor = System.Drawing.Color.Black;
            this.rb_HistoricalData.Location = new System.Drawing.Point(1, 28);
            this.rb_HistoricalData.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.rb_HistoricalData.Name = "rb_HistoricalData";
            this.rb_HistoricalData.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rb_HistoricalData.Size = new System.Drawing.Size(179, 16);
            this.rb_HistoricalData.TabIndex = 838;
            this.rb_HistoricalData.Text = "Historiska Data";
            this.rb_HistoricalData.UseVisualStyleBackColor = false;
            this.rb_HistoricalData.CheckedChanged += new System.EventHandler(this.HistoriskaData_CheckedChanged);
            // 
            // rb_Validated
            // 
            this.rb_Validated.AutoSize = true;
            this.rb_Validated.BackColor = System.Drawing.Color.White;
            this.rb_Validated.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_Validated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb_Validated.Enabled = false;
            this.rb_Validated.Font = new System.Drawing.Font("Arial", 7F);
            this.rb_Validated.ForeColor = System.Drawing.Color.Black;
            this.rb_Validated.Location = new System.Drawing.Point(1, 44);
            this.rb_Validated.Margin = new System.Windows.Forms.Padding(1, 0, 0, 0);
            this.rb_Validated.Name = "rb_Validated";
            this.rb_Validated.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rb_Validated.Size = new System.Drawing.Size(179, 16);
            this.rb_Validated.TabIndex = 838;
            this.rb_Validated.Text = "Validerat på dessa loter:";
            this.rb_Validated.UseVisualStyleBackColor = false;
            this.rb_Validated.CheckedChanged += new System.EventHandler(this.Validerat_CheckedChanged);
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 5;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlp_Main.Controls.Add(this.btn_ProcesscardBasedOn, 0, 0);
            this.tlp_Main.Controls.Add(this.label_Empty_0, 1, 3);
            this.tlp_Main.Controls.Add(this.lbl_ApprovedDate, 2, 1);
            this.tlp_Main.Controls.Add(this.tb_Validerade_Loter, 1, 2);
            this.tlp_Main.Controls.Add(this.lbl_UpprättatAv_Sign_AnstNr, 4, 2);
            this.tlp_Main.Controls.Add(this.lbl_RevNr, 4, 1);
            this.tlp_Main.Controls.Add(this.label_RevNr, 3, 1);
            this.tlp_Main.Controls.Add(this.rb_HistoricalData, 0, 1);
            this.tlp_Main.Controls.Add(this.label_ApprovedBy, 3, 3);
            this.tlp_Main.Controls.Add(this.rb_Validated, 0, 2);
            this.tlp_Main.Controls.Add(this.label_EstablishedBy, 3, 2);
            this.tlp_Main.Controls.Add(this.rb_FramtagningAvProcessfönster, 0, 3);
            this.tlp_Main.Controls.Add(this.label_ProcesscardApprovedDate, 1, 1);
            this.tlp_Main.Controls.Add(this.lbl_QA_Sign, 4, 3);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.Size = new System.Drawing.Size(771, 77);
            this.tlp_Main.TabIndex = 878;
            // 
            // btn_ProcesscardBasedOn
            // 
            this.btn_ProcesscardBasedOn.BackColor = System.Drawing.Color.LightGray;
            this.tlp_Main.SetColumnSpan(this.btn_ProcesscardBasedOn, 5);
            this.btn_ProcesscardBasedOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ProcesscardBasedOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ProcesscardBasedOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.btn_ProcesscardBasedOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ProcesscardBasedOn.Font = new System.Drawing.Font("Palatino Linotype", 10F);
            this.btn_ProcesscardBasedOn.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btn_ProcesscardBasedOn.Location = new System.Drawing.Point(0, 0);
            this.btn_ProcesscardBasedOn.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ProcesscardBasedOn.Name = "btn_ProcesscardBasedOn";
            this.btn_ProcesscardBasedOn.Size = new System.Drawing.Size(771, 28);
            this.btn_ProcesscardBasedOn.TabIndex = 915;
            this.btn_ProcesscardBasedOn.Text = "Processkort är baserat på:";
            this.btn_ProcesscardBasedOn.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btn_ProcesscardBasedOn.UseVisualStyleBackColor = false;
            this.btn_ProcesscardBasedOn.Click += new System.EventHandler(this.ProcesscardBasedOn_MouseClick);
            // 
            // label_Empty_0
            // 
            this.label_Empty_0.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Empty_0, 2);
            this.label_Empty_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Empty_0.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.label_Empty_0.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_Empty_0.Location = new System.Drawing.Point(180, 60);
            this.label_Empty_0.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_Empty_0.Name = "label_Empty_0";
            this.label_Empty_0.Size = new System.Drawing.Size(386, 16);
            this.label_Empty_0.TabIndex = 914;
            // 
            // lbl_ApprovedDate
            // 
            this.lbl_ApprovedDate.BackColor = System.Drawing.Color.White;
            this.lbl_ApprovedDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ApprovedDate.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_ApprovedDate.ForeColor = System.Drawing.Color.Gray;
            this.lbl_ApprovedDate.Location = new System.Drawing.Point(311, 28);
            this.lbl_ApprovedDate.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_ApprovedDate.Name = "lbl_ApprovedDate";
            this.lbl_ApprovedDate.Size = new System.Drawing.Size(254, 15);
            this.lbl_ApprovedDate.TabIndex = 912;
            this.lbl_ApprovedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_Validerade_Loter
            // 
            this.tb_Validerade_Loter.BackColor = System.Drawing.Color.White;
            this.tb_Validerade_Loter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tlp_Main.SetColumnSpan(this.tb_Validerade_Loter, 2);
            this.tb_Validerade_Loter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Validerade_Loter.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.tb_Validerade_Loter.ForeColor = System.Drawing.Color.Gray;
            this.tb_Validerade_Loter.Location = new System.Drawing.Point(181, 44);
            this.tb_Validerade_Loter.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.tb_Validerade_Loter.Name = "tb_Validerade_Loter";
            this.tb_Validerade_Loter.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tb_Validerade_Loter.Size = new System.Drawing.Size(384, 15);
            this.tb_Validerade_Loter.TabIndex = 911;
            this.tb_Validerade_Loter.Text = "";
            // 
            // lbl_UpprättatAv_Sign_AnstNr
            // 
            this.lbl_UpprättatAv_Sign_AnstNr.BackColor = System.Drawing.Color.White;
            this.lbl_UpprättatAv_Sign_AnstNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_UpprättatAv_Sign_AnstNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_UpprättatAv_Sign_AnstNr.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_UpprättatAv_Sign_AnstNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_UpprättatAv_Sign_AnstNr.Location = new System.Drawing.Point(702, 44);
            this.lbl_UpprättatAv_Sign_AnstNr.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_UpprättatAv_Sign_AnstNr.Name = "lbl_UpprättatAv_Sign_AnstNr";
            this.lbl_UpprättatAv_Sign_AnstNr.Size = new System.Drawing.Size(68, 15);
            this.lbl_UpprättatAv_Sign_AnstNr.TabIndex = 909;
            this.lbl_UpprättatAv_Sign_AnstNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_UpprättatAv_Sign_AnstNr.Click += new System.EventHandler(this.UpprättatAv_Sign_AnstNr_Click);
            // 
            // lbl_RevNr
            // 
            this.lbl_RevNr.BackColor = System.Drawing.Color.LightSteelBlue;
            this.lbl_RevNr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_RevNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_RevNr.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_RevNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_RevNr.Location = new System.Drawing.Point(702, 28);
            this.lbl_RevNr.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_RevNr.Name = "lbl_RevNr";
            this.lbl_RevNr.Size = new System.Drawing.Size(68, 15);
            this.lbl_RevNr.TabIndex = 908;
            this.lbl_RevNr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_RevNr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RevNr_MouseDown);
            // 
            // label_ApprovedBy
            // 
            this.label_ApprovedBy.AutoSize = true;
            this.label_ApprovedBy.BackColor = System.Drawing.Color.White;
            this.label_ApprovedBy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_ApprovedBy.Font = new System.Drawing.Font("Arial", 7F);
            this.label_ApprovedBy.Location = new System.Drawing.Point(566, 60);
            this.label_ApprovedBy.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.label_ApprovedBy.Name = "label_ApprovedBy";
            this.label_ApprovedBy.Size = new System.Drawing.Size(135, 16);
            this.label_ApprovedBy.TabIndex = 839;
            this.label_ApprovedBy.Text = "Godkänt av: Sign./Anst nr:";
            this.label_ApprovedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rb_FramtagningAvProcessfönster
            // 
            this.rb_FramtagningAvProcessfönster.AutoSize = true;
            this.rb_FramtagningAvProcessfönster.BackColor = System.Drawing.Color.White;
            this.rb_FramtagningAvProcessfönster.Checked = true;
            this.rb_FramtagningAvProcessfönster.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rb_FramtagningAvProcessfönster.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rb_FramtagningAvProcessfönster.Enabled = false;
            this.rb_FramtagningAvProcessfönster.Font = new System.Drawing.Font("Arial", 7F);
            this.rb_FramtagningAvProcessfönster.ForeColor = System.Drawing.Color.Black;
            this.rb_FramtagningAvProcessfönster.Location = new System.Drawing.Point(1, 60);
            this.rb_FramtagningAvProcessfönster.Margin = new System.Windows.Forms.Padding(1, 0, 0, 1);
            this.rb_FramtagningAvProcessfönster.Name = "rb_FramtagningAvProcessfönster";
            this.rb_FramtagningAvProcessfönster.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.rb_FramtagningAvProcessfönster.Size = new System.Drawing.Size(179, 16);
            this.rb_FramtagningAvProcessfönster.TabIndex = 838;
            this.rb_FramtagningAvProcessfönster.TabStop = true;
            this.rb_FramtagningAvProcessfönster.Text = "Framtagning av Processfönster:";
            this.rb_FramtagningAvProcessfönster.UseVisualStyleBackColor = false;
            this.rb_FramtagningAvProcessfönster.CheckedChanged += new System.EventHandler(this.FramtagningAvProcessfönster_CheckedChanged);
            // 
            // lbl_QA_Sign
            // 
            this.lbl_QA_Sign.BackColor = System.Drawing.Color.White;
            this.lbl_QA_Sign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_QA_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_QA_Sign.Enabled = false;
            this.lbl_QA_Sign.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.lbl_QA_Sign.ForeColor = System.Drawing.Color.Gray;
            this.lbl_QA_Sign.Location = new System.Drawing.Point(702, 60);
            this.lbl_QA_Sign.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_QA_Sign.Name = "lbl_QA_Sign";
            this.lbl_QA_Sign.Size = new System.Drawing.Size(68, 16);
            this.lbl_QA_Sign.TabIndex = 913;
            this.lbl_QA_Sign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_QA_Sign.Click += new System.EventHandler(this.QA_Sign_Click);
            // 
            // ProcesscardBasedOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tlp_Main);
            this.Name = "ProcesscardBasedOn";
            this.Size = new System.Drawing.Size(771, 77);
            this.MouseHover += new System.EventHandler(this.ProcesscardBasedOn_MouseClick);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

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
