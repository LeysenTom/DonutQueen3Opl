using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DonutQueenAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donut",
                columns: table => new
                {
                    DonutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Afbeelding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Glazuur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVegan = table.Column<bool>(type: "bit", nullable: true),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topping = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vulling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinkelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donut", x => x.DonutId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donut");
        }
    }
}
