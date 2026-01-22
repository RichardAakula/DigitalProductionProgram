using DigitalProductionProgram.DatabaseManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.Log
{
    public partial class ClientUpdateManager : Form
    {
        public ClientUpdateManager()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            var clients = Database.ExecuteSafe(con =>
            {
                var list = new List<KeyValuePair<int, string>>();

                const string query = "SELECT HostID, HostName FROM [Settings].General ORDER BY HostName";
                using var cmd = new SqlCommand(query, con);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int hostId = reader.GetInt32(reader.GetOrdinal("HostID"));
                    string hostName = reader.GetString(reader.GetOrdinal("HostName"));
                    list.Add(new KeyValuePair<int, string>(hostId, hostName));
                }

                return list;
            });

            // Bind till ListBox
            lb_Clients.DataSource = clients;
            lb_Clients.DisplayMember = "Value"; // HostName
            lb_Clients.ValueMember = "Key";     // HostID
        }

        private void lb_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Clients.SelectedItem is KeyValuePair<int, string> selectedClient)
            {
                int hostId = selectedClient.Key;

                // Hämta användare som brukar använda denna dator (HostID)
                var users = GetUsersForHost(hostId);

                // Visa i listan bredvid, t.ex. lb_UsersForHost
                lb_Users.Items.Clear();
                foreach (var user in users)
                    lb_Users.Items.Add(user);
            }
        }

        private List<KeyValuePair<int, string>> GetUsersForHost(int hostId)
        {
            return Database.ExecuteSafe(con =>
            {
                var result = new List<KeyValuePair<int, string>>();

                const string query = @"
                    SELECT UserID, Name, Date
                    FROM    
                    (
                        SELECT 
                            al.UserID,
                            p.Name,
                            al.Date,
                            ROW_NUMBER() OVER(PARTITION BY al.UserID ORDER BY al.Date DESC) AS rn
                        FROM Log.ActivityLog al
                        JOIN [User].Person p 
                            ON al.UserID = p.UserID
                        WHERE al.HostID = @hostid
                    ) t
                    WHERE rn = 1
                    ORDER BY Date DESC";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@hostid", hostId);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int userId = reader.GetInt32(reader.GetOrdinal("UserID"));
                    string name = reader["Name"]?.ToString() ?? string.Empty;
                    result.Add(new KeyValuePair<int, string>(userId, name));
                }

                return result;
            }); // fallback om ExecuteSafe returnerar null
        }
    }
}
