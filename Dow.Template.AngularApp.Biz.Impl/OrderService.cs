using Dow.Template.AngularApp.Biz.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dow.Template.AngularApp.Biz.Interface.Model;
using Dow.Template.AngularApp.Data.Interface;
using Dow.Template.AngularApp.Common;
using Dow.Core.Library.ExceptionHandling;

namespace Dow.Template.AngularApp.Biz.Impl
{
    public class OrderService : BaseService, IOrderService
    {

        #region Private Fields

        private IOrderRepository orderRepository;

        #endregion

        public OrderService(IUnitOfWork uow, IOrderRepository orderRepository)
            : base(uow)
        {
            this.orderRepository = orderRepository;
        }

        public List<OrderVM> GetAllOrders()
        {
            List<OrderVM> orderList = new List<OrderVM>();

            var orders = orderRepository.GetAll();
            foreach (var order in orders)
            {
                orderList.Add(ConvertToOrderVM(order));
            }

            return orderList;
        }

        public OrderVM GetOrderById(int orderId)
        {
            try
            {
                var order = orderRepository.FirstOrDefault(x => x.OrderID == orderId);
                if (null != order)
                {
                    var ordervm = ConvertToOrderVM(order);
                    return ordervm;
                }

                return null;
            }
            catch(Exception ex)
            {
                ExceptionManager.HandleBizException(ex, "custom msg");
                return null;
            }
        }

        public void UpdateOrder(OrderVM ordervm)
        {
            try
            {
                Order order = ConvertToOrder(ordervm);
                orderRepository.Update(order);
                  
                orderRepository.Commit();
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleBizException(ex, "custom msg");
            }
        }


        private OrderVM ConvertToOrderVM(Order order)
        {
            OrderVM ordervm = new OrderVM();
            ordervm.OrderID = order.OrderID;
            ordervm.Customer = order.Customer;
            ordervm.Country = order.ShipCountry;
            ordervm.City = order.ShipCity;
            ordervm.Address = order.ShipAddress;
            ordervm.OrderDate = order.OrderDate;

            return ordervm;
        }


        private Order ConvertToOrder(OrderVM ordervm)
        {
            Order order = new Order();
            order.OrderID = ordervm.OrderID;
            order.Customer = ordervm.Customer;
            order.ShipCountry = ordervm.Country;
            order.ShipCity = ordervm.City;
            order.ShipAddress = ordervm.Address;
            order.OrderDate = ordervm.OrderDate;

            return order;
        }

    }
}
