using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using quickmeal.Models;
using quickmeal.Constants;
using quickmeal.Droid;
namespace quickmeal
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FindMeRecipePage : ContentPage
	{
        private bool BreakfastClicked;
        private bool DinnerClicked;
        private bool DessertClicked;

        public FindMeRecipePage ()
		{
			InitializeComponent ();

            BreakfastClicked = false;
            DinnerClicked = false;
            DessertClicked = false;
            
		}

        private void BreakfastButton_Clicked(object sender, EventArgs e)
        {
            Button button = this.FindByName<Button>("BreakfastButton");
            if (!BreakfastClicked)
            {
                BreakfastClicked = true;
                button.BackgroundColor = Color.Orange;
            }
            else
            {
                BreakfastClicked = false;
                button.BackgroundColor = Color.Default;
            }
        }

        private void DinnerButton_Clicked(object sender, EventArgs e)
        {
            Button button = this.FindByName<Button>("DinnerButton");
            if (!DinnerClicked)
            {
                DinnerClicked = true;
                button.BackgroundColor = Color.Orange;
            }
            else
            {
                DinnerClicked = false;
                button.BackgroundColor = Color.Default;
            }
        }

        private void DessertButton_Clicked(object sender, EventArgs e)
        {
            Button button = this.FindByName<Button>("DessertButton");
            if (!DessertClicked)
            {
                DessertClicked = true;
                button.BackgroundColor = Color.Orange;
            }
            else
            {
                DessertClicked = false;
                button.BackgroundColor = Color.Default;
            }
        }

        private async void FindButton_Clicked(object sender, EventArgs e)
        {
            
            if (BreakfastClicked || DessertClicked || DinnerClicked)
                await DisplayAlert("Alert", "Teraz powinno szukać przepisu.", "OK");
            else
                await DisplayAlert("Hej!", "Nie wybrałeś czego szukasz.", "OK");

            if (BreakfastClicked)
            {
                
                var lista2 = App.PrzepisRepo.GetAllPrzepis();
                var lista = App.PrzepisRepo.GetSniadaniaPrzepis();
                string przepisy = String.Empty;
                foreach (var x in lista)
                {
                    przepisy = String.Concat(String.Concat(x.Nazwa, x.Opis), x.Zdjecie);
                    await DisplayAlert("test", przepisy, "ok");
                }
            }
        }
    }
}