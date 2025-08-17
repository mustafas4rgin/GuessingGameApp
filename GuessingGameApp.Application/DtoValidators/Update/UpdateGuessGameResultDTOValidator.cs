using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateGuessGameResultDTOValidator : AbstractValidator<UpdateGuessGameResultDTO>
{
    public UpdateGuessGameResultDTOValidator()
    {
        RuleFor(ggr => ggr.IsGuessedCorrect)
            .NotNull()
            .WithMessage("IsGuessedCorrect field cannot be null.");

        RuleFor(ggr => ggr.ResultMessage)
            .NotEmpty()
            .WithMessage("Message field cannot be empty.")
            .Length(2, 20)
            .WithMessage("Message field must be between 2-50 characters.");
    }
}