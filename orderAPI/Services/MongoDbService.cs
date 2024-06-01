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

        public async Task CreateOrderAsync(Order order)
        {
            await _ordersCollection.InsertOneAsync(order);
        }
    }
}











/*using MongoDB.Driver;
using orderAPI.Models;

namespace orderAPI.Services
//{
public class MongoService
{
    private readonly IMongoCollection<Order> _orderCollection;

    public MongoService(string mongoUrl, string databaseName, string collectionName)
    {
        var client = new MongoClient(mongoUrl);
        var database = client.GetDatabase(databaseName);
        _orderCollection = database.GetCollection<Order>(collectionName);
    }

  /  public void InsertOrder(Order order)
 /   {
        _orderCollection.InsertOne(order);
    }
}
}*/