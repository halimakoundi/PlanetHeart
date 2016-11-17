using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using PlanetHeartPCL.Presentation;

namespace PlanetHeart.Droid.Views
{
    public class ItemListAdapter : BaseAdapter<PresentationItem>
    {
        private readonly List<PresentationItem> _items;
        private readonly Activity _context;

        public ItemListAdapter(Activity context, IEnumerable<PresentationItem> items)
        {
            _context = context;
            _items = items.ToList();
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
            var view = convertView ?? _context.LayoutInflater.Inflate(Resource.Layout.ItemRow, null);

            view.FindViewById<TextView>(Resource.Id.UserName).Text = item.AddedBy;
            view.FindViewById<TextView>(Resource.Id.ItemType).Text = item.Title;
            view.FindViewById<ImageView>(Resource.Id.ItemPicture).SetImageURI(Android.Net.Uri.Parse(item.ImageUrl));

            return view;
        }
    }
}
