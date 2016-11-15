using System;
using System.Net.Http;
using PlanetHeartPCL.Pages;
using Xamarin.Forms;

namespace PlanetHeartPCL
{
    public class App : Application
    {
        public event Action ShouldTakePicture = () => { };
        public event Action NoPicture = () => { };
        public event Action<string> ShouldShowPicture = (filepath) => { };
        public event Action<StreamContent> ShouldSetPictureStream = (filestream) => { };

        public App()
        {
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void TakePicture()
        {
            ShouldTakePicture();
        }

        public void ShowPicture(string filepath)
        {
            ShouldShowPicture(filepath);
        }

        public virtual void OnNoPicture()
        {
            NoPicture();
        }

        public void SetPictureStream(StreamContent streamContent)
        {
            ShouldSetPictureStream(streamContent);
        }

    }
}
