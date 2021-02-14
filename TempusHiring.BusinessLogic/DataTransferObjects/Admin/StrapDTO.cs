namespace TempusHiring.BusinessLogic.DataTransferObjects.Admin
{
    public class StrapDTO
    {
        public int Id { get; set; }
        public double Weight { get; set; }

        public int WristSizeId { get; set; }
        public WristSizeDTO WristSize { get; set; }
        public int StrapMaterialId { get; set; }
        public StrapMaterialDTO StrapMaterial { get; set; }
        public int ColorId { get; set; }
        public ColorDTO Color { get; set; }
    }
}
