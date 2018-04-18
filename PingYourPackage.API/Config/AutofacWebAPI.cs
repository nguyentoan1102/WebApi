using Autofac;
using Autofac.Integration.WebApi;
using PingYourPackage.Domain.Entities.Core;
using PingYourPackage.Domain.Services;
using System.Data.Entity;
using System.Reflection;
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
            // registration goes here
            //EF DbContext
            builder.RegisterType<EntitiesContext>()
           .As<DbContext>().InstancePerApiRequest();

            //Repository
            builder.RegisterGeneric(typeof(EntityRepository<>))
                .As(typeof(IEntityRepository<>))
                .InstancePerApiRequest();
            //Service
            builder.RegisterType<CryptService>()
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