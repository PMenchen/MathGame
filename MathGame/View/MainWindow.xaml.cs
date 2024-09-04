using MathGame.View;
using System.Windows;
using System.Windows.Input;
using MathGame.Model;
using MathGame.Model.Controller;

namespace MathGame.View
{
    public partial class MainWindow : Window
    {
        private GameModel model;
        private GameController controller;

        public MainWindow()
        {
            InitializeComponent();
            model = new GameModel();
            controller = new GameController(model, this);

            StartButton.Click += (s, e) => controller.StartGame();
            CheckButton.Click += (s, e) => controller.CheckAnswerPublic();
            EndGameButton.Click += (s, e) => controller.EndGame();
            DifficultyComboBox.SelectionChanged += (s, e) => controller.UpdateDifficulty();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void AnswerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (AnswerBox.Text != "")
                {
                    controller.CheckAnswerPublic();
                }
            }
        }

        public void ShowCustomMessageBox(string title, string message)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox(title, message);
            customMessageBox.ShowDialog();
        }
    }
}