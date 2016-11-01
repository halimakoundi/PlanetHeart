﻿using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Java.IO;
using PlanetHeartPCL;
using Xamarin.Forms.Platform.Android;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using Android.Media;

namespace PlanetHeart.Droid
{

    [Activity(Label = "PlanetHeart", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
          Theme = "@style/AppTheme")]
    public class MainActivity : FormsAppCompatActivity
    {
        private App _app;
        private File _file;
        private File _dir;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            InitialiseApplication(bundle);

            CreateDirectoryForPictures();

            _app.ShouldTakePicture += () =>
            {
                var intent = new Intent(MediaStore.ActionImageCapture);
                _file = new File(_dir, $"myPhoto_{Guid.NewGuid()}.jpg");
                intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(_file));
                StartActivityForResult(intent, 0);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {

            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            var contentUri = Uri.FromFile(_file);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            var thumbnail = BitmapHelpers.CreateThumbnail(_file.Path, 350, 350);

            _app.ShowPicture(thumbnail);

            base.OnActivityResult(requestCode, resultCode, data);
        }

        private void InitialiseApplication(Bundle bundle)
        {
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            _app = (Xamarin.Forms.Application.Current as App);
        }

        private void CreateDirectoryForPictures()
        {
            _dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "PlanetHeart");
            if (!_dir.Exists())
            {
                _dir.Mkdirs();
            }
        }
    }
}