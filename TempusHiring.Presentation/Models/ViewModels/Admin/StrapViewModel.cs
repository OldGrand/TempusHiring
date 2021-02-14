namespace TempusHiring.Presentation.Models.ViewModels.Admin
{
    public class StrapViewModel
    {
        public int Id { get; set; }
        public double Weight { get; set; }

        public int WristSizeId { get; set; }
        public virtual WristSizeViewModel WristSize { get; set; }
        public int StrapMaterialId { get; set; }
        public virtual StrapMaterialViewModel StrapMaterial { get; set; }
        public int ColorId { get; set; }
        public virtual ColorViewModel Color { get; set; }
    }
}
