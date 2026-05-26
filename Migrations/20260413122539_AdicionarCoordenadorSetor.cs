using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Providentia_vitae.Migrations
{
    /// <inheritdoc />
    public partial class AdicionarCoordenadorSetor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "coordenador_setor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_coordenador = table.Column<string>(type: "varchar(50)", nullable: true, defaultValueSql: "'0'", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cd_setor = table.Column<string>(type: "varchar(50)", nullable: true, defaultValueSql: "'0'", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dt_inicio = table.Column<DateOnly>(type: "date", nullable: true),
                    dt_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    dt_create = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "coordenador_usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_coordenador = table.Column<int>(type: "int", nullable: false),
                    cd_funcionario = table.Column<int>(type: "int", nullable: false),
                    dt_inicio = table.Column<DateOnly>(type: "date", nullable: true),
                    dt_fim = table.Column<DateOnly>(type: "date", nullable: true),
                    dt_create = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "troca_plantao",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_solicitante = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    cd_substituto = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    dt_plantao_original = table.Column<DateOnly>(type: "date", nullable: false),
                    hr_entrada_plantao_original = table.Column<TimeSpan>(type: "time", nullable: false),
                    hr_saida_plantao_original = table.Column<TimeSpan>(type: "time", nullable: false),
                    dt_plantao_troca = table.Column<DateOnly>(type: "date", nullable: false),
                    hr_entrada_plantao_troca = table.Column<TimeSpan>(type: "time", nullable: false),
                    hr_saida_plantao_troca = table.Column<TimeSpan>(type: "time", nullable: false),
                    motivo_troca = table.Column<string>(type: "text", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sn_aceito = table.Column<string>(type: "enum('S','N','P')", nullable: true, defaultValueSql: "'P'", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dt_solicitacao = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    dt_resposta = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "cd_coordenador",
                table: "coordenador_setor",
                column: "cd_coordenador");

            migrationBuilder.CreateIndex(
                name: "setor",
                table: "coordenador_setor",
                column: "cd_setor");

            migrationBuilder.CreateIndex(
                name: "cd_coordenador1",
                table: "coordenador_usuario",
                column: "cd_coordenador");

            migrationBuilder.CreateIndex(
                name: "cd_funcionario",
                table: "coordenador_usuario",
                column: "cd_funcionario");

            migrationBuilder.CreateIndex(
                name: "idx_dt_plantao_original",
                table: "troca_plantao",
                column: "dt_plantao_original");

            migrationBuilder.CreateIndex(
                name: "idx_solicitante",
                table: "troca_plantao",
                column: "cd_solicitante");

            migrationBuilder.CreateIndex(
                name: "idx_substituto",
                table: "troca_plantao",
                column: "cd_substituto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coordenador_setor");

            migrationBuilder.DropTable(
                name: "coordenador_usuario");

            migrationBuilder.DropTable(
                name: "troca_plantao");
        }
    }
}
