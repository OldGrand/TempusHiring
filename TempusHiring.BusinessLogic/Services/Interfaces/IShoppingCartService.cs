using System.Collections.Generic;
using System.Threading.Tasks;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.Common;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartDTO> ReadUserCart(int id);
        Task AddToCartAsync(int userId, int watchId);
        void ChangeCount(int userId, int watchId, Operations operation);
        void DeleteFromCart(int cartId);
        void UpdateSelection(int userId, int watchId, bool isChecked);
        OrderSummaryDTO GetSummary(int userId);
    }
}
