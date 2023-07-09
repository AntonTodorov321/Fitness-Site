using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddMuscleExerciseIdId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId" });
        }
    }
}
