using FluentValidation;
using Order.BusinessLogic.DTO;

namespace Order.BusinessLogic.Validators;

public class OrderItemUpdateRequestValidator : AbstractValidator<OrderItemUpdateRequest>
{
  public OrderItemUpdateRequestValidator()
  {
    //ProductID
    RuleFor(temp => temp.ProductId)
      .NotEmpty().WithErrorCode("Product ID can't be blank");

    //UnitPrice
    RuleFor(temp => temp.Price)
      .NotEmpty().WithErrorCode("Unit Price can't be blank")
      .GreaterThan(0).WithErrorCode("Unit Price can't be less than or equal to zero");

    //Quantity
    RuleFor(temp => temp.Quantity)
      .NotEmpty().WithErrorCode("Quantity can't be blank")
      .GreaterThan(0).WithErrorCode("Quantity can't be less than or equal to zero");
  }
}
