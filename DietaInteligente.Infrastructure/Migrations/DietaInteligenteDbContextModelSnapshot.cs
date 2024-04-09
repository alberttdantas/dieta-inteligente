﻿// <auto-generated />
using System;
using DietaInteligente.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DietaInteligente.Infrastructure.Migrations
{
    [DbContext(typeof(DietaInteligenteDbContext))]
    partial class DietaInteligenteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Alimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GrupoAlimentarId")
                        .HasColumnType("int");

                    b.Property<int>("InformacaoNutricionalId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoAlimentarId");

                    b.ToTable("Alimentos", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Dieta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Dietas", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.DietaAlimento", b =>
                {
                    b.Property<int>("DietaId")
                        .HasColumnType("int");

                    b.Property<int>("AlimentoId")
                        .HasColumnType("int");

                    b.Property<decimal>("QuantidadeGramas")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("DietaId", "AlimentoId");

                    b.HasIndex("AlimentoId");

                    b.ToTable("DietaAlimentos", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.GrupoAlimentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("GrupoAlimentar", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.InformacaoNutricional", b =>
                {
                    b.Property<int>("AlimentoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Calorias")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Carboidratos")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Fibras")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Gorduras")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Proteinas")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("AlimentoId");

                    b.ToTable("InformacaoNutricional", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.RestricaoDietetica", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("GrupoAlimentarId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "GrupoAlimentarId");

                    b.HasIndex("GrupoAlimentarId");

                    b.ToTable("RestricaoDietetica", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Altura")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Objetivos")
                        .HasColumnType("int");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Alimento", b =>
                {
                    b.HasOne("DietaInteligente.Domain.Entities.GrupoAlimentar", "GruposAlimentares")
                        .WithMany("Alimentos")
                        .HasForeignKey("GrupoAlimentarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GruposAlimentares");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Dieta", b =>
                {
                    b.HasOne("DietaInteligente.Domain.Entities.Usuario", "Usuarios")
                        .WithMany("Dietas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.DietaAlimento", b =>
                {
                    b.HasOne("DietaInteligente.Domain.Entities.Alimento", "Alimentos")
                        .WithMany()
                        .HasForeignKey("AlimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietaInteligente.Domain.Entities.Dieta", "Dietas")
                        .WithMany("DietasAlimento")
                        .HasForeignKey("DietaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alimentos");

                    b.Navigation("Dietas");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.InformacaoNutricional", b =>
                {
                    b.HasOne("DietaInteligente.Domain.Entities.Alimento", "ALimento")
                        .WithOne("InformacaoNutricional")
                        .HasForeignKey("DietaInteligente.Domain.Entities.InformacaoNutricional", "AlimentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ALimento");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.RestricaoDietetica", b =>
                {
                    b.HasOne("DietaInteligente.Domain.Entities.GrupoAlimentar", "GrupoAlimentar")
                        .WithMany()
                        .HasForeignKey("GrupoAlimentarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DietaInteligente.Domain.Entities.Usuario", "Usuario")
                        .WithMany("RestricoesDieteticas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoAlimentar");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Alimento", b =>
                {
                    b.Navigation("InformacaoNutricional")
                        .IsRequired();
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Dieta", b =>
                {
                    b.Navigation("DietasAlimento");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.GrupoAlimentar", b =>
                {
                    b.Navigation("Alimentos");
                });

            modelBuilder.Entity("DietaInteligente.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Dietas");

                    b.Navigation("RestricoesDieteticas");
                });
#pragma warning restore 612, 618
        }
    }
}
