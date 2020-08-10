using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta_Back_End.Migrations
{
    public partial class projdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "Projects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "Projects");
        }
    }
}
