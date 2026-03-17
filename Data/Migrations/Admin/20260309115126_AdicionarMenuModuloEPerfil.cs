using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Providentia_vitae.Data.Migrations.Admin
{
    /// <inheritdoc />
    public partial class AdicionarMenuModuloEPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "cd_modulo",
                table: "usuario_modulos",
                newName: "cd_modulo1");

            migrationBuilder.CreateTable(
                name: "menu",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmMenu = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sn_ativo = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    dt_create = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "menu_modulos",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false),
                    cd_menu = table.Column<uint>(type: "int unsigned", nullable: false),
                    cd_modulo = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_modulos_menu_cd_menu",
                        column: x => x.cd_menu,
                        principalTable: "menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_modulos_modulos_cd_modulo",
                        column: x => x.cd_modulo,
                        principalTable: "modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "cd_menu",
                table: "menu_modulos",
                column: "cd_menu");

            migrationBuilder.CreateIndex(
                name: "cd_modulo",
                table: "menu_modulos",
                column: "cd_modulo");

            migrationBuilder.CreateIndex(
                name: "IX_menu_modulos_cd_menu",
                table: "menu_modulos",
                column: "cd_menu");

            migrationBuilder.CreateIndex(
                name: "IX_menu_modulos_cd_modulo",
                table: "menu_modulos",
                column: "cd_modulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_modulos");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.RenameIndex(
                name: "cd_modulo1",
                table: "usuario_modulos",
                newName: "cd_modulo");
        }
    }
}
