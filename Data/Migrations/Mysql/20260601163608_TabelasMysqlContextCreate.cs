using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core_Providentia_vitae.Data.Migrations.Mysql
{
    /// <inheritdoc />
    public partial class TabelasMysqlContextCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nmMenu = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CdMenuPai = table.Column<uint>(type: "int unsigned", nullable: false),
                    Ordem = table.Column<uint>(type: "int unsigned", nullable: false),
                    SnAtivo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Modulo",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NmModulos = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SnAtivo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DsPerfil = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SnAtivo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    DtCreate = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cracha = table.Column<int>(type: "int", nullable: true),
                    sn_ativo = table.Column<bool>(type: "tinyint(1)", nullable: true, defaultValue: true),
                    sn_funcionario = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ds_usuario = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    senha = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dt_log = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    dt_ult_log = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    dt_create = table.Column<DateTime>(type: "datetime(6)", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP"),
                    dt_update = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuModulo",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cd_Menu = table.Column<uint>(type: "int unsigned", nullable: false),
                    cd_Modulo = table.Column<uint>(type: "int unsigned", nullable: false),
                    MenuId = table.Column<uint>(type: "int unsigned", nullable: false),
                    ModuloId = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModulo_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuModulo_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuarioModulo",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CdUsuario = table.Column<uint>(type: "int unsigned", nullable: false),
                    CdModulo = table.Column<uint>(type: "int unsigned", nullable: false),
                    UsuarioId = table.Column<uint>(type: "int unsigned", nullable: false),
                    ModuloId = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioModulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioModulo_Modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioModulo_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuModuloPerfil",
                columns: table => new
                {
                    Id = table.Column<uint>(type: "int unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    cdMenuModulo = table.Column<uint>(type: "int unsigned", nullable: false),
                    cdPerfil = table.Column<uint>(type: "int unsigned", nullable: false),
                    PerfilId = table.Column<uint>(type: "int unsigned", nullable: false),
                    MenuModuloId = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuModuloPerfil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuModuloPerfil_MenuModulo_MenuModuloId",
                        column: x => x.MenuModuloId,
                        principalTable: "MenuModulo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuModuloPerfil_Perfil_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModulo_MenuId",
                table: "MenuModulo",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModulo_ModuloId",
                table: "MenuModulo",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuloPerfil_MenuModuloId",
                table: "MenuModuloPerfil",
                column: "MenuModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuModuloPerfil_PerfilId",
                table: "MenuModuloPerfil",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModulo_ModuloId",
                table: "UsuarioModulo",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioModulo_UsuarioId",
                table: "UsuarioModulo",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuModuloPerfil");

            migrationBuilder.DropTable(
                name: "UsuarioModulo");

            migrationBuilder.DropTable(
                name: "MenuModulo");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Modulo");
        }
    }
}
