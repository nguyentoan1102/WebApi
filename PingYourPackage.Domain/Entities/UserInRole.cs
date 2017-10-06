using PingYourPackage.Domain.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.Domain.Entities
{
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