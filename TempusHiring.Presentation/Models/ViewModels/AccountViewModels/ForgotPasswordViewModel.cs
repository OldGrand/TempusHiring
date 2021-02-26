using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
