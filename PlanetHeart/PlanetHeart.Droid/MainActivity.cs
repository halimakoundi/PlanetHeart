using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Java.IO;
using PlanetHeartPCL;
using Xamarin.Forms.Platform.Android;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace PlanetHeart.Droid
{

    [Activity(Label = "PlanetHeart", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
          Theme = "@style/AppTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        private static  File _file = new File(Environment.GetExternalStoragePublicDirectory(
                                Environment.DirectoryPictures), "tmp.jpg");

        private App _app;
        private File _dir;

        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            _app = (Xamarin.Forms.Application.Current as App);
            CreateDirectoryForPictures();

            _app.ShouldTakePicture += () =>
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);
            _file = new File(_dir, $"myPhoto_{Guid.NewGuid()}.jpg");
            _app.ShowPicture(_file.AbsolutePath);
            //_app.ShowPicture("ic_photo.png");
            base.OnActivityResult(requestCode, resultCode, data);
        }
        private void CreateDirectoryForPictures()
        {
            _dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "CameraAppDemo");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }
    }
}