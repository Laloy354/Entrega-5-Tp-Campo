using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCondicionDeVenta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCondicionDeVenta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoMedioPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMedioPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoResponsableIVA",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoResponsableIVA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTarjeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Codigo = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    MarcaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insumo_Marca_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaPrecio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoCondicionDeVentaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaPrecio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaPrecio_TipoCondicionDeVenta_TipoCondicionDeVentaId",
                        column: x => x.TipoCondicionDeVentaId,
                        principalTable: "TipoCondicionDeVenta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FechaVencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ImporteTotal = table.Column<float>(type: "real", nullable: false),
                    NumeroComprobante = table.Column<int>(type: "integer", nullable: false),
                    SubTotal = table.Column<float>(type: "real", nullable: false),
                    TipoMedioPagoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Factura_TipoMedioPago_TipoMedioPagoId",
                        column: x => x.TipoMedioPagoId,
                        principalTable: "TipoMedioPago",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Afiliado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Cuit = table.Column<string>(type: "text", nullable: false),
                    FechaDeAgremiacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumeroAgremiado = table.Column<int>(type: "integer", nullable: false),
                    TipoResponsableIVAId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Afiliado_TipoResponsableIVA_TipoResponsableIVAId",
                        column: x => x.TipoResponsableIVAId,
                        principalTable: "TipoResponsableIVA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    InsumoId = table.Column<int>(type: "integer", nullable: false),
                    ListaPrecioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Precio_Insumo_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Precio_ListaPrecio_ListaPrecioId",
                        column: x => x.ListaPrecioId,
                        principalTable: "ListaPrecio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cantidad = table.Column<int>(type: "integer", nullable: false),
                    Precio = table.Column<int>(type: "integer", nullable: false),
                    FacturaId = table.Column<int>(type: "integer", nullable: false),
                    InsumoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Insumo_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "Insumo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cobranza",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MontoTotal = table.Column<float>(type: "real", nullable: false),
                    AfiliadoId = table.Column<int>(type: "integer", nullable: false),
                    FacturaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobranza", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobranza_Afiliado_AfiliadoId",
                        column: x => x.AfiliadoId,
                        principalTable: "Afiliado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cobranza_Factura_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Factura",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    TipoTarjetaId = table.Column<int>(type: "integer", nullable: false),
                    CobranzaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjeta_Cobranza_CobranzaId",
                        column: x => x.CobranzaId,
                        principalTable: "Cobranza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarjeta_TipoTarjeta_TipoTarjetaId",
                        column: x => x.TipoTarjetaId,
                        principalTable: "TipoTarjeta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    MontoTransferencia = table.Column<int>(type: "integer", nullable: false),
                    IdCobranza = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transferencia_Cobranza_IdCobranza",
                        column: x => x.IdCobranza,
                        principalTable: "Cobranza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Afiliado_TipoResponsableIVAId",
                table: "Afiliado",
                column: "TipoResponsableIVAId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranza_AfiliadoId",
                table: "Cobranza",
                column: "AfiliadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cobranza_FacturaId",
                table: "Cobranza",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_TipoMedioPagoId",
                table: "Factura",
                column: "TipoMedioPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_FacturaId",
                table: "FacturaDetalle",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_InsumoId",
                table: "FacturaDetalle",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumo_MarcaId",
                table: "Insumo",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_ListaPrecio_TipoCondicionDeVentaId",
                table: "ListaPrecio",
                column: "TipoCondicionDeVentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_InsumoId",
                table: "Precio",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_Precio_ListaPrecioId",
                table: "Precio",
                column: "ListaPrecioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_CobranzaId",
                table: "Tarjeta",
                column: "CobranzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjeta_TipoTarjetaId",
                table: "Tarjeta",
                column: "TipoTarjetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencia_IdCobranza",
                table: "Transferencia",
                column: "IdCobranza");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaDetalle");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Transferencia");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "ListaPrecio");

            migrationBuilder.DropTable(
                name: "TipoTarjeta");

            migrationBuilder.DropTable(
                name: "Cobranza");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "TipoCondicionDeVenta");

            migrationBuilder.DropTable(
                name: "Afiliado");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "TipoResponsableIVA");

            migrationBuilder.DropTable(
                name: "TipoMedioPago");
        }
    }
}
