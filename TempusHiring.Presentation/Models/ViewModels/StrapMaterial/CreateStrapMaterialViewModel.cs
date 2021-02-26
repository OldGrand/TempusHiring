using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.StrapMaterial
{
    public class CreateStrapMaterialViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
