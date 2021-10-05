using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess.Interfaces
{
 
    public interface IRepositoryWrapper
    {
        public IDataRepository<MenuItem> MenuItem { get; }
        public IDataRepository<Selection> Selection { get; }
        public IDataRepository<Order> Order { get; }
        public IDataRepository<Cart> Cart { get; }
        void Save();
    }
    
}
