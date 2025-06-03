using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class GuessGameValidator : AbstractValidator<GuessGame>
{
    public GuessGameValidator()
    {
        RuleFor(gg => gg.CreatedAt)
            .NotNull()
            .WithMessage("Created at date cannot be null.");

        RuleFor(gg => gg.Answer)
            .NotNull()
            .WithMessage("Answer field cannot be null.");

        RuleFor(gg => gg.DayId)
            .NotNull()
            .WithMessage("DayId value cannot be null.")
            .GreaterThan(0)
            .WithMessage("DayId Value must be greater than zero.");

        RuleFor(gg => gg.GuessGameResultId)
            .NotNull()
            .WithMessage("GuessGameResultId cannot be null")
            .GreaterThan(0)
            .WithMessage("GuessGameResultId must be greater than zero.");
            
    }
}