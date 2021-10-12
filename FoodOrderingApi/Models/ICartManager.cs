namespace FoodOrderingApi.Models
{
    public interface ICartManager
    {
        Cart NewCart();
        Selection NewSelection(SelectionDTO value);
        Order PlaceOrder(int cartId);
        int UpdateSelectionQty(Selection currentSelection, int value);
    }
}