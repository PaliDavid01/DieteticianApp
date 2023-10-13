using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Fat = table.Column<float>(type: "REAL", nullable: false),
                    Protein = table.Column<float>(type: "REAL", nullable: false),
                    Kilocalorie = table.Column<float>(type: "REAL", nullable: false),
                    Kilojoule = table.Column<float>(type: "REAL", nullable: false),
                    Carbohydrate = table.Column<float>(type: "REAL", nullable: false),
                    Cholesterol = table.Column<float>(type: "REAL", nullable: false),
                    Saturatedfat = table.Column<float>(type: "REAL", nullable: false),
                    Transfat = table.Column<float>(type: "REAL", nullable: false),
                    Natrium_mg = table.Column<float>(type: "REAL", nullable: false),
                    Fluorite_mg = table.Column<float>(type: "REAL", nullable: false),
                    Salt = table.Column<float>(type: "REAL", nullable: false),
                    Sugar = table.Column<float>(type: "REAL", nullable: false),
                    Scale = table.Column<int>(type: "INTEGER", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StorageItem",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    PackageSize = table.Column<int>(type: "INTEGER", nullable: false),
                    StoredAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    StoredBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageItem_Material_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageItem_MaterialId",
                table: "StorageItem",
                column: "MaterialId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StorageItem");

            migrationBuilder.DropTable(
                name: "Material");
        }
    }
}
