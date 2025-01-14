using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMSAPI.Migrations
{
    public partial class AddBatteryReturnedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryReturnedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Endorsedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryReleasedItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryReturnedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryReturnedItems_BatteryReleasedItems_BatteryReleasedItemId",
                        column: x => x.BatteryReleasedItemId,
                        principalTable: "BatteryReleasedItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryReturnedItems_BatteryReleasedItemId",
                table: "BatteryReturnedItems",
                column: "BatteryReleasedItemId",
                unique: true,
                filter: "[BatteryReleasedItemId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryReturnedItems");
        }
    }
}
