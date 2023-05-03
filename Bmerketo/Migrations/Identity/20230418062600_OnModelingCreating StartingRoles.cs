using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bmerketo.Migrations.Identity
{
    /// <inheritdoc />
    public partial class OnModelingCreatingStartingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2579d5e3-eacd-4fe1-aaf2-30e31599c852", null, "user", "USER" },
                    { "4f642038-1a3e-40e3-9514-382e32242c20", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2579d5e3-eacd-4fe1-aaf2-30e31599c852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f642038-1a3e-40e3-9514-382e32242c20");
        }
    }
}
