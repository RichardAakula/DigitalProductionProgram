using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;

namespace DigitalProductionProgram.Log
{
    public partial class ChangeLog : Form
    {
        private bool isMouseDown;
        private Point mouseOffset;
        public static string News
        {
            get
            {
                string news = null;
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT Version, Description From Log.ChangeLog WHERE VisibleToUser = 'True' AND ID > (SELECT TOP(1) ID FROM Log.ChangeLog WHERE Version = @activeVersion ORDER BY ID DESC) ORDER BY ID DESC";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                cmd.Parameters.AddWithValue("@activeVersion", CurrentVersion.ToString());
                con?.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    news += $"{reader[0]} - {reader[1]} \n";
                return news;
            }
        }
        public static Version CurrentVersion
        {
            get
            {
                // För att hämta versionen från den aktuella exekverbara filen
                var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
                if (versionInfo.FileVersion != null) return new Version(versionInfo.FileVersion);
                return new Version(0, 0, 0, 0); // Om versionen inte kan hämtas, returnera en standardversion
            }
        }

       

    public static Version? LatestVersion
    {
        get
        {
            const string appInstallerPath = @"\\optifil\dpp\Install DPP.appinstaller";

            // ✅ Kontrollera att filen finns innan vi försöker läsa
            if (File.Exists(appInstallerPath))
            {
                var doc = XDocument.Load(appInstallerPath);
                var versionStr = doc.Root?.Attribute("Version")?.Value;
                Version.TryParse(versionStr, out var latestVersion);
                if (latestVersion != null)
                    return latestVersion;
            }

            try
            {
                using var con = new SqlConnection(Database.cs_Protocol);
                const string query = "SELECT TOP(1) Version FROM Log.ChangeLog WHERE ReleaseDate IS NOT NULL ORDER BY ID DESC";

                var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
                con?.Open();
                Version.TryParse((string)cmd.ExecuteScalar(), out var vers);
                return vers;
            }
            catch
            {
                Debug.WriteLine("Försöker hämta senaste version från databas");
                return null;
            }
        }
    }

        private readonly List<VersionInfo> versions = new();
        public static Version? selectedVersion;
        public static Version? HighestSelectedVersion;
        private LabelPreText? labelVersion;

        private class LabelPreText : Label
        {
            private readonly string? _preText;
            public string? PreText
            {
                get => _preText;
                init
                {
                    _preText = value;
                    Invalidate();
                }
            }
            public override string? Text
            {
                get => base.Text;
                set
                {
                    base.Text = value;
                    AdjustSize();
                    Invalidate();
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                var fullText = PreText + base.Text;
                e.Graphics.DrawString(fullText, Font, new SolidBrush(ForeColor), 30, 10);
            }
            private void AdjustSize()
            {
                if (this.AutoSize)
                {
                    using var g = this.CreateGraphics();
                    var fullText = PreText + base.Text;
                    var size = g.MeasureString(fullText, this.Font);
                    this.Width = (int)Math.Ceiling(size.Width);
                    this.Height = (int)Math.Ceiling(size.Height);
                }
            }
        }

       

        

        public ChangeLog(Version? currentVersion)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = true;
            this.MinimizeBox = true;
            this.MaximizeBox = false;

            InitializeVersionLabel(currentVersion);
            Load_VersionInfo(currentVersion);

            Show_VersionDetails();

            panel_Left.MouseWheel += panel_Left_MouseWheel;
            versionReadStartTime = DateTime.Now;
        }

        private void InitializeVersionLabel(Version? currentVersion)
        {
            if (currentVersion == null)
                currentVersion = LatestVersion;

            labelVersion = new LabelPreText
            {
                PreText = "V ",
                Text = currentVersion.ToString(),
                AutoSize = true,
                Font = new Font("Lucida Sans", 22f),
                ForeColor = CustomColors.Parmesan,
                Dock = DockStyle.Top,
                Padding = new Padding(60, 20, 0, 0)
            };
            panel_Left.Controls.Add(labelVersion);
            labelVersion?.SendToBack();
        }

