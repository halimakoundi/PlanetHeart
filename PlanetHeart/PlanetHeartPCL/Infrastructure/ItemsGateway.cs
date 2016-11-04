using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Infrastructure
{
    public class ItemsGateway : IItemsGateway
    {
        private readonly Uri _baseAddress = new Uri("http://awesomejunk.azurewebsites.net/");
        private const string ItemApiEndPoint = "api/item";
        private const string ApiItemPostEndPoint = "api/item/post";
        private const string ItemSaved = @" Item successfully saved.";

        public Items GetAllItems()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                using (var httpResponse = httpClient.GetAsync(ItemApiEndPoint).Result)
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
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                using (var httpResponse = httpClient.PostAsync(ApiItemPostEndPoint, content).Result)
                {
                    httpResponse.EnsureSuccessStatusCode();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(ItemSaved);
                    }
                }
            }
        }

    }
}
