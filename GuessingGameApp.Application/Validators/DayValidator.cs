using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class DayValidator : AbstractValidator<Day>
{
    public DayValidator()
    {
        RuleFor(d => d.Date)
            .NotNull()
            .WithMessage("Date value cannot be null.");
    }
}