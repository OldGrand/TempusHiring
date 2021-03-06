﻿using TempusHiring.Presentation.Models.ViewModels.Watch;

namespace TempusHiring.Presentation.Models.ViewModels.Order
{
    public class OrderWatchLinkViewModel
    {
        public int Id { get; set; }
        public int Count { get; set; }

        public int OrderId { get; set; }
        public OrderViewModel Order { get; set; }
        public int WatchId { get; set; }
        public WatchViewModel Watch { get; set; }
    }
}
