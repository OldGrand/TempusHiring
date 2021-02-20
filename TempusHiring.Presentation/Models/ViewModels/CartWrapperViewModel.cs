using System.Collections.Generic;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public class CartWrapperViewModel
    {
        public OrderSummaryViewModel OrderSummaryViewModel { get; set; }
        public IEnumerable<ShoppingCartViewModel> ShoppingCarts { get; set; }
    }
}
