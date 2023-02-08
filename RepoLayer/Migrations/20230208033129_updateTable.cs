using Microsoft.EntityFrameworkCore.Migrations;

namespace RepoLayer.Migrations
{
    public partial class updateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "EmpCFATable",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "EmpCFATable",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "EmpCFATable");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "EmpCFATable");
        }
    }
}
