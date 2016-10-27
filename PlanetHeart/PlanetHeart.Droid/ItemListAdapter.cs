using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using PlanetHeartPCL.Presentation;

namespace PlanetHeart.Droid
{
    public class ItemListAdapter : BaseAdapter<PresentationItem>
    {
        private readonly List<PresentationItem> _items;
        private readonly Activity _context;
        private View _view;

        public ItemListAdapter(Activity context, List<PresentationItem> items)
            : base()
        {
            _items = items;
            _context = context;
            _view = context.LayoutInflater.Inflate(Resource.Layout.PresentationItem, null);

        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override PresentationItem this[int position] => _items[position];
        public override int Count => _items.Count;

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];
            _view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.PresentationItem, null);

            var addedBy =  _view.FindViewById<TextView>(Resource.Id.Text1);
            addedBy.Text = item.AddedBy;
            var title = _view.FindViewById<TextView>(Resource.Id.Text2);
            title.Text = item.Title;
           // _view.FindViewById<ImageView>(Resource.Id.itemimage).SetImageResource(item.ImageResourceId);
            return _view;
        }
    }
}