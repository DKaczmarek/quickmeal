using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace quickmeal.ViewModels
{
    class PrzepisViewModels
    {
        private ObservableCollection<Models.Przepis> recipes;
        public ObservableCollection<Models.Przepis> Recipes
        {
            get { return recipes; }
            set { recipes = value; }
        }

        public PrzepisViewModels()
        {
            Recipes = new ObservableCollection<Models.Przepis>();
            MyDataSource.PrzepisData _context = new MyDataSource.PrzepisData();
            foreach (var recipe in _context.Recipes)
            {
                Recipes.Add(recipe);
            } 
        }
    }
}
