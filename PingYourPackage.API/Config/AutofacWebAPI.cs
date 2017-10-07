using Autofac;
using Autofac.Integration.WebApi;
using PingYourPackage.Domain.Entities.Core;
using PingYourPackage.Domain.Entities.Extensions;
using PingYourPackage.Domain.Services;
using System.Data.Entity;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Web.Configuration;
using System.Web.Http;

namespace PingYourPackage.API.Config
{
    public class AutofacWebAPI
    {


        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }

        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //EF DbContext
            builder.RegisterType<EntitiesContext>()
           .As<DbContext>().InstancePerApiRequest();

            //
            builder.RegisterGeneric(typeof(EntityRepository<>))
                .As(typeof(IEntityRepository<>))
                .InstancePerApiRequest();
            // registration goes here

            //Services
            builder.RegisterType<CryptoService>()
                .As<ICryptoService>()
                .InstancePerApiRequest();
            builder.RegisterType<MembershipService>()
                .As<IMembershipService>()
                .InstancePerApiRequest();
            builder.RegisterType<ShipmentService>()
                .As<IShipmentService>()
                .InstancePerApiRequest();
            return builder.Build();

        }

    }
}