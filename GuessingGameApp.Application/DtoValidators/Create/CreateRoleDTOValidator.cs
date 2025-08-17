using FluentValidation;
using GuessingGameApp.Application.DTOs.Create;

namespace GuessingGameApp.Application.DtoValidators.Create;

public class CreateRoleDTOValidator : AbstractValidator<CreateRoleDTO>
{
    public CreateRoleDTOValidator()
    {
        RuleFor(r => r.Name)
            .NotEmpty()
            .WithMessage("Name field cannot be empty.")
            .Length(2, 50)
            .WithMessage("Name field must be between 2-50 characters.");
    }
}