using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp
{
    public interface IBasket
    {
        List<Product> BasketProducts { get; set; }
    }
}
