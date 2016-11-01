using System;
using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class AddItemPage
    {
        private readonly App _app = (Xamarin.Forms.Application.Current as App);
        private bool _pictureHasBeenAdded;

        public AddItemPage()
        {
            InitializeComponent();
            _app.ShouldShowPicture += ShowImage;
            ItemPicture.GestureRecognizers.Add(new TapGestureRecognizer());
        }

        public void ShowImage(string filepath)
        {
            _pictureHasBeenAdded = true;
            ItemPicture.Source = ImageSource.FromFile(filepath);
            
            ItemPicture.BackgroundColor = Color.Aqua;
            ItemPicture.ScaleTo(2,250,null);

        }

        protected override void OnAppearing()
        {
            if (!_pictureHasBeenAdded)
            {
                OpenCameraForPicture();
            }
            base.OnAppearing();
        }

        private void TakePicture(object sender, EventArgs eventArgs)
        {
            OpenCameraForPicture();
        }

        private void OpenCameraForPicture()
        {
            _app.TakePicture();
        }
    }
}
