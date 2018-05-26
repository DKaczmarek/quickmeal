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


        public Typ SzukajTypu(String naz)
        {
            Typ tp= (from t in dbConn.Table<Typ>() where t.Nazwa == naz select t).FirstOrDefault();
            return tp;
        }

        public DataTable SzukajPrzepis()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID_Przepisu", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_pokrywajacych_sie_ skladnikow", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_wszystkich_skladnikow", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Stosunek", typeof(Int32)));

            var qTyp = (from p in dbConn.Table<Przepis>()
                        group p by p.Id into gp
                        join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Przepisu
                        join pr in dbConn.Table<Produkt>() on s.Id_Produktu equals pr.Id
                        join l in dbConn.Table<Lodowka>() on pr.Id equals l.Id_Produktu
                        select gp.Key).Distinct().ToList();


            foreach (var q in qTyp)
            {

                int liczba = (from pr in dbConn.Table<Produkt>()
                              group pr by pr.Id into gp
                              join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                              join l in dbConn.Table<Lodowka>() on s.Id_Produktu equals l.Id_Produktu
                              join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                              where p.Id == q
                              select gp.Key).Distinct().Count();

                int liczba_skla = (from pr in dbConn.Table<Produkt>()
                                   group pr by pr.Id into gp
                                   join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                                   join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                                   where p.Id == q
                                   select gp.Key).Distinct().Count();

                int stosunek = liczba - liczba_skla;

                DataRow new_row = dt.NewRow();
                new_row["ID_Przepisu"] = q;
                new_row["Liczba_pokrywajacych_sie_ skladnikow"] = liczba;
                new_row["Liczba_wszystkich_skladnikow"] = liczba_skla;
                new_row["Stosunek"] = stosunek;
                dt.Rows.Add(new_row);

            }

            DataView dv = dt.DefaultView;
            dv.Sort = "Stosunek desc";
            DataTable dt2 = dv.ToTable();
            return dt2;
        }

        public DataTable SzukajPrzepis(Typ typ)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID_Przepisu", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_pokrywajacych_sie_ skladnikow", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_wszystkich_skladnikow", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Stosunek", typeof(Int32)));

            var qTyp = (from p in dbConn.Table<Przepis>()
                         group p by p.Id into gp
                         join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Przepisu
                         join pr in dbConn.Table<Produkt>() on s.Id_Produktu equals pr.Id
                         join l in dbConn.Table<Lodowka>() on pr.Id equals l.Id_Produktu
                         select gp.Key).Distinct().ToList();

            List<int> qTyp2 = new List<int>();
            foreach (var a in qTyp)
            {
                Przepis pom = (from p in dbConn.Table<Przepis>()
                           where p.Id==a
                           select p
                           ).FirstOrDefault();

                if (pom.Id_Typu == typ.Id) {qTyp2.Add(a); }

            }


                foreach (var q in qTyp2) {
                
                int liczba = (from pr in dbConn.Table<Produkt>()
                              group pr by pr.Id into gp
                              join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                              join l in dbConn.Table<Lodowka>() on s.Id_Produktu equals l.Id_Produktu
                              join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                              where p.Id==q
                              select gp.Key).Distinct().Count();

                int liczba_skla = (from pr in dbConn.Table<Produkt>()
                              group pr by pr.Id into gp
                              join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu     
                              join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                              where p.Id == q
                              select gp.Key).Distinct().Count();

                int stosunek = liczba-liczba_skla;

                DataRow new_row = dt.NewRow();
                new_row["ID_Przepisu"] = q;
                new_row["Liczba_pokrywajacych_sie_ skladnikow"] = liczba;
                new_row["Liczba_wszystkich_skladnikow"] = liczba_skla;
                new_row["Stosunek"] = stosunek;
                dt.Rows.Add(new_row);

            }

            DataView dv = dt.DefaultView;
            dv.Sort = "Stosunek desc";
            DataTable dt2 = dv.ToTable();
            return dt2;
        }

        public DataTable SzukajPrzepis(Typ typ, Typ typ2)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ID_Przepisu", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_pokrywajacych_sie_ skladnikow", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Liczba_wszystkich_skladnikow", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Stosunek", typeof(Int32)));

            var qTyp = (from p in dbConn.Table<Przepis>()
                        group p by p.Id into gp
                        join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Przepisu
                        join pr in dbConn.Table<Produkt>() on s.Id_Produktu equals pr.Id
                        join l in dbConn.Table<Lodowka>() on pr.Id equals l.Id_Produktu
                        select gp.Key).Distinct().ToList();

            List<int> qTyp2 = new List<int>();
            foreach (var a in qTyp)
            {
                Przepis pom = (from p in dbConn.Table<Przepis>()
                               where p.Id == a
                               select p
                           ).FirstOrDefault();

                if (pom.Id_Typu == typ.Id || pom.Id_Typu == typ2.Id) { qTyp2.Add(a); }

            }


            foreach (var q in qTyp2)
            {

                int liczba = (from pr in dbConn.Table<Produkt>()
                              group pr by pr.Id into gp
                              join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                              join l in dbConn.Table<Lodowka>() on s.Id_Produktu equals l.Id_Produktu
                              join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                              where p.Id == q
                              select gp.Key).Distinct().Count();

                int liczba_skla = (from pr in dbConn.Table<Produkt>()
                                   group pr by pr.Id into gp
                                   join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                                   join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                                   where p.Id == q
                                   select gp.Key).Distinct().Count();

                int stosunek = liczba - liczba_skla;

                DataRow new_row = dt.NewRow();
                new_row["ID_Przepisu"] = q;
                new_row["Liczba_pokrywajacych_sie_ skladnikow"] = liczba;
                new_row["Liczba_wszystkich_skladnikow"] = liczba_skla;
                new_row["Stosunek"] = stosunek;
                dt.Rows.Add(new_row);

            }



            DataView dv = dt.DefaultView;
            dv.Sort = "Stosunek desc";
            DataTable dt2 = dv.ToTable();
            return dt2;
        }


        
    }
}
