using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Protocols.MainInfo;

namespace DigitalProductionProgram.Protocols.Blandning_PTFE
{
    partial class MainProtocol_Blandning_PTFE
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
            this.panel_Info = new System.Windows.Forms.Panel();
            this.label_Info_2 = new System.Windows.Forms.Label();
            this.label_Info_1 = new System.Windows.Forms.Label();
            this.Journal = new Journal_Blandning_PTFE();
            this.MainInfo = new MainInfo_A();
            this.tlp_Main.SuspendLayout();
            this.panel_Info.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Controls.Add(this.Journal, 0, 1);
            this.tlp_Main.Controls.Add(this.panel_Info, 0, 2);
            this.tlp_Main.Controls.Add(this.MainInfo, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(934, 723);
            this.tlp_Main.TabIndex = 2;
            // 
            // panel_Info
            // 
            this.panel_Info.BackColor = System.Drawing.Color.White;
            this.panel_Info.Controls.Add(this.label_Info_2);
            this.panel_Info.Controls.Add(this.label_Info_1);
            this.panel_Info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Info.Location = new System.Drawing.Point(1, 673);
            this.panel_Info.Margin = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.panel_Info.Name = "panel_Info";
            this.panel_Info.Size = new System.Drawing.Size(932, 49);
            this.panel_Info.TabIndex = 2;
            // 
            // label_Info_2
            // 
            this.label_Info_2.Location = new System.Drawing.Point(88, 4);
            this.label_Info_2.Name = "label_Info_2";
            this.label_Info_2.Size = new System.Drawing.Size(257, 39);
            this.label_Info_2.TabIndex = 0;
            this.label_Info_2.Text = "1 = BRA\r\n2 = KORNIGT, LITE KLUMPAR, RENT\r\n3 = FÖRORENAT, SAMMANPRESSAT\r\n";
            // 
            // label_Info_1
            // 
            this.label_Info_1.AutoSize = true;
            this.label_Info_1.Location = new System.Drawing.Point(24, 4);
            this.label_Info_1.Name = "label_Info_1";
            this.label_Info_1.Size = new System.Drawing.Size(59, 13);
            this.label_Info_1.TabIndex = 0;
            this.label_Info_1.Text = "A) Tillstånd";
            // 
            // Journal
            // 
            this.Journal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Journal.Location = new System.Drawing.Point(1, 41);
            this.Journal.Margin = new System.Windows.Forms.Padding(1);
            this.Journal.Name = "Journal";
            this.Journal.Size = new System.Drawing.Size(932, 631);
            this.Journal.TabIndex = 1;
            // 
            // MainInfo
            // 
            this.MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfo.Location = new System.Drawing.Point(1, 1);
            this.MainInfo.Margin = new System.Windows.Forms.Padding(1);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(932, 38);
            this.MainInfo.TabIndex = 3;
            // 
            // MainProtocol_Blandning_PTFE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainProtocol_Blandning_PTFE";
            this.Size = new System.Drawing.Size(934, 723);
            this.tlp_Main.ResumeLayout(false);
            this.panel_Info.ResumeLayout(false);
            this.panel_Info.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        private Panel panel_Info;
        private Label label_Info_2;
        private Label label_Info_1;
        public Journal_Blandning_PTFE Journal;
        public MainInfo_A MainInfo;
    }
}
