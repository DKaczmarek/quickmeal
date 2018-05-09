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

namespace quickmeal
{
    public class TypRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public TypRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Typ>();
            var table = dbConn.Table<Typ>();

        }

        public Typ AddTyp(string nazwa)
        {
            Typ typ = new Typ(nazwa);
            dbConn.Insert(typ);
            return typ;
        }

        public List<Typ> GetAllTyp()
        {
            var table = dbConn.GetAllWithChildren<Typ>().ToList();
            return table;
        }

        public void Update(Typ typ)
        {
            dbConn.UpdateWithChildren(typ);
        }
    }
}
