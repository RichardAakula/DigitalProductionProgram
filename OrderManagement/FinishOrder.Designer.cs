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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinishOrder));
            this.label_FinishOrder_Header = new System.Windows.Forms.Label();
            this.chb_FinishOrder_PrintOrder = new System.Windows.Forms.CheckBox();
            this.label_Info = new System.Windows.Forms.Label();
            this.chb_0 = new System.Windows.Forms.CheckBox();
            this.chb_1 = new System.Windows.Forms.CheckBox();
            this.chb_2 = new System.Windows.Forms.CheckBox();
            this.chb_3 = new System.Windows.Forms.CheckBox();
            this.chb_4 = new System.Windows.Forms.CheckBox();
            this.chb_5 = new System.Windows.Forms.CheckBox();
            this.label_Info_0 = new System.Windows.Forms.Label();
            this.label_Info_1 = new System.Windows.Forms.Label();
            this.label_Info_2 = new System.Windows.Forms.Label();
            this.label_Info_3 = new System.Windows.Forms.Label();
            this.label_Info_4 = new System.Windows.Forms.Label();
            this.label_Info_5 = new System.Windows.Forms.Label();
            this.lbl_FinishOrder_Done = new System.Windows.Forms.Label();
            this.lbl_FinishOrder_Abort = new System.Windows.Forms.Label();
            this.chb_Rapportera_Jira = new System.Windows.Forms.CheckBox();
            this.panel_Poäng = new System.Windows.Forms.Panel();
            this.pb_Info_Jira = new System.Windows.Forms.PictureBox();
            this.panel_Poäng.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Jira)).BeginInit();
            this.SuspendLayout();
            // 
            // label_FinishOrder_Header
            // 
            this.label_FinishOrder_Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_FinishOrder_Header.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.label_FinishOrder_Header.ForeColor = System.Drawing.Color.Black;
            this.label_FinishOrder_Header.Location = new System.Drawing.Point(0, 0);
            this.label_FinishOrder_Header.Name = "label_FinishOrder_Header";
            this.label_FinishOrder_Header.Size = new System.Drawing.Size(450, 30);
            this.label_FinishOrder_Header.TabIndex = 0;
            this.label_FinishOrder_Header.Text = "Ordern är nu klar";
            this.label_FinishOrder_Header.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // chb_FinishOrder_PrintOrder
            // 
            this.chb_FinishOrder_PrintOrder.AutoSize = true;
            this.chb_FinishOrder_PrintOrder.Checked = true;
            this.chb_FinishOrder_PrintOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_FinishOrder_PrintOrder.Font = new System.Drawing.Font("Consolas", 10.25F);
            this.chb_FinishOrder_PrintOrder.ForeColor = System.Drawing.Color.Black;
            this.chb_FinishOrder_PrintOrder.Location = new System.Drawing.Point(50, 46);
            this.chb_FinishOrder_PrintOrder.Name = "chb_FinishOrder_PrintOrder";
            this.chb_FinishOrder_PrintOrder.Size = new System.Drawing.Size(227, 21);
            this.chb_FinishOrder_PrintOrder.TabIndex = 1;
            this.chb_FinishOrder_PrintOrder.Text = "Vill du skriva ut ordern?";
            this.chb_FinishOrder_PrintOrder.UseVisualStyleBackColor = true;
            this.chb_FinishOrder_PrintOrder.Visible = false;
            // 
            // label_Info
            // 
            this.label_Info.AutoSize = true;
            this.label_Info.Font = new System.Drawing.Font("Arial", 12.25F);
            this.label_Info.Location = new System.Drawing.Point(3, 12);
            this.label_Info.Name = "label_Info";
            this.label_Info.Size = new System.Drawing.Size(380, 19);
            this.label_Info.TabIndex = 1;
            this.label_Info.Text = "Betygsätt ordern baserat på hur materialet har gått.";
            // 
            // chb_0
            // 
            this.chb_0.AutoSize = true;
            this.chb_0.Font = new System.Drawing.Font("Courier New", 30F);
            this.chb_0.ForeColor = System.Drawing.Color.LemonChiffon;
            this.chb_0.Location = new System.Drawing.Point(7, 47);
            this.chb_0.Name = "chb_0";
            this.chb_0.Size = new System.Drawing.Size(61, 46);
            this.chb_0.TabIndex = 3;
            this.chb_0.Text = "0";
            this.chb_0.UseVisualStyleBackColor = true;
            this.chb_0.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chb_1
            // 
            this.chb_1.AutoSize = true;
            this.chb_1.Font = new System.Drawing.Font("Courier New", 30F);
            this.chb_1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.chb_1.Location = new System.Drawing.Point(7, 92);
            this.chb_1.Name = "chb_1";
            this.chb_1.Size = new System.Drawing.Size(61, 46);
            this.chb_1.TabIndex = 3;
            this.chb_1.Text = "1";
            this.chb_1.UseVisualStyleBackColor = true;
            this.chb_1.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chb_2
            // 
            this.chb_2.AutoSize = true;
            this.chb_2.Font = new System.Drawing.Font("Courier New", 30F);
            this.chb_2.ForeColor = System.Drawing.Color.LemonChiffon;
            this.chb_2.Location = new System.Drawing.Point(7, 137);
            this.chb_2.Name = "chb_2";
            this.chb_2.Size = new System.Drawing.Size(61, 46);
            this.chb_2.TabIndex = 3;
            this.chb_2.Text = "2";
            this.chb_2.UseVisualStyleBackColor = true;
            this.chb_2.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chb_3
            // 
            this.chb_3.AutoSize = true;
            this.chb_3.Font = new System.Drawing.Font("Courier New", 30F);
            this.chb_3.ForeColor = System.Drawing.Color.LemonChiffon;
            this.chb_3.Location = new System.Drawing.Point(7, 182);
            this.chb_3.Name = "chb_3";
            this.chb_3.Size = new System.Drawing.Size(61, 46);
            this.chb_3.TabIndex = 3;
            this.chb_3.Text = "3";
            this.chb_3.UseVisualStyleBackColor = true;
            this.chb_3.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chb_4
            // 
            this.chb_4.AutoSize = true;
            this.chb_4.Font = new System.Drawing.Font("Courier New", 30F);
            this.chb_4.ForeColor = System.Drawing.Color.LemonChiffon;
            this.chb_4.Location = new System.Drawing.Point(7, 227);
            this.chb_4.Name = "chb_4";
            this.chb_4.Size = new System.Drawing.Size(61, 46);
            this.chb_4.TabIndex = 3;
            this.chb_4.Text = "4";
            this.chb_4.UseVisualStyleBackColor = true;
            this.chb_4.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chb_5
            // 
            this.chb_5.AutoSize = true;
            this.chb_5.Font = new System.Drawing.Font("Courier New", 30F);
            this.chb_5.ForeColor = System.Drawing.Color.LemonChiffon;
            this.chb_5.Location = new System.Drawing.Point(7, 272);
            this.chb_5.Name = "chb_5";
            this.chb_5.Size = new System.Drawing.Size(61, 46);
            this.chb_5.TabIndex = 3;
            this.chb_5.Text = "5";
            this.chb_5.UseVisualStyleBackColor = true;
            this.chb_5.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // label_Info_0
            // 
            this.label_Info_0.Font = new System.Drawing.Font("Consolas", 9F);
            this.label_Info_0.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label_Info_0.Location = new System.Drawing.Point(83, 57);
            this.label_Info_0.Name = "label_Info_0";
            this.label_Info_0.Size = new System.Drawing.Size(340, 35);
            this.label_Info_0.TabIndex = 1;
            this.label_Info_0.Text = "Materialet var oanvändbart.";
            // 
            // label_Info_1
            // 
            this.label_Info_1.Font = new System.Drawing.Font("Consolas", 9F);
            this.label_Info_1.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label_Info_1.Location = new System.Drawing.Point(83, 102);
            this.label_Info_1.Name = "label_Info_1";
            this.label_Info_1.Size = new System.Drawing.Size(340, 35);
            this.label_Info_1.TabIndex = 1;
            this.label_Info_1.Text = "Materialet var användbart men medförde mycket stora problem.";
            // 
            // label_Info_2
            // 
            this.label_Info_2.Font = new System.Drawing.Font("Consolas", 9F);
            this.label_Info_2.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label_Info_2.Location = new System.Drawing.Point(83, 147);
            this.label_Info_2.Name = "label_Info_2";
            this.label_Info_2.Size = new System.Drawing.Size(340, 35);
            this.label_Info_2.TabIndex = 1;
            this.label_Info_2.Text = "Materialet var användbart men medförde mer problem än vanligt.";
            // 
            // label_Info_3
            // 
            this.label_Info_3.Font = new System.Drawing.Font("Consolas", 9F);
            this.label_Info_3.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label_Info_3.Location = new System.Drawing.Point(83, 192);
            this.label_Info_3.Name = "label_Info_3";
            this.label_Info_3.Size = new System.Drawing.Size(340, 35);
            this.label_Info_3.TabIndex = 1;
            this.label_Info_3.Text = "Material uppförde sig som vanligt med normala hanterbara variationer från materia" +
    "let.";
            // 
            // label_Info_4
            // 
            this.label_Info_4.Font = new System.Drawing.Font("Consolas", 9F);
            this.label_Info_4.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label_Info_4.Location = new System.Drawing.Point(83, 237);
            this.label_Info_4.Name = "label_Info_4";
            this.label_Info_4.Size = new System.Drawing.Size(340, 35);
            this.label_Info_4.TabIndex = 1;
            this.label_Info_4.Text = "Körningen gick bra med färre än vanligt problem med materialet.";
            // 
            // label_Info_5
            // 
            this.label_Info_5.Font = new System.Drawing.Font("Consolas", 9F);
            this.label_Info_5.ForeColor = System.Drawing.Color.LemonChiffon;
            this.label_Info_5.Location = new System.Drawing.Point(83, 282);
            this.label_Info_5.Name = "label_Info_5";
            this.label_Info_5.Size = new System.Drawing.Size(340, 35);
            this.label_Info_5.TabIndex = 1;
            this.label_Info_5.Text = "Körningen gick mycket bra utan problem orsakade av materialet.";
            // 
            // lbl_FinishOrder_Done
            // 
            this.lbl_FinishOrder_Done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_FinishOrder_Done.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_FinishOrder_Done.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FinishOrder_Done.ForeColor = System.Drawing.Color.Black;
            this.lbl_FinishOrder_Done.Location = new System.Drawing.Point(0, 442);
            this.lbl_FinishOrder_Done.Name = "lbl_FinishOrder_Done";
            this.lbl_FinishOrder_Done.Size = new System.Drawing.Size(117, 24);
            this.lbl_FinishOrder_Done.TabIndex = 4;
            this.lbl_FinishOrder_Done.Text = "Avsluta Order";
            this.lbl_FinishOrder_Done.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_FinishOrder_Done.Click += new System.EventHandler(this.Klar_Click);
            // 
            // lbl_FinishOrder_Abort
            // 
            this.lbl_FinishOrder_Abort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FinishOrder_Abort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_FinishOrder_Abort.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_FinishOrder_Abort.ForeColor = System.Drawing.Color.Black;
            this.lbl_FinishOrder_Abort.Location = new System.Drawing.Point(376, 442);
            this.lbl_FinishOrder_Abort.Name = "lbl_FinishOrder_Abort";
            this.lbl_FinishOrder_Abort.Size = new System.Drawing.Size(72, 24);
            this.lbl_FinishOrder_Abort.TabIndex = 4;
            this.lbl_FinishOrder_Abort.Text = "Avbryt";
            this.lbl_FinishOrder_Abort.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lbl_FinishOrder_Abort.Click += new System.EventHandler(this.Avbryt_Click);
            // 
            // chb_Rapportera_Jira
            // 
            this.chb_Rapportera_Jira.AutoSize = true;
            this.chb_Rapportera_Jira.Font = new System.Drawing.Font("Consolas", 10.25F);
            this.chb_Rapportera_Jira.ForeColor = System.Drawing.Color.Black;
            this.chb_Rapportera_Jira.Location = new System.Drawing.Point(50, 73);
            this.chb_Rapportera_Jira.Name = "chb_Rapportera_Jira";
            this.chb_Rapportera_Jira.Size = new System.Drawing.Size(371, 21);
            this.chb_Rapportera_Jira.TabIndex = 1;
            this.chb_Rapportera_Jira.Text = "Rapportera problem till produktionssupport?";
            this.chb_Rapportera_Jira.UseVisualStyleBackColor = true;
            // 
            // panel_Poäng
            // 
            this.panel_Poäng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Poäng.Controls.Add(this.label_Info);
            this.panel_Poäng.Controls.Add(this.chb_0);
            this.panel_Poäng.Controls.Add(this.label_Info_0);
            this.panel_Poäng.Controls.Add(this.chb_5);
            this.panel_Poäng.Controls.Add(this.label_Info_5);
            this.panel_Poäng.Controls.Add(this.chb_1);
            this.panel_Poäng.Controls.Add(this.chb_4);
            this.panel_Poäng.Controls.Add(this.label_Info_1);
            this.panel_Poäng.Controls.Add(this.label_Info_4);
            this.panel_Poäng.Controls.Add(this.chb_3);
            this.panel_Poäng.Controls.Add(this.chb_2);
            this.panel_Poäng.Controls.Add(this.label_Info_2);
            this.panel_Poäng.Controls.Add(this.label_Info_3);
            this.panel_Poäng.Location = new System.Drawing.Point(12, 100);
            this.panel_Poäng.Name = "panel_Poäng";
            this.panel_Poäng.Size = new System.Drawing.Size(426, 347);
            this.panel_Poäng.TabIndex = 5;
            // 
            // pb_Info_Jira
            // 
            this.pb_Info_Jira.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info_Jira.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info_Jira.BackgroundImage")));
            this.pb_Info_Jira.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_Jira.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_Jira.Location = new System.Drawing.Point(5, 65);
            this.pb_Info_Jira.Name = "pb_Info_Jira";
            this.pb_Info_Jira.Size = new System.Drawing.Size(34, 29);
            this.pb_Info_Jira.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info_Jira.TabIndex = 871;
            this.pb_Info_Jira.TabStop = false;
            this.pb_Info_Jira.Click += new System.EventHandler(this.Info_Jira_Click);
            // 
            // Order_Done
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(450, 470);
            this.Controls.Add(this.pb_Info_Jira);
            this.Controls.Add(this.panel_Poäng);
            this.Controls.Add(this.lbl_FinishOrder_Abort);
            this.Controls.Add(this.lbl_FinishOrder_Done);
            this.Controls.Add(this.chb_Rapportera_Jira);
            this.Controls.Add(this.chb_FinishOrder_PrintOrder);
            this.Controls.Add(this.label_FinishOrder_Header);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Order_Done";
            this.Text = "OrderKlar";
            this.panel_Poäng.ResumeLayout(false);
            this.panel_Poäng.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_Jira)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private Label lbl_FinishOrder_Done;
        private Label lbl_FinishOrder_Abort;
        private CheckBox chb_Rapportera_Jira;
        private Panel panel_Poäng;
        private PictureBox pb_Info_Jira;
    }
}