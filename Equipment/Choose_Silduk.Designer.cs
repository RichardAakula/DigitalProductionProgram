using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Equipment
{
    partial class Choose_Silduk
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
            this.btn_Select = new System.Windows.Forms.Button();
            this.label_Info_ScreenPackage = new System.Windows.Forms.Label();
            this.flp_Sildukar = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_80 = new System.Windows.Forms.Button();
            this.btn_150 = new System.Windows.Forms.Button();
            this.btn_325 = new System.Windows.Forms.Button();
            this.btn_500 = new System.Windows.Forms.Button();
            this.btn_NA = new System.Windows.Forms.Button();
            this.tb_Silduk = new System.Windows.Forms.TextBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.tlp_Main.SuspendLayout();
            this.flp_Sildukar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.btn_Select, 0, 3);
            this.tlp_Main.Controls.Add(this.label_Info_ScreenPackage, 0, 0);
            this.tlp_Main.Controls.Add(this.flp_Sildukar, 0, 1);
            this.tlp_Main.Controls.Add(this.tb_Silduk, 0, 2);
            this.tlp_Main.Controls.Add(this.btn_Exit, 1, 3);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 4;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(412, 150);
            this.tlp_Main.TabIndex = 0;
            // 
            // btn_Select
            // 
            this.btn_Select.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Select.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Select.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Select.ForeColor = System.Drawing.Color.Gray;
            this.btn_Select.Location = new System.Drawing.Point(0, 106);
            this.btn_Select.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(99, 44);
            this.btn_Select.TabIndex = 4;
            this.btn_Select.Text = "Välj";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.Back_Click);
            // 
            // label_Info_ScreenPackage
            // 
            this.label_Info_ScreenPackage.AutoSize = true;
            this.tlp_Main.SetColumnSpan(this.label_Info_ScreenPackage, 2);
            this.label_Info_ScreenPackage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_ScreenPackage.Font = new System.Drawing.Font("Lucida Sans", 12.25F);
            this.label_Info_ScreenPackage.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Info_ScreenPackage.Location = new System.Drawing.Point(3, 0);
            this.label_Info_ScreenPackage.Name = "label_Info_ScreenPackage";
            this.label_Info_ScreenPackage.Size = new System.Drawing.Size(406, 24);
            this.label_Info_ScreenPackage.TabIndex = 0;
            this.label_Info_ScreenPackage.Text = "Välj Silduk";
            this.label_Info_ScreenPackage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flp_Sildukar
            // 
            this.tlp_Main.SetColumnSpan(this.flp_Sildukar, 2);
            this.flp_Sildukar.Controls.Add(this.btn_Clear);
            this.flp_Sildukar.Controls.Add(this.btn_80);
            this.flp_Sildukar.Controls.Add(this.btn_150);
            this.flp_Sildukar.Controls.Add(this.btn_325);
            this.flp_Sildukar.Controls.Add(this.btn_500);
            this.flp_Sildukar.Controls.Add(this.btn_NA);
            this.flp_Sildukar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Sildukar.Location = new System.Drawing.Point(3, 27);
            this.flp_Sildukar.Name = "flp_Sildukar";
            this.flp_Sildukar.Size = new System.Drawing.Size(406, 36);
            this.flp_Sildukar.TabIndex = 1;
            // 
            // btn_Clear
            // 
            this.btn_Clear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.ForeColor = System.Drawing.Color.Gray;
            this.btn_Clear.Location = new System.Drawing.Point(0, 0);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(0, 0, 40, 0);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(77, 36);
            this.btn_Clear.TabIndex = 4;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = true;
            this.btn_Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // btn_80
            // 
            this.btn_80.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_80.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_80.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_80.ForeColor = System.Drawing.Color.Gray;
            this.btn_80.Location = new System.Drawing.Point(117, 0);
            this.btn_80.Margin = new System.Windows.Forms.Padding(0);
            this.btn_80.Name = "btn_80";
            this.btn_80.Size = new System.Drawing.Size(55, 36);
            this.btn_80.TabIndex = 0;
            this.btn_80.Text = "80";
            this.btn_80.UseVisualStyleBackColor = true;
            this.btn_80.Click += new System.EventHandler(this.Add_Silduk_Click);
            // 
            // btn_150
            // 
            this.btn_150.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_150.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_150.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_150.ForeColor = System.Drawing.Color.Gray;
            this.btn_150.Location = new System.Drawing.Point(172, 0);
            this.btn_150.Margin = new System.Windows.Forms.Padding(0);
            this.btn_150.Name = "btn_150";
            this.btn_150.Size = new System.Drawing.Size(55, 36);
            this.btn_150.TabIndex = 1;
            this.btn_150.Text = "150";
            this.btn_150.UseVisualStyleBackColor = true;
            this.btn_150.Click += new System.EventHandler(this.Add_Silduk_Click);
            // 
            // btn_325
            // 
            this.btn_325.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_325.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_325.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_325.ForeColor = System.Drawing.Color.Gray;
            this.btn_325.Location = new System.Drawing.Point(227, 0);
            this.btn_325.Margin = new System.Windows.Forms.Padding(0);
            this.btn_325.Name = "btn_325";
            this.btn_325.Size = new System.Drawing.Size(55, 36);
            this.btn_325.TabIndex = 2;
            this.btn_325.Text = "325";
            this.btn_325.UseVisualStyleBackColor = true;
            this.btn_325.Click += new System.EventHandler(this.Add_Silduk_Click);
            // 
            // btn_500
            // 
            this.btn_500.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btn_500.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_500.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_500.ForeColor = System.Drawing.Color.Gray;
            this.btn_500.Location = new System.Drawing.Point(282, 0);
            this.btn_500.Margin = new System.Windows.Forms.Padding(0);
            this.btn_500.Name = "btn_500";
            this.btn_500.Size = new System.Drawing.Size(55, 36);
            this.btn_500.TabIndex = 3;
            this.btn_500.Text = "500";
            this.btn_500.UseVisualStyleBackColor = true;
            this.btn_500.Click += new System.EventHandler(this.Add_Silduk_Click);
            // 
            // btn_NA
            // 
            this.btn_NA.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btn_NA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_NA.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_NA.Location = new System.Drawing.Point(337, 0);
            this.btn_NA.Margin = new System.Windows.Forms.Padding(0);
            this.btn_NA.Name = "btn_NA";
            this.btn_NA.Size = new System.Drawing.Size(55, 36);
            this.btn_NA.TabIndex = 3;
            this.btn_NA.Text = "N/A";
            this.btn_NA.UseVisualStyleBackColor = true;
            this.btn_NA.Click += new System.EventHandler(this.Add_Silduk_Click);
            // 
            // tb_Silduk
            // 
            this.tlp_Main.SetColumnSpan(this.tb_Silduk, 2);
            this.tb_Silduk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tb_Silduk.Font = new System.Drawing.Font("Courier New", 12.25F);
            this.tb_Silduk.Location = new System.Drawing.Point(0, 66);
            this.tb_Silduk.Margin = new System.Windows.Forms.Padding(0);
            this.tb_Silduk.Name = "tb_Silduk";
            this.tb_Silduk.Size = new System.Drawing.Size(412, 26);
            this.tb_Silduk.TabIndex = 2;
            this.tb_Silduk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(0)))), ((int)(((byte)(6)))));
            this.btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Exit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Exit.ForeColor = System.Drawing.Color.Gray;
            this.btn_Exit.Location = new System.Drawing.Point(314, 106);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(98, 44);
            this.btn_Exit.TabIndex = 4;
            this.btn_Exit.Text = "Avbryt";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Choose_Silduk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(412, 150);
            this.Controls.Add(this.tlp_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Choose_Silduk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Choose_Silduk";
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.flp_Sildukar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Info_ScreenPackage;
        private FlowLayoutPanel flp_Sildukar;
        private Button btn_80;
        private Button btn_150;
        private Button btn_325;
        private Button btn_500;
        private Button btn_Clear;
        private Button btn_Select;
        private TextBox tb_Silduk;
        private Button btn_Exit;
        private Button btn_NA;
    }
}