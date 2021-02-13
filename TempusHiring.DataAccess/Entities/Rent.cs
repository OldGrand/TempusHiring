namespace TempusHiring.DataAccess.Entities
{
    public class Rent
    {
        public int Id { get; set; }

        public int LeaseId { get; set; }
        public virtual Lease Lease { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int WatchId { get; set; }
        public virtual Watch Watch { get; set; }
    }
}
