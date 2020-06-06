using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Design
{
    public class ProductModel
    {
        public static Product Product
        {
            get
            {
                return new Product
                {
                    Id = 512,
                    Name = "V-Neck T-Shirt",
                    Price=23,
                    Inventory=45
                };
            }
        }



    }
}
