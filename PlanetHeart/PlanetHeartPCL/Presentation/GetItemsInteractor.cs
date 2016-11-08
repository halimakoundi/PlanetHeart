using System;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class GetItemsInteractor : IInteractor
    {
        private Action<Items> _callback;
        private readonly IItemsGateway _itemsGateway;

        public GetItemsInteractor(IItemsGateway itemsGateway)
        {
            _itemsGateway = itemsGateway;
        }

        public void SetCallback(Action<Items> action)
        {
            _callback = action;
        }

        public void Execute()
        {
            _callback.Invoke(_itemsGateway.GetAllItems());
        }
    }
}