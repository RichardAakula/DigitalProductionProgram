using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class Main_FilterQuickOpen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_FilterQuickOpen));
            this.flp_Labels = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_BackGround = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb_Top = new System.Windows.Forms.PictureBox();
            this.tlp_BackGround.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Top)).BeginInit();
            this.SuspendLayout();
            // 
            // flp_Labels
            // 
            this.flp_Labels.AutoSize = true;
            this.flp_Labels.BackColor = System.Drawing.Color.Black;
            this.flp_Labels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Labels.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Labels.Location = new System.Drawing.Point(10, 27);
            this.flp_Labels.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Labels.Name = "flp_Labels";
            this.flp_Labels.Size = new System.Drawing.Size(230, 280);
            this.flp_Labels.TabIndex = 0;
            // 
            // tlp_BackGround
            // 
            this.tlp_BackGround.BackColor = System.Drawing.Color.Black;
            this.tlp_BackGround.ColumnCount = 3;
            this.tlp_BackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlp_BackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_BackGround.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlp_BackGround.Controls.Add(this.pictureBox1, 1, 2);
            this.tlp_BackGround.Controls.Add(this.flp_Labels, 1, 1);
            this.tlp_BackGround.Controls.Add(this.pb_Top, 1, 0);
            this.tlp_BackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_BackGround.Location = new System.Drawing.Point(0, 0);
            this.tlp_BackGround.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_BackGround.Name = "tlp_BackGround";
            this.tlp_BackGround.RowCount = 3;
            this.tlp_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlp_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_BackGround.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlp_BackGround.Size = new System.Drawing.Size(250, 335);
            this.tlp_BackGround.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 307);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(230, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.Close_Click);
            // 
            // pb_Top
            // 
            this.pb_Top.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_Top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Top.Image = ((System.Drawing.Image)(resources.GetObject("pb_Top.Image")));
            this.pb_Top.Location = new System.Drawing.Point(10, 0);
            this.pb_Top.Margin = new System.Windows.Forms.Padding(0);
            this.pb_Top.Name = "pb_Top";
            this.pb_Top.Size = new System.Drawing.Size(230, 27);
            this.pb_Top.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Top.TabIndex = 1;
            this.pb_Top.TabStop = false;
            this.pb_Top.Click += new System.EventHandler(this.Close_Click);
            // 
            // Main_QuickOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(250, 335);
            this.Controls.Add(this.tlp_BackGround);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_QuickOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SnabbÖppna";
            this.tlp_BackGround.ResumeLayout(false);
            this.tlp_BackGround.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Top)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_Labels;
        private TableLayoutPanel tlp_BackGround;
        private PictureBox pb_Top;
        private PictureBox pictureBox1;
    }
}