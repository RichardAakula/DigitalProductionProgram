using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.OrderManagement
{
    partial class Manage_WorkOperation
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_ChooseWorkOperation = new Label();
            cb_Workoperations = new ComboBox();
            btn_Workoperation_Choose = new Button();
            btn_Workoperation_Abort = new Button();
            SuspendLayout();
            // 
            // label_ChooseWorkOperation
            // 
            label_ChooseWorkOperation.Dock = DockStyle.Top;
            label_ChooseWorkOperation.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_ChooseWorkOperation.ForeColor = SystemColors.Info;
            label_ChooseWorkOperation.Location = new Point(0, 0);
            label_ChooseWorkOperation.Margin = new Padding(4, 0, 4, 0);
            label_ChooseWorkOperation.Name = "label_ChooseWorkOperation";
            label_ChooseWorkOperation.Size = new Size(467, 35);
            label_ChooseWorkOperation.TabIndex = 0;
            label_ChooseWorkOperation.Text = "Välj Arbetsoperation";
            label_ChooseWorkOperation.TextAlign = ContentAlignment.TopCenter;
            // 
            // cb_Workoperations
            // 
            cb_Workoperations.FormattingEnabled = true;
            cb_Workoperations.Location = new Point(102, 51);
            cb_Workoperations.Margin = new Padding(4, 3, 4, 3);
            cb_Workoperations.Name = "cb_Workoperations";
            cb_Workoperations.Size = new Size(258, 23);
            cb_Workoperations.TabIndex = 1;
            // 
            // btn_Workoperation_Choose
            // 
            btn_Workoperation_Choose.FlatStyle = FlatStyle.Flat;
            btn_Workoperation_Choose.ForeColor = Color.White;
            btn_Workoperation_Choose.Location = new Point(102, 99);
            btn_Workoperation_Choose.Margin = new Padding(4, 3, 4, 3);
            btn_Workoperation_Choose.Name = "btn_Workoperation_Choose";
            btn_Workoperation_Choose.Size = new Size(88, 27);
            btn_Workoperation_Choose.TabIndex = 2;
            btn_Workoperation_Choose.Text = "Välj";
            btn_Workoperation_Choose.UseVisualStyleBackColor = true;
            btn_Workoperation_Choose.Click += Choose_Click;
            // 
            // btn_Workoperation_Abort
            // 
            btn_Workoperation_Abort.FlatStyle = FlatStyle.Flat;
            btn_Workoperation_Abort.ForeColor = Color.White;
            btn_Workoperation_Abort.Location = new Point(273, 99);
            btn_Workoperation_Abort.Margin = new Padding(4, 3, 4, 3);
            btn_Workoperation_Abort.Name = "btn_Workoperation_Abort";
            btn_Workoperation_Abort.Size = new Size(88, 27);
            btn_Workoperation_Abort.TabIndex = 2;
            btn_Workoperation_Abort.Text = "Avbryt";
            btn_Workoperation_Abort.UseVisualStyleBackColor = true;
            btn_Workoperation_Abort.Click += Abort_Click;
            // 
            // Manage_WorkOperation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(25, 25, 25);
            ClientSize = new Size(467, 140);
            Controls.Add(btn_Workoperation_Abort);
            Controls.Add(btn_Workoperation_Choose);
            Controls.Add(cb_Workoperations);
            Controls.Add(label_ChooseWorkOperation);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "Manage_WorkOperation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Arbetsoperation";
            ResumeLayout(false);

        }

        #endregion

        private Label label_ChooseWorkOperation;
        private ComboBox cb_Workoperations;
        private Button btn_Workoperation_Choose;
        private Button btn_Workoperation_Abort;
    }
}