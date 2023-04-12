using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class imageStorageUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrimaryImageData",
                table: "ProductImageEntity",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageDatatwo",
                table: "ProductImageEntity",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageDatathree",
                table: "ProductImageEntity",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageDatafour",
                table: "ProductImageEntity",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageDataOne",
                table: "ProductImageEntity",
                type: "varchar(MAX)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "PrimaryImageData",
                table: "ProductImageEntity",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageDatatwo",
                table: "ProductImageEntity",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageDatathree",
                table: "ProductImageEntity",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageDatafour",
                table: "ProductImageEntity",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ImageDataOne",
                table: "ProductImageEntity",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(MAX)");
        }
    }
}
