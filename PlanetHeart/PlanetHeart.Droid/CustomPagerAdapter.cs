using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;
using PlanetHeart.Droid.Views;

namespace PlanetHeart.Droid
{
    public class CustomPagerAdapter : FragmentPagerAdapter
    {
        const int PAGE_COUNT = 3;
        private string[] tabTitles = { "Home","Add Item", "Favourites" };

        public CustomPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomPagerAdapter(Context context, FragmentManager fm) : base(fm)
        {
        }

        public override int Count => PAGE_COUNT;

        public override Fragment GetItem(int position)
        {
            if (position == 0)
            {
                return new HomeFragment();
            }
            return new AddItemFragment();
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(tabTitles)[position];
        }

    }
}