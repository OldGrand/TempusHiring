﻿namespace TempusHiring.BusinessLogic.DataTransferObjects
{
    public class OrderWatchLinkDTO
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int WatchId { get; set; }
        public WatchDTO Watch { get; set; }
    }
}
