using FoodOrderingApi.Context;
using FoodOrderingApi.Models.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models.DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OrderingContext _repoContext;
        private IMenuItemRepository _menuItem;
        private ISelectionRepository _selection;
        private IOrderRepository _order;
        private ICartRepository _cart;
        public IMenuItemRepository MenuItem
        {
            get
            {
                if (_menuItem == null)
                {
                    _menuItem = new MenuItemRepository(_repoContext);
                }
                return _menuItem;
            }
        }
        public ISelectionRepository Selection
        {
            get
            {
                if (_selection == null)
                {
                    _selection = new SelectionRepository(_repoContext);
                }
                return _selection;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_repoContext);
                }
                return _order;
            }
        }

        public ICartRepository Cart
        {
            get
            {
                if (_cart == null)
                {
                    _cart = new CartRepository(_repoContext);
                }
                return _cart;
            }
        }

        public RepositoryWrapper(OrderingContext context)
        {
            _repoContext = context;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    
}
}
