using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;
using SQLite.Net.Interop;
using SQLite;
using System.Linq;
using quickmeal.Models;
using System.Threading.Tasks;
using SQLiteNetExtensions.Extensions;
namespace quickmeal.Repositories
{
    public class LodowkaRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public LodowkaRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Lodowka>();
            var table = dbConn.Table<Lodowka>();
        }

        public Lodowka AddLodowka(int ilosc)
        {
            Lodowka lod = new Lodowka(ilosc);
            dbConn.Insert(lod);
            return lod;
        }

        public List<Lodowka> GetAllProdukt()
        {
            var table = dbConn.GetAllWithChildren<Lodowka>().ToList();
            return table;
        }
        public void Remove(Lodowka lodowka)
        {
            dbConn.Delete(lodowka);
        }
        public void Update(Lodowka lodowka)
        {
            dbConn.UpdateWithChildren(lodowka);
        }

    }
}
