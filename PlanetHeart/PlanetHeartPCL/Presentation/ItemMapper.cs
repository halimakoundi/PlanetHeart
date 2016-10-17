using System.Collections.Generic;
using System.Linq;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class ItemMapper
    {
        public PresentationItem Map(Item item)
        {
            return new PresentationItem($"{item.Id} - {item.Type}", "Admin", 23);
        }

        public List<PresentationItem> Map(List<Item> items)
        {
            return items.Select(Map).ToList();
        }
    }
}
