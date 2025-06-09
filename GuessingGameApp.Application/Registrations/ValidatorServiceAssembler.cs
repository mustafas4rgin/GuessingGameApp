using GuessingGameApp.Application.Registration;
using Microsoft.Extensions.DependencyInjection;

namespace GuessingGameApp.Application.Registration;

public static class ValidatorServiceAssembler
{
    public static IServiceCollection AssembleValidators(this IServiceCollection services)
    {
        services.AddEntityValidators();

        return services;
    }
}