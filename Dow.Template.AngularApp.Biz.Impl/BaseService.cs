using Dow.Template.AngularApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Impl
{
    public abstract class BaseService
    {
        protected IUnitOfWork context;

        public BaseService(IUnitOfWork uow)
        {
            context = uow;
        }
    }

}
