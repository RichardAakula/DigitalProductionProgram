using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.PrintingServices
{
    partial class VäljProcesskort
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
            this.label_Rubrik = new System.Windows.Forms.Label();
            this.lbl_Extrudering_1 = new System.Windows.Forms.Label();
            this.lbl_Extrudering_2 = new System.Windows.Forms.Label();
            this.lbl_Krympslang = new System.Windows.Forms.Label();
            this.lbl_Kragning = new System.Windows.Forms.Label();
            this.lbl_Svetsning = new System.Windows.Forms.Label();
            this.lbl_Slipning = new System.Windows.Forms.Label();
            this.lbl_Skärmning = new System.Windows.Forms.Label();
            this.lbl_Hackning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Rubrik
            // 
            this.label_Rubrik.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_Rubrik.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Rubrik.Location = new System.Drawing.Point(0, 0);
            this.label_Rubrik.Name = "label_Rubrik";
            this.label_Rubrik.Size = new System.Drawing.Size(484, 30);
            this.label_Rubrik.TabIndex = 1;
            this.label_Rubrik.Text = "Välj processkort som du vill skriva ut";
            this.label_Rubrik.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_Extrudering_1
            // 
            this.lbl_Extrudering_1.AutoSize = true;
            this.lbl_Extrudering_1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Extrudering_1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Extrudering_1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Extrudering_1.Location = new System.Drawing.Point(90, 55);
            this.lbl_Extrudering_1.Name = "lbl_Extrudering_1";
            this.lbl_Extrudering_1.Size = new System.Drawing.Size(207, 19);
            this.lbl_Extrudering_1.TabIndex = 2;
            this.lbl_Extrudering_1.Text = "Extrudering - 1 Maskin";
            this.lbl_Extrudering_1.Click += new System.EventHandler(this.lbl_Extrudering_1_Click);
            // 
            // lbl_Extrudering_2
            // 
            this.lbl_Extrudering_2.AutoSize = true;
            this.lbl_Extrudering_2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Extrudering_2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Extrudering_2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Extrudering_2.Location = new System.Drawing.Point(90, 85);
            this.lbl_Extrudering_2.Name = "lbl_Extrudering_2";
            this.lbl_Extrudering_2.Size = new System.Drawing.Size(225, 19);
            this.lbl_Extrudering_2.TabIndex = 3;
            this.lbl_Extrudering_2.Text = "Extrudering - 2 Maskiner";
            this.lbl_Extrudering_2.Click += new System.EventHandler(this.lbl_Extrudering_2_Click);
            // 
            // lbl_Krympslang
            // 
            this.lbl_Krympslang.AutoSize = true;
            this.lbl_Krympslang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Krympslang.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Krympslang.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Krympslang.Location = new System.Drawing.Point(90, 115);
            this.lbl_Krympslang.Name = "lbl_Krympslang";
            this.lbl_Krympslang.Size = new System.Drawing.Size(99, 19);
            this.lbl_Krympslang.TabIndex = 3;
            this.lbl_Krympslang.Text = "Krympslang";
            this.lbl_Krympslang.Click += new System.EventHandler(this.lbl_Krympslang_Click);
            // 
            // lbl_Kragning
            // 
            this.lbl_Kragning.AutoSize = true;
            this.lbl_Kragning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Kragning.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Kragning.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Kragning.Location = new System.Drawing.Point(90, 145);
            this.lbl_Kragning.Name = "lbl_Kragning";
            this.lbl_Kragning.Size = new System.Drawing.Size(81, 19);
            this.lbl_Kragning.TabIndex = 3;
            this.lbl_Kragning.Text = "Kragning";
            this.lbl_Kragning.Click += new System.EventHandler(this.lbl_Kragning_Click);
            // 
            // lbl_Svetsning
            // 
            this.lbl_Svetsning.AutoSize = true;
            this.lbl_Svetsning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Svetsning.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Svetsning.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Svetsning.Location = new System.Drawing.Point(90, 235);
            this.lbl_Svetsning.Name = "lbl_Svetsning";
            this.lbl_Svetsning.Size = new System.Drawing.Size(90, 19);
            this.lbl_Svetsning.TabIndex = 3;
            this.lbl_Svetsning.Text = "Svetsning";
            this.lbl_Svetsning.Click += new System.EventHandler(this.lbl_Svetsning_Click);
            // 
            // lbl_Slipning
            // 
            this.lbl_Slipning.AutoSize = true;
            this.lbl_Slipning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Slipning.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Slipning.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Slipning.Location = new System.Drawing.Point(90, 265);
            this.lbl_Slipning.Name = "lbl_Slipning";
            this.lbl_Slipning.Size = new System.Drawing.Size(81, 19);
            this.lbl_Slipning.TabIndex = 3;
            this.lbl_Slipning.Text = "Slipning";
            this.lbl_Slipning.Click += new System.EventHandler(this.lbl_Slipning_Click);
            // 
            // lbl_Skärmning
            // 
            this.lbl_Skärmning.AutoSize = true;
            this.lbl_Skärmning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Skärmning.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Skärmning.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Skärmning.Location = new System.Drawing.Point(90, 205);
            this.lbl_Skärmning.Name = "lbl_Skärmning";
            this.lbl_Skärmning.Size = new System.Drawing.Size(90, 19);
            this.lbl_Skärmning.TabIndex = 3;
            this.lbl_Skärmning.Text = "Skärmning";
            this.lbl_Skärmning.Click += new System.EventHandler(this.lbl_Skärmning_Click);
            // 
            // lbl_Hackning
            // 
            this.lbl_Hackning.AutoSize = true;
            this.lbl_Hackning.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Hackning.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hackning.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_Hackning.Location = new System.Drawing.Point(90, 175);
            this.lbl_Hackning.Name = "lbl_Hackning";
            this.lbl_Hackning.Size = new System.Drawing.Size(81, 19);
            this.lbl_Hackning.TabIndex = 3;
            this.lbl_Hackning.Text = "Hackning";
            this.lbl_Hackning.Click += new System.EventHandler(this.lbl_Hackning_Click);
            // 
            // VäljProcesskort
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 332);
            this.Controls.Add(this.lbl_Slipning);
            this.Controls.Add(this.lbl_Skärmning);
            this.Controls.Add(this.lbl_Svetsning);
            this.Controls.Add(this.lbl_Hackning);
            this.Controls.Add(this.lbl_Kragning);
            this.Controls.Add(this.lbl_Krympslang);
            this.Controls.Add(this.lbl_Extrudering_2);
            this.Controls.Add(this.lbl_Extrudering_1);
            this.Controls.Add(this.label_Rubrik);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VäljProcesskort";
            this.Text = "VäljProcesskort";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Rubrik;
        private Label lbl_Extrudering_1;
        private Label lbl_Extrudering_2;
        private Label lbl_Krympslang;
        private Label lbl_Kragning;
        private Label lbl_Svetsning;
        private Label lbl_Slipning;
        private Label lbl_Skärmning;
        private Label lbl_Hackning;
    }
}