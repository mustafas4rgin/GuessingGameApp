using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateDayDTOValidator : AbstractValidator<UpdateDayDTO>
{
    public UpdateDayDTOValidator()
    {
        RuleFor(d => d.Date)
            .NotNull()
            .WithMessage("Date cannot be null.");
    }
}