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
                return _menuItem;
            }
        }
        public ISelectionRepository Selection
        {
            get
            {
                return _selection;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                return _order;
            }
        }

        public ICartRepository Cart
        {
            get
            {
                return _cart;
            }
        }

        public RepositoryWrapper(OrderingContext context, IMenuItemRepository menuRepo, ISelectionRepository selectionRepo, ICartRepository cartRepo, IOrderRepository orderRepo)
        {
            _repoContext = context;
            _menuItem = menuRepo;
            _selection = selectionRepo;
            _cart = cartRepo;
            _order = orderRepo;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    
}
}
