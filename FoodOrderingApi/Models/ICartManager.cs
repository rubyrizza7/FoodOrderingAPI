namespace FoodOrderingApi.Models
{
    public interface ICartManager
    {
        Cart NewCart();
        Order PlaceOrder(OrderDTO newOrder);
        Selection UpdateOrCreateSelection(SelectionDTO value);
    }
}