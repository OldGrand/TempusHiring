using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.WristSize
{
    public class CreateWristSizeViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [Range(0, 100)]
        public double Size { get; set; }
    }
}
