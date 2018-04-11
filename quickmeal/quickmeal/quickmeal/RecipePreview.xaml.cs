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
	public partial class RecipePreview : ContentPage
	{
        private Recipe recipe;

		public RecipePreview (object recipe)
		{
			InitializeComponent ();

            this.recipe = (Recipe) recipe;
            updateFields();
        }

        private void updateFields()
        {
            Label RecipeName = this.FindByName<Label>("RecipeName");
            RecipeName.Text = recipe.Name;

            Image image = this.FindByName<Image>("RecipeImage");
            image.Source = recipe.ImageURL;

            Label RecipeTime = this.FindByName<Label>("RecipeTime");
            RecipeTime.Text = "Szacowany czas: " + recipe.Time.ToString() + "min";

            Label RecipeDescription = this.FindByName<Label>("RecipeDescription");
            RecipeDescription.Text = recipe.Description;
        }
	}
}