using FoodOrderingApi.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class SelectionRepository : DataRepository<Selection>, IDataRepository<Selection>
    {
        public SelectionRepository(OrderingContext context)
            : base(context)
        {
        }


        public override IEnumerable<Selection> GetAll()
        {
            return this.OrderingContext.Set<Selection>().Include(x => x.MenuItem).AsNoTracking();
        }
        public override IQueryable<Selection> FindByCondition(Expression<Func<Selection, bool>> expression)
        {
            return this.OrderingContext.Set<Selection>().Where(expression).Include(x => x.MenuItem);
        }
    }
}
