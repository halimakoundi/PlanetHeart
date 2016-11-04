using System;
using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class AddItemPage
    {
        private readonly App _app = (Xamarin.Forms.Application.Current as App);
        private bool _openCameraOnAppearing=true;

        public AddItemPage()
        {
            InitializeComponent();
            _app.ShouldShowPicture += ShowImage;
            _app.NoPicture += NoPictureTaken;
            ItemPicture.GestureRecognizers.Add(new TapGestureRecognizer());
        }

        public void ShowImage(string filepath)
        {
            _openCameraOnAppearing = false;
            ItemPicture.Source = ImageSource.FromFile(filepath);
        }

        public void NoPictureTaken()
        {
            _openCameraOnAppearing = false;
            var homePage = Navigation.NavigationStack[0];
            Navigation.PushModalAsync(new MainPage());
        }

        protected override void OnAppearing()
        {
            if (_openCameraOnAppearing)
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
