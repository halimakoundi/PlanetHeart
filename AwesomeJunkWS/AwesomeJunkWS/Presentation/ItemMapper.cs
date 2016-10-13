using System.Collections.Generic;
using AwesomeJunkWS.Presentation;
using System.Linq;

namespace AwesomeJunkWS.Domain
{
    public class ItemMapper
    {
        public PresentationItem Map(Item item)
        {
            return new PresentationItem($"{item.Id} - {item.Type}" );
        }

        public List<PresentationItem> Map(List<Item> items)
        {
            return items.Select(Map).ToList();
        }
    }
}
