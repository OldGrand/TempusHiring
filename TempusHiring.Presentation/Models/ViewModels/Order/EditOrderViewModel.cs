using System.ComponentModel.DataAnnotations;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.Presentation.Models.ViewModels.Order
{
    public class EditOrderViewModel
    {
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(64)]
        [MinLength(5)]
        public string Address { get; set; }
    }
}
