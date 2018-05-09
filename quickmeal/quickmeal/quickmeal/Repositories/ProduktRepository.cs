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
    public class ProduktRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public ProduktRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Produkt>();
            var table = dbConn.Table<Produkt>();

        }

        public Produkt AddProdukt(string nazwa)
        {
            Produkt pro = new Produkt(nazwa);
            dbConn.Insert(pro);
            return pro;
        }

        public List<Produkt> GetAllProdukt()
        {
            var table = dbConn.GetAllWithChildren<Produkt>().ToList();
            return table;
        }

        public void Update(Produkt produkt)
        {
            dbConn.UpdateWithChildren(produkt);
        }
    }
}
