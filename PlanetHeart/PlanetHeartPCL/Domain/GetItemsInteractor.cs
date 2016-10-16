using System;
using AwesomeJunkWS.Infrastructure;
using PlanetHeart.Presentation;

namespace PlanetHeart.Domain
{
    public class GetItemsInteractor : IInteractor
    {
        private Action<Items> _callback;
        private readonly ItemsGeteway _itemsGeteway = new ItemsGeteway();

        public void SetCallback(Action<Items> action)
        {
            _callback = action;
        }

        public void Execute()
        {
            _callback.Invoke(_itemsGeteway.GetAllItems());
        }
    }
}