using TempusHiring.DataAccess.EntityEnums;
using TempusHiring.Presentation.Models.ViewModels.Admin;

namespace TempusHiring.Presentation.Models.ViewModels
{
    public class WatchViewModel
    {
        public int Id { get; set; }
        public double Diameter { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public Gender Gender { get; set; }
        public int CountInStock { get; set; }
        public int SaledCount { get; set; }

        public int ManufacturerId { get; set; }
        public virtual ManufacturerViewModel Manufacturer { get; set; }
        public int GlassMaterialId { get; set; }
        public virtual GlassMaterialViewModel GlassMaterial { get; set; }
        public int MechanismId { get; set; }
        public virtual MechanismViewModel Mechanism { get; set; }
        public int BodyMaterialId { get; set; }
        public virtual BodyMaterialViewModel BodyMaterial { get; set; }
        public int StrapId { get; set; }
        public virtual StrapViewModel Strap { get; set; }
    }
}
