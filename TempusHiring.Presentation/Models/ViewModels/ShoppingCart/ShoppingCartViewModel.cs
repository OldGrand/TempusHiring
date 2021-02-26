using TempusHiring.Presentation.Models.ViewModels.Watch;

namespace TempusHiring.Presentation.Models.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public bool IsChecked { get; set; }

        public int UserId { get; set; }
        public UserViewModel User { get; set; }
        public int WatchId { get; set; }
        public WatchViewModel Watch { get; set; }
    }
}
