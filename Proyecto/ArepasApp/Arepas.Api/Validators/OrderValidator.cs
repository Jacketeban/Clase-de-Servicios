using Arepas.Api.Dtos;
using FluentValidation;

namespace Arepas.Api.Validators
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El Campo Id es Requerido");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("El CustomerId es Requerido");
                

            RuleFor(x => x.DeliveryFullName)
                .NotEmpty().WithMessage("El Nombre Completo del Cliente es Requerido")
                .MaximumLength(100).WithMessage("La Longitud Maxima para Nombre Completo del Cliente es de 100 Caracteres");

            RuleFor(x => x.DeliveryAddress)
                .NotEmpty().WithMessage("La Direccion del Cliente es Requerida")
                .MaximumLength(250).WithMessage("La Longitud Maxima para la Direccion del Cliente es de 250 Caracteres");

            RuleFor(x => x.DeliveryPhoneNumber)
                .NotEmpty().WithMessage("El Telefono del Cliente es Requerido")
                .MaximumLength(50).WithMessage("La Longitud Maxima para el Telefono del cliente es de 50 Caracteres");

            RuleFor(x => x.TotalPrice)
                .NotEmpty().WithMessage("La Contraseña del Cliente es Requerida");
         

            RuleFor(x => x.Notes)
              .NotEmpty().WithMessage("La Contraseña del Cliente es Requerida")
              .MaximumLength(250).WithMessage("La Longitud Maxima para La Contraseña es de 50 Caracteres");
        }
    }
}