using System.Collections.Generic;
using System.Linq;

namespace PlanetHeartPCL.Domain
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
            return _data.Where(x => x != null).ToList();
        }
    }
}