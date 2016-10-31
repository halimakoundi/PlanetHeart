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
        }

        protected override void OnAppearing()
        {
            if (!_pictureHasBeenAdded)
            {
                _app.TakePicture();
            }
            base.OnAppearing();
        }

        public void ShowImage(string filepath)
        {
            _pictureHasBeenAdded = true;
            ItemPicture.Source = ImageSource.FromFile(filepath);
        }
    }
}
