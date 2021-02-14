namespace TempusHiring.Presentation.Models.ViewModels
{
    public class PhotoViewModel
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int WatchId { get; set; }
        public WatchViewModel Watch { get; set; }
    }
}