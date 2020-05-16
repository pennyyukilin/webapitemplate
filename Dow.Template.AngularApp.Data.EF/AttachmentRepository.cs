using System;
using System.Linq;
using System.Collections.Generic;
using Dow.Template.AngularApp.Data.Interface;

namespace Dow.Template.AngularApp.Data.EF
{  
	public  class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
	{
		public AttachmentRepository(IUnitOfWork uow) : base(uow)
		{
		}
	}
}


