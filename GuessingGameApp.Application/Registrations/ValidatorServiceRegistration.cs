using FluentValidation;
using GuessingGameApp.Application.Registrations.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace GuessingGameApp.Application.Registration;

public static class ValidatorServiceRegistration
{
    public static IServiceCollection AddEntityValidators(this IServiceCollection services)
    {
        var entityValidatorAssemblies = EntityValidatorAssemblyProvider.GetValidatorAssemblies();

        foreach (var assemblyType in entityValidatorAssemblies)
            services.AddValidatorsFromAssemblyContaining(assemblyType);

        return services; 
    }
}