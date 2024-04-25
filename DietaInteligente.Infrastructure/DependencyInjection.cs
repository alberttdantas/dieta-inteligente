using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Repositories;
using DietaInteligente.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddLibs(this IServiceCollection services, IConfiguration configuration, ConfigurationDbContext configurationDbContext)
    {
        // Adicionando AutoMapper
        services.AddAutoMapper(configurationDbContext.Assemblies.ToArray());

        // Adicionando MediatR
        services.AddMediatR(cfg =>
        {
            foreach (var assembly in configurationDbContext.Assemblies)
            {
                cfg.RegisterServicesFromAssembly(assembly);
            }
        });

        // Adicionando o AlimentoRepository
        services.AddScoped<IAlimentoRepository, AlimentoRepository>();

        // services.AddScoped<IOutroRepository, OutroRepository>();

        return services;
    }
}
