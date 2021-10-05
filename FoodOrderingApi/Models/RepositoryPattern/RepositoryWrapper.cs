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
        private IDataRepository<MenuItem> _menuItem;
        private IDataRepository<Selection> _selection;
        private IDataRepository<Order> _order;
        private IDataRepository<Cart> _cart;
        public IDataRepository<MenuItem> MenuItem
        {
            get
            {
                return _menuItem;
            }
        }
        public IDataRepository<Selection> Selection
        {
            get
            {
                return _selection;
            }
        }

        public IDataRepository<Order> Order
        {
            get
            {
                return _order;
            }
        }

        public IDataRepository<Cart> Cart
        {
            get
            {
                return _cart;
            }
        }

        public RepositoryWrapper(OrderingContext context, IDataRepository<MenuItem> menuRepo, IDataRepository<Selection> selectionRepo, IDataRepository<Cart> cartRepo, IDataRepository<Order> orderRepo)
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
