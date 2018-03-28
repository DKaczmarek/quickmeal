using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
namespace quickmeal
{
    [Activity(Label = "@string/favRecipePreviewTitle")]
    public class RecipePreview : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            // Set our view from the "fridge" layout resource
            SetContentView(Resource.Layout.FavRecipePreview);

            initLayout();
            initTextViews();
        }

        // initialize childrens
        private void initTextViews()
        {
            // find object in layout by id
            TextView recipeNameTextField = FindViewById<TextView>(Resource.Id.recipeName);
            TextView recipeDesc = FindViewById<TextView>(Resource.Id.recipeDesc);

            recipeNameTextField.Text = Intent.GetStringExtra("itemInfo") ?? "Brak";      // wyświetlany tekst
            recipeNameTextField.TextSize = 30;                                           // wielkość czcionki
            recipeNameTextField.Gravity = GravityFlags.CenterHorizontal;                 // wyrównanie
            recipeNameTextField.SetBackgroundColor(Color.Rgb(255, 179, 102));            // kolor tła
            recipeNameTextField.SetTextColor(Color.Rgb(77, 37, 0));                      // kolor tekstu
            recipeNameTextField.SetPadding(10, 30, 10, 30);                              // odległość od granic obiektu

            recipeDesc.Text = Intent.GetStringExtra("desc") ?? "Brak";
            recipeDesc.TextSize = 15;
            recipeDesc.Gravity = GravityFlags.Fill;
            recipeDesc.SetBackgroundColor(Color.Rgb(255, 190, 125));
            recipeDesc.SetTextColor(Color.Rgb(77, 37, 0));
        }

        private void initLayout()
        {
            // find object in layout by id
            LinearLayout lLayout = FindViewById<LinearLayout>(Resource.Id.FRPLayout);
            lLayout.SetBackgroundColor(Color.Rgb(255, 190, 125));
        }

    }
}