using System.ComponentModel.DataAnnotations;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.Presentation.Models.ViewModels.Mechanism
{
    public class EditMechanismViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(64)]
        public string Description { get; set; }

        [Range(0, 100)]
        public int PowerReserveDays { get; set; }

        public MechanismType MechanismType { get; set; }
    }
}
