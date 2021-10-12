using FoodOrderingApi.Models.DataAccess;
using FoodOrderingApi.Models.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models
{
    public class CartManager : ICartManager
    {
        private IRepositoryWrapper _repoWrapper;
        public CartManager(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public int UpdateSelectionQty(Selection currentSelection, int value)
        {
            CheckIsModfiable(currentSelection.CartId);

            int newQuantity = currentSelection.UpdateQty(value);

            // if qty > 0 then update existing otherwise delete selection
            if (newQuantity > 0)
            {
                _repoWrapper.Selection.Update(currentSelection);
            }
            else
            {
                _repoWrapper.Selection.Delete(currentSelection);
            }

            UpdateTotalPrice(currentSelection.CartId);
            _repoWrapper.Save();

            return newQuantity;
        }

        // creates a new cart and returns it
        public Cart NewCart()
        {
            var newCart = new Cart();
            _repoWrapper.Cart.Create(newCart);
            _repoWrapper.Save();

            return newCart;
        }

        private void UpdateTotalPrice(int cartId)
        {
            // get cart
            Cart cart = _repoWrapper.Cart.FindByCondition(x => x.CartId.Equals(cartId)).Single();

            // tally the prices of each selection
            double newTotal = 0;
            foreach (Selection selection in cart.Selections)
            {
                newTotal += selection.SelectionPrice;
            }

            // update cart total and update cart
            cart.TotalPrice = newTotal;
            _repoWrapper.Cart.Update(cart);
        }

        public Selection NewSelection(SelectionDTO newSelection)
        {
            CheckIsModfiable(newSelection.CartId);

            // get item price
            double selectionPrice = _repoWrapper.MenuItem.FindByCondition(x => x.MenuItemId.Equals(newSelection.MenuItemId)).Single().Price * newSelection.Quantity;

            // create new selection
            Selection selection = new Selection { MenuItemId = newSelection.MenuItemId, CartId = newSelection.CartId, Quantity = newSelection.Quantity, SelectionPrice = selectionPrice };
            _repoWrapper.Selection.Create(selection);
            _repoWrapper.Save();

            return selection;
        }

        public Order PlaceOrder(int cartId)
        {
            CheckIsModfiable(cartId);

            // create new order
            Order order = new Order { CartId = cartId, TimePlaced = DateTime.Now };
            _repoWrapper.Order.Create(order);
            _repoWrapper.Save();
            
            return order;
        }

        // checks if an order is assosiated.  If so no further changes should be made to the cart.
        private void CheckIsModfiable(int cartId)
        {
            // get queried cart
            int assosiatedOrdersCount =  _repoWrapper.Order.FindByCondition(x => x.CartId.Equals(cartId)).Count();

            if (assosiatedOrdersCount > 0)
            {
                throw new Exception("This cart cannot be modified because it has an assosiated order.");
            }
        }
    }
}
