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
    class FillDatabase
    {


        public FillDatabase(ISQLitePlatform sqlitePlatform, string dbPath)
        {

        }

        public void fill()
        {
            /* Typ posilku */
            Typ sniadanie = App.TypRepo.AddTyp("Śniadanie");
            Typ obiad = App.TypRepo.AddTyp("Obiad");
            Typ kolacja = App.TypRepo.AddTyp("Deser");

            /* Produkty */
            Produkt ziemniaki = App.ProduktRepo.AddProdukt("Ziemniaki", "g");
            Produkt maka_pszenna = App.ProduktRepo.AddProdukt("Mąka pszenna", "g");
            Produkt maka_ziemniaczana = App.ProduktRepo.AddProdukt("Mąka ziemniaczana", "g");
            Produkt jajka = App.ProduktRepo.AddProdukt("Jajka", "sztuk");
            Produkt sol = App.ProduktRepo.AddProdukt("Sól", "g");
            Produkt banan = App.ProduktRepo.AddProdukt("Banan", "sztuk");
            Produkt truskawka = App.ProduktRepo.AddProdukt("Truskawka", "sztuk");
            Produkt platki_czekoladowe = App.ProduktRepo.AddProdukt("Płatki czekoladowe", "g");
            Produkt mleko = App.ProduktRepo.AddProdukt("Mleko", "ml");
            Produkt ananas = App.ProduktRepo.AddProdukt("Ananas", "sztuk");
            Produkt cukier = App.ProduktRepo.AddProdukt("Cukier", "g");
            Produkt cebula = App.ProduktRepo.AddProdukt("Cebula", "sztuk");
            Produkt kurczak_filet = App.ProduktRepo.AddProdukt("Kurczak-filet", "sztuk");
            Produkt brokul = App.ProduktRepo.AddProdukt("Brokuł", "sztuk");
            Produkt smietanka_kremowka = App.ProduktRepo.AddProdukt("Śmietanka kremówka", "g");
            Produkt makaron = App.ProduktRepo.AddProdukt("Makaron", "g");
            Produkt olej = App.ProduktRepo.AddProdukt("Olej", "lyzki");
            Produkt szparag = App.ProduktRepo.AddProdukt("Szparagi", "g");
            Produkt maslo = App.ProduktRepo.AddProdukt("Masło", "łyżki");
            Produkt szpinak = App.ProduktRepo.AddProdukt("Szpinak", "g");

            /* Kategorie */
            Kategoria warzywa = App.KategoriaRepo.AddKategoria("Warzywa");
            Kategoria owoce = App.KategoriaRepo.AddKategoria("Owoce");
            Kategoria pieczywo = App.KategoriaRepo.AddKategoria("Pieczywo");
            Kategoria nabial = App.KategoriaRepo.AddKategoria("Nabiał");
            Kategoria jajkak = App.KategoriaRepo.AddKategoria("Jajka");
            Kategoria mieso = App.KategoriaRepo.AddKategoria("Mieso");
            Kategoria ryby = App.KategoriaRepo.AddKategoria("Ryby");
            Kategoria wedliny = App.KategoriaRepo.AddKategoria("Wędliny");
            Kategoria slodycze_cukier = App.KategoriaRepo.AddKategoria("Słodycze i cukier");
            Kategoria Tluszcze = App.KategoriaRepo.AddKategoria("Tluszcze");
            Kategoria przyprawy = App.KategoriaRepo.AddKategoria("Przyprawy");
            Kategoria produkty_zbozowe = App.KategoriaRepo.AddKategoria("Produkty zbożowe i mączne");
            Kategoria dodatki = App.KategoriaRepo.AddKategoria("Dodatki");

            /* Przypisanie produktow do kategorii */
            warzywa.Produkty = new List<Produkt> { ziemniaki, brokul, cebula, szparag };
            App.KategoriaRepo.Update(warzywa);

            owoce.Produkty = new List<Produkt> { banan, truskawka, ananas };
            App.KategoriaRepo.Update(owoce);

            produkty_zbozowe.Produkty = new List<Produkt> { maka_pszenna, maka_ziemniaczana, platki_czekoladowe, makaron };
            App.KategoriaRepo.Update(produkty_zbozowe);

            jajkak.Produkty = new List<Produkt> { jajka };
            App.KategoriaRepo.Update(jajkak);

            przyprawy.Produkty = new List<Produkt> { sol, cukier };
            App.KategoriaRepo.Update(przyprawy);

            nabial.Produkty = new List<Produkt> { mleko, smietanka_kremowka };
            App.KategoriaRepo.Update(nabial);

            mieso.Produkty = new List<Produkt> { kurczak_filet };
            App.KategoriaRepo.Update(mieso);

            Tluszcze.Produkty = new List<Produkt> { olej, maslo };
            App.KategoriaRepo.Update(Tluszcze);

            /* Lodowka */
            Lodowka l_ziemniaki = App.LodowkaRepo.AddLodowka(5);
            l_ziemniaki.Id_Produktu = ziemniaki.Id;
            l_ziemniaki.Wypelnij_Dane();
            App.LodowkaRepo.Update(l_ziemniaki);

            Lodowka l_jajka = App.LodowkaRepo.AddLodowka(2);
            l_jajka.Id_Produktu = jajka.Id;
            l_jajka.Wypelnij_Dane();
            App.LodowkaRepo.Update(l_jajka);


            /* Przepisy */
            Przepis kopytka = App.PrzepisRepo.AddPrzepis(
                "Kopytka",
                "1. Ziemniaki umyć, obrać, wieksze przekroić, zalać wodą, posolić i zagotować. Gotować pod przykryciem przez ok. 30 minut lub do miękkości (wbity nóż ma gładko w nie wchodzić).\n\n"
                + "2. Odcedzić i od razu rozgnieść praską na idealnie gładkie puree. Całkowicie ostudzić.\n\n"
                + "3. Na stolnicę przesiać mąkę, dodać ziemniaki, zrobić w środku wgłębienie i wbić w nie jajko. Całość posolić i zagnieść gładkie ciasto, w razie potrzeby podsypać delikatnie mąką. Można użyć miksera planetarnego (łopatki). Im mniej dodamy mąki, tym kopytka będą delikatniejsze.\n\n"
                + "4. Zagotować duży garnek z osoloną wodą. Ciasto podzielić na 4 części, z każdej uformować wałeczek o grubości kciuka. Nożem odkrajać kawałki tzw. kopytka o szerokości ok. 1,5 - 2 cm.\n\n"
                + "5. Wrzucać na gotującą się wodę i gotować przez ok. 4 minuty licząc od czasu wypłynięcia na powierzchnię lub do miękkości. W trakcie gotowania delikatnie przemieszać wodę drewnianą łyżką sprawdzając czy kopytka nie przykleiły się do dna. Wyławiać łyżką cedzakową i wykładać na talerze.", 
                30,
                "https://static.gotujmy.pl/ZDJECIE_PRZEPISU_ETAP/kopytka-z-maka-kukurydziana-433153.jpg");

            Skladnik skladnikiKopytek1 = App.SkladnikRepo.AddSkladnik(500);
            kopytka.Zawiera.Add(skladnikiKopytek1);
            App.PrzepisRepo.Update(kopytka);
            ziemniaki.Skladniki.Add(skladnikiKopytek1);
            App.ProduktRepo.Update(ziemniaki);

            Skladnik skladnikiKopytek2 = App.SkladnikRepo.AddSkladnik(100);
            kopytka.Zawiera.Add(skladnikiKopytek2);
            App.PrzepisRepo.Update(kopytka);
            maka_pszenna.Skladniki.Add(skladnikiKopytek2);
            App.ProduktRepo.Update(maka_pszenna);

            Skladnik skladnikiKopytek3 = App.SkladnikRepo.AddSkladnik(1);
            kopytka.Zawiera.Add(skladnikiKopytek3);
            App.PrzepisRepo.Update(kopytka);
            jajka.Skladniki.Add(skladnikiKopytek3);
            App.ProduktRepo.Update(jajka);

            Skladnik skladnikiKopytek4 = App.SkladnikRepo.AddSkladnik(10);
            kopytka.Zawiera.Add(skladnikiKopytek4);
            App.PrzepisRepo.Update(kopytka);
            sol.Skladniki.Add(skladnikiKopytek4);
            App.ProduktRepo.Update(sol);

            Ulubiony ul_mzkwss = App.UlubionyRepo.AddUlubiony();
            ul_mzkwss.Id_Przepisu = kopytka.Id;
            App.UlubionyRepo.Update(ul_mzkwss);
            kopytka.ulubiony = ul_mzkwss;
            App.PrzepisRepo.Update(kopytka);

            Przepis platkiCzekoladowe = App.PrzepisRepo.AddPrzepis(
                "Płatki z mlekiem", 
                "1. Nasyp płatki do miski.\n\n2. Zalej płatki ciepłym lub zimnym mlekiem.\n\n3. Gotowe!",
                2,
                "http://www.prowadzedom.pl/wp-content/uploads/2014/10/kulki-czekoladowe.gif");

            Skladnik skladnikiPlatekCzekoladowych1 = App.SkladnikRepo.AddSkladnik(250);
            platkiCzekoladowe.Zawiera.Add(skladnikiPlatekCzekoladowych1);
            App.PrzepisRepo.Update(platkiCzekoladowe);
            platki_czekoladowe.Skladniki.Add(skladnikiPlatekCzekoladowych1);
            App.ProduktRepo.Update(platki_czekoladowe);

            Skladnik skladnikiPlatekCzekoladowych2 = App.SkladnikRepo.AddSkladnik(250);
            platkiCzekoladowe.Zawiera.Add(skladnikiPlatekCzekoladowych2);
            App.PrzepisRepo.Update(platkiCzekoladowe);
            mleko.Skladniki.Add(skladnikiPlatekCzekoladowych2);
            App.ProduktRepo.Update(mleko);

            Przepis mzkwss = App.PrzepisRepo.AddPrzepis(
                "Makaron z kurczakiem w sosie śmietanowym",
                "1. Cebulę obierz, posiekaj i zeszklij na patelni na rozgrzanym oleju.\n\n" +
                "2. Filety pokrój w plastry.\n\n" +
                "3. Brokuła podziel na różyczki, wrzuć do wrzątku i gotuj 3 minuty, odsącz.\n\n" +
                "4. Do cebuli dodaj mięso, oprósz przyprawą ZIARENKA SMAKU i pieprzem.\n\n" +
                "5. Smaż ok. 5 minut, dodaj 100 ml wody i śmietanę, dokładnie rozmieszaj.\n\n" +
                "6. Następnie do potrawy dodaj brokuły, duś razem kolejne 5 minut.\n\n" +
                "7. Makaron ugotuj w dużej ilości posolonej wody, odcedź i połącz z sosem mięsnym.\n\n" +
                "8. Podawaj zaraz po przygotowaniu.",
                50,
                "https://www.winiary.pl/image.ashx/zdjecie.jpg?fileID=75055&width=1400&height=1400&quality=84&bg=0&resize=0");

            Skladnik s = App.SkladnikRepo.AddSkladnik(1);
            mzkwss.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkwss);
            cebula.Skladniki.Add(s);
            App.ProduktRepo.Update(cebula);

            s = App.SkladnikRepo.AddSkladnik(2);
            mzkwss.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkwss);
            kurczak_filet.Skladniki.Add(s);
            App.ProduktRepo.Update(kurczak_filet);

            Skladnik s2 = App.SkladnikRepo.AddSkladnik(1);
            mzkwss.Zawiera.Add(s2 );
            App.PrzepisRepo.Update(mzkwss);
            brokul.Skladniki.Add(s2);
            App.ProduktRepo.Update(brokul);

            Skladnik s3 = App.SkladnikRepo.AddSkladnik(150);
            mzkwss.Zawiera.Add(s3);
            App.PrzepisRepo.Update(mzkwss);
            smietanka_kremowka.Skladniki.Add(s3);
            App.ProduktRepo.Update(smietanka_kremowka);

            Skladnik s4 = App.SkladnikRepo.AddSkladnik(250);
            mzkwss.Zawiera.Add(s4);
            App.PrzepisRepo.Update(mzkwss);
            makaron.Skladniki.Add(s4);
            App.ProduktRepo.Update(makaron);

            Skladnik s5 = App.SkladnikRepo.AddSkladnik(2);
            mzkwss.Zawiera.Add(s5);
            App.PrzepisRepo.Update(mzkwss);
            olej.Skladniki.Add(s5);
            App.ProduktRepo.Update(olej);

            ul_mzkwss = App.UlubionyRepo.AddUlubiony();
            ul_mzkwss.Id_Przepisu = mzkwss.Id;
            App.UlubionyRepo.Update(ul_mzkwss);
            mzkwss.ulubiony = ul_mzkwss;
            App.PrzepisRepo.Update(mzkwss);

            Przepis mzkis = App.PrzepisRepo.AddPrzepis(
                "Makaron z kurczakiem i szparagami",
                "1. Świeże szparagi oczyść i pokrój w 2 cm kawałki.\n\n" +
                "2. Filet pokrój w kostkę a szpinak drobno\n\n" +
                "3. Masło rozgrzej na patelni, smaż na nim przez 10 minut szparagi i mięso.\n\n" +
                "4. Opcjonalne przyprawy wymieszaj ze śmietanką i 200 ml wody - dodaj na patelnię i duś całość przez 5 minut. Dodaj szpinak.\n\n" +
                "5. Makaron ugotuj w dużej ilości posolonej wody.\n\n" +
                "6. Makaron połącz z zawartością patelni, podawaj zaraz po przygotowaniu.\n\n",
                55,
                "https://www.winiary.pl/image.ashx/zdjecie.jpg?fileID=210327&width=1400&height=1400&quality=84&bg=0&resize=0");

            s = App.SkladnikRepo.AddSkladnik(200);
            mzkis.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkis);
            smietanka_kremowka.Skladniki.Add(s);
            App.ProduktRepo.Update(smietanka_kremowka);

            s = App.SkladnikRepo.AddSkladnik(400);
            mzkis.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkis);
            szparag.Skladniki.Add(s);
            App.ProduktRepo.Update(szparag);

            s = App.SkladnikRepo.AddSkladnik(1);
            mzkis.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkis);
            kurczak_filet.Skladniki.Add(s);
            App.ProduktRepo.Update(kurczak_filet);

            s = App.SkladnikRepo.AddSkladnik(3);
            mzkis.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkis);
            maslo.Skladniki.Add(s);
            App.ProduktRepo.Update(maslo);

            s = App.SkladnikRepo.AddSkladnik(300);
            mzkis.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkis);
            makaron.Skladniki.Add(s);
            App.ProduktRepo.Update(makaron);

            s = App.SkladnikRepo.AddSkladnik(50);
            mzkis.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkis);
            szpinak.Skladniki.Add(s);
            App.ProduktRepo.Update(szpinak);

            Ulubiony ul = App.UlubionyRepo.AddUlubiony();
            ul.Id_Przepisu = mzkis.Id;
            App.UlubionyRepo.Update(ul);
            mzkis.ulubiony = ul;
            App.PrzepisRepo.Update(mzkis);

            /* Przypisanie przepisow do typów */
            obiad.Przepisy = new List<Przepis> { kopytka, mzkwss, mzkis };
            App.TypRepo.Update(obiad);

            sniadanie.Przepisy = new List<Przepis> { platkiCzekoladowe };
            App.TypRepo.Update(sniadanie);

            var przepisy = App.PrzepisRepo.GetAllPrzepis();
            var typy = App.TypRepo.GetAllTyp();
            var kategorie = App.KategoriaRepo.GetAllKategoria();
            var skladniki = App.SkladnikRepo.GetAllSkladnik();
            var produkty = App.ProduktRepo.GetAllProdukt();
        }
    }
}
