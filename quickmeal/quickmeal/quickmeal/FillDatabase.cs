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
            Produkt ziemniaki = App.ProduktRepo.AddProdukt("Ziemniaki");
            Produkt maka_pszenna = App.ProduktRepo.AddProdukt("Mąka pszenna");
            Produkt maka_ziemniaczana = App.ProduktRepo.AddProdukt("Mąka ziemniaczana");
            Produkt jajka = App.ProduktRepo.AddProdukt("Jajka");
            Produkt sol = App.ProduktRepo.AddProdukt("Sól");
            Produkt banan = App.ProduktRepo.AddProdukt("Banan");
            Produkt truskawka = App.ProduktRepo.AddProdukt("Truskawka");
            Produkt platki_czekoladowe = App.ProduktRepo.AddProdukt("Płatki czekoladowe");
            Produkt mleko = App.ProduktRepo.AddProdukt("Mleko");
            Produkt ananas = App.ProduktRepo.AddProdukt("Ananas");
            Produkt cukier = App.ProduktRepo.AddProdukt("Cukier");
            Produkt cebula = App.ProduktRepo.AddProdukt("Cebula");
            Produkt kurczak_filet = App.ProduktRepo.AddProdukt("Kurczak-filet");
            Produkt brokul = App.ProduktRepo.AddProdukt("Brokuł");
            Produkt smietanka_kremowka = App.ProduktRepo.AddProdukt("Śmietanka kremówka");
            Produkt makaron = App.ProduktRepo.AddProdukt("Makaron");
            Produkt olej = App.ProduktRepo.AddProdukt("Olej");

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
            warzywa.Produkty = new List<Produkt> { ziemniaki, brokul, cebula };
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

            Tluszcze.Produkty = new List<Produkt> { olej };
            App.KategoriaRepo.Update(Tluszcze);

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

            Skladnik skladnikiKopytek1 = App.SkladnikRepo.AddSkladnik(500, "g");
            kopytka.Zawiera.Add(skladnikiKopytek1);
            App.PrzepisRepo.Update(kopytka);
            ziemniaki.Skladniki.Add(skladnikiKopytek1);
            App.ProduktRepo.Update(ziemniaki);

            Skladnik skladnikiKopytek2 = App.SkladnikRepo.AddSkladnik(100, "g");
            kopytka.Zawiera.Add(skladnikiKopytek2);
            App.PrzepisRepo.Update(kopytka);
            maka_pszenna.Skladniki.Add(skladnikiKopytek2);
            App.ProduktRepo.Update(maka_pszenna);

            Skladnik skladnikiKopytek3 = App.SkladnikRepo.AddSkladnik(1, "sztuk");
            kopytka.Zawiera.Add(skladnikiKopytek3);
            App.PrzepisRepo.Update(kopytka);
            jajka.Skladniki.Add(skladnikiKopytek3);
            App.ProduktRepo.Update(jajka);

            Skladnik skladnikiKopytek4 = App.SkladnikRepo.AddSkladnik(10, "g");
            kopytka.Zawiera.Add(skladnikiKopytek4);
            App.PrzepisRepo.Update(kopytka);
            sol.Skladniki.Add(skladnikiKopytek4);
            App.ProduktRepo.Update(sol);

            Przepis platkiCzekoladowe = App.PrzepisRepo.AddPrzepis(
                "Płatki z mlekiem", 
                "1. Nasyp płatki do miski.\n\n2. Zalej płatki ciepłym lub zimnym mlekiem.\n\n3. Gotowe!",
                2,
                "http://www.prowadzedom.pl/wp-content/uploads/2014/10/kulki-czekoladowe.gif");

            Skladnik skladnikiPlatekCzekoladowych1 = App.SkladnikRepo.AddSkladnik(250, "g");
            platkiCzekoladowe.Zawiera.Add(skladnikiPlatekCzekoladowych1);
            App.PrzepisRepo.Update(platkiCzekoladowe);
            platki_czekoladowe.Skladniki.Add(skladnikiPlatekCzekoladowych1);
            App.ProduktRepo.Update(platki_czekoladowe);

            Skladnik skladnikiPlatekCzekoladowych2 = App.SkladnikRepo.AddSkladnik(250, "ml");
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

            Skladnik s = App.SkladnikRepo.AddSkladnik(1, "sztuk");
            mzkwss.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkwss);
            cebula.Skladniki.Add(s);
            App.ProduktRepo.Update(cebula);

            s = App.SkladnikRepo.AddSkladnik(2, "sztuk");
            mzkwss.Zawiera.Add(s);
            App.PrzepisRepo.Update(mzkwss);
            kurczak_filet.Skladniki.Add(s);
            App.ProduktRepo.Update(kurczak_filet);

            Skladnik s2 = App.SkladnikRepo.AddSkladnik(1, "sztuk");
            mzkwss.Zawiera.Add(s2 );
            App.PrzepisRepo.Update(mzkwss);
            brokul.Skladniki.Add(s2);
            App.ProduktRepo.Update(brokul);

            Skladnik s3 = App.SkladnikRepo.AddSkladnik(150, "g");
            mzkwss.Zawiera.Add(s3);
            App.PrzepisRepo.Update(mzkwss);
            smietanka_kremowka.Skladniki.Add(s3);
            App.ProduktRepo.Update(smietanka_kremowka);

            Skladnik s4 = App.SkladnikRepo.AddSkladnik(250, "g");
            mzkwss.Zawiera.Add(s4);
            App.PrzepisRepo.Update(mzkwss);
            makaron.Skladniki.Add(s4);
            App.ProduktRepo.Update(makaron);

            Skladnik s5 = App.SkladnikRepo.AddSkladnik(2, "łyżki");
            mzkwss.Zawiera.Add(s5);
            App.PrzepisRepo.Update(mzkwss);
            olej.Skladniki.Add(s5);
            App.ProduktRepo.Update(olej);

            /* Przypisanie przepisow do typów */
            obiad.Przepisy = new List<Przepis> { kopytka, mzkwss };
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
