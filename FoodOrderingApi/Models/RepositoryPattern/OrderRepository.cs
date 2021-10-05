using FoodOrderingApi.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class OrderRepository : DataRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderingContext context)
            : base(context)
        {
        }

        public override IEnumerable<Order> GetAll()
        {
            return this.OrderingContext.Set<Order>().Include(x => x.Cart).ThenInclude(x => x.Selections).ThenInclude(x => x.MenuItem).AsNoTracking();
        }
        public override IQueryable<Order> FindByCondition(Expression<Func<Order, bool>> expression)
        {
            return this.OrderingContext.Set<Order>().Where(expression).Include(x => x.Cart).ThenInclude(x => x.Selections).ThenInclude(x => x.MenuItem).AsNoTracking();
        }
    }
}
