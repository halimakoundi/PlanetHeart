using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace PlanetHeart.Droid.Views
{
    [Activity(Label = "RewardActivity")]
    public class RewardActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Reward);

            Button saveItemBtn = FindViewById<Button>(Resource.Id.backToHome);
            saveItemBtn.Click += OnAddItemButtonClicked;
        }

        private void OnAddItemButtonClicked(object sender, EventArgs e)
        {
            var intent = new Android.Content.Intent(this, typeof(MainActivity));

            StartActivity(intent);
        }
    }
}