using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.App;
using Android.OS;
using PlanetHeart.Droid.Views;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;
using Xamarin.Forms;
using ListView = Android.Widget.ListView;

namespace PlanetHeart.Droid
{
    [Activity(Label = "PlanetHeart", MainLauncher = true)]
    public class MainActivity : Activity, IBrowserView
    {
        private ListView _listView;
        private ObservableCollection<PresentationItem> Items { get; set; }
        private HomePagePresenter _presenter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);
            _listView = FindViewById<ListView>(Resource.Id.List);
            Items = new ObservableCollection<PresentationItem>
                        {
                            new PresentationItem("Coffee table", "A Kitten", "image_placeholder.png"),
                            new PresentationItem("Office Chair", "John Doe", "image_placeholder.png")
                        };
            _listView.Adapter = new ItemListAdapter(this, Items);

            _presenter = new HomePagePresenter(new GetItemsInteractor(new ItemsGateway()), new Executor(), this, new ItemMapper());
            _presenter.OnViewReady();

        }

        public void Display(List<PresentationItem> presentationItems)
        {
           RunOnUiThread(() =>
            {
                if (presentationItems != null && presentationItems.Count > 0)
                {
                    _listView.Adapter = new ItemListAdapter(this, presentationItems);
                }
            });
        }
    }
}

