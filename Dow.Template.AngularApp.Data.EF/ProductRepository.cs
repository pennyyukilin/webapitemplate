using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


