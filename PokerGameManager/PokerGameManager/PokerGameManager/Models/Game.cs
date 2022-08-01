using SQLite;
using System;
using System.Collections.Generic;

namespace PokerGameManager.Models
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public TimeSpan PlayedTime { get; set; }

        public TimeSpan BlindsDuration { get; set; }

        public TimeSpan Remaining { get; set; }

        public int CurrentLevel { get; set; }



        public static int InsertGame(Game game)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Game>();
                return conn.Insert(game);
            }
        }

        public static int UpdateGame(Game game)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Game>();
                return conn.Update(game);
            }
        }

        public static IEnumerable<Game> GetGames()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Game>();
                return conn.Table<Game>().ToList();
            }
        }

        public static void RemoveGame(Game game)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Game>();
                conn.Delete<Game>(game.Id);
            }
        }
    }
}
