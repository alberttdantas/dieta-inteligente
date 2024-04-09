
using System.Reflection;

namespace DietaInteligente.Domain;

public interface IConfigurationDbContext
{
    public List<Assembly> Assemblies { get; set; }
}