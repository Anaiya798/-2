using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.CustomerDataProcessing;
using Shop.Data.Abstractions;
using Shop.Data.Models;
using Shop.Database;
using Shop.Models;
using Shop.OrderProcessing;
using Shop.ViewModels;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
namespace Shop.Utils
{
    public class AutofacConfig
    {
        public static ContainerBuilder ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Category>();
            builder.RegisterType<Reagent>();
            builder.RegisterType<Order>();
            builder.RegisterType<OrderDetail>();
            builder.RegisterType<ShopCartItem>();
            builder.RegisterType<ShopCart>().InstancePerLifetimeScope();

            builder.RegisterType<AppDBContent>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<DBObjects>().SingleInstance();
            builder.RegisterType<CategoryRepository>().As<ReagentsCategory>().WithParameter("appDBContent", new AppDBContent()).InstancePerLifetimeScope();
            builder.RegisterType<ReagentsRepository>().As<AllReagents>().WithParameter("appDBContent", new AppDBContent()).InstancePerLifetimeScope();
            builder.RegisterType<OrdersRepository>().As<AllOrders>().WithParameters(new List<Parameter> { new NamedParameter("appDBContent",  new AppDBContent()),
                new NamedParameter("shopCart", new ShopCart()) }).InstancePerLifetimeScope();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<HomeViewModel>().SingleInstance();
            builder.RegisterType<ReagentsListViewModel>().SingleInstance();
            builder.RegisterType<ShopCartViewModel>().SingleInstance();

            builder.RegisterType<CustomerInfoVerification>().WithParameter("order", new Order());
            builder.RegisterType<PhoneChecker>().Named<CustomerDataChecker>("phone-checker").SingleInstance();
            builder.RegisterType<EmailChecker>().Named<CustomerDataChecker>("email-checker").SingleInstance();
            builder.RegisterType<CreditCardChecker>().Named<CustomerDataChecker>("credit-card-checker").SingleInstance();

            builder.RegisterType<XlsxReport>().Named<IPaymentReport>("xlsx-report").SingleInstance();
            builder.RegisterType<PdfReport>().Named<IPaymentReport>("pdf-report").SingleInstance();

            return builder;



        }
    }
}
