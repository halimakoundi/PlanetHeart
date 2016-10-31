using System.Collections.Generic;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;

namespace PlanetHeart.Droid.Views
{
    public class HomeFragment : Fragment, IBrowserView
    {
        private HomePagePresenter _presenter;
        private ListView _listView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _presenter = new HomePagePresenter(new GetItemsInteractor( new ItemsGateway()), new Executor(), this, new ItemMapper());
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.HomeFragment, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            _listView = view.FindViewById<ListView>(Resource.Id.list);
            _presenter.OnViewReady();
        }

        public void Display(List<PresentationItem> items)
        {
            _listView.Adapter = new ItemListAdapter(Activity, items);
        }
    }
}