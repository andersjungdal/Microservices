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

        //private Product selectproduct;
        private List<Product> selectedproducts;
        public Basket Basket { get; set; }
        Models.Product o;


        //private readonly IBasket basket;

        public BasketPage()
        {
            InitializeComponent();
            Basket = AutofacHelper.container.Resolve<Basket>();
            selectedproducts = new List<Product>();
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

            var selected = e.CurrentSelection;
            

                if(selectedproducts.Count < selected.Count)
                {
                    selectedproducts.Add(selected.ElementAt(selected.Count-1) as Models.Product);
                }

                if (selectedproducts.Count > selected.Count)
                {
                var currentSelectionToList = new List<Models.Product>();
                foreach (var item in selected)
                {
                    currentSelectionToList.Add(item as Models.Product);
                }
                    List<Product> Unselected = selectedproducts.Except(currentSelectionToList).Concat(selectedproducts.Except(currentSelectionToList)).ToList();
                    Unselected.RemoveAt(Unselected.Count - 1);
                    Product removeSpecificProduct = Unselected.Single();
                    selectedproducts.Remove(removeSpecificProduct);                 
                }
            
            
            //if (selected.Count == 0)
            //{
            //    selectedproducts.RemoveAt(selectedproducts.Count - 1);
            //}
            //selected = new List<Product>();

        }

        public void RemoveSelectedItems(object sender, EventArgs e)
        {
            List<Models.Product> templist = new List<Product>();

            foreach (var item in selectedproducts)
            {
                templist.Add(item);
            }
            if(selectedproducts.Count != 0)
            {
                foreach (var item in templist)
                {
                    Basket.BasketProducts.Remove(item);
                    selectedproducts.RemoveAt(selectedproducts.Count - 1);
                }
            }
            else
            {
                DisplayAlert("Notification", "Select an item an try again", "OK");
            }

            InitializeComponent();
        }

        public void SeeSelectedItem(object sender, EventArgs e)
        {
             

            if (selectedproducts.Count == 1)
            {
                o = selectedproducts.Single();

                Navigation.PushAsync(new SeeSpecificBasketItem(o));
            }
            else if(selectedproducts.Count > 1)
            {
                DisplayAlert("Notification", "You can only see one product at a time", "OK");
            }
            else
            {
                DisplayAlert("Notification", "Select an item an try again", "OK");
            }
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