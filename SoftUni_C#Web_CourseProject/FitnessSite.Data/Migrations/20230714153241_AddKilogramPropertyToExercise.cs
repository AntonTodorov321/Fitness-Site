using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddKilogramPropertyToExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Kilogram",
                table: "Exercises",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kilogram",
                table: "Exercises");
        }
    }
}
