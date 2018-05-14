using System;
using System.Collections.Generic;
using System.Text;
using quickmeal.Models;

namespace quickmeal.MyDataSource
{
    class ProductData
    {
        public List<Produkt> Products = new List<Produkt>();
        public ProductData()
        {
            Products = App.ProduktRepo.GetAllProdukt();
        }

    }
    
}
