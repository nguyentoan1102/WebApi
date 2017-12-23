using PingYourPackage.API.Model;
using PingYourPackage.API.Model.Dtos;
using PingYourPackage.API.Model.RequestCommands;
using PingYourPackage.Domain.Entities.Extensions;
using PingYourPackage.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PingYourPackage.API.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ShipmentController : ApiController
    {
        private readonly IShipmentService _shipmentService;
        public ShipmentController(IShipmentService shipmentService)
        {

            _shipmentService = shipmentService;
        }
        public PaginatedDto<ShipmentDto> GetShipments(PaginatedRequestCommand cmd)
        {

            var shipments = _shipmentService
                .GetShipments(cmd.Page, cmd.Take);

            return shipments.ToPaginatedDto(shipments.Select(sh => sh.ToShipmentDto()));
        }

        public ShipmentDto GetShipment(Guid key)
        {

            var shipment = _shipmentService.GetShipment(key);
            if (shipment == null)
            {

                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return shipment.ToShipmentDto();
        }
    }
}
