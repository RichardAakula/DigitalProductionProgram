using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using DigitalProductionProgram.ControlsManagement;
using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Equipment;
using DigitalProductionProgram.Help;

using DigitalProductionProgram.OrderManagement;
using DigitalProductionProgram.Övrigt;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace DigitalProductionProgram.QC
{
    public partial class QC_Feedback : Form
    {
        private bool mouseDown;
        private Point lastLocation;
       
        public byte[] ImageToByteArray(Image image)
        {
            if (image == null)
                return null;
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
        private readonly bool isUserSigningNotification;
        private List<int> ListOperations
        {
            get
            {
                var list = new List<int>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"SELECT DISTINCT Operation FROM [Order].MainData WHERE PartNr = @partnumber";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partnumber", tb_PartNr.Text);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add(int.Parse(reader["Operation"].ToString()));
                }

                return list;

            }
        }
        private List<string> HistoryPartNumbers
        {
            get
            {
               var list = new List<string>();
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                    SELECT PartNumber, OrderNr, Operation, qc.OrderID
                    FROM Parts.FeedBackQC as qc
                        JOIN [Order].MainData as main
                            ON qc.OrderID = main.OrderID";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                        list.Add($"{reader["PartNumber"]} - {reader["OrderNr"]} - {reader["Operation"]}:{reader["OrderID"]}");
                }
                return list;
            }
        }
        public static bool IsOperationHaveQCFeedback
        {
            get
            {
                if (string.IsNullOrEmpty(Order.PartNumber))
                    return false;
                
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"
                        SELECT * 
                            FROM Parts.FeedbackQC as qc
                            JOIN Parts.FeedBackQC_RemainingViews as counter
                                ON qc.FeedbackQC_ID = counter.FeedbackQC_ID

                            WHERE qc.PartNumber = @partnumber AND IsDone = 'False' AND Operation = @operation AND RemainingViews > 0";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
                    cmd.Parameters.AddWithValue("@operation", Order.Operation);
                    var value = cmd.ExecuteScalar();
                    if (value != null)
                        return true;
                }
                return false;
            }
        }

        


        public QC_Feedback(bool IsOkShowWarningAuthorization, bool IsUserSigningNotification, bool IsReadOnly)
        {
            InitializeComponent();
            isUserSigningNotification = IsUserSigningNotification;
            tb_OrderNr.Text = Order.OrderNumber;
            tb_Operation.Text = Order.Operation;
            tb_PartNr.Text = Order.PartNumber;
            tb_WorkOperation.Text = Order.WorkOperation.ToString();
            tb_ProdLine.Text = Order.ProdLine;
            tb_ProdType.Text = Order.ProdType;
            tb_Date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            tb_ppkHistory.KeyPress += Public_Events.Only_Decimal_KeyPress;
            tb_ppkOrder.KeyPress += Public_Events.Only_Decimal_KeyPress;

            LoadData(Order.OrderID);
            if (CheckAuthority.IsRoleAuthorized(CheckAuthority.TemplateAuthorities.Edit_QC_Feedback, IsOkShowWarningAuthorization) == false || IsReadOnly)
                LockForm();
        }

        private void LockForm()
        {
            btn_Screenshot.Visible = false;
            btn_UploadImage.Visible = false;
            btn_Save_Exit.Visible = false;
            tb_ppkHistory.Enabled = false;
            tb_ppkOrder.Enabled = false;
            tb_Comments.Enabled = false;
            num_RemainingViews.Enabled = false;
            tb_PartNr.Enabled = false;
            tb_WorkOperation.Enabled = false;
            label_RemainingView.Text = "Antal visningar kvar för denna operation:";
        }

        private void LoadData(int? orderid)
        {
            if (orderid is null)
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT (SELECT OrderNr FROM [Order].MainData WHERE OrderID = feedback.OrderID) as OrderNr, Text, Ppk_OrderNr, Ppk_History, Image, DateTime, RemainingViews
                    FROM Parts.FeedBackQC as feedback
                    JOIN Parts.FeedbackQC_RemainingViews as remViews
                        ON feedback.FeedbackQC_ID = remViews.FeedbackQC_ID
                    WHERE PartNumber = @partnumber AND IsDone = 'False'";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", orderid);
                cmd.Parameters.AddWithValue("@partnumber", tb_PartNr.Text);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tb_OrderNr.Text = reader["OrderNr"].ToString();
                    tb_Comments.Text = reader["Text"].ToString();
                    tb_ppkOrder.Text = reader["Ppk_OrderNr"].ToString();
                    tb_ppkHistory.Text = reader["Ppk_History"].ToString();
                    if (reader["Image"] != DBNull.Value)
                    {
                        var img = (byte[])reader["Image"];
                        var ms = new MemoryStream(img);
                        pb_Image.BackgroundImage = Image.FromStream(ms);
                    }

                    tb_Date.Text = reader["DateTime"].ToString();
                    num_RemainingViews.Text = reader["RemainingViews"].ToString();
                }
            }
        }
        private void DecreaseRemainingViewsForOperation()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"UPDATE Parts.FeedbackQC_RemainingViews SET RemainingViews = RemainingViews - 1 WHERE FeedbackQC_ID = (SELECT FeedbackQC_ID FROM Parts.FeedbackQC WHERE PartNumber = @partnumber AND IsDone = 'False') AND Operation = @operation AND RemainingViews > 0";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
                cmd.Parameters.AddWithValue("@operation", Order.Operation);
                cmd.ExecuteNonQuery();
            }
            CheckIfFeedbackIsDone();
        }
        public static void IncreaseRemainingViewsForOperation()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"UPDATE Parts.FeedbackQC_RemainingViews SET RemainingViews = RemainingViews + 1 WHERE FeedbackQC_ID = (SELECT FeedbackQC_ID FROM Parts.FeedbackQC WHERE PartNumber = @partnumber AND IsDone = 'False') AND Operation = @operation AND RemainingViews > 0";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
                cmd.Parameters.AddWithValue("@operation", Order.Operation);
                cmd.ExecuteNonQuery();
            }
        }

        private void CheckIfFeedbackIsDone()
        {
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                var query = @"
                    SELECT SUM(RemainingViews) FROM Parts.FeedbackQC_RemainingViews
                    WHERE FeedbackQC_ID = (SELECT FeedbackQC_ID FROM Parts.FeedBackQC WHERE PartNumber = @partnumber AND IsDone = 'False')";
                con.Open();
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partNumber", tb_PartNr.Text);
                var value = cmd.ExecuteScalar();
                int.TryParse(value.ToString(), out var remainingViews);
                if (remainingViews != 0) 
                    return;
                InfoText.Show("Denna feedback stängs nu och kommer ej att visas flera gånger.", CustomColors.InfoText_Color.Info, null,this);
                query = @"UPDATE Parts.FeedbackQC SET IsDone = 'True' WHERE PartNumber = @partnumber";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@partNumber", tb_PartNr.Text);
                cmd.ExecuteNonQuery();
            }
        }
        private void Save_RemainingViews()
        {
            foreach (var operation in ListOperations)
            {
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"INSERT INTO Parts.FeedbackQC_RemainingViews
                                   VALUES ((SELECT TOP(1) FeedbackQC_ID FROM Parts.FeedbackQC WHERE PartNumber = @partNumber ORDER BY DateTime DESC), @operation, @remainingViews)";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@partNumber", Order.PartNumber);
                    cmd.Parameters.AddWithValue("@operation", operation);
                    SQL_Parameter.Double(cmd.Parameters, "@remainingViews", num_RemainingViews.Text);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        private new void MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private new void MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                var deltaX = e.X - lastLocation.X;
                var deltaY = e.Y - lastLocation.Y;

                Location = new Point(Location.X + deltaX, Location.Y + deltaY);
            }
        }
        


        private void Screenshot_Click(object sender, EventArgs e)
        {
            var myProcess = new Process();

            myProcess.StartInfo.FileName = "ms-screenclip:"; // e.g., "C:\\Program Files\\MyApp\\MyApp.exe"
            myProcess.StartInfo.Arguments = "arguments"; // e.g., "-n"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            myProcess.StartInfo.CreateNoWindow = false;

            myProcess.Start();

            myProcess.WaitForExit();

            var clipboardImage = Clipboard.GetImage();
            pb_Image.BackgroundImage = clipboardImage;
        }
        private void UploadImage_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "JPG Files(*.jpg)|*.jpg|GIF Files(*.gif)|*.gif|All Files(*.*)|*.*",
                Title = LanguageManager.GetString("uploadPicture_2")
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var picLocation = dlg.FileName;

                var fs = new FileStream(picLocation, FileMode.Open, FileAccess.Read);
                var br = new BinaryReader(fs);
                var img = br.ReadBytes((int)fs.Length);
                var ms = new MemoryStream(img);
                pb_Image.BackgroundImage = Image.FromStream(ms);
            }
        }
       
       
        private void Save_Exit_Click(object sender, EventArgs e)
        {
            using (var image = pb_Image.BackgroundImage)
            {
                var img = ImageToByteArray(image);
                using (var con = new SqlConnection(Database.cs_Protocol))
                {
                    const string query = @"INSERT INTO Parts.FeedbackQC (OrderID, PartNumber, Text, Ppk_OrderNr, Ppk_History, Image, DateTime, IsDone)
                                   VALUES (@orderid, @partnumber, @text, @ppk_orderNr, @ppk_history, @img, @date, 'False')";
                    con.Open();
                    var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                    cmd.Parameters.AddWithValue("@partnumber", tb_PartNr.Text);
                    cmd.Parameters.AddWithValue("@text" ,tb_Comments.Text);
                    SQL_Parameter.Double(cmd.Parameters, "@ppk_orderNr", tb_ppkOrder.Text);
                    SQL_Parameter.Double(cmd.Parameters, "@ppk_history", tb_ppkHistory.Text);
                    if (img is null)
                    {
                        var imgParameter = cmd.Parameters.Add("@img", SqlDbType.Image);
                        imgParameter.Value = DBNull.Value;
                    }
                    else
                        cmd.Parameters.AddWithValue("@img", img);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));

                    cmd.ExecuteNonQuery();
                }
            }
            Save_RemainingViews();
            Close();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            if (isUserSigningNotification)
            {
                var background = new BlackBackground("", 70);
                var password = new PasswordManager("Bekräfta att du läst denna notifiering.");
                background.Show();
                password.ShowDialog();
                background.Close();

                if (password.IsOk == false)
                    return;
                DecreaseRemainingViewsForOperation();
            }
            Close();
        }

        private void PartNr_LoadHistory_Click(object sender, EventArgs e)
        {
            var chooseItem = new Choose_Item(HistoryPartNumbers, new Control[]{ tb_PartNr, tb_OrderNr }, true, false, false);
            chooseItem.ShowDialog();
            var ordernr = tb_OrderNr.Text;
            int? orderid;
            if (int.TryParse(ordernr, out var tempResult))
                orderid = tempResult;
            else
                orderid = null;
            if (orderid == null)
            {
                tb_PartNr.Text = string.Empty;
                tb_OrderNr.Text = string.Empty;
                return;
            }
            string partNumber = null;
            var input = tb_PartNr.Text;
            var firstIndex = input.IndexOf("-");
            if (firstIndex != -1)
                partNumber = input.Substring(0, firstIndex).Trim();
            tb_PartNr.Text = partNumber;
            LoadData(orderid);
        }
    }
}
