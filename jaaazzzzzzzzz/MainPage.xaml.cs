using Microsoft.Maui.Controls.Shapes;

namespace jaaazzzzzzzzz
{
    public partial class MainPage : ContentPage
    {
        [Obsolete]
        public MainPage()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), UpdateTime);
        }

        private int previousHours = -1;
        private int previousMinutes = -1;
        private int previousSeconds = -1;

        // Функция для обновления времени
        private bool UpdateTime()
        {
            TimeZoneInfo ekbPlus2TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            DateTime ekbPlus2Time = TimeZoneInfo.ConvertTime(DateTime.Now, ekbPlus2TimeZone).AddHours(2);

            int hours = ekbPlus2Time.Hour;
            int minutes = ekbPlus2Time.Minute;
            int seconds = ekbPlus2Time.Second;

            // Проверяем изменения
            if (hours != previousHours || minutes != previousMinutes /*|| seconds != previousSeconds*/)
            {
                // Обновление сегментов
                UpdateDigitSegments(hours / 10, TopSegment1, TopLeftSegment1, TopRightSegment1, MiddleSegment1, BottomLeftSegment1, BottomRightSegment1, BottomSegment1);
                UpdateDigitSegments(hours % 10, TopSegment2, TopLeftSegment2, TopRightSegment2, MiddleSegment2, BottomLeftSegment2, BottomRightSegment2, BottomSegment2);
                UpdateDigitSegments(minutes / 10, TopSegment3, TopLeftSegment3, TopRightSegment3, MiddleSegment3, BottomLeftSegment3, BottomRightSegment3, BottomSegment3);
                UpdateDigitSegments(minutes % 10, TopSegment4, TopLeftSegment4, TopRightSegment4, MiddleSegment4, BottomLeftSegment4, BottomRightSegment4, BottomSegment4);
                //UpdateDigitSegments(seconds / 10, TopSegment5, TopLeftSegment5, TopRightSegment5, MiddleSegment5, BottomLeftSegment5, BottomRightSegment5, BottomSegment5);
                //UpdateDigitSegments(seconds % 10, TopSegment6, TopLeftSegment6, TopRightSegment6, MiddleSegment6, BottomLeftSegment6, BottomRightSegment6, BottomSegment6);

                // Сохраняем текущее время как предыдущее
                previousHours = hours;
                previousMinutes = minutes;
                //previousSeconds = seconds;
            }

            UpdateDigitSegments(seconds / 10, TopSegment5, TopLeftSegment5, TopRightSegment5, MiddleSegment5, BottomLeftSegment5, BottomRightSegment5, BottomSegment5);
            UpdateDigitSegments(seconds % 10, TopSegment6, TopLeftSegment6, TopRightSegment6, MiddleSegment6, BottomLeftSegment6, BottomRightSegment6, BottomSegment6);
            previousSeconds = seconds;

            return true;
        }


        ///////
        private async void OnTimerPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimerPage());
        }


        //////




        private void UpdateDigitSegments(int digit, Image top, Image topLeft, Image topRight, Image middle, Image bottomLeft, Image bottomRight, Image bottom)
        {
            top.Source = ImageSource.FromFile("top.png");      //Все фотки в \jaaazzzzzzzzz\Resources\Images
            middle.Source = ImageSource.FromFile("top.png");
            bottom.Source = ImageSource.FromFile("top.png");
            topLeft.Source = ImageSource.FromFile("vert.png");
            topRight.Source = ImageSource.FromFile("vert.png");
            bottomLeft.Source = ImageSource.FromFile("vert.png");
            bottomRight.Source = ImageSource.FromFile("vert.png");

            // Устанавливаем прозрачность в зависимости от цифры
            top.Opacity = (digit == 0 || digit == 2 || digit == 3 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9) ? 1.0 : 0.1;
            topLeft.Opacity = (digit == 0 || digit == 4 || digit == 5 || digit == 6 || digit == 8 || digit == 9) ? 1.0 : 0.1;
            topRight.Opacity = (digit == 0 || digit == 1 || digit == 2 || digit == 3 || digit == 4 || digit == 8 || digit == 9) ? 1.0 : 0.1;
            middle.Opacity = (digit == 2 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 8 || digit == 9) ? 1.0 : 0.1;
            bottomLeft.Opacity = (digit == 0 || digit == 2 || digit == 6 || digit == 8) ? 1.0 : 0.1;
            bottomRight.Opacity = (digit == 0 || digit == 1 || digit == 3 || digit == 4 || digit == 5 || digit == 6 || digit == 7 || digit == 8 || digit == 9) ? 1.0 : 0.1;
            bottom.Opacity = (digit == 0 || digit == 2 || digit == 3 || digit == 5 || digit == 6 || digit == 8 || digit == 9) ? 1.0 : 0.1;

            switch (digit)
            {
                case 0:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = true;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = false;
                    //bottomLeft.IsVisible = true;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topLeft.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    bottomLeft.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                case 1:
                    //top.IsVisible = false;
                    //topLeft.IsVisible = false;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = false;
                    //bottomLeft.IsVisible = false;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = false;
                    //break;

                    topRight.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    break;

                case 2:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = false;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = true;
                    //bottomRight.IsVisible = false;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomLeft.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                case 3:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = false;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = false;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                case 4:
                    //top.IsVisible = false;
                    //topLeft.IsVisible = true;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = false;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = false;
                    //break;

                    topLeft.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    break;

                case 5:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = true;
                    //topRight.IsVisible = false;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = false;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topLeft.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                case 6:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = true;
                    //topRight.IsVisible = false;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = true;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topLeft.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomLeft.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                case 7:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = false;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = false;
                    //bottomLeft.IsVisible = false;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = false;
                    //break;

                    top.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    break;

                case 8:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = true;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = true;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topLeft.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomLeft.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                case 9:
                    //top.IsVisible = true;
                    //topLeft.IsVisible = true;
                    //topRight.IsVisible = true;
                    //middle.IsVisible = true;
                    //bottomLeft.IsVisible = false;
                    //bottomRight.IsVisible = true;
                    //bottom.IsVisible = true;
                    //break;

                    top.Opacity = 1.0;
                    topLeft.Opacity = 1.0;
                    topRight.Opacity = 1.0;
                    middle.Opacity = 1.0;
                    bottomRight.Opacity = 1.0;
                    bottom.Opacity = 1.0;
                    break;

                default:
                    // Если цифра не распознана, скрываем все сегменты
                    top.IsVisible = false;
                    topLeft.IsVisible = false;
                    topRight.IsVisible = false;
                    middle.IsVisible = false;
                    bottomLeft.IsVisible = false;
                    bottomRight.IsVisible = false;
                    bottom.IsVisible = false;
                    break;
            }
        }
    }
}