using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.Models
{
    public class Przepis_alg : Przepis
    {
        public int Liczba_wsz_skladnikow;
        public int Liczba_pas_skladnikow;
        public int Stosunek;
        public Przepis przepis;
        public Przepis_alg(Przepis prze, int Liczba_wszystkich, int Liczba_pasujacych, int Stosu) {
            przepis = prze;
            Liczba_pas_skladnikow = Liczba_pasujacych;
            Liczba_wsz_skladnikow = Liczba_wszystkich;
            Stosunek = Stosu;
        }
    }
}
