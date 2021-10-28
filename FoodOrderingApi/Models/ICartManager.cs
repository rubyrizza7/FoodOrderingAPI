namespace FoodOrderingApi.Models
{
    public interface ICartManager
    {
        Cart NewCart();
        Order PlaceOrder(int cartId);
        Selection UpdateOrCreateSelection(SelectionDTO value);
    }
}