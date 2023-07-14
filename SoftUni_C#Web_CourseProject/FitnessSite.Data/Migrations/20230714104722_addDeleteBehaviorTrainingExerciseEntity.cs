using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessSite.Data.Migrations
{
    public partial class addDeleteBehaviorTrainingExerciseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingId",
                table: "TrainingExercises");

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId",
                table: "TrainingExercises",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingId",
                table: "TrainingExercises",
                column: "TrainingId",
                principalTable: "Trainings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Exercises_ExerciseId",
                table: "TrainingExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrainingExercises_Trainings_TrainingId",
                table: "TrainingExercises");

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
    }
}
