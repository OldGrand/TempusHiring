using System.Linq;
using TempusHiring.BusinessLogic.DataTransferObjects;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        void AddItemsToOrder(int userId);
        IQueryable<OrderDTO> GetOrders(int userId);
    }
}
