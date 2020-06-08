using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp
{
    public class Basket : IBasket
    {
        public List<Product> BasketProducts { get; set; }

    }
}
