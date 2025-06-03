using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(u => u.CreatedAt)
            .NotNull()
            .WithMessage("Created at date cannot be null.");

        RuleFor(u => u.Email)
            .NotNull()
            .WithMessage("Email field cannot be null.")
            .EmailAddress()
            .WithMessage("Email field must be a valid email address.")
            .Length(10, 100)
            .WithMessage("Email field must be between 10-100 characters long.");

        RuleFor(u => u.FirstName)
            .NotNull()
            .WithMessage("FirstName field cannot be null.")
            .Length(3, 50)
            .WithMessage("FirstName field must be between 3-50 characters long.");

        RuleFor(u => u.LastName)
            .NotNull()
            .WithMessage("LastName field cannot be null.")
            .Length(3, 50)
            .WithMessage("LastName field must be between 3-50 characters long.");

        RuleFor(u => u.UserName)
            .NotNull()
            .WithMessage("UserName field cannot be null.")
            .Length(3, 50)
            .WithMessage("UserName field must be between 3-50 characters long.");
    }
}