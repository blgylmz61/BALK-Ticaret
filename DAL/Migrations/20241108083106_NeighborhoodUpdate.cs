using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class NeighborhoodUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NeighborhoodId",
                table: "ProductDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_NeighborhoodId",
                table: "ProductDetails",
                column: "NeighborhoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Neighborhoods_NeighborhoodId",
                table: "ProductDetails",
                column: "NeighborhoodId",
                principalTable: "Neighborhoods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Neighborhoods_NeighborhoodId",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_NeighborhoodId",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "NeighborhoodId",
                table: "ProductDetails");
        }
    }
}
