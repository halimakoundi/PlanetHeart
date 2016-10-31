using System;
using System.Collections.ObjectModel;
using System.Linq;
using PlanetHeartPCL.Presentation;
using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class HomePage : BaseContentPage
    {
        public static ObservableCollection<PresentationItem> Items { get; set; }
        public HomePage()
        {
            Items = new ObservableCollection<PresentationItem>
                        {
                            new PresentationItem("Coffee table", "A Kitten", "image_placeholder.png"),
                            new PresentationItem("Office Chair", "John Doe", "image_placeholder.png")
                        };
            InitializeComponent();
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (ItemIsBeingDesected(e))
            {
                return;
            }
            var lst = (ListView)sender;
            lst.SelectedItem = null;
        }

        private static bool ItemIsBeingDesected(SelectedItemChangedEventArgs e)
        {
            return e.SelectedItem == null;
        }

        public void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            var itemList = Items.Reverse().ToList();
            Items.Clear();
            foreach (var s in itemList)
            {
                Items.Add(s);
            }
            EndRefreshState(list);
        }

        private static void EndRefreshState(ListView list)
        {
            list.IsRefreshing = false;
        }

        public void OnTap(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }

        private void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        private void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;

            DisplayAlert("Item to delete ", item.ToString(), "Ok");
        }

    }
}
