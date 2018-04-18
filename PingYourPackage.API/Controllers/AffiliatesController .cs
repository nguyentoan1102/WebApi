using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Security;

namespace PingYourPackage.API.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class AffiliatesController : ApiController
    {

    }
}
