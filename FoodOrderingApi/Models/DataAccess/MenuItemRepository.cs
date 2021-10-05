using FoodOrderingApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class MenuItemRepository : DataRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(OrderingContext context)
            : base(context)
        {
        }
    }
}
