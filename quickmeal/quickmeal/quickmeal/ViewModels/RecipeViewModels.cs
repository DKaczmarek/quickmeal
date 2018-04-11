using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace quickmeal.ViewModels
{
    public class RecipeViewModels
    {
        private ObservableCollection<Models.Recipe> recipes;
        public ObservableCollection<Models.Recipe> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public RecipeViewModels()
        {
            Recipes = new ObservableCollection<Models.Recipe>();
            MyDataSource.RecipeData _context = new MyDataSource.RecipeData();
            foreach (var recipe in _context.Recipes)
            {
                Recipes.Add(recipe);
            }
        }
    }
}
