using Arepas.Api.Dtos;
using FluentValidation;

namespace Arepas.Api.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("El Campo Id es Requerido");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Name es Requerido")
                .MaximumLength(50).WithMessage("La Longitud Maxima para el nombre del Producto es de 50 Caracteres");

            RuleFor(x => x.Description)
                .MaximumLength(250).WithMessage("La Longitud Maxima para la descripción del Producto es de 250 Caracteres");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("El campo Precio es requerido");
                

            RuleFor(x => x.Image)
                .MaximumLength(250).WithMessage("La Longitud Maxima para la imagen del Producto es de 250 Caracteres");

        }
    }
}