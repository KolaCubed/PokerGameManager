using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace PokerGameManager.Models
{
    public class Blinds
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public static int Save(Blinds blinds)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Blinds>();
                return conn.InsertOrReplace(blinds);
            }
        }

        public static IEnumerable<Blinds> Load()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Blinds>();
                return conn.Table<Blinds>().ToList();
            }
        }

        public static IEnumerable<Blinds> Load(int id)
        {
            return Load().Where(o => o.Id == id);
        }
    }
}
