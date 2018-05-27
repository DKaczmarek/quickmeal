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
        private FridgePage fridgePage;
        public ProductPreview(object product, FridgePage fridgePage)
        {
            InitializeComponent();
            this.fridgePage = fridgePage;
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
            Label ProductType = this.FindByName<Label>("ProductType");

            List<Skladnik> ingredients = App.SkladnikRepo.GetAllSkladnik(); //Pobranie wszystkich skladnikow
            foreach (var skladnik in ingredients)
            {
                if (skladnik.Id_Produktu == product.Id)
                {
                    ProductType.Text = product.Gramatura;
                }
            }
        }
        private void SaveClicked(object sender, EventArgs e)
        {
            Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            if (ProductAmount.Text == null || ProductAmount.Text == "" || ProductAmount.Text == "0") ProductAmount.Text = "1";
            int ilosc = Convert.ToInt32(ProductAmount.Text);
            product.Ilosc = ilosc;

            Lodowka dodawanyProdukt = App.LodowkaRepo.GetAllProdukt().Where(x => x.Id_Produktu == product.Id).FirstOrDefault();
            if (dodawanyProdukt == null)
            {
                Lodowka lodowka = App.LodowkaRepo.AddLodowka(product.Ilosc);
                lodowka.Id_Produktu = product.Id;
                lodowka.Nazwa = product.Nazwa;
                lodowka.Gramatura = product.Gramatura;

                App.LodowkaRepo.Update(lodowka);
            }
            else
            {
                dodawanyProdukt.Ilosc += ilosc;
                App.LodowkaRepo.Update(dodawanyProdukt);
            }
            fridgePage.RefreshListView();
            fridgePage.ClearSearchBar();
            Navigation.RemovePage(this);
        }
    }
}