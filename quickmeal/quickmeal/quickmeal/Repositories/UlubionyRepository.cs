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
    public class UlubionyRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public UlubionyRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Ulubiony>();
            var table = dbConn.Table<Ulubiony>();

        }

        public Ulubiony AddUlubiony()
        {
            Ulubiony ulubiony = new Ulubiony();
            dbConn.Insert(ulubiony);
            return ulubiony;
        }

        public List<Ulubiony> GetAllUlubione()
        {
            var table = dbConn.GetAllWithChildren<Ulubiony>().ToList();
            return table;
        }

        public void Remove(Ulubiony ulubiony)
        {
            dbConn.Delete(ulubiony);
        }

        public void Update(Ulubiony ulubiony)
        {
            dbConn.UpdateWithChildren(ulubiony);
        }

    }
}
