using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class SecurityUserRepository : Repository<SecurityUser>, ISecurityUserRepository
	{
		public SecurityUserRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


