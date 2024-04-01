
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class InformacaoNutricionalEntityConfiguration : IEntityTypeConfiguration<InformacaoNutricional>
{
    public void Configure(EntityTypeBuilder<InformacaoNutricional> builder)
    {
        builder.ToTable("InformacaoNutricional");
        builder.HasKey(i => i.AlimentoId);

        builder.HasOne(i => i.ALimento)
            .WithOne(a => a.InformacaoNutricional)
            .HasForeignKey<InformacaoNutricional>(i => i.AlimentoId);

        builder.Property(i => i.Calorias).IsRequired();
        builder.Property(i => i.Proteinas).IsRequired();
        builder.Property(i => i.Carboidratos).IsRequired();
        builder.Property(i => i.Fibras).IsRequired();
        builder.Property(i => i.Gorduras).IsRequired();
    }
}
