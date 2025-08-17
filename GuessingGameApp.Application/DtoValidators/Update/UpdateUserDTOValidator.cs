using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
{
    public UpdateUserDTOValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty()
            .WithMessage("Email field cannot be empty.")
            .EmailAddress()
            .WithMessage("Email value must be a valid email address.")
            .Length(0, 100)
            .WithMessage("Email field must be between 0-100 characters.");

        RuleFor(u => u.FirstName)
            .NotEmpty()
            .WithMessage("FirstName field cannot be empty.")
            .Length(2, 50)
            .WithMessage("FirstName field must be between 2-50 characters.");

        RuleFor(u => u.UserName)
            .NotEmpty()
            .WithMessage("UserName field cannot be empty.")
            .Length(2, 50)
            .WithMessage("UserName field must be between 2-50 characters.");

        RuleFor(u => u.LastName)
            .NotEmpty()
            .WithMessage("LastName field cannot be empty.")
            .Length(2, 50)
            .WithMessage("LastName field must be between 2-50 characters.");

        RuleFor(u => u.Password)
            .NotEmpty().WithMessage("Password is necessary.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters.")
            .Matches(@"[A-Z]+").WithMessage("Password must contain at least one upper case letter.")
            .Matches(@"[a-z]+").WithMessage("Password must contain at least one lower case letter.")
            .Matches(@"\d+").WithMessage("Password must contain at least one number.")
            .Matches(@"[\!\@\#\$\%\^\&\*\(\)\-\+\=.]+").WithMessage("Password must contain at least one special character.");

        RuleFor(u => u.PasswordDup)
            .NotEmpty().WithMessage("Password confirmation is required.")
            .Equal(u => u.Password).WithMessage("Password confirmation must match the password.");
    }
}
