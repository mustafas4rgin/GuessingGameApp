using FluentValidation;
using GuessingGameApp.Application.DTOs.Create;

namespace GuessingGameApp.Application.DtoValidators.Create;

public class CreateGuessGameResultDTOValidator : AbstractValidator<CreateGuessGameResultDTO>
{
    public CreateGuessGameResultDTOValidator()
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