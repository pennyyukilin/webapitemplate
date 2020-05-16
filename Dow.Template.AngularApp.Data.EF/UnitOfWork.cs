using Dow.Template.AngularApp.Data.Interface;
using System;
using System.Data.Entity;

namespace Dow.Template.AngularApp.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataEntities _context;
        private bool _disposed = false;

        public UnitOfWork()
        {
            this._context = new DataEntities();
        }
        public UnitOfWork(string connection)
        {
            this._context = new DataEntities(connection);
        }

        public DbContext Context
        {
            get { return _context; }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
