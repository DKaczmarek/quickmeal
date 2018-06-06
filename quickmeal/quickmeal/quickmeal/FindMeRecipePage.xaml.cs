using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using quickmeal.Models;
using quickmeal.Constants;
using quickmeal.Droid;
using SQLite.Net.Interop;
using System.Data.SqlClient;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.Collections.ObjectModel;

namespace quickmeal
{
    class PrzepisAlgData
    {
        public List<Przepis_alg> Recipes = new List<Przepis_alg>();
        public PrzepisAlgData()
        {
            Recipes = null; ;
        }

    }

    class PrzepisAlgViewModels
    {
        private ObservableCollection<Models.Przepis_alg> recipes;
        public ObservableCollection<Models.Przepis_alg> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public PrzepisAlgViewModels()
        {
            Recipes = new ObservableCollection<Models.Przepis_alg>();
        }

    }


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FindMeRecipePage : ContentPage
	{
        private bool BreakfastClicked;
        private bool DinnerClicked;
        private bool DessertClicked;

        private ListView listView;
        private ObservableCollection<Models.Przepis_alg> recipes;
        private PrzepisAlgViewModels viewModels;

        public FindMeRecipePage ()
		{
			InitializeComponent ();

            viewModels = new PrzepisAlgViewModels();

            listView = this.FindByName<ListView>("FavRecipesList");

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

        async void AddToFavourite_Clicked(object sender, EventArgs e)
        {
            MenuItem SelectedRecipe = ((MenuItem)sender);
            Przepis Fav = (Przepis)SelectedRecipe.CommandParameter;

            Ulubiony Favs = App.UlubionyRepo.GetAllUlubione().Where(u => u.Id_Przepisu == Fav.Id).FirstOrDefault();
            if (Favs != null)
                await DisplayAlert("Powiadomienie", "Ten przepis znajduje się już w ulubionych!", "OK");
            else
            {
                Ulubiony new_fav = App.UlubionyRepo.AddUlubiony();
                new_fav.Id_Przepisu = Fav.Id;
                App.UlubionyRepo.Update(new_fav);

                await DisplayAlert("Powiadomienie", "Dodano przepis do ulubionych!", "OK");
            }
        }

        private ObservableCollection<Przepis_alg> ReturnObservableCollection(List<Przepis_alg> l)
        {
            ObservableCollection<Przepis_alg> NewObCollection = new ObservableCollection<Przepis_alg>();
            foreach (Przepis_alg p in l)
                NewObCollection.Add(p);
            return NewObCollection;
        }

        async void ShowButton_Clicked(object sender, EventArgs e)
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

        private async void FindButton_Clicked(object sender, EventArgs e)
        {
            if (!BreakfastClicked && !DessertClicked && !DinnerClicked)
                await DisplayAlert("Hej!", "Nie wybrałeś czego szukasz.", "OK");
            else if (BreakfastClicked && !DessertClicked && !DinnerClicked)
            {
                Typ typ = App.Algorytm.SzukajTypu("Śniadanie");

                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis(typ);
                if(CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
            else if (!BreakfastClicked && !DessertClicked && DinnerClicked)
            {
                Typ typ = App.Algorytm.SzukajTypu("Obiad");

                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis(typ);
                if (CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
            else if (!BreakfastClicked && DessertClicked && !DinnerClicked)
            {
                Typ typ = App.Algorytm.SzukajTypu("Deser");

                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis(typ);
                if (CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
            else if (BreakfastClicked && !DessertClicked && DinnerClicked)
            {
                Typ typ = App.Algorytm.SzukajTypu("Śniadanie");
                Typ typ2 = App.Algorytm.SzukajTypu("Obiad");

                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis(typ, typ2);
                if (CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
            else if (BreakfastClicked && DessertClicked && !DinnerClicked)
            {
                Typ typ = App.Algorytm.SzukajTypu("Śniadanie");
                Typ typ2 = App.Algorytm.SzukajTypu("Deser");

                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis(typ, typ2);
                if (CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
            else if (!BreakfastClicked && DessertClicked && DinnerClicked)
            {
                Typ typ = App.Algorytm.SzukajTypu("Obiad");
                Typ typ2 = App.Algorytm.SzukajTypu("Deser");

                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis(typ, typ2);
                if (CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
            else
            {
                List<Przepis_alg> dt = App.Algorytm.SzukajPrzepis();
                if (CheckIfEmpty(dt)) await DisplayAlert("Hej!", "Twoja lodówka ma za mało produktów, aby znaleźć przepis.", "OK");
                dt = dt.OrderBy(o => o.Stosunek).ToList();

                recipes = ReturnObservableCollection(dt);
                viewModels.Recipes = recipes;
                BindingContext = viewModels;

                listView.ItemsSource = recipes;
            }
        }

        private bool CheckIfEmpty(List<Przepis_alg> ListToCheck)
        {
            if (ListToCheck.Count == 0)
                return true;
            else
                return false;
        }
    }
}