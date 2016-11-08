using System.Collections.Generic;
using System.Linq;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class ItemMapper
    {
        public PresentationItem Map(Item item)
        {
            return new PresentationItem($"{item.Type}", "Admin", item.Picture);
        }

        public List<PresentationItem> Map(List<Item> items)
        {
            return items.Select(Map).ToList();
        }
    }
}
