using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class SpellingMistakeFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "imageDatatwo",
                table: "ProductImageEntity",
                newName: "ImageDatatwo");

            migrationBuilder.RenameColumn(
                name: "imageDatathree",
                table: "ProductImageEntity",
                newName: "ImageDatathree");

            migrationBuilder.RenameColumn(
                name: "imageDatafour",
                table: "ProductImageEntity",
                newName: "ImageDatafour");

            migrationBuilder.RenameColumn(
                name: "imageDataOne",
                table: "ProductImageEntity",
                newName: "ImageDataOne");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageDatatwo",
                table: "ProductImageEntity",
                newName: "imageDatatwo");

            migrationBuilder.RenameColumn(
                name: "ImageDatathree",
                table: "ProductImageEntity",
                newName: "imageDatathree");

            migrationBuilder.RenameColumn(
                name: "ImageDatafour",
                table: "ProductImageEntity",
                newName: "imageDatafour");

            migrationBuilder.RenameColumn(
                name: "ImageDataOne",
                table: "ProductImageEntity",
                newName: "imageDataOne");
        }
    }
}
