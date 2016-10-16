namespace PlanetHeart.Domain
{
    public class Item
    {
        public Item(string type)
        {
            Type = type;
        }

        public string Id { get; set; }
        public string Type { get; set; }

    }
}