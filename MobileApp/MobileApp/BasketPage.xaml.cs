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
        private List<Product> selectedproducts;
        public Basket Basket { get; set; }
        Models.Product navigationObject;
        public BasketPage()
        {
            InitializeComponent();
            Basket = AutofacHelper.container.Resolve<Basket>();
            selectedproducts = new List<Product>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = Basket.BasketProducts;
        }
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
                navigationObject = selectedproducts.Single();

                Navigation.PushAsync(new SeeSpecificBasketItem(navigationObject));
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
    }
}