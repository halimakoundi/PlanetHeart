using PlanetHeartPCL.Pages;
using Xamarin.Forms;

namespace PlanetHeartPCL.Presentation
{
    public class Navigator : INavigator
    {
        private readonly INavigation _navigation;

        public Navigator(INavigation navigation)
        {
            _navigation = navigation;
        }

        public void NavigateTo(Screen screen)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _navigation.PushModalAsync(new RewardPage());
            });
        }
    }
}