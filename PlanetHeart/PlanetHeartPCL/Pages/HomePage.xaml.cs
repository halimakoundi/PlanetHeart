using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PlanetHeartPCL.Pages
{
    public partial class HomePage : BaseContentPage
    {
        public static ObservableCollection<string> Items { get; set; }
        public HomePage()
        {
            Items = new ObservableCollection<string>() { "speaker", "pen", "lamp", "monitor", "bag", "book", "cap", "tote", "floss", "phone" };
            InitializeComponent();
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //comment out if you want to keep selections
            ListView lst = (ListView)sender;
            lst.SelectedItem = null;
        }

        void OnRefresh(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            //put your refreshing logic here
            var itemList = Items.Reverse().ToList();
            Items.Clear();
            foreach (var s in itemList)
            {
                Items.Add(s);
            }
            //make sure to end the refresh state
            list.IsRefreshing = false;
        }

        void OnTap(object sender, ItemTappedEventArgs e)
        {
            DisplayAlert("Item Tapped", e.Item.ToString(), "Ok");
        }

        void OnMore(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            DisplayAlert("More Context Action", item.CommandParameter + " more context action", "OK");
        }

        void OnDelete(object sender, EventArgs e)
        {
            var item = (MenuItem)sender;
            Items.Remove(item.CommandParameter.ToString());
        }

    }
}
