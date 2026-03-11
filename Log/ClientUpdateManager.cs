using DigitalProductionProgram.DatabaseManagement;
using LoadingProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.Log
{
    public partial class ClientUpdateManager : Form
    {
        private List<HostItem> _allClients = new();
        private List<HostItem> _allBlockedClients = new();
        private readonly List<string> _allProdLines = new();

        private bool _suppressSelectionChanged;
        private CancellationTokenSource _usersOnClientCts;

        public ClientUpdateManager()
        {
            InitializeComponent();
            InitializeUsersOnClientListView();
            Opacity = 0;
            ShowInTaskbar = false;

            Load += async (_, __) => await InitializeDataAsync();

            // Koppla filtertextbox
            tb_FilterAllClients.TextChanged += tb_Filter_TextChanged;
            tb_FilterBlockedClients.TextChanged += tb_FilterBlockedClients_TextChanged;
        }

        private async Task InitializeDataAsync()
        {
            SetLoadingState(true);
            using var pbar = new LoadingProgressBar();
            try
            {
                pbar.Show();
                pbar.TopMost = true;
                pbar.BringToFront();
                pbar.Activate();
                pbar.Set_ValueProgressBar(0, "Startar Client Update Manager...", isOkRefresh: true);
                await Task.Yield();

                pbar.Set_ValueProgressBar(15, "Laddar klienter...", isOkRefresh: true);
                LoadClients();
                await Task.Yield();

                pbar.Set_ValueProgressBar(45, "Laddar produktionslinjer...", isOkRefresh: true);
                LoadProdLines();
                await Task.Yield();

                pbar.Set_ValueProgressBar(70, "Laddar versioner...", isOkRefresh: true);
                LoadVersions();
                await Task.Yield();

                pbar.Set_ValueProgressBar(90, "Laddar anvÃƒÆ’Ã‚Â¤ndare...", isOkRefresh: true);
                LoadAllUsers();
                await Task.Yield();

                pbar.Set_ValueProgressBar(100, "Klart", isOkRefresh: true);
                await Task.Delay(120);
            }
            finally
            {
                if (!pbar.IsDisposed)
                {
                    pbar.TopMost = false;
                    pbar.Close();
                }

                SetLoadingState(false);
                ShowInTaskbar = true;
                Opacity = 1;
                Activate();
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
            lb_AllowedClients.Enabled = !isLoading;
            lb_ProdLines.Enabled = !isLoading;
            lb_Versions.Enabled = !isLoading;
            lb_AllUsers.Enabled = !isLoading;
            lb_BlockedClients.Enabled = !isLoading;
            btn_BlockClient.Enabled = !isLoading;
            btn_UnBlockClient.Enabled = !isLoading;
        }



        private void RefreshClientList()
        {
            lb_AllowedClients.BeginUpdate();
            _suppressSelectionChanged = true;
            try
            {
                lb_AllowedClients.Items.Clear();

                IEnumerable<HostItem> filtered = _allClients;

                string filter = tb_FilterAllClients.Text.Trim();
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filtered = filtered.Where(c =>
                        c.HostName.Contains(filter, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var client in filtered)
                    lb_AllowedClients.Items.Add(client);

                // Om CheckAll ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤r ikryssad, markera alla synliga
                if (chk_CheckAllClients.Checked)
                {
                    lb_AllowedClients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_AllowedClients.Items.Count; i++)
                        lb_AllowedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                _suppressSelectionChanged = false;
                lb_AllowedClients.EndUpdate();
            }
        }
        private void RefreshBlockedClientList()
        {
            lb_BlockedClients.BeginUpdate();
            try
            {
                lb_BlockedClients.Items.Clear();

                IEnumerable<HostItem> filtered = _allBlockedClients;

                string filter = tb_FilterBlockedClients.Text.Trim();

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    filtered = filtered.Where(c =>
                        c.HostName.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                        c.HostID.ToString().Contains(filter));
                }

                lb_BlockedClients.Items.AddRange(filtered.ToArray());
            }
            finally
            {
                lb_BlockedClients.EndUpdate();
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
            lv_UsersOnClient.Columns.Add("Name", 150, HorizontalAlignment.Left);
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

        private void LoadProdLines()
        {
            _allProdLines.Clear();

            lb_ProdLines.BeginUpdate();
            try
            {
                lb_ProdLines.Items.Clear();

                var prodLines = Database.ExecuteSafe(con =>
                {
                    var list = new List<string>();
                    const string query = @"
                        SELECT DISTINCT o.ProdLine
                        FROM [Order].MainData o
                        WHERE o.ProdLine IS NOT NULL
                            AND EXISTS
                            (
                                SELECT 1
                                FROM Log.ActivityLog al
                                WHERE al.OrderID = o.OrderID
                                    AND al.HostID IS NOT NULL
                                    AND al.Date >= DATEADD(MONTH, -2, GETDATE())
                            )
                        ORDER BY o.ProdLine";

                    using var cmd = new SqlCommand(query, con);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(reader.GetOrdinal("ProdLine")));
                    }
                    return list;
                });

                if (prodLines != null)
                    _allProdLines.AddRange(prodLines);

                foreach (var pl in _allProdLines)
                    lb_ProdLines.Items.Add(pl);
            }
            finally
            {
                lb_ProdLines.EndUpdate();
            }
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
            if (users != null)
            {
                foreach (var user in users)
                    lb_AllUsers.Items.Add(user);
            }

            // Om du vill kan du visa endast namn i ListBox
            lb_AllUsers.DisplayMember = "Value";
            lb_AllUsers.ValueMember = "Key";
        }

        private async void lb_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;

            _suppressSelectionChanged = true;
            try
            {
                if (lb_BlockedClients.SelectedItems.Count > 0)
                    lb_BlockedClients.ClearSelected();
            }
            finally
            {
                _suppressSelectionChanged = false;
            }

            var selectedHosts = lb_AllowedClients.SelectedItems
                .Cast<HostItem>()
                .Select(h => h.HostID)
                .ToList();

            await LoadUsersForSelectedHostsAsync(selectedHosts);
        }
        private async void lb_BlockedClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;

            _suppressSelectionChanged = true;
            try
            {
                if (lb_AllowedClients.SelectedItems.Count > 0)
                    lb_AllowedClients.ClearSelected();
            }
            finally
            {
                _suppressSelectionChanged = false;
            }

            var selectedHosts = lb_BlockedClients.SelectedItems
                .Cast<HostItem>()
                .Select(h => h.HostID)
                .ToList();

            await LoadUsersForSelectedHostsAsync(selectedHosts);
        }

        private async Task LoadUsersForSelectedHostsAsync(List<int> selectedHosts)
        {
            _usersOnClientCts?.Cancel();
            _usersOnClientCts?.Dispose();
            _usersOnClientCts = new CancellationTokenSource();
            var token = _usersOnClientCts.Token;

            lv_UsersOnClient.BeginUpdate();
            try
            {
                lv_UsersOnClient.Items.Clear();

                if (selectedHosts.Count == 0)
                    return;

                List<(int UserID, string Name, DateTime LastActivity)> users;
                try
                {
                    users = await GetUsersForHostsAsync(selectedHosts, token);
                }
                catch (OperationCanceledException)
                {
                    return;
                }

                if (token.IsCancellationRequested || users == null)
                    return;

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

        private void lb_ProdLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;

            _suppressSelectionChanged = true;
            lb_AllowedClients.BeginUpdate();
            try
            {
                lb_AllowedClients.Items.Clear();

                IEnumerable<HostItem> filtered = _allClients;

                // Kolla om nÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥gra ProductionLines ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤r markerade
                var selectedProdLines = lb_ProdLines.SelectedItems.Cast<string>().ToList();

                if (selectedProdLines.Any())
                {
                    var hostIdsForProdLines = new HashSet<int>();

                    foreach (var prodLine in selectedProdLines)
                    {
                        // HÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤mta top 50 HostID som anvÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤nts med denna ProductionLine senaste ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥ret
                        var hostIds = Database.ExecuteSafe(con =>
                        {
                            var list = new List<int>();
                            const string query = @"
                        SELECT TOP(50) al.HostID, COUNT(*) AS WorkCount
                        FROM Log.ActivityLog al
                        INNER JOIN [Order].MainData o ON al.OrderID = o.OrderID
                        WHERE o.ProdLine = @prodline
                            AND al.Date >= DATEADD(MONTH, -2, GETDATE())
                            AND al.HostID IS NOT NULL
                        GROUP BY al.HostID
                        ORDER BY WorkCount DESC";

                            using var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@prodline", prodLine);
                            using var reader = cmd.ExecuteReader();
                            while (reader.Read())
                                list.Add(reader.GetInt32(reader.GetOrdinal("HostID")));
                            return list;
                        });

                        foreach (var h in hostIds)
                            hostIdsForProdLines.Add(h);
                    }

                    // Filtrera masterlistan baserat pÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥ alla valda ProductionLines
                    filtered = filtered.Where(c => hostIdsForProdLines.Contains(c.HostID));
                }

                // Kombinera med tb_Filter om text finns
                string textFilter = tb_FilterAllClients.Text.Trim();
                if (!string.IsNullOrWhiteSpace(textFilter))
                {
                    filtered = filtered.Where(c =>
                        c.HostName.Contains(textFilter, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var client in filtered)
                    lb_AllowedClients.Items.Add(client);

                // Om CheckAll ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤r ikryssad, markera alla synliga
                if (chk_CheckAllClients.Checked)
                {
                    lb_AllowedClients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_AllowedClients.Items.Count; i++)
                        lb_AllowedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                _suppressSelectionChanged = false;
                lb_AllowedClients.EndUpdate();
            }
        }

        private void lb_Versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Versions.SelectedItem is not string version)
                return;

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 1. ÃƒÆ’Ã†â€™ÃƒÂ¢Ã¢â€šÂ¬Ã‚Â¦terstÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤ll masterlistan fÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¶r Clients helt (inkl. UI)
            LoadClients();

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 2. HÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤mta blockerade klienter fÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¶r vald version
            var blockedClients = GetBlockedClientsForVersion(version);

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 3. Uppdatera masterlistan fÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¶r blockerade klienter
            _allBlockedClients = blockedClients.ToList();

            lb_BlockedClients.BeginUpdate();
            lb_AllowedClients.BeginUpdate();
            try
            {
                // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 4. Fyll Blocked-listan frÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥n masterlistan
                lb_BlockedClients.Items.Clear();
                lb_BlockedClients.Items.AddRange(_allBlockedClients.ToArray());

                // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 5. Ta bort blockerade frÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥n _allClients
                if (_allBlockedClients.Count > 0)
                {
                    var blockedIds = new HashSet<int>(_allBlockedClients.Select(x => x.HostID));
                    _allClients = _allClients
                        .Where(c => !blockedIds.Contains(c.HostID))
                        .ToList();
                }
            }
            finally
            {
                lb_AllowedClients.EndUpdate();
                lb_BlockedClients.EndUpdate();
            }

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 6. Refreshar klientlistan med aktuella filter (tb_Filter)
            RefreshClientList();

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ 7. Refreshar Blocked-listan med aktuellt filter (tb_FilterBlockedClients)
            RefreshBlockedClientList();
        }
        private void lb_AllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;
            lb_AllowedClients.BeginUpdate();
            try
            {
                lb_AllowedClients.Items.Clear();

                IEnumerable<HostItem> filtered = _allClients;

                // Kolla om nÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥gra anvÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤ndare ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤r markerade
                var selectedUsers = lb_AllUsers.SelectedItems.Cast<KeyValuePair<int, string>>().ToList();

                if (selectedUsers.Any())
                {
                    var hostIdsForUsers = new HashSet<int>();

                    foreach (var user in selectedUsers)
                    {
                        // HÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤mta top 50 HostID som anvÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤ndaren jobbat mest pÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥ senaste ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥ret
                        var userHostIds = Database.ExecuteSafe(con =>
                        {
                            var list = new List<int>();
                            const string query = @"
                                SELECT TOP(50) HostID, COUNT(*) AS WorkCount
                                FROM Log.ActivityLog
                                WHERE UserID = @userid
                                    AND Date >= DATEADD(YEAR, -1, GETDATE())
                                    AND HostID IS NOT NULL
                                GROUP BY HostID
                                ORDER BY WorkCount DESC";

                            using var cmd = new SqlCommand(query, con);
                            cmd.Parameters.AddWithValue("@userid", user.Key);
                            using var reader = cmd.ExecuteReader();
                            while (reader.Read())
                                list.Add(reader.GetInt32(reader.GetOrdinal("HostID")));
                            return list;
                        });

                        // LÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤gg till i en HashSet fÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¶r union
                        foreach (var h in userHostIds)
                            hostIdsForUsers.Add(h);
                    }

                    // Filtrera masterlistan baserat pÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥ alla valda anvÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤ndares HostID
                    filtered = filtered.Where(c => hostIdsForUsers.Contains(c.HostID));
                }

                // Kombinera med tb_Filter om text finns
                string textFilter = tb_FilterAllClients.Text.Trim();
                if (!string.IsNullOrWhiteSpace(textFilter))
                {
                    filtered = filtered.Where(c =>
                        c.HostName.Contains(textFilter, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var client in filtered)
                    lb_AllowedClients.Items.Add(client);

                // Om CheckAll ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤r ikryssad, markera alla synliga
                if (chk_CheckAllClients.Checked)
                {
                    lb_AllowedClients.SelectedIndices.Clear();
                    for (int i = 0; i < lb_AllowedClients.Items.Count; i++)
                        lb_AllowedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                _suppressSelectionChanged = false;
                lb_AllowedClients.EndUpdate();
            }
        }

        private void chk_CheckAllClients_CheckedChanged(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;

            lb_AllowedClients.BeginUpdate();
            try
            {
                lb_AllowedClients.ClearSelected();

                if (chk_CheckAllClients.Checked)
                {
                    for (int i = 0; i < lb_AllowedClients.Items.Count; i++)
                        lb_AllowedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                lb_AllowedClients.EndUpdate();
                _suppressSelectionChanged = false;
            }

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ TRIGGA EN ENDA uppdatering manuellt
            lb_Clients_SelectedIndexChanged(lb_AllowedClients, EventArgs.Empty);
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
            if (lb_AllowedClients.SelectedItems.Count == 0 || string.IsNullOrEmpty(version))
                return;

            // HÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤mta valda klienter
            var toBlock = lb_AllowedClients.SelectedItems.Cast<HostItem>().ToList();
            if (toBlock.Count == 0)
                return;

            // --- 1. DB UPDATE ---
            Database.ExecuteSafe(con =>
            {
                using var tran = con.BeginTransaction();
                try
                {
                    const string sql = @"
                INSERT INTO Log.ClientPolicy (HostID, Version, CreatedBy)
                VALUES (@hostid, @version, @createdby);";

                    using var cmd = new SqlCommand(sql, con, tran);
                    cmd.Parameters.Add("@hostid", SqlDbType.Int);
                    cmd.Parameters.Add("@version", SqlDbType.NVarChar);
                    cmd.Parameters.Add("@createdby", SqlDbType.NVarChar);

                    foreach (var host in toBlock)
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

            // --- 2. MASTERLIST UPPDATERING ---
            foreach (var host in toBlock)
            {
                // flytta till blocked masterlist
                if (_allBlockedClients.All(x => x.HostID != host.HostID))
                    _allBlockedClients.Add(host);

                // ta bort frÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥n clients masterlist
                _allClients.RemoveAll(x => x.HostID == host.HostID);
            }

            // --- 3. UI UPPDATERING ---
            lb_BlockedClients.BeginUpdate();
            lb_AllowedClients.BeginUpdate();
            try
            {
                // fyll blocked-listan
                lb_BlockedClients.Items.Clear();
                lb_BlockedClients.Items.AddRange(_allBlockedClients.ToArray());

                // fyll client-listan (filtrerat)
                RefreshClientList();
            }
            finally
            {
                lb_AllowedClients.EndUpdate();
                lb_BlockedClients.EndUpdate();
            }

            // --- 4. Filtrera blocked-list efter ev. textfilter ---
            RefreshBlockedClientList();
        }
        private void btn_UnBlockClient_Click(object sender, EventArgs e)
        {
            if (lb_BlockedClients.SelectedItems.Count == 0)
                return;

            var selected = lb_BlockedClients.SelectedItems.Cast<HostItem>().ToList();
            string version = lb_Versions.SelectedItem?.ToString() ?? "";

            // --- 1. DB DELETE ---
            Database.ExecuteSafe(con =>
            {
                using var cmd = new SqlCommand(
                    @"DELETE FROM Log.ClientPolicy WHERE HostID = @hostid AND Version = @version", con);

                cmd.Parameters.Add("@hostid", SqlDbType.Int);
                cmd.Parameters.Add("@version", SqlDbType.NVarChar).Value = version;

                foreach (var host in selected)
                {
                    cmd.Parameters["@hostid"].Value = host.HostID;
                    cmd.ExecuteNonQuery();
                }
            });

            // --- 2. MASTERLIST UPDATE ---
            foreach (var host in selected)
            {
                // Ta bort ur blocked masterlist
                _allBlockedClients.RemoveAll(x => x.HostID == host.HostID);

                // LÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤gg tillbaka i client-masterlist om sÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤kert
                if (_allClients.All(x => x.HostID != host.HostID))
                    _allClients.Add(host);
            }

            // --- 3. UI UPDATE ---
            lb_BlockedClients.BeginUpdate();
            lb_AllowedClients.BeginUpdate();
            try
            {
                // fyll blocked-listan
                lb_BlockedClients.Items.Clear();
                lb_BlockedClients.Items.AddRange(_allBlockedClients.ToArray());

                // fyll client list (med filter)
                RefreshClientList();
            }
            finally
            {
                lb_BlockedClients.EndUpdate();
                lb_AllowedClients.EndUpdate();
            }

            // --- 4. SÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¶kfilter pÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¥ blocked-list ---
            RefreshBlockedClientList();
        }


        private void tb_Filter_TextChanged(object sender, EventArgs e)
        {
            RefreshClientList();
        }
        private void tb_FilterBlockedClients_TextChanged(object sender, EventArgs e)
        {
            RefreshBlockedClientList();
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
        private async Task<List<(int UserID, string Name, DateTime LastActivity)>> GetUsersForHostsAsync(IEnumerable<int> hostIds, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return new List<(int UserID, string Name, DateTime LastActivity)>();

            var users = await Task.Run(() =>
            {
                if (cancellationToken.IsCancellationRequested)
                    return new List<(int UserID, string Name, DateTime LastActivity)>();

                return GetUsersForHosts(hostIds);
            });

            if (cancellationToken.IsCancellationRequested)
                return new List<(int UserID, string Name, DateTime LastActivity)>();

            return users;
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

            public override string ToString()
            {
                return $"{HostName} (ID: {HostID})";
            }

        }

        private void label_AllUsers_Click(object sender, EventArgs e)
        {
            lb_AllUsers.ClearSelected();
        }
        private void label_ProdLines_Click(object sender, EventArgs e)
        {
            lb_ProdLines.ClearSelected();
        }
    }
}

