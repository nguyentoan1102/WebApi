using Autofac;
using Moq;
using PingYourPackage.API.Model.Dtos;
using PingYourPackage.API.Test.Integration.cs.Common;
using PingYourPackage.API.Test.Integration.cs.TestHelpers;
using PingYourPackage.Domain.Entities;
using PingYourPackage.Domain.Entities.Extensions;
using PingYourPackage.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PingYourPackage.API.Test.Integration.cs.Controllers
{
    public class ShipmentsControllerIntegrationTest
    {
        private static readonly string ApiBaseRequestPath = "api/shipments";
        public class GetShipments
        {

            private static IContainer GetContainer()
            {
                var shipments = GetDummyShipments(new[] {
                    Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()
                });

                Mock<IShipmentService> shipmentSrvMock = new Mock<IShipmentService>();
                shipmentSrvMock.Setup(ss =>
                    ss.GetShipments(
                        It.IsAny<int>(), It.IsAny<int>()
                    )
                ).Returns<int, int>(
                    (pageIndex, pageSize) =>
                        shipments.AsQueryable()
                            .ToPaginatedList(pageIndex, pageSize)
                );

                return GetContainerThroughMock(shipmentSrvMock);
            }
            private static IContainer GetContainerThroughMock(Mock<IShipmentService> shipmentSrvMock)
            {
                var containerbuilder = GetInitialContainerbuilder();
                containerbuilder.Register(c => shipmentSrvMock.Object)
                    .As<IShipmentService>()
                    .InstancePerRequest();
                return containerbuilder.Build();
            }

            private static ContainerBuilder GetInitialContainerbuilder()
            {
                var builder = IntegrationTestHelper.GetEmptyContainerBuilder();
                var mockMemSrv = ServicesMockHelper.GetInitialMembershipServiceMock();
                builder.Register(c => mockMemSrv.Object).As<IMembershipService>().InstancePerRequest();
                return builder;
            }

            private static IEnumerable<Shipment> GetDummyShipments(Guid[] keys)
            {
                var shipmentTypekeys = new Guid[] { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
                for (int i = 0; i < 3; i++)
                {
                    yield return new Shipment
                    {
                        Key = keys[i],
                        AffiliateKey = Guid.NewGuid(),
                        ShipmentTypeKey = shipmentTypekeys[i],
                        Price = 12.23M * (i + 1),
                        ReceiverName = string.Format("Receiver {0} Name", i),
                        ReceiverSurname = string.Format("Receiver {0} Surname", i),
                        ReceiverAddress = string.Format("Receiver {0} Address", i),
                        ReceiverCity = string.Format("Receiver {0} City", i),
                        ReceiverCountry = string.Format("Receiver {0} Country", i),
                        ReceiverTelephone = string.Format("Receiver {0} Country", i),
                        ReceiverZipCode = "12345",
                        ReceiverEmail = "foo@example.com",
                        CreatedOn = DateTime.Now,
                        ShipmentType = new ShipmentType { Key = shipmentTypekeys[i], Name = "Small", Price = 4.19M, CreatedOn = DateTime.Now, },
                        ShipmentStates = new List<ShipmentState> { new ShipmentState { Key = Guid.NewGuid(), ShipmentKey = keys[i], ShipmentStatus = ShipmentStatus.Ordered } }
                    };

                }
            }
            [Fact, NullcurrentPrincipal]
            public Task Returns_200_And_Shipments_If_request_Authorized()
            {
                //arrange
                var config = IntegrationTestHelper.GetInitialIntegrationTestConfig(GetContainer());
                var request = HttpRequestMessageHelper.ConstructRequest(httpMethod: HttpMethod.Get, uri: string.Format(
                    "https://localhost/{0}?page={1}&take={2}",
                    ApiBaseRequestPath, 1, 2),
                    mediaType: "application/json",
                    username: Common.Constants.ValidAdminUserName,
                    password: Common.Constants.ValidAdminPassword);
                return IntegrationTestHelper.TestForPaginatedDtoAsync<ShipmentDto>(config, request, expectedPageIndex: 1, expectedTotalItemsCount: 2, expectedCurrentItemsCount: 2, expectedTotalPageCount: 3, expectedHasNextPageResult: true, expectedHasPreviousPageResult: false);
            }


        }




    }
}
