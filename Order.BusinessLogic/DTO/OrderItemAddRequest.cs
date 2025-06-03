using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BusinessLogic.DTO
{
    public record OrderItemAddRequest(
        Guid ProductId,
        int Quantity,
        decimal Price  )
    {
        public OrderItemAddRequest() : this(default, default, default)
        {
        }
    }

}
