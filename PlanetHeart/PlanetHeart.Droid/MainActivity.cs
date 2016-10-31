using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Provider;
using Java.IO;
using PlanetHeartPCL;
using Xamarin.Forms.Platform.Android;

namespace PlanetHeart.Droid
{

    [Activity(Label = "PlanetHeart", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
          Theme = "@style/AppTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        private static readonly File File = new File(Environment.GetExternalStoragePublicDirectory(
                                Environment.DirectoryPictures), "tmp.jpg");

        private App _app;

        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            _app = (Xamarin.Forms.Application.Current as App);

            _app.ShouldTakePicture += () =>
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(File));
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Uri.FromFile(File);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

           // _app.ShowPicture(File.Path);
            _app.ShowPicture("ic_photo.png");
            base.OnActivityResult(requestCode, resultCode, data);
        }
    }
}