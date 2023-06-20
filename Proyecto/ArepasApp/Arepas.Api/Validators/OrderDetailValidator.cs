using Arepas.Api.Dtos;
using FluentValidation;

namespace Arepas.Api.Validators
{
    public class OrderDetailValidator : AbstractValidator<OrderDetailDto>
    {
        public OrderDetailValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El Campo Id es Requerido");

            RuleFor(x => x.OrderId)
                .NotEmpty().WithMessage("El OrderId es Requerido");


            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("El ProductId es Requerido");

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("La Quantity es Requerida");

            RuleFor(x => x.PriceOrd)
                .NotEmpty().WithMessage("El PriceOrd es Requerido");
        }
    }
}