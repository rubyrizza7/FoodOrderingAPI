using FoodOrderingApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class CartRepository : DataRepository<Cart>, ICartRepository
    {
        public CartRepository(OrderingContext context)
            : base(context)
        {
        }
    }
}
