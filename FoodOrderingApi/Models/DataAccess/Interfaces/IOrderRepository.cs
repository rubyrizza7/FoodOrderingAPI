using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public interface IOrderRepository: IDataRepository<Order>
    {
    }
}
