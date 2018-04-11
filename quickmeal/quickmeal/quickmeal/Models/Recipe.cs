using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public int TypeID { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Time { get; set; }
        public String ImageURL { get; set; }
    }
}
