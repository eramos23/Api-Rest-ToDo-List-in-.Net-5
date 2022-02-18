using Application.Features.Commands.ListaCommand;
using FluentValidation;

namespace Application.Features.Validators
{
    public class CreateListaCommandValidator : AbstractValidator<CreateListaCommand>
    {
        public CreateListaCommandValidator()
        {
            RuleFor(lista => lista.Titulo)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.")
                .MaximumLength(100).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres.");

            RuleFor(lista => lista.Descripcion)
                .MaximumLength(500).WithMessage("{PropertyName} debe tener maximo {MaxLength} caracteres.");
        }
    }
}
