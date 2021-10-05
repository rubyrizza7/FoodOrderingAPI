using FoodOrderingApi.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class SelectionRepository : DataRepository<Selection>, ISelectionRepository
    {
        public SelectionRepository(OrderingContext context)
            : base(context)
        {
        }
    }
}
