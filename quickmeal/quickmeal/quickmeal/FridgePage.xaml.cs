using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace quickmeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FridgePage : ContentPage
    {
        public FridgePage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.ProductViewModels();
        }
    
        private void Remove_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button?.BindingContext as Models.Product;
            var vm = BindingContext as ViewModels.ProductViewModels;
            vm?.RemoveCommand.Execute(product);
        }
        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button?.BindingContext as Models.Product;
            Navigation.PushAsync(new ProductPreview(product));
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Models.Product product = new Models.Product();
            var productName = productEntry.Text;
            product.Name = productName;

            var button = sender as Button;
            var vm = BindingContext as ViewModels.ProductViewModels;

            if (!string.IsNullOrEmpty(productName))
            {
                vm?.InsertCommand.Execute(product);
            }
        }
    }
}