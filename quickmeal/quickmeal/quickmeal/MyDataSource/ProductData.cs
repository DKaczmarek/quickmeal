using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.MyDataSource
{
    public class ProductData
    {
        public List<Models.Product> Products = new List<Models.Product>()
        {
            new Models.Product()
            {
                ProductID=1,
                Name="Jogobella Truskawkowa",
                Category="Nabiał",
                Amount=3,
                Type="szt."

            },
            new Models.Product()
            {
                ProductID=2,
                Name="Bułka grachamka",
                Category="Pieczywo",
                Amount=8,
                Type="szt."
            },
            new Models.Product()
            {
                ProductID=3,
                Name="Kurczak",
                Category="Mięso",
                Amount=1000,
                Type="g"
            },
            new Models.Product()
            {
                ProductID=4,
                Name="Ketchup",
                Category="Dodatki",
                Amount=200,
                Type="g"
            },
            new Models.Product()
            {
                ProductID=5,
                Name="Musztarda",
                Category="Dodatki",
                Amount=100,
                Type="g"
            },
            new Models.Product()
            {
                ProductID=6,
                Name="Olej rzepakowy",
                Category="Dodatki",
                Amount=800,
                Type="ml"
            },
            new Models.Product()
            {
                ProductID=7,
                Name="Sok pomarańczowy",
                Category="Napoje",
                Amount=2000,
                Type="ml"
            },
            new Models.Product()
            {
                ProductID=8,
                Name="Mięso wieprzowe",
                Category="Mięso",
                Amount=500,
                Type="g"
            },
            new Models.Product()
            {
                ProductID=9,
                Name="Miód",
                Category="Dodatki",
                Amount=500,
                Type="ml"
            }
        };

    }
    
}
