using System;
using System.IO;
using System.Net.Http;
using Android.Content;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Infrastructure;
using PlanetHeartPCL.Presentation;
using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class AddItemPage: IAddItemView
    {
        private const string EmptyStar = "ic_star_border";
        private const string FullStar = "ic_star";
        private readonly App _app = (Application.Current as App);
        private bool _openCameraOnAppearing=true;
        private readonly AddItemPresenter _presenter;
        private StreamContent _pictureStream;

        public AddItemPage()
        {
            InitializeComponent();
            _app.ShouldShowPicture += ShowImage;
            _app.NoPicture += NoPictureTaken;
            _app.ShouldSetPictureStream += SetPictureStream;
            ItemPicture.GestureRecognizers.Add(new TapGestureRecognizer());
            _presenter = new AddItemPresenter(new AddItemInteractor(this, new ItemsGateway()),new Executor(), new Navigator(Navigation) );
        }

        private void SetPictureStream(StreamContent stream)
        {
            _pictureStream = stream;
        }

        public void ShowImage(string filepath)
        {
            _openCameraOnAppearing = false;
            ItemPicture.Source = ImageSource.FromFile(filepath);
        }

        public void NoPictureTaken()
        {
            _openCameraOnAppearing = false;
            Navigation.PopAsync();
        }

        public Item RetrieveItem()
        {
            
            return new Item(Type.Text)
            {
                Description = Description.Text,
                PostCode = PostCode.Text,
                Picture = "image_placeholder.png",
                Condition = ItemCondition.VeryGood,
                PictureStream = _pictureStream
            };
        }

        protected override void OnAppearing()
        {
            if (_openCameraOnAppearing)
            {
           //     OpenCameraForPicture();
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

        private void ToggleStar(object sender, EventArgs eventArgs)
        {
            var ratingStar = (Image) sender;

            ratingStar.Source = ((FileImageSource)ratingStar.Source).File == EmptyStar ? FullStar : EmptyStar;
        }

        private void AddItem(object sender, EventArgs eventArgs)
        {
            _presenter.OnAddItemButtonClicked();
        }

    }
}
