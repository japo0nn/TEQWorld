using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TotalPrice = table.Column<double>(type: "REAL", nullable: false),
                    CreateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UnitOfMeasure = table.Column<string>(type: "TEXT", nullable: false),
                    PricePerUnit = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    IsUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ItemsGroupId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    UpdateTime = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemsGroups_ItemsGroupId",
                        column: x => x.ItemsGroupId,
                        principalTable: "ItemsGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemsGroupId",
                table: "Items",
                column: "ItemsGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ItemsGroups");
        }
    }
}
