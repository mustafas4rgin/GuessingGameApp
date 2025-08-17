using GuessingGameApp.Application.Validators;

namespace GuessingGameApp.Application.Registrations.Validator;

public static class DtoValidatorAssemblyProvider
{
    public static Type[] GetValidatorAssemblies()
    {
        return new[]
        {
            typeof(DayValidator),
        };
    }
}