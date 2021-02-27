using System.Collections.Generic;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDTO orderDto, int userId);
        IEnumerable<OrderDTO> GetOrders(int userId);
    }
}
