using FluentValidation;
using GuessingGameApp.Application.DTOs.Create;

namespace GuessingGameApp.Application.DtoValidators.Create;

public class CreateUserGameRelDTOValidator : AbstractValidator<CreateUserGameRelDTO>
{
    public CreateUserGameRelDTOValidator()
    {
        RuleFor(ugr => ugr.GuessesCount)
            .NotNull()
            .WithMessage("GuessesCount field cannot be null.");

        RuleFor(ugr => ugr.GuessGameId)
            .NotNull()
            .WithMessage("GuessGameId field cannot be null.")
            .GreaterThan(0)
            .WithMessage("GuessGameId must be greater than zero.");

        RuleFor(ugr => ugr.UserId)
            .NotNull()
            .WithMessage("UserId field cannot be null")
            .GreaterThan(0)
            .WithMessage("UserId value must be greater than zero.");
    }
}