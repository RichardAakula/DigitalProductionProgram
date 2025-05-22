namespace DigitalProductionProgram.EasterEggs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EasterEgg_Code));
            btn_TestCode = new Button();
            SuspendLayout();
            // 
            // btn_TestCode
            // 
            btn_TestCode.BackColor = Color.Transparent;
            btn_TestCode.BackgroundImage = (Image)resources.GetObject("btn_TestCode.BackgroundImage");
            btn_TestCode.BackgroundImageLayout = ImageLayout.Zoom;
            btn_TestCode.FlatAppearance.BorderSize = 0;
            btn_TestCode.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 40, 40, 40);
            btn_TestCode.FlatStyle = FlatStyle.Flat;
            btn_TestCode.Font = new Font("Segoe UI", 18F);
            btn_TestCode.ForeColor = Color.Gold;
            btn_TestCode.Location = new Point(811, 424);
            btn_TestCode.Margin = new Padding(0);
            btn_TestCode.Name = "btn_TestCode";
            btn_TestCode.Size = new Size(184, 76);
            btn_TestCode.TabIndex = 0;
            btn_TestCode.UseVisualStyleBackColor = false;
            btn_TestCode.Click += btn_TestCode_Click;
            // 
            // EasterEgg_Code
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1790, 500);
            Controls.Add(btn_TestCode);
            Name = "EasterEgg_Code";
            Text = "EasterEgg_Code";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_TestCode;
    }
}