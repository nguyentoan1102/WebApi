using PingYourPackage.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;

namespace PingYourPackage.API.Http
{
    internal static class HttpRequestMessageExtensions
    {

        internal static IShipmentService GetShipmentService(this HttpRequestMessage request) => request.GetService<IShipmentService>();




        internal static IMembershipService GetMembershipService(this HttpRequestMessage request) => request.GetService<IMembershipService>();

        private static TService GetService<TService>(this HttpRequestMessage request)
        {

            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));

            return service;
        }

    }
}
