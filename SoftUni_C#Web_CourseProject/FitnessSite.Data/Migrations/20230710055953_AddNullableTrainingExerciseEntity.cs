using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class AddNullableTrainingExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Exercises_ExerciseId",
                table: "TrainingExercise");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercise_Trainings_TrainingId",
                table: "TrainingExercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExercise",
                table: "TrainingExercise");

            migrationBuilder.RenameTable(
                name: "TrainingExercise",
                newName: "TrainingExercises");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExercise_ExerciseId",
                table: "TrainingExercises",
                newName: "IX_TrainingExercises_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises",
                columns: new[] { "TrainingId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId",
                table: "TrainingExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingId",
                table: "TrainingExercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingId",
                table: "TrainingExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrainingExercises",
                table: "TrainingExercises");

            migrationBuilder.RenameTable(
                name: "TrainingExercises",
                newName: "TrainingExercise");

            migrationBuilder.RenameIndex(
                name: "IX_TrainingExercises_ExerciseId",
                table: "TrainingExercise",
                newName: "IX_TrainingExercise_ExerciseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrainingExercise",
                table: "TrainingExercise",
                columns: new[] { "TrainingId", "ExerciseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Exercises_ExerciseId",
                table: "TrainingExercise",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercise_Trainings_TrainingId",
                table: "TrainingExercise",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
