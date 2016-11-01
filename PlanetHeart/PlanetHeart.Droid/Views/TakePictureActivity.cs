using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Widget;
using Java.IO;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;
using Picture = PlanetHeart.Droid.Infrastructure.Picture;

namespace PlanetHeart.Droid.Views
{
    using Environment = Android.OS.Environment;
    using Uri = Android.Net.Uri;


    [Activity(Label = "PlanetHeart")]
    public class TakePictureActivity : Activity, IAddItemView
    {

        private ImageView _imageView;
        private Button _saveButton;
        readonly ItemsGateway _sharedItemsGateway = new ItemsGateway();
        private EditText _labelEditText;
        private AddItemPresenter _presenter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.TakePicture);

           // _presenter = new AddItemPresenter(new AddItemInteractor(this, new ItemsGateway()),
           //                                     new Executor(),
             //                                   new Navigator());
            if (IsThereAnAppToTakePictures())
            {
                CreateDirectoryForPictures();

                _labelEditText = FindViewById<EditText>(Resource.Id.itemLabel);

                _saveButton = FindViewById<Button>(Resource.Id.saveItem);
                _saveButton.Visibility = Android.Views.ViewStates.Gone;

                Button takePictureBtn = FindViewById<Button>(Resource.Id.takePicture);
                takePictureBtn.Click += TakeAPicture;

                Button saveItemBtn = FindViewById<Button>(Resource.Id.saveItem);
                saveItemBtn.Click += OnAddItemButtonClicked;

                _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            }

        }

        private void OnAddItemButtonClicked(object sender, EventArgs e)
        {
            _presenter.OnAddItemButtonClicked();
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
            Picture.Bitmap = Picture.File.Path.LoadBitmap();
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

        public Item RetrieveItem()
        {
            return new Item(_labelEditText.Text);
        }
    }
}