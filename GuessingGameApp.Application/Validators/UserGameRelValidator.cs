using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class UserGameRelValidator : AbstractValidator<UserGameRel>
{
    public UserGameRelValidator()
    {
        RuleFor(ugr => ugr.GuessesCount)
            .NotNull()
            .WithMessage("GuessesCount field cannot be null.");

        RuleFor(ugr => ugr.GuessGameId)
            .NotNull()
            .WithMessage("GuessGameId cannot be null.")
            .GreaterThan(0)
            .WithMessage("GuessGameId value must be greater than zero.");

        RuleFor(ugr => ugr.UserId)
            .NotNull()
            .WithMessage("UserId value cannot be null.")
            .GreaterThan(0)
            .WithMessage("UserId value must be greater than zero.");
    }
}