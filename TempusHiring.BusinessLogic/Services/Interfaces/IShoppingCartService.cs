using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartDTO> ReadUserCart(int id);
        Task AddToCartAsync(int userId, int watchId);
        void ChangeItemsCountInCart(int userId, int watchId, int count);
        void DeleteFromCart(int cartId);
        decimal GetWatchPrice(int watchId);
        void UpdateSelection(int userId, int watchId, bool isChecked);
        int GetWatchCountInStock(int watchId);
        OrderSummaryDTO GetSummary(int userId);
    }
}
