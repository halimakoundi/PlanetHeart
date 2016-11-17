using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;

namespace PlanetHeart.Droid.Views
{
    public class CustomPagerAdapter : FragmentPagerAdapter
    {
        private readonly string[] _tabTitles = { "Home", "Favourites" };
        private readonly Fragment[] _tabs = { new HomeFragment(), new FavouritsFragment() };
        private const int PAGE_COUNT = 2;

        public CustomPagerAdapter(Context context, FragmentManager fragmentManager):base(fragmentManager)
        {
        }

        public override int Count => PAGE_COUNT;
        public override Fragment GetItem(int position)
        {
            return _tabs[position]; 
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(_tabTitles)[position];
        }
    }
}