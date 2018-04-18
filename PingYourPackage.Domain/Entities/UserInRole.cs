using PingYourPackage.Domain.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PingYourPackage.Domain.Entities
{
    [Table("UserInRoles")]
    public class UserInRole : IEntity
    {
        [Key]
        public Guid Key { get; set; }
        public Guid UserKey { get; set; }
        public Guid RoleKey { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }

    }
}