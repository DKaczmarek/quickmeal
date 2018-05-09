﻿using quickmeal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace quickmeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPreview : ContentPage
    {
        private Product product;

        public ProductPreview(object product)
        {
            InitializeComponent();

            this.product = (Product)product;
            updateFields();
        }

        private void updateFields()
        {
            ContentPage TitleName = this.FindByName<ContentPage>("TitleName");
            TitleName.Title = product.Name;

            Label ProductName = this.FindByName<Label>("ProductName");
            ProductName.Text = product.Name;

            Label ProductCategory = this.FindByName<Label>("ProductCategory");
            ProductCategory.Text = product.Category;

            Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            ProductAmount.Text = product.Amount.ToString();
            
            Label ProductType = this.FindByName<Label>("ProductType");
            ProductType.Text = product.Type;

        }
        private void SaveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as ViewModels.ProductViewModels;
            vm?.RemoveCommand.Execute(product);

            Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            product.Amount = Convert.ToInt32(ProductAmount.Text);
            vm?.InsertCommand.Execute(product);


            Navigation.RemovePage(this);
            //Navigation.RemovePage(Navigation.NavigationStack.LastOrDefault());

        }
    }
}