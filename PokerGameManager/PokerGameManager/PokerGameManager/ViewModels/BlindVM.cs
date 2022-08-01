using PokerGameManager.Models;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PokerGameManager.ViewModels
{
    public class BlindVM : BaseVM
    {
        private int _blindsId;

        public ObservableCollection<Blind> Items { get; set; }

        public BlindVM()
        {
            Items = new ObservableCollection<Blind>();

            SaveCommand = new Command(async () =>
            {
                foreach (var item in Items)
                {
                    Blind.Save(item);
                }

                await Application.Current.MainPage.Navigation.PopAsync(true);
            });

            AddCommand = new Command(() =>
            {
                var level = 1;

                if (Items.Any())
                {
                    level = Items.OrderByDescending(o => o.Level).First().Level + 1;
                }

                Items.Add(new Blind
                {
                    Level = level,
                    BlindsId = _blindsId
                });
            });
        }

        public Command SaveCommand { get; }
        public Command AddCommand { get; }

        public void Load(int blindsId)
        {
            _blindsId = blindsId;
            Items.Clear();
            foreach (var item in Blind.Load(blindsId))
            {
                Items.Add(item);
            }
        }
    }
}
