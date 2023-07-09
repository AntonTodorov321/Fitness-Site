using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class RemoveMuscleExerciseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MuscleExercises");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises");

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MuscleExercises",
                keyColumns: new[] { "ExerciseId", "MuscleId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MuscleExercises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId", "Id" });

            migrationBuilder.InsertData(
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "Id", "MuscleId" },
                values: new object[] { 1, 2, 2 });

            migrationBuilder.InsertData(
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "Id", "MuscleId" },
                values: new object[] { 1, 1, 7 });
        }
    }
}
