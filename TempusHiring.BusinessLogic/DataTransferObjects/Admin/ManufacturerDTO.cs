using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.BusinessLogic.DataTransferObjects.Admin
{
    public class ManufacturerDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Country Country { get; set; }
    }
}
