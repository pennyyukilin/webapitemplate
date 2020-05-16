using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class SpecialtyProductRepository : Repository<SpecialtyProduct>, ISpecialtyProductRepository
	{
		public SpecialtyProductRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


