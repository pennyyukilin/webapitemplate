using Dow.Template.AngularApp.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Dow.Template.AngularApp.Biz.Impl.Test.Stubs
{
    public class StubIOrderRepository : IRepository<Order>, IOrderRepository
    {
        public IQueryable<Order> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(Expression<Func<Order, bool>> where, params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> where, params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> FindQueryable(Expression<Func<Order, bool>> where, params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public Order FirstOrDefault(Expression<Func<Order, bool>> where, params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll(params Expression<Func<Order, object>>[] includeProperties)
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order()
            {
                OrderID = 1,
                Customer = "Test Name"
            });

            return orders;
        }

        public Order GetByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Single(Expression<Func<Order, bool>> where, params Expression<Func<Order, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Order entity, Func<Order, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
