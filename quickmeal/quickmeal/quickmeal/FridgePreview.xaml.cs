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
    public partial class FridgePreview : ContentPage
    {
        private Lodowka lodowka;
        private FridgePage fridgePage;
        public FridgePreview(object lodowka, FridgePage fridgePage)
        {
            InitializeComponent();
            this.lodowka = (Lodowka)lodowka;
            this.fridgePage = fridgePage;
            updateFields();
        }

        private void updateFields()
        {
            ContentPage TitleName = this.FindByName<ContentPage>("TitleName");
            TitleName.Title = lodowka.Nazwa;

            Label ProductName = this.FindByName<Label>("ProductName");
            ProductName.Text = lodowka.Nazwa;

            Label ProductCategory = this.FindByName<Label>("ProductCategory");

            Produkt produkt = App.ProduktRepo.GetAllProdukt().Where(x => x.Id == lodowka.Id_Produktu).FirstOrDefault();
            if (produkt != null)
            {
                ProductCategory.Text = produkt.kategoria_produktu;
            }
              
            Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            ProductAmount.Text = lodowka.Ilosc.ToString();
            Label ProductType = this.FindByName<Label>("ProductType");
            ProductType.Text = lodowka.Gramatura;

        }
        private void SaveClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var vm = BindingContext as ViewModels.LodowkaViewModel;

            Entry ProductAmount = this.FindByName<Entry>("ProductAmount");
            if (ProductAmount.Text == null || ProductAmount.Text == "" || ProductAmount.Text == "0") ProductAmount.Text = "1";
            int ilosc = Convert.ToInt32(ProductAmount.Text);
            lodowka.Ilosc = ilosc;
            App.LodowkaRepo.Update(lodowka);
            fridgePage.RefreshListView();
            Navigation.RemovePage(this);
        }

    }
}