using GuessingGameApp.Application.Providers.Service;
using Microsoft.Extensions.DependencyInjection;

namespace GuessingGameApp.Application.Registration;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessService(this IServiceCollection services)
    {
        //service registration
        ServiceRegistrationProvider.RegisterServices(services);
        //validator registration
        services.AssembleValidators();

        return services;
    }
}