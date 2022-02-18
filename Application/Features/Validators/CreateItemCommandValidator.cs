using Application.Features.Commands.ItemCommand;
using FluentValidation;

namespace Application.Features.Validators
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(item => item.Descripcion)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(200).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres.");
        }
    }
}
