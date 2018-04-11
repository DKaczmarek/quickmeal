using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

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

        public Command<Models.Product> RemoveCommand
        {
            get
            {
                return new Command<Models.Product>((product) =>
                {
                    Products.Remove(product);
                });
            }
        }

        public Command<Models.Product> UpdateCommand
        {
            get
            {
                return new Command<Models.Product>((product) =>
                {
                Products.Remove(product);
                Products.Insert(Products.IndexOf(product), product);
                });
            }
        }
    }
}
