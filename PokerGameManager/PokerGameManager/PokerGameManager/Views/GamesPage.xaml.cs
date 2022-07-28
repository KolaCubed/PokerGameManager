using PokerGameManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokerGameManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamesPage : ContentPage
    {
        private readonly GamesVM vm;

        public GamesPage()
        {
            InitializeComponent();
            vm = Resources["vm"] as GamesVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetGames();
        }
    }
}