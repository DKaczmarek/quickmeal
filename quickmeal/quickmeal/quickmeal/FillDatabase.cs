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
            Typ sniadanie = App.TypRepo.AddTyp("Sniadanie");
            Typ obiad = App.TypRepo.AddTyp("Obiad");
            Typ kolacja = App.TypRepo.AddTyp("Kolacja");

            Produkt ziemniaki = App.ProduktRepo.AddProdukt("Ziemniaki");
            Produkt maka_pszenna = App.ProduktRepo.AddProdukt("Maka pszenna");
            Produkt maka_ziemniaczana = App.ProduktRepo.AddProdukt("Maka ziemniaczana");
            Produkt jajka = App.ProduktRepo.AddProdukt("Jajka");
            Produkt sol = App.ProduktRepo.AddProdukt("Sol");
            Produkt banan = App.ProduktRepo.AddProdukt("Banan");
            Produkt truskawka = App.ProduktRepo.AddProdukt("Truskawka");
            Produkt platki_czekoladowe = App.ProduktRepo.AddProdukt("Platki czekoladowe");
            Produkt mleko = App.ProduktRepo.AddProdukt("Mleko");
            Produkt ananas = App.ProduktRepo.AddProdukt("Ananas");
            Produkt cukier = App.ProduktRepo.AddProdukt("Cukier");

            Kategoria warzywa = App.KategoriaRepo.AddKategoria("Warzywa");
            Kategoria owoce = App.KategoriaRepo.AddKategoria("Owoce");
            Kategoria pieczywo = App.KategoriaRepo.AddKategoria("Pieczywo");
            Kategoria nabial = App.KategoriaRepo.AddKategoria("Nabial");
            Kategoria jajkak = App.KategoriaRepo.AddKategoria("Jajka");
            Kategoria mieso = App.KategoriaRepo.AddKategoria("Mieso");
            Kategoria ryby = App.KategoriaRepo.AddKategoria("Ryby");
            Kategoria wedliny = App.KategoriaRepo.AddKategoria("Wedliny");
            Kategoria slodycze_cukier = App.KategoriaRepo.AddKategoria("Slodycze i cukier");
            Kategoria Tluszcze = App.KategoriaRepo.AddKategoria("Tluszcze");
            Kategoria przyprawy = App.KategoriaRepo.AddKategoria("Przyprawy");
            Kategoria produkty_zbozowe = App.KategoriaRepo.AddKategoria("Produkty zbozowe");
            Kategoria dodatki = App.KategoriaRepo.AddKategoria("Dodatki");

            warzywa.Produkty = new List<Produkt> { ziemniaki };
            App.KategoriaRepo.Update(warzywa);

            owoce.Produkty = new List<Produkt> { banan, truskawka, ananas };
            App.KategoriaRepo.Update(owoce);

            produkty_zbozowe.Produkty = new List<Produkt> { maka_pszenna, maka_ziemniaczana, platki_czekoladowe };
            App.KategoriaRepo.Update(produkty_zbozowe);

            jajkak.Produkty = new List<Produkt> { jajka };
            App.KategoriaRepo.Update(jajkak);

            przyprawy.Produkty = new List<Produkt> { sol, cukier };
            App.KategoriaRepo.Update(przyprawy);

            nabial.Produkty = new List<Produkt> { mleko };
            App.KategoriaRepo.Update(nabial);

            Przepis kopytka = App.PrzepisRepo.AddPrzepis(
                "Kopytka",
                "1. Ziemniaki umyć, obrać, wieksze przekroić, zalać wodą, posolić i zagotować. Gotować pod przykryciem przez ok. 30 minut lub do miękkości (wbity nóż ma gładko w nie wchodzić).\n\n"
                + "2. Odcedzić i od razu rozgnieść praską na idealnie gładkie puree. Całkowicie ostudzić.\n\n"
                + "3. Na stolnicę przesiać mąkę, dodać ziemniaki, zrobić w środku wgłębienie i wbić w nie jajko. Całość posolić i zagnieść gładkie ciasto, w razie potrzeby podsypać delikatnie mąką. Można użyć miksera planetarnego (łopatki). Im mniej dodamy mąki, tym kopytka będą delikatniejsze.\n\n"
                + "4. Zagotować duży garnek z osoloną wodą. Ciasto podzielić na 4 części, z każdej uformować wałeczek o grubości kciuka. Nożem odkrajać kawałki tzw. kopytka o szerokości ok. 1,5 - 2 cm.\n\n"
                + "5. Wrzucać na gotującą się wodę i gotować przez ok. 4 minuty licząc od czasu wypłynięcia na powierzchnię lub do miękkości. W trakcie gotowania delikatnie przemieszać wodę drewnianą łyżką sprawdzając czy kopytka nie przykleiły się do dna. Wyławiać łyżką cedzakową i wykładać na talerze.", 
                30,
                "https://static.gotujmy.pl/ZDJECIE_PRZEPISU_ETAP/kopytka-z-maka-kukurydziana-433153.jpg");
            obiad.Przepisy = new List<Przepis> { kopytka };
            App.TypRepo.Update(obiad);

            Skladnik skladnikiKopytek1 = App.SkladnikRepo.AddSkladnik(500, "g");
            kopytka.Zawiera = new List<Skladnik> { skladnikiKopytek1 };
            App.PrzepisRepo.Update(kopytka);
            ziemniaki.Skladniki = new List<Skladnik> { skladnikiKopytek1 };
            App.ProduktRepo.Update(ziemniaki);

            Skladnik skladnikiKopytek2 = App.SkladnikRepo.AddSkladnik(100, "g");
            kopytka.Zawiera.Add(skladnikiKopytek2);
            App.PrzepisRepo.Update(kopytka);
            maka_pszenna.Skladniki = new List<Skladnik> { skladnikiKopytek2 };
            App.ProduktRepo.Update(maka_pszenna);

            Skladnik skladnikiKopytek3 = App.SkladnikRepo.AddSkladnik(1, "sztuk");
            kopytka.Zawiera.Add(skladnikiKopytek3);
            App.PrzepisRepo.Update(kopytka);
            jajka.Skladniki = new List<Skladnik> { skladnikiKopytek3 };
            App.ProduktRepo.Update(jajka);

            Skladnik skladnikiKopytek4 = App.SkladnikRepo.AddSkladnik(10, "g");
            kopytka.Zawiera.Add(skladnikiKopytek4);
            App.PrzepisRepo.Update(kopytka);
            sol.Skladniki = new List<Skladnik> { skladnikiKopytek4 };
            App.ProduktRepo.Update(sol);

            Przepis platkiCzekoladowe = App.PrzepisRepo.AddPrzepis(
                "Płatki z mlekiem", 
                "1. Nasyp płatki do miski.\n\n2. Zalej płatki ciepłym lub zimnym mlekiem.\n\n3. Gotowe!",
                2,
                "http://www.prowadzedom.pl/wp-content/uploads/2014/10/kulki-czekoladowe.gif");
            sniadanie.Przepisy = new List<Przepis> { platkiCzekoladowe };
            App.TypRepo.Update(sniadanie);

            Skladnik skladnikiPlatekCzekoladowych1 = App.SkladnikRepo.AddSkladnik(250, "g");
            platkiCzekoladowe.Zawiera = new List<Skladnik> { skladnikiPlatekCzekoladowych1 };
            App.PrzepisRepo.Update(platkiCzekoladowe);
            platki_czekoladowe.Skladniki = new List<Skladnik> { skladnikiPlatekCzekoladowych1 };
            App.ProduktRepo.Update(platki_czekoladowe);

            Skladnik skladnikiPlatekCzekoladowych2 = App.SkladnikRepo.AddSkladnik(250, "ml");
            platkiCzekoladowe.Zawiera.Add(skladnikiPlatekCzekoladowych2);
            App.PrzepisRepo.Update(platkiCzekoladowe);
            mleko.Skladniki = new List<Skladnik> { skladnikiPlatekCzekoladowych2 };
            App.ProduktRepo.Update(mleko);

            var przepisy = App.PrzepisRepo.GetAllPrzepis();
            var typy = App.TypRepo.GetAllTyp();
            var kategorie = App.KategoriaRepo.GetAllKategoria();
            var skladniki = App.SkladnikRepo.GetAllSkladnik();
            var produkty = App.ProduktRepo.GetAllProdukt();
        }
    }
}
