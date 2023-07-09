using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class SeedMuscleEx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "Id", "MuscleId" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "Id", "MuscleId" },
                values: new object[] { 1, 1, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "Id", "MuscleId" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "Id", "MuscleId" },
                keyValues: new object[] { 1, 1, 7 });
        }
    }
}
