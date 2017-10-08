using PingYourPackage.API.Http;
using PingYourPackage.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using WebApiDoodle.Web;
using WebApiDoodle.Web.MessageHandlers;

namespace PingYourPackage.API.MessageHandlers
{
    public class PingYourPackageAuthhandler : BasicAuthenticationHandler
    {
        protected override Task<IPrincipal> AuthenticateUserAsync(HttpRequestMessage request, string username, string password, CancellationToken cancellationToken)
        {
            var membershipService = request.GetMembershipService();
            var validUserCtx = membershipService.ValidateUser(username, password);
            return Task.FromResult(validUserCtx.Principal);
        }

    }
    internal static class HttpRequestMessageExtensions
    {
        internal static IMembershipService getMembershipService(this HttpRequestMessage request) => request.GetService<IMembershipService>();
        private static TService getService<TService>(this HttpRequestMessage request)
        {
            IDependencyScope dependencyScope = request.GetDependencyScope();
            TService service = (TService)dependencyScope.GetService(typeof(TService));
            return service;
        }
    }
}
