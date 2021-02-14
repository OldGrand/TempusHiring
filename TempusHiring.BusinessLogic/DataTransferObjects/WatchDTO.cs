using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.BusinessLogic.DataTransferObjects
{
    public class WatchDTO
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public int CountInStock { get; set; }
        public int SaledCount { get; set; }

        public int ManufacturerId { get; set; }
        public virtual ManufacturerDTO Manufacturer { get; set; }
        public int GlassMaterialId { get; set; }
        public virtual GlassMaterialDTO GlassMaterial { get; set; }
        public int MechanismId { get; set; }
        public virtual MechanismDTO Mechanism { get; set; }
        public int BodyMaterialId { get; set; }
        public virtual BodyMaterialDTO BodyMaterial { get; set; }
        public int StrapId { get; set; }
        public virtual StrapDTO Strap { get; set; }
    }
}