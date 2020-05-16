using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class SolutionRepository : Repository<Solution>, ISolutionRepository
	{
		public SolutionRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


