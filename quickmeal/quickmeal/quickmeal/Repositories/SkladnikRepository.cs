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
    public class SkladnikRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public SkladnikRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Skladnik>();
            var table = dbConn.Table<Skladnik>();

        }

        public Skladnik AddSkladnik(string gramatura)
        {
            Skladnik skl = new Skladnik(gramatura);
            dbConn.Insert(skl);
            return skl;
        }

        public Skladnik AddSkladnik(int ilosc)
        {
            Skladnik skl = new Skladnik(ilosc);
            dbConn.Insert(skl);
            return skl;
        }

        public Skladnik AddSkladnik(int ilosc, string gramatura)
        {
            Skladnik sk1 = new Skladnik
            {
                Ilosc = ilosc,
                Gramatura = gramatura
            };
            dbConn.Insert(sk1);
            return sk1;
        }

        public List<Skladnik> GetAllSkladnik()
        {
            var table = dbConn.GetAllWithChildren<Skladnik>().ToList();
            return table;
        }
        public void Update(Skladnik skladnik)
        {
            dbConn.UpdateWithChildren(skladnik);
        }
    }
}
