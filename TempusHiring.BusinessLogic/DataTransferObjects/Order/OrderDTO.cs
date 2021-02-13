﻿using System;
using System.Collections.Generic;

namespace TempusHiring.BusinessLogic.DataTransferObjects.Order
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public DateTime OrderDate { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsOrderCompleted { get; set; }

        public int UserId { get; set; }
        public UserDTO User { get; set; }
        public ICollection<OrderWatchLinkDTO> OrderWatchLinks { get; set; }
    }
}