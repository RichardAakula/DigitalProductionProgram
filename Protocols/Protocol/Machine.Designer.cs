namespace DigitalProductionProgram.Protocols.Protocol
{
    partial class Machine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlp_Machine = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // tlp_Machine
            // 
            this.tlp_Machine.AutoScroll = true;
            this.tlp_Machine.BackColor = System.Drawing.Color.Black;
            this.tlp_Machine.ColumnCount = 1;
            this.tlp_Machine.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Machine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Machine.Location = new System.Drawing.Point(0, 0);
            this.tlp_Machine.Name = "tlp_Machine";
            this.tlp_Machine.RowCount = 1;
            this.tlp_Machine.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 724F));
            this.tlp_Machine.Size = new System.Drawing.Size(629, 724);
            this.tlp_Machine.TabIndex = 0;
            // 
            // Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tlp_Machine);
            this.Name = "Machine";
            this.Size = new System.Drawing.Size(629, 724);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlp_Machine;
    }
}
