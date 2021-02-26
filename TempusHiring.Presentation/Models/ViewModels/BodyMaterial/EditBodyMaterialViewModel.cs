using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.BodyMaterial
{
    public class EditBodyMaterialViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
