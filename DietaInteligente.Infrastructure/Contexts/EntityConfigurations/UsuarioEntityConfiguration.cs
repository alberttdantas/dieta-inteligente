
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class UsuarioEntityConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nome).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.Peso).HasColumnType("decimal(18, 2)").IsRequired();
        builder.Property(u => u.Altura).HasColumnType("decimal(18, 2)").IsRequired();
        builder.Property(u => u.Objetivos).HasConversion<int>();

        builder.HasMany(u => u.Dietas)
            .WithOne(d => d.Usuarios)
            .HasForeignKey(d => d.UsuarioId);

        builder.HasMany(u => u.RestricoesDieteticas)
            .WithOne(r => r.Usuario)
            .HasForeignKey(r => r.UsuarioId);
    }
}
