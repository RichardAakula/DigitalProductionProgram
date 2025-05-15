
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class MonitorUsers
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
            this.components = new System.ComponentModel.Container();
            this.flp_List = new DoubleBufferedFlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flp_List
            // 
            this.flp_List.AutoScroll = true;
            this.flp_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_List.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_List.Location = new System.Drawing.Point(0, 0);
            this.flp_List.Margin = new System.Windows.Forms.Padding(0);
            this.flp_List.Name = "flp_List";
            this.flp_List.Size = new System.Drawing.Size(386, 600);
            this.flp_List.TabIndex = 0;
            this.flp_List.WrapContents = false;
            // 
            // MonitorUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.flp_List);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MonitorUsers";
            this.Size = new System.Drawing.Size(386, 600);
            this.ResumeLayout(false);

        }

        #endregion
        //private FlowLayoutPanel flp_List;
        public System.Windows.Forms.Timer timer_Update;
    }
}
