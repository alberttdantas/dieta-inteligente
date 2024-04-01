
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class GrupoAlimentarEntityConfiguration : IEntityTypeConfiguration<GrupoAlimentar>
{
    public void Configure(EntityTypeBuilder<GrupoAlimentar> builder)
    {
        builder.ToTable("GrupoAlimentar");
        builder.HasKey(g => g.Id);
        builder.Property(g => g.Id).ValueGeneratedOnAdd();
        builder.Property(g => g.Nome).IsRequired().HasMaxLength(100);

        builder.HasMany(g => g.Alimentos)
            .WithOne(a => a.GruposAlimentares)
            .HasForeignKey(a => a.GrupoAlimentarId);
    }
}
