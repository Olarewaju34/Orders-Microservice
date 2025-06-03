using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BusinessLogic.DTO
{
    public record OrderUpdateRequest(Guid OrderId, Guid UserId, DateTime OrderDate, List<OrderItemUpdateRequest> orderItem)
    {
        public OrderUpdateRequest() : this(default,default, default, default)
        {

        }
    }
}
