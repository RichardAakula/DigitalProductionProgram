using DigitalProductionProgram.DatabaseManagement;
using DigitalProductionProgram.Help;
using DigitalProductionProgram.Log;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using DigitalProductionProgram.User;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    public partial class EasterEgg_Code : Form
    {
        internal const string GameName = "The Cipher Wheel";
        private const string Password = "H4PPYEG6";
        private const int DeclinedGameLevel = -3;
        internal const int KnockAttemptLevel = -2;
        private const int StartMarkerLevel = -1;
        private const int WrongGuessLevel = 0;
        private const int CompletedGameLevel = 99;
        private const int MaximumScore = 5000;
        private const int IncorrectGuessPenalty = 100;
        private static readonly string IntroMessage = "Congratulations. You've discovered a hidden Easter Egg!\n" +
                                                      "Before you lies a mysterious cipher lock.\n" +
                                                      "Unlock it, and you shall win the game.\n" +
                                                      "But beware...\n" +
                                                      "Each failed attempt chips away at your score.\n" +
                                                      "Clues are scattered—hidden in the shadows of the program,\n" +
                                                      "waiting for the observant and the bold.\n" +
                                                      " -Maximum score: 5000\n" +
                                                      " -Each incorrect guess costs you 100 points\n\n" +
                                                      "Can you crack the code before your chances run out?\n" +
                                                      "Let the cipher challenge begin.";
        private static readonly string DiscoveryQuestionMessage = "You have uncovered a hidden trail.\n" +
                                                                 "Do you want to investigate The Cipher Wheel?\n\n" +
                                                                 "If you turn away now, the clues will fade and the flying egg will not return.";
        private static readonly string DeclinedMessage = "The trail grows cold.\n" +
                                                         "The Cipher Wheel remains sealed, and the signs will not return.";
        private static readonly string UnlockMessage = IntroMessage + "\n\nThe path is now open under Hjälp -> The Cipher Wheel.";
        private static readonly string IntroPanelText = "Congratulations. You've discovered a hidden Easter Egg. Before you lies a mysterious cipher lock.\n" +
                                                        "Unlock it, and you shall win the game, but beware: each failed attempt chips away at your score.\n" +
                                                        "Clues are scattered—hidden in the shadows of the program, waiting for the observant and the bold.\n" +
                                                        "Can you crack the code before your chances run out? Let the cipher challenge begin.";
        private readonly List<CodeWheel> wheels = new();
        private readonly CipherWheelInfoPanel introPanel;
        private readonly CipherWheelScorePanel scorePanel;
        private readonly DataGridView dgvHighscore;
        private int currentScore = MaximumScore;
        private int wrongGuessCount;
        private static bool? isGameStarted;
        private static bool? isGameCompleted;
        private static bool? isGameDeclined;
        private static EasterEgg_Code? activeInstance;
        public static bool IsGameStarted
        {
            get
            {
                EnsureGameState();
                return isGameStarted ?? false;
            }
        }
        public static bool IsGameCompleted
        {
            get
            {
                EnsureGameState();
                return isGameCompleted ?? false;
            }
        }
        public static bool IsGameDeclined
        {
            get
            {
                EnsureGameState();
                return isGameDeclined ?? false;
            }
        }
        public static bool HasBeenDiscovered
        {
            get
            {
                EnsureGameState();
                return (isGameStarted ?? false) || (isGameCompleted ?? false);
            }
        }
        public static bool HasHandledDiscovery
        {
            get
            {
                EnsureGameState();
                return (isGameStarted ?? false) || (isGameCompleted ?? false) || (isGameDeclined ?? false);
            }
        }
        public static bool HasBeenDiscoveredInDatabase()
        {
            ResetGameStateCache();
            EnsureGameState();
            return (isGameStarted ?? false) || (isGameCompleted ?? false);
        }
        public static bool HasHandledDiscoveryInDatabase()
        {
            ResetGameStateCache();
            EnsureGameState();
            return (isGameStarted ?? false) || (isGameCompleted ?? false) || (isGameDeclined ?? false);
        }
        public EasterEgg_Code()
        {
            InitializeComponent();
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("DigitalProductionProgram.Resources.Code_Background.jpg"))
            {
                if (stream != null)
                {
                    using var loadedImage = Image.FromStream(stream);
                    BackgroundImage = new Bitmap(loadedImage);
                    BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
            activeInstance = this;
            FormClosed += (_, _) =>
            {
                if (ReferenceEquals(activeInstance, this))
                    activeInstance = null;
                CipherWheelLevels.Level_8.Detach();
            };
            introPanel = new CipherWheelInfoPanel
            {
                Left = 40,
                Top = 318,
                Width = 1710,
                Height = 328,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                TitleText = GameName,
                BodyText = IntroPanelText,
                PrimaryBadgeText = $"Maximum score: {MaximumScore}",
                SecondaryBadgeText = $"Each incorrect guess costs you {IncorrectGuessPenalty} points",
                SectionTitleText = "Cipher Highscore"
            };
            if (BackgroundImage != null)
            {
                introPanel.BackgroundImage = new Bitmap(BackgroundImage);
                introPanel.BackgroundImageLayout = ImageLayout.Stretch;
            }
            scorePanel = new CipherWheelScorePanel
            {
                Width = 300,
                Height = 84,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                TitleText = "Current score"
            };
            dgvHighscore = new DataGridView
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                ReadOnly = true,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.None,
                BackgroundColor = Color.FromArgb( 49, 20, 14),
                GridColor = Color.FromArgb(86, 66, 43),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single,
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                EnableHeadersVisualStyles = false
            };
            dgvHighscore.DefaultCellStyle.BackColor = Color.FromArgb(43, 29, 18);
            dgvHighscore.DefaultCellStyle.ForeColor = Color.FromArgb(244, 236, 214);
            dgvHighscore.DefaultCellStyle.SelectionBackColor = Color.FromArgb(96, 70, 31);
            dgvHighscore.DefaultCellStyle.SelectionForeColor = Color.FromArgb(255, 244, 222);
            dgvHighscore.DefaultCellStyle.Font = new Font("Segoe UI", 9.4f, FontStyle.Regular);
            dgvHighscore.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(86, 56, 24);
            dgvHighscore.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 235, 178);
            dgvHighscore.ColumnHeadersDefaultCellStyle.Font = new Font("Palatino Linotype", 10f, FontStyle.Bold);
            dgvHighscore.ColumnHeadersHeight = 30;
            dgvHighscore.RowTemplate.Height = 24;
            dgvHighscore.DataBindingComplete += (_, _) => dgvHighscore.ClearSelection();
            Controls.Add(introPanel);
            Controls.Remove(btn_TestCode);
            introPanel.Controls.Add(scorePanel);
            introPanel.Controls.Add(dgvHighscore);
            introPanel.Controls.Add(btn_TestCode);
            introPanel.Resize += (_, _) => LayoutInfoPanelContents();
            LayoutInfoPanelContents();
            CipherWheelLevels.Level_5.AttachToLorePanel(introPanel, this);
            CipherWheelLevels.Level_6.AttachToForm(this);
            for (int i = 0; i < 8; i++)
            {
                var wheel = new CodeWheel { Left = 100 + i * 200, Top = 100 };
                this.Controls.Add(wheel);
                wheels.Add(wheel);
            }
            CipherWheelLevels.Level_8.AttachToWheels(wheels, this);
            introPanel.SendToBack();
            btn_TestCode.BringToFront();
            LoadScoreFromDatabase();
            RefreshScorePanel();
            LoadHighscoreTable();
            RefreshLevel8Seal();
            Activity.Stop("User opened The Cipher Wheel");
        }
        
        
        private static void EnsureGameState()
        {
            if (isGameStarted.HasValue && isGameCompleted.HasValue && isGameDeclined.HasValue)
                return;
            if (string.IsNullOrWhiteSpace(Person.Name))
            {
                SetGameStateCache(false, false, false);
                return;
            }
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT
                COUNT(*) AS TotalRows,
                SUM(CASE WHEN Level = @declinedLevel THEN 1 ELSE 0 END) AS DeclinedRows,
                SUM(CASE WHEN Level = @completedLevel OR Points > 0 THEN 1 ELSE 0 END) AS CompletedRows
                FROM Easter_Egg_Points
                WHERE Namn = @name AND Game = @game";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@name", Person.Name);
            cmd.Parameters.AddWithValue("@game", GameName);
            cmd.Parameters.AddWithValue("@declinedLevel", DeclinedGameLevel);
            cmd.Parameters.AddWithValue("@completedLevel", CompletedGameLevel);
            con.Open();
            using var reader = cmd.ExecuteReader();
            reader.Read();
            var totalRows = reader["TotalRows"] is DBNull ? 0 : Convert.ToInt32(reader["TotalRows"]);
            var declinedRows = reader["DeclinedRows"] is DBNull ? 0 : Convert.ToInt32(reader["DeclinedRows"]);
            var completedRows = reader["CompletedRows"] is DBNull ? 0 : Convert.ToInt32(reader["CompletedRows"]);
            var completed = completedRows > 0;
            var declined = declinedRows > 0 && completed == false;
            var started = totalRows > 0 && completed == false && declined == false;
            SetGameStateCache(started, completed, declined);
        }
        private static void SetGameStateCache(bool started, bool completed, bool declined)
        {
            isGameStarted = started;
            isGameCompleted = completed;
            isGameDeclined = declined;
        }
        public static void ResetGameStateCache()
        {
            isGameStarted = null;
            isGameCompleted = null;
            isGameDeclined = null;
        }
        private static bool ConfirmDiscoveryChoice(Control? owner)
        {
            InfoText.Question(DiscoveryQuestionMessage, CustomColors.InfoText_Color.Info, GameName, owner, true);
            if (InfoText.answer == InfoText.Answer.Yes)
                return true;
            EasterEgg_HighScore.Save_MarkerIfMissing(DeclinedGameLevel, GameName);
            SetGameStateCache(false, false, true);
            InfoText.Show(DeclinedMessage, CustomColors.InfoText_Color.Info, GameName, owner);
            return false;
        }
        public static bool EnsureStarted(Control? owner = null, bool showUnlockMessage = false)
        {
            if (string.IsNullOrWhiteSpace(Person.Name))
                return false;
            ResetGameStateCache();
            EnsureGameState();
            if (isGameCompleted ?? false)
                return true;
            if (isGameDeclined ?? false)
                return false;
            var wasStartedNow = false;
            if ((isGameStarted ?? false) == false)
            {
                if (!ConfirmDiscoveryChoice(owner))
                    return false;
                EasterEgg_HighScore.Save_MarkerIfMissing(StartMarkerLevel, GameName);
                SetGameStateCache(true, false, false);
                wasStartedNow = true;
            }
            if (showUnlockMessage && wasStartedNow)
                InfoText.Show(UnlockMessage, CustomColors.InfoText_Color.Info, GameName, owner);
            return true;
        }
        public static bool TryUnlockFromFlyingEgg(Control? owner)
        {
            return EnsureStarted(owner, true);
        }
        internal static void RegisterFoundLevel(int level)
        {
            EasterEgg_HighScore.Save_LevelFound(level, GameName);
            activeInstance?.RefreshLevel8Seal();
        }
        
        
        private void RefreshLevel8Seal()
        {
            CipherWheelLevels.Level_8.RefreshAvailability();
        }
        private void LayoutInfoPanelContents()
        {
            scorePanel.Bounds = introPanel.ScorePanelBounds;
            btn_TestCode.Bounds = introPanel.ActionButtonBounds;
            dgvHighscore.Bounds = introPanel.HighscoreContentBounds;
            scorePanel.BringToFront();
            dgvHighscore.BringToFront();
            btn_TestCode.BringToFront();
        }
        private void LoadScoreFromDatabase()
        {
            if (string.IsNullOrWhiteSpace(Person.Name))
            {
                wrongGuessCount = 0;
                currentScore = MaximumScore;
                SetGameStateCache(false, false, false);
                return;
            }
            using var con = new SqlConnection(Database.cs_Protocol);
            const string query = @"SELECT
                COUNT(*) AS TotalRows,
                SUM(CASE WHEN Level = @declinedLevel THEN 1 ELSE 0 END) AS DeclinedRows,
                SUM(CASE WHEN Level = @wrongGuessLevel THEN 1 ELSE 0 END) AS WrongGuesses,
                SUM(CASE WHEN Level = @completedLevel OR Points > 0 THEN 1 ELSE 0 END) AS CompletedScores,
                MAX(CASE WHEN Level = @completedLevel OR Points > 0 THEN Points ELSE 0 END) AS CompletedPoints
                FROM Easter_Egg_Points
                WHERE Namn = @name AND Game = @game";
            var cmd = new SqlCommand(query, con); ServerStatus.Add_Sql_Counter();
            cmd.Parameters.AddWithValue("@name", Person.Name);
            cmd.Parameters.AddWithValue("@game", GameName);
            cmd.Parameters.AddWithValue("@declinedLevel", DeclinedGameLevel);
            cmd.Parameters.AddWithValue("@wrongGuessLevel", WrongGuessLevel);
            cmd.Parameters.AddWithValue("@completedLevel", CompletedGameLevel);
            con.Open();
            using var reader = cmd.ExecuteReader();
            reader.Read();
            var totalRows = reader["TotalRows"] is DBNull ? 0 : Convert.ToInt32(reader["TotalRows"]);
            var declinedRows = reader["DeclinedRows"] is DBNull ? 0 : Convert.ToInt32(reader["DeclinedRows"]);
            var savedWrongGuesses = reader["WrongGuesses"] is DBNull ? 0 : Convert.ToInt32(reader["WrongGuesses"]);
            var completedScores = reader["CompletedScores"] is DBNull ? 0 : Convert.ToInt32(reader["CompletedScores"]);
            var completedPoints = reader["CompletedPoints"] is DBNull ? 0 : Convert.ToInt32(reader["CompletedPoints"]);
            if (completedScores > 0)
            {
                currentScore = Math.Max(0, completedPoints);
                wrongGuessCount = Math.Max(0, (MaximumScore - currentScore) / IncorrectGuessPenalty);
                SetGameStateCache(false, true, false);
                return;
            }
            if (declinedRows > 0)
            {
                wrongGuessCount = 0;
                currentScore = MaximumScore;
                SetGameStateCache(false, false, true);
                return;
            }
            wrongGuessCount = savedWrongGuesses;
            currentScore = Math.Max(0, MaximumScore - wrongGuessCount * IncorrectGuessPenalty);
            SetGameStateCache(totalRows > 0, false, false);
        }
        private void RefreshScorePanel()
        {
            scorePanel.ScoreValue = currentScore;
            scorePanel.WrongGuessCount = wrongGuessCount;
        }
        private void LoadHighscoreTable()
        {
            var table = EasterEgg_HighScore.LoadHighscores(GameName, 10, true);
            if (table.Columns.Contains("Level"))
                table.Columns.Remove("Level");
            dgvHighscore.DataSource = table;
            if (dgvHighscore.Columns.Contains("Namn"))
            {
                dgvHighscore.Columns["Namn"].HeaderText = "Name";
                dgvHighscore.Columns["Namn"].FillWeight = 42;
            }
            if (dgvHighscore.Columns.Contains("Datum"))
            {
                dgvHighscore.Columns["Datum"].HeaderText = "Date";
                dgvHighscore.Columns["Datum"].FillWeight = 38;
                dgvHighscore.Columns["Datum"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm";
            }
            if (dgvHighscore.Columns.Contains("Points"))
            {
                dgvHighscore.Columns["Points"].HeaderText = "Score";
                dgvHighscore.Columns["Points"].FillWeight = 20;
                dgvHighscore.Columns["Points"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            dgvHighscore.ClearSelection();
        }
        private void ShowVictoryCelebration()
        {
            var overlay = new CipherWheelVictoryOverlay(currentScore);
            overlay.CelebrationFinished += (_, _) =>
            {
                Controls.Remove(overlay);
                overlay.Dispose();
                btn_TestCode.BringToFront();
            };
            Controls.Add(overlay);
            overlay.BringToFront();
            overlay.Start();
        }
        private void SaveCompletedGame()
        {
            CipherWheelLevels.Level_6.ResetTrail();
            CipherWheelLevels.Level_7.Reset();
            EasterEgg_HighScore.ReplacePlayerScore(GameName, CompletedGameLevel, currentScore);
            SetGameStateCache(false, true, false);
            RefreshLevel8Seal();
            LoadHighscoreTable();
        }
        private void btn_TestCode_Click(object sender, EventArgs e)
        {
            Activity.Start();
            InfoText.Question(
                "Are you sure you wish to test the code?\n" +
                "Such haste might come at a cost...",
                CustomColors.InfoText_Color.Warning,
                "Proceed with the trial?",
                Form: this);
            if (InfoText.answer == InfoText.Answer.No)
            {
                Activity.Stop("Cancelled attempt at cracking the cipher wheel code.");
                return;
            }
            var enteredPassword = string.Concat(wheels.Select(w => w.SelectedChar));

            for (var i = 0; i < wheels.Count; i++)
            {
                var selected = wheels[i].SelectedChar;
                var correct = Password[i];

                if (selected == correct)
                    wheels[i].SetHighlight(Color.FromArgb(50, 198,239,206)); // Rätt plats, rätt bokstav
                else if (Password.Contains(selected))
                    wheels[i].SetHighlight(Color.FromArgb(50, 255,235,156)); // Fel plats, men rätt bokstav
                else
                    wheels[i].SetHighlight(Color.FromArgb(50,255,199,206)); // Fel bokstav helt
            }

            // Om hela lösenordet är rätt:
            if (enteredPassword == Password)
            {
                SaveCompletedGame();
                Activity.Stop($"Successfully cracked the cipher wheel code. Score: {currentScore}");
                ShowVictoryCelebration();
                return;
            }
            EasterEgg_HighScore.Save_Score(WrongGuessLevel,0, GameName);
            Activity.Stop($"Failed attempt at cracking the cipher wheel code. Tried Password: {enteredPassword}");
            LoadScoreFromDatabase();
            RefreshScorePanel();
            InfoText.Show("Oooops sorry! there goes another 100 points.", CustomColors.InfoText_Color.Bad, "Sorry", this);
        }
    }
}
