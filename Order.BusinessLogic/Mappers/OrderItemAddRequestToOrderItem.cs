using AutoMapper;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;

namespace Order.BusinessLogic.Mappers;

public class OrderItemAddRequestToOrderItem : Profile
{
  public OrderItemAddRequestToOrderItem()
  {
    CreateMap<OrderItemAddRequest, OrdersItem>()
      .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
      .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
      .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
      .ForMember(dest => dest.TotalPrice, opt => opt.Ignore())
      .ForMember(dest => dest._id, opt => opt.Ignore());
  }
}