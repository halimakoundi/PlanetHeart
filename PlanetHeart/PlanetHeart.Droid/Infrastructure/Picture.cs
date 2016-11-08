using Android.Graphics;
using Android.OS;
using Java.IO;

namespace PlanetHeart.Droid.Infrastructure
{
    public static class Picture
    {
        public static File File;
        public static File Dir;
        public static Bitmap Bitmap;

        public static void CreateDirectory()
        {
            Dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "PlanetHeart");
            if (!Dir.Exists())
            {
                Dir.Mkdirs();
            }
        }
    }
}