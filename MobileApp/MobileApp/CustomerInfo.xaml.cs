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
    public partial class CustomerInfo : ContentPage
    {
        public CustomerInfo()
        {
            InitializeComponent();
        }
        public CustomerInfo(Models.Customer customer)
        {
            InitializeComponent();
            BindingContext = customer;
        }

    }
}