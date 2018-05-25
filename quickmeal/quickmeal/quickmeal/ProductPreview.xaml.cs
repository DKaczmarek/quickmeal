using quickmeal.Models;
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
        private Produkt product;
        public ProductPreview(object product)
        {
            InitializeComponent();

            this.product = (Produkt)product;
            updateFields();
        }

        private void updateFields()
        {
            ContentPage TitleName = this.FindByName<ContentPage>("TitleName");
            TitleName.Title = product.Nazwa;

            Label ProductName = this.FindByName<Label>("ProductName");
            ProductName.Text = product.Nazwa;

            Label ProductCategory = this.FindByName<Label>("ProductCategory");

            List<Kategoria> categories = App.KategoriaRepo.GetAllKategoria(); //Pobranie wszystkich kategorii
            foreach(var kategoria in categories)
            {
                if(kategoria.Id == product.Id_Kategorii)
                {
                    ProductCategory.Text = kategoria.Nazwa;
                }
            }

            //Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            Label ProductType = this.FindByName<Label>("ProductType");

            List<Skladnik> ingredients = App.SkladnikRepo.GetAllSkladnik(); //Pobranie wszystkich skladnikow
            foreach (var skladnik in ingredients)
            {
                if (skladnik.Id_Produktu == product.Id)
                {
                    ProductType.Text = product.Gramatura;
                    //ProductAmount.Text = skladnik.Ilosc.ToString();
                }
            }
        }
        private void SaveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as ViewModels.LodowkaViewModel;
      
            
            Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            if (ProductAmount.Text == null || ProductAmount.Text == "" || ProductAmount.Text == "0") ProductAmount.Text = "1";
            int ilosc = Convert.ToInt32(ProductAmount.Text);
            product.Ilosc = ilosc;

            Lodowka lodowka = App.LodowkaRepo.AddLodowka(product.Ilosc);
            lodowka.Id_Produktu = product.Id;
            lodowka.Nazwa = product.Nazwa;
            lodowka.Gramatura = product.Gramatura;

            App.LodowkaRepo.Update(lodowka);

            Navigation.RemovePage(this);
        }
    }
}