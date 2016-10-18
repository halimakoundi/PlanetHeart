using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Presentation;

namespace PlanetHeartPCL.Tests
{
    public class ListAllItemsFeature
    {
        private IItemsGateway _itemsGateway;
        private Executor _executor;
        private GetItemsInteractor _getItemsInteractor;
        private IBrowserView _view;
        private HomeFragmentPresenter _homeFragmentPresenter;
        private ItemMapper _maper;
        private readonly Items _items = new Items(new List<Item>() {new Item("Stuff"),
                 new Item("wooden chair") ,
                 new Item("wooden table") });


        [SetUp]
        public void SetUp()
        {
            _itemsGateway = Substitute.For<IItemsGateway>();
            _getItemsInteractor = new GetItemsInteractor(_itemsGateway);
            _executor = new Executor();
            _maper = new ItemMapper();
            _view = Substitute.For <IBrowserView>();
            _homeFragmentPresenter = new HomeFragmentPresenter(_getItemsInteractor,_executor,_view,_maper);
        }

        [Test]
        public void request_all_items_from_items_gateway()
        {
            GivenItems();

            _homeFragmentPresenter.OnViewReady();

            _view.Received().Display(Arg.Is<List<PresentationItem>>(items => ExpectedItems().SequenceEqual(items)));
        }

        private List<PresentationItem> ExpectedItems()
        {
            return _maper.Map(_items.All());
        }

        private void GivenItems()
        {
            _itemsGateway.GetAllItems().Returns(_items);
        }
    }
}
