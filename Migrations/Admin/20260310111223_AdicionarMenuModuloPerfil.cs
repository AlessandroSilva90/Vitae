using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Providentia_vitae.Migrations.Admin
{
    /// <inheritdoc />
    public partial class AdicionarMenuModuloPerfil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "menu_modulo_perfils",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false),
                    cd_menu_modulo = table.Column<uint>(type: "int unsigned", nullable: false),
                    cd_perfil = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_menu_modulo_perfils_menu_modulos_cd_menu_modulo",
                        column: x => x.cd_menu_modulo,
                        principalTable: "menu_modulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_menu_modulo_perfils_perfil_cd_perfil",
                        column: x => x.cd_perfil,
                        principalTable: "perfil",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "cd_menu_modulo",
                table: "menu_modulo_perfils",
                column: "cd_menu_modulo");

            migrationBuilder.CreateIndex(
                name: "cd_perfil",
                table: "menu_modulo_perfils",
                column: "cd_perfil");

            migrationBuilder.CreateIndex(
                name: "IX_menu_modulos_cd_menu_modulo",
                table: "menu_modulo_perfils",
                column: "cd_menu_modulo");

            migrationBuilder.CreateIndex(
                name: "IX_menu_modulos_cd_perfil",
                table: "menu_modulo_perfils",
                column: "cd_perfil");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_modulo_perfils");
        }
    }
}
