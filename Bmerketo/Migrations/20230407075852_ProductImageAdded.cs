using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class ProductImageAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProductImageDataId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ProductImageEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimairyImageData = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    imageDataOne = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    imageDatatwo = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    imageDatathree = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    imageDatafour = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImageEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductImageDataId",
                table: "Products",
                column: "ProductImageDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductImageEntity_ProductImageDataId",
                table: "Products",
                column: "ProductImageDataId",
                principalTable: "ProductImageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductImageEntity_ProductImageDataId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductImageEntity");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductImageDataId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImageDataId",
                table: "Products");
        }
    }
}
