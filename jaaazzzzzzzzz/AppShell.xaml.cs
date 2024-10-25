namespace jaaazzzzzzzzz
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Регистрация маршрутов для страниц, если они могут быть вызваны программно
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(Timer), typeof(Timer));
        }
    }
}
