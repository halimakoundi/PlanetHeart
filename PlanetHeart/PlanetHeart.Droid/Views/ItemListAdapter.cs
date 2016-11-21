using System.Collections.Generic;
using System.Linq;
using System.Net;
using Android.App;
using Android.Graphics;
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
            if (RemoteFileExists(item.ImageUrl))
            {
                view.FindViewById<ImageView>(Resource.Id.ItemPicture).SetImageBitmap(GetImageBitmapFromUrl(item.ImageUrl));
            }

            return view;
        }

        private static Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        private static bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                var response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }
    }
}
