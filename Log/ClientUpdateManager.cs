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
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;

namespace DigitalProductionProgram.Log
{
    public partial class ClientUpdateManager : Form
    {
        public ClientUpdateManager()
        {
            InitializeComponent();
            LoadClients();
            LoadVersions();
        }

        private void LoadClients()
        {
            lb_Clients.Items.Clear();
            lb_Clients.SelectionMode = SelectionMode.MultiExtended;

            var clients = Database.ExecuteSafe(con =>
            {
                var list = new List<HostItem>();

                const string query = "SELECT HostID, HostName FROM [Settings].General ORDER BY HostName";
                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new HostItem(
                        reader.GetInt32(reader.GetOrdinal("HostID")),
                        reader.GetString(reader.GetOrdinal("HostName"))
                    ));
                }

                return list;
            });

            if (clients == null)
                return;

            foreach (var client in clients)
                lb_Clients.Items.Add(client);
        }
        private void LoadVersions()
        {
            var versions = Database.ExecuteSafe(con =>
            {
                var list = new List<string>();

                const string query = @"
                    SELECT Version
                    FROM [Log].ChangeLog
                    GROUP BY Version
                    ORDER BY MAX(ID) DESC";

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                    list.Add(reader.GetString(reader.GetOrdinal("Version")));

                return list;
            });

            lb_Versions.DataSource = versions;
        }

        private void lb_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Clients.SelectedItem is not HostItem host)
                return;

            lb_Users.Items.Clear();

            var users = GetUsersForHost(host.HostID);
            foreach (var user in users)
                lb_Users.Items.Add(user);
        }
        private void lb_Versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Versions.SelectedItem is not string version)
                return;

            lb_BlockedClients.Items.Clear();

            var blockedClients = GetBlockedClientsForVersion(version);

            lb_Clients.BeginUpdate();
            lb_BlockedClients.BeginUpdate();
            try
            {
                foreach (var client in blockedClients)
                {
                    // Lägg till i lb_BlockedClients
                    lb_BlockedClients.Items.Add(client);

                    // Ta bort från lb_Clients om den finns där
                    var existing = lb_Clients.Items.Cast<HostItem>()
                        .FirstOrDefault(x => x.HostID == client.HostID);
                    if (existing != null)
                        lb_Clients.Items.Remove(existing);
                }
            }
            finally
            {
                lb_Clients.EndUpdate();
                lb_BlockedClients.EndUpdate();
            }

            if (lb_BlockedClients.Items.Count == 0)
                LoadClients();
        }

        private void chk_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            lb_Clients.BeginUpdate();
            try
            {
                if (chk_CheckAllClients.Checked)
                {
                    lb_Clients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_Clients.Items.Count; i++)
                        lb_Clients.SelectedIndices.Add(i); // snabbare än SetSelected
                }
                else
                {
                    lb_Clients.ClearSelected();
                }
            }
            finally
            {
                lb_Clients.EndUpdate();
            }
        }
        private void chk_CheckAllBlockedClients_CheckedChanged(object sender, EventArgs e)
        {
            lb_BlockedClients.BeginUpdate();
            try
            {
                if (chk_CheckAllBlockedClients.Checked)
                {
                    lb_BlockedClients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_BlockedClients.Items.Count; i++)
                        lb_BlockedClients.SelectedIndices.Add(i); // snabbare än SetSelected
                }
                else
                {
                    lb_BlockedClients.ClearSelected();
                }
            }
            finally
            {
                lb_BlockedClients.EndUpdate();
            }
        }
        private void btn_BlockClient_Click(object sender, EventArgs e)
        {
            if (lb_Clients.SelectedItems.Count == 0)
                return;

            var toMove = lb_Clients.SelectedItems
                .Cast<HostItem>()
                .ToList();

            lb_BlockedClients.BeginUpdate();
            lb_Clients.BeginUpdate();

            try
            {
                foreach (var host in toMove)
                {
                    if (lb_BlockedClients.Items.Cast<HostItem>().All(x => x.HostID != host.HostID))
                    {
                        lb_BlockedClients.Items.Add(host);
                        Database.ExecuteSafe(con =>
                        {
                            const string query = @"
                                INSERT INTO Log.ClientPolicy (HostID, Version, AllowUpdate, CreatedBy)
                                VALUES (@hostid, @version, 0, @createdby)";

                            using var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@hostid", host.HostID);
                            cmd.Parameters.AddWithValue("@version", lb_Versions.SelectedItem.ToString() ?? string.Empty);
                            cmd.Parameters.AddWithValue("@createdby", Person.Name);
                            cmd.ExecuteNonQuery();
                        });
                    }

                    lb_Clients.Items.Remove(host);
                }
            }
            finally
            {
                lb_BlockedClients.EndUpdate();
                lb_Clients.EndUpdate();
            }
        }
        private void btn_UnBlockClient_Click(object sender, EventArgs e)
        {
            if (lb_BlockedClients.SelectedItems.Count == 0)
                return;

            var toMove = lb_BlockedClients.SelectedItems
                .Cast<HostItem>()
                .ToList();

            lb_Clients.BeginUpdate();
            lb_BlockedClients.BeginUpdate();

            try
            {
                foreach (var host in toMove)
                {
                    // Ta bort blockeringen från masterlistans blocklista om du använder HashSet

                    // Lägg tillbaka i klientlistan
                    if (lb_Clients.Items.Cast<HostItem>().All(x => x.HostID != host.HostID))
                        lb_Clients.Items.Add(host);

                    // Ta bort från blocked listan
                    lb_BlockedClients.Items.Remove(host);

                    // --- Ta bort från databasen ---
                    Database.ExecuteSafe(con =>
                    {
                        using var cmd = new SqlCommand("DELETE FROM Log.ClientPolicy WHERE HostID = @hostid AND Version = @version", con);
                        cmd.Parameters.AddWithValue("@hostid", host.HostID);
                        cmd.Parameters.AddWithValue("@version", lb_Versions.SelectedItem.ToString() ?? string.Empty);
                        cmd.ExecuteNonQuery();
                    });
                }
            }
            finally
            {
                lb_Clients.EndUpdate();
                lb_BlockedClients.EndUpdate();
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
                            ROW_NUMBER() OVER
                                (PARTITION BY al.UserID ORDER BY al.Date DESC) AS rn
                        FROM Log.ActivityLog al
                        JOIN [User].Person p ON al.UserID = p.UserID
                        WHERE al.HostID = @hostid
                    ) t
                    WHERE rn = 1
                    ORDER BY Date DESC";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@hostid", hostId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new KeyValuePair<int, string>(
                            reader.GetInt32(reader.GetOrdinal("UserID")),
                            reader["Name"]?.ToString() ?? string.Empty
                        )
                    );
                }
                return result;
            });
        }
        private List<HostItem> GetBlockedClientsForVersion(string version)
        {
            return Database.ExecuteSafe(con =>
            {
                var result = new List<HostItem>();

                const string query = @"
                    SELECT g.HostID, g.HostName
                    FROM [Settings].General g
                    JOIN Log.ClientPolicy cp ON cp.HostID = g.HostID
                    WHERE cp.Version = @version
                      AND cp.AllowUpdate = 0
                    ORDER BY g.HostName";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@version", version);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new HostItem(
                        reader.GetInt32(reader.GetOrdinal("HostID")),
                        reader.GetString(reader.GetOrdinal("HostName"))
                    ));
                }

                return result;
            });
        }


        public class HostItem
        {
            public int HostID { get; }
            public string HostName { get; }

            public HostItem(int hostId, string hostName)
            {
                HostID = hostId;
                HostName = hostName;
            }

            public override string ToString()
            {
                return HostName; // Det som visas i ListBox
            }
        }

       
    }
}
