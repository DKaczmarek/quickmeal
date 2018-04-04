using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace quickmeal.ViewModels
{
    public class ProductViewModels
    {
        private ObservableCollection<Models.Product> products;
        public ObservableCollection<Models.Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public ProductViewModels()
        {
            Products = new ObservableCollection<Models.Product>();
            MyDataSource.ProductData _context = new MyDataSource.ProductData();
            foreach(var product in _context.Products)
            {
                Products.Add(product);
            }
        }

    }
}
