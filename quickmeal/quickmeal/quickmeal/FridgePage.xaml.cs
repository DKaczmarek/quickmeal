﻿using quickmeal.Models;
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
        private ListView listView_produkty = new ListView();
        private ListView listView_lodowka = new ListView();
        private ObservableCollection<Models.Lodowka> lodowka;
        private ObservableCollection<Models.Produkt> produkts;
        public FridgePage()
        {
            InitializeComponent();
            ViewModels.LodowkaViewModel viewModels_lodowka = new ViewModels.LodowkaViewModel();
            ViewModels.ProductViewModels viewModels_produkty = new ViewModels.ProductViewModels();
            BindingContext = viewModels_lodowka;
            produkts = viewModels_produkty.Products;
            listView_produkty = this.FindByName<ListView>("ProductList");
            listView_lodowka = this.FindByName<ListView>("FridgeList");
            
            RefreshListView();
            SearchBarEventConnect();

        }

        private async void Remove_Clicked(object sender, EventArgs e)
        {
            var x = await DisplayAlert("Usuwanie produktu", "Czy na pewno chcesz usunąć?", "Tak", "Anuluj");
            if (x==true)
            {
                var button = sender as Button;
                var lodowka_przycisk = button?.BindingContext as Models.Lodowka;
                App.LodowkaRepo.Remove(lodowka_przycisk);

                RefreshListView();
            }

        }

        public void RefreshListView()
        {
            ViewModels.LodowkaViewModel viewModels_lodowka = new ViewModels.LodowkaViewModel();
            lodowka = viewModels_lodowka.Lodowka;
            listView_lodowka.ItemsSource = lodowka;
        }
        public void ClearSearchBar()
        {
            Entry searchBar = this.FindByName<Entry>("productEntry");
            searchBar.Text = "";
        }

        private void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var lodowka = button?.BindingContext as Models.Lodowka;
            Navigation.PushAsync(new FridgePreview(lodowka, this)); //Należy zrobić nową zakładke od podglądu lodówki, a ProductPreview będzie do dodawania produktu do lodówki
   
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            //Po kliknięciu dodaj, powinna otworzyć się zakładka ProductPreview
            var button = sender as Button;
            var wybrany_produkt = button?.BindingContext as Models.Produkt;
            Navigation.PushAsync(new ProductPreview(wybrany_produkt, this));
        }

        private void SearchBarEventConnect()
        {
            try
            {
                Entry searchBar = this.FindByName<Entry>("productEntry");

                searchBar.TextChanged += (sender, e) =>
                {
                    if (searchBar.Text != null && searchBar.Text != "")
                    {
                        listView_produkty.IsVisible = true;
                        string keyword = searchBar.Text;
                        IEnumerable<Produkt> searchResult = produkts.Where(
                        r => r.Nazwa.ToLower().Contains(keyword.ToLower())
                        );
                        listView_produkty.ItemsSource = searchResult;
                    }
                    else
                    {
                        listView_produkty.ItemsSource = null;
                        listView_produkty.IsVisible = false;
                    }

                };
            }
            catch
            {

            }
        }
    }
}