using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.BodyMaterial
{
    public class CreateBodyMaterialViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
