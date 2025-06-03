using FluentValidation;
using Order.BusinessLogic.DTO;

namespace Order.BusinessLogic.Validators;

public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
{
  public OrderUpdateRequestValidator()
  {
    //OrderID
    RuleFor(temp => temp.OrderId)
      .NotEmpty().WithErrorCode("Order ID can't be blank");

    //UserID
    RuleFor(temp => temp.UserId)
      .NotEmpty().WithErrorCode("User ID can't be blank");

    //OrderDate
    RuleFor(temp => temp.OrderDate)
      .NotEmpty().WithErrorCode("Order Date can't be blank");

    //OrderItems
    RuleFor(temp => temp.orderItem)
      .NotEmpty().WithErrorCode("Order Items can't be blank");
  }
}
