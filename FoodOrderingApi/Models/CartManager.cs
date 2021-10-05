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
            // update value
            currentSelection.Quantity += value;
            // update price 
            currentSelection.SelectionPrice = currentSelection.Quantity * currentSelection.MenuItem.Price;

            // if qty > 0 then update existing otherwise delete selection
            if (currentSelection.Quantity > 0)
            {
                _repoWrapper.Selection.Update(currentSelection);
            }
            else {
                _repoWrapper.Selection.Delete(currentSelection);
            }

            UpdateTotalPrice(currentSelection.CartId);
        }



        internal void UpdateTotalPrice(int cartId)
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


    }
}
