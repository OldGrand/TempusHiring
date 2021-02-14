using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.Presentation.Models.ViewModels.Admin
{
    public class MechanismViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PowerReserveDays { get; set; }
        public MechanismType MechanismType { get; set; }
    }
}
