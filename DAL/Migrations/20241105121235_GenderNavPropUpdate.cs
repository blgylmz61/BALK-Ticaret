using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class GenderNavPropUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_GenderId",
                table: "UserDetails");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_GenderId",
                table: "UserDetails",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserDetails_GenderId",
                table: "UserDetails");

            migrationBuilder.CreateIndex(
                name: "IX_UserDetails_GenderId",
                table: "UserDetails",
                column: "GenderId",
                unique: true);
        }
    }
}
