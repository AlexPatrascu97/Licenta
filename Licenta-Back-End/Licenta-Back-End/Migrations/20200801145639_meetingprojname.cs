using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta_Back_End.Migrations
{
    public partial class meetingprojname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Meetings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Meetings");
        }
    }
}
