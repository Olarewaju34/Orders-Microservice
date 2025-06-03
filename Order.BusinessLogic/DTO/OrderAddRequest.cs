namespace Order.BusinessLogic.DTO
{
    public record OrderAddRequest(Guid UserId,DateTime OrderDate,List<OrderItemAddRequest> orderItem)
    {
        public OrderAddRequest() : this(default,default,default)
        {
            
        }
    }   
}
    