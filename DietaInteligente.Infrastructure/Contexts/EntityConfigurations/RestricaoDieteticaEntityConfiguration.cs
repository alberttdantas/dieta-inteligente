
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class RestricaoDieteticaEntityConfiguration : IEntityTypeConfiguration<RestricaoDietetica>
{
    public void Configure(EntityTypeBuilder<RestricaoDietetica> builder)
    {
        builder.ToTable("RestricaoDietetica");
        builder.HasKey(r => new { r.UsuarioId, r.GrupoAlimentarId });

        builder.HasOne(r => r.Usuario)
            .WithMany(u => u.RestricoesDieteticas)
            .HasForeignKey(r => r.UsuarioId);

        builder.HasOne(r => r.GrupoAlimentar)
            .WithMany()
            .HasForeignKey(r => r.GrupoAlimentarId);
    }
}
