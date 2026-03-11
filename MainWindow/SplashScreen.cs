using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using DigitalProductionProgram.PrintingServices;

namespace DigitalProductionProgram.MainWindow
{
    public partial class SplashScreen : Form
    {
        private readonly List<string> _splashTexts =
        [
            "Initializing Digital Production Program",
            "Connecting to Monitor API and Loading Production Plan",
            "Loading User Settings and Preferences",
            "Synchronizing Order Data and Resources",
            "Finalizing Startup Procedures"
        ];
        private int _currentTextIndex = 0;
        private string _currentText => _currentTextIndex >= 0 ? _splashTexts[_currentTextIndex] : string.Empty;
        private readonly List<(string Text, Color Color)> _finishedTexts = new();
        private int _activeIndex = -1;
        private bool _isAnimating = false;
        private int _colorIndex = 1;
        private const int PauseLength = 2; // antal iterationer att pausa efter full text
        private int _pauseTicks = 0;
        private float StartY => (ClientSize.Height / 2f) + 140;        // första radens Y
        private const float LineSpacing = 80;
        private bool _allTextsWritten = false;
        private Color _currentActiveColor = CustomColors.LightBlue;
        private readonly System.Windows.Forms.Timer fadeTimer = new();
        public event Action FadeCompleted;

        private readonly List<Color> _activeColors =
        [
           // CustomColors.Blue,
            CustomColors.Parmesan_Font,
           // CustomColors.MediumGrey,
           // CustomColors.LightBlue,
           // CustomColors.Aqua_Font
        ];

        private CancellationTokenSource _cts;

        public SplashScreen()
        {
            InitializeComponent();
            StartAnimation_Initializing();
        }


        private void StartAnimation_Initializing()
        {
            _cts = new CancellationTokenSource();
            _ = AnimateTextAsync(_cts.Token);
        }
        public void ClearAllText()
        {
            // Stoppa eventuell pågående animation
            _cts?.Cancel();
            _cts = null;

            // Rensa all visuell state
            _finishedTexts.Clear();

            _currentTextIndex = 0;
            _activeIndex = -1;
            _pauseTicks = 0;

            _allTextsWritten = false;
            _isAnimating = false;

            _currentActiveColor = CustomColors.LightBlue;

            // Tvinga omritning
            Invalidate();
        }
        public void StartFadeOut()
        {
            fadeTimer.Interval = 60; // 50 FPS
            fadeTimer.Tick += FadeTimer_Tick;
            fadeTimer.Start();
        }
        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.05;  // fade ut på ~400 ms


            if (this.Opacity <= 0)
            {
                fadeTimer.Stop();
                this.Hide(); // Snyggare än Close direkt

                FadeCompleted?.Invoke(); // 🔥 SIGNALERA ATT FADEN ÄR KLAR

                this.Close(); // Stäng efter att mainform fått chans att visa sig
            }

        }

        public void StopAnimation()
        {
            _cts?.Cancel();
        }

        private async Task AnimateTextAsync(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested && !_allTextsWritten)
                {
                    // 1. Skriv bokstäver
                    if (_activeIndex < _currentText.Length - 1)
                    {
                        _activeIndex++;
                    }
                    else
                    {
                        // 2. Full text skriven → pausa
                        _pauseTicks++;

                        if (_pauseTicks >= PauseLength)
                        {
                            _pauseTicks = 0;

                            // 3. Commit exakt EN gång
                            _finishedTexts.Add((_currentText, _currentActiveColor));

                            // Är detta sista texten?
                            if (_currentTextIndex == _splashTexts.Count - 1)
                            {
                                _allTextsWritten = true;
                                Invalidate(); // sista repaint
                                break;
                            }

                            // Förbered nästa text
                            _currentTextIndex++;
                            _activeIndex = -1;
                            _currentActiveColor = CustomColors.LightBlue;// GetNextActiveColor();
                        }
                    }

                    Invalidate();
                    await Task.Delay(40, token);
                }
            }
            catch (OperationCanceledException)
            {
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception)
            {
            }
        }


        //private Color GetNextActiveColor()
        //{
        //    var color = _activeColors[_colorIndex];
        //    _colorIndex = (_colorIndex + 1) % _activeColors.Count;
        //    return color;
        //}
        [DebuggerStepThrough]
        private float MeasureTextWidth(Graphics g, Font font, string text)
        {
            float width = 0;
            foreach (char c in text)
            {
                width += g.MeasureString(c.ToString(), font).Width;
            }
            return width;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            base.OnPaint(e);

            using var font = new Font("Segoe UI", 32, FontStyle.Regular);

            // Rita färdiga texter – IDENTISKT med animationslogiken
            for (int i = 0; i < _finishedTexts.Count; i++)
            {
                var (text, color) = _finishedTexts[i];
                using var brush = new SolidBrush(color);

                float totalWidth = MeasureTextWidth(e.Graphics, font, text);
                float x = (ClientSize.Width - totalWidth) / 2f;
                float y = StartY + i * LineSpacing;

                float letterX = x;
                for (int c = 0; c < text.Length; c++)
                {
                    string letter = text[c].ToString();
                    var size = e.Graphics.MeasureString(letter, font);
                    e.Graphics.DrawString(letter, font, brush, letterX, y);
                    letterX += size.Width;
                }
            }


            // Rita aktuell text bokstav för bokstav
            if (!_allTextsWritten && !string.IsNullOrEmpty(_currentText))
            {
                float totalWidth = MeasureTextWidth(e.Graphics, font, _currentText);
                float x = (ClientSize.Width - totalWidth) / 2f;
                float y = StartY + _finishedTexts.Count * LineSpacing;

                using var activeBrush = new SolidBrush(_currentActiveColor); // bara en brush
                for (int i = 0; i <= _activeIndex && i < _currentText.Length; i++)
                {
                    string letter = _currentText[i].ToString();
                    var size = e.Graphics.MeasureString(letter, font);
                    e.Graphics.DrawString(letter, font, activeBrush, x, y);
                    x += size.Width;
                }

                // Rita resten med transparent brush (kan också hoppa över)
                // Ingen ny pensel skapas per bokstav
                if (_activeIndex + 1 < _currentText.Length)
                {
                    using var transparentBrush = new SolidBrush(Color.Transparent);
                    for (int i = _activeIndex + 1; i < _currentText.Length; i++)
                    {
                        string letter = _currentText[i].ToString();
                        var size = e.Graphics.MeasureString(letter, font);
                        e.Graphics.DrawString(letter, font, transparentBrush, x, y);
                        x += size.Width;
                    }
                }
            }
        }

    }
}
