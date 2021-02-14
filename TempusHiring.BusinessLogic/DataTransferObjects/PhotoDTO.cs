namespace TempusHiring.BusinessLogic.DataTransferObjects
{
    public class PhotoDTO
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int WatchId { get; set; }
        public WatchDTO Watch { get; set; }
    }
}
