namespace PlanetHeartPCL.Domain
{
    public interface IItemsGateway
    {
        Items GetAllItems();
        void Add(Item item);
    }
}