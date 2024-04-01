
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class AlimentoEntityConfiguration : IEntityTypeConfiguration<Alimento>
{
    public void Configure(EntityTypeBuilder<Alimento> builder)
    {
        builder.ToTable("Alimentos");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id).ValueGeneratedOnAdd();

        builder.Property(a => a.Nome).IsRequired().HasMaxLength(100);

        builder.HasOne(a => a.GruposAlimentares)
            .WithMany(g => g.Alimentos)
            .HasForeignKey(a => a.GrupoAlimentarId);
    }
}
