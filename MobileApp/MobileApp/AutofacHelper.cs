using Autofac;
using Autofac.Extras.CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp
{
    public static class AutofacHelper
    {
        public static IContainer container;
        public static void Initialize()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<Basket>().SingleInstance();


            //CommonServiceLocator.ServiceLocator.Current.GetInstance<Basket>();

            container = containerBuilder.Build();

            //AutofacServiceLocator asl = new AutofacServiceLocator(container);

            //CommonServiceLocator.ServiceLocator.SetLocatorProvider(() => asl);


        }
    }
}
