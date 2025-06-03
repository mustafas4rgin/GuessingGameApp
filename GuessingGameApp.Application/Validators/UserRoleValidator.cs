using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class UserRoleValidator : AbstractValidator<UserRole>
{
    public UserRoleValidator()
    {
        RuleFor(ur => ur.GivenDate)
            .NotNull()
            .WithMessage("GivenDate field cannot be null.");

        RuleFor(ur => ur.RoleId)
            .NotNull()
            .WithMessage("RoleId value cannot be null.")
            .GreaterThan(0)
            .WithMessage("RoleId value must be greater than zero.");

        RuleFor(ur => ur.UserId)
            .NotNull()
            .WithMessage("UserId value cannot be null.")
            .GreaterThan(0)
            .WithMessage("UserId value must be greater than zero.");
    }
}