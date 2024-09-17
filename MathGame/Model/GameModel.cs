using System;
using System.Windows;

namespace MathGame.Model
{
    public class GameModel
    {
        private Random rnd = new Random();

        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public int TimeLeft { get; set; }
        public bool IsGameActive { get; set; }
        public int Streak { get; set; }
        public int HighestStreak { get; set; }
        public string CurrentQuestion { get; set; }
        public double CorrectAnswer { get; set; }
        public string Difficulty { get; set; }

        public GameModel()
        {
            ResetGame();
        }

        public void ResetGame()
        {
            Score = 0;
            TotalQuestions = 0;
            TimeLeft = 100;
            IsGameActive = false;
            Streak = 0;
            HighestStreak = 0;
            CurrentQuestion = "";
            CorrectAnswer = 0;
            Difficulty = "Fácil";
        }

        public void GenerateQuestion()
        {
            string operation = GetRandomOperation();
            int num1, num2;

            //traza para comprobar cambio dificultad
            MessageBox.Show("Dificultad:" + Difficulty);

            switch (Difficulty)
            {
                case "Fácil":
                    num1 = rnd.Next(1, 11);
                    num2 = rnd.Next(1, 11);
                    break;
                case "Medio":
                    num1 = rnd.Next(1, 51);
                    num2 = rnd.Next(1, 51);
                    break;
                case "Difícil":
                    num1 = rnd.Next(1, 101);
                    num2 = rnd.Next(1, 101);
                    break;
                default:
                    num1 = num2 = 0;
                    break;
            }

            switch (operation)
            {
                case "+":
                    CorrectAnswer = num1 + num2;
                    break;
                case "-":
                    CorrectAnswer = num1 - num2;
                    break;
                case "*":
                    CorrectAnswer = num1 * num2;
                    break;
                case "/":
                    num2 = num2 == 0 ? 1 : num2;
                    num1 = num2 * rnd.Next(1, 11);
                    CorrectAnswer = num1 / num2;
                    break;
            }

            CurrentQuestion = $"{num1} {operation} {num2} = ?";
            TimeLeft = 100;
        }

        private string GetRandomOperation()
        {
            string[] operations = { "+", "-", "*", "/" };
            return operations[rnd.Next(operations.Length)];
        }

        public bool CheckAnswer(double userAnswer)
        {
            TotalQuestions++;
            bool isCorrect = Math.Abs(userAnswer - CorrectAnswer) < 0.001;

            if (isCorrect)
            {
                int timeBonus = TimeLeft / 20;
                int difficultyMultiplier = Difficulty == "Fácil" ? 1 : (Difficulty == "Medio" ? 2 : 3);
                int pointsEarned = (10 + timeBonus) * difficultyMultiplier;
                Score += pointsEarned;
                Streak++;
                if (Streak > HighestStreak) HighestStreak = Streak;
            }
            else
            {
                Streak = 0;
            }

            return isCorrect;
        }
    }
}