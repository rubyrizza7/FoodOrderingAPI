using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess.Interfaces
{
 
    public interface IRepositoryWrapper
    {
        IMenuItemRepository MenuItem { get; }
        ISelectionRepository Selection { get; }
        IOrderRepository Order { get; }
        ICartRepository Cart { get; }
        void Save();
    }
    
}
