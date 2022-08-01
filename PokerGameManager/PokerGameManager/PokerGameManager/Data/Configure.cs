using System;
using PokerGameManager.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameManager.Data
{
    public static class Configure
    {
        private static readonly IEnumerable<Blinds> DefaultBlinds = new List<Blinds>
        {
            new Blinds
            {
                Id = 1,
                Name = "Micro Blinds 1 / 2"
            },
            new Blinds
            {
                Id = 2,
                Name = "Medium Blinds 25 / 50"
            },
            new Blinds
            {
                Id = 5,
                Name = "High Roller Blinds 250 / 500"
            }
        };
        private static readonly IEnumerable<Blind> DefaultBlind = new List<Blind>
        {
            new Blind { Id = 1, BlindsId = 1, Level = 1, Small = 1, Big = 2 },
            new Blind { Id = 2, BlindsId = 1, Level = 2, Small = 2, Big = 4 },
            new Blind { Id = 3, BlindsId = 1, Level = 3, Small = 4, Big = 8 },
            new Blind { Id = 4, BlindsId = 1, Level = 4, Small = 5, Big = 10 },
            new Blind { Id = 5, BlindsId = 1, Level = 5, Small = 10, Big = 20 },
            new Blind { Id = 6, BlindsId = 1, Level = 6, Small = 20, Big = 40 },
            new Blind { Id = 7, BlindsId = 1, Level = 7, Small = 50, Big = 100 },
            new Blind { Id = 8, BlindsId = 1, Level = 8, Small = 100, Big = 200 },
            new Blind { Id = 9, BlindsId = 1, Level = 9, Small = 200, Big = 400 },
            new Blind { Id = 10, BlindsId = 1, Level = 10, Small = 400, Big = 800 },
            new Blind { Id = 11, BlindsId = 1, Level = 11, Small = 500, Big = 1000 },
            new Blind { Id = 12, BlindsId = 1, Level = 12, Small = 1000, Big = 2000 },
            new Blind { Id = 13, BlindsId = 1, Level = 13, Small = 2000, Big = 4000 },
            new Blind { Id = 14, BlindsId = 1, Level = 14, Small = 4000, Big = 8000 },
            new Blind { Id = 15, BlindsId = 1, Level = 15, Small = 5000, Big = 10000 },
            new Blind { Id = 16, BlindsId = 1, Level = 16, Small = 10000, Big = 20000 },
            new Blind { Id = 17, BlindsId = 1, Level = 17, Small = 20000, Big = 40000 },
            new Blind { Id = 18, BlindsId = 1, Level = 18, Small = 40000, Big = 80000 },
            new Blind { Id = 19, BlindsId = 1, Level = 19, Small = 80000, Big = 160000 },
            new Blind { Id = 20, BlindsId = 1, Level = 20, Small = 160000, Big = 320000 },
            new Blind { Id = 21, BlindsId = 1, Level = 21, Small = 320000, Big = 640000 },
            new Blind { Id = 22, BlindsId = 1, Level = 22, Small = 640000, Big = 1280000 },

            new Blind { Id = 23, BlindsId = 2, Level = 1, Small = 25, Big = 50 },
            new Blind { Id = 24, BlindsId = 2, Level = 2, Small = 50, Big = 100 },
            new Blind { Id = 25, BlindsId = 2, Level = 3, Small = 100, Big = 200 },
            new Blind { Id = 26, BlindsId = 2, Level = 4, Small = 150, Big = 300 },
            new Blind { Id = 27, BlindsId = 2, Level = 5, Small = 250, Big = 500 },
            new Blind { Id = 28, BlindsId = 2, Level = 6, Small = 400, Big = 800 },
            new Blind { Id = 29, BlindsId = 2, Level = 7, Small = 600, Big = 1200 },
            new Blind { Id = 30, BlindsId = 2, Level = 8, Small = 800, Big = 1600 },
            new Blind { Id = 31, BlindsId = 2, Level = 9, Small = 1000, Big = 2000 },
            new Blind { Id = 32, BlindsId = 2, Level = 10, Small = 1500, Big = 3000 },
            new Blind { Id = 33, BlindsId = 2, Level = 11, Small = 2000, Big = 4000 },
            new Blind { Id = 34, BlindsId = 2, Level = 12, Small = 3000, Big = 6000 },
            new Blind { Id = 35, BlindsId = 2, Level = 13, Small = 4000, Big = 8000 },
            new Blind { Id = 36, BlindsId = 2, Level = 14, Small = 5000, Big = 10000 },
            new Blind { Id = 37, BlindsId = 2, Level = 15, Small = 7500, Big = 15000 },
            new Blind { Id = 38, BlindsId = 2, Level = 16, Small = 10000, Big = 20000 },
            new Blind { Id = 39, BlindsId = 2, Level = 17, Small = 15000, Big = 30000 },
            new Blind { Id = 40, BlindsId = 2, Level = 18, Small = 20000, Big = 40000 },
            new Blind { Id = 41, BlindsId = 2, Level = 19, Small = 25000, Big = 50000 },
            new Blind { Id = 42, BlindsId = 2, Level = 20, Small = 30000, Big = 60000 },

            new Blind { Id = 43, BlindsId = 3, Level = 1, Small = 250, Big = 500},
            new Blind { Id = 44, BlindsId = 3, Level = 2, Small = 500, Big = 1000}
        };

        private static readonly IEnumerable<Game> DefaultGames = new List<Game>
        {
            new Game
            {
                Id = 1,
                BlindsDuration = TimeSpan.FromMinutes(15),
                PlayedTime = new TimeSpan(),
                Name = "First game",
                CurrentLevel = 0
            }
        };

        public static void Default()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Game>();
                conn.CreateTable<Blind>();
                conn.CreateTable<Blinds>();

                var blinds = conn.Table<Blinds>().ToList();
                if (!blinds.Any())
                {
                    foreach (var item in DefaultBlinds)
                    {
                        conn.InsertOrReplace(item);
                    }
                }

                var blind = conn.Table<Blind>().ToList();
                if (!blind.Any())
                {
                    foreach (var item in DefaultBlind)
                    {
                        conn.InsertOrReplace(item);
                    }
                }

                var game = conn.Table<Game>().ToList();
                if (!game.Any())
                {
                    foreach (var item in DefaultGames)
                    {
                        conn.InsertOrReplace(game);
                    }
                }
            }
        }

        public static void Reset()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.DeleteAll<Blind>();
                conn.DeleteAll<Blinds>();
                conn.DeleteAll<Game>();
            }

            Default();
        }
    }
}
