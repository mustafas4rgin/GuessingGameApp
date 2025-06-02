using GuessingGameApp.Data.Contexts;
using GuessingGameApp.Data.Repositories;
using GuessingGameApp.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GuessingGameApp.Data.Registrations;

public static class DataServiceRegistration
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GuessingGameDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        RepositoryRegistrationProvider.RegisterRepositories(services);

        return services;
    }
}