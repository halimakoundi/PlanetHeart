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
        private readonly string[] _tabTitles = { "Home", "Add Item", "Favourites" };
        private AddItemFragment _addItemFragment;

        public CustomPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomPagerAdapter(Context context, FragmentManager fm) : base(fm)
        {
        }

        public override int Count => PAGE_COUNT;

        public override Fragment GetItem(int position)
        {
            if (position == 1)
            {
                return _addItemFragment ?? (_addItemFragment = new AddItemFragment());
            }
            return new HomeFragment();
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(_tabTitles)[position];
        }

    }
}