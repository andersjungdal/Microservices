using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #region unity og autofac
            //Unity
            //UnityContainer container = new UnityContainer();
            //container.RegisterType<IBasket, Basket>();

            //ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            //Autofac
            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<Basket>().As<IBasket>();

            //IContainer container = containerBuilder.Build();

            //AutofacServiceLocator asl = new AutofacServiceLocator(container);
            //CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => asl);

            //CommonServiceLocator.ServiceLocator.Current.GetInstance<Basket>();
            #endregion



            AutofacHelper.Initialize();


            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
