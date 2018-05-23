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
    public partial class FavouriteRecipesPage : ContentPage
    {

        private ListView listView;
        private ObservableCollection<Models.Przepis> recipes;
        private ViewModels.PrzepisViewModels viewModels;

        public FavouriteRecipesPage()
        {
            InitializeComponent();

            viewModels = new ViewModels.PrzepisViewModels();
            recipes = GetFavRecipes(viewModels.Recipes);
            viewModels.Recipes = recipes;
            BindingContext = viewModels;

            listView = this.FindByName<ListView>("FavRecipesList");

            SearchBarEventConnect();
        }

        private ObservableCollection<Przepis> GetFavRecipes(ObservableCollection<Przepis> recipes)
        {
            ObservableCollection<Przepis> FavRecipes = new ObservableCollection<Przepis>();
            List<Ulubiony> Favs = App.UlubionyRepo.GetAllUlubione();

            foreach(Ulubiony f in Favs)
            {
                Przepis p = recipes.Where(r => r.Id == f.Id_Przepisu).FirstOrDefault();
                if(p != null)
                    FavRecipes.Add(p);
            }
            return FavRecipes;
        }

        async void OnMore(object sender, EventArgs e)
        {
            MenuItem SelectedRecipe = ((MenuItem)sender);
            Przepis Fav = (Przepis)SelectedRecipe.CommandParameter;
            Typ type = App.TypRepo.GetAllTyp().Where(t => t.Id == Fav.Id_Typu).FirstOrDefault();

            String Short_Summary = "Rodzaj: " + type.Nazwa + "\nCzas trwania: " + Fav.Czas.ToString()
                + "\nLiczba składników: " + Fav.Zawiera.Count;

            await DisplayAlert(Fav.Nazwa, Short_Summary, "OK");
        }

        private void OnDelete(object sender, EventArgs e)
        {
            MenuItem SelectedRecipe = ((MenuItem)sender);
            Przepis Fav = (Przepis)SelectedRecipe.CommandParameter;

            App.UlubionyRepo.Remove(Fav.ulubiony);

            String toast_message = "Usunięto " + Fav.Nazwa + " z ulubionych";
            DependencyService.Get<Toast>().Show(toast_message);

            recipes = GetFavRecipes(viewModels.Recipes);
            listView.ItemsSource = recipes;
        }

        private async void ShowRecipeButton_Clicked(object sender, EventArgs e)
        {
            object obj = listView.SelectedItem;
            if (obj == null)
            {
                await DisplayAlert("Alert", "Nie wybrano żadnego przepisu.", "OK");
            }
            else
            {
                await Navigation.PushAsync(new RecipePreview(obj));
            }
        }

        private void SearchBarEventConnect()
        {
            Entry searchBar = this.FindByName<Entry>("FavRecipesSearchBar");
            searchBar.TextChanged += (sender, e) =>
            {
                string keyword = searchBar.Text;
                IEnumerable<Przepis> searchResult = recipes.Where(
                r => r.Nazwa.ToLower().Contains(keyword.ToLower())
                );

                listView.ItemsSource = searchResult;
            };
        }
    }
}