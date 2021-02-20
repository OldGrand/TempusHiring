using System.Collections.Generic;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public class CartWrapperViewModel
    {
        public IEnumerable<ShoppingCartViewModel> ShoppingCarts { get; set; }
    }
}
