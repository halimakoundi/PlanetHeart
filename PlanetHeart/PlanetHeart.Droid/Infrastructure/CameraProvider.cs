using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Provider;
using Java.IO;
using PlanetHeart.Droid.Infrastructure;
using PlanetHeartPCL.Infrastructure;
using Xamarin.Forms;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(CameraProvider))]
namespace PlanetHeart.Droid.Infrastructure
{
    
    public class CameraProvider : ICameraProvider
    {
        private static File _file;
        private static File _pictureDirectory;

        private static TaskCompletionSource<CameraResult> _tcs;

        public Task<CameraResult> TakePictureAsync()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            _pictureDirectory = new File(Environment.GetExternalStoragePublicDirectory(Environment.DirectoryPictures), "CameraAppDemo");

            if (!_pictureDirectory.Exists())
            {
                _pictureDirectory.Mkdirs();
            }

            _file = new File(_pictureDirectory, $"photo_{Guid.NewGuid()}.jpg");

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));

            var activity = (Activity)Forms.Context;
            activity.StartActivityForResult(intent, 0);

            _tcs = new TaskCompletionSource<CameraResult>();

            return _tcs.Task;
        }

        public static void OnResult(Result resultCode)
        {
            if (resultCode == Result.Canceled)
            {
                _tcs.TrySetResult(null);
                return;
            }

            if (resultCode != Result.Ok)
            {
                _tcs.TrySetException(new Exception("Unexpected error"));
                return;
            }

            var res = new CameraResult
            {
                Picture = ImageSource.FromFile(_file.Path),
                FilePath = _file.Path
            };

            _tcs.TrySetResult(res);
        }
    }
}