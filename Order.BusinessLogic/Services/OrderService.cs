using AutoMapper;
using FluentValidation;
using MongoDB.Driver;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;
using Order.DataAccessLayer.Repository;

namespace Order.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private readonly IValidator<OrderAddRequest> _orderAddRequestValidator;
        private readonly IValidator<OrderItemAddRequest> _orderItemAddRequestValidator;
        private readonly IValidator<OrderUpdateRequest> _orderUpdateRequestValidator;
        private readonly IValidator<OrderItemUpdateRequest> _orderItemUpdateRequestValidator;
        private readonly IMapper _mapper;
        private readonly IOrdersRepository _ordersRepository;

        public OrderService(IOrdersRepository ordersRepository, IMapper mapper, IValidator<OrderAddRequest> orderAddRequestValidator, IValidator<OrderItemAddRequest> orderItemAddRequestValidator, IValidator<OrderUpdateRequest> orderUpdateRequestValidator, IValidator<OrderItemUpdateRequest> orderItemUpdateRequestValidator)
        {
            _orderAddRequestValidator = orderAddRequestValidator;
            _orderItemAddRequestValidator = orderItemAddRequestValidator;
            _orderUpdateRequestValidator = orderUpdateRequestValidator;
            _orderItemUpdateRequestValidator = orderItemUpdateRequestValidator;
            _mapper = mapper;
            _ordersRepository = ordersRepository;
        }
        public async Task<OrderResponse> AddOrder(OrderAddRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var validationResult = await _orderAddRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                var errors = string.Join(",", validationResult.Errors.Select(temp=>temp.ErrorMessage));
                throw new ArgumentException(errors);
            }
            var orderInput = _mapper.Map<Orders>(request);
            foreach (var orders in orderInput.OrderItems)
            {
                orders.TotalPrice = orders.Quantity * orders.Price;
            }
            orderInput.TotalBill = orderInput.OrderItems.Sum(temp=>temp.TotalPrice);
            var newOrder = await _ordersRepository.AddOrder(orderInput);

            if (newOrder == null)
            {
                return null;
            }

            var addedOrderResponse = _mapper.Map<OrderResponse>(newOrder); //Map addedOrder ('Order' type) into 'OrderResponse' type (it invokes OrderToOrderResponseMappingProfile).

            return addedOrderResponse;

        }

        public async Task<bool> DeleteOrder(Guid id)
        {
           FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq(temp => temp.OrderId ,id);  
            var orderExist = await _ordersRepository.GetOrderByCondition(filter);
            if (orderExist is null)
            {
                return false;
            }
            var isDeleted = await _ordersRepository.DeleteOrder(id);
            return isDeleted;
        }

        public async Task<OrderResponse?> GetOrderByCondtion(FilterDefinition<Orders> filter)
        {
            var order = await _ordersRepository.GetOrderByCondition(filter);
            if (order == null)
                return null;

            OrderResponse? orderResponse = _mapper.Map<OrderResponse>(order);
            return orderResponse;
        }

        public async Task<List<OrderResponse?>> GetOrders()
        {

            IEnumerable<Orders?> orders = await _ordersRepository.GetOrders();


            IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return orderResponses.ToList();
        }

        public async Task<List<OrderResponse?>> GetOrdersByCondition(FilterDefinition<Orders> filter)
        {
            IEnumerable<Orders?> orders = await _ordersRepository.GetOrdersByCondition(filter);


            IEnumerable<OrderResponse?> orderResponses = _mapper.Map<IEnumerable<OrderResponse>>(orders);
            return orderResponses.ToList();
        }

        public async Task<OrderResponse> UpdateOrder(OrderUpdateRequest request)
        {
            if (request is null)
            {
                throw new ArgumentException(nameof(request));
            }
            var validationResult = await _orderUpdateRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                string errors = string.Join(",", validationResult.Errors.Select(temp => temp.ErrorMessage));
                throw new InvalidOperationException(errors);
            }

            var updateOrder = _mapper.Map<Orders>(request);
            foreach (var orders in updateOrder.OrderItems)
            {
                orders.TotalPrice = orders.Quantity * orders.Price;
            }
            updateOrder.OrderItems.Sum(temp => temp.TotalPrice);

            var newOrder = await _ordersRepository.UpdateOrder(updateOrder);
            if (newOrder is null)
            {
                return null;
            }
            var response = _mapper.Map<OrderResponse>(newOrder);
            return response;
        }
    }
}
