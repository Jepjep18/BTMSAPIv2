using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMSAPI.Migrations
{
    public partial class AddBatteryReleasedItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryReleasedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imjno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReleasedReceivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserplateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryItemId = table.Column<int>(type: "int", nullable: true),
                    OldSnDebossedNo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryReleasedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryReleasedItems_BatteryItems_BatteryItemId",
                        column: x => x.BatteryItemId,
                        principalTable: "BatteryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryReleasedItems_BatteryItemId",
                table: "BatteryReleasedItems",
                column: "BatteryItemId",
                unique: true,
                filter: "[BatteryItemId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryReleasedItems");
        }
    }
}