        private void Load_VersionInfo(Version? currentVersion)
        {
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"
                    SELECT Tags, Version, DescriptionHeader, Description, HowToDo, ReleaseDate 
                    FROM [Log].ChangeLog
                    WHERE VisibleToUser = 'True'
                    AND ReleaseDate IS NOT NULL
                    ORDER BY ID";

            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@version", labelVersion.Text);
            con?.Open();

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                versions.Add(new VersionInfo
                {
                    Tag = reader.IsDBNull(0) ? "Info" : reader.GetString(0),
                    VersionNr = reader.IsDBNull(1) ? new Version(0, 0, 0, 0) : Version.Parse(reader.GetString(1)),
                    DescriptionHeader = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Description = reader.IsDBNull(3) ? "N/A" : reader.GetString(3),
                    HowTo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    ReleaseDate = reader.IsDBNull(5) ? default : reader.GetDateTime(5)

                });
            }

            if (versions.Any() && currentVersion is null)
            {
                selectedVersion = versions.Last().VersionNr;
                labelVersion.Text = selectedVersion?.ToString(); // Assign string to label
            }
            else
            {
                selectedVersion = currentVersion; // Assign Version to Version
                labelVersion.Text = selectedVersion?.ToString(); // Then assign string to label
            }
        }
        private void Show_VersionDetails()
        {
            if (!Version.TryParse(labelVersion?.Text, out var currentVersion))
                return;
            currentVersionBeingRead = currentVersion;
            // Find the index of the current version in the distinct version list
            var distinctVersions = versions
                .Select(v => v.VersionNr)
                .Distinct()
                .OrderBy(v => v)
                .ToList();

            var currentIndex = distinctVersions.IndexOf(currentVersion);
            if (currentIndex == -1) return;

            var start = Math.Max(0, currentIndex - 5);
            var end = Math.Min(distinctVersions.Count - 1, currentIndex + 5);

            flp_Versions.Controls.Clear();
            flp_Descriptions.Controls.Clear();

            flp_Descriptions.AutoScroll = true;
            flp_Descriptions.FlowDirection = FlowDirection.TopDown;
            flp_Descriptions.WrapContents = false;

            // Add versions to the left panel
            for (var i = start; i <= end; i++)
            {
                var version = distinctVersions[i];
                Add_Versions(version.ToString()); 
            }

            // Find matching entries for the current version
            var matchingVersions = versions
                .Where(v => v.VersionNr == currentVersion)
                .ToList();

            // Update ReleaseDate label
            var releaseDate = matchingVersions.FirstOrDefault()?.ReleaseDate;
            label_ReleaseDate.Text = releaseDate.HasValue ? releaseDate.Value.ToLongDateString() : "N/A";

            // Group descriptions by tag
            var grouped = matchingVersions.GroupBy(v => v.Tag);

            foreach (var group in grouped)
            {
                if (group.Key != null) Add_DescritpionTag(group.Key);
                foreach (var item in group)
                {
                    if (string.IsNullOrEmpty(item.DescriptionHeader) == false)
                        Add_DescriptionHeader(item.DescriptionHeader);
                    Add_Description(item.Description);
                    if (string.IsNullOrEmpty(item.HowTo) == false)
                        Add_HowTo(item.HowTo);
                }
            }
            //HighestSelectedVersion is used when saving Users LastReadChangeLog
            if (HighestSelectedVersion is null || selectedVersion > HighestSelectedVersion)
                HighestSelectedVersion = selectedVersion;

            flp_Versions.Location = new Point(0, (panel_Left.Height - flp_Versions.Height) / 2);
        }



       
        private void Add_Versions(string versionText)
        {
            var version = Version.Parse(versionText); // Convert the string to Version

            var lbl = new Label
            {
                Text = versionText,
                Font = version == selectedVersion
                    ? new Font("Lucida Sans", 16, FontStyle.Bold)
                    : new Font("Lucida Sans", 14, FontStyle.Regular),

                ForeColor = version == selectedVersion
                    ? CustomColors.Aqua_Font
                    : CustomColors.Aqua,

                Size = new Size(150, 20),
                Cursor = Cursors.Hand,
                Margin = new Padding(20, 5, 0, 0),
                Tag = version
            };

            lbl.Click += OnVersionLabelClick;
            flp_Versions.Controls.Add(lbl);
        }

