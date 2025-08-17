using System.IO.Compression;
using FluentValidation;
using GuessingGameApp.Application.DTOs.Update;

namespace GuessingGameApp.Application.DtoValidators.Update;

public class UpdateGameDTOValidator : AbstractValidator<UpdateGameDTO>
{
    public UpdateGameDTOValidator()
    {
        RuleFor(g => g.Developer)
            .NotEmpty()
            .WithMessage("Developer field cannot be empty.")
            .Length(2, 50)
            .WithMessage("Developer field must be between 2-50 characters.");

        RuleFor(g => g.Genre)
            .NotEmpty()
            .WithMessage("Genre field cannot be empty.")
            .Length(2, 50)
            .WithMessage("Genre field must be between 2-50 characters.");

        RuleFor(g => g.MetaScore)
            .NotEmpty()
            .WithMessage("Metascore field cannot be empty.")
            .Length(0, 3)
            .WithMessage("Metascore field must be between 0-3 characters.");

        RuleFor(g => g.Name)
            .NotEmpty()
            .WithMessage("Name field cannot be empty.")
            .Length(3, 100)
            .WithMessage("Name field must be between 3-100 characters.");

        RuleFor(g => g.OriginalPlatform)
            .NotEmpty()
            .WithMessage("Original Platform field cannot be null.")
            .Length(2, 50)
            .WithMessage("Original Platform field must be between 2-50 characters.");

        RuleFor(g => g.Release)
            .NotEmpty()
            .WithMessage("Release field cannot be null.")
            .Length(1, 5)
            .WithMessage("Release field must be between 1-5 characters.");
    }
}