using Android.Graphics;
using Android.OS;
using Java.IO;

namespace PlanetHeart.Droid.Views
{
    public static class Picture
    {
        public static File File;
        public static File Dir;
        public static Bitmap Bitmap;

        public static void CreateDirectory()
        {
            Picture.Dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "PlanetHeart");
            if (!Picture.Dir.Exists())
            {
                Picture.Dir.Mkdirs();
            }
        }
    }
}