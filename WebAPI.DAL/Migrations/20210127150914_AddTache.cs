using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.DAL.Migrations
{
    public partial class AddTache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "TaskModels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "TaskModels");
        }
    }
}
