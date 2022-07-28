using PokerGameManager.Models;
using PokerGameManager.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PokerGameManager.ViewModels
{
    public class GamesVM : BaseVM
    {
        public ObservableCollection<Game> Games { get; set; }

        public Command NewGameCommand { get; }

        public GamesVM()
        {
            Title = "Games";

            NewGameCommand = new Command(async () =>
            {
                await Application.Current.MainPage.Navigation.PushAsync(new NewGamePage(), true);
            });

            Games = new ObservableCollection<Game>();

            GetGames();
        }

        public void GetGames()
        {
            Games.Clear();
            foreach (var game in Game.GetGames())
            {
                Games.Add(game);
            }
        }
    }
}
