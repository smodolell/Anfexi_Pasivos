using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Anfx.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialPasivos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "psv");

            migrationBuilder.AddColumn<int>(
                name: "GeneroIdGenero",
                schema: "web",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PSV_MenuID",
                schema: "web",
                table: "Rol",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Catalogo",
                schema: "cat",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tabla = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Colonia",
                schema: "cat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Colonia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colonia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstatusContrato",
                schema: "cat",
                columns: table => new
                {
                    IdEstatusContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusContrato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusContrato", x => x.IdEstatusContrato);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                schema: "cat",
                columns: table => new
                {
                    IdGenero = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.IdGenero);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Archivo",
                schema: "psv",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contenido = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Archivo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Banco",
                schema: "psv",
                columns: table => new
                {
                    IdBanco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Banco = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Banco", x => x.IdBanco);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Bitacora",
                schema: "psv",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pantalla = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaOperacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Bitacora", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PSV_EstatusContrato",
                schema: "psv",
                columns: table => new
                {
                    IdEstatusContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstatusContrato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_EstatusContrato", x => x.IdEstatusContrato);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Fondeador",
                schema: "psv",
                columns: table => new
                {
                    IdFondeador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fondeador = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClaveCuentaContable = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Fondeador", x => x.IdFondeador);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Menu",
                schema: "psv",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Controller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Orden = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Menu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Parameter",
                schema: "psv",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Parameter", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoCapitalizacion",
                schema: "psv",
                columns: table => new
                {
                    IdTipoCapitalizacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCapitalizacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoCapitalizacion", x => x.IdTipoCapitalizacion);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoPago",
                schema: "psv",
                columns: table => new
                {
                    IdTipoPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPago = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoPago", x => x.IdTipoPago);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoPagoCapital",
                schema: "psv",
                columns: table => new
                {
                    IdTipoPagoCapital = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoPagoCapital = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoPagoCapital", x => x.IdTipoPagoCapital);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoTablaAmortiza",
                schema: "psv",
                columns: table => new
                {
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTablaAmortiza = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EsCapitalizable = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoTablaAmortiza", x => x.IdTipoTablaAmortiza);
                });

            migrationBuilder.CreateTable(
                name: "SB_Periodicidad",
                schema: "cat",
                columns: table => new
                {
                    IdPeriodicidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CveCortaPeriodicidad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DescPeriodicidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParamDias = table.Column<int>(type: "int", nullable: true),
                    ParamMes = table.Column<int>(type: "int", nullable: true),
                    sDefault = table.Column<bool>(type: "bit", nullable: false),
                    Band = table.Column<bool>(type: "bit", nullable: false),
                    PedirDiasVencimiento = table.Column<bool>(type: "bit", nullable: true),
                    CantidadDiasVencimiento = table.Column<int>(type: "int", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: true),
                    NoPagosMes = table.Column<int>(type: "int", nullable: true),
                    NroPagosAnio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SB_Periodicidad", x => x.IdPeriodicidad);
                });

            migrationBuilder.CreateTable(
                name: "SB_TipoMoneda",
                schema: "cat",
                columns: table => new
                {
                    IdTipoMoneda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoMoneda = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CveCortaTipoMoneda = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    sDefault = table.Column<bool>(type: "bit", nullable: false),
                    MontoConvercion = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SB_TipoMoneda", x => x.IdTipoMoneda);
                });

            migrationBuilder.CreateTable(
                name: "TipoCalculoTasaVariable",
                schema: "cat",
                columns: table => new
                {
                    IdTipoCalculoTasaVariable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCalculoTasaVariable = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Proceso = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCalculoTasaVariable", x => x.IdTipoCalculoTasaVariable);
                });

            migrationBuilder.CreateTable(
                name: "TipoGeneracionComprobante",
                schema: "cat",
                columns: table => new
                {
                    IdTipoGeneracionComprobante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoGeneracionComprobante = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoGeneracionComprobante", x => x.IdTipoGeneracionComprobante);
                });

            migrationBuilder.CreateTable(
                name: "TipoMantenimiento",
                schema: "cat",
                columns: table => new
                {
                    IdTipoMantenimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMantenimiento", x => x.IdTipoMantenimiento);
                });

            migrationBuilder.CreateTable(
                name: "PSV_CuentaBancaria",
                schema: "psv",
                columns: table => new
                {
                    IdCuentaBancaria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBanco = table.Column<int>(type: "int", nullable: false),
                    CuentaBancaria = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CLABE = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_CuentaBancaria", x => x.IdCuentaBancaria);
                    table.ForeignKey(
                        name: "FK_PSV_CuentaBancaria_PSV_Banco_IdBanco",
                        column: x => x.IdBanco,
                        principalSchema: "psv",
                        principalTable: "PSV_Banco",
                        principalColumn: "IdBanco",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoTablaAmortizaTipoCapitalizacion",
                schema: "psv",
                columns: table => new
                {
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false),
                    IdTipoCapitalizacion = table.Column<int>(type: "int", nullable: false),
                    Seleccionado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoTablaAmortizaTipoCapitalizacion", x => new { x.IdTipoTablaAmortiza, x.IdTipoCapitalizacion });
                    table.ForeignKey(
                        name: "FK_PSV_TipoTablaAmortizaTipoCapitalizacion_PSV_TipoCapitalizacion_IdTipoCapitalizacion",
                        column: x => x.IdTipoCapitalizacion,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoCapitalizacion",
                        principalColumn: "IdTipoCapitalizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTablaAmortizaTipoCapitalizacion_PSV_TipoTablaAmortiza_IdTipoTablaAmortiza",
                        column: x => x.IdTipoTablaAmortiza,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTablaAmortiza",
                        principalColumn: "IdTipoTablaAmortiza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoTablaAmortizaTipoPagoCapital",
                schema: "psv",
                columns: table => new
                {
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false),
                    IdTipoPagoCapital = table.Column<int>(type: "int", nullable: false),
                    Seleccionado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoTablaAmortizaTipoPagoCapital", x => new { x.IdTipoTablaAmortiza, x.IdTipoPagoCapital });
                    table.ForeignKey(
                        name: "FK_PSV_TipoTablaAmortizaTipoPagoCapital_PSV_TipoPagoCapital_IdTipoPagoCapital",
                        column: x => x.IdTipoPagoCapital,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoPagoCapital",
                        principalColumn: "IdTipoPagoCapital",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTablaAmortizaTipoPagoCapital_PSV_TipoTablaAmortiza_IdTipoTablaAmortiza",
                        column: x => x.IdTipoTablaAmortiza,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTablaAmortiza",
                        principalColumn: "IdTipoTablaAmortiza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoTablaAmortizaPeriodicidad",
                schema: "psv",
                columns: table => new
                {
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false),
                    IdPeriodicidad = table.Column<int>(type: "int", nullable: false),
                    Seleccionado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoTablaAmortizaPeriodicidad", x => new { x.IdTipoTablaAmortiza, x.IdPeriodicidad });
                    table.ForeignKey(
                        name: "FK_PSV_TipoTablaAmortizaPeriodicidad_PSV_TipoTablaAmortiza_IdTipoTablaAmortiza",
                        column: x => x.IdTipoTablaAmortiza,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTablaAmortiza",
                        principalColumn: "IdTipoTablaAmortiza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTablaAmortizaPeriodicidad_SB_Periodicidad_IdPeriodicidad",
                        column: x => x.IdPeriodicidad,
                        principalSchema: "cat",
                        principalTable: "SB_Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                schema: "cat",
                columns: table => new
                {
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClaveTipoMovimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GeneraIVACapital = table.Column<bool>(type: "bit", nullable: true),
                    GeneraMora = table.Column<bool>(type: "bit", nullable: true),
                    Capturable = table.Column<bool>(type: "bit", nullable: true),
                    EsRenta = table.Column<bool>(type: "bit", nullable: true),
                    Estatus = table.Column<bool>(type: "bit", nullable: true),
                    Orden = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GeneraIVAInteres = table.Column<bool>(type: "bit", nullable: true),
                    IdTipoGeneracionComprobante = table.Column<int>(type: "int", nullable: true),
                    SeparaComprobante = table.Column<bool>(type: "bit", nullable: true),
                    CalificaCarteraVencida = table.Column<bool>(type: "bit", nullable: true),
                    GeneraCapital = table.Column<bool>(type: "bit", nullable: true),
                    GeneraInteres = table.Column<bool>(type: "bit", nullable: true),
                    GeneraFees = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.IdTipoMovimiento);
                    table.ForeignKey(
                        name: "FK_TipoMovimiento_TipoGeneracionComprobante_IdTipoGeneracionComprobante",
                        column: x => x.IdTipoGeneracionComprobante,
                        principalSchema: "cat",
                        principalTable: "TipoGeneracionComprobante",
                        principalColumn: "IdTipoGeneracionComprobante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Pago",
                schema: "psv",
                columns: table => new
                {
                    IdPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoPago = table.Column<int>(type: "int", nullable: false),
                    IdCuentaBancaria = table.Column<int>(type: "int", nullable: false),
                    Contrato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FecPagoRegistro = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecPagoValor = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MontoPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoPagoAplicado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoPago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Suspenso = table.Column<bool>(type: "bit", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FecUltimoCambio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdFondeador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Pago", x => x.IdPago);
                    table.ForeignKey(
                        name: "FK_PSV_Pago_PSV_CuentaBancaria_IdCuentaBancaria",
                        column: x => x.IdCuentaBancaria,
                        principalSchema: "psv",
                        principalTable: "PSV_CuentaBancaria",
                        principalColumn: "IdCuentaBancaria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Pago_PSV_Fondeador_IdFondeador",
                        column: x => x.IdFondeador,
                        principalSchema: "psv",
                        principalTable: "PSV_Fondeador",
                        principalColumn: "IdFondeador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Pago_PSV_TipoPago_IdTipoPago",
                        column: x => x.IdTipoPago,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoPago",
                        principalColumn: "IdTipoPago",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoCredito",
                schema: "psv",
                columns: table => new
                {
                    IdTipoCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCredito = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    Prefijo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Sufijo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Contador = table.Column<int>(type: "int", nullable: false),
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoMovimiento_Mora = table.Column<int>(type: "int", nullable: false),
                    PeriodoGracia = table.Column<int>(type: "int", nullable: false),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoCredito", x => x.IdTipoCredito);
                    table.ForeignKey(
                        name: "FK_PSV_TipoCredito_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "sac",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoCredito_PSV_TipoTablaAmortiza_IdTipoTablaAmortiza",
                        column: x => x.IdTipoTablaAmortiza,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTablaAmortiza",
                        principalColumn: "IdTipoTablaAmortiza",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoCredito_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoCredito_TipoMovimiento_IdTipoMovimiento_Mora",
                        column: x => x.IdTipoMovimiento_Mora,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoTerminacion",
                schema: "psv",
                columns: table => new
                {
                    IdTipoTerminacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoTerminacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdTipoMovimientoBaja = table.Column<int>(type: "int", nullable: false),
                    IdTipoMovimientoPena = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoInteres = table.Column<int>(type: "int", nullable: true),
                    PermiteUsarDeposito = table.Column<bool>(type: "bit", nullable: false),
                    IdCuentaBancariaDeposito = table.Column<int>(type: "int", nullable: true),
                    IdTipoPagoDeposito = table.Column<int>(type: "int", nullable: true),
                    SumaInteresSigAmortizacion = table.Column<bool>(type: "bit", nullable: false),
                    PermiteCalculoInteres = table.Column<bool>(type: "bit", nullable: false),
                    EsLiquidacionTotal = table.Column<bool>(type: "bit", nullable: false),
                    EsPorcAnticipo_PenaAnticipo = table.Column<bool>(type: "bit", nullable: false),
                    PorcAnticipo_PenaAnticipo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EsDiasVencidos = table.Column<bool>(type: "bit", nullable: false),
                    DiasVencidos = table.Column<int>(type: "int", nullable: true),
                    IdEstatusContratoTerminacion = table.Column<int>(type: "int", nullable: true),
                    PSV_CuentaBancariaIdCuentaBancaria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoTerminacion", x => x.IdTipoTerminacion);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_PSV_CuentaBancaria_IdCuentaBancariaDeposito",
                        column: x => x.IdCuentaBancariaDeposito,
                        principalSchema: "psv",
                        principalTable: "PSV_CuentaBancaria",
                        principalColumn: "IdCuentaBancaria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_PSV_CuentaBancaria_PSV_CuentaBancariaIdCuentaBancaria",
                        column: x => x.PSV_CuentaBancariaIdCuentaBancaria,
                        principalSchema: "psv",
                        principalTable: "PSV_CuentaBancaria",
                        principalColumn: "IdCuentaBancaria");
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_PSV_EstatusContrato_IdEstatusContratoTerminacion",
                        column: x => x.IdEstatusContratoTerminacion,
                        principalSchema: "psv",
                        principalTable: "PSV_EstatusContrato",
                        principalColumn: "IdEstatusContrato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_PSV_TipoPago_IdTipoPagoDeposito",
                        column: x => x.IdTipoPagoDeposito,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoPago",
                        principalColumn: "IdTipoPago",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_TipoMovimiento_IdTipoMovimientoBaja",
                        column: x => x.IdTipoMovimientoBaja,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_TipoMovimiento_IdTipoMovimientoInteres",
                        column: x => x.IdTipoMovimientoInteres,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_TipoTerminacion_TipoMovimiento_IdTipoMovimientoPena",
                        column: x => x.IdTipoMovimientoPena,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoCredito",
                schema: "cat",
                columns: table => new
                {
                    IdTipoCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaveTipoCredito = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoCredito = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: true),
                    PermiteEnganche = table.Column<bool>(type: "bit", nullable: true),
                    CausaPenaPrepago = table.Column<bool>(type: "bit", nullable: true),
                    PermiteBallonPayment = table.Column<bool>(type: "bit", nullable: true),
                    ManejaActivos = table.Column<bool>(type: "bit", nullable: true),
                    PermiteDepositoEnGarantia = table.Column<bool>(type: "bit", nullable: true),
                    PermiteOpcionDeCompra = table.Column<bool>(type: "bit", nullable: true),
                    ActivosConIvaSumanCapital = table.Column<bool>(type: "bit", nullable: true),
                    CalculaIvaTasaReal = table.Column<bool>(type: "bit", nullable: true),
                    PermiteValorResidual = table.Column<bool>(type: "bit", nullable: true),
                    Prefijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Postfijo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consecutivo = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoEnganche = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoBallon = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoValorResidual = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoDeposito = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoOpcion = table.Column<int>(type: "int", nullable: true),
                    IdEmpresa = table.Column<int>(type: "int", nullable: true),
                    EsquemaFinanciero = table.Column<int>(type: "int", nullable: false),
                    TasaMoraDefault = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTipoMovimientoMora = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoGastos = table.Column<int>(type: "int", nullable: true),
                    FactorGastoCob = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MaxMontoGastoCob = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PeriodoGracia = table.Column<int>(type: "int", nullable: true),
                    IdTipoMovimientoCancelCheque = table.Column<int>(type: "int", nullable: true),
                    PorcCancelacionCheque = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoPenaNoDevuelto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTipoMovimientoNoDevuelto = table.Column<int>(type: "int", nullable: true),
                    IdMonedaNoDevuelto = table.Column<int>(type: "int", nullable: true),
                    MesesDePenaNoDevuelto = table.Column<int>(type: "int", nullable: true),
                    MontoKilometraje = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTipoMonedaKm = table.Column<int>(type: "int", nullable: true),
                    CargoCheque = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AplicaGraciaCapital = table.Column<bool>(type: "bit", nullable: true),
                    GraciaCapital = table.Column<int>(type: "int", nullable: true),
                    CATMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcComApertura = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Gastoslegales = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GastosdeRegistro = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PermiteSubsidio = table.Column<bool>(type: "bit", nullable: true),
                    PermiteCreditoGrupal = table.Column<bool>(type: "bit", nullable: true),
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: true),
                    PermiteGastosAdministracion = table.Column<bool>(type: "bit", nullable: true),
                    IdTipoProducto = table.Column<int>(type: "int", nullable: true),
                    FactorTasaMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PermiteLimiteMontoCredito = table.Column<bool>(type: "bit", nullable: false),
                    MontoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PermiteSeguroEnPeriodo = table.Column<bool>(type: "bit", nullable: false),
                    IdTipoMovimientoSeguro = table.Column<int>(type: "int", nullable: true),
                    PorcSeguroEnPeriodo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PermiteAforo = table.Column<bool>(type: "bit", nullable: false),
                    PorcAforo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PermiteGraciaCapitalInteres = table.Column<bool>(type: "bit", nullable: false),
                    FactorCapadicadDePago = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PermiteTasaVariable = table.Column<bool>(type: "bit", nullable: false),
                    PermiteUsarPAyFactor = table.Column<bool>(type: "bit", nullable: false),
                    SeUsaEnPasivos = table.Column<bool>(type: "bit", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCredito", x => x.IdTipoCredito);
                    table.ForeignKey(
                        name: "FK_TipoCredito_Empresa_IdEmpresa",
                        column: x => x.IdEmpresa,
                        principalSchema: "sac",
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoBallon",
                        column: x => x.IdTipoMovimientoBallon,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoCancelCheque",
                        column: x => x.IdTipoMovimientoCancelCheque,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoDeposito",
                        column: x => x.IdTipoMovimientoDeposito,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoEnganche",
                        column: x => x.IdTipoMovimientoEnganche,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoGastos",
                        column: x => x.IdTipoMovimientoGastos,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoMora",
                        column: x => x.IdTipoMovimientoMora,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoNoDevuelto",
                        column: x => x.IdTipoMovimientoNoDevuelto,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoOpcion",
                        column: x => x.IdTipoMovimientoOpcion,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoSeguro",
                        column: x => x.IdTipoMovimientoSeguro,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TipoCredito_TipoMovimiento_IdTipoMovimientoValorResidual",
                        column: x => x.IdTipoMovimientoValorResidual,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TipoCreditoPSV_TipoTerminacion",
                schema: "psv",
                columns: table => new
                {
                    PSV_TipoCreditoIdTipoCredito = table.Column<int>(type: "int", nullable: false),
                    PSV_TipoTerminacionIdTipoTerminacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TipoCreditoPSV_TipoTerminacion", x => new { x.PSV_TipoCreditoIdTipoCredito, x.PSV_TipoTerminacionIdTipoTerminacion });
                    table.ForeignKey(
                        name: "FK_PSV_TipoCreditoPSV_TipoTerminacion_PSV_TipoCredito_PSV_TipoCreditoIdTipoCredito",
                        column: x => x.PSV_TipoCreditoIdTipoCredito,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoCredito",
                        principalColumn: "IdTipoCredito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_TipoCreditoPSV_TipoTerminacion_PSV_TipoTerminacion_PSV_TipoTerminacionIdTipoTerminacion",
                        column: x => x.PSV_TipoTerminacionIdTipoTerminacion,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTerminacion",
                        principalColumn: "IdTipoTerminacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasa",
                schema: "cat",
                columns: table => new
                {
                    IdTasa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tasa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ValorTasa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FecTasa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EsVariable = table.Column<bool>(type: "bit", nullable: true),
                    IdFondeador = table.Column<int>(type: "int", nullable: true),
                    Spred = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RangoMinimo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RangoMaximo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTipoCredito = table.Column<int>(type: "int", nullable: true),
                    IdPlazo = table.Column<int>(type: "int", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CodeDofGob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCreditoIdTipoCredito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasa", x => x.IdTasa);
                    table.ForeignKey(
                        name: "FK_Tasa_TipoCredito_IdTipoCredito",
                        column: x => x.IdTipoCredito,
                        principalSchema: "cat",
                        principalTable: "TipoCredito",
                        principalColumn: "IdTipoCredito",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasa_TipoCredito_TipoCreditoIdTipoCredito",
                        column: x => x.TipoCreditoIdTipoCredito,
                        principalSchema: "cat",
                        principalTable: "TipoCredito",
                        principalColumn: "IdTipoCredito");
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                schema: "sac",
                columns: table => new
                {
                    IdContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdPersona = table.Column<int>(type: "int", nullable: true),
                    IdTipoCredito = table.Column<int>(type: "int", nullable: true),
                    IdEstatusContrato = table.Column<int>(type: "int", nullable: true),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcEnganche = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Enganche = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CapitalFinanciado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdPeriodicidad = table.Column<int>(type: "int", nullable: false),
                    Plazo = table.Column<int>(type: "int", nullable: true),
                    IdMoneda = table.Column<int>(type: "int", nullable: false),
                    FecInicioContrato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecPrimeraRenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActivacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecFinContrato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdTasa = table.Column<int>(type: "int", nullable: false),
                    TasaBase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PuntosMas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PuntosPor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tasa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaBaseMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTasaMora = table.Column<int>(type: "int", nullable: false),
                    PuntosMasMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PuntosPorMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FactorMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaldoInsoluto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BallonPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcBallonPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorResidual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcValorResidual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepositoEnGarantia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OpcionDeCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcOpcionDeCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaIva = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VersionTabla = table.Column<int>(type: "int", nullable: true),
                    IdTipoCalculoTasaVariable = table.Column<int>(type: "int", nullable: true),
                    NroRentasDepositoGarantia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FechaFirmaContrato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdTipoMantenimiento = table.Column<int>(type: "int", nullable: true),
                    TasaMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: true),
                    IdSucursal = table.Column<int>(type: "int", nullable: true),
                    IdReestructura = table.Column<int>(type: "int", nullable: true),
                    IdSector = table.Column<int>(type: "int", nullable: true),
                    IdSubSector = table.Column<int>(type: "int", nullable: true),
                    EsWriteOff = table.Column<bool>(type: "bit", nullable: true),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCotizador = table.Column<int>(type: "int", nullable: true),
                    TasaEsVariable = table.Column<bool>(type: "bit", nullable: true),
                    GraciaCapital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraciaInteres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FactorFIRA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdCredito = table.Column<int>(type: "int", nullable: true),
                    NumeroPagosCapital = table.Column<int>(type: "int", nullable: true),
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: true),
                    IdPeriodicidad_TTA = table.Column<int>(type: "int", nullable: true),
                    IdTipoPagoCapital = table.Column<int>(type: "int", nullable: true),
                    NoPagosIrregulares = table.Column<int>(type: "int", nullable: true),
                    IdTipoCapitalizacion = table.Column<int>(type: "int", nullable: true),
                    Emproblemado = table.Column<bool>(type: "bit", nullable: false),
                    InversionPrincipal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPeriodicidadTC = table.Column<int>(type: "int", nullable: false),
                    CapturaManualTAPasiva = table.Column<bool>(type: "bit", nullable: false),
                    Tasa2IdTasa = table.Column<int>(type: "int", nullable: false),
                    TipoCalculoTasaVariableIdTipoCalculoTasaVariable = table.Column<int>(type: "int", nullable: false),
                    TipoMantenimientoIdTipoMantenimiento = table.Column<int>(type: "int", nullable: false),
                    PSV_TipoCapitalizacionIdTipoCapitalizacion = table.Column<int>(type: "int", nullable: false),
                    PSV_TipoPagoCapitalIdTipoPagoCapital = table.Column<int>(type: "int", nullable: false),
                    PSV_TipoTablaAmortizaIdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false),
                    TipoCreditoIdTipoCredito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.IdContrato);
                    table.ForeignKey(
                        name: "FK_Contrato_EstatusContrato_IdEstatusContrato",
                        column: x => x.IdEstatusContrato,
                        principalSchema: "cat",
                        principalTable: "EstatusContrato",
                        principalColumn: "IdEstatusContrato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_PSV_TipoCapitalizacion_PSV_TipoCapitalizacionIdTipoCapitalizacion",
                        column: x => x.PSV_TipoCapitalizacionIdTipoCapitalizacion,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoCapitalizacion",
                        principalColumn: "IdTipoCapitalizacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_PSV_TipoPagoCapital_PSV_TipoPagoCapitalIdTipoPagoCapital",
                        column: x => x.PSV_TipoPagoCapitalIdTipoPagoCapital,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoPagoCapital",
                        principalColumn: "IdTipoPagoCapital",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_PSV_TipoTablaAmortiza_PSV_TipoTablaAmortizaIdTipoTablaAmortiza",
                        column: x => x.PSV_TipoTablaAmortizaIdTipoTablaAmortiza,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTablaAmortiza",
                        principalColumn: "IdTipoTablaAmortiza",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_SB_Periodicidad_IdPeriodicidad",
                        column: x => x.IdPeriodicidad,
                        principalSchema: "cat",
                        principalTable: "SB_Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_SB_Periodicidad_IdPeriodicidadTC",
                        column: x => x.IdPeriodicidadTC,
                        principalSchema: "cat",
                        principalTable: "SB_Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_SB_Periodicidad_IdPeriodicidad_TTA",
                        column: x => x.IdPeriodicidad_TTA,
                        principalSchema: "cat",
                        principalTable: "SB_Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_SB_TipoMoneda_IdMoneda",
                        column: x => x.IdMoneda,
                        principalSchema: "cat",
                        principalTable: "SB_TipoMoneda",
                        principalColumn: "IdTipoMoneda",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_Tasa_IdTasa",
                        column: x => x.IdTasa,
                        principalSchema: "cat",
                        principalTable: "Tasa",
                        principalColumn: "IdTasa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_Tasa_Tasa2IdTasa",
                        column: x => x.Tasa2IdTasa,
                        principalSchema: "cat",
                        principalTable: "Tasa",
                        principalColumn: "IdTasa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_TipoCalculoTasaVariable_TipoCalculoTasaVariableIdTipoCalculoTasaVariable",
                        column: x => x.TipoCalculoTasaVariableIdTipoCalculoTasaVariable,
                        principalSchema: "cat",
                        principalTable: "TipoCalculoTasaVariable",
                        principalColumn: "IdTipoCalculoTasaVariable",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_TipoCredito_IdTipoCredito",
                        column: x => x.IdTipoCredito,
                        principalSchema: "cat",
                        principalTable: "TipoCredito",
                        principalColumn: "IdTipoCredito",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contrato_TipoCredito_TipoCreditoIdTipoCredito",
                        column: x => x.TipoCreditoIdTipoCredito,
                        principalSchema: "cat",
                        principalTable: "TipoCredito",
                        principalColumn: "IdTipoCredito");
                    table.ForeignKey(
                        name: "FK_Contrato_TipoMantenimiento_TipoMantenimientoIdTipoMantenimiento",
                        column: x => x.TipoMantenimientoIdTipoMantenimiento,
                        principalSchema: "cat",
                        principalTable: "TipoMantenimiento",
                        principalColumn: "IdTipoMantenimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Contrato",
                schema: "psv",
                columns: table => new
                {
                    IdContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contrato = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdTipoCredito = table.Column<int>(type: "int", nullable: true),
                    IdEstatusContrato = table.Column<int>(type: "int", nullable: true),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcEnganche = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Enganche = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CapitalFinanciado = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdPeriodicidad = table.Column<int>(type: "int", nullable: false),
                    Plazo = table.Column<int>(type: "int", nullable: true),
                    IdMoneda = table.Column<int>(type: "int", nullable: false),
                    FecInicioContrato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecPrimeraRenta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecActivacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecFinContrato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdTasa = table.Column<int>(type: "int", nullable: false),
                    TasaBase = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PuntosMas = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PuntosPor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tasa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaBaseMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTasaMora = table.Column<int>(type: "int", nullable: false),
                    PuntosMasMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PuntosPorMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FactorMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaMora = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaldoInsoluto = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BallonPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcBallonPayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValorResidual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcValorResidual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepositoEnGarantia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OpcionDeCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PorcOpcionDeCompra = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TasaIva = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VersionTabla = table.Column<int>(type: "int", nullable: true),
                    IdTipoCalculoTasaVariable = table.Column<int>(type: "int", nullable: true),
                    NroRentasDepositoGarantia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FechaFirmaContrato = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdTipoMantenimiento = table.Column<int>(type: "int", nullable: true),
                    TasaMensual = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TasaEsVariable = table.Column<bool>(type: "bit", nullable: true),
                    IdFondeador = table.Column<int>(type: "int", nullable: false),
                    FactorFIRA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IdTipoTablaAmortiza = table.Column<int>(type: "int", nullable: false),
                    IdPeriodicidad_TTA = table.Column<int>(type: "int", nullable: true),
                    IdTipoPagoCapital = table.Column<int>(type: "int", nullable: true),
                    NoPagosIrregulares = table.Column<int>(type: "int", nullable: true),
                    IdTipoCapitalizacion = table.Column<int>(type: "int", nullable: true),
                    CapturaManualTAPasiva = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Contrato", x => x.IdContrato);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_PSV_EstatusContrato_IdEstatusContrato",
                        column: x => x.IdEstatusContrato,
                        principalSchema: "psv",
                        principalTable: "PSV_EstatusContrato",
                        principalColumn: "IdEstatusContrato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_PSV_Fondeador_IdFondeador",
                        column: x => x.IdFondeador,
                        principalSchema: "psv",
                        principalTable: "PSV_Fondeador",
                        principalColumn: "IdFondeador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_PSV_TipoCapitalizacion_IdTipoCapitalizacion",
                        column: x => x.IdTipoCapitalizacion,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoCapitalizacion",
                        principalColumn: "IdTipoCapitalizacion",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_PSV_TipoCredito_IdTipoCredito",
                        column: x => x.IdTipoCredito,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoCredito",
                        principalColumn: "IdTipoCredito",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_PSV_TipoPagoCapital_IdTipoPagoCapital",
                        column: x => x.IdTipoPagoCapital,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoPagoCapital",
                        principalColumn: "IdTipoPagoCapital",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_PSV_TipoTablaAmortiza_IdTipoTablaAmortiza",
                        column: x => x.IdTipoTablaAmortiza,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTablaAmortiza",
                        principalColumn: "IdTipoTablaAmortiza",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_SB_Periodicidad_IdPeriodicidad",
                        column: x => x.IdPeriodicidad,
                        principalSchema: "cat",
                        principalTable: "SB_Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_SB_Periodicidad_IdPeriodicidad_TTA",
                        column: x => x.IdPeriodicidad_TTA,
                        principalSchema: "cat",
                        principalTable: "SB_Periodicidad",
                        principalColumn: "IdPeriodicidad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_SB_TipoMoneda_IdMoneda",
                        column: x => x.IdMoneda,
                        principalSchema: "cat",
                        principalTable: "SB_TipoMoneda",
                        principalColumn: "IdTipoMoneda",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_Tasa_IdTasa",
                        column: x => x.IdTasa,
                        principalSchema: "cat",
                        principalTable: "Tasa",
                        principalColumn: "IdTasa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Contrato_Tasa_IdTasaMora",
                        column: x => x.IdTasaMora,
                        principalSchema: "cat",
                        principalTable: "Tasa",
                        principalColumn: "IdTasa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_LineaCredito",
                schema: "psv",
                columns: table => new
                {
                    IdLineaCredito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFondeador = table.Column<int>(type: "int", nullable: false),
                    IdMoneda = table.Column<int>(type: "int", nullable: false),
                    MontoAprobado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoDispuesto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoDisponible = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoRevolvente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaUltimaDisposicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaMaxDisposicion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAmpliacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoDisposiciones = table.Column<int>(type: "int", nullable: false),
                    PlazoMaximo = table.Column<int>(type: "int", nullable: false),
                    EsRevolvente = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    IdTasa = table.Column<int>(type: "int", nullable: true),
                    Tasa = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_LineaCredito", x => x.IdLineaCredito);
                    table.ForeignKey(
                        name: "FK_PSV_LineaCredito_PSV_Fondeador_IdFondeador",
                        column: x => x.IdFondeador,
                        principalSchema: "psv",
                        principalTable: "PSV_Fondeador",
                        principalColumn: "IdFondeador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_LineaCredito_SB_TipoMoneda_IdMoneda",
                        column: x => x.IdMoneda,
                        principalSchema: "cat",
                        principalTable: "SB_TipoMoneda",
                        principalColumn: "IdTipoMoneda",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_LineaCredito_Tasa_IdTasa",
                        column: x => x.IdTasa,
                        principalSchema: "cat",
                        principalTable: "Tasa",
                        principalColumn: "IdTasa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_ContratoPagoIrregular",
                schema: "psv",
                columns: table => new
                {
                    NoPago = table.Column<int>(type: "int", nullable: false),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    VersionTabla = table.Column<int>(type: "int", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FecVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoAplicaCapital = table.Column<bool>(type: "bit", nullable: false),
                    Procesado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_ContratoPagoIrregular", x => new { x.IdContrato, x.NoPago, x.VersionTabla });
                    table.ForeignKey(
                        name: "FK_PSV_ContratoPagoIrregular_PSV_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalSchema: "psv",
                        principalTable: "PSV_Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Movimiento",
                schema: "psv",
                columns: table => new
                {
                    IdMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NoPago = table.Column<int>(type: "int", nullable: false),
                    FecMovimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoIVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FecUltimoCambio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdContrato = table.Column<int>(type: "int", nullable: true),
                    IdFondeador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Movimiento", x => x.IdMovimiento);
                    table.ForeignKey(
                        name: "FK_PSV_Movimiento_PSV_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalSchema: "psv",
                        principalTable: "PSV_Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Movimiento_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalSchema: "cat",
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_RelActivoPasivo",
                schema: "psv",
                columns: table => new
                {
                    IdContratoActivo = table.Column<int>(type: "int", nullable: false),
                    IdContratoPasivo = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuario_Asigno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_RelActivoPasivo", x => new { x.IdContratoActivo, x.IdContratoPasivo });
                    table.ForeignKey(
                        name: "FK_PSV_RelActivoPasivo_Contrato_IdContratoActivo",
                        column: x => x.IdContratoActivo,
                        principalSchema: "sac",
                        principalTable: "Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_RelActivoPasivo_PSV_Contrato_IdContratoPasivo",
                        column: x => x.IdContratoPasivo,
                        principalSchema: "psv",
                        principalTable: "PSV_Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_TablaAmortiza",
                schema: "psv",
                columns: table => new
                {
                    IdTablaAmortiza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTipoTabla = table.Column<int>(type: "int", nullable: false),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    FecInicial = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NoPago = table.Column<int>(type: "int", nullable: true),
                    SaldoInicial = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Capital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seguro = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RequiereCalculo = table.Column<bool>(type: "bit", nullable: true),
                    VersionTabla = table.Column<int>(type: "int", nullable: false),
                    Procesado = table.Column<bool>(type: "bit", nullable: false),
                    EsValorResidual = table.Column<bool>(type: "bit", nullable: false),
                    TasaCalculo = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_TablaAmortiza", x => x.IdTablaAmortiza);
                    table.ForeignKey(
                        name: "FK_PSV_TablaAmortiza_PSV_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalSchema: "psv",
                        principalTable: "PSV_Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSV_Terminacion",
                schema: "psv",
                columns: table => new
                {
                    IdTerminacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContrato = table.Column<int>(type: "int", nullable: false),
                    IdTipoTerminacion = table.Column<int>(type: "int", nullable: false),
                    IdTipoReduccion = table.Column<int>(type: "int", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAnticipo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoAnticipo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MontoInteres = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoPena = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoIVA_Interes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoIVA_Pena = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MontoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_Terminacion", x => x.IdTerminacion);
                    table.ForeignKey(
                        name: "FK_PSV_Terminacion_PSV_Contrato_IdContrato",
                        column: x => x.IdContrato,
                        principalSchema: "psv",
                        principalTable: "PSV_Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_Terminacion_PSV_TipoTerminacion_IdTipoTerminacion",
                        column: x => x.IdTipoTerminacion,
                        principalSchema: "psv",
                        principalTable: "PSV_TipoTerminacion",
                        principalColumn: "IdTipoTerminacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_ContratoPSV_LineaCredito",
                schema: "psv",
                columns: table => new
                {
                    PSV_ContratoIdContrato = table.Column<int>(type: "int", nullable: false),
                    PSV_LineaCreditoIdLineaCredito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_ContratoPSV_LineaCredito", x => new { x.PSV_ContratoIdContrato, x.PSV_LineaCreditoIdLineaCredito });
                    table.ForeignKey(
                        name: "FK_PSV_ContratoPSV_LineaCredito_PSV_Contrato_PSV_ContratoIdContrato",
                        column: x => x.PSV_ContratoIdContrato,
                        principalSchema: "psv",
                        principalTable: "PSV_Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_ContratoPSV_LineaCredito_PSV_LineaCredito_PSV_LineaCreditoIdLineaCredito",
                        column: x => x.PSV_LineaCreditoIdLineaCredito,
                        principalSchema: "psv",
                        principalTable: "PSV_LineaCredito",
                        principalColumn: "IdLineaCredito",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PSV_RelLineaCreditoTipoCredito",
                schema: "psv",
                columns: table => new
                {
                    IdLineaCredito = table.Column<int>(type: "int", nullable: false),
                    IdTipoCredito = table.Column<int>(type: "int", nullable: false),
                    Seleccionado = table.Column<bool>(type: "bit", nullable: false),
                    TipoCreditoIdTipoCredito = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_RelLineaCreditoTipoCredito", x => new { x.IdLineaCredito, x.IdTipoCredito });
                    table.ForeignKey(
                        name: "FK_PSV_RelLineaCreditoTipoCredito_PSV_LineaCredito_IdLineaCredito",
                        column: x => x.IdLineaCredito,
                        principalSchema: "psv",
                        principalTable: "PSV_LineaCredito",
                        principalColumn: "IdLineaCredito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_RelLineaCreditoTipoCredito_TipoCredito_IdTipoCredito",
                        column: x => x.IdTipoCredito,
                        principalSchema: "cat",
                        principalTable: "TipoCredito",
                        principalColumn: "IdTipoCredito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_RelLineaCreditoTipoCredito_TipoCredito_TipoCreditoIdTipoCredito",
                        column: x => x.TipoCreditoIdTipoCredito,
                        principalSchema: "cat",
                        principalTable: "TipoCredito",
                        principalColumn: "IdTipoCredito");
                });

            migrationBuilder.CreateTable(
                name: "PSV_RelPagoMovimiento",
                schema: "psv",
                columns: table => new
                {
                    IdPagoMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPago = table.Column<int>(type: "int", nullable: false),
                    IdMovimiento = table.Column<int>(type: "int", nullable: false),
                    FecAplicacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CapitalPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InteresPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IVAPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPagado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false),
                    FecUltimoCambio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FecCancelacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Reaplicado = table.Column<bool>(type: "bit", nullable: false),
                    CausaCancelacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_RelPagoMovimiento", x => x.IdPagoMovimiento);
                    table.ForeignKey(
                        name: "FK_PSV_RelPagoMovimiento_PSV_Movimiento_IdMovimiento",
                        column: x => x.IdMovimiento,
                        principalSchema: "psv",
                        principalTable: "PSV_Movimiento",
                        principalColumn: "IdMovimiento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PSV_RelPagoMovimiento_PSV_Pago_IdPago",
                        column: x => x.IdPago,
                        principalSchema: "psv",
                        principalTable: "PSV_Pago",
                        principalColumn: "IdPago",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PSV_MovimientoPSV_Terminacion",
                schema: "psv",
                columns: table => new
                {
                    PSV_MovimientoIdMovimiento = table.Column<int>(type: "int", nullable: false),
                    PSV_TerminacionIdTerminacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSV_MovimientoPSV_Terminacion", x => new { x.PSV_MovimientoIdMovimiento, x.PSV_TerminacionIdTerminacion });
                    table.ForeignKey(
                        name: "FK_PSV_MovimientoPSV_Terminacion_PSV_Movimiento_PSV_MovimientoIdMovimiento",
                        column: x => x.PSV_MovimientoIdMovimiento,
                        principalSchema: "psv",
                        principalTable: "PSV_Movimiento",
                        principalColumn: "IdMovimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PSV_MovimientoPSV_Terminacion_PSV_Terminacion_PSV_TerminacionIdTerminacion",
                        column: x => x.PSV_TerminacionIdTerminacion,
                        principalSchema: "psv",
                        principalTable: "PSV_Terminacion",
                        principalColumn: "IdTerminacion",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_GeneroIdGenero",
                schema: "web",
                table: "Usuario",
                column: "GeneroIdGenero");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_PSV_MenuID",
                schema: "web",
                table: "Rol",
                column: "PSV_MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdEstatusContrato",
                schema: "sac",
                table: "Contrato",
                column: "IdEstatusContrato");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdMoneda",
                schema: "sac",
                table: "Contrato",
                column: "IdMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdPeriodicidad",
                schema: "sac",
                table: "Contrato",
                column: "IdPeriodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdPeriodicidad_TTA",
                schema: "sac",
                table: "Contrato",
                column: "IdPeriodicidad_TTA");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdPeriodicidadTC",
                schema: "sac",
                table: "Contrato",
                column: "IdPeriodicidadTC");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdTasa",
                schema: "sac",
                table: "Contrato",
                column: "IdTasa");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_IdTipoCredito",
                schema: "sac",
                table: "Contrato",
                column: "IdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_PSV_TipoCapitalizacionIdTipoCapitalizacion",
                schema: "sac",
                table: "Contrato",
                column: "PSV_TipoCapitalizacionIdTipoCapitalizacion");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_PSV_TipoPagoCapitalIdTipoPagoCapital",
                schema: "sac",
                table: "Contrato",
                column: "PSV_TipoPagoCapitalIdTipoPagoCapital");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_PSV_TipoTablaAmortizaIdTipoTablaAmortiza",
                schema: "sac",
                table: "Contrato",
                column: "PSV_TipoTablaAmortizaIdTipoTablaAmortiza");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_Tasa2IdTasa",
                schema: "sac",
                table: "Contrato",
                column: "Tasa2IdTasa");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TipoCalculoTasaVariableIdTipoCalculoTasaVariable",
                schema: "sac",
                table: "Contrato",
                column: "TipoCalculoTasaVariableIdTipoCalculoTasaVariable");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TipoCreditoIdTipoCredito",
                schema: "sac",
                table: "Contrato",
                column: "TipoCreditoIdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_TipoMantenimientoIdTipoMantenimiento",
                schema: "sac",
                table: "Contrato",
                column: "TipoMantenimientoIdTipoMantenimiento");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdEstatusContrato",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdEstatusContrato");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdFondeador",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdFondeador");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdMoneda",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdPeriodicidad",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdPeriodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdPeriodicidad_TTA",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdPeriodicidad_TTA");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdTasa",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdTasa");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdTasaMora",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdTasaMora");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdTipoCapitalizacion",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdTipoCapitalizacion");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdTipoCredito",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdTipoPagoCapital",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdTipoPagoCapital");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Contrato_IdTipoTablaAmortiza",
                schema: "psv",
                table: "PSV_Contrato",
                column: "IdTipoTablaAmortiza");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_ContratoPSV_LineaCredito_PSV_LineaCreditoIdLineaCredito",
                schema: "psv",
                table: "PSV_ContratoPSV_LineaCredito",
                column: "PSV_LineaCreditoIdLineaCredito");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_CuentaBancaria_IdBanco",
                schema: "psv",
                table: "PSV_CuentaBancaria",
                column: "IdBanco");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_LineaCredito_IdFondeador",
                schema: "psv",
                table: "PSV_LineaCredito",
                column: "IdFondeador");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_LineaCredito_IdMoneda",
                schema: "psv",
                table: "PSV_LineaCredito",
                column: "IdMoneda");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_LineaCredito_IdTasa",
                schema: "psv",
                table: "PSV_LineaCredito",
                column: "IdTasa");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Movimiento_IdContrato",
                schema: "psv",
                table: "PSV_Movimiento",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Movimiento_IdTipoMovimiento",
                schema: "psv",
                table: "PSV_Movimiento",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_MovimientoPSV_Terminacion_PSV_TerminacionIdTerminacion",
                schema: "psv",
                table: "PSV_MovimientoPSV_Terminacion",
                column: "PSV_TerminacionIdTerminacion");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Pago_IdCuentaBancaria",
                schema: "psv",
                table: "PSV_Pago",
                column: "IdCuentaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Pago_IdFondeador",
                schema: "psv",
                table: "PSV_Pago",
                column: "IdFondeador");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Pago_IdTipoPago",
                schema: "psv",
                table: "PSV_Pago",
                column: "IdTipoPago");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_RelActivoPasivo_IdContratoPasivo",
                schema: "psv",
                table: "PSV_RelActivoPasivo",
                column: "IdContratoPasivo");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_RelLineaCreditoTipoCredito_IdTipoCredito",
                schema: "psv",
                table: "PSV_RelLineaCreditoTipoCredito",
                column: "IdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_RelLineaCreditoTipoCredito_TipoCreditoIdTipoCredito",
                schema: "psv",
                table: "PSV_RelLineaCreditoTipoCredito",
                column: "TipoCreditoIdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_RelPagoMovimiento_IdMovimiento",
                schema: "psv",
                table: "PSV_RelPagoMovimiento",
                column: "IdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_RelPagoMovimiento_IdPago",
                schema: "psv",
                table: "PSV_RelPagoMovimiento",
                column: "IdPago");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TablaAmortiza_IdContrato",
                schema: "psv",
                table: "PSV_TablaAmortiza",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Terminacion_IdContrato",
                schema: "psv",
                table: "PSV_Terminacion",
                column: "IdContrato");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_Terminacion_IdTipoTerminacion",
                schema: "psv",
                table: "PSV_Terminacion",
                column: "IdTipoTerminacion");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoCredito_IdEmpresa",
                schema: "psv",
                table: "PSV_TipoCredito",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoCredito_IdTipoMovimiento",
                schema: "psv",
                table: "PSV_TipoCredito",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoCredito_IdTipoMovimiento_Mora",
                schema: "psv",
                table: "PSV_TipoCredito",
                column: "IdTipoMovimiento_Mora");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoCredito_IdTipoTablaAmortiza",
                schema: "psv",
                table: "PSV_TipoCredito",
                column: "IdTipoTablaAmortiza");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoCreditoPSV_TipoTerminacion_PSV_TipoTerminacionIdTipoTerminacion",
                schema: "psv",
                table: "PSV_TipoCreditoPSV_TipoTerminacion",
                column: "PSV_TipoTerminacionIdTipoTerminacion");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTablaAmortizaPeriodicidad_IdPeriodicidad",
                schema: "psv",
                table: "PSV_TipoTablaAmortizaPeriodicidad",
                column: "IdPeriodicidad");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTablaAmortizaTipoCapitalizacion_IdTipoCapitalizacion",
                schema: "psv",
                table: "PSV_TipoTablaAmortizaTipoCapitalizacion",
                column: "IdTipoCapitalizacion");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTablaAmortizaTipoPagoCapital_IdTipoPagoCapital",
                schema: "psv",
                table: "PSV_TipoTablaAmortizaTipoPagoCapital",
                column: "IdTipoPagoCapital");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_IdCuentaBancariaDeposito",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "IdCuentaBancariaDeposito");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_IdEstatusContratoTerminacion",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "IdEstatusContratoTerminacion");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_IdTipoMovimientoBaja",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "IdTipoMovimientoBaja");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_IdTipoMovimientoInteres",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "IdTipoMovimientoInteres");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_IdTipoMovimientoPena",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "IdTipoMovimientoPena");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_IdTipoPagoDeposito",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "IdTipoPagoDeposito");

            migrationBuilder.CreateIndex(
                name: "IX_PSV_TipoTerminacion_PSV_CuentaBancariaIdCuentaBancaria",
                schema: "psv",
                table: "PSV_TipoTerminacion",
                column: "PSV_CuentaBancariaIdCuentaBancaria");

            migrationBuilder.CreateIndex(
                name: "IX_Tasa_IdTipoCredito",
                schema: "cat",
                table: "Tasa",
                column: "IdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_Tasa_TipoCreditoIdTipoCredito",
                schema: "cat",
                table: "Tasa",
                column: "TipoCreditoIdTipoCredito");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdEmpresa",
                schema: "cat",
                table: "TipoCredito",
                column: "IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimiento",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoBallon",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoBallon");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoCancelCheque",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoCancelCheque");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoDeposito",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoDeposito");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoEnganche",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoEnganche");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoGastos",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoGastos");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoMora",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoMora");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoNoDevuelto",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoNoDevuelto");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoOpcion",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoOpcion");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoSeguro",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoSeguro");

            migrationBuilder.CreateIndex(
                name: "IX_TipoCredito_IdTipoMovimientoValorResidual",
                schema: "cat",
                table: "TipoCredito",
                column: "IdTipoMovimientoValorResidual");

            migrationBuilder.CreateIndex(
                name: "IX_TipoMovimiento_IdTipoGeneracionComprobante",
                schema: "cat",
                table: "TipoMovimiento",
                column: "IdTipoGeneracionComprobante");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_PSV_Menu_PSV_MenuID",
                schema: "web",
                table: "Rol",
                column: "PSV_MenuID",
                principalSchema: "psv",
                principalTable: "PSV_Menu",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Genero_GeneroIdGenero",
                schema: "web",
                table: "Usuario",
                column: "GeneroIdGenero",
                principalSchema: "cat",
                principalTable: "Genero",
                principalColumn: "IdGenero");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_PSV_Menu_PSV_MenuID",
                schema: "web",
                table: "Rol");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Genero_GeneroIdGenero",
                schema: "web",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Catalogo",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Colonia",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Genero",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "PSV_Archivo",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Bitacora",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_ContratoPagoIrregular",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_ContratoPSV_LineaCredito",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Menu",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_MovimientoPSV_Terminacion",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Parameter",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_RelActivoPasivo",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_RelLineaCreditoTipoCredito",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_RelPagoMovimiento",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TablaAmortiza",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoCreditoPSV_TipoTerminacion",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoTablaAmortizaPeriodicidad",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoTablaAmortizaTipoCapitalizacion",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoTablaAmortizaTipoPagoCapital",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Terminacion",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "Contrato",
                schema: "sac");

            migrationBuilder.DropTable(
                name: "PSV_LineaCredito",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Movimiento",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Pago",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoTerminacion",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "EstatusContrato",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "TipoCalculoTasaVariable",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "TipoMantenimiento",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "PSV_Contrato",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_CuentaBancaria",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoPago",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_EstatusContrato",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_Fondeador",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoCapitalizacion",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoCredito",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoPagoCapital",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "SB_Periodicidad",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "SB_TipoMoneda",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Tasa",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "PSV_Banco",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "PSV_TipoTablaAmortiza",
                schema: "psv");

            migrationBuilder.DropTable(
                name: "TipoCredito",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "TipoMovimiento",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "TipoGeneracionComprobante",
                schema: "cat");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_GeneroIdGenero",
                schema: "web",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Rol_PSV_MenuID",
                schema: "web",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "GeneroIdGenero",
                schema: "web",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PSV_MenuID",
                schema: "web",
                table: "Rol");
        }
    }
}
