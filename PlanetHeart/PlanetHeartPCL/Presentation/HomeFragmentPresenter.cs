using System;
using PlanetHeartPCL.Domain;

namespace PlanetHeartPCL.Presentation
{
    public class HomeFragmentPresenter
    {
        private readonly GetItemsInteractor _getItemsInteractor;
        private readonly Executor _executor;
        private readonly ItemMapper _maper;
        private readonly IBrowserView _view;

        public HomeFragmentPresenter(GetItemsInteractor getItemsInteractor, Executor executor, IBrowserView view, ItemMapper maper)
        {
            _getItemsInteractor = getItemsInteractor;
            _executor = executor;
            _view = view;
            _maper = maper;
        }

        public void OnViewReady()
        {
            _getItemsInteractor.SetCallback(OnItemsLoaded());
        
            _executor.Execute(_getItemsInteractor);
        }

        private Action<Items> OnItemsLoaded()
        {
            return (items) =>
            {
                _view.Display(_maper.Map(items.All()));

            };
           
        }
    }
}
