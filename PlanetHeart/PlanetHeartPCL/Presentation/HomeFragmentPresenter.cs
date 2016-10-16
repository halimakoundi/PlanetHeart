﻿using System;
using System.Collections.Generic;
using PlanetHeart.Domain;

namespace PlanetHeart.Presentation
{
    public class HomeFragmentPresenter
    {
        private GetItemsInteractor _getItemsInteractor;
        private Executor _executor;
        private ItemMapper _maper;
        private IBrowserView _view;

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

    public interface IBrowserView
    {
        void Display(List<PresentationItem> presentationItems);
    }
}