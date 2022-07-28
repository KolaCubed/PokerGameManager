using PokerGameManager.Models;
using PokerGameManager.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokerGameManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private readonly GameVM vm = new GameVM();

        public GamePage()
        {
            InitializeComponent();
        }

        public GamePage(Game game)
        {
            InitializeComponent();
            vm = Resources["vm"] as GameVM;
            vm.Game = game;
        }
    }
}