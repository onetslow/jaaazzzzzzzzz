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

            // ������ ������� ��� ���������� �����
            timer = new System.Timers.Timer(1000); // 1 �������
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = true; 
            timer.Start();
        }


        private void OnTimerElapsed(object? sender, ElapsedEventArgs e)
        {
            // ���������� MainThread ��� ������ � UI
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ClockLabel.Text = DateTime.Now.ToString("HH:mm:ss");

                // ���������, �������� �� ���������
                if (alarmSet && DateTime.Now.Hour == alarmTime.Hour && DateTime.Now.Minute == alarmTime.Minute)
                {
                    alarmSet = false; // ����� ����� ��������� ����������
                    AlarmStat.Text = "��������� ��������!";
                    DisplayAlert("���������", "�������, ����!", "OK");
                }
            });
    }

    // ������������� ����� ����������
    private void OnSetAlarmButtonClicked(object sender, EventArgs e)
        {
            // ��������� ������� ���������� �� ������ ���������� �������
            alarmTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                AlarmTimePicker.Time.Hours, AlarmTimePicker.Time.Minutes, 0);
            alarmSet = true; // ��������� �����, ��� ��������� ����������
            AlarmStat.Text = $"��������� ���������� �� {alarmTime:HH:mm}";
        }
    }

