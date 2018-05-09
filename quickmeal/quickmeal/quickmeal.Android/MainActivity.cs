using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite.Net.Platform.XamarinAndroid;
namespace quickmeal.Droid
{
    [Activity(Label = "quickmeal", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static SQLitePlatformAndroid platformAndroid = new SQLitePlatformAndroid();
        public static string dbPath = FileAccesHelper.GetLocalFilePath("quickmeal.db3");
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            string dbPath = FileAccesHelper.GetLocalFilePath("quickmeal.db3");
            LoadApplication(new quickmeal.App(dbPath, platformAndroid));
        }
    }
}

