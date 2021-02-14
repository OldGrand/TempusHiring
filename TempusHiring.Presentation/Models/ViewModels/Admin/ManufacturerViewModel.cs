using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.Presentation.Models.ViewModels.Admin
{
    public class ManufacturerViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Country Country { get; set; }
    }
}
