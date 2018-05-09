using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite;
using System.Linq;
using quickmeal.Models;
using SQLiteNetExtensions.Extensions;
using System.Threading.Tasks;
namespace quickmeal
{
    public class PrzepisRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public PrzepisRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Przepis>();
            var table = dbConn.Table<Przepis>();

        }

        public Przepis AddPrzepis(string nazwa, string opis, int czas, string zdjecie)
        {
            Przepis prze = new Przepis(nazwa, opis, czas, zdjecie);
            dbConn.Insert(prze);
            return prze;
        }

        public List<Przepis> GetAllPrzepis()
        {
            var table = dbConn.GetAllWithChildren<Przepis>().ToList();
            return table;
        }

        public List<Przepis> GetSniadaniaPrzepis()
        {
            var table = dbConn.Table<Przepis>().Where(x => x.Id_Typu == 1).ToList();
            return table;
        }

        public void Update(Przepis przepis)
        {
            dbConn.UpdateWithChildren(przepis);
        }
    }
}
