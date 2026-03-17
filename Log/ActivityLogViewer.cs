using DigitalProductionProgram.DatabaseManagement;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalProductionProgram.Log
{
    public partial class ActivityLogViewer : Form
    {
        private System.Windows.Forms.Timer updateTimer;
        private bool isLoading = false;
        private FlowLayoutPanel activityListPanel;
        private Label LoadingStatusLabel;
        private List<ActivityLogEntry> currentEntries = [];

        public ActivityLogViewer()
        {
            SetupForm();
            SetupUpdateTimer();
            LoadActivityLogHistory();
        }

        private void SetupForm()
        {
            // Grundläggande inställningar
            this.Size = new Size(900, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Activity Log Monitor";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.DoubleBuffered = true;

            // Huvudlayout
            var mainPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                BackColor = Color.FromArgb(240, 240, 240)
            };

            mainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70f));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
            mainPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 50f));

            // Rubrik
            var headerPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(33, 33, 33),
                Padding = new Padding(20, 10, 20, 10)
            };

            var titleLabel = new Label
            {
                Text = "Activity Log History",
                Font = new Font("Segoe UI", 22f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 12)
            };
            headerPanel.Controls.Add(titleLabel);

            mainPanel.Controls.Add(headerPanel, 0, 0);

            // Scroll container för aktiviteter
            var scrollContainer = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(15)
            };

            var scrollControl = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Color.FromArgb(240, 240, 240),
                Name = "ScrollPanel"
            };

            activityListPanel = scrollControl;
            scrollContainer.Controls.Add(scrollControl);

            mainPanel.Controls.Add(scrollContainer, 0, 1);

            // Status bar längst ner
            var statusPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(250, 250, 250),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(15)
            };

            LoadingStatusLabel = new Label
            {
                Text = "● Updating...",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(76, 175, 80),
                AutoSize = true
            };
            statusPanel.Controls.Add(LoadingStatusLabel);

            mainPanel.Controls.Add(statusPanel, 0, 2);

            this.Controls.Add(mainPanel);
        }
        private void SetupUpdateTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 5000; // 5 sekunder
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }
        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            if (!isLoading)
            {
                LoadActivityLogHistory();
            }
        }

        private void LoadActivityLogHistory()
        {
            if (isLoading) return;

            isLoading = true;
            UpdateLoadingStatus(true);

            // Kör på bakgrundstråd för att inte fryza UI
            System.Threading.Tasks.Task.Run(() =>
            {
                try
                {
                    var results = Database.ExecuteSafe(con =>
                    {
                        const string query = @"
                            SELECT TOP 20
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

                        var entries = new List<ActivityLogEntry>();
                        using var cmd = new SqlCommand(query, con);
                        using var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            entries.Add(new ActivityLogEntry
                            {
                                Program = reader["Program"]?.ToString() ?? "N/A",
                                Date = reader["Date"] is DateTime date ? date : DateTime.MinValue,
                                Version = reader["Version"]?.ToString() ?? "N/A",
                                Info = reader["Info"]?.ToString() ?? "N/A",
                                HostName = reader["HostName"]?.ToString() ?? "Unknown Host",
                                UserName = reader["UserName"]?.ToString() ?? "Unknown User"
                            });
                        }

                        return entries;
                    });

                    if (results != null && results.Count > 0)
                    {
                        this.Invoke(() =>
                        {
                            UpdateActivityList(results);
                            UpdateLoadingStatus(false);
                        });
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke(() =>
                    {
                        LoadingStatusLabel.Text = $"● Error: {ex.Message}";
                        LoadingStatusLabel.ForeColor = Color.FromArgb(244, 67, 54);
                        UpdateLoadingStatus(false);
                    });
                }
                finally
                {
                    isLoading = false;
                }
            });
        }

        private void UpdateActivityList(List<ActivityLogEntry> entries)
        {
            // Jämför med tidigare poster för att se vad som är nytt
            bool hasNewEntries = currentEntries.Count != entries.Count ||
                (currentEntries.Count > 0 && entries.Count > 0 &&
                 currentEntries[0].Date != entries[0].Date);

            currentEntries = entries;

            if (!hasNewEntries && activityListPanel.Controls.Count > 0)
                return;

            // Rensa gamla kontroller
            activityListPanel.Controls.Clear();

            // Lägg till nya poster
            foreach (var entry in entries)
            {
                var activityPanel = CreateActivityCard(entry);
                activityListPanel.Controls.Add(activityPanel);
            }
        }

        private Panel CreateActivityCard(ActivityLogEntry entry)
        {
            var card = new Panel
            {
                Width = activityListPanel.Width - 40,
                Height = 140, // ökat för två nya rader
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 0, 12),
                Padding = new Padding(15)
            };

            // Tidlinje punkt på vänster sida
            var timelineMarker = new Panel
            {
                Width = 14,
                Height = 14,
                BackColor = Color.FromArgb(76, 175, 80),
                Location = new Point(-7, 12),
                BorderStyle = BorderStyle.None
            };
            card.Controls.Add(timelineMarker);

            // Datum och tid
            var dateLabel = new Label
            {
                Text = entry.Date.ToString("yyyy-MM-dd HH:mm:ss"),
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80),
                AutoSize = true,
                Location = new Point(15, 5)
            };
            card.Controls.Add(dateLabel);

            // Program
            var programLabel = new Label
            {
                Text = $"Program: {entry.Program}",
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                AutoSize = true,
                Location = new Point(15, 25)
            };
            card.Controls.Add(programLabel);

            // Version
            var versionLabel = new Label
            {
                Text = $"Version: {entry.Version}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(15, 48)
            };
            card.Controls.Add(versionLabel);
    
            // HostName
            var hostLabel = new Label
            {
                Text = $"HostName: {entry.HostName ?? "-"}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(15, 66)
            };
            card.Controls.Add(hostLabel);

            // UserName
            var userLabel = new Label
            {
                Text = $"UserName: {entry.UserName ?? "-"}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(100, 100, 100),
                AutoSize = true,
                Location = new Point(15, 84)
            };
            card.Controls.Add(userLabel);

            // Info (trunkerad för att passa i kortet)
            var infoText = (entry.Info ?? string.Empty);
            infoText = infoText.Length > 85 ? infoText.Substring(0, 85) + "..." : infoText;
        
            var infoLabel = new Label
            {
                Text = $"Info: {infoText}",
                Font = new Font("Segoe UI", 9f),
                ForeColor = Color.FromArgb(66, 66, 66),
                AutoSize = true,
                Location = new Point(15, 106),
                MaximumSize = new Size(card.Width - 40, 40)
            };
            card.Controls.Add(infoLabel);

            // Hover-effekt
            card.MouseEnter += (s, e) =>
            {
                card.BackColor = Color.FromArgb(245, 245, 245);
                card.Cursor = Cursors.Hand;
            };
            card.MouseLeave += (s, e) =>
            {
                card.BackColor = Color.White;
                card.Cursor = Cursors.Default;
            };

    return card;
}

        private void UpdateLoadingStatus(bool loading)
        {
            if (loading)
            {
                LoadingStatusLabel.Text = "● Updating...";
                LoadingStatusLabel.ForeColor = Color.FromArgb(76, 175, 80);
            }
            else
            {
                LoadingStatusLabel.Text = $"● Last updated: {DateTime.Now:HH:mm:ss} ({currentEntries.Count} activities)";
                LoadingStatusLabel.ForeColor = Color.FromArgb(100, 100, 100);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                updateTimer?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class ActivityLogEntry
    {
        public string Program { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Version { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public string HostName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
