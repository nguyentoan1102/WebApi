using PingYourPackage.API.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PingYourPacakage.API.Test.MessageHandlers
{
    public class RequireHttpsMessagehandlerTest
    {
        [Fact]
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
            Assert.Equal(
            HttpStatusCode.Forbidden,
            response.StatusCode);
        }
        [Fact]
        public async Task Returns_Delegated_StatusCode_When_Request_Is_Over_HTTPS()
        {
            // Arange
            var request = new HttpRequestMessage(
            HttpMethod.Get, "https://localhost:8080");
            var requireHtttpsMessageHandler =
            new RequireHttpsMessageHandler();
            // Act
            var response = await requireHtttpsMessageHandler.InvokeAsync(request);
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


    }
}
