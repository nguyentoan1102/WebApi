using PingYourPackage.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Entities.Extensions
{
    public static class RoleRepositoryExtensions
    {
        public static Role GetSinglebyRoleName(this IEntityRepository<Role> roleRepository, string roleName) => roleRepository.GetAll().FirstOrDefault(x => x.Name == roleName);
    }
}
