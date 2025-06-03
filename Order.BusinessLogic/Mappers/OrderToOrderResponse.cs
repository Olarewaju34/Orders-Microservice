using AutoMapper;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BusinessLogic.Mapper
{
    public class OrderToOrderResponse : Profile
    {
        public OrderToOrderResponse()
        {
            CreateMap<Orders, OrderResponse>()
                .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.TotalBill, opt => opt.MapFrom(src => src.TotalBill))
;
        }
    }
}
