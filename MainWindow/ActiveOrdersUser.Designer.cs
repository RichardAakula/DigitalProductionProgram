using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.MainWindow
{
    partial class ActiveOrdersUser
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
            this.flp_Main = new System.Windows.Forms.FlowLayoutPanel();
            this.label_Header_ActiveOrders = new System.Windows.Forms.Label();
            this.flp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // flp_Main
            // 
            this.flp_Main.BackColor = System.Drawing.Color.Transparent;
            this.flp_Main.Controls.Add(this.label_Header_ActiveOrders);
            this.flp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Main.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Main.Location = new System.Drawing.Point(0, 0);
            this.flp_Main.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Main.Name = "flp_Main";
            this.flp_Main.Size = new System.Drawing.Size(224, 207);
            this.flp_Main.TabIndex = 0;
            // 
            // label_Header_ActiveOrders
            // 
            this.label_Header_ActiveOrders.BackColor = System.Drawing.Color.Transparent;
            this.label_Header_ActiveOrders.Font = new System.Drawing.Font("Palatino Linotype", 14.25F);
            this.label_Header_ActiveOrders.ForeColor = System.Drawing.Color.Moccasin;
            this.label_Header_ActiveOrders.Location = new System.Drawing.Point(0, 0);
            this.label_Header_ActiveOrders.Margin = new System.Windows.Forms.Padding(0);
            this.label_Header_ActiveOrders.Name = "label_Header_ActiveOrders";
            this.label_Header_ActiveOrders.Size = new System.Drawing.Size(224, 26);
            this.label_Header_ActiveOrders.TabIndex = 1;
            this.label_Header_ActiveOrders.Text = "Dina aktiva Ordrar";
            this.label_Header_ActiveOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ActiveOrdersUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.Controls.Add(this.flp_Main);
            this.Name = "ActiveOrdersUser";
            this.Size = new System.Drawing.Size(224, 207);
            this.flp_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_Main;
        public Label label_Header_ActiveOrders;
    }
}
