using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMSAPI.Migrations
{
    public partial class addedTireItemModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TireItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrciNo = table.Column<int>(type: "int", nullable: true),
                    PoNo = table.Column<int>(type: "int", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Unitofmeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiresize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tirebrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebossedNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TireItems");
        }
    }
}
