using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.IO;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;
using Uri = Android.Net.Uri;

namespace PlanetHeart.Droid.Views
{

    public class HomeFragment : Fragment, IBrowserView, View.IOnClickListener
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
            var fab1 = (FloatingActionButton)view.FindViewById(Resource.Id.fab_1);
            fab1.SetOnClickListener(this);

            _listView = Activity.FindViewById<ListView>(Resource.Id.List);
            Items = new ObservableCollection<PresentationItem>
            {
                new PresentationItem("Coffee table", "A Kitten", "image_placeholder.png"),
                new PresentationItem("Office Chair", "John Doe", "image_placeholder.png")
            };
            _listView.Adapter = new ItemListAdapter(Activity, Items);

            Picture.CreateDirectory();

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

        public void OnClick(View v)
        {
            var intent = new Intent(Activity, typeof(CameraWrapper));
            StartActivity(intent);
        }
    }
}