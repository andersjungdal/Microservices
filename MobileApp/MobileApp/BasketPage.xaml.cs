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
    public partial class BasketPage : ContentPage
    {
        private static List<Product> productsInBasketListe = new List<Product>();
        public BasketPage()
        {
            InitializeComponent();
        }
        public BasketPage(List<Product> products)
        {
            InitializeComponent();
            foreach(var item in products)
            {
                productsInBasketListe.Add(item);
            }

            BindingContext = productsInBasketListe;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
    }
}