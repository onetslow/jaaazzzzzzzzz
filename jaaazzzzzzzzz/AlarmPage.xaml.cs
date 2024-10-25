using System;
using System.Timers;
using Microsoft.Maui.Controls;

namespace jaaazzzzzzzzz;
public partial class AlarmPage : ContentPage

{
    private DateTime alarmTime;
        private bool alarmSet = false;
        private System.Timers.Timer timer;

        public AlarmPage()
        {
            InitializeComponent();

            // Запуск таймера для обновления часов
            timer = new System.Timers.Timer(1000); // 1 секунда
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true; 
            timer.Start();
        }


        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            // Используем MainThread для работы с UI
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ClockLabel.Text = DateTime.Now.ToString("HH:mm:ss");

                // Проверяем, сработал ли будильник
                if (alarmSet && DateTime.Now.Hour == alarmTime.Hour && DateTime.Now.Minute == alarmTime.Minute)
                {
                    alarmSet = false; // Сброс флага установки будильника
                    AlarmStat.Text = "Будильник сработал!";
                    DisplayAlert("Будильник", "Товарищ, пора!", "OK");
                }
            });
    }

    // Устанавливаем время будильника
    private void OnSetAlarmButtonClicked(object sender, EventArgs e)
        {
            // Установка времени будильника на основе выбранного времени
            alarmTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                AlarmTimePicker.Time.Hours, AlarmTimePicker.Time.Minutes, 0);
            alarmSet = true; // Установка флага, что будильник установлен
            AlarmStat.Text = $"Будильник установлен на {alarmTime:HH:mm}";
        }
    }

