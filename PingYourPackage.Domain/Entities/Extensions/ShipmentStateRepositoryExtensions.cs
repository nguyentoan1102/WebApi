using PingYourPackage.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Entities.Extensions
{
    public static class ShipmentStateRepositoryExtensions
    {
        public static IQueryable<ShipmentState> GetAllbyShipmentKey(this IEntityRepository<ShipmentState> shipmentStaterepository, Guid shipmentKey) => shipmentStaterepository.GetAll().Where(x => x.ShipmentKey == shipmentKey);
    }
}
