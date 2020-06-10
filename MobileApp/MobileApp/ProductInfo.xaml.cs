using Autofac;
using CommonServiceLocator;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductInfo : ContentPage
    {
        public Basket basket { get; set; }
        //Basket basket = new Basket();
        public List<Product> productinbasket = new List<Product>();
        private Product selectedProduct;

        public ProductInfo()
        {
            InitializeComponent();
        }
        public ProductInfo(Models.Product product)
        {
            InitializeComponent();
            BindingContext = product;
            selectedProduct = product;
            basket = AutofacHelper.container.Resolve<Basket>();            
        }

        public void AddToBasket(object sender, EventArgs e)
        {
            if(basket.BasketProducts == null)
            {
                basket.BasketProducts = new List<Product>();
            }
            
            basket.BasketProducts.Add(selectedProduct);
            Navigation.PopAsync();


        }
        public void GoToBasket(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage());
        }

    }
}