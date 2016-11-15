using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Infrastructure
{
    public class ItemsGateway : IItemsGateway
    {
        private readonly Uri _baseAddress = new Uri("http://awesomejunk.azurewebsites.net/");
        private const string FileExtention = "jpg";
        private const string ItemApiEndPoint = "api/item/";
        private const string ApiItemPostEndPoint = "api/item/PostFormData";
        private const string ItemSaved = @" Item successfully saved.";
        private const string GetItemsOfTypeTable = "type/?type=Table";

        public Items GetAllItems()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                using (var httpResponse = httpClient.GetAsync(ItemApiEndPoint + GetItemsOfTypeTable).Result)
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
            var multiPartContent = BuildMultipartFormDataContent(this, item);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = _baseAddress;
                using (var httpResponse = httpClient.PostAsync(ApiItemPostEndPoint, multiPartContent).Result)
                {
                    httpResponse.EnsureSuccessStatusCode();
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        Debug.WriteLine(ItemSaved);
                    }
                }
            }
        }

        private static MultipartFormDataContent BuildMultipartFormDataContent(ItemsGateway itemsGateway, Item item)
        {
            var multiPartContent = new MultipartFormDataContent("boundary=---011000010111000001101001");
            itemsGateway.AddImageContent(item.PictureStream, multiPartContent);

            AddItemContent(item, multiPartContent);
            return multiPartContent;
        }

        private static void AddItemContent(Item item, MultipartFormDataContent multiPartContent)
        {
            var json = JsonConvert.SerializeObject(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            multiPartContent.Add(content, "Item");
        }

        public void AddImageContent(StreamContent streamContent, MultipartFormDataContent multiPartContent)
        {
            streamContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
            multiPartContent.Add(streamContent, "PictureOfTheFile", Guid.NewGuid() + "." + FileExtention);
        }
    }
}
