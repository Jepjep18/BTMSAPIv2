using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMSAPI.Migrations
{
    public partial class addedTireReleasedItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TireReleasedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imjno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abfiserialno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireItemId = table.Column<int>(type: "int", nullable: true),
                    OldSnDebossedNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireReleasedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireReleasedItems_TireItems_TireItemId",
                        column: x => x.TireItemId,
                        principalTable: "TireItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TireReleasedItems_TireItemId",
                table: "TireReleasedItems",
                column: "TireItemId",
                unique: true,
                filter: "[TireItemId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TireReleasedItems");
        }
    }
}
