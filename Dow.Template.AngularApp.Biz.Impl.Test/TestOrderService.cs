using Dow.Template.AngularApp.Biz.Impl.Test.Stubs;
using Dow.Template.AngularApp.Data.Interface;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Impl.Test
{
    [TestFixture]
    public class TestOrderService
    {

        private OrderService orderService;

        [SetUp]
        public void Init()
        {
            IOrderRepository orderRepository = new StubIOrderRepository();
            IUnitOfWork uow = new StubIUnitOfWork();
            orderService = new OrderService(uow, orderRepository);
        }


        [Test]
        public void TestGetAllOrders()
        {
            var result = orderService.GetAllOrders();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0].OrderID);
            Assert.AreEqual("Test Name", result[0].Customer);
        }

    }
}
