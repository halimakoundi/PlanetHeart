using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class AddItemPage
    {
        private readonly App _app = (Xamarin.Forms.Application.Current as App);

        public AddItemPage()
        {
            InitializeComponent();
            
            _app.ShouldShowPicture += ShowImage;
            _app.TakePicture();
        }

        public void ShowImage(string filepath)
        {
            ItemPicture.Source = ImageSource.FromFile(filepath);
        }
    }
}
