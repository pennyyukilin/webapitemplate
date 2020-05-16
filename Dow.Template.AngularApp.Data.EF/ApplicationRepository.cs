using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class ApplicationRepository : Repository<Application>, IApplicationRepository
	{
		public ApplicationRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


