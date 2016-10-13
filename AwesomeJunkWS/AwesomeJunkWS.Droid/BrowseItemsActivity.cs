using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using AwesomeJunkWS.Domain;
using AwesomeJunkWS.Presentation;

namespace PlanetHeart.Droid
{
    [Activity(Label = "Browse Items")]
    public class BrowseItemsActivity : ListActivity, IBrowserView
    {
        private BrowseItemsPresenter _presenter ;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _presenter = new BrowseItemsPresenter(new GetItemsInteractor(), new Executor(), this);

            SetContentView(Resource.Layout.BrowseItems);

            Button button = FindViewById<Button>(Resource.Id.getAllItems);
            button.Click += (sender, eventArgs) =>
            {
                _presenter.GetItemsButtonClicked();
            };
        }

        public void Display(List<PresentationItem> items)
        {
            ListAdapter = new ArrayAdapter<PresentationItem>(this, Android.Resource.Layout.SimpleListItem1, items); ;
        }
    }
}