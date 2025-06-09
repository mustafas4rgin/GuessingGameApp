using GuessingGameApp.Application.Validators;

namespace GuessingGameApp.Application.Registrations.Validator;

public static class EntityValidatorAssemblyProvider
{
    public static Type[] GetValidatorAssemblies()
    {
        return new[]
        {
            typeof(DayValidator),
            typeof(GameValidator),
            typeof(GuessGameResultValidator),
            typeof(GuessGameValidator),
            typeof(RoleValidator),
            typeof(UserGameRelValidator),
            typeof(UserRoleValidator),
            typeof(UserValidator)
        };
    }
}