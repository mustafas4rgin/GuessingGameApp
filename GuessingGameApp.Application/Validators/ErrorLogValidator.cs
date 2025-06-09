using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class ErrorLogValidator : AbstractValidator<ErrorLog>
{
    public ErrorLogValidator()
    {
        RuleFor(el => el.CreatedAt)
            .NotNull()
            .WithMessage("CreatedAt field cannot be null.");
    }
}