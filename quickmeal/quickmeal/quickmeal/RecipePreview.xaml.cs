using quickmeal.Models;
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
    public class IngredientItem
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Gramatura { get; set; }
    }

    public class IngredientItemViewModel
    {
        private ObservableCollection<IngredientItem> ingredientItems;
        public ObservableCollection<IngredientItem> IngredientItems
        {
            get { return ingredientItems; }
            set { ingredientItems = value; }
        }

        public IngredientItemViewModel(ObservableCollection<IngredientItem> value)
        {
            IngredientItems = new ObservableCollection<IngredientItem>();

            IngredientItems = value;
        }
    }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipePreview : ContentPage
	{
        private Przepis recipe;
        private List<Skladnik> skladniks;
        private ObservableCollection<IngredientItem> IngredientItems { get; set; }

		public RecipePreview (object recipe)
		{
			InitializeComponent ();
            IngredientItems = new ObservableCollection<IngredientItem>();
            this.recipe = (Przepis)recipe;
            ShowIngredients();

            BindingContext = new IngredientItemViewModel(IngredientItems);
            int count = IngredientItems.Count;
            RecipeIngredientsList.HeightRequest = count * 50;

            updateFields();
        }

        private void updateFields()
        {
            Label RecipeName = this.FindByName<Label>("RecipeName");
            RecipeName.Text = recipe.Nazwa;

            Image image = this.FindByName<Image>("RecipeImage");
            image.Source = recipe.Zdjecie;

            Label RecipeTime = this.FindByName<Label>("RecipeTime");
            RecipeTime.Text = "Szacowany czas: " + recipe.Czas.ToString() + "min";

            Label RecipeDescription = this.FindByName<Label>("RecipeDescription");
            RecipeDescription.Text = recipe.Opis;

        }

        private void ShowIngredients()
        {
            this.skladniks = recipe.Zawiera;
            List<Produkt> temp = App.ProduktRepo.GetAllProdukt();
            foreach (Skladnik s in skladniks)
            {
                string name = temp.Where(o => o.Id == s.Id_Produktu).FirstOrDefault().Nazwa;
                int ilosc = s.Ilosc;
                string gram = temp.Where(o => o.Id == s.Id_Produktu).FirstOrDefault().Gramatura; 

                IngredientItems.Add(new IngredientItem
                {
                    Name = name,
                    Amount = ilosc,
                    Gramatura = gram
                });
            }
        }
	}
}