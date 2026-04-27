using DigitalProductionProgram.DatabaseManagement;
using LoadingProgressBar = DigitalProductionProgram.ControlsManagement.CustomProgressBar;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalProductionProgram.Log
{
    public partial class ClientUpdateManager : Form
    {
        private const int GwlExstyle = -20;
        private const int WsExLayered = 0x00080000;
        private readonly List<HostItem> _allKnownClients = new();
        private readonly Dictionary<string, List<HostItem>> _blockedClientsByVersion = new(StringComparer.OrdinalIgnoreCase);
        private List<HostItem> _allClients = new();
        private List<HostItem> _allBlockedClients = new();
        private readonly List<string> _allProdLines = new();
        private readonly List<KeyValuePair<int, string>> _allUsers = new();
        private readonly Dictionary<ListView, (int Column, System.Windows.Forms.SortOrder Order)> _listViewSortStates = new();
        private bool _suppressSelectionChanged;
        private CancellationTokenSource _usersOnClientCts;
        private CancellationTokenSource _prodLinesOnClientCts;
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern int GetWindowLong(IntPtr hWnd,int nIndex);
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        private static extern int SetWindowLong(IntPtr hWnd,int nIndex,int dwNewLong);
        public ClientUpdateManager()
        {
            InitializeComponent();
            InitializeUsersOnClientListView();
            InitializeProdLinesOnClientListView();
            InitializeClientListViews();
            Opacity = 0;
            ShowInTaskbar = false;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw,true);
            UpdateStyles();
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(tlp_Main);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lb_AllUsers);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lb_ProdLines);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lv_AllowedClients);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lv_BlockedClients);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lb_Versions);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lv_UsersOnClient);
            DigitalProductionProgram.ControlsManagement.DrawingControl.EnableDoubleBuffer(lv_ProdLinesOnClient);
            Load += async (_, __) => await InitializeDataAsync();
            lv_AllowedClients.ColumnClick += ListView_ColumnClick;
            lv_BlockedClients.ColumnClick += ListView_ColumnClick;
            lv_UsersOnClient.ColumnClick += ListView_ColumnClick;
            lv_ProdLinesOnClient.ColumnClick += ListView_ColumnClick;
            tb_FilterUsersProdLines.TextChanged += tb_FilterUsersProdLines_TextChanged;
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

                pbar.Set_ValueProgressBar(90, "Laddar användare...", isOkRefresh: true);
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
                RemoveLayeredWindowStyle();
                Activate();
            }
        }

        private void SetLoadingState(bool isLoading)
        {
            Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
            lv_AllowedClients.Enabled = !isLoading;
            lb_ProdLines.Enabled = !isLoading;
            lb_Versions.Enabled = !isLoading;
            lb_AllUsers.Enabled = !isLoading;
            lv_BlockedClients.Enabled = !isLoading;
            lv_UsersOnClient.Enabled = !isLoading;
            lv_ProdLinesOnClient.Enabled = !isLoading;
            tb_FilterUsersProdLines.Enabled = !isLoading;
            tb_FilterAllClients.Enabled = !isLoading;
            tb_FilterBlockedClients.Enabled = !isLoading;
            btn_BlockClient.Enabled = !isLoading;
            btn_UnBlockClient.Enabled = !isLoading;
        }
        private void RemoveLayeredWindowStyle()
        {
            if (!IsHandleCreated)
                return;
            int exStyle = GetWindowLong(Handle,GwlExstyle);
            if ((exStyle & WsExLayered) != 0)
                SetWindowLong(Handle,GwlExstyle,exStyle & ~WsExLayered);
        }
        private void RefreshUsersAndProdLines()
        {
            var userFilter = tb_FilterUsersProdLines.Text.Trim();
            var selectedUserIds = lb_AllUsers.SelectedItems.Cast<KeyValuePair<int, string>>().Select(x => x.Key).ToHashSet();
            var selectedProdLines = lb_ProdLines.SelectedItems.Cast<string>().ToHashSet(StringComparer.OrdinalIgnoreCase);

            _suppressSelectionChanged = true;
            lb_AllUsers.BeginUpdate();
            lb_ProdLines.BeginUpdate();
            try
            {
                lb_AllUsers.Items.Clear();
                lb_ProdLines.Items.Clear();

                IEnumerable<KeyValuePair<int, string>> filteredUsers = _allUsers;
                IEnumerable<string> filteredProdLines = _allProdLines;

                if (!string.IsNullOrWhiteSpace(userFilter))
                {
                    filteredUsers = filteredUsers.Where(user =>
                        user.Value.Contains(userFilter, StringComparison.OrdinalIgnoreCase) ||
                        user.Key.ToString().Contains(userFilter, StringComparison.OrdinalIgnoreCase));
                    filteredProdLines = filteredProdLines.Where(prodLine =>
                        prodLine.Contains(userFilter, StringComparison.OrdinalIgnoreCase));
                }

                foreach (var user in filteredUsers)
                {
                    int index = lb_AllUsers.Items.Add(user);
                    if (selectedUserIds.Contains(user.Key))
                        lb_AllUsers.SelectedIndices.Add(index);
                }

                foreach (var prodLine in filteredProdLines)
                {
                    int index = lb_ProdLines.Items.Add(prodLine);
                    if (selectedProdLines.Contains(prodLine))
                        lb_ProdLines.SelectedIndices.Add(index);
                }
            }
            finally
            {
                lb_ProdLines.EndUpdate();
                lb_AllUsers.EndUpdate();
                _suppressSelectionChanged = false;
            }

            RefreshClientListsFromSelections();
        }
        private void RefreshClientListsFromSelections()
        {
            var selectedUsers = lb_AllUsers.SelectedItems.Cast<KeyValuePair<int, string>>().ToList();
            var selectedProdLines = lb_ProdLines.SelectedItems.Cast<string>().ToList();
            var hostUsageCountsForUsers = GetHostUsageCountsForSelectedUsers(selectedUsers.Select(x => x.Key));
            var hostIdsForSelectedUsers = hostUsageCountsForUsers.Keys.ToHashSet();
            var hostIdsForProdLines = GetHostIdsForSelectedProdLines(selectedProdLines);
            lv_AllowedClients.BeginUpdate();
            lv_BlockedClients.BeginUpdate();
            _suppressSelectionChanged = true;
            try
            {
                IEnumerable<HostItem> filteredAllowed = _allClients;
                IEnumerable<HostItem> filteredBlocked = _allBlockedClients;
                if (selectedUsers.Count > 0)
                {
                    filteredAllowed = filteredAllowed.Where(c => hostIdsForSelectedUsers.Contains(c.HostID));
                    filteredBlocked = filteredBlocked.Where(c => hostIdsForSelectedUsers.Contains(c.HostID));
                }
                if (selectedProdLines.Count > 0)
                {
                    filteredAllowed = filteredAllowed.Where(c => hostIdsForProdLines.Contains(c.HostID));
                    filteredBlocked = filteredBlocked.Where(c => hostIdsForProdLines.Contains(c.HostID));
                }
                string allowedFilter = tb_FilterAllClients.Text.Trim();
                if (!string.IsNullOrWhiteSpace(allowedFilter))
                {
                    filteredAllowed = filteredAllowed.Where(c =>
                        c.HostName.Contains(allowedFilter, StringComparison.OrdinalIgnoreCase) ||
                        c.CurrentVersion.Contains(allowedFilter, StringComparison.OrdinalIgnoreCase) ||
                        c.HostID.ToString().Contains(allowedFilter));
                }
                string blockedFilter = tb_FilterBlockedClients.Text.Trim();
                if (!string.IsNullOrWhiteSpace(blockedFilter))
                {
                    filteredBlocked = filteredBlocked.Where(c =>
                        c.HostName.Contains(blockedFilter, StringComparison.OrdinalIgnoreCase) ||
                        c.CurrentVersion.Contains(blockedFilter, StringComparison.OrdinalIgnoreCase) ||
                        c.HostID.ToString().Contains(blockedFilter));
                }
                if (hostUsageCountsForUsers.Count > 0)
                {
                    filteredAllowed = OrderClientsByUsage(filteredAllowed, hostUsageCountsForUsers);
                    filteredBlocked = OrderClientsByUsage(filteredBlocked, hostUsageCountsForUsers);
                }
                PopulateClientListView(lv_AllowedClients,filteredAllowed,chk_CheckAllClients.Checked);
                PopulateClientListView(lv_BlockedClients,filteredBlocked,chk_CheckAllBlockedClients.Checked);
                ApplyStoredSort(lv_AllowedClients);
                ApplyStoredSort(lv_BlockedClients);
            }
            finally
            {
                _suppressSelectionChanged = false;
                lv_BlockedClients.EndUpdate();
                lv_AllowedClients.EndUpdate();
            }
        }
        private Dictionary<int, int> GetHostUsageCountsForSelectedUsers(IEnumerable<int> selectedUserIds)
        {
            var result = new Dictionary<int, int>();

            foreach (var userId in selectedUserIds)
            {
                var usageRows = Database.ExecuteSafe(con =>
                {
                    var list = new List<(int HostID, int WorkCount)>();
                    const string query = @"
                        SELECT TOP(50) HostID, COUNT(*) AS WorkCount
                        FROM Log.ActivityLog
                        WHERE UserID = @userid
                            AND Date >= DATEADD(YEAR, -1, GETDATE())
                            AND HostID IS NOT NULL
                        GROUP BY HostID
                        ORDER BY WorkCount DESC";

                    using var cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@userid", userId);
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        list.Add((
                            reader.GetInt32(reader.GetOrdinal("HostID")),
                            reader.GetInt32(reader.GetOrdinal("WorkCount"))
                        ));
                    }
                    return list;
                });

                if (usageRows == null)
                    continue;

                foreach (var usageRow in usageRows)
                {
                    if (result.TryGetValue(usageRow.HostID, out int currentCount))
                        result[usageRow.HostID] = currentCount + usageRow.WorkCount;
                    else
                        result[usageRow.HostID] = usageRow.WorkCount;
                }
            }

            return result;
        }
        private HashSet<int> GetHostIdsForSelectedProdLines(IEnumerable<string> selectedProdLines)
        {
            var result = new HashSet<int>();

            foreach (var prodLine in selectedProdLines)
            {
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

                if (hostIds == null)
                    continue;

                foreach (var hostId in hostIds)
                    result.Add(hostId);
            }

            return result;
        }
        private static IEnumerable<HostItem> OrderClientsByUsage(IEnumerable<HostItem> clients, IReadOnlyDictionary<int, int> hostUsageCounts)
        {
            return clients
                .OrderByDescending(client => hostUsageCounts.TryGetValue(client.HostID, out int workCount) ? workCount : 0)
                .ThenBy(client => client.HostName);
        }
        private void InitializeClientListViews()
        {
            ConfigureClientListView(lv_AllowedClients);
            ConfigureClientListView(lv_BlockedClients);
        }
        private static void ConfigureClientListView(ListView listView)
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.MultiSelect = true;
            listView.HideSelection = false;
            listView.Columns.Clear();
            listView.Columns.Add("Client",185,HorizontalAlignment.Left);
            listView.Columns.Add("Version",70,HorizontalAlignment.Left);
            listView.Columns.Add("Senast aktiv",110,HorizontalAlignment.Left);
        }
        private static void PopulateClientListView(ListView listView,IEnumerable<HostItem> clients,bool selectAll)
        {
            listView.Items.Clear();
            foreach (var client in clients)
                listView.Items.Add(CreateClientListViewItem(client));
            if (selectAll)
            {
                listView.SelectedIndices.Clear();
                for (int i = 0; i < listView.Items.Count; i++)
                    listView.SelectedIndices.Add(i);
            }
        }
        private static ListViewItem CreateClientListViewItem(HostItem client)
        {
            var item = new ListViewItem(client.ToString());
            item.SubItems.Add(client.CurrentVersion);
            item.SubItems.Add(GetLastActiveText(client.LastActivity));
            item.Tag = client;
            return item;
        }
        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (sender is not ListView listView)
                return;
            System.Windows.Forms.SortOrder nextOrder = System.Windows.Forms.SortOrder.Ascending;
            if (_listViewSortStates.TryGetValue(listView, out var currentSort) && currentSort.Column == e.Column)
                nextOrder = currentSort.Order == System.Windows.Forms.SortOrder.Ascending ? System.Windows.Forms.SortOrder.Descending : System.Windows.Forms.SortOrder.Ascending;
            _listViewSortStates[listView] = (e.Column, nextOrder);
            ApplyStoredSort(listView);
        }
        private void ApplyStoredSort(ListView listView)
        {
            if (!_listViewSortStates.TryGetValue(listView, out var sortState))
                return;
            listView.ListViewItemSorter = new ListViewItemComparer(sortState.Column, sortState.Order);
            listView.Sort();
        }
        private static List<HostItem> GetSelectedHosts(ListView listView)
        {
            return listView.SelectedItems
                .Cast<ListViewItem>()
                .Select(item => item.Tag as HostItem)
                .Where(item => item != null)
                .Cast<HostItem>()
                .ToList();
        }
        private static string GetLastActiveText(DateTime? lastActivity)
        {
            if (lastActivity == null)
                return "Ingen aktivitet";
            var span = DateTime.Now - lastActivity.Value;
            if (span.TotalMinutes < 1)
                return "Nyss";
            if (span.TotalHours < 1)
                return $"{Math.Max(1,(int)span.TotalMinutes)} min sedan";
            if (span.TotalDays < 1)
                return $"{Math.Max(1,(int)span.TotalHours)} h sedan";
            if (span.TotalDays < 14)
                return $"{Math.Max(1,(int)span.TotalDays)} dagar sedan";
            return lastActivity.Value.ToString("yyyy-MM-dd");
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
        private void InitializeProdLinesOnClientListView()
        {
            lv_ProdLinesOnClient.View = View.Details;
            lv_ProdLinesOnClient.FullRowSelect = true;
            lv_ProdLinesOnClient.MultiSelect = false;
            lv_ProdLinesOnClient.HideSelection = false;
            lv_ProdLinesOnClient.Columns.Clear();
            lv_ProdLinesOnClient.Columns.Add("Production Line", 120, HorizontalAlignment.Left);
            lv_ProdLinesOnClient.Columns.Add("Senast aktiv", 95, HorizontalAlignment.Left);
        }
        private void LoadClients()
        {
            _allClients.Clear();
            _allKnownClients.Clear();
            _blockedClientsByVersion.Clear();
            var clients = Database.ExecuteSafe(con =>
            {
                var list = new List<HostItem>();
                const string query = @"
                    SELECT g.HostID, g.HostName, MAX(al.Date) AS LastActivity, latest.Version AS CurrentVersion
                    FROM [Settings].General g
                    JOIN Log.ActivityLog al ON al.HostID = g.HostID
                    OUTER APPLY
                    (
                        SELECT TOP(1) Version
                        FROM Log.ActivityLog latest
                        WHERE latest.HostID = g.HostID
                            AND latest.Version IS NOT NULL
                        ORDER BY latest.Date DESC
                    ) latest
                    WHERE al.Date >= DATEADD(YEAR, -1, GETDATE())
                    GROUP BY g.HostID, g.HostName, latest.Version
                    ORDER BY g.HostName";
                using var cmd = new SqlCommand(query, con);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new HostItem(
                        reader.GetInt32(reader.GetOrdinal("HostID")),
                        reader.GetString(reader.GetOrdinal("HostName")),
                        reader.GetDateTime(reader.GetOrdinal("LastActivity")),
                        reader["CurrentVersion"]?.ToString() ?? string.Empty
                    ));
                }
                return list;
            });

            if (clients == null)
                return;
            _allKnownClients.AddRange(clients);
            _allClients.AddRange(clients);
            RefreshClientListsFromSelections();
        }
        private void LoadProdLines()
        {
            _allProdLines.Clear();
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

            RefreshUsersAndProdLines();
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
            _allUsers.Clear();

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
                    _allUsers.Add(user);
            }

            // Om du vill kan du visa endast namn i ListBox
            lb_AllUsers.DisplayMember = "Value";
            lb_AllUsers.ValueMember = "Key";
            RefreshUsersAndProdLines();
        }

        private async void lb_Clients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;
            _suppressSelectionChanged = true;
            try
            {
                if (lv_BlockedClients.SelectedItems.Count > 0)
                    lv_BlockedClients.SelectedIndices.Clear();
            }
            finally
            {
                _suppressSelectionChanged = false;
            }
            var selectedHosts = GetSelectedHosts(lv_AllowedClients)
                .Select(h => h.HostID)
                .ToList();
            await LoadClientDetailsForSelectedHostsAsync(selectedHosts);
        }
        private async void lb_BlockedClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;
            _suppressSelectionChanged = true;
            try
            {
                if (lv_AllowedClients.SelectedItems.Count > 0)
                    lv_AllowedClients.SelectedIndices.Clear();
            }
            finally
            {
                _suppressSelectionChanged = false;
            }
            var selectedHosts = GetSelectedHosts(lv_BlockedClients)
                .Select(h => h.HostID)
                .ToList();
            await LoadClientDetailsForSelectedHostsAsync(selectedHosts);
        }
        private async Task LoadClientDetailsForSelectedHostsAsync(List<int> selectedHosts)
        {
            await Task.WhenAll(
                LoadUsersForSelectedHostsAsync(selectedHosts),
                LoadProdLinesForSelectedHostsAsync(selectedHosts)
            );
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
                    item.Tag = new UserActivityItem(user.UserID, user.Name, user.LastActivity);
                    lv_UsersOnClient.Items.Add(item);
                }
                ApplyStoredSort(lv_UsersOnClient);
            }
            finally
            {
                lv_UsersOnClient.EndUpdate();
            }
        }
        private async Task LoadProdLinesForSelectedHostsAsync(List<int> selectedHosts)
        {
            _prodLinesOnClientCts?.Cancel();
            _prodLinesOnClientCts?.Dispose();
            _prodLinesOnClientCts = new CancellationTokenSource();
            var token = _prodLinesOnClientCts.Token;
            lv_ProdLinesOnClient.BeginUpdate();
            try
            {
                lv_ProdLinesOnClient.Items.Clear();
                if (selectedHosts.Count == 0)
                    return;
                List<(string ProdLine, DateTime LastActivity)> prodLines;
                try
                {
                    prodLines = await GetProdLinesForHostsAsync(selectedHosts, token);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                if (token.IsCancellationRequested || prodLines == null)
                    return;
                foreach (var prodLine in prodLines)
                {
                    var item = new ListViewItem(prodLine.ProdLine);
                    item.SubItems.Add(prodLine.LastActivity.ToString("yyyy-MM-dd HH:mm"));
                    item.Tag = new ProdLineActivityItem(prodLine.ProdLine, prodLine.LastActivity);
                    lv_ProdLinesOnClient.Items.Add(item);
                }
                ApplyStoredSort(lv_ProdLinesOnClient);
            }
            finally
            {
                lv_ProdLinesOnClient.EndUpdate();
            }
        }
        private void lb_ProdLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_suppressSelectionChanged)
                return;
            RefreshClientListsFromSelections();
        }

        private void lb_Versions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb_Versions.SelectedItem is not string version)
                return;
            var blockedClients = GetBlockedClientsForVersion(version);
            _allBlockedClients = blockedClients.ToList();
            lv_BlockedClients.BeginUpdate();
            lv_AllowedClients.BeginUpdate();
            try
            {
                var blockedIds = new HashSet<int>(_allBlockedClients.Select(x => x.HostID));
                _allClients = _allKnownClients
                    .Where(c => !blockedIds.Contains(c.HostID))
                    .ToList();
            }
            finally
            {
                lv_AllowedClients.EndUpdate();
                lv_BlockedClients.EndUpdate();
            }
            RefreshClientListsFromSelections();
        }
        private void lb_AllUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;
            try
            {
                RefreshClientListsFromSelections();
            }
            finally
            {
                _suppressSelectionChanged = false;
            }
        }

        private void chk_CheckAllClients_CheckedChanged(object sender, EventArgs e)
        {
            _suppressSelectionChanged = true;

            lv_AllowedClients.BeginUpdate();
            try
            {
                lv_AllowedClients.SelectedIndices.Clear();

                if (chk_CheckAllClients.Checked)
                {
                    for (int i = 0; i < lv_AllowedClients.Items.Count; i++)
                        lv_AllowedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                lv_AllowedClients.EndUpdate();
                _suppressSelectionChanged = false;
            }

            // ÃƒÆ’Ã‚Â°Ãƒâ€¦Ã‚Â¸ÃƒÂ¢Ã¢â€šÂ¬Ã‚ÂÃƒâ€šÃ‚Â¥ TRIGGA EN ENDA uppdatering manuellt
            lb_Clients_SelectedIndexChanged(lv_AllowedClients, EventArgs.Empty);
        }
        private void chk_CheckAllBlockedClients_CheckedChanged(object sender, EventArgs e)
        {
            lv_BlockedClients.BeginUpdate();
            try
            {
                lv_BlockedClients.SelectedIndices.Clear();

                if (chk_CheckAllBlockedClients.Checked)
                {
                    for (int i = 0; i < lv_BlockedClients.Items.Count; i++)
                        lv_BlockedClients.SelectedIndices.Add(i);
                }
            }
            finally
            {
                lv_BlockedClients.EndUpdate();
            }
        }
        private void btn_BlockClient_Click(object sender, EventArgs e)
        {
            var version = lb_Versions.SelectedItem?.ToString();
            if (lv_AllowedClients.SelectedItems.Count == 0 || string.IsNullOrEmpty(version))
                return;

            // HÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â¤mta valda klienter
            var toBlock = GetSelectedHosts(lv_AllowedClients);
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
            _blockedClientsByVersion.Remove(version);
            // --- 3. UI UPPDATERING ---
            lv_BlockedClients.BeginUpdate();
            lv_AllowedClients.BeginUpdate();
            try
            {
                RefreshClientListsFromSelections();
            }
            finally
            {
                lv_AllowedClients.EndUpdate();
                lv_BlockedClients.EndUpdate();
            }

        }
        private void btn_UnBlockClient_Click(object sender, EventArgs e)
        {
            if (lv_BlockedClients.SelectedItems.Count == 0)
                return;

            var selected = GetSelectedHosts(lv_BlockedClients);
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
                // Lägg tillbaka i client‑masterlist om säkert
                if (_allClients.All(x => x.HostID != host.HostID))
                    _allClients.Add(host);
            }
            _blockedClientsByVersion.Remove(version);
            // --- 3. UI UPDATE ---
            lv_BlockedClients.BeginUpdate();
            lv_AllowedClients.BeginUpdate();
            try
            {
                RefreshClientListsFromSelections();
            }
            finally
            {
                lv_BlockedClients.EndUpdate();
                lv_AllowedClients.EndUpdate();
            }

            tb_FilterBlockedClients.Text = string.Empty;
            RefreshClientListsFromSelections();
        }
        private void tb_FilterUsersProdLines_TextChanged(object sender, EventArgs e)
        {
            RefreshUsersAndProdLines();
        }
        private void tb_Filter_TextChanged(object sender, EventArgs e)
        {
            RefreshClientListsFromSelections();
        }
        private void tb_FilterBlockedClients_TextChanged(object sender, EventArgs e)
        {
            RefreshClientListsFromSelections();
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
        private async Task<List<(string ProdLine, DateTime LastActivity)>> GetProdLinesForHostsAsync(IEnumerable<int> hostIds, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return new List<(string ProdLine, DateTime LastActivity)>();
            var prodLines = await Task.Run(() =>
            {
                if (cancellationToken.IsCancellationRequested)
                    return new List<(string ProdLine, DateTime LastActivity)>();
                return GetProdLinesForHosts(hostIds);
            });
            if (cancellationToken.IsCancellationRequested)
                return new List<(string ProdLine, DateTime LastActivity)>();
            return prodLines;
        }
        private List<(string ProdLine, DateTime LastActivity)> GetProdLinesForHosts(IEnumerable<int> hostIds)
        {
            return Database.ExecuteSafe(con =>
            {
                var result = new List<(string, DateTime)>();
                var ids = hostIds.ToList();
                if (ids.Count == 0)
                    return result;
                var parameters = ids
                    .Select((id, i) => $"@h{i}")
                    .ToArray();
                var query = $@"
            SELECT
                o.ProdLine,
                MAX(al.Date) AS LastActivity
            FROM Log.ActivityLog al
            JOIN [Order].MainData o ON al.OrderID = o.OrderID
            WHERE al.HostID IN ({string.Join(",", parameters)})
              AND al.Date >= DATEADD(YEAR, -1, GETDATE())
              AND o.ProdLine IS NOT NULL
            GROUP BY o.ProdLine
            ORDER BY MAX(al.Date) DESC";
                using var cmd = new SqlCommand(query, con);
                for (int i = 0; i < ids.Count; i++)
                    cmd.Parameters.AddWithValue(parameters[i], ids[i]);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add((
                        reader.GetString(0),
                        reader.GetDateTime(1)
                    ));
                }
                return result;
            });
        }
        private List<HostItem> GetBlockedClientsForVersion(string version)
        {
            if (_blockedClientsByVersion.TryGetValue(version, out var cachedBlockedClients))
                return cachedBlockedClients.ToList();
            return Database.ExecuteSafe(con =>
            {
                var result = new List<HostItem>();
                var clientInfoByHostId = _allKnownClients.Count > 0
                    ? _allKnownClients.ToDictionary(client => client.HostID)
                    : _allClients.ToDictionary(client => client.HostID);
                const string query = @"
                    SELECT DISTINCT g.HostID, g.HostName
                    FROM Log.ClientPolicy cp
                    INNER JOIN [Settings].General g ON g.HostID = cp.HostID
                    WHERE cp.Version = @version
                    ORDER BY g.HostName";
                using var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@version", version);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int hostId = reader.GetInt32(reader.GetOrdinal("HostID"));
                    string hostName = reader.GetString(reader.GetOrdinal("HostName"));
                    clientInfoByHostId.TryGetValue(hostId, out var clientInfo);
                    result.Add(new HostItem(
                        hostId,
                        hostName,
                        clientInfo?.LastActivity,
                        clientInfo?.CurrentVersion ?? string.Empty
                    ));
                }
                _blockedClientsByVersion[version] = result.ToList();
                return result;
            });
        }
        public class HostItem(int hostId, string hostName, DateTime? lastActivity = null, string currentVersion = "")
        {
            public int HostID { get; } = hostId;
            public string HostName { get; } = hostName;
            public DateTime? LastActivity { get; } = lastActivity;
            public string CurrentVersion { get; } = currentVersion;
            public override string ToString()
            {
                return $"{HostName} (ID: {HostID})";
            }
        }
        private sealed class UserActivityItem(int userId, string name, DateTime lastActivity)
        {
            public int UserID { get; } = userId;
            public string Name { get; } = name;
            public DateTime LastActivity { get; } = lastActivity;
        }
        private sealed class ProdLineActivityItem(string prodLine, DateTime lastActivity)
        {
            public string ProdLine { get; } = prodLine;
            public DateTime LastActivity { get; } = lastActivity;
        }
        private sealed class ListViewItemComparer(int column, System.Windows.Forms.SortOrder sortOrder) : System.Collections.IComparer
        {
            public int Compare(object? x, object? y)
            {
                if (x is not ListViewItem leftItem || y is not ListViewItem rightItem)
                    return 0;
                int result = CompareValues(GetSortValue(leftItem, column), GetSortValue(rightItem, column));
                if (result == 0)
                    result = StringComparer.CurrentCultureIgnoreCase.Compare(leftItem.Text, rightItem.Text);
                return sortOrder == System.Windows.Forms.SortOrder.Descending ? -result : result;
            }
            private static object GetSortValue(ListViewItem item, int columnIndex)
            {
                if (item.Tag is HostItem host)
                {
                    return columnIndex switch
                    {
                        0 => host.HostName,
                        1 => GetVersionSortValue(host.CurrentVersion),
                        2 => host.LastActivity,
                        _ => GetSubItemText(item, columnIndex)
                    };
                }
                if (item.Tag is UserActivityItem user)
                {
                    return columnIndex switch
                    {
                        0 => user.UserID,
                        1 => user.Name,
                        2 => user.LastActivity,
                        _ => GetSubItemText(item, columnIndex)
                    };
                }
                if (item.Tag is ProdLineActivityItem prodLine)
                {
                    return columnIndex switch
                    {
                        0 => prodLine.ProdLine,
                        1 => prodLine.LastActivity,
                        _ => GetSubItemText(item, columnIndex)
                    };
                }
                return GetSubItemText(item, columnIndex);
            }
            private static string GetSubItemText(ListViewItem item, int columnIndex)
            {
                return item.SubItems.Count > columnIndex ? item.SubItems[columnIndex].Text : item.Text;
            }
            private static object GetVersionSortValue(string version)
            {
                return Version.TryParse(version, out var parsedVersion) ? parsedVersion : version;
            }
            private static int CompareValues(object leftValue, object rightValue)
            {
                if (leftValue == null && rightValue == null)
                    return 0;
                if (leftValue == null)
                    return 1;
                if (rightValue == null)
                    return -1;
                if (leftValue is int leftInt && rightValue is int rightInt)
                    return leftInt.CompareTo(rightInt);
                if (leftValue is DateTime leftDate && rightValue is DateTime rightDate)
                    return leftDate.CompareTo(rightDate);
                if (leftValue is IComparable leftComparable && leftValue.GetType() == rightValue.GetType())
                    return leftComparable.CompareTo(rightValue);
                return StringComparer.CurrentCultureIgnoreCase.Compare(leftValue.ToString(), rightValue.ToString());
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

