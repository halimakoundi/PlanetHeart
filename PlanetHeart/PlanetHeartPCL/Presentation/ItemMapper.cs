using System.Collections.Generic;
using PlanetHeart.Presentation;
using System.Linq;

namespace PlanetHeart.Domain
{
    public class ItemMapper
    {
        public PresentationItem Map(Item item)
        {
            return new PresentationItem($"{item.Id} - {item.Type}", "Admin", 23 );
        }

        public List<PresentationItem> Map(List<Item> items)
        {
            return items.Select(Map).ToList();
        }
    }
}
