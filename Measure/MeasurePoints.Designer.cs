using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class MeasurePoints
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
            tlp_Main = new TableLayoutPanel();
            flp_CodeName = new FlowLayoutPanel();
            label_USL = new Label();
            label_Nom = new Label();
            label_LSL = new Label();
            label_LCL = new Label();
            label_UCL = new Label();
            flp_LSL = new FlowLayoutPanel();
            flp_LCL = new FlowLayoutPanel();
            flp_NOM = new FlowLayoutPanel();
            flp_UCL = new FlowLayoutPanel();
            flp_USL = new FlowLayoutPanel();
            label_Measurepoints = new Label();
            tlp_Main.SuspendLayout();
            SuspendLayout();
            // 
            // tlp_Main
            // 
            tlp_Main.BackColor = Color.Transparent;
            tlp_Main.ColumnCount = 6;
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 187F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_Main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlp_Main.Controls.Add(flp_CodeName, 0, 1);
            tlp_Main.Controls.Add(label_USL, 5, 0);
            tlp_Main.Controls.Add(label_Nom, 3, 0);
            tlp_Main.Controls.Add(label_LSL, 1, 0);
            tlp_Main.Controls.Add(label_LCL, 2, 0);
            tlp_Main.Controls.Add(label_UCL, 4, 0);
            tlp_Main.Controls.Add(flp_LSL, 1, 1);
            tlp_Main.Controls.Add(flp_LCL, 2, 1);
            tlp_Main.Controls.Add(flp_NOM, 3, 1);
            tlp_Main.Controls.Add(flp_UCL, 4, 1);
            tlp_Main.Controls.Add(flp_USL, 5, 1);
            tlp_Main.Dock = DockStyle.Fill;
            tlp_Main.Location = new Point(0, 35);
            tlp_Main.Margin = new Padding(0, 6, 4, 0);
            tlp_Main.Name = "tlp_Main";
            tlp_Main.RowCount = 2;
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Main.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tlp_Main.Size = new Size(537, 155);
            tlp_Main.TabIndex = 904;
            // 
            // flp_CodeName
            // 
            flp_CodeName.BackColor = Color.Transparent;
            flp_CodeName.Dock = DockStyle.Fill;
            flp_CodeName.FlowDirection = FlowDirection.TopDown;
            flp_CodeName.Location = new Point(0, 23);
            flp_CodeName.Margin = new Padding(0);
            flp_CodeName.Name = "flp_CodeName";
            flp_CodeName.Size = new Size(187, 132);
            flp_CodeName.TabIndex = 872;
            // 
            // label_USL
            // 
            label_USL.AutoSize = true;
            label_USL.BackColor = Color.FromArgb(255, 199, 206);
            label_USL.Dock = DockStyle.Fill;
            label_USL.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label_USL.ForeColor = Color.FromArgb(156, 0, 6);
            label_USL.Location = new Point(475, 0);
            label_USL.Margin = new Padding(8, 0, 8, 0);
            label_USL.Name = "label_USL";
            label_USL.Size = new Size(54, 23);
            label_USL.TabIndex = 18;
            label_USL.Text = "USL:";
            label_USL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_Nom
            // 
            label_Nom.AutoSize = true;
            label_Nom.BackColor = Color.FromArgb(198, 239, 206);
            label_Nom.Dock = DockStyle.Fill;
            label_Nom.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label_Nom.ForeColor = Color.FromArgb(0, 97, 0);
            label_Nom.Location = new Point(335, 0);
            label_Nom.Margin = new Padding(8, 0, 8, 0);
            label_Nom.Name = "label_Nom";
            label_Nom.Size = new Size(54, 23);
            label_Nom.TabIndex = 16;
            label_Nom.Text = "NOM:";
            label_Nom.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_LSL
            // 
            label_LSL.AutoSize = true;
            label_LSL.BackColor = Color.FromArgb(255, 199, 206);
            label_LSL.Dock = DockStyle.Fill;
            label_LSL.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label_LSL.ForeColor = Color.FromArgb(156, 0, 6);
            label_LSL.Location = new Point(195, 0);
            label_LSL.Margin = new Padding(8, 0, 8, 0);
            label_LSL.Name = "label_LSL";
            label_LSL.Size = new Size(54, 23);
            label_LSL.TabIndex = 17;
            label_LSL.Text = "LSL:";
            label_LSL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_LCL
            // 
            label_LCL.AutoSize = true;
            label_LCL.BackColor = Color.FromArgb(255, 235, 156);
            label_LCL.Dock = DockStyle.Fill;
            label_LCL.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label_LCL.ForeColor = Color.FromArgb(156, 101, 0);
            label_LCL.Location = new Point(265, 0);
            label_LCL.Margin = new Padding(8, 0, 8, 0);
            label_LCL.Name = "label_LCL";
            label_LCL.Size = new Size(54, 23);
            label_LCL.TabIndex = 17;
            label_LCL.Text = "LCL:";
            label_LCL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label_UCL
            // 
            label_UCL.AutoSize = true;
            label_UCL.BackColor = Color.FromArgb(255, 235, 156);
            label_UCL.Dock = DockStyle.Fill;
            label_UCL.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            label_UCL.ForeColor = Color.FromArgb(156, 101, 0);
            label_UCL.Location = new Point(405, 0);
            label_UCL.Margin = new Padding(8, 0, 8, 0);
            label_UCL.Name = "label_UCL";
            label_UCL.Size = new Size(54, 23);
            label_UCL.TabIndex = 18;
            label_UCL.Text = "UCL:";
            label_UCL.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flp_LSL
            // 
            flp_LSL.BackColor = Color.Transparent;
            flp_LSL.Dock = DockStyle.Fill;
            flp_LSL.FlowDirection = FlowDirection.TopDown;
            flp_LSL.Location = new Point(187, 23);
            flp_LSL.Margin = new Padding(0);
            flp_LSL.Name = "flp_LSL";
            flp_LSL.Size = new Size(70, 132);
            flp_LSL.TabIndex = 872;
            // 
            // flp_LCL
            // 
            flp_LCL.BackColor = Color.Transparent;
            flp_LCL.Dock = DockStyle.Fill;
            flp_LCL.FlowDirection = FlowDirection.TopDown;
            flp_LCL.Location = new Point(257, 23);
            flp_LCL.Margin = new Padding(0);
            flp_LCL.Name = "flp_LCL";
            flp_LCL.Size = new Size(70, 132);
            flp_LCL.TabIndex = 872;
            // 
            // flp_NOM
            // 
            flp_NOM.BackColor = Color.Transparent;
            flp_NOM.Dock = DockStyle.Fill;
            flp_NOM.FlowDirection = FlowDirection.TopDown;
            flp_NOM.Location = new Point(327, 23);
            flp_NOM.Margin = new Padding(0);
            flp_NOM.Name = "flp_NOM";
            flp_NOM.Size = new Size(70, 132);
            flp_NOM.TabIndex = 872;
            // 
            // flp_UCL
            // 
            flp_UCL.BackColor = Color.Transparent;
            flp_UCL.Dock = DockStyle.Fill;
            flp_UCL.FlowDirection = FlowDirection.TopDown;
            flp_UCL.Location = new Point(397, 23);
            flp_UCL.Margin = new Padding(0);
            flp_UCL.Name = "flp_UCL";
            flp_UCL.Size = new Size(70, 132);
            flp_UCL.TabIndex = 872;
            // 
            // flp_USL
            // 
            flp_USL.BackColor = Color.Transparent;
            flp_USL.Dock = DockStyle.Fill;
            flp_USL.FlowDirection = FlowDirection.TopDown;
            flp_USL.Location = new Point(467, 23);
            flp_USL.Margin = new Padding(0);
            flp_USL.Name = "flp_USL";
            flp_USL.Size = new Size(70, 132);
            flp_USL.TabIndex = 872;
            // 
            // label_Measurepoints
            // 
            label_Measurepoints.BackColor = Color.Transparent;
            label_Measurepoints.Dock = DockStyle.Top;
            label_Measurepoints.Font = new Font("Palatino Linotype", 12F, FontStyle.Bold);
            label_Measurepoints.ForeColor = Color.Moccasin;
            label_Measurepoints.Location = new Point(0, 0);
            label_Measurepoints.Margin = new Padding(4, 0, 4, 0);
            label_Measurepoints.Name = "label_Measurepoints";
            label_Measurepoints.Size = new Size(537, 35);
            label_Measurepoints.TabIndex = 869;
            label_Measurepoints.Text = "Mätpunkter:";
            label_Measurepoints.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MeasurePoints
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            Controls.Add(tlp_Main);
            Controls.Add(label_Measurepoints);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MeasurePoints";
            Size = new Size(537, 190);
            tlp_Main.ResumeLayout(false);
            tlp_Main.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        public TableLayoutPanel tlp_Main;
        private Label label_Nom;
        private Label label_LSL;
        private Label label_USL;
        public Label label_Measurepoints;
        private Label label_LCL;
        private Label label_UCL;
        private FlowLayoutPanel flp_CodeName;
        private FlowLayoutPanel flp_LSL;
        private FlowLayoutPanel flp_LCL;
        private FlowLayoutPanel flp_NOM;
        private FlowLayoutPanel flp_UCL;
        private FlowLayoutPanel flp_USL;
    }
}
