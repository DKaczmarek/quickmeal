using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using quickmeal.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace quickmeal
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPreview : ContentPage
    {
        private Product product;
        public ProductPreview(object product)
        {
            InitializeComponent();
            this.product = (Product)product;
        }
    }
}