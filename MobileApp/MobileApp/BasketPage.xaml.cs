using Autofac;
using CommonServiceLocator;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Product = MobileApp.Models.Product;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : ContentPage
    {

        private Product selectproduct;
        private List<Product> products = new List<Product>();
        public Basket Basket { get; set; }

        //private readonly IBasket basket;

        public BasketPage()
        {
            InitializeComponent();
            Basket = AutofacHelper.container.Resolve<Basket>();
            //foreach (var item in Basket.BasketProducts)
            //{
            //    products.Add(item);
            //}

            //ServiceLocator.Current.GetInstance<Basket>();
        }
        //public BasketPage()
        //{
        //    InitializeComponent();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = Basket.BasketProducts;
        }
        //public void AddToBasket(object sender, EventArgs e)
        //{
        //productInBasket.Add(selectedProduct);
        //productsInBasketListe.Add()
        //}
        public void Product_Select(object sender, SelectionChangedEventArgs e)
        {
            Models.Product product = e.CurrentSelection.First() as Models.Product;
            selectproduct = product;

        }

        public void RemoveSelectedItems(object sender, EventArgs e)
        {
            Basket.BasketProducts.Remove(selectproduct);
            Navigation.PopAsync();
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    base.OnPropertyChanged(propertyName);

        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //}
        //public void Refresh(object sender, PropertyChangingEventArgs e)
        //{
        //    e.
        //}

    }
}