using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.StrapMaterial
{
    public class EditStrapMaterialViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
