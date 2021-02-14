namespace TempusHiring.DataAccess.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int WatchId { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
