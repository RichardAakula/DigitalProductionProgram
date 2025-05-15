using System.ComponentModel;
using System.Windows.Forms;
using DigitalProductionProgram.Protocols.MainInfo;

namespace DigitalProductionProgram.Protocols.Slipning_TEF
{
    partial class MainProtocol_Slipning_TEF
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
            this.Maskinparametrar = new Maskinparametrar_Slipning_TEF();
            this.MainInfo = new MainInfo_Description_Prodtype();
            this.Produktion = new Produktion_Slipning_TEF();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Black;
            this.tlp_Main.ColumnCount = 1;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 766F));
            this.tlp_Main.Controls.Add(this.Maskinparametrar, 0, 1);
            this.tlp_Main.Controls.Add(this.MainInfo, 0, 0);
            this.tlp_Main.Controls.Add(this.Produktion, 0, 2);
            this.tlp_Main.Cursor = System.Windows.Forms.Cursors.Default;
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 0);
            this.tlp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 3;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 248F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlp_Main.Size = new System.Drawing.Size(862, 679);
            this.tlp_Main.TabIndex = 1;
            // 
            // Maskinparametrar
            // 
            this.Maskinparametrar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Maskinparametrar.Location = new System.Drawing.Point(0, 46);
            this.Maskinparametrar.Margin = new System.Windows.Forms.Padding(0);
            this.Maskinparametrar.Name = "Maskinparametrar";
            this.Maskinparametrar.Size = new System.Drawing.Size(862, 248);
            this.Maskinparametrar.TabIndex = 1027;
            // 
            // MainInfo
            // 
            this.MainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainInfo.Location = new System.Drawing.Point(0, 0);
            this.MainInfo.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.MainInfo.Name = "MainInfo";
            this.MainInfo.Size = new System.Drawing.Size(862, 45);
            this.MainInfo.TabIndex = 1028;
            // 
            // Produktion
            // 
            this.Produktion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Produktion.Location = new System.Drawing.Point(0, 294);
            this.Produktion.Margin = new System.Windows.Forms.Padding(0);
            this.Produktion.Name = "Produktion";
            this.Produktion.Size = new System.Drawing.Size(862, 385);
            this.Produktion.TabIndex = 1029;
            // 
            // MainProtocol_Slipning_TEF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlp_Main);
            this.Name = "MainProtocol_Slipning_TEF";
            this.Size = new System.Drawing.Size(862, 679);
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tlp_Main;
        public Maskinparametrar_Slipning_TEF Maskinparametrar;
        public MainInfo_Description_Prodtype MainInfo;
        public Produktion_Slipning_TEF Produktion;
    }
}
