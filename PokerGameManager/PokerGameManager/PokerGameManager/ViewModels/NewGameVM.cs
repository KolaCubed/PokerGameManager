using PokerGameManager.Models;
using Xamarin.Forms;

namespace PokerGameManager.ViewModels
{
    public class NewGameVM : BaseVM
    {
        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        
        public Command SaveGameCommand { get; }

        public NewGameVM()
        {
            Title = "Create New Game";

            SaveGameCommand = new Command(() =>
            {
                if (Game.InsertGame(new Game
                    {
                        Name = Name
                    }) > 0)
                {
                    Application.Current.MainPage.Navigation.PopAsync(true);
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Save Error", "Unable to save new game", "Ok");
                }
            });
        }
    }
}
