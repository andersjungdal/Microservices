﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BlazorApp.Shared.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
