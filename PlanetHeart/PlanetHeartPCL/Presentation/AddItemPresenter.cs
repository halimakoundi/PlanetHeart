using System;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class AddItemPresenter
    {
        private readonly AddItemInteractor _addItemInteractor;
        private readonly Executor _executor;
        private INavigator _navigator;

        public AddItemPresenter(AddItemInteractor addItemInteractor, Executor executor, INavigator navigator)
        {
            _addItemInteractor = addItemInteractor;
            _executor = executor;
            _navigator = navigator;
        }

        public void OnAddItemButtonClicked()
        {
            _addItemInteractor.SetCallback(OnItemSaved());

            _executor.Execute(_addItemInteractor);
        }

        private Action OnItemSaved()
        {
            return () =>
            {
                _navigator.NavigateTo(Screen.Reward);
            };
        }
    }

    public class AddItemInteractor:IInteractor
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