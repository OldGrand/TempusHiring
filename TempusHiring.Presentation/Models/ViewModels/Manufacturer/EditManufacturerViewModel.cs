using System.ComponentModel.DataAnnotations;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.Presentation.Models.ViewModels.Manufacturer
{
    public class EditManufacturerViewModel
    {
        [Required]
        public int Id { get; set; }  

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        //[EnumDataType(typeof(Country))]
        public Country Country { get; set; }
    }
}
