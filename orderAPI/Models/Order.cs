using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace orderAPI.Models
{
public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string OrderNumber { get; set; }

    
    
    public int Quantity { get; set; }

    public decimal Price { get; set; }
}
}