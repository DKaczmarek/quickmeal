using System;
using System.Collections.Generic;
using System.Text;

namespace quickmeal.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public String Name { get; set; }
        public String Category { get; set; }
        public int Amount { get; set; } 
        public String Type { get; set; }
    }
}
