using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PlanningPocker.Repository.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "PlanningPoker");

            migrationBuilder.CreateTable(
                name: "Cartas",
                schema: "PlanningPoker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorDaCarta = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaDoUsuarios",
                schema: "PlanningPoker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaDoUsuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                schema: "PlanningPoker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "PlanningPoker",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdCarta = table.Column<long>(type: "bigint", nullable: false),
                    IdHistoriaDoUsuario = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Cartas_IdCarta",
                        column: x => x.IdCarta,
                        principalSchema: "PlanningPoker",
                        principalTable: "Cartas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_HistoriaDoUsuarios_IdHistoriaDoUsuario",
                        column: x => x.IdHistoriaDoUsuario,
                        principalSchema: "PlanningPoker",
                        principalTable: "HistoriaDoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "PlanningPoker",
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdCarta",
                schema: "PlanningPoker",
                table: "Usuario",
                column: "IdCarta");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdHistoriaDoUsuario",
                schema: "PlanningPoker",
                table: "Usuario",
                column: "IdHistoriaDoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdUsuario",
                schema: "PlanningPoker",
                table: "Usuario",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "PlanningPoker");

            migrationBuilder.DropTable(
                name: "Cartas",
                schema: "PlanningPoker");

            migrationBuilder.DropTable(
                name: "HistoriaDoUsuarios",
                schema: "PlanningPoker");

            migrationBuilder.DropTable(
                name: "Usuarios",
                schema: "PlanningPoker");
        }
    }
}
