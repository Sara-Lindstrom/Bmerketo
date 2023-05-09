using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class CorrectedSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "companyName",
                table: "Contacts",
                newName: "CompanyName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Contacts",
                newName: "companyName");
        }
    }
}
