using System.ComponentModel;
using System.Windows.Forms;

namespace DigitalProductionProgram.Templates
{
    partial class Templates_MeasureProtocol
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
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Templates_MeasureProtocol));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgv_Parameters = new DataGridView();
            cb_TemplateName = new ComboBox();
            btn_SaveTemplate = new Button();
            label_Measureprotocol_Revision = new Label();
            cb_Revision = new ComboBox();
            btn_DeleteTemplate = new Button();
            btn_MoveTaskUp = new PictureBox();
            btn_MoveTaskDown = new PictureBox();
            btn_DeleteTask = new PictureBox();
            label_Buttons_Parameter = new Label();
            btn_NewRevision = new Button();
            toolTip = new ToolTip(components);
            tb_AddNewParameter = new TextBox();
            btn_AddParameter = new Button();
            gbx_MeasureParameters = new GroupBox();
            gbox_MeasureProtocolTemplate = new GroupBox();
            chb_IsUsingCutterTakeUpUnit = new CheckBox();
            chb_ExtraInputBoxes_Second_Measurement = new CheckBox();
            chb_ExtraInputBoxes_2Layer = new CheckBox();
            chb_ExtraInputBoxes = new CheckBox();
            chb_EditAmount = new CheckBox();
            cb_Monitor_MeasuringTemplate = new ComboBox();
            cb_Workoperation = new ComboBox();
            label_Workoperation = new Label();
            label1 = new Label();
            label_TemplateName = new Label();
            tlp_Top = new TableLayoutPanel();
            btn_ConnectPartNr_NewTemplate = new Button();
            tlp_ExtraInfo = new TableLayoutPanel();
            label_TotalConnectedOrders = new Label();
            lbl_CreatedDate = new Label();
            lbl_CreatedBy = new Label();
            label_CreatedDate = new Label();
            label_CreatedBy = new Label();
            label_TotalConnectedProcesscards = new Label();
            tlp_Bottom = new TableLayoutPanel();
            web_PDF_Viewer = new WebBrowser();
            flp_ObjectManagement = new FlowLayoutPanel();
            dgv_Template = new DataGridView();
            col_DescriptionID = new DataGridViewTextBoxColumn();
            col_Parameter = new DataGridViewTextBoxColumn();
            col_ParameterMonitor = new DataGridViewComboBoxColumn();
            col_Items = new DataGridViewCheckBoxColumn();
            col_IsMandatory = new DataGridViewCheckBoxColumn();
            col_DataType = new DataGridViewComboBoxColumn();
            col_ControlType = new DataGridViewComboBoxColumn();
            col_Increment = new DataGridViewTextBoxColumn();
            col_Decimals = new DataGridViewTextBoxColumn();
            col_Formula = new DataGridViewTextBoxColumn();
            col_Width = new DataGridViewTextBoxColumn();
            col_MaxChars = new DataGridViewTextBoxColumn();
            ((ISupportInitialize)dgv_Parameters).BeginInit();
            ((ISupportInitialize)btn_MoveTaskUp).BeginInit();
            ((ISupportInitialize)btn_MoveTaskDown).BeginInit();
            ((ISupportInitialize)btn_DeleteTask).BeginInit();
            gbx_MeasureParameters.SuspendLayout();
            gbox_MeasureProtocolTemplate.SuspendLayout();
            tlp_Top.SuspendLayout();
            tlp_ExtraInfo.SuspendLayout();
            tlp_Bottom.SuspendLayout();
            flp_ObjectManagement.SuspendLayout();
            ((ISupportInitialize)dgv_Template).BeginInit();
            SuspendLayout();
            // 
            // dgv_Parameters
            // 
            dgv_Parameters.AllowUserToAddRows = false;
            dgv_Parameters.AllowUserToDeleteRows = false;
            dgv_Parameters.AllowUserToResizeColumns = false;
            dgv_Parameters.AllowUserToResizeRows = false;
            dgv_Parameters.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgv_Parameters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_Parameters.BackgroundColor = Color.FromArgb(81, 85, 92);
            dgv_Parameters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Parameters.Location = new Point(4, 411);
            dgv_Parameters.Margin = new Padding(4, 3, 4, 3);
            dgv_Parameters.MultiSelect = false;
            dgv_Parameters.Name = "dgv_Parameters";
            dgv_Parameters.ReadOnly = true;
            dgv_Parameters.RowHeadersVisible = false;
            dgv_Parameters.Size = new Size(315, 707);
            dgv_Parameters.TabIndex = 2;
            dgv_Parameters.CellMouseDown += Parameters_CellMouseDown;
            dgv_Parameters.KeyPress += CodeText_KeyPress;
            // 
            // cb_TemplateName
            // 
            cb_TemplateName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cb_TemplateName.Font = new Font("Lucida Sans", 11.25F);
            cb_TemplateName.FormattingEnabled = true;
            cb_TemplateName.Location = new Point(7, 54);
            cb_TemplateName.Margin = new Padding(4, 3, 4, 3);
            cb_TemplateName.Name = "cb_TemplateName";
            cb_TemplateName.Size = new Size(372, 25);
            cb_TemplateName.TabIndex = 4;
            cb_TemplateName.SelectedIndexChanged += Template_Name_SelectedIndexChanged;
            cb_TemplateName.TextChanged += TemplateName_TextChanged;
            // 
            // btn_SaveTemplate
            // 
            btn_SaveTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_SaveTemplate.Cursor = Cursors.Hand;
            btn_SaveTemplate.Dock = DockStyle.Fill;
            btn_SaveTemplate.FlatStyle = FlatStyle.Flat;
            btn_SaveTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_SaveTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_SaveTemplate.Location = new Point(4, 6);
            btn_SaveTemplate.Margin = new Padding(4, 0, 4, 0);
            btn_SaveTemplate.Name = "btn_SaveTemplate";
            btn_SaveTemplate.Size = new Size(176, 48);
            btn_SaveTemplate.TabIndex = 1;
            btn_SaveTemplate.Text = "Spara Mall";
            btn_SaveTemplate.UseVisualStyleBackColor = false;
            btn_SaveTemplate.Click += Save_Template_Click;
            // 
            // label_Measureprotocol_Revision
            // 
            label_Measureprotocol_Revision.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label_Measureprotocol_Revision.BackColor = Color.FromArgb(239, 228, 177);
            label_Measureprotocol_Revision.Font = new Font("Lucida Sans", 10.25F);
            label_Measureprotocol_Revision.ForeColor = Color.FromArgb(57, 108, 121);
            label_Measureprotocol_Revision.Location = new Point(1000, 25);
            label_Measureprotocol_Revision.Margin = new Padding(4, 0, 4, 0);
            label_Measureprotocol_Revision.Name = "label_Measureprotocol_Revision";
            label_Measureprotocol_Revision.Size = new Size(204, 25);
            label_Measureprotocol_Revision.TabIndex = 9;
            label_Measureprotocol_Revision.Text = "Mätprotokoll Revision";
            // 
            // cb_Revision
            // 
            cb_Revision.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cb_Revision.Font = new Font("Lucida Sans", 11.25F);
            cb_Revision.FormattingEnabled = true;
            cb_Revision.Location = new Point(1000, 54);
            cb_Revision.Margin = new Padding(4, 3, 4, 3);
            cb_Revision.Name = "cb_Revision";
            cb_Revision.Size = new Size(84, 25);
            cb_Revision.TabIndex = 14;
            cb_Revision.Text = "A";
            cb_Revision.SelectedIndexChanged += Template_RevisionNr_SelectedIndexChanged;
            cb_Revision.KeyPress += Revision_KeyPress;
            // 
            // btn_DeleteTemplate
            // 
            btn_DeleteTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_DeleteTemplate.Cursor = Cursors.Hand;
            btn_DeleteTemplate.Dock = DockStyle.Fill;
            btn_DeleteTemplate.FlatStyle = FlatStyle.Flat;
            btn_DeleteTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_DeleteTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_DeleteTemplate.Location = new Point(4, 54);
            btn_DeleteTemplate.Margin = new Padding(4, 0, 4, 3);
            btn_DeleteTemplate.Name = "btn_DeleteTemplate";
            btn_DeleteTemplate.Size = new Size(176, 46);
            btn_DeleteTemplate.TabIndex = 1;
            btn_DeleteTemplate.Text = "Radera Mall";
            btn_DeleteTemplate.UseVisualStyleBackColor = false;
            btn_DeleteTemplate.Click += Delete_Template_Click;
            // 
            // btn_MoveTaskUp
            // 
            btn_MoveTaskUp.Anchor = AnchorStyles.None;
            btn_MoveTaskUp.BackgroundImage = (Image)resources.GetObject("btn_MoveTaskUp.BackgroundImage");
            btn_MoveTaskUp.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MoveTaskUp.Cursor = Cursors.Hand;
            btn_MoveTaskUp.Location = new Point(32, 26);
            btn_MoveTaskUp.Margin = new Padding(4, 3, 4, 6);
            btn_MoveTaskUp.Name = "btn_MoveTaskUp";
            btn_MoveTaskUp.Size = new Size(30, 33);
            btn_MoveTaskUp.TabIndex = 3;
            btn_MoveTaskUp.TabStop = false;
            btn_MoveTaskUp.Click += MoveTaskUp_Click;
            // 
            // btn_MoveTaskDown
            // 
            btn_MoveTaskDown.Anchor = AnchorStyles.None;
            btn_MoveTaskDown.BackgroundImage = (Image)resources.GetObject("btn_MoveTaskDown.BackgroundImage");
            btn_MoveTaskDown.BackgroundImageLayout = ImageLayout.Stretch;
            btn_MoveTaskDown.Cursor = Cursors.Hand;
            btn_MoveTaskDown.Location = new Point(32, 68);
            btn_MoveTaskDown.Margin = new Padding(4, 3, 4, 6);
            btn_MoveTaskDown.Name = "btn_MoveTaskDown";
            btn_MoveTaskDown.Size = new Size(30, 33);
            btn_MoveTaskDown.TabIndex = 4;
            btn_MoveTaskDown.TabStop = false;
            btn_MoveTaskDown.Click += MoveTaskDown_Click;
            // 
            // btn_DeleteTask
            // 
            btn_DeleteTask.Anchor = AnchorStyles.None;
            btn_DeleteTask.BackgroundImage = (Image)resources.GetObject("btn_DeleteTask.BackgroundImage");
            btn_DeleteTask.BackgroundImageLayout = ImageLayout.Stretch;
            btn_DeleteTask.Cursor = Cursors.Hand;
            btn_DeleteTask.Location = new Point(23, 110);
            btn_DeleteTask.Margin = new Padding(4, 3, 4, 6);
            btn_DeleteTask.Name = "btn_DeleteTask";
            btn_DeleteTask.Size = new Size(48, 47);
            btn_DeleteTask.TabIndex = 1;
            btn_DeleteTask.TabStop = false;
            toolTip.SetToolTip(btn_DeleteTask, "Radera markerad rad");
            btn_DeleteTask.Click += DeleteTask_Click;
            // 
            // label_Buttons_Parameter
            // 
            label_Buttons_Parameter.Anchor = AnchorStyles.None;
            label_Buttons_Parameter.AutoSize = true;
            label_Buttons_Parameter.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            label_Buttons_Parameter.ForeColor = Color.FromArgb(255, 235, 156);
            label_Buttons_Parameter.Location = new Point(4, 0);
            label_Buttons_Parameter.Margin = new Padding(4, 0, 4, 6);
            label_Buttons_Parameter.Name = "label_Buttons_Parameter";
            label_Buttons_Parameter.Size = new Size(87, 17);
            label_Buttons_Parameter.TabIndex = 0;
            label_Buttons_Parameter.Text = "Parameter";
            // 
            // btn_NewRevision
            // 
            btn_NewRevision.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btn_NewRevision.BackColor = Color.FromArgb(185, 188, 189);
            btn_NewRevision.Cursor = Cursors.Hand;
            btn_NewRevision.FlatStyle = FlatStyle.Flat;
            btn_NewRevision.Font = new Font("Lucida Sans", 10.25F);
            btn_NewRevision.ForeColor = Color.FromArgb(63, 116, 140);
            btn_NewRevision.Location = new Point(1092, 54);
            btn_NewRevision.Margin = new Padding(4, 3, 4, 3);
            btn_NewRevision.Name = "btn_NewRevision";
            btn_NewRevision.Size = new Size(112, 29);
            btn_NewRevision.TabIndex = 1;
            btn_NewRevision.Text = "Ny Revision";
            toolTip.SetToolTip(btn_NewRevision, "Vänsterklicka för att stega upp en revision, högerklicka för att stega ner en revision.");
            btn_NewRevision.UseVisualStyleBackColor = false;
            btn_NewRevision.MouseDown += NewRevision_MouseDown;
            // 
            // tb_AddNewParameter
            // 
            tb_AddNewParameter.Font = new Font("Lucida Sans", 8.25F);
            tb_AddNewParameter.Location = new Point(7, 66);
            tb_AddNewParameter.Margin = new Padding(4, 3, 4, 3);
            tb_AddNewParameter.Name = "tb_AddNewParameter";
            tb_AddNewParameter.Size = new Size(174, 20);
            tb_AddNewParameter.TabIndex = 3;
            tb_AddNewParameter.TextChanged += AddNewParameter_TextChanged;
            // 
            // btn_AddParameter
            // 
            btn_AddParameter.BackColor = Color.FromArgb(185, 188, 189);
            btn_AddParameter.Cursor = Cursors.Hand;
            btn_AddParameter.FlatStyle = FlatStyle.Flat;
            btn_AddParameter.Font = new Font("Lucida Sans", 10.25F);
            btn_AddParameter.ForeColor = Color.FromArgb(63, 116, 140);
            btn_AddParameter.Location = new Point(7, 27);
            btn_AddParameter.Margin = new Padding(4, 3, 4, 3);
            btn_AddParameter.Name = "btn_AddParameter";
            btn_AddParameter.Size = new Size(175, 32);
            btn_AddParameter.TabIndex = 11;
            btn_AddParameter.Text = "Lägg till Parameter";
            btn_AddParameter.UseVisualStyleBackColor = false;
            // 
            // gbx_MeasureParameters
            // 
            gbx_MeasureParameters.Controls.Add(btn_AddParameter);
            gbx_MeasureParameters.Controls.Add(tb_AddNewParameter);
            gbx_MeasureParameters.Dock = DockStyle.Bottom;
            gbx_MeasureParameters.Font = new Font("Lucida Sans", 10.25F);
            gbx_MeasureParameters.ForeColor = Color.FromArgb(239, 228, 177);
            gbx_MeasureParameters.Location = new Point(4, 301);
            gbx_MeasureParameters.Margin = new Padding(4, 3, 4, 3);
            gbx_MeasureParameters.Name = "gbx_MeasureParameters";
            gbx_MeasureParameters.Padding = new Padding(4, 3, 4, 3);
            gbx_MeasureParameters.Size = new Size(315, 104);
            gbx_MeasureParameters.TabIndex = 21;
            gbx_MeasureParameters.TabStop = false;
            gbx_MeasureParameters.Text = "Mätparametrar";
            // 
            // gbox_MeasureProtocolTemplate
            // 
            gbox_MeasureProtocolTemplate.Controls.Add(chb_IsUsingCutterTakeUpUnit);
            gbox_MeasureProtocolTemplate.Controls.Add(chb_ExtraInputBoxes_Second_Measurement);
            gbox_MeasureProtocolTemplate.Controls.Add(chb_ExtraInputBoxes_2Layer);
            gbox_MeasureProtocolTemplate.Controls.Add(chb_ExtraInputBoxes);
            gbox_MeasureProtocolTemplate.Controls.Add(chb_EditAmount);
            gbox_MeasureProtocolTemplate.Controls.Add(cb_Monitor_MeasuringTemplate);
            gbox_MeasureProtocolTemplate.Controls.Add(cb_Workoperation);
            gbox_MeasureProtocolTemplate.Controls.Add(cb_TemplateName);
            gbox_MeasureProtocolTemplate.Controls.Add(btn_NewRevision);
            gbox_MeasureProtocolTemplate.Controls.Add(label_Workoperation);
            gbox_MeasureProtocolTemplate.Controls.Add(label1);
            gbox_MeasureProtocolTemplate.Controls.Add(label_TemplateName);
            gbox_MeasureProtocolTemplate.Controls.Add(label_Measureprotocol_Revision);
            gbox_MeasureProtocolTemplate.Controls.Add(cb_Revision);
            gbox_MeasureProtocolTemplate.Dock = DockStyle.Fill;
            gbox_MeasureProtocolTemplate.Font = new Font("Lucida Sans", 10.25F);
            gbox_MeasureProtocolTemplate.ForeColor = Color.FromArgb(239, 228, 177);
            gbox_MeasureProtocolTemplate.Location = new Point(444, 114);
            gbox_MeasureProtocolTemplate.Margin = new Padding(4, 3, 4, 3);
            gbox_MeasureProtocolTemplate.Name = "gbox_MeasureProtocolTemplate";
            gbox_MeasureProtocolTemplate.Padding = new Padding(4, 3, 4, 3);
            gbox_MeasureProtocolTemplate.Size = new Size(1211, 291);
            gbox_MeasureProtocolTemplate.TabIndex = 21;
            gbox_MeasureProtocolTemplate.TabStop = false;
            gbox_MeasureProtocolTemplate.Text = "Mätprotokoll Mall";
            // 
            // chb_IsUsingCutterTakeUpUnit
            // 
            chb_IsUsingCutterTakeUpUnit.AutoSize = true;
            chb_IsUsingCutterTakeUpUnit.Font = new Font("Lucida Sans", 10.25F);
            chb_IsUsingCutterTakeUpUnit.ForeColor = Color.FromArgb(187, 215, 228);
            chb_IsUsingCutterTakeUpUnit.Location = new Point(7, 242);
            chb_IsUsingCutterTakeUpUnit.Margin = new Padding(4, 3, 4, 3);
            chb_IsUsingCutterTakeUpUnit.Name = "chb_IsUsingCutterTakeUpUnit";
            chb_IsUsingCutterTakeUpUnit.Size = new Size(448, 20);
            chb_IsUsingCutterTakeUpUnit.TabIndex = 16;
            chb_IsUsingCutterTakeUpUnit.Text = "Skall extra textfält för Hack/Upptagare visas på mätprotokollet?";
            chb_IsUsingCutterTakeUpUnit.UseVisualStyleBackColor = true;
            // 
            // chb_ExtraInputBoxes_Second_Measurement
            // 
            chb_ExtraInputBoxes_Second_Measurement.AutoSize = true;
            chb_ExtraInputBoxes_Second_Measurement.Font = new Font("Lucida Sans", 10.25F);
            chb_ExtraInputBoxes_Second_Measurement.ForeColor = Color.FromArgb(187, 215, 228);
            chb_ExtraInputBoxes_Second_Measurement.Location = new Point(169, 212);
            chb_ExtraInputBoxes_Second_Measurement.Margin = new Padding(4, 3, 4, 3);
            chb_ExtraInputBoxes_Second_Measurement.Name = "chb_ExtraInputBoxes_Second_Measurement";
            chb_ExtraInputBoxes_Second_Measurement.Size = new Size(115, 20);
            chb_ExtraInputBoxes_Second_Measurement.TabIndex = 16;
            chb_ExtraInputBoxes_Second_Measurement.Text = "Extra mätning";
            chb_ExtraInputBoxes_Second_Measurement.UseVisualStyleBackColor = true;
            chb_ExtraInputBoxes_Second_Measurement.Visible = false;
            // 
            // chb_ExtraInputBoxes_2Layer
            // 
            chb_ExtraInputBoxes_2Layer.AutoSize = true;
            chb_ExtraInputBoxes_2Layer.Font = new Font("Lucida Sans", 10.25F);
            chb_ExtraInputBoxes_2Layer.ForeColor = Color.FromArgb(187, 215, 228);
            chb_ExtraInputBoxes_2Layer.Location = new Point(47, 212);
            chb_ExtraInputBoxes_2Layer.Margin = new Padding(4, 3, 4, 3);
            chb_ExtraInputBoxes_2Layer.Name = "chb_ExtraInputBoxes_2Layer";
            chb_ExtraInputBoxes_2Layer.Size = new Size(81, 20);
            chb_ExtraInputBoxes_2Layer.TabIndex = 16;
            chb_ExtraInputBoxes_2Layer.Text = "2 Lager?\r\n";
            chb_ExtraInputBoxes_2Layer.UseVisualStyleBackColor = true;
            chb_ExtraInputBoxes_2Layer.Visible = false;
            // 
            // chb_ExtraInputBoxes
            // 
            chb_ExtraInputBoxes.AutoSize = true;
            chb_ExtraInputBoxes.Font = new Font("Lucida Sans", 10.25F);
            chb_ExtraInputBoxes.ForeColor = Color.FromArgb(187, 215, 228);
            chb_ExtraInputBoxes.Location = new Point(7, 187);
            chb_ExtraInputBoxes.Margin = new Padding(4, 3, 4, 3);
            chb_ExtraInputBoxes.Name = "chb_ExtraInputBoxes";
            chb_ExtraInputBoxes.Size = new Size(334, 20);
            chb_ExtraInputBoxes.TabIndex = 16;
            chb_ExtraInputBoxes.Text = "Extra textrutor för enklare input av mätvärden?";
            chb_ExtraInputBoxes.UseVisualStyleBackColor = true;
            chb_ExtraInputBoxes.CheckedChanged += ExtraInputBoxes_CheckedChanged;
            // 
            // chb_EditAmount
            // 
            chb_EditAmount.AutoSize = true;
            chb_EditAmount.Font = new Font("Lucida Sans", 10.25F);
            chb_EditAmount.ForeColor = Color.FromArgb(187, 215, 228);
            chb_EditAmount.Location = new Point(7, 157);
            chb_EditAmount.Margin = new Padding(4, 3, 4, 3);
            chb_EditAmount.Name = "chb_EditAmount";
            chb_EditAmount.Size = new Size(452, 20);
            chb_EditAmount.TabIndex = 16;
            chb_EditAmount.Text = "Skall det vara möjligt att editera mängd för en överförd mätning?";
            chb_EditAmount.UseVisualStyleBackColor = true;
            // 
            // cb_Monitor_MeasuringTemplate
            // 
            cb_Monitor_MeasuringTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cb_Monitor_MeasuringTemplate.Font = new Font("Lucida Sans", 11.25F);
            cb_Monitor_MeasuringTemplate.FormattingEnabled = true;
            cb_Monitor_MeasuringTemplate.Location = new Point(7, 119);
            cb_Monitor_MeasuringTemplate.Margin = new Padding(4, 3, 4, 3);
            cb_Monitor_MeasuringTemplate.Name = "cb_Monitor_MeasuringTemplate";
            cb_Monitor_MeasuringTemplate.Size = new Size(372, 25);
            cb_Monitor_MeasuringTemplate.TabIndex = 4;
            cb_Monitor_MeasuringTemplate.SelectedIndexChanged += Monitor_MeasuringTemplate_SelectedIndexChanged;
            // 
            // cb_Workoperation
            // 
            cb_Workoperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cb_Workoperation.Font = new Font("Lucida Sans", 11.25F);
            cb_Workoperation.FormattingEnabled = true;
            cb_Workoperation.Location = new Point(443, 54);
            cb_Workoperation.Margin = new Padding(4, 3, 4, 3);
            cb_Workoperation.Name = "cb_Workoperation";
            cb_Workoperation.Size = new Size(372, 25);
            cb_Workoperation.TabIndex = 4;
            // 
            // label_Workoperation
            // 
            label_Workoperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_Workoperation.BackColor = Color.Transparent;
            label_Workoperation.Font = new Font("Lucida Sans", 10.25F);
            label_Workoperation.ForeColor = Color.FromArgb(187, 215, 228);
            label_Workoperation.Location = new Point(443, 25);
            label_Workoperation.Margin = new Padding(4, 0, 4, 0);
            label_Workoperation.Name = "label_Workoperation";
            label_Workoperation.Size = new Size(240, 25);
            label_Workoperation.TabIndex = 9;
            label_Workoperation.Text = "Arbetsoperation";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Lucida Sans", 10.25F);
            label1.ForeColor = Color.FromArgb(187, 215, 228);
            label1.Location = new Point(7, 90);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(240, 25);
            label1.TabIndex = 9;
            label1.Text = "Välj mall från Monitor";
            // 
            // label_TemplateName
            // 
            label_TemplateName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label_TemplateName.BackColor = Color.Transparent;
            label_TemplateName.Font = new Font("Lucida Sans", 10.25F);
            label_TemplateName.ForeColor = Color.FromArgb(187, 215, 228);
            label_TemplateName.Location = new Point(7, 25);
            label_TemplateName.Margin = new Padding(4, 0, 4, 0);
            label_TemplateName.Name = "label_TemplateName";
            label_TemplateName.Size = new Size(240, 25);
            label_TemplateName.TabIndex = 9;
            label_TemplateName.Text = "Mätprotokollets Mall-Namn";
            // 
            // tlp_Top
            // 
            tlp_Top.ColumnCount = 3;
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 184F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 208F));
            tlp_Top.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 2005F));
            tlp_Top.Controls.Add(btn_ConnectPartNr_NewTemplate, 0, 0);
            tlp_Top.Controls.Add(tlp_ExtraInfo, 2, 0);
            tlp_Top.Controls.Add(btn_SaveTemplate, 0, 0);
            tlp_Top.Controls.Add(btn_DeleteTemplate, 0, 1);
            tlp_Top.Dock = DockStyle.Top;
            tlp_Top.Location = new Point(0, 0);
            tlp_Top.Margin = new Padding(0);
            tlp_Top.Name = "tlp_Top";
            tlp_Top.Padding = new Padding(0, 6, 0, 0);
            tlp_Top.RowCount = 2;
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlp_Top.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_Top.Size = new Size(2398, 103);
            tlp_Top.TabIndex = 878;
            // 
            // btn_ConnectPartNr_NewTemplate
            // 
            btn_ConnectPartNr_NewTemplate.BackColor = Color.FromArgb(185, 188, 189);
            btn_ConnectPartNr_NewTemplate.Cursor = Cursors.Hand;
            btn_ConnectPartNr_NewTemplate.Dock = DockStyle.Fill;
            btn_ConnectPartNr_NewTemplate.FlatStyle = FlatStyle.Flat;
            btn_ConnectPartNr_NewTemplate.Font = new Font("Lucida Sans", 10.25F);
            btn_ConnectPartNr_NewTemplate.ForeColor = Color.FromArgb(63, 116, 140);
            btn_ConnectPartNr_NewTemplate.Location = new Point(184, 6);
            btn_ConnectPartNr_NewTemplate.Margin = new Padding(0);
            btn_ConnectPartNr_NewTemplate.Name = "btn_ConnectPartNr_NewTemplate";
            btn_ConnectPartNr_NewTemplate.Size = new Size(208, 48);
            btn_ConnectPartNr_NewTemplate.TabIndex = 20;
            btn_ConnectPartNr_NewTemplate.Text = "Koppla Aktiv Mall till Processkort";
            btn_ConnectPartNr_NewTemplate.UseVisualStyleBackColor = false;
            btn_ConnectPartNr_NewTemplate.Click += ConnectPartNr_NewTemplate_Click;
            // 
            // tlp_ExtraInfo
            // 
            tlp_ExtraInfo.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp_ExtraInfo.ColumnCount = 2;
            tlp_ExtraInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 175F));
            tlp_ExtraInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlp_ExtraInfo.Controls.Add(label_TotalConnectedOrders, 0, 2);
            tlp_ExtraInfo.Controls.Add(lbl_CreatedDate, 1, 1);
            tlp_ExtraInfo.Controls.Add(lbl_CreatedBy, 1, 0);
            tlp_ExtraInfo.Controls.Add(label_CreatedDate, 0, 1);
            tlp_ExtraInfo.Controls.Add(label_CreatedBy, 0, 0);
            tlp_ExtraInfo.Controls.Add(label_TotalConnectedProcesscards, 0, 3);
            tlp_ExtraInfo.Dock = DockStyle.Right;
            tlp_ExtraInfo.Location = new Point(1862, 6);
            tlp_ExtraInfo.Margin = new Padding(0);
            tlp_ExtraInfo.Name = "tlp_ExtraInfo";
            tlp_ExtraInfo.Padding = new Padding(0, 0, 6, 0);
            tlp_ExtraInfo.RowCount = 4;
            tlp_Top.SetRowSpan(tlp_ExtraInfo, 2);
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tlp_ExtraInfo.RowStyles.Add(new RowStyle(SizeType.Absolute, 23F));
            tlp_ExtraInfo.Size = new Size(536, 97);
            tlp_ExtraInfo.TabIndex = 19;
            // 
            // label_TotalConnectedOrders
            // 
            label_TotalConnectedOrders.AutoSize = true;
            tlp_ExtraInfo.SetColumnSpan(label_TotalConnectedOrders, 2);
            label_TotalConnectedOrders.Dock = DockStyle.Right;
            label_TotalConnectedOrders.Font = new Font("Lucida Sans", 11.25F);
            label_TotalConnectedOrders.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalConnectedOrders.Location = new Point(274, 49);
            label_TotalConnectedOrders.Margin = new Padding(4, 0, 4, 0);
            label_TotalConnectedOrders.Name = "label_TotalConnectedOrders";
            label_TotalConnectedOrders.Size = new Size(251, 23);
            label_TotalConnectedOrders.TabIndex = 16;
            label_TotalConnectedOrders.Text = "Antal Ordrar kopplade till mallen:";
            label_TotalConnectedOrders.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbl_CreatedDate
            // 
            lbl_CreatedDate.AutoSize = true;
            lbl_CreatedDate.BackColor = Color.Transparent;
            lbl_CreatedDate.Dock = DockStyle.Fill;
            lbl_CreatedDate.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            lbl_CreatedDate.ForeColor = Color.FromArgb(255, 235, 156);
            lbl_CreatedDate.Location = new Point(177, 25);
            lbl_CreatedDate.Margin = new Padding(0);
            lbl_CreatedDate.Name = "lbl_CreatedDate";
            lbl_CreatedDate.Size = new Size(352, 23);
            lbl_CreatedDate.TabIndex = 18;
            lbl_CreatedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_CreatedBy
            // 
            lbl_CreatedBy.AutoSize = true;
            lbl_CreatedBy.BackColor = Color.Transparent;
            lbl_CreatedBy.Dock = DockStyle.Fill;
            lbl_CreatedBy.Font = new Font("Lucida Sans", 11.25F, FontStyle.Bold);
            lbl_CreatedBy.ForeColor = Color.FromArgb(255, 235, 156);
            lbl_CreatedBy.Location = new Point(177, 1);
            lbl_CreatedBy.Margin = new Padding(0);
            lbl_CreatedBy.Name = "lbl_CreatedBy";
            lbl_CreatedBy.Size = new Size(352, 23);
            lbl_CreatedBy.TabIndex = 17;
            lbl_CreatedBy.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_CreatedDate
            // 
            label_CreatedDate.AutoSize = true;
            label_CreatedDate.Dock = DockStyle.Right;
            label_CreatedDate.Font = new Font("Lucida Sans", 11.25F);
            label_CreatedDate.ForeColor = Color.FromArgb(187, 215, 228);
            label_CreatedDate.Location = new Point(56, 25);
            label_CreatedDate.Margin = new Padding(4, 0, 4, 0);
            label_CreatedDate.Name = "label_CreatedDate";
            label_CreatedDate.Size = new Size(116, 23);
            label_CreatedDate.TabIndex = 16;
            label_CreatedDate.Text = "Mallen skapad:";
            // 
            // label_CreatedBy
            // 
            label_CreatedBy.AutoSize = true;
            label_CreatedBy.Dock = DockStyle.Right;
            label_CreatedBy.Font = new Font("Lucida Sans", 11.25F);
            label_CreatedBy.ForeColor = Color.FromArgb(187, 215, 228);
            label_CreatedBy.Location = new Point(34, 1);
            label_CreatedBy.Margin = new Padding(4, 0, 4, 0);
            label_CreatedBy.Name = "label_CreatedBy";
            label_CreatedBy.Size = new Size(138, 23);
            label_CreatedBy.TabIndex = 16;
            label_CreatedBy.Text = "Mallen skapad av:";
            // 
            // label_TotalConnectedProcesscards
            // 
            label_TotalConnectedProcesscards.AutoSize = true;
            tlp_ExtraInfo.SetColumnSpan(label_TotalConnectedProcesscards, 2);
            label_TotalConnectedProcesscards.Dock = DockStyle.Right;
            label_TotalConnectedProcesscards.Font = new Font("Lucida Sans", 11.25F);
            label_TotalConnectedProcesscards.ForeColor = Color.FromArgb(187, 215, 228);
            label_TotalConnectedProcesscards.Location = new Point(234, 73);
            label_TotalConnectedProcesscards.Margin = new Padding(4, 0, 4, 0);
            label_TotalConnectedProcesscards.Name = "label_TotalConnectedProcesscards";
            label_TotalConnectedProcesscards.Size = new Size(291, 23);
            label_TotalConnectedProcesscards.TabIndex = 16;
            label_TotalConnectedProcesscards.Text = "Antal Processkort kopplade till mallen:";
            label_TotalConnectedProcesscards.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tlp_Bottom
            // 
            tlp_Bottom.ColumnCount = 4;
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 323F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 117F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1219F));
            tlp_Bottom.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 126F));
            tlp_Bottom.Controls.Add(gbx_MeasureParameters, 0, 1);
            tlp_Bottom.Controls.Add(gbox_MeasureProtocolTemplate, 2, 1);
            tlp_Bottom.Controls.Add(dgv_Parameters, 0, 2);
            tlp_Bottom.Controls.Add(web_PDF_Viewer, 3, 2);
            tlp_Bottom.Controls.Add(flp_ObjectManagement, 1, 2);
            tlp_Bottom.Controls.Add(dgv_Template, 2, 2);
            tlp_Bottom.Dock = DockStyle.Fill;
            tlp_Bottom.Location = new Point(0, 103);
            tlp_Bottom.Margin = new Padding(4, 3, 4, 3);
            tlp_Bottom.Name = "tlp_Bottom";
            tlp_Bottom.RowCount = 3;
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 111F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 297F));
            tlp_Bottom.RowStyles.Add(new RowStyle(SizeType.Absolute, 9F));
            tlp_Bottom.Size = new Size(2398, 1121);
            tlp_Bottom.TabIndex = 879;
            // 
            // web_PDF_Viewer
            // 
            web_PDF_Viewer.Dock = DockStyle.Fill;
            web_PDF_Viewer.Location = new Point(1663, 411);
            web_PDF_Viewer.Margin = new Padding(4, 3, 4, 3);
            web_PDF_Viewer.MinimumSize = new Size(23, 23);
            web_PDF_Viewer.Name = "web_PDF_Viewer";
            web_PDF_Viewer.Size = new Size(731, 707);
            web_PDF_Viewer.TabIndex = 22;
            // 
            // flp_ObjectManagement
            // 
            flp_ObjectManagement.Controls.Add(label_Buttons_Parameter);
            flp_ObjectManagement.Controls.Add(btn_MoveTaskUp);
            flp_ObjectManagement.Controls.Add(btn_MoveTaskDown);
            flp_ObjectManagement.Controls.Add(btn_DeleteTask);
            flp_ObjectManagement.Dock = DockStyle.Fill;
            flp_ObjectManagement.FlowDirection = FlowDirection.TopDown;
            flp_ObjectManagement.Location = new Point(327, 411);
            flp_ObjectManagement.Margin = new Padding(4, 3, 4, 3);
            flp_ObjectManagement.Name = "flp_ObjectManagement";
            flp_ObjectManagement.Size = new Size(109, 707);
            flp_ObjectManagement.TabIndex = 23;
            // 
            // dgv_Template
            // 
            dgv_Template.AllowUserToAddRows = false;
            dgv_Template.AllowUserToResizeColumns = false;
            dgv_Template.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(6, 81, 87);
            dataGridViewCellStyle1.Font = new Font("Lucida Sans", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 235, 156);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_Template.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv_Template.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Template.Columns.AddRange(new DataGridViewColumn[] { col_DescriptionID, col_Parameter, col_ParameterMonitor, col_Items, col_IsMandatory, col_DataType, col_ControlType, col_Increment, col_Decimals, col_Formula, col_Width, col_MaxChars });
            dgv_Template.Dock = DockStyle.Fill;
            dgv_Template.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv_Template.EnableHeadersVisualStyles = false;
            dgv_Template.Location = new Point(444, 411);
            dgv_Template.Margin = new Padding(4, 3, 4, 3);
            dgv_Template.Name = "dgv_Template";
            dgv_Template.RowHeadersVisible = false;
            dgv_Template.Size = new Size(1211, 707);
            dgv_Template.TabIndex = 24;
            dgv_Template.CellMouseClick += Template_CellMouseClick;
            dgv_Template.CellValueChanged += Template_CellValueChanged;
            dgv_Template.CurrentCellDirtyStateChanged += Template_CurrentCellDirtyStateChanged;
            dgv_Template.DataError += Template_DataError;
            // 
            // col_DescriptionID
            // 
            col_DescriptionID.HeaderText = "DescriptionID";
            col_DescriptionID.Name = "col_DescriptionID";
            col_DescriptionID.Visible = false;
            // 
            // col_Parameter
            // 
            col_Parameter.HeaderText = "Parameter Text";
            col_Parameter.Name = "col_Parameter";
            col_Parameter.Width = 125;
            // 
            // col_ParameterMonitor
            // 
            col_ParameterMonitor.HeaderText = "Parameter Monitor";
            col_ParameterMonitor.Name = "col_ParameterMonitor";
            col_ParameterMonitor.Resizable = DataGridViewTriState.True;
            col_ParameterMonitor.SortMode = DataGridViewColumnSortMode.Automatic;
            col_ParameterMonitor.Width = 140;
            // 
            // col_Items
            // 
            col_Items.HeaderText = "Hämta Lista";
            col_Items.Name = "col_Items";
            col_Items.Resizable = DataGridViewTriState.True;
            col_Items.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // col_IsMandatory
            // 
            col_IsMandatory.HeaderText = "Obligatoriskt Fält";
            col_IsMandatory.Name = "col_IsMandatory";
            col_IsMandatory.Resizable = DataGridViewTriState.True;
            col_IsMandatory.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // col_DataType
            // 
            col_DataType.HeaderText = "DataTyp";
            col_DataType.Name = "col_DataType";
            col_DataType.Resizable = DataGridViewTriState.True;
            col_DataType.SortMode = DataGridViewColumnSortMode.Automatic;
            col_DataType.Width = 80;
            // 
            // col_ControlType
            // 
            col_ControlType.HeaderText = "Kontroll Typ";
            col_ControlType.Name = "col_ControlType";
            col_ControlType.Resizable = DataGridViewTriState.True;
            col_ControlType.SortMode = DataGridViewColumnSortMode.Automatic;
            col_ControlType.Width = 110;
            // 
            // col_Increment
            // 
            col_Increment.HeaderText = "Öknings värde";
            col_Increment.Name = "col_Increment";
            col_Increment.Width = 65;
            // 
            // col_Decimals
            // 
            col_Decimals.HeaderText = "Decimaler";
            col_Decimals.Name = "col_Decimals";
            // 
            // col_Formula
            // 
            col_Formula.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col_Formula.HeaderText = "Formel Beräknat Värde";
            col_Formula.Name = "col_Formula";
            // 
            // col_Width
            // 
            col_Width.HeaderText = "Kolumn bredd";
            col_Width.Name = "col_Width";
            col_Width.Width = 80;
            // 
            // col_MaxChars
            // 
            col_MaxChars.HeaderText = "Max tecken";
            col_MaxChars.Name = "col_MaxChars";
            col_MaxChars.Width = 60;
            // 
            // Templates_MeasureProtocol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(6, 81, 87);
            ClientSize = new Size(2398, 1224);
            Controls.Add(tlp_Bottom);
            Controls.Add(tlp_Top);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Templates_MeasureProtocol";
            Text = "Hantera Mätprotokolls Mallar";
            WindowState = FormWindowState.Maximized;
            FormClosed += Manage_Templates_FormClosed;
            Load += Templates_MeasureProtocol_Load;
            ((ISupportInitialize)dgv_Parameters).EndInit();
            ((ISupportInitialize)btn_MoveTaskUp).EndInit();
            ((ISupportInitialize)btn_MoveTaskDown).EndInit();
            ((ISupportInitialize)btn_DeleteTask).EndInit();
            gbx_MeasureParameters.ResumeLayout(false);
            gbx_MeasureParameters.PerformLayout();
            gbox_MeasureProtocolTemplate.ResumeLayout(false);
            gbox_MeasureProtocolTemplate.PerformLayout();
            tlp_Top.ResumeLayout(false);
            tlp_ExtraInfo.ResumeLayout(false);
            tlp_ExtraInfo.PerformLayout();
            tlp_Bottom.ResumeLayout(false);
            flp_ObjectManagement.ResumeLayout(false);
            flp_ObjectManagement.PerformLayout();
            ((ISupportInitialize)dgv_Template).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private DataGridView dgv_Parameters;
        private ComboBox cb_TemplateName;
        private Button btn_SaveTemplate;
        private Label label_Measureprotocol_Revision;
        private ComboBox cb_Revision;
        private Button btn_DeleteTemplate;
        private PictureBox btn_DeleteTask;
        private Label label_Buttons_Parameter;
        private PictureBox btn_MoveTaskUp;
        private PictureBox btn_MoveTaskDown;
        private Button btn_NewRevision;
        private ToolTip toolTip;
        private TextBox tb_AddNewParameter;
        private Button btn_AddParameter;
        private GroupBox gbx_MeasureParameters;
        private GroupBox gbox_MeasureProtocolTemplate;
        private Label label_TemplateName;
        private TableLayoutPanel tlp_Top;
        private TableLayoutPanel tlp_ExtraInfo;
        private Label label_TotalConnectedOrders;
        private Label lbl_CreatedDate;
        private Label lbl_CreatedBy;
        private Label label_CreatedDate;
        private Label label_CreatedBy;
        private Label label_TotalConnectedProcesscards;
        private TableLayoutPanel tlp_Bottom;
        private WebBrowser web_PDF_Viewer;
        private FlowLayoutPanel flp_ObjectManagement;
        private DataGridView dgv_Template;
        private ComboBox cb_Monitor_MeasuringTemplate;
        private Label label1;
        private ComboBox cb_Workoperation;
        private Label label_Workoperation;
        private CheckBox chb_EditAmount;
        private CheckBox chb_ExtraInputBoxes;
        private CheckBox chb_IsUsingCutterTakeUpUnit;
        private CheckBox chb_ExtraInputBoxes_2Layer;
        private CheckBox chb_ExtraInputBoxes_Second_Measurement;
        private DataGridViewTextBoxColumn col_DescriptionID;
        private DataGridViewTextBoxColumn col_Parameter;
        private DataGridViewComboBoxColumn col_ParameterMonitor;
        private DataGridViewCheckBoxColumn col_Items;
        private DataGridViewCheckBoxColumn col_IsMandatory;
        private DataGridViewComboBoxColumn col_DataType;
        private DataGridViewComboBoxColumn col_ControlType;
        private DataGridViewTextBoxColumn col_Increment;
        private DataGridViewTextBoxColumn col_Decimals;
        private DataGridViewTextBoxColumn col_Formula;
        private DataGridViewTextBoxColumn col_Width;
        private DataGridViewTextBoxColumn col_MaxChars;
        private Button btn_ConnectPartNr_NewTemplate;
    }
}