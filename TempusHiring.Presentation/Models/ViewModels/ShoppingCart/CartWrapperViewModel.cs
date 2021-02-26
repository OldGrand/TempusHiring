using System.Collections.Generic;
using TempusHiring.Presentation.Models.ViewModels.Order;

namespace TempusHiring.Presentation.Models.ViewModels.ShoppingCart
{
    public class CartWrapperViewModel
    {
        public OrderSummaryViewModel OrderSummaryViewModel { get; set; }
        public IEnumerable<ShoppingCartViewModel> ShoppingCarts { get; set; }
    }
}
