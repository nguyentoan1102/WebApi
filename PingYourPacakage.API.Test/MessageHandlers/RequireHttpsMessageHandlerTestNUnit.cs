using NUnit.Framework;
using PingYourPackage.API.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PingYourPacakage.API.Test.MessageHandlers
{
    [TestFixture]
    public class RequireHttpsMessageHandlerTestNUnit
    {
        [Test]
        public async Task Returns_Forbidden_If_Request_Is_Not_Over_HTTPS()
        {
            // TODO: Add your test code here
            //Arange
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:8080");
            var requireHttpsMessageHandler = new RequireHttpsMessageHandler();

            //Act
            var response = await requireHttpsMessageHandler.InvokeAsync(request);

            //Assert
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
    }
}
