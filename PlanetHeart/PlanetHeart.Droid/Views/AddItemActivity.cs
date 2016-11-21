using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using PlanetHeart.Droid.Infrastructure;

namespace PlanetHeart.Droid.Views
{
    [Activity(Label = "Add Item", Theme = "@style/PlanetHeartTheme")]
    public class AddItemActivity : Activity
    {
        private ImageView _imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddItem);

            _imageView = FindViewById<ImageView>(Resource.Id.ItemPicture);
            SetImage();
        }

        private void SetImage()
        {

            if (Picture.File.Path != null)
            {
                var thumbnail = BitmapHelpers.CreateThumbnail(Picture.File.Path, 500, 500);
                var bitmap = BitmapFactory.DecodeFile(thumbnail);
                _imageView.SetImageBitmap(bitmap);

                Picture.Bitmap = null;
            }
            GC.Collect();
        }


    }
}