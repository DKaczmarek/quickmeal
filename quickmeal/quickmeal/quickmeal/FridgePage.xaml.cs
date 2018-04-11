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
    }
}