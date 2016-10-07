using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AwesomeJunkWS.Domain;
using AwesomeJunkWS.Presentation;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AwesomeJunkWS
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };
            BaseAddress = new Uri("http://awesomejunk.azurewebsites.net/");

        }

        public async Task<Items> GetItems()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = BaseAddress;
                using (HttpResponseMessage httpResponse = await httpClient.GetAsync("api/item"))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    var result = await httpResponse.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<Items>(result);
                    return items;
                }
            }

        }

        public async Task SaveTodoItemAsync(Item item, bool isNewItem = false)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = BaseAddress;
                using (HttpResponseMessage httpResponse = await httpClient.PostAsync("api/item/post", content))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(@" PresentationItem successfully saved.");
                    }
                }
            }

        }

        public Uri BaseAddress { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
