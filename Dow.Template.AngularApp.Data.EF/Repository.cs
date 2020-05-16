using Dow.Template.AngularApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Dow.Template.AngularApp.Data.EF
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DataEntities context;
        protected DbSet<T> dbSet;

        public Repository(IUnitOfWork uow)
        {
            context = uow.Context as DataEntities;
            this.dbSet = context.Set<T>();
        }

        #region IRepository<T> Members

        public virtual IQueryable<T> AsQueryable()
        {
            return dbSet;
        }

        public virtual IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable().AsNoTracking();
            return PerformInclusions(includeProperties, query);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.AsNoTracking().Where(where);
        }

        public virtual IQueryable<T> FindQueryable(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable().AsNoTracking();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public virtual T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable().AsNoTracking();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        public virtual T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable().AsNoTracking();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
        }

        public virtual void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public virtual void DeleteAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);

            foreach (var entity in query.AsNoTracking().Where(where))
            {
                Delete(entity);
            }
        }

        public virtual void DeleteById(object id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual T GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);

                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Update(T entity, Func<T, bool> predicate)
        {
            var entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                T attachedEntity = dbSet.Local.SingleOrDefault(predicate);
                if (attachedEntity != null)
                {
                    var attachedEntry = context.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    dbSet.Attach(entity);
                    entry.State = EntityState.Modified;
                }
            }
        }

        public virtual void Commit()
        {
            context.SaveChanges();
        }

        #endregion

        #region Protected Methods

        protected static IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties, IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #endregion
    }
}
