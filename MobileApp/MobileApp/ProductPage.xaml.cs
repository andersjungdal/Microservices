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
    public partial class ProductPage : ContentPage
    {
        public ProductPage()
        {
            InitializeComponent();
        }
        public void Product_Selected(object sender, SelectionChangedEventArgs e)
        {
            Models.Product product = e.CurrentSelection.First() as Models.Product;
            Navigation.PushAsync(new ProductInfo(product));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var products = await Services.ProductsService.GetProductsAsync();
            BindingContext = products;
        }
        public void GoBasket(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage());
        }
    }
}