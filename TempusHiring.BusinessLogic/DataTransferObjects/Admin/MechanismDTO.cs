using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.BusinessLogic.DataTransferObjects.Admin
{
    public class MechanismDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PowerReserveDays { get; set; }
        public MechanismType MechanismType { get; set; }
    }
}
