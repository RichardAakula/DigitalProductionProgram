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
            flp_Main = new FlowLayoutPanel();
            label_Header_ActiveOrders = new Label();
            flp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // flp_Main
            // 
            flp_Main.BackColor = Color.Transparent;
            flp_Main.Controls.Add(label_Header_ActiveOrders);
            flp_Main.Dock = DockStyle.Fill;
            flp_Main.FlowDirection = FlowDirection.TopDown;
            flp_Main.Location = new Point(0, 0);
            flp_Main.Margin = new Padding(0);
            flp_Main.Name = "flp_Main";
            flp_Main.Size = new Size(300, 239);
            flp_Main.TabIndex = 0;
            // 
            // label_Header_ActiveOrders
            // 
            label_Header_ActiveOrders.BackColor = Color.Transparent;
            label_Header_ActiveOrders.Font = new Font("Palatino Linotype", 14.25F);
            label_Header_ActiveOrders.ForeColor = Color.Moccasin;
            label_Header_ActiveOrders.Location = new Point(0, 0);
            label_Header_ActiveOrders.Margin = new Padding(0);
            label_Header_ActiveOrders.Name = "label_Header_ActiveOrders";
            label_Header_ActiveOrders.Size = new Size(261, 30);
            label_Header_ActiveOrders.TabIndex = 1;
            label_Header_ActiveOrders.Text = "Dina aktiva Ordrar";
            label_Header_ActiveOrders.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ActiveOrdersUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(60, 60, 60);
            Controls.Add(flp_Main);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ActiveOrdersUser";
            Size = new Size(300, 239);
            flp_Main.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flp_Main;
        public Label label_Header_ActiveOrders;
    }
}
