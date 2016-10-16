using System.Collections.Generic;

namespace PlanetHeart.Domain
{
    public class Items
    {
        private readonly List<Item> _data;

        public Items(List<Item> data)
        {
            _data = data;
        }

        public List<Item> All()
        {
            return _data;
        }
    }
}