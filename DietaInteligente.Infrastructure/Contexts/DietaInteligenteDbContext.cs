using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DietaInteligente.Infrastructure.Contexts;

public class DietaInteligenteDbContext : DbContext
{
    public DietaInteligenteDbContext(DbContextOptions<DietaInteligenteDbContext> options) : base(options)
    {

    }

    public DbSet<Alimento> Alimentos { get; set; }
    public DbSet<Dieta> Dietas { get; set; }
    public DbSet<DietaAlimento> DietasAlimentos { get; set; }
    public DbSet<GrupoAlimentar> GruposAlimentares { get; set; }
    public DbSet<InformacaoNutricional> InformacoesNutricionais { get; set; }
    public DbSet<RestricaoDietetica> RestricoesDieteticas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
}
