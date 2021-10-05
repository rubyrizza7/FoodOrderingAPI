using FoodOrderingApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class OrderRepository : DataRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderingContext context)
            : base(context)
        {
        }
    }
}
