using Dow.Template.AngularApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Biz.Impl.Test.Stubs
{
    public class StubIUnitOfWork : IUnitOfWork
    {
        public System.Data.Entity.DbContext Context
        {
            get
            {
                return new System.Data.Entity.DbContext("test connection");
            }
        }

        public void Dispose()
        {
        }

        public int Save()
        {
            return 1;
        }
    }
}
