using System;
using Android.Support.V4.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Java.IO;
using PlanetHeart.Droid.Infrastructure;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;
using Uri = Android.Net.Uri;

namespace PlanetHeart.Droid.Views
{
    public class AddItemFragment : Fragment, IAddItemView
    {
        private EditText _labelEditText;
        private Button _saveButton;
        private AddItemPresenter _presenter;
        private ImageView _imageView;

        public override void OnCreate(Bundle savedInstanceState)
        {
            InitialisePresenter();
            base.OnCreate(savedInstanceState);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            InitialiseViewElements();
            InitialiseElementsForTakingAPicture();
            base.OnViewCreated(view, savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.TakePicture, container, false);
        }

        public Item RetrieveItem()
        {
            return new Item(_labelEditText.Text);
        }

        public override void OnActivityResult(int requestCode, int resultCode, Intent data)
        {
            Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            Uri contentUri = Uri.FromFile(Picture.File);
            mediaScanIntent.SetData(contentUri);
            Activity.SendBroadcast(mediaScanIntent);
            ResizePicture();
            SetImageSource();

            base.OnActivityResult(requestCode, resultCode, data);
        }

        private void SetImageSource()
        {
            if (Picture.Bitmap != null)
            {
                _imageView.SetImageBitmap(Picture.Bitmap);
                _saveButton.Visibility = Android.Views.ViewStates.Visible;
                Picture.Bitmap = null;
            }
            GC.Collect();
        }

        private void ResizePicture()
        {
            int height = Resources.DisplayMetrics.HeightPixels;
            int width = _imageView.Height;
            Picture.Bitmap = Picture.File.Path.LoadBitmap();
        }

        private void OnAddItemButtonClicked(object sender, EventArgs e)
        {
            _presenter.OnAddItemButtonClicked();
        }

        private void InitialiseViewElements()
        {
            _labelEditText = Activity.FindViewById<EditText>(Resource.Id.itemLabel);
            _saveButton = Activity.FindViewById<Button>(Resource.Id.saveItem);
            _saveButton.Click += OnAddItemButtonClicked;
        }

        private void InitialisePresenter()
        {
            _presenter = new AddItemPresenter(new AddItemInteractor(this, new ItemsGateway()),
                new Executor(),
                new Navigator(Activity.ApplicationContext));
        }

        private void InitialiseElementsForTakingAPicture()
        {
            if (!IsCameraAppAvailable()) return;
            Picture.CreateDirectory();

            var takePictureBtn = Activity.FindViewById<Button>(Resource.Id.takePicture);
            takePictureBtn.Click += TakeAPicture;

            _imageView = Activity.FindViewById<ImageView>(Resource.Id.imageView1);
        }

        private bool IsCameraAppAvailable()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            var availableActivities =
                Activity.PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);

            return availableActivities != null && availableActivities.Count > 0;
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(MediaStore.ActionImageCapture);

            Picture.File = new File(Picture.Dir, $"newgem_{Guid.NewGuid()}.jpg");

            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(Picture.File));

            StartActivityForResult(intent, 0);
        }

    }
}