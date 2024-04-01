
using DietaInteligente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietaInteligente.Infrastructure.Contexts.EntityConfigurations;

public class DietaEntityConfiguration : IEntityTypeConfiguration<Dieta>
{
    public void Configure(EntityTypeBuilder<Dieta> builder)
    {
        builder.ToTable("Dietas");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id).ValueGeneratedOnAdd();
        builder.Property(d => d.Data).IsRequired();

        builder.HasOne(d => d.Usuarios)
            .WithMany(u => u.Dietas)
            .HasForeignKey(d => d.UsuarioId);
    }
}
