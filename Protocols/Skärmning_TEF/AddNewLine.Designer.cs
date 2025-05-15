using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.Skärmning_TEF
{
    partial class AddNewLine
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
            this.label_Linje = new System.Windows.Forms.Label();
            this.label_Sida = new System.Windows.Forms.Label();
            this.cb_Linje = new System.Windows.Forms.ComboBox();
            this.lbl_Add = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.lbl_Side = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Linje
            // 
            this.label_Linje.AutoSize = true;
            this.label_Linje.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Linje.Location = new System.Drawing.Point(12, 9);
            this.label_Linje.Name = "label_Linje";
            this.label_Linje.Size = new System.Drawing.Size(269, 25);
            this.label_Linje.TabIndex = 0;
            this.label_Linje.Text = "Fyll i namnet på den nya linjen";
            // 
            // label_Sida
            // 
            this.label_Sida.AutoSize = true;
            this.label_Sida.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Sida.Location = new System.Drawing.Point(12, 77);
            this.label_Sida.Name = "label_Sida";
            this.label_Sida.Size = new System.Drawing.Size(178, 25);
            this.label_Sida.TabIndex = 0;
            this.label_Sida.Text = "Fyll i sidan på linjen";
            // 
            // cb_Linje
            // 
            this.cb_Linje.BackColor = System.Drawing.Color.LemonChiffon;
            this.cb_Linje.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.cb_Linje.FormattingEnabled = true;
            this.cb_Linje.Location = new System.Drawing.Point(17, 38);
            this.cb_Linje.Name = "cb_Linje";
            this.cb_Linje.Size = new System.Drawing.Size(199, 23);
            this.cb_Linje.TabIndex = 2;
            // 
            // lbl_Add
            // 
            this.lbl_Add.AutoSize = true;
            this.lbl_Add.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Add.Font = new System.Drawing.Font("Palatino Linotype", 16F, System.Drawing.FontStyle.Bold);
            this.lbl_Add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.lbl_Add.Location = new System.Drawing.Point(3, 155);
            this.lbl_Add.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lbl_Add.Name = "lbl_Add";
            this.lbl_Add.Size = new System.Drawing.Size(149, 31);
            this.lbl_Add.TabIndex = 4;
            this.lbl_Add.Text = "Lägg till linje";
            this.lbl_Add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Add.Click += new System.EventHandler(this.Back_Click);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_Close.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_Close.Location = new System.Drawing.Point(522, 2);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(24, 25);
            this.lbl_Close.TabIndex = 5;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // lbl_Side
            // 
            this.lbl_Side.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Side.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Side.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Side.Font = new System.Drawing.Font("Consolas", 9.25F);
            this.lbl_Side.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Side.Location = new System.Drawing.Point(14, 121);
            this.lbl_Side.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.lbl_Side.Name = "lbl_Side";
            this.lbl_Side.Size = new System.Drawing.Size(68, 24);
            this.lbl_Side.TabIndex = 909;
            this.lbl_Side.Text = "A";
            this.lbl_Side.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Side.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Side_MouseDown);
            // 
            // AddNewLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(549, 189);
            this.Controls.Add(this.lbl_Side);
            this.Controls.Add(this.lbl_Close);
            this.Controls.Add(this.lbl_Add);
            this.Controls.Add(this.cb_Linje);
            this.Controls.Add(this.label_Sida);
            this.Controls.Add(this.label_Linje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddNewLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Question";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_Linje;
        private Label label_Sida;
        private ComboBox cb_Linje;
        private Label lbl_Add;
        private Label lbl_Close;
        public Label lbl_Side;
    }
}