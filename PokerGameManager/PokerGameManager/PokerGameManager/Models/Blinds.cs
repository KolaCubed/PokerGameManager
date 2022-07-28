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

        IEnumerable<Blind> BlindItems {get;set;}

        public class Blind
        {
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }
            public int BlindsId { get; set; }
            public int Level { get; set; }
            public int Small { get; set; }
            public int Big { get; set; }
        }

        public static bool InsertBlinds(Blinds blinds)
        {
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
                {
                    conn.CreateTable<Blinds>();
                    conn.CreateTable<Blind>();

                    foreach (var item in conn.Table<Blinds>().ToList())
                    {
                        if (item.BlindItems.Any())
                        {
                            var id = conn.Insert(blinds);

                            foreach (var blind in item.BlindItems)
                            {
                                conn.Insert(blind);
                            }
                        }
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static IEnumerable<Blinds> GetBlinds()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Blinds>();
                conn.CreateTable<Blind>();

                var blinds = conn.Table<Blinds>().ToList();
                var blindItems = conn.Table<Blind>().ToList();

                foreach (var item in blinds)
                {
                    item.BlindItems = conn.Table<Blind>().Where(o => o.BlindsId == item.Id).ToList();
                    blinds.Add(item);
                }

                return blinds;
            }
        }
    }
}
