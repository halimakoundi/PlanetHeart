using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Java.IO;
using Uri = Android.Net.Uri;

namespace PlanetHeart.Droid.Views
{
    [Activity(Label = "CameraWrapper")]
    public class CameraWrapper : Activity
    {
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
            base.OnActivityResult(requestCode, resultCode, data);

            var addItemActivity = new Intent(this, typeof(AddItemActivity));
            StartActivity(addItemActivity);
        }
    }
}