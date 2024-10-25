using System;
using System.Timers; // Убедись, что это пространство имен указано
using Microsoft.Maui.Controls;

namespace jaaazzzzzzzzz
{
    public partial class TimerPage : ContentPage
    {
        private System.Timers.Timer timer; // Указываем явно, что это Timer из System.Timers
        private TimeSpan timeLeft;
        private bool isRunning;

        public TimerPage()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += OnTimerElapsed;
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            if (!isRunning &&
                int.TryParse(HoursEntry.Text, out int hours) &&
                int.TryParse(MinutesEntry.Text, out int minutes) &&
                int.TryParse(SecondsEntry.Text, out int seconds))
            {
                // Если таймер еще не запущен, устанавливаем время
                if (timeLeft == TimeSpan.Zero)
                {
                    timeLeft = new TimeSpan(hours, minutes, seconds);
                }

                isRunning = true;
                timer.Start();
            }
        }

        private void OnStartButtonPressed(object sender, EventArgs e)
        {
            // Изменяем цвет кнопки при нажатии
            ((ImageButton)sender).BackgroundColor = Color.FromHex("#3E8E41"); // Темно-зеленый
        }

        private void OnStartButtonReleased(object sender, EventArgs e)
        {
            // Возвращаем цвет кнопки к предыдущему состоянию
            ((ImageButton)sender).BackgroundColor = Color.FromHex("#4CAF50"); // Зеленый
        }

        private void OnPauseClicked(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timer.Stop();
                isRunning = false;
            }
        }

        private void OnPauseButtonPressed(object sender, EventArgs e)
        {
            // Изменяем цвет кнопки при нажатии
            ((ImageButton)sender).BackgroundColor = Color.FromHex("#D6A400"); // Темно-желтый
        }

        private void OnPauseButtonReleased(object sender, EventArgs e)
        {
            // Возвращаем цвет кнопки к предыдущему состоянию
            ((ImageButton)sender).BackgroundColor = Color.FromHex("#FFC107"); // Желтый
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            timer.Stop();
            isRunning = false;
            timeLeft = TimeSpan.Zero;
            TimerLabel.Text = "00:00:00";
            // Сбрасываем поля ввода, если нужно
            HoursEntry.Text = "";
            MinutesEntry.Text = "";
            SecondsEntry.Text = "";
        }

        private void OnResetButtonPressed(object sender, EventArgs e)
        {
            // Изменяем цвет кнопки при нажатии
            ((ImageButton)sender).BackgroundColor = Color.FromHex("#D32F2F"); // Темно-красный
        }

        private void OnResetButtonReleased(object sender, EventArgs e)
        {
            // Возвращаем цвет кнопки к предыдущему состоянию
            ((ImageButton)sender).BackgroundColor = Color.FromHex("#F44336"); // Красный
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (timeLeft > TimeSpan.Zero)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                Device.BeginInvokeOnMainThread(() => TimerLabel.Text = timeLeft.ToString(@"hh\:mm\:ss"));
            }
            else
            {
                timer.Stop();
                isRunning = false;
                Device.BeginInvokeOnMainThread(() => TimerLabel.Text = "Время вышло, товарищ!");
            }
        }
    }
}
