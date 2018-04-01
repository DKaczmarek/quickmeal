using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;

namespace quickmeal
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Register buttons
            Button FavouriteViewButton = FindViewById<Button>(Resource.Id.favouriteViewButton);
            Button ShowFridgeButton = FindViewById<Button>(Resource.Id.showFridgeButton);
            Button RecipeForNowButton = FindViewById<Button>(Resource.Id.recipefornowButton);
            
            // add action to buttons
            ShowFridgeButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FridgeViewActivity));
                StartActivity(intent);
            };

            RecipeForNowButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(RecipeActivity));
                StartActivity(intent);
            };

            FavouriteViewButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(FavouriteRecipesActivity));
                StartActivity(intent);
            };

        }
    }
}

