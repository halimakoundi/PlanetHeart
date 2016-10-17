using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Infrastructure;

namespace PlanetHeart.Droid
{
    using Environment = Android.OS.Environment;
    using Uri = Android.Net.Uri;

    public static class Picture
    {
        public static File File;
        public static File Dir;
        public static Bitmap Bitmap;
    }

    [Activity(Label = "Awesome Junk")]
    public class TakePictureActivity : Activity
    {

        private ImageView _imageView;
        private TextView _label;
        private Button _saveButton;
        readonly ItemsGeteway _sharedItemsGeteway = new ItemsGeteway();
        private EditText _labelEditText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TakePicture);

            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                _label = FindViewById<TextView>(Resource.Id.itemLabelTextView);
                //_label.Visibility = Android.Views.ViewStates.Gone;

                _labelEditText = FindViewById<EditText>(Resource.Id.itemLabel);

                _saveButton = FindViewById<Button>(Resource.Id.saveItem);
                _saveButton.Visibility = Android.Views.ViewStates.Gone;

                Button takePictureBtn = FindViewById<Button>(Resource.Id.takePicture);
                takePictureBtn.Click += TakeAPicture;

                Button saveItemBtn = FindViewById<Button>(Resource.Id.saveItem);
                saveItemBtn.Click += SaveItem;

                _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            }

        }

        private async void SaveItem(object sender, EventArgs e)
        {
            var item = new Item(_labelEditText.Text);

            await _sharedItemsGeteway.SaveTodoItemAsync(item, true);
            new AlertDialog.Builder(this)
            .SetPositiveButton("OK", (senderBtn, args) =>
            {
                Finish();
            })
            .SetMessage("PresentationItem has been saved")
            .SetTitle("Thank you!")
            .Show();
            
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(Picture.File);
            mediaScanIntent.SetData(contentUri);
            SendBroadcast(mediaScanIntent);

            // Display in ImageView. We will resize the bitmap to fit the display
            // Loading the full sized image will consume too much memory 
            // and cause the application to crash.

            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            Picture.Bitmap = Picture.File.Path.LoadAndResizeBitmap(width, height);
            if (Picture.Bitmap != null)
            {
                _imageView.SetImageBitmap(Picture.Bitmap);
               // _label.Visibility = Android.Views.ViewStates.Visible;
                _saveButton.Visibility = Android.Views.ViewStates.Visible;
                Picture.Bitmap = null;
            }

            GC.Collect();
        }

        private void CreateDirectoryForPictures()
        {
            Picture.Dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "AwesomeJunk");
            if (!Picture.Dir.Exists())
            {
                Picture.Dir.Mkdirs();
            }
        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities =
                PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);

            Picture.File = new File(Picture.Dir, $"newgem_{Guid.NewGuid()}.jpg");

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(Picture.File));

            StartActivityForResult(intent, 0);
        }
    }
}