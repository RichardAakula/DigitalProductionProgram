using DigitalProductionProgram.Help;
using DigitalProductionProgram.MainWindow;
using DigitalProductionProgram.PrintingServices;
using Timer = System.Windows.Forms.Timer;

namespace DigitalProductionProgram.EasterEggs.The_Cipher_Wheel
{
    internal static class CipherWheelLevels
    {
        internal static class Level_1
        {
            private static string Riddle_1 =>
                "This riddle holds the key, the first mark you’ll feel,\n" +
                "The opening symbol on The Cipher Wheel.\n\n" +
                "I am the start of hope, and the start of home.\n" +
                "In the alphabet’s heart, I stand first alone. \n" +
                "Without me, questions wander lost and awry—\n" +
                "What letter am I? Come on, give it a try.";
            internal static void ShowRiddle(Control parent)
            {
                EasterEgg_Code.RegisterFoundLevel(1);
                InfoText.Show(Riddle_1, CustomColors.InfoText_Color.Info, EasterEgg_Code.GameName, parent);
            }
        }
        internal static class Level_2
        {
            private static int clickCount;
            private static DateTime firstClickTime;
            private static int Attempts
            {
                get
                {
                    return EasterEgg_HighScore.CountEntries(EasterEgg_Code.GameName, EasterEgg_Code.KnockAttemptLevel) + 1;
                }
            }
            private static readonly string[] crypticErrorMessages = new[]
            {
                "The rhythm slipped through the cracks of time — the dance must fall within the fleeting moments.",
                "A shadow of discord lingers — the cadence only reveals itself in perfect timing.",
                "Echoes fall silent when the beat is lost; remember, the secret pulses only in precise intervals.",
                "The sequence falters in the void of haste or delay — align your touch to the narrow window.",
                "A whisper missed the call of time’s delicate balance; the key lies in striking the moment just right.",
                "Between beats, the secret fades — your rhythm must dance within the briefest seconds.",
                "The pulse resists the hands that hurry or linger — only the timed touch unlocks the path.",
                "Remember! Not too fast, Not too slow."
            };
            internal static void KnockKnock(Control parent, Point clickLocation)
            {
                if (EasterEgg_Code.IsGameStarted == false)
                    return;
                if (clickCount == 0)
                {
                    firstClickTime = DateTime.Now;
                    ShowKnockTip(parent);
                }
                clickCount++;
                var elapsed = (DateTime.Now - firstClickTime).TotalSeconds;
                if (elapsed > 6)
                {
                    InfoText.Show(
                        $"You struck {clickCount} times in {elapsed:F2} heartbeats,\n" +
                        "yet the secret rhythm remains elusive.\n" +
                        "Only the one who knocks the right number of times\n" +
                        "between four and six heartbeats shall uncover the second symbol of The Cipher Wheel.",
                        CustomColors.InfoText_Color.Bad, EasterEgg_Code.GameName, parent);
                    EasterEgg_HighScore.Save_Score(EasterEgg_Code.KnockAttemptLevel,0, EasterEgg_Code.GameName);
                    clickCount = 0;
                    return;
                }
                if (elapsed is >= 4 and <= 6)
                {
                    if (clickCount == 4)
                    {
                        EasterEgg_Code.RegisterFoundLevel(2);
                        InfoText.Show(
                            $"A hidden path reveals itself...\n" +
                            $"You have unlocked the *second* symbol of The Cipher Wheel.\n\n" +
                            $"It took you {Attempts} attempt{(Attempts > 1 ? "s" : "")} to find the right rhythm.\n" +
                            $"But beware — only those who remember the number of knocks shall find their way.",
                            CustomColors.InfoText_Color.Ok,
                            EasterEgg_Code.GameName,
                            parent, true);
                        clickCount = 0;
                    }
                    else
                    {
                        var rnd = new Random();
                        var msg = crypticErrorMessages[rnd.Next(crypticErrorMessages.Length)];
                        var info = $"{clickCount} knocks in {elapsed:F2} heartbeats.";
                        InfoText.Show($"{msg}\n\n{info}\n" +
                                      $"Only the one who knocks the right number of times\n" +
                                      $"between four and six heartbeats shall uncover the second symbol of The Cipher Wheel.",
                            CustomColors.InfoText_Color.Bad, EasterEgg_Code.GameName, parent);
                        EasterEgg_HighScore.Save_Score(EasterEgg_Code.KnockAttemptLevel,0, EasterEgg_Code.GameName);
                        clickCount = 0;
                    }
                }
            }
            private static void ShowKnockTip(Control parent)
            {
                var cursorPos = Cursor.Position;
                var tipLocation = parent.PointToClient(cursorPos);
                var toolTip = new ToolTip();
                toolTip.OwnerDraw = true;
                toolTip.Draw += (sender, e) =>
                {
                    e.Graphics.FillRectangle(Brushes.LightYellow, e.Bounds);
                    using var f = new Font("Segoe UI", 10, FontStyle.Bold);
                    e.Graphics.DrawString(e.ToolTipText, f, Brushes.Black, e.Bounds);
                };
                toolTip.Popup += (sender, e) =>
                {
                    e.ToolTipSize = TextRenderer.MeasureText(toolTip.GetToolTip(e.AssociatedControl), new Font("Segoe UI", 10, FontStyle.Bold));
                };
                toolTip.Show("Knock knock...", parent, tipLocation, 2000);
            }
        }
        internal static class Level_3
        {
            private static CipherWheelLevel3Overlay? overlay;
            private static string Riddle_1 =>
                "Which key did you press just now?\n" +
                "Do not let that letter drift away.\n\n" +
                "The key that summoned this vision\n" +
                "may guide you to the third symbol\n" +
                "of The Cipher Wheel.";
            internal static bool TryShowPressKeyClue(Main_Form parent, Keys keyData)
            {
                var keyCode = keyData & Keys.KeyCode;
                var modifiers = keyData & Keys.Modifiers;
                if (EasterEgg_Code.IsGameStarted == false || keyCode != Keys.P || modifiers != Keys.None && modifiers != Keys.Shift)
                    return false;
                if (IsTextInputFocused(parent))
                    return false;
                if (overlay is { IsDisposed: false, Visible: true })
                {
                    overlay.RestartAnimation();
                    return true;
                }
                EasterEgg_Code.RegisterFoundLevel(3);
                overlay = new CipherWheelLevel3Overlay(parent, Riddle_1);
                overlay.FormClosed += (_, _) => overlay = null;
                overlay.Show(parent);
                return true;
            }
            private static bool IsTextInputFocused(Control root)
            {
                var focusedControl = GetFocusedControl(root);
                while (focusedControl != null)
                {
                    if (focusedControl is TextBoxBase ||
                        focusedControl is UpDownBase ||
                        (focusedControl is ComboBox combo && combo.DropDownStyle != ComboBoxStyle.DropDownList) ||
                        focusedControl is DataGridViewTextBoxEditingControl ||
                        (focusedControl is DataGridView dgv && dgv.IsCurrentCellInEditMode))
                        return true;
                    focusedControl = focusedControl.Parent;
                }
                return false;
            }
            private static Control? GetFocusedControl(Control root)
            {
                if (root.Focused)
                    return root;
                foreach (Control child in root.Controls)
                {
                    if (child.ContainsFocus == false && child.Focused == false)
                        continue;
                    var focusedChild = GetFocusedControl(child);
                    if (focusedChild != null)
                        return focusedChild;
                    return child;
                }
                return null;
            }
        }
        internal static class Level_4
        {
            private static PictureBox? profilePicture;
            private static Main_Form? parentForm;
            private static Timer? pulseTimer;
            private static Rectangle originalBounds;
            private static int hoverSessionId;
            private static int pulseCount;
            private static bool clueShownThisHover;
            internal static void AttachToProfilePicture(PictureBox pictureBox, Main_Form form)
            {
                if (ReferenceEquals(profilePicture, pictureBox) && ReferenceEquals(parentForm, form))
                    return;
                if (profilePicture != null)
                {
                    profilePicture.MouseEnter -= ProfilePicture_MouseEnter;
                    profilePicture.MouseLeave -= ProfilePicture_MouseLeave;
                }
                profilePicture = pictureBox;
                parentForm = form;
                originalBounds = pictureBox.Bounds;
                pulseTimer ??= new Timer { Interval = 900 };
                pulseTimer.Tick -= PulseTimer_Tick;
                pulseTimer.Tick += PulseTimer_Tick;
                pictureBox.MouseEnter += ProfilePicture_MouseEnter;
                pictureBox.MouseLeave += ProfilePicture_MouseLeave;
            }
            internal static void ResetProfilePulse()
            {
                hoverSessionId++;
                pulseCount = 0;
                clueShownThisHover = false;
                pulseTimer?.Stop();
                RestoreProfilePicture();
            }
            private static void ProfilePicture_MouseEnter(object? sender, EventArgs e)
            {
                if (EasterEgg_Code.IsGameStarted == false || profilePicture == null || profilePicture.Visible == false || profilePicture.Image == null)
                    return;
                hoverSessionId++;
                pulseCount = 0;
                clueShownThisHover = false;
                originalBounds = profilePicture.Bounds;
                pulseTimer?.Stop();
                pulseTimer?.Start();
            }
            private static void ProfilePicture_MouseLeave(object? sender, EventArgs e)
            {
                ResetProfilePulse();
            }
            private static void PulseTimer_Tick(object? sender, EventArgs e)
            {
                if (profilePicture == null || parentForm == null || profilePicture.Visible == false || profilePicture.Image == null)
                {
                    ResetProfilePulse();
                    return;
                }
                pulseCount++;
                var sessionId = hoverSessionId;
                PulseProfilePicture(sessionId);
                if (pulseCount >= 4)
                {
                    pulseTimer?.Stop();
                    if (clueShownThisHover == false)
                    {
                        EasterEgg_Code.RegisterFoundLevel(4);
                        clueShownThisHover = true;
                        InfoText.Show("The portrait answered your patience...\n" +
                                      "Four quiet pulses were enough.\n" +
                                      "The fourth symbol of The Cipher Wheel is the first letter in Pulse.",
                            CustomColors.InfoText_Color.Info,
                            EasterEgg_Code.GameName,
                            parentForm,
                            true);
                    }
                }
            }
            private static async void PulseProfilePicture(int sessionId)
            {
                if (profilePicture == null)
                    return;
                var pulseBounds = Rectangle.Inflate(originalBounds, 6, 8);
                profilePicture.Bounds = pulseBounds;
                profilePicture.BackColor = Color.FromArgb(35, 220, 184, 95);
                await Task.Delay(180);
                if (sessionId != hoverSessionId)
                    return;
                RestoreProfilePicture();
            }
            private static void RestoreProfilePicture()
            {
                if (profilePicture == null || profilePicture.IsDisposed)
                    return;
                profilePicture.Bounds = originalBounds;
                profilePicture.BackColor = Color.Transparent;
            }
        }
        
