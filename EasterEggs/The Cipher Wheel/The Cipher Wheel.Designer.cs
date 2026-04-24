namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    partial class EasterEgg_Code
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            btn_TestCode = new CipherWheelActionButton();
            SuspendLayout();
            // 
            // btn_TestCode
            // 
            btn_TestCode.BackColor = Color.Transparent;
            btn_TestCode.Cursor = Cursors.Hand;
            btn_TestCode.FlatAppearance.BorderSize = 0;
            btn_TestCode.FlatStyle = FlatStyle.Flat;
            btn_TestCode.Font = new Font("Palatino Linotype", 12.6F, FontStyle.Bold);
            btn_TestCode.ForeColor = Color.FromArgb(243, 228, 176);
            btn_TestCode.Location = new Point(1579, 598);
            btn_TestCode.Margin = new Padding(0);
            btn_TestCode.Name = "btn_TestCode";
            btn_TestCode.Size = new Size(186, 44);
            btn_TestCode.TabIndex = 0;
            btn_TestCode.Text = "Test Code";
            btn_TestCode.UseVisualStyleBackColor = false;
            btn_TestCode.Click += btn_TestCode_Click;
            // 
            // EasterEgg_Code
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1790, 680);
            Controls.Add(btn_TestCode);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EasterEgg_Code";
            ResumeLayout(false);
        }

        #endregion

        private CipherWheelActionButton btn_TestCode;
    }
}
