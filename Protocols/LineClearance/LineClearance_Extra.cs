using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.Measure;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Template_Management;
using DigitalProductionProgram.Templates;
using DigitalProductionProgram.User;

namespace DigitalProductionProgram.Protocols.LineClearance
{
    public partial class LineClearance_Extra : Form
    {
        private string CenturiLink { get; set; }
        private bool IsAllCheckBoxesDone
        {
            get
            {
                foreach (var dgv in flp_Checkboxes.Controls.OfType<DataGridView>())
                {
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        bool.TryParse(row.Cells[1].EditedFormattedValue.ToString(), out var IsChecked);
                        if (IsChecked == false)
                        {
                            InfoText.Show("Checka i alla rutor före du klickar i LineClearance.", CustomColors.InfoText_Color.Warning, "Varning!");
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        private void InitializeDataGridView(DataGridView dgv, string header, IEnumerable<string> checkboxes)
        {
            var col_header = new DataGridViewTextBoxColumn
            {
                HeaderText = header,

                Name = header,
                ReadOnly = true,
                Width = 350,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
            var col_checkbox = new DataGridViewCheckBoxColumn
            {
                ThreeState = false,
                ReadOnly = false,
                SortMode = DataGridViewColumnSortMode.NotSortable,

            };

            col_header.HeaderCell.Style.Font = new Font("Lucida Sans", 10.25f, FontStyle.Bold);

            dgv.Columns.Add(col_header);
            dgv.Columns.Add(col_checkbox);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 20;
            dgv.BackgroundColor = Color.White;
            dgv.Width = flp_Checkboxes.Width - 20;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            dgv.DefaultCellStyle.SelectionBackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.Margin = new Padding(10, 0, 10, 0);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.EndEdit();
            var height = dgv.ColumnHeadersHeight;
            foreach (var checkbox in checkboxes)
            {
                dgv.Rows.Add(checkbox, false);
                height += 21;
            }
            dgv.Height = height;

        }
        private DataGridView DataGridView_Checkboxes(string header, IEnumerable<string> checkboxes)
        {
            var dgv = new DataGridView();
            InitializeDataGridView(dgv, header, checkboxes);

            return dgv;
        }





        public LineClearance_Extra()
        {
            InitializeComponent();
            Change_UI_Workoperation();

            Add_DataGridView();
            Load_LineClearance();
        }




        private void Change_UI_Workoperation()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT  CenturiLink, IsApprovalRequired, LineClearance_Revision, Name
                    FROM LineClearance.MainTemplate as lc
                    JOIN Protocol.MainTemplate as protocol
                        ON lc.ProtocolMainTemplateID = protocol.ID
                    WHERE MainTemplateID = @maintemplateid";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CenturiLink = reader["CenturiLink"].ToString();
                    lbl_InstructionLink.Text = CenturiLink.Substring(CenturiLink.LastIndexOf('/') + 1);
                    label_LineClearanceTemplate.Text = $"{reader["Name"]} - Revision: {reader["LineClearance_Revision"]}";
                }
            }



            //switch (Order.WorkOperation)
            //{
            //    case Manage_WorkOperation.WorkOperations.Bump_PTFE:
            //        lbl_InstructionLink.Text = "I237";
            //        CenturiLink = "http://centuri.optinova.com/RegNo/I237";
            //        label_LineClearanceTemplate.Text = "på:";
            //        label_Line_Clearance.Text = "Line Clearance: K24 Bump PTFE:";
            //        break;

            //    case Manage_WorkOperation.WorkOperations.Hackning_PTFE:
            //        lbl_InstructionLink.Text = "I237";
            //        CenturiLink = "http://centuri.optinova.com/RegNo/I237";
            //        label_LineClearanceTemplate.Text = "på:";
            //        label_Line_Clearance.Text = "Line Clearance Hackning Bi-tube:";
            //        break;

            //    case Manage_WorkOperation.WorkOperations.Kragning_PTFE:
            //    case Manage_WorkOperation.WorkOperations.Kragning_K22_PTFE:
            //        lbl_InstructionLink.Text = "I237";
            //        CenturiLink = "http://centuri.optinova.com/RegNo/I237";
            //        label_LineClearanceTemplate.Text = $"på Kragningslinje {Order.ProdLine}";
            //        label_Line_Clearance.Text = "Line Clearance Kragning PTFE:";
            //        label_ExtraInfo.Visible = true;
            //        break;

            //    case Manage_WorkOperation.WorkOperations.Slitting_PTFE:
            //        lbl_InstructionLink.Text = "I237";
            //        CenturiLink = "http://centuri.optinova.com/RegNo/I237";
            //        label_LineClearanceTemplate.Text = "på:";
            //        label_Line_Clearance.Text = "Line Clearance K15 PTFE:";
            //        break;

            //    case Manage_WorkOperation.WorkOperations.Synergy_PTFE:
            //        lbl_InstructionLink.Text = "I526";
            //        CenturiLink = "http://centuri.optinova.com/RegNo/I526";
            //        label_LineClearanceTemplate.Text = "på K17 Automat Synergy.";
            //        label_Line_Clearance.Text = "Line Clearance K18 Automat Synergy:";
            //        break;

            //}
        }

        public static void Fill_Tasks(int formTemplateid, out string[] tasks)
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT Tasks
                    FROM LineClearance.Template as template
                        JOIN LineClearance.Description as description
	                        ON template.DescriptionID = description.DescriptionID
                    WHERE FormTemplateID = @formtemplateid
                    ORDER BY RowIndex";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@formtemplateid", formTemplateid);
                con.Open();
                var reader = cmd.ExecuteReader();
                var tasksList = new List<string>();
                while (reader.Read())
                {
                    tasksList.Add(reader["Tasks"].ToString());
                }
                tasks = tasksList.ToArray();
            }
        }
        private void Add_DataGridView()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"SELECT FormTemplateID, Category FROM LineClearance.FormTemplate WHERE MainTemplateID = @maintemplateid ORDER BY TemplateOrder";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@maintemplateid", Templates_LineClearance.MainTemplate.LineClearance_MainTemplateID);
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //_ = Array.Empty<string>();
                    if (int.TryParse(reader["FormTemplateID"].ToString(), out var formtemplateID))
                    {
                        Fill_Tasks(formtemplateID, out var checkboxes);
                        flp_Checkboxes.Controls.Add(DataGridView_Checkboxes(reader["Category"].ToString(), checkboxes));
                    }
                }
            }
        }
        private void Load_LineClearance()
        {
            lbl_ArtikelNr.Text = Order.PartNumber;
            lbl_OrderNr.Text = Order.OrderNumber;
            lbl_Customer.Text = Order.Customer;
            lbl_ID.Text = $@"{MeasurePoints.Value(MeasurePoints.CodeTextMonitor.MainBodyID, "NOM")}";

            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                //var query = @"                    SELECT Rum_Temp, Rum_Fukt, FORMAT(LC_Date, 'yyyy-MM-dd HH:mm') AS LC_Date, LC_Name, FORMAT(LC_Approved_Date, 'yyyy-MM-dd HH:mm') AS LC_Approved_Date, LC_Approved_Name, LC_Rengjort_Extrudern_Ja, LC_Rengjort_Extrudern_Nej_Samma_Mtrl, LC_Rengjort_Extrudern_Mjukt_Hårt, LC_Rengjort_Extrudern_Ljus_Mörk, LC_Comments\r\nFROM [Order].MainData\r\nWHERE OrderID = @orderid";
                var query = @"
                    SELECT Rum_Temp, Rum_Fukt, LC_Date, LC_Name, LC_Approved_Date, LC_Approved_Name,  LC_Comments
                    FROM [Order].MainData
                    WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tb_Comments.Text = reader["LC_Comments"].ToString();
                    if (DateTime.TryParse(reader["LC_Date"].ToString(), out var date))
                    {
                        var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                        var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                        LC_Date.Text = formattedDate;
                    }

                    if (!string.IsNullOrEmpty(reader["LC_Name"].ToString()))
                    {
                        LC_Name.Text = reader["LC_Name"].ToString();
                        lbl_LC_Performed_AnstNr.Text = Person.Get_AnstNrWithName(LC_Name.Text);
                        foreach (var dgv in flp_Checkboxes.Controls.OfType<DataGridView>())
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                                row.Cells[1].Value = 1;
                        }

                        ChangeFont_Label_Performed_LC();
                    }

                    if (DateTime.TryParse(reader["LC_Approved_Date"].ToString(), out var approveDateTime))
                    {
                        var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                        var formattedDate = approveDateTime.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                        LC_Approved_Date.Text = formattedDate;
                    }


                    if (!string.IsNullOrEmpty(reader["LC_Approved_Name"].ToString()))
                    {
                        LC_Approved_Name.Text = reader["LC_Approved_Name"].ToString();
                        lbl_LC_Approved_AnstNr.Text = Person.Get_AnstNrWithName(LC_Approved_Name.Text);
                        ChangeFont_Label_Approved_LC();
                    }
                }
            }
        }
        private void Save_LC()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query =
                    "UPDATE [Order].MainData SET LC_Date = @date, LC_Name = @name WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@date", LC_Date.Text);
                cmd.Parameters.AddWithValue("@name", LC_Name.Text);

                cmd.ExecuteNonQuery();
            }
        }
        private void Save_Approved_LC()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query =
                    "UPDATE [Order].MainData SET LC_Approved_Date = @date, LC_Approved_Name = @name WHERE OrderID = @orderid";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@date", LC_Approved_Date.Text);
                cmd.Parameters.AddWithValue("@name", LC_Approved_Name.Text);

                cmd.ExecuteNonQuery();
            }
        }

        private void LC_Performed_Click(object sender, EventArgs e)
        {
            if (IsAllCheckBoxesDone && Person.IsPasswordOk("Bekräfta LineClearance med ditt lösenord."))
            {
                lbl_LC_Performed_AnstNr.Text = Person.EmployeeNr;
                LC_Name.Text = Person.Name;
                LC_Date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Save_LC();
                ChangeFont_Label_Performed_LC();
            }
        }
        private void ChangeFont_Label_Performed_LC()
        {
            lbl_LC_Performed_AnstNr.Font = LC_Name.Font = LC_Date.Font = new Font("Courier New", 11);
            LC_Name.Cursor = Cursors.No;
            LC_Name.Click -= LC_Performed_Click;
        }

        private void LC_Approved_Click(object sender, EventArgs e)
        {
            if (LineClearance.IsLineClearanceDone == false)
            {
                InfoText.Show("Du kan inte godkänna en Line Clearance före någon har gjort Line Clearance.", CustomColors.InfoText_Color.Bad, "Warning!", this);
                return;
            }
            var List_AuthorizedUsers = new List<string?>();
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const int id = (int)CheckAuthority.TemplateAuthorities.ApproveLineClearancePTFE_Kragning;
                const string query = "SELECT UserName FROM Authorities.CustomNames WHERE TemplateID = @id";

                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["UserName"].ToString() != LC_Name.Text)
                        List_AuthorizedUsers.Add(reader[0].ToString());
                }
            }

            var org_Name = Person.Name;
            var org_UserAnstNr = Person.EmployeeNr;

            using var choose_Item = new Choose_Item(List_AuthorizedUsers, new Control[] { LC_Approved_Name }, false);
            choose_Item.ShowDialog();

            Person.Name = LC_Approved_Name.Text;
            Person.EmployeeNr = Person.Get_AnstNrWithName(Person.Name);
            if (Person.EmployeeNr != null)
            {
                if (Person.IsPasswordOk("Bekräfta LineClearance med ditt lösenord."))
                {
                    lbl_LC_Approved_AnstNr.Text = Person.EmployeeNr;
                    LC_Approved_Name.Text = Person.Name;
                    LC_Approved_Date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                    Save_Approved_LC();
                    ChangeFont_Label_Approved_LC();
                }
                else
                {
                    lbl_LC_Approved_AnstNr.Text = string.Empty;
                    LC_Approved_Name.Text = "Klicka här för godkännande...";
                    LC_Approved_Date.Text = string.Empty;
                }
            }
            Person.Name = org_Name;
            Person.EmployeeNr = org_UserAnstNr;
        }
        private void ChangeFont_Label_Approved_LC()
        {
            lbl_LC_Approved_AnstNr.Font = LC_Approved_Name.Font = LC_Approved_Date.Font = new Font("Courier New", 11);
            LC_Approved_Name.Cursor = Cursors.No;
            LC_Approved_Name.Click -= LC_Approved_Click;
        }

        private void LineClearance_Save_Comments_FormClosed(object sender, FormClosedEventArgs e)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            con.Open();
            var query =
                $@"UPDATE [Order].MainData SET LC_Comments = @comments {Queries.WHERE_OrderID}";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@id", Order.OrderID);
            cmd.Parameters.AddWithValue("@comments", tb_Comments.Text);

            cmd.ExecuteNonQuery();
        }

        private void InstructionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(CenturiLink);
        }


    }
}
