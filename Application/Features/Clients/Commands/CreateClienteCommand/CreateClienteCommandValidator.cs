using FluentValidation;

namespace Application.Features.Clients.Commands;

public class CreateClienteCommandValidator: AbstractValidator<CreateClienteCommand.CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} no puede ser vacio.")
            .MaximumLength(80)
            .WithMessage("{PropertyName} no debe exceder de {MaxLength}");
        
        RuleFor(p => p.LastName)
            .NotEmpty()
            .WithMessage("{PropertyName} no puede ser vacio.")
            .MaximumLength(80)
            .WithMessage("{PropertyName} no debe exceder de {MaxLength}");
        
        RuleFor(p => p.BirthDay)
            .NotEmpty()
            .WithMessage("Birthday no puede ser vacia.");
        
        RuleFor(p => p.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number no puede ser vacio.")
            .MaximumLength(9)
            .WithMessage("{PropertyName} no debe exceder de {MaxLength}");

        RuleFor(p => p.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} no puede ser vacío")
            .EmailAddress()
            .WithMessage("{PropertyName} debe ser una dirección de correo válida.")
            .MaximumLength(100)
            .WithMessage("{PropertyName} no debe exceder de {MaxLenght} caracteres.");
        
        RuleFor(p => p.Direction)
            .NotEmpty()
            .WithMessage("{PropertyName} no puede ser vacio.")
            .MaximumLength(120)
            .WithMessage("{PropertyName} no debe exceder de {MaxLength}");
    }
}