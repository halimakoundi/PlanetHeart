using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Infrastructure
{
    public class ItemsGateway : IItemsGateway
    {
        public ItemsGateway()
        {
            BaseAddress = new Uri("http://awesomejunk.azurewebsites.net/");

        }

        public Items GetAllItems()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = BaseAddress;
                using (HttpResponseMessage httpResponse = httpClient.GetAsync("api/item").Result)
                {
                    httpResponse.EnsureSuccessStatusCode();
                    var result = httpResponse.Content.ReadAsStringAsync().Result;
                    var items = JsonConvert.DeserializeObject<List<Item>>(result);
                    return new Items(items);
                }
            }

        }

        public void Add(Item item)
        {
            throw new NotImplementedException();
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
                        Debug.WriteLine(@" Item successfully saved.");
                    }
                }
            }

        }

        public Uri BaseAddress { get; set; }

    }
}