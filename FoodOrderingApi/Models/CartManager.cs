using FoodOrderingApi.Models.DataAccess;
using FoodOrderingApi.Models.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models
{
    public class CartManager
    {
        private IRepositoryWrapper _repoWrapper;
        public CartManager(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        internal void UpdateSelectionQty(Selection currentSelection, int value)
        {
            currentSelection.UpdateQty(value);

            // if qty > 0 then update existing otherwise delete selection
            if (currentSelection.Quantity > 0)
            {
                _repoWrapper.Selection.Update(currentSelection);
            }
            else {
                _repoWrapper.Selection.Delete(currentSelection);
            }

            UpdateTotalPrice(currentSelection.CartId);
            _repoWrapper.Save();
        }

        internal int NewCart()
        {
            var newCart = new Cart();
            _repoWrapper.Cart.Create(newCart);
            _repoWrapper.Save();

            return newCart.CartId;
        }

        private void UpdateTotalPrice(int cartId)
        {
            // get cart
            Cart cart = _repoWrapper.Cart.FindByCondition(x => x.CartId.Equals(cartId)).Single();

            double newTotal = 0;
            foreach (Selection selection in cart.Selections)
            {
                newTotal += selection.SelectionPrice;
            }

            // update cart total and update cart
            cart.TotalPrice = newTotal;
            _repoWrapper.Cart.Update(cart);
        }

        internal void NewSelection(NewSelection value)
        {
            // get item price
            double selectionPrice = _repoWrapper.MenuItem.FindByCondition(x => x.MenuItemId.Equals(value.MenuItemId)).Single().Price * value.Quantity;

            // create new selection
            _repoWrapper.Selection.Create(new Selection { MenuItemId = value.MenuItemId, CartId = value.CartId, Quantity = value.Quantity, SelectionPrice = selectionPrice });
            _repoWrapper.Save();
        }

        internal void PlaceOrder(int cartId)
        {
            // create new order
            _repoWrapper.Order.Create(new Order { CartId = cartId, TimePlaced = DateTime.Now });
            _repoWrapper.Save();
        }
    }
}
