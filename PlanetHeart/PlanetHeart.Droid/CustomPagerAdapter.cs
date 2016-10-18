using System;
using Android.Content;
using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;

namespace PlanetHeart.Droid
{
    public class CustomPagerAdapter : FragmentPagerAdapter
    {
        const int PAGE_COUNT = 2;
        private string[] tabTitles = { "Home", "Favourits" };
        readonly Context context;

        public CustomPagerAdapter(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public CustomPagerAdapter(Context context, FragmentManager fm) : base(fm)
        {
            this.context = context;
        }

        public override int Count
        {
            get { return PAGE_COUNT; }
        }

        public override Fragment GetItem(int position)
        {
            return new HomeFragment();
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            // Generate title based on item position
            return CharSequence.ArrayFromStringArray(tabTitles)[position];
        }

    }
}