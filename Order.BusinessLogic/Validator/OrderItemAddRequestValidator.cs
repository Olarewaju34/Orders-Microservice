using FluentValidation;
using Order.BusinessLogic.DTO;

namespace Order.BusinessLogicLayer.Validators;

public class OrderItemAddRequestValidator : AbstractValidator<OrderItemAddRequest>
{
  public OrderItemAddRequestValidator()
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
