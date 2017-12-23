using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PingYourPackage.API.Model.RequestModels
{
    public class ShipmentStateRequestModel
    {
        [Required]

        public string ShipmentStatus { get; set; }
    }
}
