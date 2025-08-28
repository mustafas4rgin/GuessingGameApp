using GuessingGameApp.Application.Interfaces;
using GuessingGameApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GuessingGameApp.Application.Providers.Service;

public class ServiceRegistrationProvider
{
    public static void RegisterServices(IServiceCollection services)
    {
        var servicesToRegister = new (Type Interface, Type Implementation)[]
        {
            (typeof(IGenericService<>),typeof(GenericService<>)),
            (typeof(IRoleService),typeof(RoleService)),
            (typeof(IGameService),typeof(GameService))
        };

        foreach (var service in servicesToRegister)
        {
            services.AddTransient(service.Interface, service.Implementation);
        }
    }
}