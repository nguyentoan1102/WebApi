using PingYourPackage.Domain.Entities.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PingYourPackage.Domain.Entities
{
    [Table("Users")]
    public class User : IEntity
    {
        [Key]
        public Guid Key { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]

        public string HashedPassword { get; set; }
        [Required]
        [StringLength(200)]

        public string Salt { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public virtual ICollection<UserInRole> UserInRoles { get; set; }
        public virtual Affiliate Affiliate { get; set; }
        public User()
        {
            UserInRoles = new HashSet<UserInRole>();
            Affiliate = new Affiliate();
        }
    }
}