using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using PlanetHeart.Droid.Views;

namespace PlanetHeart.Droid
{
    [Activity(Label = "PlanetHeart",Icon="@drawable/icon", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var pager = FindViewById<ViewPager>(Resource.Id.pager);
            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            var adapter = new CustomPagerAdapter(this, SupportFragmentManager);
            
            pager.Adapter = adapter;
            tabLayout.SetupWithViewPager(pager);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.MainTopMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }



    }
}

