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
    public class KategoriaRepository
    {
        private SQLite.SQLiteConnection dbConn;

        public string StatusMessage { get; set; }

        public KategoriaRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
            dbConn.CreateTable<Kategoria>();
            var table = dbConn.Table<Kategoria>();

        }

        public Kategoria AddKategoria(string nazwa)
        {
            Kategoria kat = new Kategoria(nazwa);
            dbConn.Insert(kat);
            return kat;
        }

        public List<Kategoria> GetAllKategoria()
        {            
            var table = dbConn.Table<Kategoria>().ToList();
            return table;
        }

        public void Update(Kategoria kategoria)
        {
            dbConn.UpdateWithChildren(kategoria);
        }
    }
}
