using TempusHiring.DataAccess.Entities;

namespace TempusHiring.BusinessLogic.Extensions
{
    public static class EntityMappingExtension
    {
        public static OrderWatchLink ToOrder(this ShoppingCart shoppingCart, Order order)
        {
            return new OrderWatchLink
            {
                Order = order,
                OrderId = order.Id,
                Watch = shoppingCart.Watch,
                WatchId = shoppingCart.WatchId,
                Count = shoppingCart.Count,
            };
        }
    }
}