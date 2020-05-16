using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class OrderRepository : Repository<Order>, IOrderRepository
	{
		public OrderRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


