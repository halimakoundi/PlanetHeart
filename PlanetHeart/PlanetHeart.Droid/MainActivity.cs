using Android.App;
using Android.Content.PM;
using Android.OS;
using PlanetHeartPCL;
using Xamarin.Forms.Platform.Android;

namespace PlanetHeart.Droid
{
    
    [Activity(Label = "PlanetHeart", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
          Theme = "@style/AppTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}