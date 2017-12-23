using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace PingYourPackage.API.Test.Integration.cs.Common
{
    public class NullcurrentPrincipalAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest)
        {
            Thread.CurrentPrincipal = null;
        }
    }
}
