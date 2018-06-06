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
            Produkt maslo = App.ProduktRepo.AddProdukt("Masło", "g");
            Produkt szpinak = App.ProduktRepo.AddProdukt("Szpinak", "g");
            Produkt pieprz = App.ProduktRepo.AddProdukt("Pieprz", "g");
            Produkt galka_muszkatolowa = App.ProduktRepo.AddProdukt("Gałka muszkatołowa", "g");
            Produkt szczypiorek = App.ProduktRepo.AddProdukt("Szczypiorek", "g");
            Produkt smietana18 = App.ProduktRepo.AddProdukt("Śmietana 18%", "ml");
            Produkt boczek = App.ProduktRepo.AddProdukt("Boczek", "g");
            Produkt cukier_puder = App.ProduktRepo.AddProdukt("Cukier puder", "g");
            Produkt bazylia = App.ProduktRepo.AddProdukt("Świeża bazylia", "sztuk");
            Produkt limonka = App.ProduktRepo.AddProdukt("Limonka", "sztuk");
            Produkt cukier_wanilinowy = App.ProduktRepo.AddProdukt("Cukier wanilinowy", "g");
            Produkt drozdze = App.ProduktRepo.AddProdukt("Drożdże", "g");
            Produkt maka_tortowa = App.ProduktRepo.AddProdukt("Mąka tortowa", "g");
            Produkt sok_pomaranczowy = App.ProduktRepo.AddProdukt("Sok pomarańczowy", "ml");
            Produkt wiorki_kokosowe = App.ProduktRepo.AddProdukt("Wiórki kokosowe", "g");

            /* Kategorie */
            Kategoria warzywa = App.KategoriaRepo.AddKategoria("Warzywa");
            Kategoria ziola = App.KategoriaRepo.AddKategoria("Zioła");
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
            Kategoria sok = App.KategoriaRepo.AddKategoria("Sok");

            /* Przypisanie produktow do kategorii */
            warzywa.Produkty = new List<Produkt> { ziemniaki, brokul, cebula, szparag, szczypiorek, szpinak };
            App.KategoriaRepo.Update(warzywa);

            sok.Produkty = new List<Produkt> { sok_pomaranczowy};
            App.KategoriaRepo.Update(sok);

            owoce.Produkty = new List<Produkt> { banan, truskawka, ananas, limonka };
            App.KategoriaRepo.Update(owoce);

            produkty_zbozowe.Produkty = new List<Produkt> { maka_pszenna, maka_ziemniaczana, platki_czekoladowe, makaron, maka_tortowa };
            App.KategoriaRepo.Update(produkty_zbozowe);

            jajkak.Produkty = new List<Produkt> { jajka };
            App.KategoriaRepo.Update(jajkak);

            ziola.Produkty = new List<Produkt> { bazylia };
            App.KategoriaRepo.Update(ziola);

            dodatki.Produkty = new List<Produkt> { drozdze, wiorki_kokosowe };
            App.KategoriaRepo.Update(dodatki);

            slodycze_cukier.Produkty = new List<Produkt> { cukier, cukier_puder, cukier_wanilinowy };
            App.KategoriaRepo.Update(slodycze_cukier);

            przyprawy.Produkty = new List<Produkt> { sol, pieprz, galka_muszkatolowa };
            App.KategoriaRepo.Update(przyprawy);

            nabial.Produkty = new List<Produkt> { mleko, smietanka_kremowka, smietana18 };
            App.KategoriaRepo.Update(nabial);

            mieso.Produkty = new List<Produkt> { kurczak_filet, boczek };
            App.KategoriaRepo.Update(mieso);

            Tluszcze.Produkty = new List<Produkt> { olej, maslo };
            App.KategoriaRepo.Update(Tluszcze);



            /* Przepisy */

            Przepis koktajl_truskawkowo_bananowo_kokosowy = App.PrzepisRepo.AddPrzepis("Koktajl truskawkowo-bananowo-kokosowy",
                "1. Truskawki dokładne wypłukać i usunąć szypułki\n\n" +
                "2. Pokroić je na połówki i wrzucić do kielicha blendera. Banana pokroić na kawałki, dodać do truskawek.\n\n" +
                "3. Dodać również wiórki kokosowe i zalać wszystko mocno schłodzonym mlekiem.\n\n" +
                "4. Blendować do momentu, aż składniki dobrze się ze sobą połączą. Pić od razu po przygotowaniu.\n\n",
                15, 
                "https://pliki.doradcasmaku.pl/big-cropped-1527782368-koktajl-truskawkowo-bananowo-kokosowy-got5-male.jpg"
                );

            Skladnik skladnikktbk1 = App.SkladnikRepo.AddSkladnik(250);
            koktajl_truskawkowo_bananowo_kokosowy.Zawiera.Add(skladnikktbk1);
            App.PrzepisRepo.Update(koktajl_truskawkowo_bananowo_kokosowy);
            truskawka.Skladniki.Add(skladnikktbk1);
            App.ProduktRepo.Update(truskawka);

            Skladnik skladnikktbk2 = App.SkladnikRepo.AddSkladnik(1);
            koktajl_truskawkowo_bananowo_kokosowy.Zawiera.Add(skladnikktbk2);
            App.PrzepisRepo.Update(koktajl_truskawkowo_bananowo_kokosowy);
            banan.Skladniki.Add(skladnikktbk2);
            App.ProduktRepo.Update(banan);

            Skladnik skladnikktbk3 = App.SkladnikRepo.AddSkladnik(10);
            koktajl_truskawkowo_bananowo_kokosowy.Zawiera.Add(skladnikktbk3);
            App.PrzepisRepo.Update(koktajl_truskawkowo_bananowo_kokosowy);
            wiorki_kokosowe.Skladniki.Add(skladnikktbk3);
            App.ProduktRepo.Update(wiorki_kokosowe);

            Skladnik skladnikktbk4 = App.SkladnikRepo.AddSkladnik(250);
            koktajl_truskawkowo_bananowo_kokosowy.Zawiera.Add(skladnikktbk4);
            App.PrzepisRepo.Update(koktajl_truskawkowo_bananowo_kokosowy);
            mleko.Skladniki.Add(skladnikktbk4);
            App.ProduktRepo.Update(mleko);



            Przepis slodkie_buleczki = App.PrzepisRepo.AddPrzepis("Słodkie bułeczki pomarańczowe",
              "1. Przygotowujemy rozczyn. Drożdże rozcieramy z 2 łyżeczkami cukru, 1 łyżką mąki i ciepłym sokiem. Przykrywamy ściereczką i odstawiamy na około 15 minut w ciepłe miejsce, żeby rozczyn ,,ruszył''.\n\n" +
              "2. Przygotowujemy ciasto. Jajko ucieramy z cukrem i cukrem waniliowym na puszystą masę. Do mąki dodajemy sól, wyrośnięte drożdże, utarte jajka i stopniowo wlewając ciepły sok zagniatamy mięciutkie ciasto. Ciasto przykrywamy ściereczką i odstawiamy na około 45 minut w ciepłe miejsce do wyrośnięcia.\n\n" +
              "3. Formowanie: Z wyrośniętego ciasta formujemy okrągłe bułeczki, układamy je na blasze wyłożonej papierem do pieczenia i odstawiamy jeszcze na 15 minut w ciepłe miejsce do podrośnięcia. Wyszło mi 8 sztuk.\n\n" +
              "4. Po tym czasie bułki pieczemy w temperaturze 180 stopni do zrumienienia przez około 30-35 minut.\n\n" +
              "5. Tak wykonane bułki są gotowe do podania. Smacznego życzę.",
              60,
              "https://pliki.doradcasmaku.pl/big-cropped-1528125601-bulkip-037-kopiowanie.jpg");

            Skladnik skladniklsb1 = App.SkladnikRepo.AddSkladnik(25);
            slodkie_buleczki.Zawiera.Add(skladniklsb1);
            App.PrzepisRepo.Update(slodkie_buleczki);
            drozdze.Skladniki.Add(skladniklsb1);
            App.ProduktRepo.Update(drozdze);

            Skladnik skladniklsb2 = App.SkladnikRepo.AddSkladnik(200);
            slodkie_buleczki.Zawiera.Add(skladniklsb2);
            App.PrzepisRepo.Update(slodkie_buleczki);
            cukier.Skladniki.Add(skladniklsb2);
            App.ProduktRepo.Update(cukier);

            Skladnik skladniklsb3 = App.SkladnikRepo.AddSkladnik(500);
            slodkie_buleczki.Zawiera.Add(skladniklsb3);
            App.PrzepisRepo.Update(slodkie_buleczki);
            maka_tortowa.Skladniki.Add(skladniklsb3);
            App.ProduktRepo.Update(maka_tortowa);

            Skladnik skladniklsb4 = App.SkladnikRepo.AddSkladnik(400);
            slodkie_buleczki.Zawiera.Add(skladniklsb4);
            App.PrzepisRepo.Update(slodkie_buleczki);
            sok_pomaranczowy.Skladniki.Add(skladniklsb4);
            App.ProduktRepo.Update(sok_pomaranczowy);

            Skladnik skladniklsb5 = App.SkladnikRepo.AddSkladnik(1);
            slodkie_buleczki.Zawiera.Add(skladniklsb5);
            App.PrzepisRepo.Update(slodkie_buleczki);
            jajka.Skladniki.Add(skladniklsb5);
            App.ProduktRepo.Update(jajka);

            Skladnik skladniklsb6 = App.SkladnikRepo.AddSkladnik(5);
            slodkie_buleczki.Zawiera.Add(skladniklsb6);
            App.PrzepisRepo.Update(slodkie_buleczki);
            cukier_wanilinowy.Skladniki.Add(skladniklsb6);
            App.ProduktRepo.Update(cukier_wanilinowy);



            Przepis lody_tajskie = App.PrzepisRepo.AddPrzepis("Lody tajskie",
                "1. Truskawki i banana kroimy w drobną kostkę. Owoce posypujemy czubatą łyżeczką cukru pudru. Płaską stroną noża rozcieramy je na jednolitą masę i przekładamy całość do miski. \n\n" +
                "2. Dodajemy posiekaną bazylię i skórkę otartą z umytej limonki oraz cukier wanilinowy. Dolewamy śmietankę i mleko. Masę dokładnie mieszamy za pomocą trzepaczki. Dodajemy sok wyciśnięty z połowy limonki.\n\n" +
                "3. Masę wylewamy na schłodzoną blachę i formujemy lody.",
                20,
                "http://thaiice.pl/wp-content/uploads/2017/04/lody-tajskie-warszawa.jpg");

            Skladnik skladniklt1 = App.SkladnikRepo.AddSkladnik(7);
            lody_tajskie.Zawiera.Add(skladniklt1);
            App.PrzepisRepo.Update(lody_tajskie);
            truskawka.Skladniki.Add(skladniklt1);
            App.ProduktRepo.Update(truskawka);

            Skladnik skladniklt2 = App.SkladnikRepo.AddSkladnik(1);
            lody_tajskie.Zawiera.Add(skladniklt2);
            App.PrzepisRepo.Update(lody_tajskie);
            banan.Skladniki.Add(skladniklt2);
            App.ProduktRepo.Update(banan);

            Skladnik skladniklt3 = App.SkladnikRepo.AddSkladnik(5);
            lody_tajskie.Zawiera.Add(skladniklt3);
            App.PrzepisRepo.Update(lody_tajskie);
            cukier_puder.Skladniki.Add(skladniklt3);
            App.ProduktRepo.Update(cukier_puder);

            Skladnik skladniklt4 = App.SkladnikRepo.AddSkladnik(5);
            lody_tajskie.Zawiera.Add(skladniklt4);
            App.PrzepisRepo.Update(lody_tajskie);
            bazylia.Skladniki.Add(skladniklt4);
            App.ProduktRepo.Update(bazylia);

            Skladnik skladniklt5 = App.SkladnikRepo.AddSkladnik(1);
            lody_tajskie.Zawiera.Add(skladniklt5);
            App.PrzepisRepo.Update(lody_tajskie);
            limonka.Skladniki.Add(skladniklt5);
            App.ProduktRepo.Update(limonka);

            Skladnik skladniklt6 = App.SkladnikRepo.AddSkladnik(3);
            lody_tajskie.Zawiera.Add(skladniklt6);
            App.PrzepisRepo.Update(lody_tajskie);
            cukier_wanilinowy.Skladniki.Add(skladniklt6);
            App.ProduktRepo.Update(cukier_wanilinowy);

            Skladnik skladniklt7 = App.SkladnikRepo.AddSkladnik(200);
            lody_tajskie.Zawiera.Add(skladniklt7);
            App.PrzepisRepo.Update(lody_tajskie);
            smietanka_kremowka.Skladniki.Add(skladniklt7);
            App.ProduktRepo.Update(smietanka_kremowka);

            Skladnik skladniklt8 = App.SkladnikRepo.AddSkladnik(20);
            lody_tajskie.Zawiera.Add(skladniklt8);
            App.PrzepisRepo.Update(lody_tajskie);
            mleko.Skladniki.Add(skladniklt8);
            App.ProduktRepo.Update(smietanka_kremowka);


            Przepis jajecznica = App.PrzepisRepo.AddPrzepis("Klasyczna Jajecznica",
                "1. Cebulę siekamy w drobną kostkę, boczek kroimy na mniejsze kawałki. \n\n"+
                "2. Jajka wbijamy do miseczki. Na patelni roztapiamy masło. \n\n"+
                "3. Pokrojoną cebulę wrzucamy na patelnię i czekamy, aż się zeszkli.\n\n" +
                "4. Jajka doprawiamy solą i pieprzem, a następnie rozbijamy za pomocą trzepaczki. \n\n" +
                "5. Do podsmażonej cebuli dodajemy boczek i lekko podsmażamy.\n\n"+
                "6. Wlewamy jajka na patelnię i cały czas mieszamy. Kiedy jajka się zetną, przekładamy je do miseczki.\n\n"+
                "7. Siekamy szczypiorek i posypujemy nim gotową jajecznicę.",
                15,
                "https://www.zajadam.pl/wp-content/uploads/2015/11/jajecznica-3-2-891x500.jpg");

            Skladnik skladnikJajecznica1 = App.SkladnikRepo.AddSkladnik(3);
            jajecznica.Zawiera.Add(skladnikJajecznica1);
            App.PrzepisRepo.Update(jajecznica);
            jajka.Skladniki.Add(skladnikJajecznica1);
            App.ProduktRepo.Update(jajka);

            Skladnik skladnikJajecznica2 = App.SkladnikRepo.AddSkladnik(40);
            jajecznica.Zawiera.Add(skladnikJajecznica2);
            App.PrzepisRepo.Update(jajecznica);
            boczek.Skladniki.Add(skladnikJajecznica2);
            App.ProduktRepo.Update(boczek);

            Skladnik skladnikJajecznica3 = App.SkladnikRepo.AddSkladnik(1);
            jajecznica.Zawiera.Add(skladnikJajecznica3);
            App.PrzepisRepo.Update(jajecznica);
            cebula.Skladniki.Add(skladnikJajecznica3);
            App.ProduktRepo.Update(cebula);

            Skladnik skladnikJajecznica4 = App.SkladnikRepo.AddSkladnik(15);
            jajecznica.Zawiera.Add(skladnikJajecznica4);
            App.PrzepisRepo.Update(jajecznica);
            szczypiorek.Skladniki.Add(skladnikJajecznica4);
            App.ProduktRepo.Update(szczypiorek);

            Skladnik skladnikJajecznica5 = App.SkladnikRepo.AddSkladnik(10);
            jajecznica.Zawiera.Add(skladnikJajecznica5);
            App.PrzepisRepo.Update(jajecznica);
            maslo.Skladniki.Add(skladnikJajecznica5);
            App.ProduktRepo.Update(maslo);

            Skladnik skladnikJajecznica6 = App.SkladnikRepo.AddSkladnik(1);
            jajecznica.Zawiera.Add(skladnikJajecznica6);
            App.PrzepisRepo.Update(jajecznica);
            sol.Skladniki.Add(skladnikJajecznica6);
            App.ProduktRepo.Update(sol);

            Skladnik skladnikJajecznica7 = App.SkladnikRepo.AddSkladnik(1);
            jajecznica.Zawiera.Add(skladnikJajecznica7);
            App.PrzepisRepo.Update(jajecznica);
            pieprz.Skladniki.Add(skladnikJajecznica7);
            App.ProduktRepo.Update(pieprz);


            Przepis zupaKremZBialychSzparagow = App.PrzepisRepo.AddPrzepis(
                "Zupa krem z białych szparagów",
                "1. Ziemniaki i cebulę obierz. Oba warzywa pokrój w kostkę, posiekaj szczypior.\n\n" +
                "2. Obierz szparagi i odetnij końce. Wszystkie obierzyny razem ze zdrewniałymi końcami gotuj przez 5 minut w litrze wody. Całość przecedź. \n\n" +
                "3. W kolejnym garnku na rozgrzanym tłuszczu zeszklij cebulę, dodaj szparagi i ziemniaki. Całość zalej wcześniej przygotowanym wywarem. Zupę gotuj około 30 minut, aż warzywa będą zupełnie miękkie. \n\n" +
                "4. Zupę zmiksuj w kielichu blendera, przecedź przez drobne sito. Dopraw do smaku gałką, szczyptą cukru i białym pieprzem, na koniec zapraw śmietaną. \n\n" +
                "5. Gotową zupę podawaj posypaną szczypiorem. Świetnie smakuje podane z pieczywem.",
                15,
                "https://s3.przepisy.pl/przepisy3ii/img/variants/670x0/white-asparagus-soup_a1230367.jpg");

            Skladnik skladnikzKZBS1 = App.SkladnikRepo.AddSkladnik(500);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS1);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            szparag.Skladniki.Add(skladnikzKZBS1);
            App.ProduktRepo.Update(szparag);

            Skladnik skladnikzKZBS2 = App.SkladnikRepo.AddSkladnik(10);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS2);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            cukier.Skladniki.Add(skladnikzKZBS2);
            App.ProduktRepo.Update(cukier);

            Skladnik skladnikzKZBS3 = App.SkladnikRepo.AddSkladnik(100);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS3);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            ziemniaki.Skladniki.Add(skladnikzKZBS3);
            App.ProduktRepo.Update(ziemniaki);

            Skladnik skladnikzKZBS4 = App.SkladnikRepo.AddSkladnik(1);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS4);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            cebula.Skladniki.Add(skladnikzKZBS4);
            App.ProduktRepo.Update(cebula);

            Skladnik skladnikzKZBS5 = App.SkladnikRepo.AddSkladnik(30);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS5);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            olej.Skladniki.Add(skladnikzKZBS5);
            App.ProduktRepo.Update(olej);

            Skladnik skladnikzKZBS6 = App.SkladnikRepo.AddSkladnik(150);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS6);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            smietana18.Skladniki.Add(skladnikzKZBS6);
            App.ProduktRepo.Update(smietana18);

            Skladnik skladnikzKZBS7 = App.SkladnikRepo.AddSkladnik(10);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS7);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            pieprz.Skladniki.Add(skladnikzKZBS7);
            App.ProduktRepo.Update(pieprz);

            Skladnik skladnikzKZBS8 = App.SkladnikRepo.AddSkladnik(10);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS8);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            galka_muszkatolowa.Skladniki.Add(skladnikzKZBS8);
            App.ProduktRepo.Update(galka_muszkatolowa);

            Skladnik skladnikzKZBS9 = App.SkladnikRepo.AddSkladnik(20);
            zupaKremZBialychSzparagow.Zawiera.Add(skladnikzKZBS9);
            App.PrzepisRepo.Update(zupaKremZBialychSzparagow);
            szczypiorek.Skladniki.Add(skladnikzKZBS9);
            App.ProduktRepo.Update(szczypiorek);

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
            obiad.Przepisy = new List<Przepis> { kopytka, mzkwss, mzkis, zupaKremZBialychSzparagow};
            App.TypRepo.Update(obiad);

            sniadanie.Przepisy = new List<Przepis> { platkiCzekoladowe , jajecznica };
            App.TypRepo.Update(sniadanie);

            kolacja.Przepisy = new List<Przepis> {lody_tajskie , slodkie_buleczki, koktajl_truskawkowo_bananowo_kokosowy };
            App.TypRepo.Update(kolacja);
        }
    }
}
