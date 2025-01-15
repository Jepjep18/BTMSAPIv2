using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMSAPI.Migrations
{
    public partial class addedTireDisposedItemsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TireDisposedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisposalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndorsedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisposalType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireReturnIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisposalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireDisposedItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TireDisposedItems");
        }
    }
}
