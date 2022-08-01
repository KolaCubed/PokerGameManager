using PokerGameManager.Views;
using Xamarin.Forms;

namespace PokerGameManager
{
    public partial class App : Application
    {
        public static string DatabasePath;

        public App()
        {
            InitializeComponent();

            MainPage = OpeningPage();
        }

        public App(string databasePath)
        {
            InitializeComponent();

            DatabasePath = databasePath;

            MainPage = OpeningPage();
        }

        public NavigationPage OpeningPage()
        {
            Data.Configure.Default();
            return new NavigationPage(new GamesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
