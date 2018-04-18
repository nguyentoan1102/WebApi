using PingYourPackage.Domain.Entities.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PingYourPackage.Domain.Entities
{
    [Table("Roles")]
    public class Role : IEntity
    {
        [Key]
        public Guid Key { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
        public Role()
        {
            UserInRoles = new HashSet<UserInRole>();
        }
    }
}