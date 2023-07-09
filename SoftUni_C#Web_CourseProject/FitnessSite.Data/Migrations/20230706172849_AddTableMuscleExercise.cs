using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddTableMuscleExercise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleExercise_Exercises_ExerciseId",
                table: "MuscleExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_MuscleExercise_Muscles_MuscleId",
                table: "MuscleExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleExercise",
                table: "MuscleExercise");

            migrationBuilder.RenameTable(
                name: "MuscleExercise",
                newName: "MuscleExercises");

            migrationBuilder.RenameIndex(
                name: "IX_MuscleExercise_MuscleId",
                table: "MuscleExercises",
                newName: "IX_MuscleExercises_MuscleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises",
                columns: new[] { "ExerciseId", "MuscleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleExercises_Exercises_ExerciseId",
                table: "MuscleExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleExercises_Muscles_MuscleId",
                table: "MuscleExercises",
                column: "MuscleId",
                principalTable: "Muscles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MuscleExercises_Exercises_ExerciseId",
                table: "MuscleExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_MuscleExercises_Muscles_MuscleId",
                table: "MuscleExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MuscleExercises",
                table: "MuscleExercises");

            migrationBuilder.RenameTable(
                name: "MuscleExercises",
                newName: "MuscleExercise");

            migrationBuilder.RenameIndex(
                name: "IX_MuscleExercises_MuscleId",
                table: "MuscleExercise",
                newName: "IX_MuscleExercise_MuscleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MuscleExercise",
                table: "MuscleExercise",
                columns: new[] { "ExerciseId", "MuscleId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleExercise_Exercises_ExerciseId",
                table: "MuscleExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MuscleExercise_Muscles_MuscleId",
                table: "MuscleExercise",
                column: "MuscleId",
                principalTable: "Muscles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
