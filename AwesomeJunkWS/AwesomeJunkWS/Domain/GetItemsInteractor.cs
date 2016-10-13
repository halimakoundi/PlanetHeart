using System;
using AwesomeJunkWS.Presentation;

namespace AwesomeJunkWS.Domain
{
    public class GetItemsInteractor : IInteractor
    {
        private Action<Items> _callback;
        private App _app = new App();

        public void SetCallback(Action<Items> action)
        {
            _callback = action;
        }

        public void Execute()
        {
            _callback.Invoke(_app.GetAllItems());
        }
    }
}