using PingYourPackage.Domain.Entities.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.Domain.Entities
{
    public class ShipmentType : IEntity
    {
        [Key]
        public Guid Key { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}