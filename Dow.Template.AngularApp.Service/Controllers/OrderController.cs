using Dow.Template.AngularApp.Biz.Interface;
using Dow.Template.AngularApp.Biz.Interface.Model;
using Dow.Template.AngularApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace Dow.Template.AngularApp.Service.Controllers
{
    [Authorize]
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private IOrderService orderServie;

        public OrderController(IOrderService service)
        {
            this.orderServie = service;
        }
        
        public List<OrderVM> Get()
        {
            var orders = orderServie.GetAllOrders();
            return orders;
        }
        
        public OrderVM Get(int id)
        {
            var order = orderServie.GetOrderById(id);
            return order;
        }

        public void Post(OrderVM ordervm)
        {
            orderServie.UpdateOrder(ordervm);
        }


    }
}
