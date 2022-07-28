using PokerGameManager.Models;
using PokerGameManager.Views;
using Xamarin.Forms;

namespace PokerGameManager.Behaviors
{
    public class GameListViewBehavior : Behavior<ListView>
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
            Game game = _listView.SelectedItem as Game;
            Application.Current.MainPage.Navigation.PushAsync(new GamePage(game));
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            _listView.ItemSelected -= ListViewOnItemSelected;
        }
    }
}
