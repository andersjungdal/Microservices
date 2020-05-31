using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BlazorApp.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Inventory { get; set; }
    }
}
