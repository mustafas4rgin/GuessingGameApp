using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateUserGameRelDTOValidator : AbstractValidator<UpdateUserGameRelDTO>
{
    public UpdateUserGameRelDTOValidator()
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