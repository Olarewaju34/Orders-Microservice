﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BusinessLogic.DTO
{
    public  record OrderItemResponse(Guid ProductId, decimal UnitPrice,int Quantity,decimal TotalPrice)
    {
        public OrderItemResponse() :this(default,default,default,default)
        {
                
        }
    }
}
