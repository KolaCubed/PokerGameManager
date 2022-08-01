using PokerGameManager.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PokerGameManager.ViewModels
{
    public class BlindsVM
    {
        public ObservableCollection<Blinds> Blinds { get; set; }

        public BlindsVM()
        {
            Blinds = new ObservableCollection<Blinds>();

            AddCommand = new Command(() =>
            {
                this.Blinds.Add(new Blinds());
            });

            ResetCommand = new Command(async () =>
            {
                if (await Application.Current.MainPage.DisplayAlert(
                        "Reset",
                        "This will reset all the data for the app",
                        "Yes",
                        "No"))
                {
                    Data.Configure.Reset();
                }

            });

            GetBlinds();
        }

        public Command ResetCommand { get; }

        public Command AddCommand { get; }

        public void GetBlinds()
        {
            foreach (var item in Models.Blinds.Load())
            {
                Blinds.Add(item);
            }
        }
    }
}
