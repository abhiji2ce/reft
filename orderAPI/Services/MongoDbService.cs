using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using orderAPI.Models;


namespace orderAPI.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Order> _ordersCollection;

        public MongoDbService(string connectionString, string databaseName)
        {
        var client = new MongoClient(connectionString);
        _database = client.GetDatabase(databaseName);
         _ordersCollection = _database.GetCollection<Order>("order");
        }

      public async Task CreateOrderAsync(Order order){
        try
        {

             Console.WriteLine("contr1",order);

             if (order == null)
                {
                    // Order not found, redirect to error page or show a message
                    Console.WriteLine("Order cont null value",order);
                }

             else

                {
                    // Order found, display order details
                    await _ordersCollection.InsertOneAsync(order);
                    Console.WriteLine("Order Genarated",order);
                }
        }
             
        catch (Exception ex)
        {
                Console.WriteLine($"Error Executing  MongoDB Service inside: {ex.Message}");
        }

      }     
    }    
  }