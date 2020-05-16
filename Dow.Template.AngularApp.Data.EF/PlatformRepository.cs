using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class PlatformRepository : Repository<Platform>, IPlatformRepository
	{
		public PlatformRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


