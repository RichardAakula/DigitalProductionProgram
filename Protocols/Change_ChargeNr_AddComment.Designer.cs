using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols
{
    partial class Change_ChargeNr_AddComment
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
            this.label_ChangeChargeNr_Info_1 = new System.Windows.Forms.Label();
            this.tb_Kommentar = new System.Windows.Forms.TextBox();
            this.lbl_ChangeChargeNr_Info_Exit = new System.Windows.Forms.Label();
            this.lbl_ChangeChargeNr_Info_Change = new System.Windows.Forms.Label();
            this.label_ChangeChargeNr_Header = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_ChangeChargeNr_Info_1
            // 
            this.label_ChangeChargeNr_Info_1.AutoSize = true;
            this.label_ChangeChargeNr_Info_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.label_ChangeChargeNr_Info_1.ForeColor = System.Drawing.Color.White;
            this.label_ChangeChargeNr_Info_1.Location = new System.Drawing.Point(12, 70);
            this.label_ChangeChargeNr_Info_1.Name = "label_ChangeChargeNr_Info_1";
            this.label_ChangeChargeNr_Info_1.Size = new System.Drawing.Size(288, 16);
            this.label_ChangeChargeNr_Info_1.TabIndex = 1;
            this.label_ChangeChargeNr_Info_1.Text = "Skriv i en kommentar om varför du har bytt lotNr:";
            // 
            // tb_Kommentar
            // 
            this.tb_Kommentar.Location = new System.Drawing.Point(15, 99);
            this.tb_Kommentar.MaxLength = 38;
            this.tb_Kommentar.Multiline = true;
            this.tb_Kommentar.Name = "tb_Kommentar";
            this.tb_Kommentar.Size = new System.Drawing.Size(262, 46);
            this.tb_Kommentar.TabIndex = 16;
            // 
            // lbl_ChangeChargeNr_Info_Exit
            // 
            this.lbl_ChangeChargeNr_Info_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ChangeChargeNr_Info_Exit.AutoSize = true;
            this.lbl_ChangeChargeNr_Info_Exit.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChangeChargeNr_Info_Exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ChangeChargeNr_Info_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_ChangeChargeNr_Info_Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_ChangeChargeNr_Info_Exit.Location = new System.Drawing.Point(241, 173);
            this.lbl_ChangeChargeNr_Info_Exit.Name = "lbl_ChangeChargeNr_Info_Exit";
            this.lbl_ChangeChargeNr_Info_Exit.Size = new System.Drawing.Size(62, 24);
            this.lbl_ChangeChargeNr_Info_Exit.TabIndex = 17;
            this.lbl_ChangeChargeNr_Info_Exit.Text = "Avbryt";
            this.lbl_ChangeChargeNr_Info_Exit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbl_ChangeChargeNr_Info_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // lbl_ChangeChargeNr_Info_Change
            // 
            this.lbl_ChangeChargeNr_Info_Change.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_ChangeChargeNr_Info_Change.AutoSize = true;
            this.lbl_ChangeChargeNr_Info_Change.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChangeChargeNr_Info_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ChangeChargeNr_Info_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_ChangeChargeNr_Info_Change.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_ChangeChargeNr_Info_Change.Location = new System.Drawing.Point(2, 173);
            this.lbl_ChangeChargeNr_Info_Change.Name = "lbl_ChangeChargeNr_Info_Change";
            this.lbl_ChangeChargeNr_Info_Change.Size = new System.Drawing.Size(85, 24);
            this.lbl_ChangeChargeNr_Info_Change.TabIndex = 18;
            this.lbl_ChangeChargeNr_Info_Change.Text = "Byt LotNr";
            this.lbl_ChangeChargeNr_Info_Change.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_ChangeChargeNr_Info_Change.Click += new System.EventHandler(this.ChangeChargeNr_Click);
            // 
            // label_ChangeChargeNr_Header
            // 
            this.label_ChangeChargeNr_Header.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ChangeChargeNr_Header.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(156)))));
            this.label_ChangeChargeNr_Header.Location = new System.Drawing.Point(15, 13);
            this.label_ChangeChargeNr_Header.Name = "label_ChangeChargeNr_Header";
            this.label_ChangeChargeNr_Header.Size = new System.Drawing.Size(283, 38);
            this.label_ChangeChargeNr_Header.TabIndex = 19;
            this.label_ChangeChargeNr_Header.Text = "OBS! Du får inte köra en order med två olika lotnr";
            // 
            // Change_ChargeNr_AddComment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(310, 207);
            this.Controls.Add(this.label_ChangeChargeNr_Header);
            this.Controls.Add(this.lbl_ChangeChargeNr_Info_Exit);
            this.Controls.Add(this.lbl_ChangeChargeNr_Info_Change);
            this.Controls.Add(this.tb_Kommentar);
            this.Controls.Add(this.label_ChangeChargeNr_Info_1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Change_ChargeNr_AddComment";
            this.Text = "LotNr_Byte_Kommentar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_ChangeChargeNr_Info_1;
        private TextBox tb_Kommentar;
        private Label lbl_ChangeChargeNr_Info_Exit;
        private Label lbl_ChangeChargeNr_Info_Change;
        private Label label_ChangeChargeNr_Header;
    }
}