using DigitalProductionProgram.DatabaseManagement;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.OrderManagement;

namespace DigitalProductionProgram.QC
{
    public partial class FeedBackQC : UserControl
    {
        public FeedBackQC()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            if (Order.OrderID is null)
                return;
            using (var con = new SqlConnection(Database.cs_Protocol))
            {
                const string query = @"
                    SELECT Text, Ppk_OrderNr, Ppk_History, DateTime
                    FROM Parts.FeedBackQC 
                    WHERE PartNumber = @partnumber AND IsDone = 'False'";
                con.Open();
                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    label_Text.Text = reader["Text"].ToString();
            }
        }
        private void Text_Click(object sender, EventArgs e)
        {
            var qc = new QC_Feedback(false, false, true);
            qc.ShowDialog();
        }
    }
}
