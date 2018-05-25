using System;
using System.Data;
using System.Collections.Generic;
using SQLite.Net.Interop;
using System.Data.SqlClient;
using SQLite;
using System.Text;
using System.Linq;
using quickmeal.Models;
using quickmeal.Constants;
using quickmeal.Repositories;
using SQLiteNetExtensions.Extensions;


namespace quickmeal
{
    public class Algorithm
    {
        private SQLite.SQLiteConnection dbConn;

        public Algorithm(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            dbConn = new SQLite.SQLiteConnection(dbPath);
                       
        }

        public DataTable SzukajPrzepis(Typ typ)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID_Przepisu", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_pokrywajacych_sie_ skladnikow", typeof(Int32)));


            var qTyp = (from p in dbConn.Table<Przepis>()
                        group p by p.Id into gp
                        join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Przepisu
                        join pr in dbConn.Table<Produkt>() on s.Id_Produktu equals pr.Id
                        join l in dbConn.Table<Lodowka>() on pr.Id equals l.Id_Produktu
                        join t in dbConn.Table<Typ>() on gp.Key equals t.Id
                        select new { Przepis_ = gp.Key, L_skladnikow_ = (from l in g select l.Id_Produktu).Distinct().Count() });
                        

            return dt;
        }
    }
}
