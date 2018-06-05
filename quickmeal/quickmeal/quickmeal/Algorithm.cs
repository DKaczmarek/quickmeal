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
        
        public List<Przepis_alg> SzukajPrzepis()
        {
            var qTyp = (from p in dbConn.Table<Przepis>()
                        group p by p.Id into gp
                        join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Przepisu
                        join pr in dbConn.Table<Produkt>() on s.Id_Produktu equals pr.Id
                        join l in dbConn.Table<Lodowka>() on pr.Id equals l.Id_Produktu
                        select gp.Key).Distinct().ToList();

            List<Przepis_alg> lista = new List<Przepis_alg>();
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

                List<Produkt> list_skla = new List<Produkt>();

                var lista_id_prod = (from pr in dbConn.Table<Produkt>()
                                     group pr by pr.Id into gp
                                     join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                                     join l in dbConn.Table<Lodowka>() on s.Id_Produktu equals l.Id_Produktu
                                     join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                                     where p.Id == q
                                     select gp.Key).Distinct().ToList();

                foreach (var a in lista_id_prod)
                {
                    Produkt p = (from pr in dbConn.Table<Produkt>()
                                 where a == pr.Id
                                 select pr).FirstOrDefault();
                    list_skla.Add(p);
                }

                Przepis przepis = App.PrzepisRepo.GetAllPrzepis().Where(x => x.Id == q).First();

                int stosunek = liczba - liczba_skla;

                Przepis_alg prze = new Przepis_alg(przepis, liczba_skla, liczba, stosunek, list_skla);
                lista.Add(prze);

            }
             lista.Sort(delegate (Przepis_alg x, Przepis_alg y)
             {
                 int a = y.Stosunek.CompareTo(x.Stosunek);
                 if (a == 0)
                     a = x.Id.CompareTo(y.Id);

                 return a;
             });

        
            return lista;
        }
        
        public List<Przepis_alg> SzukajPrzepis(Typ typ)
        {
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

                if (pom.Id_Typu == typ.Id) { qTyp2.Add(a); }

            }
            List<Przepis_alg> lista = new List<Przepis_alg>();
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

                List<Produkt> list_skla = new List<Produkt>();

                var lista_id_prod = (from pr in dbConn.Table<Produkt>()
                                     group pr by pr.Id into gp
                                     join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                                     join l in dbConn.Table<Lodowka>() on s.Id_Produktu equals l.Id_Produktu
                                     join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                                     where p.Id == q
                                     select gp.Key).Distinct().ToList();

                foreach (var a in lista_id_prod)
                {
                     Produkt p = (from pr in dbConn.Table<Produkt>()
                                  where a==pr.Id
                                  select pr).FirstOrDefault();
                    list_skla.Add(p);
                }
                Przepis przepis = App.PrzepisRepo.GetAllPrzepis().Where(x => x.Id == q).First();

                int stosunek = liczba - liczba_skla;

                Przepis_alg prze = new Przepis_alg(przepis, liczba_skla, liczba, stosunek, list_skla);
                lista.Add(prze);

            }
            lista.Sort(delegate (Przepis_alg x, Przepis_alg y)
            {
                int a = y.Stosunek.CompareTo(x.Stosunek);
                if (a == 0)
                    a = x.Id.CompareTo(y.Id);

                return a;
            });


            return lista;
        }

        public List<Przepis_alg> SzukajPrzepis(Typ typ, Typ typ2)
        {
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

                if (pom.Id_Typu == typ.Id || pom.Id_Typu==typ2.Id) { qTyp2.Add(a); }

            }
            List<Przepis_alg> lista = new List<Przepis_alg>();
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

                List<Produkt> list_skla = new List<Produkt>();

                var lista_id_prod = (from pr in dbConn.Table<Produkt>()
                                     group pr by pr.Id into gp
                                     join s in dbConn.Table<Skladnik>() on gp.Key equals s.Id_Produktu
                                     join l in dbConn.Table<Lodowka>() on s.Id_Produktu equals l.Id_Produktu
                                     join p in dbConn.Table<Przepis>() on s.Id_Przepisu equals p.Id
                                     where p.Id == q
                                     select gp.Key).Distinct().ToList();

                foreach (var a in lista_id_prod)
                {
                    Produkt p = (from pr in dbConn.Table<Produkt>()
                                 where a == pr.Id
                                 select pr).FirstOrDefault();
                    list_skla.Add(p);
                }

                Przepis przepis = App.PrzepisRepo.GetAllPrzepis().Where(x => x.Id == q).First();

                int stosunek = liczba - liczba_skla;

                Przepis_alg prze = new Przepis_alg(przepis, liczba_skla, liczba, stosunek, list_skla);
                lista.Add(prze);

            }
            lista.Sort(delegate (Przepis_alg x, Przepis_alg y)
            {
                int a = y.Stosunek.CompareTo(x.Stosunek);
                if (a == 0)
                    a = x.Id.CompareTo(y.Id);

                return a;
            });


            return lista;
        }

    }
}