        private DateTime? versionReadStartTime;
        private Version? currentVersionBeingRead;

        private async void OnVersionLabelClick(object? sender, EventArgs e)
        {
            if (sender is Label clickedLabel && clickedLabel.Tag is Version clickedVersion)
            {
                if (versionReadStartTime.HasValue)// && currentVersionBeingRead != null)
                {
                    var duration = DateTime.Now - versionReadStartTime.Value;
                    await Activity.AddTimeUserReadChangeLog(currentVersionBeingRead.ToString(), duration);
                }

                currentVersionBeingRead = clickedVersion;
                versionReadStartTime = DateTime.Now;

                selectedVersion = clickedVersion;
                labelVersion.Text = clickedVersion.ToString();
                Show_VersionDetails();
            }
        }

        private void Add_DescritpionTag(string tag)
        {
            var lbl_Tag = new Label
            {
                Font = new Font("Lucida Sans", 12, FontStyle.Bold),
                ForeColor = CustomColors.Parmesan,
                Text = tag,
                AutoSize = true,
                Padding = new Padding(30, 30, 0, 0)
            };
            flp_Descriptions.Controls.Add(lbl_Tag);
        }

        private void Add_DescriptionHeader(string? text)
        {

            var lbl = new Label
            {
                Font = new Font("Lucida Sans", 11, FontStyle.Bold),
                ForeColor = CustomColors.Parmesan_Font,
                Text = "• " + text,
                AutoSize = true,
                Padding = new Padding(30, 0, 0, 10),
            };

            flp_Descriptions.Controls.Add(lbl);
        }
        private void Add_Description(string? text)
        {

            var lbl_Description = new Label
            {
                Font = new Font("Lucida Sans", 11, FontStyle.Regular),
                ForeColor = CustomColors.LightGrey_Font,
                Text = text,
                AutoSize = true,
                Padding = new Padding(50, 0, 0, 10),
            };

            flp_Descriptions.Controls.Add(lbl_Description);
        }
        private void Add_HowTo(string text)
        {
            var lbl = new Label
            {
                Font = new Font("Lucida Sans", 11, FontStyle.Regular),
                ForeColor = CustomColors.LightGrey,
                Text = text,
                AutoSize = true,
                Padding = new Padding(80, 0, 0, 10),
            };

            flp_Descriptions.Controls.Add(lbl);
        }


        public class VersionInfo
        {
            public Version? VersionNr { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string? DescriptionHeader { get; set; }
            public string? Description { get; set; }
            public string? HowTo { get; set; }
            public string? Tag { get; set; }
        }

        private void panel_Left_MouseWheel(object? sender, MouseEventArgs e)
        {
            SelectVersionAtPosition(e.Delta > 0 ? "up" : "down");
        }
        private void SelectVersionAtPosition(string direction)
        {
            // Get all the versions from the panel
            var versionLabels = flp_Versions.Controls.OfType<Label>().ToList();

            // Find the topmost and bottommost visible versions
            Label topVersion = versionLabels.FirstOrDefault();
            Label bottomVersion = versionLabels.LastOrDefault();

            // Adjust for scroll direction
            if (direction == "up" && topVersion != null)
            {
                selectedVersion = Version.Parse(topVersion.Text);  // Set selected version to the topmost
                labelVersion.Text = selectedVersion.ToString();
            }
            else if (direction == "down" && bottomVersion != null)
            {
                selectedVersion = Version.Parse(bottomVersion.Text);  // Set selected version to the bottommost
                labelVersion.Text = selectedVersion.ToString();
            }

            // Reload version details for the new selected version
            Show_VersionDetails();
        }
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            mouseOffset = new Point(e.X, e.Y);
        }
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                this.Location = new Point(this.Left + e.X - mouseOffset.X, this.Top + e.Y - mouseOffset.Y);
            }
        }
        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private async void ChangeLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (versionReadStartTime.HasValue)// && currentVersionBeingRead != null)
            {
                var duration = DateTime.Now - versionReadStartTime.Value;
                await Activity.AddTimeUserReadChangeLog(currentVersionBeingRead.ToString(), duration);
            }
            await User.Person.UpdateLastReadChangelogVersion(User.Person.Name);
        }
    }
}
