using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Order.BusinessLogic.DTO;
using Order.BusinessLogic.Services;
using Order.DataAccessLayer.Entites;
using Order.DataAccessLayer.Repository;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Order.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService ordersService)
        {
            _orderService = ordersService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<IEnumerable<OrderResponse?>> GetAllOrders()
        {

            var orders = await _orderService.GetOrders();
            return orders;
        }

        // GET api/<OrderController>/5
        [HttpGet("search/orderid/{orderId}")]
        public async Task<OrderResponse?> GetOrderById(Guid id)
        {
            var filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId, id);
            var response = await _orderService.GetOrderByCondtion(filter);
            return response;
        }

        public async Task<OrderResponse?> GetOrdersByCondition(Guid id)
        {
            var filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId, id);
            var response = await _orderService.GetOrderByCondtion(filter);
            return response;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderAddRequest request)
        {
            if (request is null)
            {
                return BadRequest("Invalid request");
            }
            var response = await _orderService.AddOrder(request);
            if (response is null)
            {
                return Problem("Enable to create order");
            }
            return Ok($"api/Orders/search/orderid/{response?.OrderId}");

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderUpdateRequest request)
        {
            if (request is null)
            {
                return BadRequest("Invalid data");
            }
            if (id != request.OrderId)
            {
                return BadRequest("Id's do not match");

            }
            var response = await _orderService.UpdateOrder(request);
            if (response is null)
            {
                return Problem("Cannot update Order");
            }
            return Ok(response);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletOrder(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid order ID");
            }

            bool isDeleted = await _orderService.DeleteOrder(id);

            if (!isDeleted)
            {
                return Problem("Error in deleting order");
            }

            return Ok(isDeleted);
        }
    }
    
}
