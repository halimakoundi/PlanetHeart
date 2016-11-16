using Android.Graphics;
using Android.Media;

namespace PlanetHeart.Droid.Infrastructure
{
    public static class BitmapHelpers
    {
        public static Bitmap LoadBitmap(this string fileName)
        {
            var options = new BitmapFactory.Options { InJustDecodeBounds = false };

            return BitmapFactory.DecodeFile(fileName, options);
        }

        public static string CreateThumbnail(string sourceFile, int reqWidth, int reqHeight, string thumbnailPrefix = "")
        {
            var thumbnail = sourceFile.Replace(".jpg", $"_{thumbnailPrefix}thumb.jpg");

            var source = sourceFile.LoadBitmap();
            var target = ThumbnailUtils.ExtractThumbnail(source, reqWidth, reqHeight);
            using (var outStream = System.IO.File.Create(thumbnail))
            {
                if (thumbnail.ToLower().EndsWith("png"))
                    target.Compress(Bitmap.CompressFormat.Png, 100, outStream);
                else
                    target.Compress(Bitmap.CompressFormat.Jpeg, 95, outStream);
            }
            source.Recycle();
            target.Recycle();
            return thumbnail;
        }
    }
}