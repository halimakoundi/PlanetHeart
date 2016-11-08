using System;
using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class RewardPage : ContentPage
    {
        public RewardPage()
        {
            InitializeComponent();
        }

        async void OnDismissButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
    }


}