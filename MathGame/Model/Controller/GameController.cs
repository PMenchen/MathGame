using System;
using System.Windows.Controls;
using System.Windows.Threading;
using MathGame.View;

namespace MathGame.Model.Controller
{
    public class GameController
    {
        private GameModel model;
        private MainWindow view;
        private DispatcherTimer timer;

        public GameController(GameModel model, MainWindow view)
        {
            this.model = model;
            this.view = view;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += Timer_Tick;

            /*view.StartButton.Click += StartButton_Click;
            view.CheckButton.Click += CheckButton_Click;
            view.EndGameButton.Click += EndGameButton_Click;
            view.AnswerBox.KeyDown += view.AnswerBox_KeyDown;
            view.DifficultyComboBox.SelectionChanged += DifficultyComboBox_SelectionChanged;*/
        }

        /*private void StartButton_Click(object sender, EventArgs e)
        {
            StartGame();
        }*/

        public void StartGame()
        {
            model.ResetGame();
            model.IsGameActive = true;
            UpdateUI();
            GenerateQuestion();
            StartTimer();
        }

        private void GenerateQuestion()
        {
            model.GenerateQuestion();
            view.QuestionText.Text = model.CurrentQuestion;
            view.AnswerBox.Text = "";
            view.ResultText.Text = "";
            view.TimeProgressBar.Value = model.TimeLeft;
        }

        /*private void CheckButton_Click(object sender, EventArgs e)
        {
            CheckAnswerInternal();
        }*/

        public void CheckAnswerPublic()
        {
            if (model.IsGameActive)
            {
                CheckAnswerInternal();
            }
        }

        private void CheckAnswerInternal()
        {
            if (!model.IsGameActive) return;

            if (double.TryParse(view.AnswerBox.Text, out double userAnswer))
            {
                bool isCorrect = model.CheckAnswer(userAnswer);

                if (isCorrect)
                {
                    view.ResultText.Text = "¡Correcto!";
                    view.ResultText.Foreground = System.Windows.Media.Brushes.Green;
                }
                else
                {
                    view.ResultText.Text = $"Incorrecto. La respuesta era {model.CorrectAnswer:F2}.";
                    view.ResultText.Foreground = System.Windows.Media.Brushes.Red;
                }

                UpdateUI();
                timer.Stop();
                DispatcherTimer pauseTimer = new DispatcherTimer();
                pauseTimer.Interval = TimeSpan.FromSeconds(2);
                pauseTimer.Tick += (s, e) =>
                {
                    pauseTimer.Stop();
                    if (model.IsGameActive)
                    {
                        GenerateQuestion();
                        StartTimer();
                    }
                };
                pauseTimer.Start();
            }
            else
            {
                view.ShowCustomMessageBox("Error", "Por favor, introduce un número válido.");
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (model.TimeLeft > 0)
            {
                model.TimeLeft--;
                view.TimeProgressBar.Value = model.TimeLeft;
            }
            else
            {
                EndGame();
            }
        }

        private void StartTimer()
        {
            model.TimeLeft = 100;
            view.TimeProgressBar.Value = model.TimeLeft;
            timer.Start();
        }

        private void UpdateUI()
        {
            view.ScoreText.Text = $"Puntuación: {model.Score} | Preguntas: {model.TotalQuestions}";
            view.StreakText.Text = $"Racha: {model.Streak} | Mejor racha: {model.HighestStreak}";
            view.StartButton.Visibility = model.IsGameActive ? System.Windows.Visibility.Collapsed : System.Windows.Visibility.Visible;
            view.DifficultyComboBox.IsEnabled = !model.IsGameActive;
            view.CheckButton.IsEnabled = model.IsGameActive;
            view.AnswerBox.IsEnabled = model.IsGameActive;
            view.EndGameButton.Visibility = model.IsGameActive ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
        }

        /*private void EndGameButton_Click(object sender, EventArgs e)
        {
            EndGame();
        }*/

        public void EndGame()
        {
            model.IsGameActive = false;
            timer.Stop();
            UpdateUI();
            view.ShowCustomMessageBox("Fin del juego", $"Juego terminado.\nPuntuación final: {model.Score}\nPreguntas respondidas: {model.TotalQuestions}\nMejor racha: {model.HighestStreak}");
        }

        public void UpdateDifficulty()
        {
            if (view.DifficultyComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                model.Difficulty = selectedItem.Content.ToString();
            }
        }
    }
}