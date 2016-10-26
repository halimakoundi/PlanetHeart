using NSubstitute;
using NUnit.Framework;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Presentation;

namespace PlanetHeartPCL.Tests.Features
{
    public class AddItemFeature
    {
        private INavigator _navigator;
        private IItemsGateway _itemsGateway;
        private AddItemPresenter _addItemPresenter;
        private readonly Item _item = new Item("Test Item");
        private IAddItemView _view;

        [SetUp]
        public void SetUp()
        {
            _itemsGateway = Substitute.For<IItemsGateway>();
            _view = Substitute.For<IAddItemView>();
            _navigator = Substitute.For<INavigator>();
            _addItemPresenter = new AddItemPresenter(
                                        new AddItemInteractor(_view, _itemsGateway),
                                        new Executor(),
                                        _navigator);
        }

        [Test]
        public void add_an_item_when_item_saved()
        {
            _view.RetrieveItem().Returns(_item);

            _addItemPresenter.OnAddItemButtonClicked();

            _view.Received().RetrieveItem();
            _itemsGateway.Received().Add(_item);
            _navigator.Received().NavigateTo(Screen.Reward);
        }

    }
}