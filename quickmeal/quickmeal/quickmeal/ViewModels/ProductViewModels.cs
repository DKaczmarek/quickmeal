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
        private ObservableCollection<Models.Product> products;
        public ObservableCollection<Models.Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public ProductViewModels()
        {
            Products = new ObservableCollection<Models.Product>();
            foreach (var product in _context.Products)
            {
                Products.Add(product);
            }
            Products = new ObservableCollection<Models.Product>(Products.OrderBy(i => i.Name));
        }
        public Command<Models.Product> InsertCommand
        {
            get
            {
                return new Command<Models.Product>((product) =>
                {
                    Products.Insert(0, product);
                });
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
