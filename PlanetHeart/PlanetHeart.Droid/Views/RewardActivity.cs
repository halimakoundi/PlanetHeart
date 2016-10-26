using Android.App;
using Android.OS;

namespace PlanetHeart.Droid.Views
{
    [Activity(Label = "RewardActivity")]
    public class RewardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Reward);
        }

    }
}