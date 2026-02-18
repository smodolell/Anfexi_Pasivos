using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anfx.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSistema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sac");

            migrationBuilder.EnsureSchema(
                name: "web");

            migrationBuilder.EnsureSchema(
                name: "cat");

            migrationBuilder.CreateTable(
                name: "Empresa",
                schema: "sac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Representante = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    AvisosEstadodeCuenta = table.Column<string>(type: "text", nullable: false),
                    AdvertenciasEstadodeCuenta = table.Column<string>(type: "text", nullable: false),
                    AclaracionesEstadodeCuenta = table.Column<string>(type: "text", nullable: false),
                    UsaDesembolso = table.Column<bool>(type: "bit", nullable: false),
                    Pasivo = table.Column<bool>(type: "bit", nullable: false),
                    TipoDireccionId = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumExterior = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumInterior = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ColoniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuId_Padre = table.Column<int>(type: "int", nullable: true),
                    Menu = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Controlador = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Menu_MenuId_Padre",
                        column: x => x.MenuId_Padre,
                        principalSchema: "web",
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoDireccion",
                schema: "cat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDireccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDireccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                schema: "web",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    UsuarioNombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalSchema: "web",
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_RazonSocial",
                schema: "sac",
                table: "Empresa",
                column: "RazonSocial");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_RFC",
                schema: "sac",
                table: "Empresa",
                column: "RFC");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Activo",
                schema: "web",
                table: "Menu",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Area_Controlador_Accion",
                schema: "web",
                table: "Menu",
                columns: new[] { "Area", "Controlador", "Accion" });

            migrationBuilder.CreateIndex(
                name: "IX_Menu_MenuId_Padre",
                schema: "web",
                table: "Menu",
                column: "MenuId_Padre");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_Activo",
                schema: "web",
                table: "Rol",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_sRol",
                schema: "web",
                table: "Rol",
                column: "Rol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipoDireccion_sTipoDireccion",
                schema: "cat",
                table: "TipoDireccion",
                column: "TipoDireccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Activo",
                schema: "web",
                table: "Usuario",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                schema: "web",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email_Activo",
                schema: "web",
                table: "Usuario",
                columns: new[] { "Email", "Activo" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                schema: "web",
                table: "Usuario",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioNombre",
                schema: "web",
                table: "Usuario",
                column: "UsuarioNombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa",
                schema: "sac");

            migrationBuilder.DropTable(
                name: "Menu",
                schema: "web");

            migrationBuilder.DropTable(
                name: "TipoDireccion",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Usuario",
                schema: "web");

            migrationBuilder.DropTable(
                name: "Rol",
                schema: "web");
        }
    }
}
