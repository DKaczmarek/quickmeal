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
    public class FavouriteRecipesActivity : ListActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            // Create list
            string[] recipes = Resources.GetStringArray(Resource.Array.favRecipesArray);
            ListAdapter = new ArrayAdapter<string>(this, Resource.Layout.FavRecipe, recipes);
            ListView.TextFilterEnabled = true;

            ListView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs args)
            {
                Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Short).Show();

                var intent = new Intent(this, typeof(RecipePreview));
                intent.PutExtra("itemInfo", ((TextView)args.View).Text);
                intent.PutExtra("desc", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                    "Nulla eget aliquet libero. Nam quis augue id diam vulputate bibendum. Nulla a fermentum leo. " +
                    "Vestibulum nec mauris purus. Nulla elementum tortor vel justo consequat tincidunt. Mauris at " +
                    "varius lectus, tincidunt rutrum orci. Quisque lobortis tincidunt mattis. Etiam vel sagittis e" +
                    "x, in pulvinar ipsum. Quisque eget imperdiet sapien, non rutrum massa. Interdum et malesuada " +
                    "fames ac ante ipsum primis in faucibus. Curabitur sapien lorem, lobortis eu felis sit amet, se" +
                    "mper condimentum leo. Sed interdum purus ut nunc pellentesque, at congue nisi cursus. Integer " +
                    "ac quam at ipsum commodo hendrerit. Morbi est eros, mollis a bibendum sit amet, accumsan at ma" +
                    "uris. In congue libero aliquet placerat hendrerit.");
                intent.PutExtra("imageURL", "http://meatmyday.pl/wp-content/uploads/2016/12/Idealny-kurczak-pieczony-w-ca%C5%82o%C5%9Bci-1.jpg");

                StartActivity(intent);
            };
        }

    }
}