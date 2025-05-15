using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Zumbach
{
    partial class Kassera_Zumbach_Mätning
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
            this.btn_Discard = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label_DiscardZumbachMeasurement_Header = new System.Windows.Forms.Label();
            this.chb_Pos1 = new System.Windows.Forms.CheckBox();
            this.chb_Pos2 = new System.Windows.Forms.CheckBox();
            this.chb_Pos3 = new System.Windows.Forms.CheckBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Discard
            // 
            this.btn_Discard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Discard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Discard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Discard.ForeColor = System.Drawing.Color.White;
            this.btn_Discard.Location = new System.Drawing.Point(3, 72);
            this.btn_Discard.Name = "btn_Discard";
            this.btn_Discard.Size = new System.Drawing.Size(65, 25);
            this.btn_Discard.TabIndex = 0;
            this.btn_Discard.Text = "Kassera";
            this.btn_Discard.UseVisualStyleBackColor = true;
            this.btn_Discard.Click += new System.EventHandler(this.Discard_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(300, 72);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(65, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Avbryt";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label_DiscardZumbachMeasurement_Header
            // 
            this.tlp_Main.SetColumnSpan(this.label_DiscardZumbachMeasurement_Header, 3);
            this.label_DiscardZumbachMeasurement_Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_DiscardZumbachMeasurement_Header.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DiscardZumbachMeasurement_Header.ForeColor = System.Drawing.Color.Silver;
            this.label_DiscardZumbachMeasurement_Header.Location = new System.Drawing.Point(3, 0);
            this.label_DiscardZumbachMeasurement_Header.Name = "label_DiscardZumbachMeasurement_Header";
            this.label_DiscardZumbachMeasurement_Header.Size = new System.Drawing.Size(362, 30);
            this.label_DiscardZumbachMeasurement_Header.TabIndex = 2;
            this.label_DiscardZumbachMeasurement_Header.Text = "Välj vilka positioner du vill kassera:";
            this.label_DiscardZumbachMeasurement_Header.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // chb_Pos1
            // 
            this.chb_Pos1.AutoSize = true;
            this.chb_Pos1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.chb_Pos1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Pos1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_Pos1.ForeColor = System.Drawing.Color.Yellow;
            this.chb_Pos1.Location = new System.Drawing.Point(3, 33);
            this.chb_Pos1.Name = "chb_Pos1";
            this.chb_Pos1.Size = new System.Drawing.Size(116, 19);
            this.chb_Pos1.TabIndex = 3;
            this.chb_Pos1.Text = "Position 1";
            this.chb_Pos1.UseVisualStyleBackColor = false;
            // 
            // chb_Pos2
            // 
            this.chb_Pos2.AutoSize = true;
            this.chb_Pos2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Pos2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_Pos2.ForeColor = System.Drawing.Color.White;
            this.chb_Pos2.Location = new System.Drawing.Point(125, 33);
            this.chb_Pos2.Name = "chb_Pos2";
            this.chb_Pos2.Size = new System.Drawing.Size(116, 19);
            this.chb_Pos2.TabIndex = 3;
            this.chb_Pos2.Text = "Position 2";
            this.chb_Pos2.UseVisualStyleBackColor = true;
            // 
            // chb_Pos3
            // 
            this.chb_Pos3.AutoSize = true;
            this.chb_Pos3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chb_Pos3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_Pos3.ForeColor = System.Drawing.Color.Lime;
            this.chb_Pos3.Location = new System.Drawing.Point(247, 33);
            this.chb_Pos3.Name = "chb_Pos3";
            this.chb_Pos3.Size = new System.Drawing.Size(118, 19);
            this.chb_Pos3.TabIndex = 3;
            this.chb_Pos3.Text = "Position 3";
            this.chb_Pos3.UseVisualStyleBackColor = true;
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.Controls.Add(this.label_DiscardZumbachMeasurement_Header, 0, 0);
            this.tlp_Main.Controls.Add(this.btn_Cancel, 2, 2);
            this.tlp_Main.Controls.Add(this.chb_Pos3, 2, 1);
            this.tlp_Main.Controls.Add(this.btn_Discard, 0, 2);
            this.tlp_Main.Controls.Add(this.chb_Pos1, 0, 1);
            this.tlp_Main.Controls.Add(this.chb_Pos2, 1, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(368, 100);
            this.tlp_Main.TabIndex = 4;
            // 
            // Kassera_Zumbach_Mätning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(368, 100);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Kassera_Zumbach_Mätning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kassera_Zumbach_Mätning";
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btn_Discard;
        private Button btn_Cancel;
        private Label label_DiscardZumbachMeasurement_Header;
        private CheckBox chb_Pos1;
        private CheckBox chb_Pos2;
        private CheckBox chb_Pos3;
        private TableLayoutPanel tlp_Main;
    }
}