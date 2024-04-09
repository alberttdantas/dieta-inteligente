using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DietaInteligente.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMySql(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AppDbConnectionString");

        services.AddDbContext<DietaInteligenteDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        return services;
    }
}
