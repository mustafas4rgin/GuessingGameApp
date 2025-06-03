using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class RoleValidator : AbstractValidator<Role>
{
    public RoleValidator()
    {
        RuleFor(r => r.Name)
            .NotNull()
            .WithMessage("Name field cannot be null.")
            .Length(3, 50)
            .WithMessage("Name field must be between 3-50 characters long.");
        
        RuleFor(r => r.CreatedAt)
            .NotNull()
            .WithMessage("Created at date cannot be null.");
    }
}