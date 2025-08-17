using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateUserRoleDTOValidator : AbstractValidator<UpdateUserRoleDTO>
{
    public UpdateUserRoleDTOValidator()
    {
        RuleFor(ur => ur.GivenDate)
            .NotNull()
            .WithMessage("GivenDate value cannot be null.");

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