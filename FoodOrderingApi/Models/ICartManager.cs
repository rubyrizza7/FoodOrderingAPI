namespace FoodOrderingApi.Models
{
    public interface ICartManager
    {
        Cart NewCart();
        void NewSelection(NewSelection value);
        void PlaceOrder(int cartId);
        void UpdateSelectionQty(Selection currentSelection, int value);
    }
}