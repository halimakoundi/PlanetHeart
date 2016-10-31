using Android.Graphics;

namespace PlanetHeart.Droid
{
    public static class BitmapHelpers
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            var options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            var outWidth = options.OutWidth;
            var inSampleSize = 1;
            inSampleSize = outWidth / width;
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;

            return BitmapFactory.DecodeFile(fileName, options);
        }
    }
}