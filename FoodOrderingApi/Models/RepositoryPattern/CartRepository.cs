using FoodOrderingApi.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class CartRepository : DataRepository<Cart>, IDataRepository<Cart>
    {
        public CartRepository(OrderingContext context)
            : base(context)
        {
        }

        public override IEnumerable<Cart> GetAll()
        {
            return this.OrderingContext.Set<Cart>().Include(x => x.Selections).ThenInclude(x => x.MenuItem).AsNoTracking();
        }
        public override IQueryable<Cart> FindByCondition(Expression<Func<Cart, bool>> expression)
        {
            return this.OrderingContext.Set<Cart>().Where(expression).Include(x => x.Selections).ThenInclude(x => x.MenuItem);
        }

    }
}
