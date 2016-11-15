using System.Net.Http;

namespace PlanetHeartPCL.Domain
{
    public class Item
    {
        public Item(string type)
        {
            Type = type;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string PostCode { get; set; }
        public string Picture { get; set; }
        public ItemCondition Condition { get; set; }
        public StreamContent PictureStream { get; set; }
    }

    public enum ItemCondition
    {
        VeryGood = 3
    }
}