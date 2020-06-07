using MobileApp.Design;
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
        public List<Product> productInBasket = new List<Product>();
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

        }

        public void AddToBasket(object sender, EventArgs e)
        {
            productInBasket.Add(selectedProduct);
        }
        public void GoToBasket(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage(productInBasket));
        }


    }
}