using GuessingGameApp.Application.DtoValidators.Create;
using GuessingGameApp.Application.DtoValidators.Update;
using GuessingGameApp.Application.Validators;

namespace GuessingGameApp.Application.Registrations.Validator;

public static class DtoValidatorAssemblyProvider
{
    public static Type[] GetValidatorAssemblies()
    {
        return new[]
        {
            //Create
            typeof(CreateDayDTOValidator),
            typeof(CreateGameDTOValidator),
            typeof(CreateGuessGameDTOValidator),
            typeof(CreateGuessGameResultDTOValidator),
            typeof(CreateRoleDTOValidator),
            typeof(CreateUserDTOValidator),
            typeof(CreateUserGameRelDTOValidator),
            typeof(CreateUserRoleDTOValidator),

            //Update

            typeof(UpdateDayDTOValidator),
            typeof(UpdateGameDTOValidator),
            typeof(UpdateGuessGameDTOValidator),
            typeof(UpdateGuessGameResultDTOValidator),
            typeof(UpdateRoleDTOValidator),
            typeof(UpdateUserDTOValidator),
            typeof(UpdateUserGameRelDTOValidator),
            typeof(UpdateUserRoleDTOValidator)
        };
    }
}