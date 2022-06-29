using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
//See Database with View

namespace OdeToFood.Data.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable( //Creates tables for me
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(280)", maxLength: 280, nullable: true),
                    Food = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    Animatronics = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
