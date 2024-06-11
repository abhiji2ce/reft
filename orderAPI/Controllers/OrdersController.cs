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
            Console.WriteLine("12");
        }


        [Route("api/contr/orders")]
         public async Task<IActionResult> CreateOrder()
         {
         try
           {
            using (var reader = new StreamReader(Request.Body))
              {
                Console.WriteLine("1");
                var jsonString = await reader.ReadToEndAsync();
                 Console.WriteLine("2");
                var order = JsonSerializer.Deserialize<Order>(jsonString);
                 Console.WriteLine("3");
                 if (order == null)
                {
                    // Order not found, redirect to error page or show a message
                   // return RedirectToAction("OrderNotFound", "Error");
                    Console.WriteLine("order",1);
                    return Ok(order);
                }
            else
                {
                    // Order found, display order details
                    await  _mongoDbService.CreateOrderAsync(order);
                    Console.WriteLine("Order Genarated & returned to Controller",order);
                    return Ok(order);
                }
                
                
              }

             // return RedirectToAction("OtherAction", "OtherController");
           }

           catch (Exception ex)
           {
                // Handle other exceptions
                Console.WriteLine($"Error accessing MongoDB Service: {ex.Message}");
                
           }
         }
    }
}