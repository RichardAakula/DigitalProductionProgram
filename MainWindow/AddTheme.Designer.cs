using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class AddTheme
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
            this.cb_Theme = new System.Windows.Forms.ComboBox();
            this.label_ChooseTheme = new System.Windows.Forms.Label();
            this.btn_AddProfilePicture = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cb_Theme
            // 
            this.cb_Theme.FormattingEnabled = true;
            this.cb_Theme.Location = new System.Drawing.Point(33, 45);
            this.cb_Theme.Name = "cb_Theme";
            this.cb_Theme.Size = new System.Drawing.Size(168, 21);
            this.cb_Theme.TabIndex = 0;
            // 
            // label_ChooseTheme
            // 
            this.label_ChooseTheme.AutoSize = true;
            this.label_ChooseTheme.BackColor = System.Drawing.SystemColors.Info;
            this.label_ChooseTheme.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ChooseTheme.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_ChooseTheme.Location = new System.Drawing.Point(33, 13);
            this.label_ChooseTheme.Name = "label_ChooseTheme";
            this.label_ChooseTheme.Size = new System.Drawing.Size(67, 15);
            this.label_ChooseTheme.TabIndex = 1;
            this.label_ChooseTheme.Text = "Välj Tema";
            // 
            // btn_AddProfilePicture
            // 
            this.btn_AddProfilePicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_AddProfilePicture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddProfilePicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btn_AddProfilePicture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(97)))), ((int)(((byte)(0)))));
            this.btn_AddProfilePicture.Location = new System.Drawing.Point(33, 83);
            this.btn_AddProfilePicture.Name = "btn_AddProfilePicture";
            this.btn_AddProfilePicture.Size = new System.Drawing.Size(214, 27);
            this.btn_AddProfilePicture.TabIndex = 64;
            this.btn_AddProfilePicture.Text = "Ladda upp Temabild";
            this.btn_AddProfilePicture.UseVisualStyleBackColor = false;
            this.btn_AddProfilePicture.Click += new System.EventHandler(this.btn_AddProfilePicture_Click);
            // 
            // AddTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(786, 370);
            this.Controls.Add(this.btn_AddProfilePicture);
            this.Controls.Add(this.label_ChooseTheme);
            this.Controls.Add(this.cb_Theme);
            this.Name = "AddTheme";
            this.Text = "AddTheme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cb_Theme;
        private Label label_ChooseTheme;
        private Button btn_AddProfilePicture;
    }
}