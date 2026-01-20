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
            Database.ExecuteSafe(con =>
            {
                const string query = @"
                    SELECT Text, Ppk_OrderNr, Ppk_History, DateTime
                    FROM Parts.FeedBackQC 
                    WHERE PartNumber = @partnumber AND IsDone = 'False'";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@orderid", Order.OrderID);
                cmd.Parameters.AddWithValue("@partnumber", Order.PartNumber);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    label_Text.Text = reader["Text"].ToString();
            });
        }
        private void Text_Click(object sender, EventArgs e)
        {
            using var qc = new QC_Feedback(false, false, true);
            qc.ShowDialog();
        }
    }
}
