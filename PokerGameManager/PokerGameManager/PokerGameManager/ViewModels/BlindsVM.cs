using PokerGameManager.Models;
using System.Collections.ObjectModel;

namespace PokerGameManager.ViewModels
{
    public class BlindsVM
    {
        public ObservableCollection<Blinds> Blinds { get; set; }

        public BlindsVM()
        {
            Blinds = new ObservableCollection<Blinds>();

            GetBlinds();
        }

        public void GetBlinds()
        {
            foreach (var item in Models.Blinds.GetBlinds())
            {
                Blinds.Add(item);
            }
        }
    }
}
