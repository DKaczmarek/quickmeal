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
    [Activity(Label = "@string/fridgeViewTitle")]
    public class FridgeViewActivity : Activity
    {
        private List<string> FridgeItems;
        private ListView mListView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Hide status bar
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            // Set our view from the "fridge" layout resource
            SetContentView(Resource.Layout.Fridge_x);

            // Create your application here
            EditText textEditor = (EditText)FindViewById(Resource.Id.textEditor);
            Button addButton = FindViewById<Button>(Resource.Id.addButton);
            mListView = FindViewById<ListView>(Resource.Id.fridgeListView); //fridgeListView jest zdefiniowane w Fridge.axml

            FridgeItems = new List<string>();
            FridgeItems.Add("Bekon"); FridgeItems.Add("Chleb"); FridgeItems.Add("Ser Feta"); FridgeItems.Add("Maslo");
            FridgeItems.Add("Pomidor"); FridgeItems.Add("Banan"); FridgeItems.Add("Jagody"); FridgeItems.Add("Ketchup");
            FridgeItems.Add("Truskawki"); FridgeItems.Add("Kiełbasa sucha krakowska"); FridgeItems.Add("Margaryna"); FridgeItems.Add("Szynka");
            FridgeItems.Add("Rzodkiewka"); FridgeItems.Add("Cebula"); FridgeItems.Add("Ser Gouda"); FridgeItems.Add("Oscypek");
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleExpandableListItem1, FridgeItems);
            mListView.Adapter = adapter;

            addButton.Click += (sender, e) =>
            {
                string text = textEditor.Text.ToString();
                if (text != "" && text != " ")
                {
                    adapter.Add(text);
                    mListView.Adapter = adapter;
                }
            };
            
        }
    }
}