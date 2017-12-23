using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PingYourPackage.Domain.Entities;
using PingYourPackage.Domain.Entities.Core;
using PingYourPackage.Domain.Entities.Extensions;

namespace PingYourPackage.Domain.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IEntityRepository<ShipmentType> _shipmentTypeRepository;
        private readonly IEntityRepository<Shipment> _shipmentRepository;
        private readonly IEntityRepository<ShipmentState> _shipmentStateRepository;
        private readonly IEntityRepository<Affiliate> _affiliateRepository;
        private readonly IMembershipService _membershipService;

        public ShipmentService(IEntityRepository<ShipmentType> shipmentTypeRepository, IEntityRepository<Shipment> shipmentRepository,
           IEntityRepository<ShipmentState> shipmentStateRepository, IEntityRepository<Affiliate> affiliateRepository,
           IMembershipService membershipService)
        {

            _shipmentTypeRepository = shipmentTypeRepository;
            _shipmentRepository = shipmentRepository;
            _shipmentStateRepository = shipmentStateRepository;
            _affiliateRepository = affiliateRepository;
            _membershipService = membershipService;
        }




        public OperationResult<Affiliate> AddAffiliate(Guid userKey, Affiliate affiliate)
        {
            var userResult = _membershipService.GetUser(userKey);
            if (userResult == null || !userResult.Roles.Any(role => role.Name.Equals("affiliate", StringComparison.OrdinalIgnoreCase)) || _affiliateRepository.GetSingle(userKey) != null)
            {
                return new OperationResult<Affiliate>(false);
            }
            affiliate.Key = userKey;
            affiliate.CreatedOn = DateTime.Now;
            _affiliateRepository.Add(affiliate);
            _affiliateRepository.Save();
            affiliate.User = userResult.User;
            return new OperationResult<Affiliate>(true)
            {
                Entity = affiliate
            };
        }

        public OperationResult<Shipment> AddShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ShipmentState> AddShipmentState(Guid shipmentKey, ShipmentStatus status)
        {
            throw new NotImplementedException();
        }

        public OperationResult<ShipmentType> AddShipmentType(ShipmentType shipmnetType)
        {
            if (_shipmentTypeRepository.GetSingleByName(shipmnetType.Name) != null)
            {
                return new OperationResult<ShipmentType>(false);
            }
            shipmnetType.Key = Guid.NewGuid();
            shipmnetType.CreatedOn = DateTime.Now;
            _shipmentTypeRepository.Add(shipmnetType);
            _shipmentTypeRepository.Save();
            return new OperationResult<ShipmentType>(true)
            {
                Entity = shipmnetType
            };

        }

        public Affiliate GetAffiliate(Guid key)
        {
            var affiliate = _affiliateRepository.AllIncluding(x => x.User).FirstOrDefault(x => x.Key == key);
            return affiliate;

        }

        public PaginatedList<Affiliate> GetAffiliates(int pageIndex, int pageSize)
        {
            var affiliates = _affiliateRepository
               .AllIncluding(x => x.User).OrderBy(x => x.CreatedOn)
               .ToPaginatedList(pageIndex, pageSize);

            return affiliates;
        }

        public Shipment GetShipment(Guid key)
        {
            throw new NotImplementedException();
        }

        public PaginatedList<Shipment> GetShipments(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public PaginatedList<Shipment> GetShipments(int pageIndex, int pageSize, Guid affiliateKey)
        {
            var shipments = _shipmentRepository
                .GetShipmentsByAffiliateKey(affiliateKey)
                .OrderBy(x => x.CreatedOn)
                .ToPaginatedList(pageIndex, pageSize);

            return shipments;
        }

        public IEnumerable<ShipmentState> GetShipmentStates(Guid shipmentKey)
        {
            throw new NotImplementedException();
        }

        public ShipmentType GetShipmentType(Guid key)
        {
            var shipmentType = _shipmentTypeRepository.GetSingle(key);
            return shipmentType;
        }

        public PaginatedList<ShipmentType> GetShipmentTypes(int pageIndex, int pageSize)
        {
            var shipmentType = _shipmentTypeRepository.Paginate(pageIndex, pageSize, x => x.CreatedOn);
            return shipmentType;
        }

        public bool IsAffiliateRelatedToUser(Guid affiliateKey, string username)
        {
            throw new NotImplementedException();
        }

        public OperationResult RemoveShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public Affiliate UpdateAffiliate(Affiliate affiliate)
        {
            throw new NotImplementedException();
        }

        public Shipment UpdateShipment(Shipment shipment)
        {
            throw new NotImplementedException();
        }

        public ShipmentType UpdateShipmentType(ShipmentType shipmentType)
        {
            _shipmentTypeRepository.Edit(shipmentType);
            _shipmentTypeRepository.Save();
            return shipmentType;
        }
    }
}
