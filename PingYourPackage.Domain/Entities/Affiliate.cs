using PingYourPackage.Domain.Entities;
using PingYourPackage.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.Domain.Entities
{
    public class Affiliate : IEntity
    {
        [Key]
        public Guid Key { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string TelephoneNumber { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        [Required]
        public User User { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
        public Affiliate()
        {
            Shipments = new HashSet<Shipment>();
        }
    }
}