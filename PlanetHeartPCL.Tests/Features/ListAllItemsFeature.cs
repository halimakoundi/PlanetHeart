using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using PlanetHeartPCL.Domain;
using PlanetHeartPCL.Presentation;

namespace PlanetHeartPCL.Tests.Features
{
    public class ListAllItemsFeature
    {
        private IItemsGateway _itemsGateway;
        private IBrowserView _view;
        private HomePagePresenter _presenter;
        private ItemMapper _itemsMaper;
        private readonly Items _items = new Items(new List<Item>() {new Item("Stuff"),
                 new Item("wooden chair") ,
                 new Item("wooden table") });


        [SetUp]
        public void SetUp()
        {
            _itemsGateway = Substitute.For<IItemsGateway>();
            _itemsMaper = new ItemMapper();
            _view = Substitute.For<IBrowserView>();
            _presenter = new HomePagePresenter(new GetItemsInteractor(_itemsGateway),
                                                    new Executor(),
                                                    _view,
                                                    _itemsMaper);
        }

        [Test]
        public void list_all_items_when_home_view_is_ready()
        {
            GivenItems();

            _presenter.OnViewReady();

            _view.Received().Display(ExpectedItems());
        }

        private List<PresentationItem> ExpectedItems()
        {
            return Arg.Is<List<PresentationItem>>(items => _itemsMaper.Map(_items.All()).SequenceEqual(items));
        }

        private void GivenItems()
        {
            _itemsGateway.GetAllItems().Returns(_items);
        }
    }
}
