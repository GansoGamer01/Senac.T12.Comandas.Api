using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace comanda.api.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PedidoCozinhas_ComandaId",
                table: "PedidoCozinhas",
                column: "ComandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoCozinhas_Comandas_ComandaId",
                table: "PedidoCozinhas",
                column: "ComandaId",
                principalTable: "Comandas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoCozinhas_Comandas_ComandaId",
                table: "PedidoCozinhas");

            migrationBuilder.DropIndex(
                name: "IX_PedidoCozinhas_ComandaId",
                table: "PedidoCozinhas");
        }
    }
}
