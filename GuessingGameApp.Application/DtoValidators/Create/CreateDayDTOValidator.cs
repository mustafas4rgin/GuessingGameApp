using FluentValidation;
using GuessingGameApp.Application.DTOs.Create;

namespace GuessingGameApp.Application.DtoValidators.Create;

public class CreateDayDTOValidator : AbstractValidator<CreateDayDTO>
{
    public CreateDayDTOValidator()
    {
        RuleFor(d => d.Date)
            .NotNull()
            .WithMessage("Date cannot be null.");
    }
}