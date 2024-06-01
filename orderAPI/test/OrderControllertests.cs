using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace orderAPI.test
{
    public class OrderControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public OrderControllerTests(WebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostOrder_ReturnsSuccessStatusCode()
        {
            // Arrange
            var content = new StringContent("{\"orderId\": \"1ooo3\", \"Quantity\": \"289\", \"total_price\": 1546}", Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/orders", content);

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}