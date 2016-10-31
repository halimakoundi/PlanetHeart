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

        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            (Xamarin.Forms.Application.Current as App).ShouldTakePicture += () => {
                var intent = new Intent(MediaStore.ActionImageCapture);
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(File));
                StartActivityForResult(intent, 0);
            };
        }
    }
}