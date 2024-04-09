using DietaInteligente.Domain;
using System.Reflection;

namespace DietaInteligente.Infrastructure;

#nullable disable
public class ConfigurationDbContext : IConfigurationDbContext
{
    public List<Assembly> Assemblies { get; set; } = new();
}