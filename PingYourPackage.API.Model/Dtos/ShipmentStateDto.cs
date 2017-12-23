﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.API.Model.Dtos
{
    public class ShipmentStateDto
    {
        public Guid Key { get; set; }
        public Guid ShipmentKey { get; set; }
        public string ShipmentStatus { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
