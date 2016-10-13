using System;
using System.Collections.Generic;
using AwesomeJunkWS.Domain;

namespace AwesomeJunkWS.Presentation
{
    public class BrowseItemsPresenter
    {
        private GetItemsInteractor _getItemsInteractor;
        private Executor _executor;
        private ItemMapper _maper;
        private IBrowserView _view;

        public BrowseItemsPresenter(GetItemsInteractor getItemsInteractor, Executor executor, IBrowserView view)
        {
            _getItemsInteractor = getItemsInteractor;
            _executor = executor;
            _view = view;
        }

        public void GetItemsButtonClicked()
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

    public interface IBrowserView
    {
        void Display(List<PresentationItem> presentationItems);
    }
}
