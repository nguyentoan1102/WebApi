﻿using PingYourPackage.Domain.Entities.Core;
using PingYourPackage.Domain.Entities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Entities.Extensions
{
    public static class ShipmentRepositoryExtensions
    {

        public static IQueryable<Shipment> GetShipmentsByAffiliateKey(
        this IEntityRepository<Shipment> shipmentRepository, Guid affiliateKey) => shipmentRepository.AllIncluding(x => x.ShipmentType, x => x.ShipmentStates).Where(x => x.AffiliateKey == affiliateKey);

        public static IQueryable<Shipment> GetNotDeliveredShipments(
            this IEntityRepository<Shipment> shipmentRepository)
        {

            var shipmenents = from shipment in shipmentRepository.AllIncluding(
                                   x => x.ShipmentType, x => x.ShipmentStates)
                              where shipment.ShipmentStates.Any(
                                    x => x.ShipmentStatus != ShipmentStatus.Delivered)
                              select shipment;

            return shipmenents;
        }


        public static IQueryable<Shipment> GetNotDeliveredShipments(
        this IEntityRepository<Shipment> shipmentRepository, Guid affiliateKey) => shipmentRepository.GetNotDeliveredShipments()
            .Where(x => x.AffiliateKey == affiliateKey);
    }
}

