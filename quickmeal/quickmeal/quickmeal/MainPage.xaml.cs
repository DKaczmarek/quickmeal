using Android.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace quickmeal
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void fridgeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FridgePage());
        }

        private async void favRecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavouriteRecipesPage());
        }

        private async void findRecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FindMeRecipePage());
        }
    }
}
