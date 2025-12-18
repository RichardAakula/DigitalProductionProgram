using System.Globalization;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.Protocols.Protocol;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.Protocols.ExtraProtocols
{
    public partial class Extra_Comments : Form
    {
        private string org_Spole_Extra_Kommentar;
        private string org_Kommentar_Extra_Kommentar;
        private bool IsOkSaveExtraComments;

        private bool IsINSERT_Extra_Kommentar;
        private bool IsOkAddDateExtraKommentar(int row)
        {

            if (dgv_ExtraComments.Rows[row].Cells["Date"].Value != null)        //Om Datum är NULL - inget händer
                return false;
            if (dgv_ExtraComments.Rows[row].Cells["Spool"].Value == null && dgv_ExtraComments.Rows[row].Cells["Comments"].Value == null)        //Om Spole och Kommentar är NULL - inget händer
            {
                if (row < dgv_ExtraComments.Rows.Count - 1)
                    InfoText.Show(LanguageManager.GetString("extraComments_Info_2"), CustomColors.InfoText_Color.Bad, "Warning", this);
                return false;
            }

            return true;
        }
        public static int TotalRows_ExtraComments
        {
            get
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    var query = $"SELECT COUNT(*) FROM [Order].ExtraComments {Queries.WHERE_OrderID}";
                    var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                    cmd.Parameters.AddWithValue("@id", Order.OrderID);
                    con.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public static int Next_Row_ExtraComments
        {
            get
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"
            SELECT ISNULL(MAX(Row), 0) + 1 
            FROM [Order].ExtraComments
            WHERE OrderID = @id";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", Order.OrderID);
                ServerStatus.Add_Sql_Counter();

                con.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public Extra_Comments()
        {
            InitializeComponent();
            Translate_Form();
            Load_Data();
            dgv_ExtraComments.MouseWheel += ExtraComments_MouseWheel;
        }
        public void Translate_Form()
        {
            label_Header.Text = LanguageManager.GetString("extraComments");
            dgv_ExtraComments.Columns["Spool"].HeaderText = LanguageManager.GetString("spool");
            dgv_ExtraComments.Columns["Comments"].HeaderText = LanguageManager.GetString("comments");
            dgv_ExtraComments.Columns["Date"].HeaderText = LanguageManager.GetString("date");
            dgv_ExtraComments.Columns["EmpNr"].HeaderText = LanguageManager.GetString("label_EmpNr");

        }
        private void ExtraComments_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            timer_Update_ExtraKommentarer.Stop();
            if (Module.IsOkToSave)
            {
                dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DodgerBlue;
                IsOkSaveExtraComments = true;
                if (dgv_ExtraComments.Rows[e.RowIndex].Cells["Spool"].Value != null)
                    org_Spole_Extra_Kommentar = dgv_ExtraComments.Rows[e.RowIndex].Cells["Spool"].Value.ToString();
                else
                    org_Spole_Extra_Kommentar = string.Empty;

                if (dgv_ExtraComments.Rows[e.RowIndex].Cells["Comments"].Value != null)
                    org_Kommentar_Extra_Kommentar = dgv_ExtraComments.Rows[e.RowIndex].Cells["Comments"].Value.ToString();
                else
                    org_Kommentar_Extra_Kommentar = string.Empty;


                if (dgv_ExtraComments.Rows[e.RowIndex].Cells["EmpNr"].Value != null)
                {
                    var anstNr = dgv_ExtraComments.Rows[e.RowIndex].Cells["EmpNr"].Value.ToString();
                    if (!string.IsNullOrEmpty(anstNr))
                    {
                        if (Person.EmployeeNr != anstNr)
                        {
                            dgv_ExtraComments.Rows[e.RowIndex].ReadOnly = true;
                            dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                            dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = CustomColors.Bad_Back;

                            IsOkSaveExtraComments = false;
                            return;
                        }
                    }
                    else
                        IsOkSaveExtraComments = false;
                }
                if (e.RowIndex == dgv_ExtraComments.Rows.Count - 1)
                    IsINSERT_Extra_Kommentar = true;
                else
                    IsINSERT_Extra_Kommentar = false;

                timer_Update_ExtraKommentarer.Stop();
                if (dgv_ExtraComments.Rows[e.RowIndex].ReadOnly)
                {
                    dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.BackColor = CustomColors.Bad_Back;
                    dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = CustomColors.Bad_Back;
                }
                else
                {
                    dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = CustomColors.Warning_Back;
                    dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.BackColor = CustomColors.Warning_Back;
                }
                    
            }
        }
        private void ExtraComments_MouseWheel(object sender, MouseEventArgs e)
        {
            var currentIndex = dgv_ExtraComments.FirstDisplayedScrollingRowIndex;
            var scrollLines = SystemInformation.MouseWheelScrollLines;

            if (e.Delta > 0)
            {
                dgv_ExtraComments.FirstDisplayedScrollingRowIndex
                    = Math.Max(0, currentIndex - scrollLines);
            }
            else if (e.Delta < 0 && currentIndex > 0)
            {
                dgv_ExtraComments.FirstDisplayedScrollingRowIndex
                    = currentIndex + scrollLines;
            }
        }
        private void ExtraComments_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (Module.IsOkToSave)
            {
                dgv_ExtraComments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                if (IsOkAddDateExtraKommentar(e.RowIndex) && IsINSERT_Extra_Kommentar)
                {
                    dgv_ExtraComments.Rows[e.RowIndex].Cells["Date"].Value = DateTime.Now;
                    dgv_ExtraComments.Rows[e.RowIndex].Cells["EmpNr"].Value = Person.EmployeeNr;
                    dgv_ExtraComments.Rows[e.RowIndex].Cells["Sign"].Value = Person.Sign;
                    dgv_ExtraComments.Rows[e.RowIndex].Cells["is_Locked"].Value = false;
                    if (Module.IsOkToSave == false)//Denna bör aldrig kunna bli false???
                        return;
                    INSERT_Extra_Kommentar(e.RowIndex);

                }
                else if (IsINSERT_Extra_Kommentar == false && IsOkSaveExtraComments)
                {
                    if (dgv_ExtraComments.Rows[e.RowIndex].Cells["Spool"].Value == null || dgv_ExtraComments.Rows[e.RowIndex].Cells["Comments"].Value == null)
                        return;
                    if (dgv_ExtraComments.Rows[e.RowIndex].Cells["Spool"].Value.ToString() != org_Spole_Extra_Kommentar ||
                        dgv_ExtraComments.Rows[e.RowIndex].Cells["Comments"].Value.ToString() != org_Kommentar_Extra_Kommentar)

                        dgv_ExtraComments.Rows[e.RowIndex].Cells["Date"].Value = DateTime.Now;

                    if (Module.IsOkToSave == false)//Denna bör aldrig kunna bli false???
                        return;
                    UPDATE_Extra_Kommentar(e.RowIndex);

                }
                timer_Update_ExtraKommentarer.Start();
            }
        }

        private void timer_Update_ExtraKommentarer_Tick(object sender, EventArgs e)
        {

        }

        public void Load_Data()
        {
            dgv_ExtraComments.RowEnter -= ExtraComments_RowEnter;

            try
            {
                dgv_ExtraComments.Rows.Clear();
            }
            catch { }
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT * FROM [Order].ExtraComments 
                    WHERE OrderID = @orderid ORDER BY Row";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                con.Open();
                var reader = cmd.ExecuteReader();
                var row = 0;
                while (reader.Read())
                {
                    dgv_ExtraComments.Rows.Add();
                    dgv_ExtraComments.Rows[row].Cells[0].Value = reader["Spole"].ToString();
                    dgv_ExtraComments.Rows[row].Cells[1].Value = reader["Kommentar"].ToString();
                    if (DateTime.TryParse(reader["Datum"].ToString(), out var date))
                    {
                        var dateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat;
                        var formattedDate = date.ToString($"{dateTimeFormat.ShortDatePattern} {dateTimeFormat.ShortTimePattern}", CultureInfo.CurrentCulture);
                        dgv_ExtraComments.Rows[row].Cells[2].Value = date.Year > 1900 ? formattedDate : date.ToString("HH:mm");
                    }
                        
                    dgv_ExtraComments.Rows[row].Cells[4].Value = reader["AnstNr"].ToString();
                    dgv_ExtraComments.Rows[row].Cells[5].Value = bool.Parse(reader["is_Locked"].ToString());
                    var anstNr = reader["AnstNr"].ToString();
                    dgv_ExtraComments.Rows[row].Cells[3].Value = Person.Get_SignWithName(Person.Get_NameWithAnstNr(anstNr));
                    if (bool.Parse(reader["is_Locked"].ToString()))
                        dgv_ExtraComments.Rows[row].ReadOnly = true;
                    if (anstNr != Person.EmployeeNr)
                        dgv_ExtraComments.Rows[row].ReadOnly = true;
                    row++;

                }
            }
            dgv_ExtraComments.Rows.Add();
            dgv_ExtraComments.RowEnter += ExtraComments_RowEnter;
        }
        public void UPDATE_Extra_Kommentar(int row)
        {
            if (dgv_ExtraComments.Rows[row].Cells["Spool"].Value == null || dgv_ExtraComments.Rows[row].Cells["Comments"].Value == null)
            {
                InfoText.Show(LanguageManager.GetString("extraComments_Info_1"), CustomColors.InfoText_Color.Warning, "Warning", this);
                return;
            }
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = $@"UPDATE [Order].ExtraComments SET Spole = @spole, Kommentar = @kommentar, Datum = @datum 
                    WHERE OrderID = @orderid AND Row = @row";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@spole", dgv_ExtraComments.Rows[row].Cells["Spool"].Value.ToString());
                cmd.Parameters.AddWithValue("@kommentar", dgv_ExtraComments.Rows[row].Cells["Comments"].Value.ToString());
                if (DateTime.TryParse(dgv_ExtraComments.Rows[row].Cells["Date"].Value.ToString(), out var dateTime) == false)
                    cmd.Parameters.AddWithValue("@datum", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@datum", dateTime);
                
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@row", row);

                cmd.ExecuteNonQuery();
            }
        }
        public void INSERT_Extra_Kommentar(int row)
        {
            if (dgv_ExtraComments.Rows[row].Cells["Spool"].Value == null || dgv_ExtraComments.Rows[row].Cells["Comments"].Value == null)
            {
                InfoText.Show(LanguageManager.GetString("extraComments_Info_2"), CustomColors.InfoText_Color.Warning, "Warning", this);

                dgv_ExtraComments.Rows[row].Cells["Date"].Value = null;
                dgv_ExtraComments.Rows[row].Cells["EmpNr"].Value = null;
                dgv_ExtraComments.Rows[row].Cells["Sign"].Value = null;
                return;
            }
            Add(dgv_ExtraComments.Rows[row].Cells["Spool"].Value.ToString(), dgv_ExtraComments.Rows[row].Cells["Comments"].Value.ToString(), dgv_ExtraComments.Rows[row].Cells["EmpNr"].Value.ToString(), bool.Parse(dgv_ExtraComments.Rows[row].Cells["is_Locked"].Value.ToString()), row);
            try
            {
                dgv_ExtraComments.AllowUserToAddRows = true;
                dgv_ExtraComments.Rows.Add();
                dgv_ExtraComments.AllowUserToAddRows = false;
            }
            catch { }

        }

        public static void Add(string spool, string comment, string empNr, bool isLocked, int row)
        {
            try
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = @"INSERT INTO [Order].ExtraComments (OrderID, Spole, Kommentar, Datum, AnstNr, is_Locked, Row)
                                     VALUES (@orderid, @spool, @comment, @date, @empnr, @islocked, @row)";
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);

                cmd.Parameters.AddWithValue("@spool", spool);
                cmd.Parameters.AddWithValue("@comment", comment);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@empnr", empNr);
                cmd.Parameters.AddWithValue("@islocked", isLocked);
                cmd.Parameters.AddWithValue("@row", row);

                con.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
               Activity.Stop($"Error Add Extra Comment: {e.Message}");
            }
            
        }
    }
}
