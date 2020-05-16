using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class SecurityRoleRepository : Repository<SecurityRole>, ISecurityRoleRepository
	{
		public SecurityRoleRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


