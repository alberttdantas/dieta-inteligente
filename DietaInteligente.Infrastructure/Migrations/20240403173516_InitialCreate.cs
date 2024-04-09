using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DietaInteligente.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GrupoAlimentar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoAlimentar", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Objetivos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GrupoAlimentarId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InformacaoNutricionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alimentos_GrupoAlimentar_GrupoAlimentarId",
                        column: x => x.GrupoAlimentarId,
                        principalTable: "GrupoAlimentar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dietas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dietas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dietas_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RestricaoDietetica",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    GrupoAlimentarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestricaoDietetica", x => new { x.UsuarioId, x.GrupoAlimentarId });
                    table.ForeignKey(
                        name: "FK_RestricaoDietetica_GrupoAlimentar_GrupoAlimentarId",
                        column: x => x.GrupoAlimentarId,
                        principalTable: "GrupoAlimentar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestricaoDietetica_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InformacaoNutricional",
                columns: table => new
                {
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    Calorias = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Proteinas = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Gorduras = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Carboidratos = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Fibras = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacaoNutricional", x => x.AlimentoId);
                    table.ForeignKey(
                        name: "FK_InformacaoNutricional_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DietaAlimentos",
                columns: table => new
                {
                    DietaId = table.Column<int>(type: "int", nullable: false),
                    AlimentoId = table.Column<int>(type: "int", nullable: false),
                    QuantidadeGramas = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaAlimentos", x => new { x.DietaId, x.AlimentoId });
                    table.ForeignKey(
                        name: "FK_DietaAlimentos_Alimentos_AlimentoId",
                        column: x => x.AlimentoId,
                        principalTable: "Alimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DietaAlimentos_Dietas_DietaId",
                        column: x => x.DietaId,
                        principalTable: "Dietas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Alimentos_GrupoAlimentarId",
                table: "Alimentos",
                column: "GrupoAlimentarId");

            migrationBuilder.CreateIndex(
                name: "IX_DietaAlimentos_AlimentoId",
                table: "DietaAlimentos",
                column: "AlimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Dietas_UsuarioId",
                table: "Dietas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RestricaoDietetica_GrupoAlimentarId",
                table: "RestricaoDietetica",
                column: "GrupoAlimentarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DietaAlimentos");

            migrationBuilder.DropTable(
                name: "InformacaoNutricional");

            migrationBuilder.DropTable(
                name: "RestricaoDietetica");

            migrationBuilder.DropTable(
                name: "Dietas");

            migrationBuilder.DropTable(
                name: "Alimentos");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "GrupoAlimentar");
        }
    }
}
