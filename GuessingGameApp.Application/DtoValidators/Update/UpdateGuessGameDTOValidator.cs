using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateGuessGameDTOValidator : AbstractValidator<UpdateGuessGameDTO>
{
    public UpdateGuessGameDTOValidator()
    {
        RuleFor(gg => gg.Answer)
            .NotEmpty()
            .WithMessage("Answer field must be between cannot be empty.");

        RuleFor(gg => gg.DayId)
            .NotNull()
            .WithMessage("DayID field cannot be null.")
            .GreaterThan(0)
            .WithMessage("DayID field must be greater than zero.");

        RuleFor(gg => gg.GuessCount)
            .NotNull()
            .WithMessage("GuessCount field cannot be null.");

        RuleFor(gg => gg.GuessGameResultId)
            .NotNull()
            .WithMessage("GuessGameResultId field cannot be null.")
            .GreaterThan(0)
            .WithMessage("GuessGameResultId field must be greater than zero.");

        RuleFor(gg => gg.IsPlayed)
            .NotNull()
            .WithMessage("IsPlayed field cannot be null.");
    }
}