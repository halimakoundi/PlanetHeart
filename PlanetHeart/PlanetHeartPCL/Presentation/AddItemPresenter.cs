using System;

namespace PlanetHeartPCL.Presentation
{
    public class AddItemPresenter
    {
        private readonly AddItemInteractor _addItemInteractor;
        private readonly Executor _executor;
        private readonly INavigator _navigator;

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
}