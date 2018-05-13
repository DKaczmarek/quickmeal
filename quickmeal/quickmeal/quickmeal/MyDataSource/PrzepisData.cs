using quickmeal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.MyDataSource
{
    class PrzepisData
    {
        public List<Przepis> Recipes = new List<Przepis>();
        public PrzepisData()
        {
            Recipes = App.PrzepisRepo.GetAllPrzepis();
        }

    }
}
