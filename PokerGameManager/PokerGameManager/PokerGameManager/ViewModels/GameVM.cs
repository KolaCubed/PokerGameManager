using PokerGameManager.Models;
using System;
using System.Timers;
using Xamarin.Forms;

namespace PokerGameManager.ViewModels
{
    public class GameVM : BaseVM
    {
        private string _action = "Start";
        private Game _game;
        private TimeSpan _playedTime;
        private readonly Timer _timer = new Timer(1000);
        
        public GameVM()
        {
            RemoveGameCommand = new Command(async () =>
            {
                if (!await Application.Current.MainPage.DisplayAlert(
                        "Delete Game",
                        $"Are you sure you want to remove the game '{Game.Name}'?", 
                        "Yes", 
                        "No"))
                {
                    return;
                }

                Game.RemoveGame(Game);
                await Application.Current.MainPage.Navigation.PopAsync(true);
            });

            ActionCommand = new Command(() =>
            {
                switch (Action)
                {
                    case "Start":
                        Action = "Pause";
                        _timer.Start();
                        break;
                    case "Pause":
                        Action = "Start";
                        _timer.Stop();
                        break;
                }

                Game.UpdateGame(Game);
            });

            _timer.Elapsed += (sender, args) =>
            {
                PlayedTime += TimeSpan.FromSeconds(1);
                Game.PlayedTime = PlayedTime;
            };
        }

        public Command RemoveGameCommand { get; }
        public Command ActionCommand { get; }

        public string Action
        {
            get => _action;
            set
            {
                _action = value;
                OnPropertyChanged();
            }
        }

        public Game Game
        {
            get => _game;
            set
            {
                _game = value;

                if (_game != null)
                {
                    PlayedTime = Game.PlayedTime;
                }

                OnPropertyChanged();
            }
        }

        public TimeSpan PlayedTime
        {
            get => _playedTime;
            set
            {
                _playedTime = value;
                OnPropertyChanged();
            }
        }
    }
}
