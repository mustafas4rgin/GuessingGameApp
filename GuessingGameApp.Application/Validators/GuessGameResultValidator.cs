using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class GuessGameResultValidator : AbstractValidator<GuessGameResult>
{
    public GuessGameResultValidator()
    {
        RuleFor(ggr => ggr.CreatedAt)
            .NotNull()
            .WithMessage("Created at date cannot be null.");

        RuleFor(ggr => ggr.ResultMessage)
            .NotNull()
            .WithMessage("ResultMessage field cannot be null")
            .Length(3, 20)
            .WithMessage("ResultMessage field must be between 3-20 characters long.");

        RuleFor(ggr => ggr.IsGuessedCorrect)
            .NotNull()
            .WithMessage("IsGuessedCorrect field cannot be null.");
    }
}