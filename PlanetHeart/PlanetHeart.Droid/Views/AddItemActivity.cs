using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using Uri = Android.Net.Uri;

namespace PlanetHeart.Droid.Views
{
    [Activity(Label = "Add Item")]
    public class AddItemActivity : Activity
    {
        private ImageView _imageView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var intent = new Intent(MediaStore.ActionImageCapture);
            Picture.File = new File(Picture.Dir, $"newgem_{Guid.NewGuid()}.jpg");

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(Picture.File));

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Uri.FromFile(Picture.File);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume too much memory 
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            //Picture.Bitmap = Picture.File.Path.LoadAndResizeBitmap(width, height);
            if (Picture.Bitmap != null)
            {
                _imageView.SetImageBitmap(Picture.Bitmap);
                Picture.Bitmap = null;
            }

            GC.Collect();
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}