using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.User
{
    partial class ProfileCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileCard));
            this.pBox_OptinovaLogo = new System.Windows.Forms.PictureBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_Role = new System.Windows.Forms.Label();
            this.lbl_Sign = new System.Windows.Forms.Label();
            this.lbl_EmpNr = new System.Windows.Forms.Label();
            this.lbl_Department = new System.Windows.Forms.Label();
            this.chb_OpenLastOrder = new System.Windows.Forms.CheckBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.pb_Image = new System.Windows.Forms.PictureBox();
            this.label_Department = new System.Windows.Forms.Label();
            this.label_EmpNr = new System.Windows.Forms.Label();
            this.label_Sign = new System.Windows.Forms.Label();
            this.label_Role = new System.Windows.Forms.Label();
            this.lbl_LastOrder = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_OptinovaLogo)).BeginInit();
            this.tlp_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pBox_OptinovaLogo
            // 
            this.pBox_OptinovaLogo.BackColor = System.Drawing.Color.Transparent;
            this.pBox_OptinovaLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_OptinovaLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pBox_OptinovaLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pBox_OptinovaLogo.Image = ((System.Drawing.Image)(resources.GetObject("pBox_OptinovaLogo.Image")));
            this.pBox_OptinovaLogo.Location = new System.Drawing.Point(0, 0);
            this.pBox_OptinovaLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pBox_OptinovaLogo.Name = "pBox_OptinovaLogo";
            this.pBox_OptinovaLogo.Size = new System.Drawing.Size(402, 43);
            this.pBox_OptinovaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_OptinovaLogo.TabIndex = 6;
            this.pBox_OptinovaLogo.TabStop = false;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 3;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 91F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 236F));
            this.tlp_Main.Controls.Add(this.lbl_Role, 2, 4);
            this.tlp_Main.Controls.Add(this.lbl_Sign, 2, 3);
            this.tlp_Main.Controls.Add(this.lbl_EmpNr, 2, 2);
            this.tlp_Main.Controls.Add(this.lbl_Department, 2, 1);
            this.tlp_Main.Controls.Add(this.chb_OpenLastOrder, 0, 5);
            this.tlp_Main.Controls.Add(this.label_Name, 0, 0);
            this.tlp_Main.Controls.Add(this.pb_Image, 0, 1);
            this.tlp_Main.Controls.Add(this.label_Department, 1, 1);
            this.tlp_Main.Controls.Add(this.label_EmpNr, 1, 2);
            this.tlp_Main.Controls.Add(this.label_Sign, 1, 3);
            this.tlp_Main.Controls.Add(this.label_Role, 1, 4);
            this.tlp_Main.Controls.Add(this.lbl_LastOrder, 2, 5);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 43);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 6;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_Main.Size = new System.Drawing.Size(402, 222);
            this.tlp_Main.TabIndex = 7;
            // 
            // lbl_Role
            // 
            this.lbl_Role.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Role.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Role.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Role.Location = new System.Drawing.Point(172, 91);
            this.lbl_Role.Name = "lbl_Role";
            this.lbl_Role.Size = new System.Drawing.Size(230, 44);
            this.lbl_Role.TabIndex = 57;
            // 
            // lbl_Sign
            // 
            this.lbl_Sign.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Sign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Sign.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Sign.Location = new System.Drawing.Point(172, 69);
            this.lbl_Sign.Name = "lbl_Sign";
            this.lbl_Sign.Size = new System.Drawing.Size(230, 22);
            this.lbl_Sign.TabIndex = 55;
            // 
            // lbl_EmpNr
            // 
            this.lbl_EmpNr.BackColor = System.Drawing.Color.Transparent;
            this.lbl_EmpNr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_EmpNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_EmpNr.ForeColor = System.Drawing.Color.Gray;
            this.lbl_EmpNr.Location = new System.Drawing.Point(172, 47);
            this.lbl_EmpNr.Name = "lbl_EmpNr";
            this.lbl_EmpNr.Size = new System.Drawing.Size(230, 22);
            this.lbl_EmpNr.TabIndex = 54;
            // 
            // lbl_Department
            // 
            this.lbl_Department.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Department.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Department.ForeColor = System.Drawing.Color.Gray;
            this.lbl_Department.Location = new System.Drawing.Point(172, 25);
            this.lbl_Department.Name = "lbl_Department";
            this.lbl_Department.Size = new System.Drawing.Size(230, 22);
            this.lbl_Department.TabIndex = 53;
            // 
            // chb_OpenLastOrder
            // 
            this.chb_OpenLastOrder.AutoSize = true;
            this.chb_OpenLastOrder.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.SetColumnSpan(this.chb_OpenLastOrder, 2);
            this.chb_OpenLastOrder.Enabled = false;
            this.chb_OpenLastOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chb_OpenLastOrder.ForeColor = System.Drawing.Color.White;
            this.chb_OpenLastOrder.Location = new System.Drawing.Point(3, 138);
            this.chb_OpenLastOrder.Name = "chb_OpenLastOrder";
            this.chb_OpenLastOrder.Size = new System.Drawing.Size(156, 20);
            this.chb_OpenLastOrder.TabIndex = 52;
            this.chb_OpenLastOrder.Text = "Öppna senaste order:";
            this.chb_OpenLastOrder.UseVisualStyleBackColor = false;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.SetColumnSpan(this.label_Name, 3);
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Name.Location = new System.Drawing.Point(3, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(399, 25);
            this.label_Name.TabIndex = 46;
            this.label_Name.Text = "Namn:";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pb_Image
            // 
            this.pb_Image.BackColor = System.Drawing.Color.Transparent;
            this.pb_Image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pb_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Image.Location = new System.Drawing.Point(3, 28);
            this.pb_Image.Name = "pb_Image";
            this.tlp_Main.SetRowSpan(this.pb_Image, 4);
            this.pb_Image.Size = new System.Drawing.Size(72, 104);
            this.pb_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Image.TabIndex = 47;
            this.pb_Image.TabStop = false;
            // 
            // label_Department
            // 
            this.label_Department.AutoSize = true;
            this.label_Department.BackColor = System.Drawing.Color.Transparent;
            this.label_Department.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Department.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Department.Location = new System.Drawing.Point(96, 25);
            this.label_Department.Name = "label_Department";
            this.label_Department.Size = new System.Drawing.Size(70, 22);
            this.label_Department.TabIndex = 48;
            this.label_Department.Text = "Avdelning:";
            // 
            // label_EmpNr
            // 
            this.label_EmpNr.AutoSize = true;
            this.label_EmpNr.BackColor = System.Drawing.Color.Transparent;
            this.label_EmpNr.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_EmpNr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EmpNr.ForeColor = System.Drawing.SystemColors.Info;
            this.label_EmpNr.Location = new System.Drawing.Point(113, 47);
            this.label_EmpNr.Name = "label_EmpNr";
            this.label_EmpNr.Size = new System.Drawing.Size(53, 22);
            this.label_EmpNr.TabIndex = 49;
            this.label_EmpNr.Text = "Anst.Nr:";
            // 
            // label_Sign
            // 
            this.label_Sign.AutoSize = true;
            this.label_Sign.BackColor = System.Drawing.Color.Transparent;
            this.label_Sign.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Sign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Sign.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Sign.Location = new System.Drawing.Point(129, 69);
            this.label_Sign.Name = "label_Sign";
            this.label_Sign.Size = new System.Drawing.Size(37, 22);
            this.label_Sign.TabIndex = 50;
            this.label_Sign.Text = "Sign:";
            // 
            // label_Role
            // 
            this.label_Role.AutoSize = true;
            this.label_Role.BackColor = System.Drawing.Color.Transparent;
            this.label_Role.Dock = System.Windows.Forms.DockStyle.Right;
            this.label_Role.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Role.ForeColor = System.Drawing.SystemColors.Info;
            this.label_Role.Location = new System.Drawing.Point(97, 91);
            this.label_Role.Name = "label_Role";
            this.label_Role.Size = new System.Drawing.Size(69, 44);
            this.label_Role.TabIndex = 51;
            this.label_Role.Text = "Befattning:";
            // 
            // lbl_LastOrder
            // 
            this.lbl_LastOrder.BackColor = System.Drawing.Color.Transparent;
            this.lbl_LastOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_LastOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastOrder.ForeColor = System.Drawing.Color.Gray;
            this.lbl_LastOrder.Location = new System.Drawing.Point(172, 135);
            this.lbl_LastOrder.Name = "lbl_LastOrder";
            this.lbl_LastOrder.Size = new System.Drawing.Size(230, 16);
            this.lbl_LastOrder.TabIndex = 56;
            this.lbl_LastOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProfileCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.pBox_OptinovaLogo);
            this.Name = "ProfileCard";
            this.Size = new System.Drawing.Size(402, 265);
            ((System.ComponentModel.ISupportInitialize)(this.pBox_OptinovaLogo)).EndInit();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pBox_OptinovaLogo;
        private TableLayoutPanel tlp_Main;
        private Label label_Department;
        private Label label_EmpNr;
        private Label label_Sign;
        private Label label_Role;
        public Label label_Name;
        public PictureBox pb_Image;
        public CheckBox chb_OpenLastOrder;
        public Label lbl_Department;
        public Label lbl_EmpNr;
        public Label lbl_Sign;
        public Label lbl_LastOrder;
        public Label lbl_Role;
    }
}
