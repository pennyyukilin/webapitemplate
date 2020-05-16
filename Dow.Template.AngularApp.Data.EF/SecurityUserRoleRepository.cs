using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class SecurityUserRoleRepository : Repository<SecurityUserRole>, ISecurityUserRoleRepository
	{
		public SecurityUserRoleRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


