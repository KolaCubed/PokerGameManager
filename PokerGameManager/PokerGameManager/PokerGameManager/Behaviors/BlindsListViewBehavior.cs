using PokerGameManager.Models;
using PokerGameManager.Views;
using Xamarin.Forms;

namespace PokerGameManager.Behaviors
{
    public class BlindsListViewBehavior : Behavior<ListView>
    {
        private ListView _listView;

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);

            _listView = bindable;
            _listView.ItemSelected += ListViewOnItemSelected;
        }

        private void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Blinds blinds = _listView.SelectedItem as Blinds;
            Application.Current.MainPage.Navigation.PushAsync(new BlindPage(blinds.Id) { Title = blinds.Name});
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            _listView.ItemSelected -= ListViewOnItemSelected;
        }
    }
}
