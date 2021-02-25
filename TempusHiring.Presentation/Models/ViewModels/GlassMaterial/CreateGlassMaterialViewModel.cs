using System.ComponentModel.DataAnnotations;

namespace TempusHiring.Presentation.Models.ViewModels.GlassMaterial
{
    public class CreateGlassMaterialViewModel
    {
        [Required]
        [MaxLength(64)]
        public string Title { get; set; }
    }
}
