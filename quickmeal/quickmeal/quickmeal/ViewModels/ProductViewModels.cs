using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace quickmeal.ViewModels
{
    public class ProductViewModels
    {
        MyDataSource.ProductData _context = new MyDataSource.ProductData();


        private ObservableCollection<Models.Produkt> products;
        public ObservableCollection<Models.Produkt> Products
        {
            get { return products; }
            set { products = value; }
        }

        public ProductViewModels()
        {
            Products = new ObservableCollection<Models.Produkt>();
          
            foreach (var product in _context.Products)
            {
                Products.Add(product);
            }

            Products = new ObservableCollection<Models.Produkt>(Products.OrderBy(i => i.Nazwa));
        }
        public Command<Models.Produkt> InsertCommand
        {
            get
            {
                return new Command<Models.Produkt>((product) =>
                {
                    Products.Insert(0, product);
                });
            }
        }

        public Command<Models.Produkt> RemoveCommand
        {
            get
            {
                return new Command<Models.Produkt>((product) =>
                {
                    Products.Remove(product);
                });
            }
        }

        public Command<Models.Produkt> UpdateCommand
        {
            get
            {
                return new Command<Models.Produkt>((product) =>
                {
                Products.Remove(product);
                Products.Insert(Products.IndexOf(product), product);
                });
            }
        }
    }
}
