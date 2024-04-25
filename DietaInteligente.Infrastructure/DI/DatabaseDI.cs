using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DietaInteligente.Infrastructure.Contexts;

namespace DietaInteligente.Infrastructure.DI;

public static class DatabaseDI
{
    public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppDbConnectionString");

        services.AddDbContext<DietaInteligenteDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        MapAutomaticallyRepositories(services);
        return services;
    }

    private static void MapAutomaticallyRepositories(IServiceCollection services)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.GetName().Name!.Contains("DietaInteligente"));
        var implementacoes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Any(y => y.Name.Contains("Repository")));
        foreach (var implementacao in implementacoes)
        {
            foreach (var interfaceType in implementacao.GetInterfaces())
            {
                services.AddScoped(interfaceType, implementacao);
            }
        }
    }
}