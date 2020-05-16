using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
	{
		public OrderProductRepository(IUnitOfWork uow) : base(uow)
		{
		}

	}
}


