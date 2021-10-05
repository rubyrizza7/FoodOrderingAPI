using FoodOrderingApi.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        protected OrderingContext OrderingContext { get; set; }
        public DataRepository(OrderingContext context)
        {
            this.OrderingContext = context;
        }
        public virtual IEnumerable<T> GetAll()
        {
            return this.OrderingContext.Set<T>().AsNoTracking();
        }
        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.OrderingContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.OrderingContext.Set<T>().Add(entity);
        }
        public virtual void Update(T entity)
        {
            this.OrderingContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.OrderingContext.Set<T>().Remove(entity);
        }
    }
}

