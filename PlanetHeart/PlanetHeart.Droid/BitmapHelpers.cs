using Android.Graphics;
using Android.Media;

namespace PlanetHeart.Droid
{
    public static class BitmapHelpers
    {
        public static Bitmap LoadBitmap(this string fileName)
        {
            var options = new BitmapFactory.Options { InJustDecodeBounds = false };

            return BitmapFactory.DecodeFile(fileName, options);
        }

        public static string CreateThumbnail(string sourceFile, int reqWidth, int reqHeight)
        {
            var thumbnail = sourceFile.Replace(".jpg", "_thumb.jpg");

            var target = ThumbnailUtils.ExtractThumbnail(sourceFile.LoadBitmap(), reqWidth, reqHeight);
            using (var outStream = System.IO.File.Create(thumbnail))
            {
                if (thumbnail.ToLower().EndsWith("png"))
                    target.Compress(Bitmap.CompressFormat.Png, 100, outStream);
                else
                    target.Compress(Bitmap.CompressFormat.Jpeg, 95, outStream);
            }
            target.Recycle();
            return thumbnail;
        }
    }
}