namespace DigitalProductionProgram.Help
{
    partial class Manual_TemplatesProtocol
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            web_PDF_Viewer = new WebBrowser();
            SuspendLayout();
            // 
            // web_PDF_Viewer
            // 
            web_PDF_Viewer.Dock = DockStyle.Fill;
            web_PDF_Viewer.Location = new Point(0, 0);
            web_PDF_Viewer.Margin = new Padding(4, 3, 4, 3);
            web_PDF_Viewer.MinimumSize = new Size(23, 23);
            web_PDF_Viewer.Name = "web_PDF_Viewer";
            web_PDF_Viewer.Size = new Size(1078, 1228);
            web_PDF_Viewer.TabIndex = 17;
            // 
            // Manual_TemplatesProtocol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1078, 1228);
            Controls.Add(web_PDF_Viewer);
            Name = "Manual_TemplatesProtocol";
            Text = "Manual_TemplatesProtocol";
            ResumeLayout(false);
        }

        #endregion

        private WebBrowser web_PDF_Viewer;
    }
}