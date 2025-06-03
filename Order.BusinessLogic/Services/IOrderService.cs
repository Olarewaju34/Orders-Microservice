using MongoDB.Driver;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;

namespace Order.BusinessLogic.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponse?>> GetOrders();
        Task<List<OrderResponse?>> GetOrdersByCondition(FilterDefinition<Orders> filter);
            Task<OrderResponse?> GetOrderByCondtion(FilterDefinition<Orders> filter);
        Task<OrderResponse?> AddOrder(OrderAddRequest request);
        Task<OrderResponse?> UpdateOrder(OrderUpdateRequest request);
        Task<bool> DeleteOrder(Guid id);
    }
}
