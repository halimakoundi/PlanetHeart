using System;
using Android.Content;
using PlanetHeartPCL.Presentation;

namespace PlanetHeart.Droid
{
    public class Navigator : INavigator
    {
        private readonly Context _context;

        public Navigator(Context context)
        {
            _context = context;
        }

        public void NavigateTo(Screen screen)
        {
            //var intent = new Android.Content.Intent(_context, typeof(RewardActivity));
            //intent.SetFlags(ActivityFlags.NewTask);
            //intent.AddFlags(ActivityFlags.NoHistory);

            //_context.StartActivity(intent);
        }
    }
}