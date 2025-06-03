using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BusinessLogic.DTO
{
    public record OrderResponse(Guid OrderId,Guid UserId,decimal TotalBill,DateTime OrderDate,List<OrderItemResponse> rderItem)
    {
        public OrderResponse() : this(default, default, default,default,default)
        {

        }
    }
}

