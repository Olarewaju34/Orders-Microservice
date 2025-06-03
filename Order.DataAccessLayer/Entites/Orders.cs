using MongoDB.Bson.Serialization.Attributes;

namespace Order.DataAccessLayer.Entites
{
    public class Orders
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public Guid _id { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid OrderId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public Guid UserId { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public DateTime OrderDate { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Double)]  
        public decimal TotalBill { get; set; }
        public List<OrdersItem> OrderItems { get; set; } = new List<OrdersItem>();


    }
}
