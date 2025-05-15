using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.eMail
{
    partial class Processcard_Changes
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Abort = new System.Windows.Forms.Label();
            this.lbl_SaveMessage = new System.Windows.Forms.Label();
            this.label_Info_ProcesscardChange = new System.Windows.Forms.Label();
            this.tb_Meddelande = new System.Windows.Forms.TextBox();
            this.label_Meddelande_Rubrik = new System.Windows.Forms.Label();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.lbl_Abort, 1, 3);
            this.tlp_Main.Controls.Add(this.lbl_SaveMessage, 0, 3);
            this.tlp_Main.Controls.Add(this.label_Info_ProcesscardChange, 0, 0);
            this.tlp_Main.Controls.Add(this.tb_Meddelande, 0, 2);
            this.tlp_Main.Controls.Add(this.label_Meddelande_Rubrik, 0, 1);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 77F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(563, 329);
            this.tlp_Main.TabIndex = 0;
            // 
            // lbl_Abort
            // 
            this.lbl_Abort.AutoSize = true;
            this.lbl_Abort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.lbl_Abort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Abort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Abort.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbl_Abort.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lbl_Abort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.lbl_Abort.Location = new System.Drawing.Point(453, 291);
            this.lbl_Abort.Margin = new System.Windows.Forms.Padding(2, 0, 3, 3);
            this.lbl_Abort.MaximumSize = new System.Drawing.Size(125, 50);
            this.lbl_Abort.MinimumSize = new System.Drawing.Size(107, 35);
            this.lbl_Abort.Name = "lbl_Abort";
            this.lbl_Abort.Size = new System.Drawing.Size(107, 35);
            this.lbl_Abort.TabIndex = 849;
            this.lbl_Abort.Text = "Avbryt";
            this.lbl_Abort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Abort.Click += new System.EventHandler(this.AbortClick);
            // 
            // lbl_SaveMessage
            // 
            this.lbl_SaveMessage.AutoSize = true;
            this.lbl_SaveMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.lbl_SaveMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_SaveMessage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_SaveMessage.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbl_SaveMessage.Font = new System.Drawing.Font("Palatino Linotype", 9F);
            this.lbl_SaveMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_SaveMessage.Location = new System.Drawing.Point(3, 291);
            this.lbl_SaveMessage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
            this.lbl_SaveMessage.MaximumSize = new System.Drawing.Size(125, 50);
            this.lbl_SaveMessage.MinimumSize = new System.Drawing.Size(107, 35);
            this.lbl_SaveMessage.Name = "lbl_SaveMessage";
            this.lbl_SaveMessage.Size = new System.Drawing.Size(116, 35);
            this.lbl_SaveMessage.TabIndex = 848;
            this.lbl_SaveMessage.Text = "Spara meddelande";
            this.lbl_SaveMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_SaveMessage.Click += new System.EventHandler(this.SaveMessage_Click);
            // 
            // label_Info_ProcesscardChange
            // 
            this.label_Info_ProcesscardChange.AutoSize = true;
            this.label_Info_ProcesscardChange.BackColor = System.Drawing.SystemColors.Info;
            this.tlp_Main.SetColumnSpan(this.label_Info_ProcesscardChange, 2);
            this.label_Info_ProcesscardChange.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Info_ProcesscardChange.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_ProcesscardChange.Font = new System.Drawing.Font("Cambria", 10.25F);
            this.label_Info_ProcesscardChange.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label_Info_ProcesscardChange.Location = new System.Drawing.Point(3, 3);
            this.label_Info_ProcesscardChange.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.label_Info_ProcesscardChange.Name = "label_Info_ProcesscardChange";
            this.label_Info_ProcesscardChange.Size = new System.Drawing.Size(557, 87);
            this.label_Info_ProcesscardChange.TabIndex = 1;
            // 
            // tb_Meddelande
            // 
            this.tb_Meddelande.BackColor = System.Drawing.Color.White;
            this.tb_Meddelande.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tlp_Main.SetColumnSpan(this.tb_Meddelande, 2);
            this.tb_Meddelande.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Meddelande.Location = new System.Drawing.Point(3, 170);
            this.tb_Meddelande.Multiline = true;
            this.tb_Meddelande.Name = "tb_Meddelande";
            this.tb_Meddelande.Size = new System.Drawing.Size(557, 118);
            this.tb_Meddelande.TabIndex = 2;
            // 
            // label_Meddelande_Rubrik
            // 
            this.label_Meddelande_Rubrik.AutoSize = true;
            this.label_Meddelande_Rubrik.BackColor = System.Drawing.Color.White;
            this.tlp_Main.SetColumnSpan(this.label_Meddelande_Rubrik, 2);
            this.label_Meddelande_Rubrik.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Meddelande_Rubrik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Meddelande_Rubrik.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold);
            this.label_Meddelande_Rubrik.Location = new System.Drawing.Point(3, 93);
            this.label_Meddelande_Rubrik.Margin = new System.Windows.Forms.Padding(3);
            this.label_Meddelande_Rubrik.Name = "label_Meddelande_Rubrik";
            this.label_Meddelande_Rubrik.Size = new System.Drawing.Size(557, 71);
            this.label_Meddelande_Rubrik.TabIndex = 850;
            // 
            // Processcard_Changes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(563, 329);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Processcard_Changes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Processcard_Changes_FormClosing);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Info_ProcesscardChange;
        private TextBox tb_Meddelande;
        private Label lbl_SaveMessage;
        private Label lbl_Abort;
        private Label label_Meddelande_Rubrik;
    }
}