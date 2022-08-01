using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameManager.Models
{
    public class Blind 
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BlindsId { get; set; }
        public int Level { get; set; }
        public int Small { get; set; }
        public int Big { get; set; }

        public static int Save(Blind blind)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Blind>();
                return conn.InsertOrReplace(blind);
            }
        }

        public static IEnumerable<int> SaveAll(IEnumerable<Blind> blinds)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Blind>();
                foreach (var item in blinds)
                {
                    item.Id = conn.InsertOrReplace(item);
                }
            }

            return blinds.Select(o => o.Id);
        }

        public static IEnumerable<Blind> Load()
        {
            using (var conn = new SQLiteConnection(App.DatabasePath))
            {
                return conn.Table<Blind>().ToList();
            }
        }

        public static IEnumerable<Blind> Load(int blindsId)
        {
            return Load().Where(o => o.BlindsId == blindsId);
        }
    }
}
