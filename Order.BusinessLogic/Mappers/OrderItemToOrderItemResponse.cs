using AutoMapper;
using Order.BusinessLogic.DTO;
using Order.DataAccessLayer.Entites;

namespace Order.BusinessLogic.Mappers;

public class OrderItemToOrderItemResponseMappingProfile : Profile
{
  public OrderItemToOrderItemResponseMappingProfile()
  {
    CreateMap<OrdersItem, OrderItemResponse>()
      .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
      .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
      .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
      .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice));
  }
}