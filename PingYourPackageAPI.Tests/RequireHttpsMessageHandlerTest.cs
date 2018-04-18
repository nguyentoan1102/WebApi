using NUnit.Framework;
using PingYourPackage.API.MessageHandlers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PingYourPackageAPI.Tests
{
    [TestFixture]
    public class RequireHttpsMessageHandlerTest
    {
        [Test]
        public async Task Returns_Forbidden_If_Request_Is_Not_Over_HTTPS()
        {
            // Arange
            var request = new HttpRequestMessage(
            HttpMethod.Get, "http://localhost:8080");
            var requireHtttpsMessageHandler =
            new RequireHttpsMessageHandler();
            // Act
            var response = await requireHtttpsMessageHandler.InvokeAsync(request);
            // Assert
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}
