using GuessingGameApp.Data.Repositories;
using GuessingGameApp.Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GuessingGameApp.Data;

public class RepositoryRegistrationProvider
{
    public static void RegisterRepositories(IServiceCollection services)
    {
        var servicesToRegister = new (Type Interface, Type Implementation)[]
        {
            (typeof(IGenericRepository<>),typeof(GenericRepository<>)),
            (typeof(IRoleRepository),typeof(RoleRepository)),
            (typeof(IGameRepository),typeof(GameRepository)),
        };
        foreach (var service in servicesToRegister)
        {
            services.AddTransient(service.Interface, service.Implementation);
        }
    }
}