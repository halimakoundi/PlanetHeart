using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;

namespace PlanetHeart.Droid.Views
{

    public class HomeFragment : Fragment, IBrowserView
    {
        public ObservableCollection<PresentationItem> Items { get; set; }
        private ListView _listView;
        private HomePagePresenter _presenter;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _presenter = new HomePagePresenter(new GetItemsInteractor(new ItemsGateway()), new Executor(), this,
                new ItemMapper());
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.HomeFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            _listView = Activity.FindViewById<ListView>(Resource.Id.List);
            Items = new ObservableCollection<PresentationItem>
            {
                new PresentationItem("Coffee table", "A Kitten", "image_placeholder.png"),
                new PresentationItem("Office Chair", "John Doe", "image_placeholder.png")
            };
            _listView.Adapter = new ItemListAdapter(Activity, Items);

            _presenter.OnViewReady();
        }

        public void Display(List<PresentationItem> presentationItems)
        {
            Activity.RunOnUiThread(() =>
            {
                if (presentationItems != null && presentationItems.Count > 0)
                {
                    _listView.Adapter = new ItemListAdapter(Activity, presentationItems);
                }
            });
        }
        
    }
}