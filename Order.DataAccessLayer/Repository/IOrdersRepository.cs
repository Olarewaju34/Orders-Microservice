using MongoDB.Driver;
using Order.DataAccessLayer.Entites;

namespace Order.DataAccessLayer.Repository
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Orders>> GetOrders();
        Task<IEnumerable<Orders?>> GetOrdersByCondition(FilterDefinition<Orders> filter);
        Task<Orders?> GetOrderByCondition(FilterDefinition<Orders> filter);
        Task<Orders?> AddOrder(Orders orders);
        Task<Orders?> UpdateOrder(Orders orders);
        Task<bool> DeleteOrder(Guid id);

    }
}
