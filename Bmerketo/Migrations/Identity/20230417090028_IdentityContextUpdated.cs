using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bmerketo.Migrations.Identity
{
    /// <inheritdoc />
    public partial class IdentityContextUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "400e52f8-1379-464e-8652-ac07a47a16dc", null, "admin", null },
                    { "bdbbdea2-299a-4746-8011-1c573b25313b", null, "customer", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "400e52f8-1379-464e-8652-ac07a47a16dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdbbdea2-299a-4746-8011-1c573b25313b");
        }
    }
}
