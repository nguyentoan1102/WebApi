using PingYourPackage.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Services
{
    public class UserWithRoles
    {

        public User User { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
