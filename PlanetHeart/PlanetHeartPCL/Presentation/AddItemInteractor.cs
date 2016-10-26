using System;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class AddItemInteractor : IInteractor
    {
        private Action _callback;
        private readonly IAddItemView _view;
        private readonly IItemsGateway _itemsGateway;

        public AddItemInteractor(IAddItemView view, IItemsGateway itemsGateway)
        {
            _view = view;
            _itemsGateway = itemsGateway;
        }

        public void Execute()
        {
            var item = _view.RetrieveItem();
            _itemsGateway.Add(item);
            _callback.Invoke();
        }

        public void SetCallback(Action action)
        {
            _callback = action;
        }
    }
}