using MongoDB.Driver;
using Order.DataAccessLayer.Entites;

namespace Order.DataAccessLayer.Repository
{
    public class OrderRepository : IOrdersRepository
    {
        private readonly IMongoCollection<Orders> _orderCollection;
        private readonly string _collectionName = "orders";

        public OrderRepository(IMongoDatabase mongoDatabase)
        {
            _orderCollection = mongoDatabase.GetCollection<Orders>(_collectionName);
        }
        public async Task<Orders?> AddOrder(Orders orders)
        {
            orders.OrderId = Guid.NewGuid();
            await _orderCollection.InsertOneAsync(orders);
            return orders;
        }

        public async Task<bool> DeleteOrder(Guid id)
        {
            var filter = Builders<Orders>.Filter.Eq(o => o.OrderId, id);
            Orders? orderExist = (await _orderCollection.FindAsync(filter)).FirstOrDefault();
            if (orderExist is null)
            {
                return false;
            }
            var result = await _orderCollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;

        }

        public async Task<Orders?> GetOrderByCondition(FilterDefinition<Orders> filter)
        {
            return (await _orderCollection.FindAsync(filter)).FirstOrDefault();
        }

        public async Task<IEnumerable<Orders>> GetOrders()
        {
            return (await _orderCollection.FindAsync(Builders<Orders>.Filter.Empty)).ToList();
        }

        public async Task<IEnumerable<Orders?>> GetOrdersByCondition(FilterDefinition<Orders> filter)
        {
            return (await _orderCollection.FindAsync(filter)).ToList();
        }

        public async Task<Orders?> UpdateOrder(Orders orders)
        {
            var filter = Builders<Orders>.Filter.Eq(o => o.OrderId, orders.OrderId);
            if (filter is null)
            {
                return null;
            }
           var updatedObject = await _orderCollection.ReplaceOneAsync(filter, orders);
            return orders;
        }
    }
}
