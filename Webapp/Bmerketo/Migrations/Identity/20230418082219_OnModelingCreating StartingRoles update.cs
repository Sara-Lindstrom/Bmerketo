using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bmerketo.Migrations.Identity
{
    /// <inheritdoc />
    public partial class OnModelingCreatingStartingRolesupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2579d5e3-eacd-4fe1-aaf2-30e31599c852");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f642038-1a3e-40e3-9514-382e32242c20");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d669d26-c606-435c-821e-0d6db4ebb7b3", null, "user", "USER" },
                    { "bd18d538-f39c-4ebe-aa8d-8c1236b33905", null, "admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d669d26-c606-435c-821e-0d6db4ebb7b3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd18d538-f39c-4ebe-aa8d-8c1236b33905");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2579d5e3-eacd-4fe1-aaf2-30e31599c852", null, "user", "USER" },
                    { "4f642038-1a3e-40e3-9514-382e32242c20", null, "admin", "ADMIN" }
                });
        }
    }
}
