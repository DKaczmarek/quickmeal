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
        public string ImgSource { get; set; }
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

        // image souce
        private string HaveMark = "tick.png";
        private string HaveNotMark = "forbidden_mark.png";
        private string Mark = "minus.png";

        // przepis types
        private string Normal = "quickmeal.Models.Przepis";
        private string Enhanced = "quickmeal.Models.Przepis_alg";
        private bool EnhancedType;

        public RecipePreview (object recipe)
		{
			InitializeComponent ();
            IngredientItems = new ObservableCollection<IngredientItem>();

            // set TypeIndicator
            var type = recipe.GetType();
            if (type.FullName == Normal) EnhancedType = false;
            else if (type.FullName == Enhanced) EnhancedType = true;

            // show ingredients list
            ShowIngredients(recipe);
            BindingContext = new IngredientItemViewModel(IngredientItems);
            int count = IngredientItems.Count;
            RecipeIngredientsList.HeightRequest = count * 50;

            updateFields((Przepis) recipe);
        }

        private void updateFields(Przepis recipe)
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

        private void ShowIngredients(object recap)
        {
            if (EnhancedType) recipe = (Przepis_alg)recap;
            else recipe = (Przepis)recap;

            this.skladniks = recipe.Zawiera;
            List<Produkt> temp = App.ProduktRepo.GetAllProdukt();
            foreach (Skladnik s in skladniks)
            {
                string name = temp.Where(o => o.Id == s.Id_Produktu).FirstOrDefault().Nazwa;
                int ilosc = s.Ilosc;
                string gram = temp.Where(o => o.Id == s.Id_Produktu).FirstOrDefault().Gramatura;
                string source = GetSource(s, recap);

                IngredientItems.Add(new IngredientItem
                {
                    Name = name,
                    Amount = ilosc,
                    Gramatura = gram,
                    ImgSource = source
                });
            }
        }

        private string GetSource(Skladnik ingredient, object recap)
        {
            if (!EnhancedType)
                return Mark;

            Przepis_alg temp = (Przepis_alg)recap;
            foreach (Produkt s in temp.lista_skla)
            {
                if (s.Id == ingredient.Id_Produktu)
                    return HaveMark;
            }

            return HaveNotMark;

        }
    }
}