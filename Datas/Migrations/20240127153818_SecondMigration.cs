using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AfiliadoId",
                table: "Factura",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Factura_AfiliadoId",
                table: "Factura",
                column: "AfiliadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Afiliado_AfiliadoId",
                table: "Factura",
                column: "AfiliadoId",
                principalTable: "Afiliado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Afiliado_AfiliadoId",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Factura_AfiliadoId",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "AfiliadoId",
                table: "Factura");
        }
    }
}
