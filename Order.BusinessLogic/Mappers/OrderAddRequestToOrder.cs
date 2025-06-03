using AutoMapper;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;

namespace Order.BusinessLogic.Mapper
{
    public class OrderAddRequestToOrder : Profile
    {
        public OrderAddRequestToOrder()
        {
            CreateMap<OrderAddRequest, Orders>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
                .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.orderItem))
                .ForMember(dest => dest._id, opt => opt.Ignore())
                .ForMember(dest => dest.TotalBill, opt => opt.Ignore());
        }
    }
}
