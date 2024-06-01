using Microsoft.AspNetCore.Mvc;
using orderAPI.Services;
using orderAPI.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace orderAPI.Controllers
{
    [Route("api/contr")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly MongoDbService _mongoDbService;

        public OrdersController(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }


        [Route("api/contr/orders")]
         public async Task<IActionResult> CreateOrder()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var jsonString = await reader.ReadToEndAsync();
                var order = JsonSerializer.Deserialize<Order>(jsonString);
                _mongoDbService.CreateOrderAsync(order);
                return Ok(order);
            }
        }


        /* public async Task<IActionResult> CreateOrder([FromBody] OrderInputModel orderInput)
        {
            try
            {
                // Create Order object from input
                var order = new Order
                {
                    OrderNumber = orderInput.OrderNumber,
                    Quantity = orderInput.Quantity,
                    Price = orderInput.Price
                };

                // Insert into MongoDB
                await _orderCollection.InsertOneAsync(order);

                return Ok("Order created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }*/










        /*
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            await _mongoDbService.CreateOrderAsync(order);
            return Ok();
        }
        */
    }
}















/*using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using orderAPI.Services.MongoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace orderAPI
/*{

[Route("api/ordercontr")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly MongoService _mongoService;

    public OrderController(MongoService mongoService)
    {
        _mongoService = mongoService;
    }

    [Route("api/ordercontr/createorder")]
    [HttpPost]
    public IActionResult InsertOrderFromFile()
    {
        using (var streamReader = new StreamReader(Request.Body))
        {
            var jsonString = streamReader.ReadToEnd();
            var order = JsonSerializer.Deserialize<Order>(jsonString);
            _mongoService.InsertOrder(order);
            return Ok("Order inserted successfully.");
        }
    /}
*/

    
  /*      [Route("api/ordercontr/getorder")]
       / [HttpGet]
        public IActionResult GetOrders()
        /*{
            var orders = _mongoService.Find(new BsonDocument()).ToList();
            return Ok(orders);
        }
    }
/}*/
