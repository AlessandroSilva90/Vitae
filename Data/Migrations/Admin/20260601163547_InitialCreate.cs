using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Providentia_vitae.Data.Migrations.Admin
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
                name: "menu",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmMenu = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cdMenuPai = table.Column<uint>(type: "int unsigned", nullable: false),
                    ordem = table.Column<uint>(type: "int unsigned", nullable: false),
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
                name: "modulos",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmModulos = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    snAtivo = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    DtCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_perfil = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sn_ativo = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    dt_create = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP(6)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cracha = table.Column<int>(type: "int", nullable: true),
                    Sn_Ativo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Sn_Funcionario = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Ds_Usuario = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Senha = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dt_Log = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Dt_Ult_Log = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Dt_Create = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Dt_Update = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "menu_modulos",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "usuario_modulos",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_usuario = table.Column<uint>(type: "int unsigned", nullable: false),
                    cd_modulo = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuario_modulos_Usuarios_cd_usuario",
                        column: x => x.cd_usuario,
                        principalTable: "Usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usuario_modulos_modulos_cd_modulo",
                        column: x => x.cd_modulo,
                        principalTable: "modulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "menu_modulo_perfils",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
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
                        principalColumn: "Id",
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

            migrationBuilder.CreateIndex(
                name: "cd_modulo1",
                table: "usuario_modulos",
                column: "cd_modulo");

            migrationBuilder.CreateIndex(
                name: "cd_usuario",
                table: "usuario_modulos",
                column: "cd_usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menu_modulo_perfils");

            migrationBuilder.DropTable(
                name: "usuario_modulos");

            migrationBuilder.DropTable(
                name: "menu_modulos");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "menu");

            migrationBuilder.DropTable(
                name: "modulos");
        }
    }
}
