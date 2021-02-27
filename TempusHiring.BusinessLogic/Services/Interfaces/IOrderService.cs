using System.Collections.Generic;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
using TempusHiring.BusinessLogic.Services.Interfaces.Common;

namespace TempusHiring.BusinessLogic.Services.Interfaces
{
    public interface IOrderService : ICrudService<OrderDTO>
    {
        void CreateOrder(OrderDTO orderDto, int userId);
        IEnumerable<OrderDTO> GetOrders(int userId);
    }
}
