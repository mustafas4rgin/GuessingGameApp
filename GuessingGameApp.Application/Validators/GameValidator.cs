using FluentValidation;
using GuessingGameApp.Domain.Entities;

namespace GuessingGameApp.Application.Validators;

public class GameValidator : AbstractValidator<Game>
{
    public GameValidator()
    {
        RuleFor(g => g.CreatedAt)
            .NotNull()
            .WithMessage("Created at date cannot be null.");

        RuleFor(g => g.Developer)
            .NotNull()
            .WithMessage("Developer field cannot be null.")
            .Length(3, 50)
            .WithMessage("Developer field must be between 3-50 characters long.");

        RuleFor(g => g.Genre)
            .NotNull()
            .WithMessage("Genre field cannot be null.")
            .Length(3, 50)
            .WithMessage("Genre field must be between 3-50 characters long.");

        RuleFor(g => g.MetaScore)
            .NotNull()
            .WithMessage("MetaScore field cannot be null.")
            .Length(0, 3)
            .WithMessage("MetaScore field must be between 0-3 characters long.");

        RuleFor(g => g.Name)
            .NotNull()
            .WithMessage("Name field cannot be null.")
            .Length(3, 100)
            .WithMessage("Name field must be between 3-100 characters long.");

        RuleFor(g => g.OriginalPlatform)
            .NotNull()
            .WithMessage("OriginalPlatform field cannot be null.")
            .Length(3, 50)
            .WithMessage("OriginalPlatform field must be between 3-50 characters long.");

        RuleFor(g => g.Release)
            .NotNull()
            .WithMessage("Release field cannot be null.");
    }
}