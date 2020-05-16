using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Dow.Template.AngularApp.Data.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> AsQueryable();

        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> FindQueryable(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        T GetByID(object id);

        T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        void Delete(T entity);

        void DeleteAll(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties);

        void Insert(T entity);

        void Update(T entity);

        void Update(T entity, Func<T, bool> predicate);

        void DeleteById(object id);

        void Commit();
    }
}
