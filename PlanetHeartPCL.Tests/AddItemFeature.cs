using NSubstitute;
using NUnit.Framework;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Presentation;

namespace PlanetHeartPCL.Tests
{
    public class AddItemFeature
    {
        private INavigator _navigator;
        private IItemsGateway _itemsGateway;
        private AddItemPresenter _addItemPresenter;
        private readonly Item _item = new Item("Test Item");

        [SetUp]
        public void SetUp()
        {
            _itemsGateway = Substitute.For<IItemsGateway>();
            _addItemPresenter = new AddItemPresenter();
            _navigator = new Navigator();
        }

        [Test]
        public void add_an_item_when_item_saved()
        {
            _addItemPresenter.OnAddItemButtonClicked();

            _itemsGateway.Received().Add(_item);
            _navigator.Received().NavigateTo(Screen.Reward);
        }

    }
}