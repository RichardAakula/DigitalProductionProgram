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
            tlp_Machine = new TableLayoutPanel();
            SuspendLayout();
            // 
            // tlp_Machine
            // 
            tlp_Machine.AutoScroll = true;
            tlp_Machine.AutoSize = true;
            tlp_Machine.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlp_Machine.BackColor = Color.FromArgb(65, 65, 65);
            tlp_Machine.ColumnCount = 1;
            tlp_Machine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_Machine.Dock = DockStyle.Top;
            tlp_Machine.Location = new Point(0, 0);
            tlp_Machine.Margin = new Padding(4, 3, 4, 3);
            tlp_Machine.Name = "tlp_Machine";
            tlp_Machine.RowCount = 1;
            tlp_Machine.RowStyles.Add(new RowStyle(SizeType.Absolute, 835F));
            tlp_Machine.Size = new Size(734, 835);
            tlp_Machine.TabIndex = 0;
            // 
            // Machine
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.Black;
            Controls.Add(tlp_Machine);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Machine";
            Size = new Size(734, 835);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel tlp_Machine;
    }
}
