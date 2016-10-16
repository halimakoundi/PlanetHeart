using System.Collections.Generic;
using Android.App;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using PlanetHeart.Presentation;

namespace PlanetHeart.Droid
{
    public class ItemListAdapter : BaseAdapter<PresentationItem>
    {
        List<PresentationItem> items;
        Activity context;
        public ItemListAdapter(Activity context, List<PresentationItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override PresentationItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            //if (view == null) // no view to re-use, create new
            //    view = context.LayoutInflater.Inflate(Resource.Layout.ItemRow, null);
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item.AddedBy;
            view.FindViewById<TextView>(Android.Resource.Id.Text2).Text = item.Title;
            //view.FindViewById<ImageView>(Android.Resource.Id.ItemImage).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}