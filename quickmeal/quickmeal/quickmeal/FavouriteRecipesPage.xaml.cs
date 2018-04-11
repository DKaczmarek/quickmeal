﻿using quickmeal.Models;
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
        private ObservableCollection<Models.Recipe> recipes;

        public FavouriteRecipesPage ()
		{
            InitializeComponent();

            ViewModels.RecipeViewModels viewModels = new ViewModels.RecipeViewModels();
            BindingContext = viewModels;
            recipes = viewModels.Recipes;

            listView = this.FindByName<ListView>("FavRecipesList");
        }

        private void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
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

        private void OnSearchButtonPressed(object sender, EventArgs e)
        {
            Entry searchBar = this.FindByName<Entry>("FavRecipesSearchBar");
            string keyword = searchBar.Text;

            IEnumerable<Recipe> searchResult = recipes.Where(
                r => r.Name.ToLower().Contains(keyword.ToLower())
                );

            listView.ItemsSource = searchResult;
        }
    }
}