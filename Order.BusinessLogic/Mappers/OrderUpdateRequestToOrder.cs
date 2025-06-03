using AutoMapper;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;

namespace Order.BusinessLogic.Mappers;

public class OrderUpdateRequestToOrder : Profile
{
  public OrderUpdateRequestToOrder()
  {
    CreateMap<OrderUpdateRequest, Orders>()
      .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId))
      .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
      .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
      .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.orderItem))
      .ForMember(dest => dest._id, opt => opt.Ignore())
      .ForMember(dest => dest.TotalBill, opt => opt.Ignore());
  }
}