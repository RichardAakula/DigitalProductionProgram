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
            label_Linje = new Label();
            label_Sida = new Label();
            cb_Machine = new ComboBox();
            lbl_Add = new Label();
            lbl_Close = new Label();
            lbl_Side = new Label();
            SuspendLayout();
            // 
            // label_Linje
            // 
            label_Linje.AutoSize = true;
            label_Linje.Font = new Font("Nirmala UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Linje.Location = new Point(14, 10);
            label_Linje.Margin = new Padding(4, 0, 4, 0);
            label_Linje.Name = "label_Linje";
            label_Linje.Size = new Size(269, 25);
            label_Linje.TabIndex = 0;
            label_Linje.Text = "Fyll i namnet på den nya linjen";
            // 
            // label_Sida
            // 
            label_Sida.AutoSize = true;
            label_Sida.Font = new Font("Nirmala UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Sida.Location = new Point(14, 89);
            label_Sida.Margin = new Padding(4, 0, 4, 0);
            label_Sida.Name = "label_Sida";
            label_Sida.Size = new Size(178, 25);
            label_Sida.TabIndex = 0;
            label_Sida.Text = "Fyll i sidan på linjen";
            // 
            // cb_Machine
            // 
            cb_Machine.BackColor = Color.LemonChiffon;
            cb_Machine.Font = new Font("Consolas", 9.75F);
            cb_Machine.FormattingEnabled = true;
            cb_Machine.Location = new Point(20, 44);
            cb_Machine.Margin = new Padding(4, 3, 4, 3);
            cb_Machine.Name = "cb_Machine";
            cb_Machine.Size = new Size(231, 23);
            cb_Machine.TabIndex = 2;
            // 
            // lbl_Add
            // 
            lbl_Add.AutoSize = true;
            lbl_Add.BorderStyle = BorderStyle.FixedSingle;
            lbl_Add.Cursor = Cursors.Hand;
            lbl_Add.Font = new Font("Palatino Linotype", 16F, FontStyle.Bold);
            lbl_Add.ForeColor = Color.FromArgb(0, 97, 0);
            lbl_Add.Location = new Point(4, 179);
            lbl_Add.Margin = new Padding(12, 0, 4, 0);
            lbl_Add.Name = "lbl_Add";
            lbl_Add.Size = new Size(149, 31);
            lbl_Add.TabIndex = 4;
            lbl_Add.Text = "Lägg till linje";
            lbl_Add.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Add.Click += Back_Click;
            // 
            // lbl_Close
            // 
            lbl_Close.AutoSize = true;
            lbl_Close.Cursor = Cursors.Hand;
            lbl_Close.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lbl_Close.ForeColor = Color.Maroon;
            lbl_Close.Location = new Point(609, 2);
            lbl_Close.Margin = new Padding(4, 0, 4, 0);
            lbl_Close.Name = "lbl_Close";
            lbl_Close.Size = new Size(24, 25);
            lbl_Close.TabIndex = 5;
            lbl_Close.Text = "X";
            lbl_Close.Click += Close_Click;
            // 
            // lbl_Side
            // 
            lbl_Side.BackColor = Color.Transparent;
            lbl_Side.BorderStyle = BorderStyle.FixedSingle;
            lbl_Side.Cursor = Cursors.Hand;
            lbl_Side.Font = new Font("Consolas", 9.25F);
            lbl_Side.ForeColor = Color.Gray;
            lbl_Side.Location = new Point(16, 140);
            lbl_Side.Margin = new Padding(1, 0, 1, 1);
            lbl_Side.Name = "lbl_Side";
            lbl_Side.Size = new Size(79, 27);
            lbl_Side.TabIndex = 909;
            lbl_Side.Text = "A";
            lbl_Side.TextAlign = ContentAlignment.MiddleCenter;
            lbl_Side.MouseDown += Side_MouseDown;
            // 
            // AddNewLine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(640, 218);
            Controls.Add(lbl_Side);
            Controls.Add(lbl_Close);
            Controls.Add(lbl_Add);
            Controls.Add(cb_Machine);
            Controls.Add(label_Sida);
            Controls.Add(label_Linje);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddNewLine";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Question";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private Label label_Linje;
        private Label label_Sida;
        private ComboBox cb_Machine;
        private Label lbl_Add;
        private Label lbl_Close;
        public Label lbl_Side;
    }
}