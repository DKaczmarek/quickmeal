using quickmeal.Models;
using quickmeal.MyDataSource;
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
        private ListView listView = new ListView();
        private ObservableCollection<Models.Produkt> products;
        public FridgePage()
        {
            InitializeComponent();
            ViewModels.ProductViewModels viewModels = new ViewModels.ProductViewModels();
            BindingContext = viewModels;
            products = viewModels.Products;

            listView = this.FindByName<ListView>("FridgeList");

            SearchBarEventConnect();

        }

        private async void Remove_Clicked(object sender, EventArgs e)
        {
            var x = await DisplayAlert("Usuwanie produktu", "Czy na pewno chcesz usunąć?", "Tak", "Anuluj");
            if (x==true)
            {
                var button = sender as Button;
                var product = button?.BindingContext as Models.Produkt;
                var vm = BindingContext as ViewModels.ProductViewModels;
                vm?.RemoveCommand.Execute(product);
            }

        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button?.BindingContext as Models.Produkt;
            Navigation.PushAsync(new ProductPreview(product));
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Models.Produkt product = new Models.Produkt();
            var productName = productEntry.Text;
            product.Nazwa = productName;

            var button = sender as Button;
            var vm = BindingContext as ViewModels.ProductViewModels;

            if (!string.IsNullOrEmpty(productName))
            {
                vm?.InsertCommand.Execute(product);
            }
        }

        private void SearchBarEventConnect()
        {
            Entry searchBar = this.FindByName<Entry>("productEntry");
            searchBar.TextChanged += (sender, e) =>
            {
                string keyword = searchBar.Text;
                IEnumerable<Produkt> searchResult = products.Where(
                r => r.Nazwa.ToLower().Contains(keyword.ToLower())
                );
                listView.ItemsSource = searchResult;
            };
        }
    }
}