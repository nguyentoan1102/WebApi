using PingYourPackage.Domain.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPackage.Domain.Entities.Extensions
{
    public static class ShipmentTypeRepositoryExtensions
    {
        public static ShipmentType GetSingleByName(this IEntityRepository<ShipmentType> shipmentTypRepository, string name) => shipmentTypRepository.GetAll().FirstOrDefault(x => x.Name == name);

    }
}
