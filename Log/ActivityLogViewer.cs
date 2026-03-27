using DigitalProductionProgram.DatabaseManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DigitalProductionProgram.Log
{
    public partial class ActivityLogViewer : Form
    {

        public class SmoothFlowLayoutPanel : FlowLayoutPanel
        {
            public SmoothFlowLayoutPanel()
            {
                this.DoubleBuffered = true;
                this.ResizeRedraw = true;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.SetStyle(ControlStyles.UserPaint, true);
                this.UpdateStyles();
            }
        }
        private const int WM_SETREDRAW = 0x000B;
      

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, bool wParam, int lParam);

        private System.Windows.Forms.Timer updateTimer;
        private bool isLoading = false;

        private List<ActivityLogEntry> currentEntries = new();

        public ActivityLogViewer()
        {
            InitializeComponent();
            SetupForm();
            SetupUpdateTimer();
            LoadActivityLogHistory(100);
        }

        private void SetupForm()
        {
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Activity Log";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.DoubleBuffered = true;

        }
        private void SetupUpdateTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 5000;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            if (!isLoading)
            {
                LoadActivityLogHistory(5);
            }
        }

        private void LoadActivityLogHistory(int top)
        {
            if (isLoading) 
                return;

            isLoading = true;
            UpdateLoadingStatus(true);

            Task.Run(() =>
            {
                try
                {
                    var results = Database.ExecuteSafe(con =>
                    {
                        const string query = @"
                            SELECT TOP (@top)
                                al.[Program], 
                                al.[Date], 
                                al.[Version], 
                                al.[Info],
                                al.[HostID],
                                al.[UserID],
                                sg.[HostName],
                                up.[Name] AS UserName
                            FROM [Log].[ActivityLog] al
                            LEFT JOIN [Settings].[General] sg ON al.[HostID] = sg.[HostID]
                            LEFT JOIN [User].[Person] up ON al.[UserID] = up.[UserID]
                            ORDER BY al.[Date] DESC";

                        var list = new List<ActivityLogEntry>();
                        using var cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@top", top);
                        using var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            list.Add(new ActivityLogEntry
                            {
                                Program = reader["Program"]?.ToString() ?? "",
                                Date = reader["Date"] is DateTime dt ? dt : DateTime.MinValue,
                                Version = reader["Version"]?.ToString() ?? "",
                                Info = reader["Info"]?.ToString() ?? "",
                                HostName = reader["HostName"]?.ToString() ?? "",
                                UserName = reader["UserName"]?.ToString() ?? ""
                            });
                        }

                        return list;
                    });

                   
                    if (results != null)
                    {
                        if (IsDisposed || !IsHandleCreated)
                            return;

                        Invoke(() =>
                        {
                            if (IsDisposed) return;

                            currentEntries = results;
                            UpdateActivityList();
                            UpdateLoadingStatus(false);
                        });
                    }
                }
                catch (Exception ex)
                {
                    Invoke(() =>
                    {
                        label_Status.Text = $"● Error: {ex.Message}";
                        label_Status.ForeColor = Color.FromArgb(244, 67, 54);
                        UpdateLoadingStatus(false);
                    });
                }
                finally
                {
                    isLoading = false;
                }
            });
        }
        private void UpdateLoadingStatus(bool loading)
        {
            if (loading)
            {
                label_Status.Text = "● Updating...";
                label_Status.ForeColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                label_Status.Text = $"● Last updated: {DateTime.Now:HH:mm:ss} ({currentEntries.Count} activities)";
                label_Status.ForeColor = Color.FromArgb(100, 100, 100);
            }
        }
        private void UpdateActivityList()
        {
            panel_activityListPanel.SuspendLayout();
            SendMessage(panel_activityListPanel.Handle, WM_SETREDRAW, false, 0);

            // activityListPanel.Controls.Clear();

            foreach (var entry in currentEntries)
            {
                var card = CreateActivityCard(entry);
                panel_activityListPanel.Controls.Add(card);
            }

            ApplyFilter();

            SendMessage(panel_activityListPanel.Handle, WM_SETREDRAW, true, 0);
            panel_activityListPanel.ResumeLayout();
            panel_activityListPanel.Refresh();
        }


        private void FilterChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            string user = tb_FilterUsername.Text.Trim().ToLower();
            string host = tb_FilterHostName.Text.Trim().ToLower();

            foreach (Control c in panel_activityListPanel.Controls)
            {
                if (c.Tag is not ActivityLogEntry e) continue;

                bool okUser = string.IsNullOrEmpty(user) || e.UserName.ToLower().Contains(user);
                bool okHost = string.IsNullOrEmpty(host) || e.HostName.ToLower().Contains(host);

                c.Visible = okUser && okHost;
            }
        }

        private Panel CreateActivityCard(ActivityLogEntry entry)
        {
            var card = new Panel
            {
                Width = panel_activityListPanel.Width - 40,
                Height = 140,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 12),
                Padding = new Padding(15),
                Tag = entry
            };

            var dateLabel = new Label
            {
                Text = entry.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80),
                AutoSize = true,
                Location = new Point(15, 5)
            };
            card.Controls.Add(dateLabel);

            card.Controls.Add(MakeLabel($"Program: {entry.Program}", 15, 25, true));
            card.Controls.Add(MakeLabel($"Version: {entry.Version}", 15, 48));
            card.Controls.Add(MakeLabel($"HostName: {entry.HostName}", 15, 66));
            card.Controls.Add(MakeLabel($"UserName: {entry.UserName}", 15, 84));

            var infoText = entry.Info.Length > 85 ? entry.Info.Substring(0, 85) + "..." : entry.Info;

            card.Controls.Add(new Label
            {
                Text = $"Info: {infoText}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(66, 66, 66),
                AutoSize = true,
                Location = new Point(15, 106),
                MaximumSize = new Size(card.Width - 40, 40)
            });

            return card;
        }
        private Label MakeLabel(string text, int x, int y, bool bold = false)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", bold ? 10f : 9f, bold ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(x, y)
            };
        }
    }

    public class ActivityLogEntry
    {
        public string Program { get; set; }
        public DateTime Date { get; set; }
        public string Version { get; set; }
        public string Info { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
    }
}