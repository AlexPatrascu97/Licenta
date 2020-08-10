using Microsoft.EntityFrameworkCore.Migrations;

namespace Licenta_Back_End.Migrations
{
    public partial class tasknameandempnames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskOwnerFirstName",
                table: "Tasks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskOwnerLastName",
                table: "Tasks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskOwnerFirstName",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "TaskOwnerLastName",
                table: "Tasks");
        }
    }
}
