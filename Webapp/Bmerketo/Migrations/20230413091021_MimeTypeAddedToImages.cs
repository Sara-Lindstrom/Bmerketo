using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class MimeTypeAddedToImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageMimeType",
                table: "Users",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageFourMimeType",
                table: "ProductImageEntity",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageOneMimeType",
                table: "ProductImageEntity",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageTwoMimeType",
                table: "ProductImageEntity",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImagethreeMimeType",
                table: "ProductImageEntity",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryImageMimeType",
                table: "ProductImageEntity",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageMimeType",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageFourMimeType",
                table: "ProductImageEntity");

            migrationBuilder.DropColumn(
                name: "ImageOneMimeType",
                table: "ProductImageEntity");

            migrationBuilder.DropColumn(
                name: "ImageTwoMimeType",
                table: "ProductImageEntity");

            migrationBuilder.DropColumn(
                name: "ImagethreeMimeType",
                table: "ProductImageEntity");

            migrationBuilder.DropColumn(
                name: "PrimaryImageMimeType",
                table: "ProductImageEntity");
        }
    }
}
