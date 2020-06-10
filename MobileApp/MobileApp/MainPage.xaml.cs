using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Basket basket = new Basket();
        public MainPage()
        {
            InitializeComponent();
        }
        public void GoToProductPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductPage());
        }
        public void GoToCustomerPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CustomerPage());
        }
        public void GoToTheBasket(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasketPage());
        }
    }
}
