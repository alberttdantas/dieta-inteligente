
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class DietaAlimentoEntityConfiguration : IEntityTypeConfiguration<DietaAlimento>
{
    public void Configure(EntityTypeBuilder<DietaAlimento> builder)
    {
        builder.ToTable("DietaAlimentos");
        builder.HasKey(da => new { da.DietaId, da.AlimentoId });
        builder.Property(da => da.QuantidadeGramas).IsRequired();

        builder.HasOne(da => da.Dietas)
            .WithMany(d => d.DietasAlimento)
            .HasForeignKey(da => da.DietaId);

        builder.HasOne(da => da.Alimentos)
            .WithMany()
            .HasForeignKey(da => da.AlimentoId);
    }
}
