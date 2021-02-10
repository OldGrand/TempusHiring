using System.Linq;
using TempusHiring.BusinessLogic.DataTransferObjects;

namespace TempusHiring.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        void AddItemsToOrder(int userId);
        IQueryable<OrderDTO> GetOrders(int userId);
    }
}
