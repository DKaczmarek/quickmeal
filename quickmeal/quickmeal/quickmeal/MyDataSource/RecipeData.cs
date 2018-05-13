using quickmeal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.MyDataSource
{
    public class RecipeData
    {
        public List<Recipe> Recipes = new List<Recipe>()
        {
            new Recipe()
            {
                RecipeID = 1,
                TypeID = 1,
                Name = "Kulki czekoladowe z mlekiem",
                Description = "Pyszne kulki!",
                Time = 3,
                ImageURL = "http://www.prowadzedom.pl/wp-content/uploads/2014/10/kulki-czekoladowe.gif"
            },
            new Recipe()
            {
                RecipeID = 2,
                TypeID = 2,
                Name = "Suche pyzy z mikrofali",
                Description = "Szybkie studenckie danie.",
                Time = 5,
                ImageURL = "https://domowe-potrawy.pl/media/2017/06/pyzy-z-miesem1.jpg"
            },
            new Recipe()
            {
                RecipeID = 3,
                TypeID = 2,
                Name = "Makaron z sosem lowieckim",
                Description = "Na obiad i na lowy !",
                Time = 15,
                ImageURL = "https://www.mojegotowanie.pl/media/cache/gallery_view/uploads/media/default/0001/42/7a92e674f7bd882b39cd7562b63e66ec89303833.jpeg"
            },
            new Recipe()
            {
                RecipeID = 4,
                TypeID = 3,
                Name = "Sernik z gruszką",
                Description = "Sposób przygotowania:\n1. Żółtka utrzyj z cukrem i cukrem wanilinowym na krem. Z umytej cytryny zetrzyj skórkę i wyciśnij sok.\n" +
                              "2. Do utartych żółtek dodaj miękką Kasię, startą skórkę z cytryny, mąkę ziemniaczaną i twaróg. Wymieszaj.\n" + 
                              "3. Gruszki obierz, usuń gniazda nasienne i pokrój na ćwiartki. Skrop sokiem z cytryny.\n" + 
                              "4. Formę o średnicy 24 cm wysmaruj Kasią i oprósz mąką. Masę serową przełóż do formy i rozprowadź.\n" +
                              "5. Na serze ułóż ćwiartki gruszek. Piecz 50-60 minut w 180 st.C.\n" +
                              "6. Miód wymieszaj z posiekanymi pistacjami i polej nim wierzch ciasta. Piecz jeszcze 10 minut.\n",
                Time = 25,
                ImageURL = "https://s3.przepisy.pl/przepisy3ii/img/variants/670x0/ciasto-serowo-gruszkowe96.jpg"
            },
            new Recipe()
            {
                RecipeID = 5,
                TypeID = 4,
                Name = "Sałatka z kaszą kuskus",
                Description = "Sposób przygotowania przepisu:\n" +
                              "1. Kaszę kuskus przygotowujemy wg. instrukcji na opakowaniu." + 
                              "Ogórki, paprykę kroimy w kostkę. Awokado ścieramy na tarce o dużych oczkach. Czosnek przeciskamy przez wyciskacz do czosnku.\n" +
                              "Do wystudzonej kaszy kuskus dodajemy warzywa, nasiona chia, oliwę. Doprawiamy do smaku\n",
                Time = 30,
                ImageURL = "https://www.przyslijprzepis.pl/media/cache/gallery_view/uploads/media/recipe/0006/88/salatka-z-kasza-kuskus_1.jpeg"
            }
        };

    }
}