        //The Cipher Wheel - Trycker snabbt tre gånger på InfoPanelen
        internal static class Level_5
        {
            private static CipherWheelInfoPanel? lorePanel;
            private static Form? parentForm;
            private static DateTime lastClickTime;
            private static int clickCount;
            private static bool isQuestionSequenceRunning;
            private static readonly string[] Questions =
            {
                "Can a key open what is locked?",
                "Can a secret hide in plain sight?",
                "Can one small word move you forward?"
            };
            private static readonly string[] Titles =
            {
                "The First Oath",
                "The Second Oath",
                "The Final Oath"
            };
            internal static void AttachToLorePanel(CipherWheelInfoPanel panel, Form form)
            {
                if (ReferenceEquals(lorePanel, panel) && ReferenceEquals(parentForm, form))
                    return;
                if (lorePanel != null)
                    lorePanel.MouseDown -= LorePanel_MouseDown;
                lorePanel = panel;
                parentForm = form;
                lorePanel.MouseDown += LorePanel_MouseDown;
            }
            private static void LorePanel_MouseDown(object? sender, MouseEventArgs e)
            {
                if (EasterEgg_Code.IsGameStarted == false || isQuestionSequenceRunning || parentForm == null || e.Button != MouseButtons.Left)
                    return;
                var now = DateTime.Now;
                if ((now - lastClickTime).TotalMilliseconds > 1200)
                    clickCount = 0;
                lastClickTime = now;
                clickCount++;
                if (clickCount < 3)
                    return;
                clickCount = 0;
                StartQuestionSequence();
            }
            private static void StartQuestionSequence()
            {
                if (parentForm == null)
                    return;
                isQuestionSequenceRunning = true;
                try
                {
                    var answeredYesToAll = true;
                    for (var i = 0; i < Questions.Length; i++)
                    {
                        InfoText.Question(Questions[i], CustomColors.InfoText_Color.Info, Titles[i], parentForm, true, buttonStrings: ["Yes", "No"]);
                        if (InfoText.answer != InfoText.Answer.Yes)
                            answeredYesToAll = false;
                    }
                    if (answeredYesToAll)
                    {
                        EasterEgg_Code.RegisterFoundLevel(5);
                        InfoText.Show("The lock accepts your answer...\nThree times you answered YES.\nThe fifth symbol of The Cipher Wheel\nis the first letter in that word.", CustomColors.InfoText_Color.Ok, EasterEgg_Code.GameName, parentForm, true);
                    }
                    else
                        InfoText.Show("The lock heard hesitation.\nReturn when your answer is the same\nthree times in a row.", CustomColors.InfoText_Color.Bad, EasterEgg_Code.GameName, parentForm, true);
                }
                finally
                {
                    isQuestionSequenceRunning = false;
                }
            }
        }
        
