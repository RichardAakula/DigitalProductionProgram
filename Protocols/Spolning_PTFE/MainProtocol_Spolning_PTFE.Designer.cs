using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Protocols.MainInfo;

namespace DigitalProductionProgram.Protocols.Spolning_PTFE
{
    partial class MainProtocol_Spolning_PTFE
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
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Info_2 = new System.Windows.Forms.Label();
            this.MainInfo = new MainInfo_Description_Prodtype();
            this.Journal = new Journal_Spolning_PTFE();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.label_Info_2, 0, 2);
            this.tlp_Main.Controls.Add(this.MainInfo, 0, 0);
            this.tlp_Main.Controls.Add(this.Journal, 0, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlp_Main.Size = new System.Drawing.Size(974, 590);
            this.tlp_Main.TabIndex = 1;
            // 
            // label_Info_2
            // 
            this.label_Info_2.AutoSize = true;
            this.label_Info_2.BackColor = System.Drawing.Color.White;
            this.label_Info_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Info_2.Location = new System.Drawing.Point(1, 568);
            this.label_Info_2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label_Info_2.Name = "label_Info_2";
            this.label_Info_2.Size = new System.Drawing.Size(972, 22);
            this.label_Info_2.TabIndex = 2;
            this.label_Info_2.Text = "BEDÖMNING AV: a) kvalitet; x= BRA b) fel i slangen; 1=SÄLLSYNT; 2=LITE; 3=OFTA\r\n\r" +
    "\n";
            this.label_Info_2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // MainInfo
            // 
            this.MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfo.Location = new System.Drawing.Point(1, 1);
            this.MainInfo.Margin = new System.Windows.Forms.Padding(1);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(972, 43);
            this.MainInfo.TabIndex = 0;
            // 
            // Journal
            // 
            this.Journal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Journal.Location = new System.Drawing.Point(0, 45);
            this.Journal.Margin = new System.Windows.Forms.Padding(0);
            this.Journal.Name = "Journal";
            this.Journal.Size = new System.Drawing.Size(974, 523);
            this.Journal.TabIndex = 3;
            // 
            // MainProtocol_Spolning_PTFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainProtocol_Spolning_PTFE";
            this.Size = new System.Drawing.Size(974, 590);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Label label_Info_2;
        public MainInfo_Description_Prodtype MainInfo;
        public Journal_Spolning_PTFE Journal;
    }
}
