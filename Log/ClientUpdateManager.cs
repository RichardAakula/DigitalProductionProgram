using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DigitalProductionProgram.Log
{
    public partial class ClientUpdateManager : Form
    {
        // --- Masterlista för alla klienter ---
        private List<HostItem> _allClients = new();

        // --- Flagga för att undvika SelectedIndexChanged under listuppdatering ---
        private bool _suppressSelectionChanged = false;

        public ClientUpdateManager()
        {
            InitializeComponent();
            InitializeUsersOnClientListView();

            LoadClients();
            LoadVersions();
            LoadAllUsers();

            // Koppla filtertextbox
            tb_Filter.TextChanged += tb_Filter_TextChanged;
        }



        private void RefreshClientList()
        {
            lb_Clients.BeginUpdate();
            _suppressSelectionChanged = true;
            try
            {
                lb_Clients.Items.Clear();

                IEnumerable<HostItem> filtered = _allClients;

                string filter = tb_Filter.Text.Trim();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filtered = filtered.Where(c =>
                        c.HostName.Contains(filter, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var client in filtered)
                    lb_Clients.Items.Add(client);

                // Om CheckAll är ikryssad, markera alla synliga
                if (chk_CheckAllClients.Checked)
                {
                    lb_Clients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_Clients.Items.Count; i++)
                        lb_Clients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                _suppressSelectionChanged = false;
                lb_Clients.EndUpdate();
            }
        }
        private void InitializeUsersOnClientListView()
        {
            lv_UsersOnClient.View = View.Details;
            lv_UsersOnClient.FullRowSelect = true;
            lv_UsersOnClient.MultiSelect = false;
            lv_UsersOnClient.HideSelection = false;

            lv_UsersOnClient.Columns.Clear();
            lv_UsersOnClient.Columns.Add("UserID", 50, HorizontalAlignment.Left);
            lv_UsersOnClient.Columns.Add("Name", 200, HorizontalAlignment.Left);
        }
        private void LoadClients()
        {
            _allClients.Clear();

            var clients = Database.ExecuteSafe(con =>
            {
                var list = new List<HostItem>();
                const string query = @"
                    SELECT g.HostID, g.HostName
                    FROM [Settings].General g
                    WHERE EXISTS
                    (
                        SELECT 1
                        FROM Log.ActivityLog     al
                        WHERE al.HostID = g.HostID
                        AND al.Date >= DATEADD(YEAR, -1, GETDATE())
                    )
                    ORDER BY g.HostName";
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

            _allClients.AddRange(clients);

            RefreshClientList();
        }
        private void LoadVersions()
        {
            var versions = Database.ExecuteSafe(con =>
            {
                var list = new List<string>();
                const string query = @"
                    SELECT TOP (20) Version
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
        private void LoadAllUsers()
        {
            lb_AllUsers.Items.Clear();

            var users = Database.ExecuteSafe(con =>
            {
                var list = new List<KeyValuePair<int, string>>();

                const string query = @"SELECT UserID, Name FROM [User].Person ORDER BY Name";

                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new KeyValuePair<int, string>(
                        reader.GetInt32(reader.GetOrdinal("UserID")),
                        reader["Name"]?.ToString() ?? string.Empty
                    ));
                }

                return list;
            });

            // Fyll lb_AllUsers med namn
            foreach (var user in users)
                lb_AllUsers.Items.Add(user);

            // Om du vill kan du visa endast namn i ListBox
            lb_AllUsers.DisplayMember = "Value";
            lb_AllUsers.ValueMember = "Key";
        }

        private void lb_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;

            var selectedHosts = lb_Clients.SelectedItems
                .Cast<HostItem>()
                .Select(h => h.HostID)
                .ToList();

            lv_UsersOnClient.BeginUpdate();
            try
            {
                lv_UsersOnClient.Items.Clear();

                if (selectedHosts.Count == 0)
                    return;

                var users = GetUsersForHosts(selectedHosts);

                foreach (var user in users)
                {
                    var item = new ListViewItem(user.UserID.ToString());
                    item.SubItems.Add(user.Name);
                    item.SubItems.Add(user.LastActivity.ToString("yyyy-MM-dd HH:mm"));

                    lv_UsersOnClient.Items.Add(item);
                }
            }
            finally
            {
                lv_UsersOnClient.EndUpdate();
            }
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
                    // Lägg till i blocked list
                    lb_BlockedClients.Items.Add(client);

                    // Ta bort från masterlistan
                    _allClients.RemoveAll(x => x.HostID == client.HostID);
                }
            }
            finally
            {
                lb_Clients.EndUpdate();
                lb_BlockedClients.EndUpdate();
            }

            RefreshClientList();
        }
        private void lb_AllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;
            lb_Clients.BeginUpdate();
            try
            {
                lb_Clients.Items.Clear();

                IEnumerable<HostItem> filtered = _allClients;

                // Kolla om några användare är markerade
                var selectedUsers = lb_AllUsers.SelectedItems.Cast<KeyValuePair<int, string>>().ToList();

                if (selectedUsers.Any())
                {
                    var hostIdsForUsers = new HashSet<int>();

                    foreach (var user in selectedUsers)
                    {
                        // Hämta top 50 HostID som användaren jobbat mest på senaste året
                        var userHostIds = Database.ExecuteSafe(con =>
                        {
                            var list = new List<int>();
                            const string query = @"
                        SELECT TOP(50) HostID, COUNT(*) AS WorkCount
                        FROM Log.ActivityLog
                        WHERE UserID = @userid
                          AND Date >= DATEADD(YEAR, -1, GETDATE())
                        GROUP BY HostID
                        ORDER BY WorkCount DESC";

                            using var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@userid", user.Key);
                            using var reader = cmd.ExecuteReader();
                            while (reader.Read())
                                list.Add(reader.GetInt32(reader.GetOrdinal("HostID")));
                            return list;
                        }) ?? new List<int>();

                        // Lägg till i en HashSet för union
                        foreach (var h in userHostIds)
                            hostIdsForUsers.Add(h);
                    }

                    // Filtrera masterlistan baserat på alla valda användares HostID
                    filtered = filtered.Where(c => hostIdsForUsers.Contains(c.HostID));
                }

                // Kombinera med tb_Filter om text finns
                string textFilter = tb_Filter.Text.Trim();
                if (!string.IsNullOrWhiteSpace(textFilter))
                {
                    filtered = filtered.Where(c =>
                        c.HostName.Contains(textFilter, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var client in filtered)
                    lb_Clients.Items.Add(client);

                // Om CheckAll är ikryssad, markera alla synliga
                if (chk_CheckAllClients.Checked)
                {
                    lb_Clients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_Clients.Items.Count; i++)
                        lb_Clients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                _suppressSelectionChanged = false;
                lb_Clients.EndUpdate();
            }
        }

        private void chk_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;

            lb_Clients.BeginUpdate();
            try
            {
                lb_Clients.ClearSelected();

                if (chk_CheckAllClients.Checked)
                {
                    for (int i = 0; i < lb_Clients.Items.Count; i++)
                        lb_Clients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                lb_Clients.EndUpdate();
                _suppressSelectionChanged = false;
            }

            // 🔥 TRIGGA EN ENDA uppdatering manuellt
            lb_Clients_SelectedIndexChanged(lb_Clients, EventArgs.Empty);
        }
        private void chk_CheckAllBlockedClients_CheckedChanged(object sender, EventArgs e)
        {
            lb_BlockedClients.BeginUpdate();
            try
            {
                lb_BlockedClients.ClearSelected();

                if (chk_CheckAllBlockedClients.Checked)
                {
                    for (int i = 0; i < lb_BlockedClients.Items.Count; i++)
                        lb_BlockedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                lb_BlockedClients.EndUpdate();
            }
        }
        private void btn_BlockClient_Click(object sender, EventArgs e)
        {
            var version = lb_Versions.SelectedItem?.ToString();
            if (lb_Clients.SelectedItems.Count == 0 || string.IsNullOrEmpty(version))
                return;

            // Hämta alla valda klienter
            var toMove = lb_Clients.SelectedItems.Cast<HostItem>().ToList();
            if (toMove.Count == 0)
                return;

            // --- 1. DB: Batch insert med transaktion ---
            Database.ExecuteSafe(con =>
            {
                using var tran = con.BeginTransaction();
                try
                {
                    const string query = @"
                INSERT INTO Log.ClientPolicy (HostID, Version, CreatedBy)
                VALUES (@hostid, @version, @createdby)";

                    using var cmd = new SqlCommand(query, con, tran);
                    cmd.Parameters.Add("@hostid", SqlDbType.Int);
                    cmd.Parameters.Add("@version", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@createdby", SqlDbType.NVarChar);

                    foreach (var host in toMove)
                    {
                        cmd.Parameters["@hostid"].Value = host.HostID;
                        cmd.Parameters["@version"].Value = version;
                        cmd.Parameters["@createdby"].Value = Person.Name;
                        cmd.ExecuteNonQuery();
                    }

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            });

            // --- 2. UI: batcha ListBox-uppdatering ---
            lb_BlockedClients.BeginUpdate();
            lb_Clients.BeginUpdate();
            try
            {
                // Ta alla redan blockerade hostIDs
                var blockedIds = new HashSet<int>(lb_BlockedClients.Items.Cast<HostItem>().Select(x => x.HostID));

                // Lägg till nya hostar i blocked list
                var toAddToBlocked = toMove.Where(h => !blockedIds.Contains(h.HostID)).ToArray();
                if (toAddToBlocked.Length > 0)
                {
                    lb_BlockedClients.Items.AddRange(toAddToBlocked);

                    // Ta bort dem från _allClients
                    _allClients = _allClients.Except(toAddToBlocked).ToList();
                }

                // --- Fyll om lb_Clients från _allClients istället för Remove loop ---
                lb_Clients.Items.Clear();
                lb_Clients.Items.AddRange(_allClients.ToArray());
            }
            finally
            {
                lb_BlockedClients.EndUpdate();
                lb_Clients.EndUpdate();
            }

            // Uppdatera UI och ev filter
            RefreshClientList();
        }


        private void btn_UnBlockClient_Click(object sender, EventArgs e)
        {
            if (lb_BlockedClients.SelectedItems.Count == 0)
                return;

            var toMove = lb_BlockedClients.SelectedItems.Cast<HostItem>().ToList();

            lb_Clients.BeginUpdate();
            lb_BlockedClients.BeginUpdate();
            try
            {
                foreach (var host in toMove)
                {
                    if (_allClients.All(x => x.HostID != host.HostID))
                        _allClients.Add(host);

                    lb_BlockedClients.Items.Remove(host);

                    Database.ExecuteSafe(con =>
                    {
                        using var cmd = new SqlCommand(
                            "DELETE FROM Log.ClientPolicy WHERE HostID = @hostid AND Version = @version", con);
                        cmd.Parameters.AddWithValue("@hostid", host.HostID);
                        cmd.Parameters.AddWithValue("@version", lb_Versions.SelectedItem?.ToString() ?? string.Empty);
                        cmd.ExecuteNonQuery();
                    });
                }
            }
            finally
            {
                lb_Clients.EndUpdate();
                lb_BlockedClients.EndUpdate();
            }

            RefreshClientList();
        }
        private void tb_Filter_TextChanged(object sender, EventArgs e)
        {
            RefreshClientList();
        }


        private List<KeyValuePair<int, string>> GetUsersForHost(int hostId)
        {
            return Database.ExecuteSafe(con =>
            {
                var result = new List<KeyValuePair<int, string>>();
                const string query = @"
                    SELECT UserID, Name, Date
                    FROM (
                        SELECT al.UserID, p.Name, al.Date,
                               ROW_NUMBER() OVER (PARTITION BY al.UserID ORDER BY al.Date DESC) AS rn
                        FROM Log.ActivityLog al
                        JOIN [User].Person p ON al.UserID = p.UserID
                        WHERE al.HostID = @hostid
                            AND al.Date >= DATEADD(YEAR, -1, GETDATE())
                    ) t
                    WHERE rn = 1
                    ORDER BY Date DESC";

                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@hostid", hostId);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new KeyValuePair<int, string>(
                        reader.GetInt32(reader.GetOrdinal("UserID")),
                        reader["Name"]?.ToString() ?? string.Empty
                    ));
                }
                return result;
            });
        }
        private List<(int UserID, string Name, DateTime LastActivity)> GetUsersForHosts(IEnumerable<int> hostIds)
        {
            return Database.ExecuteSafe(con =>
            {
                var result = new List<(int, string, DateTime)>();

                var ids = hostIds.ToList();
                if (ids.Count == 0)
                    return result;

                var parameters = ids
                    .Select((id, i) => $"@h{i}")
                    .ToArray();

                var query = $@"
            SELECT 
                al.UserID,
                p.Name,
                MAX(al.Date) AS LastActivity
            FROM Log.ActivityLog al
            JOIN [User].Person p ON al.UserID = p.UserID
            WHERE al.HostID IN ({string.Join(",", parameters)})
              AND al.Date >= DATEADD(YEAR, -1, GETDATE())
            GROUP BY al.UserID, p.Name
            ORDER BY MAX(al.Date) DESC";

                using var cmd = new SqlCommand(query, con);

                for (int i = 0; i < ids.Count; i++)
                    cmd.Parameters.AddWithValue(parameters[i], ids[i]);

                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDateTime(2)
                    ));
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

        public class HostItem(int hostId, string hostName)
        {
            public int HostID { get; } = hostId;
            public string HostName { get; } = hostName;

            public override string ToString() => HostName;
        }

        
    }
}
