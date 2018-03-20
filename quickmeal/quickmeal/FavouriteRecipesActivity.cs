using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace quickmeal
{
    [Activity(Label = "@string/favouriteViewTitle")]
    public class FavouriteRecipesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            // Create your application here
        }
    }
}