        //The Cipher Wheel - Kör musen mot alla kanter i rätt ordning
        internal static class Level_6   
        {
            private enum EdgeDirection
            {
                North,
                South,
                West,
                East
            }
            private static readonly EdgeDirection[] Sequence =
            {
                EdgeDirection.North,
                EdgeDirection.South,
                EdgeDirection.West,
                EdgeDirection.East
            };
            private static readonly Color BaseColor = Color.FromArgb(80,6, 81, 87);
            private static readonly Color SuccessColor = Color.FromArgb(180, 198, 239, 206);
            private static readonly Color FailureColor = Color.FromArgb(180,255, 199, 206);
            private static Form? parentForm;
            private static Panel? pnlNorth;
            private static Panel? pnlSouth;
            private static Panel? pnlWest;
            private static Panel? pnlEast;
            private static Timer? resetTimer;
            private static int sequenceIndex;
            internal static void AttachToForm(Form form)
            {
                if (ReferenceEquals(parentForm, form))
                    return;
                DetachFromCurrentForm();
                parentForm = form;
                pnlNorth = CreateEdgePanel(EdgeDirection.North, new Point(0, 0), new Size(form.ClientSize.Width, 14), AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                pnlSouth = CreateEdgePanel(EdgeDirection.South, new Point(0, form.ClientSize.Height - 14), new Size(form.ClientSize.Width, 14), AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                pnlWest = CreateEdgePanel(EdgeDirection.West, new Point(0, 0), new Size(14, form.ClientSize.Height), AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left);
                pnlEast = CreateEdgePanel(EdgeDirection.East, new Point(form.ClientSize.Width - 14, 0), new Size(14, form.ClientSize.Height), AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
                form.Controls.Add(pnlNorth);
                form.Controls.Add(pnlSouth);
                form.Controls.Add(pnlWest);
                form.Controls.Add(pnlEast);
                pnlNorth.BringToFront();
                pnlSouth.BringToFront();
                pnlWest.BringToFront();
                pnlEast.BringToFront();
                resetTimer ??= new Timer { Interval = 650 };
                resetTimer.Tick -= ResetTimer_Tick;
                resetTimer.Tick += ResetTimer_Tick;
                ResetTrail();
            }
            internal static void ResetTrail()
            {
                sequenceIndex = 0;
                resetTimer?.Stop();
                SetPanelColor(pnlNorth, BaseColor);
                SetPanelColor(pnlSouth, BaseColor);
                SetPanelColor(pnlWest, BaseColor);
                SetPanelColor(pnlEast, BaseColor);
            }
            private static void DetachFromCurrentForm()
            {
                if (pnlNorth != null)
                    pnlNorth.MouseEnter -= EdgePanel_MouseEnter;
                if (pnlSouth != null)
                    pnlSouth.MouseEnter -= EdgePanel_MouseEnter;
                if (pnlWest != null)
                    pnlWest.MouseEnter -= EdgePanel_MouseEnter;
                if (pnlEast != null)
                    pnlEast.MouseEnter -= EdgePanel_MouseEnter;
                if (parentForm != null && parentForm.IsDisposed == false)
                {
                    if (pnlNorth != null)
                        parentForm.Controls.Remove(pnlNorth);
                    if (pnlSouth != null)
                        parentForm.Controls.Remove(pnlSouth);
                    if (pnlWest != null)
                        parentForm.Controls.Remove(pnlWest);
                    if (pnlEast != null)
                        parentForm.Controls.Remove(pnlEast);
                }
                pnlNorth = null;
                pnlSouth = null;
                pnlWest = null;
                pnlEast = null;
            }
            private static Panel CreateEdgePanel(EdgeDirection direction, Point location, Size size, AnchorStyles anchor)
            {
                var panel = new Panel
                {
                    BackColor = BaseColor,
                    Location = location,
                    Size = size,
                    Anchor = anchor,
                    Tag = direction,
                    Cursor = Cursors.Cross
                };
                panel.MouseEnter += EdgePanel_MouseEnter;
                return panel;
            }
            private static void EdgePanel_MouseEnter(object? sender, EventArgs e)
            {
                if (EasterEgg_Code.IsGameStarted == false || parentForm == null || resetTimer is { Enabled: true } || sender is not Control ctrl || ctrl.Tag is not EdgeDirection direction)
                    return;
                if (Sequence[sequenceIndex] == direction)
                {
                    SetPanelColor(ctrl, SuccessColor);
                    sequenceIndex++;
                    if (sequenceIndex < Sequence.Length)
                        return;
                    EasterEgg_Code.RegisterFoundLevel(6);
                    InfoText.Show("You traced the sign upon the frame...\nNorth. South. West. East.\nThe sixth symbol of The Cipher Wheel\nbears the first mark of where morning rises.", CustomColors.InfoText_Color.Ok, EasterEgg_Code.GameName, parentForm, true);
                    ResetTrail();
                    return;
                }
                SetPanelColor(ctrl, FailureColor);
                sequenceIndex = 0;
                resetTimer?.Stop();
                resetTimer?.Start();
            }
            private static void ResetTimer_Tick(object? sender, EventArgs e)
            {
                resetTimer?.Stop();
                ResetTrail();
            }
            private static void SetPanelColor(Control? control, Color color)
            {
                if (control == null || control.IsDisposed)
                    return;
                control.BackColor = color;
            }
        }
        
        //MainForm - Dubbleklicka på Grade för att låsa upp
        internal static class Level_7
        {
            private static Control? percentLabel;
            private static Control? gradeFill;
            private static Main_Form? parentForm;
            private static CipherWheelChalkboardForm? chalkboard;
            internal static void AttachToGradeControls(Control lblPercent, Control pnlGradeFill, Main_Form form)
            {
                if (ReferenceEquals(percentLabel, lblPercent) && ReferenceEquals(gradeFill, pnlGradeFill) && ReferenceEquals(parentForm, form))
                    return;
                DetachFromCurrentControls();
                percentLabel = lblPercent;
                gradeFill = pnlGradeFill;
                parentForm = form;
                percentLabel.MouseDoubleClick += GradeControl_MouseDoubleClick;
                gradeFill.MouseDoubleClick += GradeControl_MouseDoubleClick;
            }
            internal static void Reset()
            {
                if (chalkboard is { IsDisposed: false })
                {
                    chalkboard.Close();
                    chalkboard.Dispose();
                }
                chalkboard = null;
            }
            private static void DetachFromCurrentControls()
            {
                if (percentLabel != null)
                    percentLabel.MouseDoubleClick -= GradeControl_MouseDoubleClick;
                if (gradeFill != null)
                    gradeFill.MouseDoubleClick -= GradeControl_MouseDoubleClick;
            }
            private static void GradeControl_MouseDoubleClick(object? sender, MouseEventArgs e)
            {
                if (EasterEgg_Code.IsGameStarted == false || parentForm == null || e.Button != MouseButtons.Left)
                    return;
                if (chalkboard is { IsDisposed: false, Visible: true })
                {
                    chalkboard.Focus();
                    return;
                }
                chalkboard = new CipherWheelChalkboardForm();
                chalkboard.GlyphSolved += Chalkboard_GlyphSolved;
                chalkboard.FormClosed += Chalkboard_FormClosed;
                chalkboard.Show(parentForm);
                chalkboard.BringToFront();
                chalkboard.Focus();
            }
            private static void Chalkboard_GlyphSolved(object? sender, EventArgs e)
            {
                EasterEgg_Code.RegisterFoundLevel(7);
                if (parentForm != null)
                    InfoText.Show("The slate remembers your hand...\nA golden mark now guards the seventh lock of The Cipher Wheel.\nHold that symbol in memory.", CustomColors.InfoText_Color.Ok, EasterEgg_Code.GameName, parentForm, true);
            }
            private static void Chalkboard_FormClosed(object? sender, FormClosedEventArgs e)
            {
                if (chalkboard != null)
                {
                    chalkboard.GlyphSolved -= Chalkboard_GlyphSolved;
                    chalkboard.FormClosed -= Chalkboard_FormClosed;
                }
                chalkboard = null;
            }
        }
        
        //The Cipher Wheel - Ringar runt alla kodlås som man hovrar över för att låsa upp
        internal static class Level_8
        {
            private static readonly Color BaseColor = Color.FromArgb(212, 181, 96);
            private static readonly Color HoverColor = Color.FromArgb(238, 214, 140);
            private static readonly Color SuccessColor = Color.FromArgb(92, 181, 104);
            private const int HoverDelayMs = 650;
            private static readonly List<CodeWheel> sealWheels = new();
            private static bool[] activationStates = Array.Empty<bool>();
            private static int[] hoverSessions = Array.Empty<int>();
            private static EasterEgg_Code? parentForm;
            private static bool isAvailable;
            private static bool isRevealing;
            internal static void AttachToWheels(IReadOnlyList<CodeWheel> wheels, EasterEgg_Code form)
            {
                if (ReferenceEquals(parentForm, form) && sealWheels.Count == wheels.Count)
                {
                    var allMatch = true;
                    for (var i = 0; i < wheels.Count; i++)
                    {
                        if (ReferenceEquals(sealWheels[i], wheels[i]) == false)
                        {
                            allMatch = false;
                            break;
                        }
                    }
                    if (allMatch)
                    {
                        RefreshAvailability();
                        return;
                    }
                }
                Detach();
                parentForm = form;
                for (var i = 0; i < wheels.Count; i++)
                {
                    sealWheels.Add(wheels[i]);
                    wheels[i].MouseEnter += Wheel_MouseEnter;
                    wheels[i].MouseLeave += Wheel_MouseLeave;
                }
                activationStates = new bool[sealWheels.Count];
                hoverSessions = new int[sealWheels.Count];
                RefreshAvailability();
            }
            internal static void Detach()
            {
                for (var i = 0; i < sealWheels.Count; i++)
                {
                    sealWheels[i].MouseEnter -= Wheel_MouseEnter;
                    sealWheels[i].MouseLeave -= Wheel_MouseLeave;
                    sealWheels[i].ClearSealRing();
                }
                sealWheels.Clear();
                activationStates = Array.Empty<bool>();
                hoverSessions = Array.Empty<int>();
                parentForm = null;
                isAvailable = false;
                isRevealing = false;
            }
            internal static void RefreshAvailability()
            {
                if (sealWheels.Count == 0)
                    return;
                var shouldShowSeal = parentForm != null && EasterEgg_Code.IsGameStarted && EasterEgg_HighScore.HasFoundAllLevels(EasterEgg_Code.GameName, 7);
                if (shouldShowSeal == false)
                {
                    isAvailable = false;
                    isRevealing = false;
                    ResetSealState(false);
                    return;
                }
                isAvailable = true;
                var level8Found = EasterEgg_HighScore.HasFoundLevel(EasterEgg_Code.GameName, 8);
                if (level8Found)
                {
                    for (var i = 0; i < activationStates.Length; i++)
                        activationStates[i] = true;
                }
                ApplySealColors(level8Found ? SuccessColor : BaseColor);
            }
            private static void Wheel_MouseEnter(object? sender, EventArgs e)
            {
                if (isAvailable == false || isRevealing || sender is not CodeWheel wheel)
                    return;
                var index = sealWheels.IndexOf(wheel);
                if (index < 0 || activationStates[index])
                    return;
                var session = ++hoverSessions[index];
                wheel.SetSealRing(HoverColor);
                AwaitSealTouch(index, session);
            }
            private static void Wheel_MouseLeave(object? sender, EventArgs e)
            {
                if (sender is not CodeWheel wheel)
                    return;
                var index = sealWheels.IndexOf(wheel);
                if (index < 0 || activationStates.Length <= index)
                    return;
                hoverSessions[index]++;
                if (isAvailable == false || activationStates[index])
                    return;
                wheel.SetSealRing(BaseColor);
            }
            private static async void AwaitSealTouch(int index, int session)
            {
                await Task.Delay(HoverDelayMs);
                if (isAvailable == false || isRevealing || index >= sealWheels.Count || hoverSessions.Length <= index || activationStates.Length <= index)
                    return;
                if (hoverSessions[index] != session || activationStates[index])
                    return;
                activationStates[index] = true;
                sealWheels[index].SetSealRing(SuccessColor);
                if (AllRingsAreGreen())
                    RevealFinalClue();
            }
            private static bool AllRingsAreGreen()
            {
                if (activationStates.Length == 0)
                    return false;
                for (var i = 0; i < activationStates.Length; i++)
                {
                    if (activationStates[i] == false)
                        return false;
                }
                return true;
            }
            private static void RevealFinalClue()
            {
                if (parentForm == null || isRevealing)
                    return;
                isRevealing = true;
                EasterEgg_Code.RegisterFoundLevel(8);
                ApplySealColors(SuccessColor);
                InfoText.Show("The Da Vinci Seal is complete...\nEight rings answered your patience.\nWhat the beast would roar as 666,\nThe Cipher Wheel demands only one of these numbers.",
                    CustomColors.InfoText_Color.Ok, EasterEgg_Code.GameName, parentForm, true);
                isRevealing = false;
            }
            private static void ResetSealState(bool preserveSolvedState)
            {
                if (hoverSessions.Length != sealWheels.Count)
                    hoverSessions = new int[sealWheels.Count];
                if (activationStates.Length != sealWheels.Count)
                    activationStates = new bool[sealWheels.Count];
                for (var i = 0; i < sealWheels.Count; i++)
                {
                    hoverSessions[i] = 0;
                    activationStates[i] = preserveSolvedState;
                    if (preserveSolvedState)
                        sealWheels[i].SetSealRing(SuccessColor);
                    else
                        sealWheels[i].ClearSealRing();
                }
            }
            private static void ApplySealColors(Color color)
            {
                if (activationStates.Length != sealWheels.Count)
                    activationStates = new bool[sealWheels.Count];
                if (hoverSessions.Length != sealWheels.Count)
                    hoverSessions = new int[sealWheels.Count];
                for (var i = 0; i < sealWheels.Count; i++)
                {
                    var ringColor = activationStates[i] ? SuccessColor : color;
                    sealWheels[i].SetSealRing(ringColor);
                }
            }
        }
    }
}
