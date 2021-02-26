namespace TempusHiring.Presentation.Models.ViewModels.Order
{
    public class OrderSummaryViewModel
    {
        public decimal SubTotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Total { get; set; }
        public int Count { get; set; }
    }
}
