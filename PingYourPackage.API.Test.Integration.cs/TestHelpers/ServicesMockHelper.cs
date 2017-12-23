using Moq;
using PingYourPackage.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.API.Test.Integration.cs.TestHelpers
{
    public class ServicesMockHelper
    {
        internal static Mock<IMembershipService> GetInitialMembershipServiceMock()
        {
            var membershipServiceMock = new Mock<IMembershipService>();
            var users = new[]
            {
                new {Name=Constants.ValidAdminUserName,
                Password=Constants.ValidAffiliatePassword,
                Roles=new[] {"Admin"}
                },
                new {Name = Constants.ValidEmployeeUserName,
                    Password = Constants.ValidEmployeePassword,
                    Roles = new[] { "Employee" }
                    },
                    new {
                    Name = Constants.ValidAffiliateUserName,
                    Password = Constants.ValidAffiliatePassword,
                    Roles = new[] { "Affiliate" }
                    }
            }.ToDictionary(user => user.Name, user => user);
            membershipServiceMock.Setup(ms => ms.ValidateUser(
               It.IsAny<string>(), It.IsAny<string>())
           ).Returns<string, string>(
               (username, password) =>
               {

                   var user = users.FirstOrDefault(x => x.Key.Equals(
                       username, StringComparison.OrdinalIgnoreCase)).Value;

                   var validUserContext = (user != null) ? new ValidUserContext
                   {
                       Principal = new GenericPrincipal(
                               new GenericIdentity(user.Name), user.Roles
                           )
                   } : new ValidUserContext();

                   return validUserContext;
               }
           );

            return membershipServiceMock;
        }
    }

    internal class Constants
    {
        internal const string ValidAffiliateUserName = "tugberkAff";
        internal const string ValidAffiliatePassword = "86421";
        internal const string ValidEmployeeUserName = "tugberkEmp";
        internal const string ValidEmployeePassword = "13579";
        internal const string ValidAdminUserName = "tugberkAdmin";
        internal const string ValidAdminPassword = "12345678";
        internal const string InvalidUserName = "tgbrk";
        internal const string InvalidPassword = "87654321";
    }
}
