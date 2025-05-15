using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Protocols.LineClearance
{
    partial class LineClearance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineClearance));
            this.tlp_LineClearance = new System.Windows.Forms.TableLayoutPanel();
            this.panel_LineClearance = new System.Windows.Forms.Panel();
            this.pb_Info_LineClearance = new System.Windows.Forms.PictureBox();
            this.label_Line_Clearance = new System.Windows.Forms.Label();
            this.tlp_DateName = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_LC_Name = new System.Windows.Forms.Label();
            this.label_LC_Name_Date = new System.Windows.Forms.Label();
            this.LC_Date = new System.Windows.Forms.Label();
            this.tlp_LineClearance.SuspendLayout();
            this.panel_LineClearance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_LineClearance)).BeginInit();
            this.tlp_DateName.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_LineClearance
            // 
            this.tlp_LineClearance.BackColor = System.Drawing.Color.Transparent;
            this.tlp_LineClearance.ColumnCount = 6;
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 118F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tlp_LineClearance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_LineClearance.Controls.Add(this.panel_LineClearance, 0, 0);
            this.tlp_LineClearance.Controls.Add(this.tlp_DateName, 0, 1);
            this.tlp_LineClearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_LineClearance.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlp_LineClearance.Location = new System.Drawing.Point(0, 0);
            this.tlp_LineClearance.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_LineClearance.Name = "tlp_LineClearance";
            this.tlp_LineClearance.RowCount = 2;
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_LineClearance.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_LineClearance.Size = new System.Drawing.Size(974, 52);
            this.tlp_LineClearance.TabIndex = 1035;
            // 
            // panel_LineClearance
            // 
            this.panel_LineClearance.BackColor = System.Drawing.Color.LightGray;
            this.tlp_LineClearance.SetColumnSpan(this.panel_LineClearance, 6);
            this.panel_LineClearance.Controls.Add(this.pb_Info_LineClearance);
            this.panel_LineClearance.Controls.Add(this.label_Line_Clearance);
            this.panel_LineClearance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_LineClearance.Location = new System.Drawing.Point(1, 0);
            this.panel_LineClearance.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel_LineClearance.Name = "panel_LineClearance";
            this.panel_LineClearance.Size = new System.Drawing.Size(972, 25);
            this.panel_LineClearance.TabIndex = 133;
            // 
            // pb_Info_LineClearance
            // 
            this.pb_Info_LineClearance.BackColor = System.Drawing.Color.Transparent;
            this.pb_Info_LineClearance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_Info_LineClearance.BackgroundImage")));
            this.pb_Info_LineClearance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_Info_LineClearance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Info_LineClearance.Dock = System.Windows.Forms.DockStyle.Left;
            this.pb_Info_LineClearance.Location = new System.Drawing.Point(110, 0);
            this.pb_Info_LineClearance.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Info_LineClearance.Name = "pb_Info_LineClearance";
            this.pb_Info_LineClearance.Size = new System.Drawing.Size(25, 25);
            this.pb_Info_LineClearance.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Info_LineClearance.TabIndex = 930;
            this.pb_Info_LineClearance.TabStop = false;
            // 
            // label_Line_Clearance
            // 
            this.label_Line_Clearance.BackColor = System.Drawing.Color.LightGray;
            this.label_Line_Clearance.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label_Line_Clearance.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Line_Clearance.Font = new System.Drawing.Font("Palatino Linotype", 10.25F);
            this.label_Line_Clearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label_Line_Clearance.Location = new System.Drawing.Point(0, 0);
            this.label_Line_Clearance.Margin = new System.Windows.Forms.Padding(0);
            this.label_Line_Clearance.Name = "label_Line_Clearance";
            this.label_Line_Clearance.Size = new System.Drawing.Size(110, 25);
            this.label_Line_Clearance.TabIndex = 929;
            this.label_Line_Clearance.Text = "Line Clearance:";
            // 
            // tlp_DateName
            // 
            this.tlp_DateName.BackColor = System.Drawing.Color.White;
            this.tlp_DateName.ColumnCount = 4;
            this.tlp_LineClearance.SetColumnSpan(this.tlp_DateName, 6);
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_DateName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_DateName.Controls.Add(this.lbl_LC_Name, 2, 0);
            this.tlp_DateName.Controls.Add(this.label_LC_Name_Date, 0, 0);
            this.tlp_DateName.Controls.Add(this.LC_Date, 1, 0);
            this.tlp_DateName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_DateName.Location = new System.Drawing.Point(0, 26);
            this.tlp_DateName.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_DateName.Name = "tlp_DateName";
            this.tlp_DateName.RowCount = 1;
            this.tlp_DateName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_DateName.Size = new System.Drawing.Size(974, 26);
            this.tlp_DateName.TabIndex = 135;
            // 
            // lbl_LC_Name
            // 
            this.lbl_LC_Name.BackColor = System.Drawing.Color.White;
            this.lbl_LC_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_LC_Name.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_LC_Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_LC_Name.Font = new System.Drawing.Font("Arial", 8F);
            this.lbl_LC_Name.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbl_LC_Name.Location = new System.Drawing.Point(293, 1);
            this.lbl_LC_Name.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.lbl_LC_Name.Name = "lbl_LC_Name";
            this.lbl_LC_Name.Size = new System.Drawing.Size(200, 24);
            this.lbl_LC_Name.TabIndex = 1031;
            this.lbl_LC_Name.Text = "Klicka här för Line Clearance...";
            this.lbl_LC_Name.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lbl_LC_Name.Click += new System.EventHandler(this.LC_Performed_Click);
            // 
            // label_LC_Name_Date
            // 
            this.label_LC_Name_Date.BackColor = System.Drawing.SystemColors.Window;
            this.label_LC_Name_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_LC_Name_Date.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_LC_Name_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_LC_Name_Date.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LC_Name_Date.ForeColor = System.Drawing.Color.Black;
            this.label_LC_Name_Date.Location = new System.Drawing.Point(1, 1);
            this.label_LC_Name_Date.Margin = new System.Windows.Forms.Padding(1, 1, 0, 1);
            this.label_LC_Name_Date.Name = "label_LC_Name_Date";
            this.label_LC_Name_Date.Size = new System.Drawing.Size(144, 24);
            this.label_LC_Name_Date.TabIndex = 1028;
            this.label_LC_Name_Date.Text = "Datum / Namn:";
            this.label_LC_Name_Date.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // LC_Date
            // 
            this.LC_Date.BackColor = System.Drawing.Color.White;
            this.LC_Date.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LC_Date.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LC_Date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LC_Date.Font = new System.Drawing.Font("Arial", 8F);
            this.LC_Date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.LC_Date.Location = new System.Drawing.Point(145, 1);
            this.LC_Date.Margin = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.LC_Date.Name = "LC_Date";
            this.LC_Date.Size = new System.Drawing.Size(148, 24);
            this.LC_Date.TabIndex = 1030;
            this.LC_Date.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // LineClearance_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_LineClearance);
            this.Name = "LineClearance_A";
            this.Size = new System.Drawing.Size(974, 52);
            this.tlp_LineClearance.ResumeLayout(false);
            this.panel_LineClearance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Info_LineClearance)).EndInit();
            this.tlp_DateName.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public TableLayoutPanel tlp_LineClearance;
        private Panel panel_LineClearance;
        private PictureBox pb_Info_LineClearance;
        private Label label_Line_Clearance;
        private TableLayoutPanel tlp_DateName;
        public Label lbl_LC_Name;
        private Label label_LC_Name_Date;
        private Label LC_Date;
    }
}
