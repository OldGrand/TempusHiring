﻿using System;
using System.Collections.Generic;
using TempusHiring.DataAccess.EntityEnums;

namespace TempusHiring.DataAccess.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsOrderCompleted { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderWatchLink> OrderWatchLinks { get; set; }
    }
}
