using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.Models
{
    public class Przepis_alg : Przepis
    {
        public int Liczba_wsz_skladnikow { get; set; }
        public int Liczba_pas_skladnikow { get; set; }
        public int Stosunek { get; set; }

        public Przepis_alg(Przepis prze, int Liczba_wszystkich, int Liczba_pasujacych, int Stosu) {
            this.Nazwa = prze.Nazwa;
            this.Opis = prze.Opis;
            this.Czas = prze.Czas;
            this.Id = prze.Id;
            this.Id_Typu = prze.Id_Typu;
            this.ulubiony = prze.ulubiony;
            this.Zawiera = prze.Zawiera;
            this.Zdjecie = prze.Zdjecie;

            Liczba_pas_skladnikow = Liczba_pasujacych;
            Liczba_wsz_skladnikow = Liczba_wszystkich;
            Stosunek = Stosu * (-1);
        }
    }
}
