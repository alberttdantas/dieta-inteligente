using DietaInteligente.Domain.Repositories;
using DietaInteligente.Infrastructure.Repositories;
using DietaInteligente.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DietaInteligente.Infrastructure.Repositories.Dietas;
using DietaInteligente.Infrastructure.Repositories.GruposAlimentares;
using DietaInteligente.Infrastructure.Repositories.InformacoesNutricionais;
using DietaInteligente.Infrastructure.Repositories.RestricoesDieteticas;
using DietaInteligente.Infrastructure.Repositories.Usuarios;

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

        services.AddScoped<IAlimentoRepository, AlimentoRepository>();
        services.AddScoped<IDietaRepository, DietaRepository>();
        services.AddScoped<IDietaAlimentoRepository, DietaAlimentoRepository>();
        services.AddScoped<IGrupoAlimentarRepository, GrupoAlimentarRepository>();
        services.AddScoped<IInformacaoNutricionalRepository, InformacaoNutricionalRepository>();
        services.AddScoped<IRestricaoDieteticaRepository, RestricaoDieteticaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;
    }
}
