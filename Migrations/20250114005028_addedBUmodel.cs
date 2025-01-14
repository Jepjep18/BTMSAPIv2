using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BTMSAPI.Migrations
{
    public partial class addedBUmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessunitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnit", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUnit");
        }
    }
}
