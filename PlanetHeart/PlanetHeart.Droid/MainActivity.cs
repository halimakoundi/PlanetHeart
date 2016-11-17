using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using PlanetHeart.Droid.Views;

namespace PlanetHeart.Droid
{
    [Activity(Label = "PlanetHeart",Icon="@drawable/icon", Theme = "@style/PlanetHeartTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            SetTabLayoutWith(ViewPager());

            SetToolbar();
        }

        private void SetToolbar()
        {
            var toolbar = (Toolbar) FindViewById(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
        }

        private void SetTabLayoutWith(ViewPager pager)
        {
            var tabLayout = FindViewById<TabLayout>(Resource.Id.tabs);
            tabLayout.SetupWithViewPager(pager);
        }

        private ViewPager ViewPager()
        {
            var pager = FindViewById<ViewPager>(Resource.Id.pager);
            var adapter = new CustomPagerAdapter(this, SupportFragmentManager);
            pager.Adapter = adapter;
            return pager;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            var inflater = MenuInflater;
            inflater.Inflate(Resource.Menu.MainTopMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

    }
}

