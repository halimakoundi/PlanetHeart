using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AwesomeJunkWS.Domain;
using AwesomeJunkWS.Presentation;
using Xamarin.Forms.Platform.Android;

namespace AwesomeJunkWS.Droid
{
    [Activity(Label = "Browse Items")]
    public class BrowseItems : ListActivity
    {
        private Items _items;
        readonly App _sharedApp = new App();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.BrowseItems);

            Button button = FindViewById<Button>(Resource.Id.getAllItems);
            button.Click += GetItemsAsync;
        }

        private async void GetItemsAsync(object sender, EventArgs eventArgs)
        {
            _items = await _sharedApp.GetItems();
            var items = _items.Select(item => new ItemMapper().Mapp(item)).ToList();
            ListAdapter = new ArrayAdapter<PresentationItem>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
    }
}