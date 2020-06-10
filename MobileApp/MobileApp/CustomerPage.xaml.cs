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
    public partial class CustomerPage : ContentPage
    {
        public CustomerPage()
        {
            InitializeComponent();
        }
        public void Customer_Selected(object sender, SelectionChangedEventArgs e)
        {
            Models.Customer customer = e.CurrentSelection.First() as Models.Customer;
            Navigation.PushAsync(new CustomerInfo(customer));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var customers = await Services.CustomersService.GetCustomersAsync();
            BindingContext = customers;
        }

    }
}