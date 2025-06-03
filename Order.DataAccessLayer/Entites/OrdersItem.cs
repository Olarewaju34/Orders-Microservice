using MongoDB.Bson.Serialization.Attributes;

namespace Order.DataAccessLayer.Entites;

public class OrdersItem
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]

    public Guid _id { get; set; }
    [BsonRepresentation(MongoDB.Bson.BsonType.String)]
    public Guid ProductId { get; set; }
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]

    public decimal Price { get; set; }
    [BsonRepresentation(MongoDB.Bson.BsonType.Int32)]

    public int Quantity { get; set; }
    [BsonRepresentation(MongoDB.Bson.BsonType.Double)]

    public decimal TotalPrice { get;set; }
}

