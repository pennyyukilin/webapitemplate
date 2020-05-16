using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
	{
		public SpecialtyRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


