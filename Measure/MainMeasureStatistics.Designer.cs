
using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Measure
{
    partial class MainMeasureStatistics
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
            this.label_MeasureInformation = new System.Windows.Forms.Label();
            this.flp_Codenames = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_Max = new System.Windows.Forms.FlowLayoutPanel();
            this.flp_Min = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.label_Max = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.label_Average = new System.Windows.Forms.Label();
            this.flp_Average = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_MeasureInformation
            // 
            this.label_MeasureInformation.BackColor = System.Drawing.Color.Transparent;
            this.label_MeasureInformation.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label_MeasureInformation.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_MeasureInformation.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.label_MeasureInformation.ForeColor = System.Drawing.Color.Moccasin;
            this.label_MeasureInformation.Location = new System.Drawing.Point(0, 0);
            this.label_MeasureInformation.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label_MeasureInformation.Name = "label_MeasureInformation";
            this.label_MeasureInformation.Size = new System.Drawing.Size(349, 30);
            this.label_MeasureInformation.TabIndex = 870;
            this.label_MeasureInformation.Text = "Mätinformation:";
            this.label_MeasureInformation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_MeasureInformation.Click += new System.EventHandler(this.ShowStats_Click);
            // 
            // flp_Codenames
            // 
            this.flp_Codenames.BackColor = System.Drawing.Color.Transparent;
            this.flp_Codenames.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Codenames.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Codenames.Location = new System.Drawing.Point(0, 25);
            this.flp_Codenames.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Codenames.Name = "flp_Codenames";
            this.flp_Codenames.Size = new System.Drawing.Size(140, 90);
            this.flp_Codenames.TabIndex = 871;
            // 
            // flp_Max
            // 
            this.flp_Max.BackColor = System.Drawing.Color.Transparent;
            this.flp_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Max.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Max.Location = new System.Drawing.Point(278, 25);
            this.flp_Max.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Max.Name = "flp_Max";
            this.flp_Max.Size = new System.Drawing.Size(71, 90);
            this.flp_Max.TabIndex = 872;
            // 
            // flp_Min
            // 
            this.flp_Min.BackColor = System.Drawing.Color.Transparent;
            this.flp_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Min.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Min.Location = new System.Drawing.Point(209, 25);
            this.flp_Min.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Min.Name = "flp_Min";
            this.flp_Min.Size = new System.Drawing.Size(69, 90);
            this.flp_Min.TabIndex = 873;
            // 
            // tlp_Main
            // 
            this.tlp_Main.BackColor = System.Drawing.Color.Transparent;
            this.tlp_Main.ColumnCount = 4;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlp_Main.Controls.Add(this.label_Max, 3, 0);
            this.tlp_Main.Controls.Add(this.label_Min, 2, 0);
            this.tlp_Main.Controls.Add(this.label_Average, 1, 0);
            this.tlp_Main.Controls.Add(this.flp_Average, 1, 1);
            this.tlp_Main.Controls.Add(this.flp_Codenames, 0, 1);
            this.tlp_Main.Controls.Add(this.flp_Min, 2, 1);
            this.tlp_Main.Controls.Add(this.flp_Max, 3, 1);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 30);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 2;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Main.Size = new System.Drawing.Size(349, 115);
            this.tlp_Main.TabIndex = 873;
            // 
            // label_Max
            // 
            this.label_Max.AutoSize = true;
            this.label_Max.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Max.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Max.ForeColor = System.Drawing.Color.Moccasin;
            this.label_Max.Location = new System.Drawing.Point(281, 0);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(65, 25);
            this.label_Max.TabIndex = 2;
            this.label_Max.Text = "MAX:";
            this.label_Max.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Min
            // 
            this.label_Min.AutoSize = true;
            this.label_Min.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Min.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Min.ForeColor = System.Drawing.Color.Moccasin;
            this.label_Min.Location = new System.Drawing.Point(212, 0);
            this.label_Min.Name = "label_Min";
            this.label_Min.Size = new System.Drawing.Size(63, 25);
            this.label_Min.TabIndex = 1;
            this.label_Min.Text = "MIN:";
            this.label_Min.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Average
            // 
            this.label_Average.AutoSize = true;
            this.label_Average.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Average.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Average.ForeColor = System.Drawing.Color.Moccasin;
            this.label_Average.Location = new System.Drawing.Point(143, 0);
            this.label_Average.Name = "label_Average";
            this.label_Average.Size = new System.Drawing.Size(63, 25);
            this.label_Average.TabIndex = 0;
            this.label_Average.Text = "AVG:";
            this.label_Average.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flp_Average
            // 
            this.flp_Average.BackColor = System.Drawing.Color.Transparent;
            this.flp_Average.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_Average.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_Average.Location = new System.Drawing.Point(140, 25);
            this.flp_Average.Margin = new System.Windows.Forms.Padding(0);
            this.flp_Average.Name = "flp_Average";
            this.flp_Average.Size = new System.Drawing.Size(69, 90);
            this.flp_Average.TabIndex = 874;
            // 
            // MainMeasureStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.label_MeasureInformation);
            this.Name = "MainMeasureStatistics";
            this.Size = new System.Drawing.Size(349, 145);
            this.tlp_Main.ResumeLayout(false);
            this.tlp_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Label label_MeasureInformation;
        private FlowLayoutPanel flp_Codenames;
        private FlowLayoutPanel flp_Max;
        private FlowLayoutPanel flp_Min;
        private TableLayoutPanel tlp_Main;
        private FlowLayoutPanel flp_Average;
        private Label label_Max;
        private Label label_Min;
        private Label label_Average;
    }
}
