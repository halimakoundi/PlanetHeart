using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace PlanetHeart.Droid
{
    [Activity(Label = "Planet Heart", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            Button openCamera = FindViewById<Button>(Resource.Id.openCamera);
            Button browse = FindViewById<Button>(Resource.Id.browseItems);
            openCamera.Click += TakeAPicture;
            browse.Click += BrowseItems;

        }

        private void BrowseItems(object sender, EventArgs eventArgs)
        {
            var second = new Intent(this, typeof(BrowseItemsActivity));
            second.PutExtra("FirstData", "Data from FirstActivity");
            StartActivity(second);

        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            var second = new Intent(this, typeof(TakePictureActivity));
            second.PutExtra("FirstData", "Data from FirstActivity");
            StartActivity(second);
        }
    }
}