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
            label_ChangeChargeNr_Info_1 = new Label();
            tb_Kommentar = new TextBox();
            lbl_ChangeChargeNr_Info_Exit = new Label();
            lbl_ChangeChargeNr_Info_Change = new Label();
            label_ChangeChargeNr_Header = new Label();
            SuspendLayout();
            // 
            // label_ChangeChargeNr_Info_1
            // 
            label_ChangeChargeNr_Info_1.AutoSize = true;
            label_ChangeChargeNr_Info_1.Font = new Font("Microsoft Sans Serif", 9.25F);
            label_ChangeChargeNr_Info_1.ForeColor = Color.White;
            label_ChangeChargeNr_Info_1.Location = new Point(14, 81);
            label_ChangeChargeNr_Info_1.Margin = new Padding(4, 0, 4, 0);
            label_ChangeChargeNr_Info_1.Name = "label_ChangeChargeNr_Info_1";
            label_ChangeChargeNr_Info_1.Size = new Size(288, 16);
            label_ChangeChargeNr_Info_1.TabIndex = 1;
            label_ChangeChargeNr_Info_1.Text = "Skriv i en kommentar om varför du har bytt lotNr:";
            // 
            // tb_Kommentar
            // 
            tb_Kommentar.Location = new Point(18, 114);
            tb_Kommentar.Margin = new Padding(4, 3, 4, 3);
            tb_Kommentar.MaxLength = 60;
            tb_Kommentar.Multiline = true;
            tb_Kommentar.Name = "tb_Kommentar";
            tb_Kommentar.Size = new Size(305, 52);
            tb_Kommentar.TabIndex = 16;
            // 
            // lbl_ChangeChargeNr_Info_Exit
            // 
            lbl_ChangeChargeNr_Info_Exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lbl_ChangeChargeNr_Info_Exit.AutoSize = true;
            lbl_ChangeChargeNr_Info_Exit.BackColor = Color.Transparent;
            lbl_ChangeChargeNr_Info_Exit.Cursor = Cursors.Hand;
            lbl_ChangeChargeNr_Info_Exit.Font = new Font("Microsoft Sans Serif", 14F);
            lbl_ChangeChargeNr_Info_Exit.ForeColor = Color.FromArgb(156, 0, 6);
            lbl_ChangeChargeNr_Info_Exit.Location = new Point(281, 200);
            lbl_ChangeChargeNr_Info_Exit.Margin = new Padding(4, 0, 4, 0);
            lbl_ChangeChargeNr_Info_Exit.Name = "lbl_ChangeChargeNr_Info_Exit";
            lbl_ChangeChargeNr_Info_Exit.Size = new Size(62, 24);
            lbl_ChangeChargeNr_Info_Exit.TabIndex = 17;
            lbl_ChangeChargeNr_Info_Exit.Text = "Avbryt";
            lbl_ChangeChargeNr_Info_Exit.TextAlign = ContentAlignment.MiddleRight;
            lbl_ChangeChargeNr_Info_Exit.Click += Exit_Click;
            // 
            // lbl_ChangeChargeNr_Info_Change
            // 
            lbl_ChangeChargeNr_Info_Change.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_ChangeChargeNr_Info_Change.AutoSize = true;
            lbl_ChangeChargeNr_Info_Change.BackColor = Color.Transparent;
            lbl_ChangeChargeNr_Info_Change.Cursor = Cursors.Hand;
            lbl_ChangeChargeNr_Info_Change.Font = new Font("Microsoft Sans Serif", 14F);
            lbl_ChangeChargeNr_Info_Change.ForeColor = Color.FromArgb(198, 239, 206);
            lbl_ChangeChargeNr_Info_Change.Location = new Point(2, 200);
            lbl_ChangeChargeNr_Info_Change.Margin = new Padding(4, 0, 4, 0);
            lbl_ChangeChargeNr_Info_Change.Name = "lbl_ChangeChargeNr_Info_Change";
            lbl_ChangeChargeNr_Info_Change.Size = new Size(85, 24);
            lbl_ChangeChargeNr_Info_Change.TabIndex = 18;
            lbl_ChangeChargeNr_Info_Change.Text = "Byt LotNr";
            lbl_ChangeChargeNr_Info_Change.TextAlign = ContentAlignment.MiddleLeft;
            lbl_ChangeChargeNr_Info_Change.Click += ChangeChargeNr_Click;
            // 
            // label_ChangeChargeNr_Header
            // 
            label_ChangeChargeNr_Header.Font = new Font("Consolas", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ChangeChargeNr_Header.ForeColor = Color.FromArgb(235, 235, 156);
            label_ChangeChargeNr_Header.Location = new Point(18, 15);
            label_ChangeChargeNr_Header.Margin = new Padding(4, 0, 4, 0);
            label_ChangeChargeNr_Header.Name = "label_ChangeChargeNr_Header";
            label_ChangeChargeNr_Header.Size = new Size(330, 44);
            label_ChangeChargeNr_Header.TabIndex = 19;
            label_ChangeChargeNr_Header.Text = "OBS! Du får inte köra en order med två olika lotnr";
            // 
            // Change_ChargeNr_AddComment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 45);
            ClientSize = new Size(362, 239);
            Controls.Add(label_ChangeChargeNr_Header);
            Controls.Add(lbl_ChangeChargeNr_Info_Exit);
            Controls.Add(lbl_ChangeChargeNr_Info_Change);
            Controls.Add(tb_Kommentar);
            Controls.Add(label_ChangeChargeNr_Info_1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Change_ChargeNr_AddComment";
            Text = "LotNr_Byte_Kommentar";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label_ChangeChargeNr_Info_1;
        private TextBox tb_Kommentar;
        private Label lbl_ChangeChargeNr_Info_Exit;
        private Label lbl_ChangeChargeNr_Info_Change;
        private Label label_ChangeChargeNr_Header;
    }
}